using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ILogger<CalculoController> _logger;
        private readonly IEnumerable<ICalculoDivida> _calculadoresDivida;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IDividaRepository _dividaRepository;

        public CalculoController(
            ILogger<CalculoController> logger,
            IEnumerable<ICalculoDivida> calculadoresDivida,
            ICarteiraRepository carteiraRepository,
            IDividaRepository dividaRepository)
        {
            _logger = logger;
            _calculadoresDivida = calculadoresDivida;
            _carteiraRepository = carteiraRepository;
            _dividaRepository = dividaRepository;
        }

        [HttpGet("v1/calculo/{idDevedor}/{idDivida}")]
        public async Task<IActionResult> GetCalculoDivida(int idDevedor, int idDivida)
        {
            _logger.LogInformation($"Calculo da dívida {idDivida} do devedor {idDevedor}");

            Divida divida;
            Carteira carteira;
            List<ParcelaNegociacao> parcelas = null;

            _logger.LogInformation($"Carregando dívida {idDivida}");
            divida = await _dividaRepository.GetAsync(idDevedor);

            if (divida.IdDevedor != idDevedor)
            {
                _logger.LogInformation($"Dívida {idDivida} não pertence ao devedor {idDevedor}");
                return Unauthorized(new { result = false, message = "A dívida não pertence ao devedor informado" });
            }

            _logger.LogInformation($"Carregando carteira da dívida {idDivida}");
            carteira = await _carteiraRepository.GetAsync(divida.IdCarteira);

            _logger.LogInformation($"Calculando parcelamento da dívida {idDivida}");
            foreach (var calculador in _calculadoresDivida)
            {
                if (calculador.Accept(carteira))
                {
                    parcelas = calculador.Calcular(carteira, divida);
                    _logger.LogInformation($"Cálculo do parcelamento da dívida {idDivida} finalizado");
                    break;
                }
            }

            if (parcelas == null)
            {
                _logger.LogInformation($"Método de cálculo para a carteira {carteira.Nome} não foi implementado.");
                return Ok(new { result = false, message = $"Método de cálculo para a carteira {carteira.Nome} não foi implementado." });
            }

            _logger.LogInformation($"Cálculo do parcelamento da dívida {idDivida} realizado com sucesso");
            return Ok(new { result = true, message = "", parcelas });
        }
    }
}
