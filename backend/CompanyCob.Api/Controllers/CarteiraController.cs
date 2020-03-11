using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompanyCob.Domain.Model;
using System.Threading.Tasks;
using CompanyCob.Api.ViewModel;
using AutoMapper;
using CompanyCob.Domain.Model.Interface.Repository;
using Flunt.Notifications;
using CompanyCob.Api.Utils;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly ILogger<CarteiraController> _logger;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IDividaRepository _dividaRepository;
        private readonly IDevedorRepository _devedorRepository;
        private readonly IMapper _mapper;

        public CarteiraController(
            ILogger<CarteiraController> logger,
            ICarteiraRepository carteiraRepository,
            IDividaRepository dividaRepository,
            IDevedorRepository devedorRepository,
            IMapper mapper)
        {
            _logger = logger;
            _carteiraRepository = carteiraRepository;
            _dividaRepository = dividaRepository;
            _devedorRepository = devedorRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/admin/carteiras")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Carregando todas as carteiras");
            var results = await _carteiraRepository.GetAllAsync();

            _logger.LogInformation("Carregando dívidas das carteiras");
            foreach (var result in results)
            {
                result.Dividas = await _dividaRepository.GetByCarteiraAsync(result);
                foreach (var divida in result.Dividas)
                {
                    divida.Devedor = await _devedorRepository.GetAsync(divida.IdDevedor);
                }
            }

            _logger.LogInformation("Quantidade carteiras: {0}", results.Count);
            return Ok(results);
        }

        [HttpGet("v1/admin/carteiras/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Carregando carteira. ID: {0}", id);

            var result = await _carteiraRepository.GetAsync(id);
            if (result == null)
            {
                _logger.LogInformation("Carteira não encontrada");
                return NotFound();
            }

            _logger.LogInformation("Carregando dívidas da carteira");
            result.Dividas = await _dividaRepository.GetByCarteiraAsync(result);

            _logger.LogInformation("Carregando devedores");
            foreach (var divida in result.Dividas)
            {
                divida.Devedor = await _devedorRepository.GetAsync(divida.IdDevedor);
            }

            _logger.LogInformation("Carteira carregada com sucesso");
            return Ok(result);
        }

        [HttpPost("v1/admin/carteiras")]
        public async Task<IActionResult> Post([FromBody] CarteiraEditViewModel model)
        {
            _logger.LogInformation("Validando nova carteira");

            model.Validate();
            if (model.Invalid)
            {
                ControllerUtils.LogErros("Carteira não é válida:", model, _logger);
                foreach (var notificacao in model.Notifications)
                {
                    _logger.LogInformation("* {0}", notificacao.Message);
                }

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a carteira",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Salvando nova carteira");
            var carteira = _mapper.Map<Carteira>(model);

            await _carteiraRepository.SaveAsync(carteira);

            _logger.LogInformation("Nova carteira cadastrada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira cadastrada com sucesso!",
                Data = carteira
            });
        }

        [HttpPut("v1/admin/carteiras")]
        public async Task<IActionResult> Put([FromBody] CarteiraEditViewModel model)
        {
            _logger.LogInformation("Validando alterações na carteira {0}", model.Id);

            model.Validate();
            if (model.Invalid)
            {
                ControllerUtils.LogErros("Alterações na carteira não são válidas:", model, _logger);

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível alterar a carteira",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Atualizando carteira");
            var carteira = _mapper.Map<Carteira>(model);

            await _carteiraRepository.UpdateAsync(carteira);

            _logger.LogInformation("Carteira atualizada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira alterada com sucesso!",
                Data = carteira
            });
        }

        [HttpDelete("v1/admin/carteiras")]
        public async Task<IActionResult> Delete([FromBody] Carteira carteira)
        {
            _logger.LogInformation("Deletando carteira {0}", carteira.Id);
            await _carteiraRepository.DeleteAsync(carteira);

            _logger.LogInformation("Carteira deletada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira excluída com sucesso!",
                Data = carteira
            });
        }
    }
}
