using System.Threading.Tasks;
using AutoMapper;
using CompanyCob.Api.ViewModel;
using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class DividaController : ControllerBase
    {
        private readonly ILogger<DividaController> _logger;
        private readonly IDividaRepository _dividaRepository;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IDevedorRepository _devedorRepository;
        private readonly IMapper _mapper;

        public DividaController(
            ILogger<DividaController> logger,
            IDividaRepository dividaRepository,
            ICarteiraRepository carteiraRepository,
            IDevedorRepository devedorRepository,
            IMapper mapper)
        {
            _logger = logger;
            _dividaRepository = dividaRepository;
            _carteiraRepository = carteiraRepository;
            _devedorRepository = devedorRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/admin/dividas")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Carregando todas as dívidas");
            var results = await _dividaRepository.GetAllAsync();

            _logger.LogInformation("Carregando carteira e devedor das dívidas");
            foreach (var result in results)
            {
                result.Carteira = await _carteiraRepository.GetAsync(result.IdCarteira);
                result.Devedor = await _devedorRepository.GetAsync(result.IdDevedor);
            }

            _logger.LogInformation("Quantidade dívidas: {0}", results.Count);
            return Ok(results);
        }

        [HttpGet("v1/admin/dividas/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Carregando dívida. ID: {0}", id);

            var result = await _dividaRepository.GetAsync(id);
            if (result == null)
            {
                _logger.LogInformation("Dívida não encontrada");
                return NotFound();
            }

            _logger.LogInformation("Carregando carteira da dívida");
            result.Carteira = await _carteiraRepository.GetAsync(result.IdCarteira);

            _logger.LogInformation("Carregando devedor da dívida");
            result.Devedor = await _devedorRepository.GetAsync(result.IdDevedor);

            _logger.LogInformation("Dívida carregada com sucesso");
            return Ok(result);
        }

        [HttpPost("v1/admin/dividas")]
        public async Task<IActionResult> Post([FromBody] DividaEditViewModel model)
        {
            _logger.LogInformation("Validando nova dívida");

            model.Validate();
            if (model.Invalid)
            {
                _logger.LogInformation("Nova dívida não é válida:");
                foreach (var notificacao in model.Notifications)
                {
                    _logger.LogInformation("* {0}", notificacao.Message);
                }

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a dívida",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Cadastrando dívida");
            var divida = _mapper.Map<Divida>(model);

            await _dividaRepository.SaveAsync(divida);

            _logger.LogInformation("Dívida cadastrada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Dívida cadastrada com sucesso!",
                Data = divida
            });
        }

        [HttpPut("v1/admin/dividas")]
        public async Task<IActionResult> Put([FromBody] DividaEditViewModel model)
        {
            _logger.LogInformation("Validando alterações na dívida {0}", model.Id);

            model.Validate();
            if (model.Invalid)
            {
                _logger.LogInformation("Alterações na dívida não são válidas:");
                foreach (var notificacao in model.Notifications)
                {
                    _logger.LogInformation("* {0}", notificacao.Message);
                }

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível alterar a dívida",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Atualizando dívida");
            var divida = _mapper.Map<Divida>(model);

            await _dividaRepository.UpdateAsync(divida);

            _logger.LogInformation("Dívida atualizada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Dívida alterada com sucesso!",
                Data = divida
            });
        }

        [HttpDelete("v1/admin/dividas")]
        public async Task<IActionResult> Delete([FromBody] Divida divida)
        {
            _logger.LogInformation("Deletando dívida {0}", divida.Id);
            await _dividaRepository.DeleteAsync(divida);

            _logger.LogInformation("Dívida deletada com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Dívida excluída com sucesso!",
                Data = divida
            });
        }
    }
}