using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Service
{
    public class CalculoDividaService : ICalculoDividaService
    {
        private readonly ILogger<CalculoDividaService> _logger;
        private readonly IEnumerable<ICalculoDivida> _calculadoresDivida;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IDividaRepository _dividaRepository;
        private readonly IDevedorRepository _devedorRepository;

        public CalculoDividaService(
            ILogger<CalculoDividaService> logger,
            IEnumerable<ICalculoDivida> calculadoresDivida,
            ICarteiraRepository carteiraRepository,
            IDividaRepository dividaRepository,
            IDevedorRepository devedorRepository)
        {
            _logger = logger;
            _calculadoresDivida = calculadoresDivida;
            _carteiraRepository = carteiraRepository;
            _devedorRepository = devedorRepository;
            _dividaRepository = dividaRepository;
        }

        public async Task<ResultadoPadrao<Negociacao>> Calcular(int idDivida, int idDevedor)
        {
            var resultado = new ResultadoPadrao<Negociacao>();
            Carteira carteira;
            Divida divida;

            _logger.LogInformation($"Validando devedor {idDevedor}");
            if (await _devedorRepository.GetAsync(idDevedor) == null)
            {
                _logger.LogInformation($"Devedor {idDevedor} não existe");
                resultado.Sucesso = false;
                resultado.Mensagem = "O devedor informado não existe";
                return resultado;
            }

            _logger.LogInformation($"Carregando dívida {idDivida}");
            divida = await _dividaRepository.GetAsync(idDivida);

            if (divida == null)
            {
                _logger.LogInformation($"Dívida {idDivida} não existe ou não pertence ao devedor {idDevedor}");

                resultado.Sucesso = false;
                resultado.Mensagem = "A dívida não existe ou não pertence ao devedor informado";
                return resultado;
            }

            if (divida.IdDevedor != idDevedor)
            {
                _logger.LogInformation($"Dívida {idDivida} não pertence ao devedor {idDevedor}");
                resultado.Sucesso = false;
                resultado.Mensagem = "A dívida não pertence ao devedor informado";
                return resultado;
            }

            _logger.LogInformation($"Carregando carteira da dívida {idDivida}");
            carteira = await _carteiraRepository.GetAsync(divida.IdCarteira);

            _logger.LogInformation($"Calculando parcelamento da dívida {idDivida}");
            resultado.Resultado = new Negociacao();
            resultado.Resultado.Parcelas = CalcularParcelas(divida, carteira);
            resultado.Resultado.Divida = divida;
            resultado.Resultado.QtdParcelas = resultado.Resultado.Parcelas.Count;
            resultado.Resultado.TelefoneContato = carteira.TelefoneContato;
            resultado.Sucesso = true;

            return resultado;
        }

        private List<ParcelaNegociacao> CalcularParcelas(Divida divida, Carteira carteira)
        {
            List<ParcelaNegociacao> parcelas = null;

            foreach (var calculador in _calculadoresDivida)
            {
                if (calculador.Accept(carteira))
                {
                    parcelas = calculador.Calcular(carteira, divida);
                    _logger.LogInformation($"Cálculo do parcelamento da dívida {divida.Id} finalizado");
                    break;
                }
            }

            return parcelas;
        }
    }
}
