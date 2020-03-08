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
    public class DevedorController : ControllerBase
    {
        private readonly ILogger<DevedorController> _logger;
        private readonly IDevedorRepository _devedorRepository;
        private readonly IDividaRepository _dividaRepository;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IMapper _mapper;

        public DevedorController(
            ILogger<DevedorController> logger,
            IDevedorRepository devedorRepository,
            IDividaRepository dividaRepository,
            ICarteiraRepository carteiraRepository,
            IMapper mapper)
        {
            _logger = logger;
            _devedorRepository = devedorRepository;
            _dividaRepository = dividaRepository;
            _carteiraRepository = carteiraRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/admin/devedores")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Carregando todos os devedores");
            var results = await _devedorRepository.GetAllAsync();

            _logger.LogInformation("Carregando dívidas dos devedores");
            foreach (var result in results)
            {
                result.Dividas = await _dividaRepository.GetByDevedorAsync(result);
                foreach (var divida in result.Dividas)
                {
                    divida.Carteira = await _carteiraRepository.GetAsync(divida.IdCarteira);
                }
            }

            _logger.LogInformation("Quantidade devedores: {0}", results.Count);
            return Ok(results);
        }

        [HttpGet("v1/admin/devedores/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Carregando devedor. ID: {0}", id);
            var result = await _devedorRepository.GetAsync(id);
            if (result == null)
            {
                _logger.LogInformation("Devedor não encontrado");
                return NotFound();
            }

            _logger.LogInformation("Carregando dívidas do devedor");
            result.Dividas = await _dividaRepository.GetByDevedorAsync(result);

            _logger.LogInformation("Carregando carteiras");
            foreach (var divida in result.Dividas)
            {
                divida.Carteira = await _carteiraRepository.GetAsync(divida.IdCarteira);
            }

            _logger.LogInformation("Devedor carregado com sucesso");
            return Ok(result);
        }

        [HttpGet("v1/admin/devedores/cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(long cpf)
        {
            _logger.LogInformation("Carregando devedor. CPF: {0}", cpf);
            var result = await _devedorRepository.GetByCpfAsync(cpf);
            if (result == null)
            {
                _logger.LogInformation("Devedor não encontrado");
                return NotFound();
            }

            _logger.LogInformation("Carregando dívidas do devedor");
            result.Dividas = await _dividaRepository.GetByDevedorAsync(result);

            _logger.LogInformation("Carregando carteiras");
            foreach (var divida in result.Dividas)
            {
                divida.Carteira = await _carteiraRepository.GetAsync(divida.IdCarteira);
            }

            _logger.LogInformation("Devedor carregado com sucesso");
            return Ok(result);
        }

        [HttpPost("v1/admin/devedores")]
        public async Task<IActionResult> Post([FromBody] DevedorEditViewModel model)
        {
            _logger.LogInformation("Validando novo devedor");
            model.Validate();
            if (model.Invalid)
            {
                _logger.LogInformation("Devedor não é válido:");
                foreach (var notificacao in model.Notifications)
                {
                    _logger.LogInformation("* {0}", notificacao.Message);
                }

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o devedor",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Salvando novo devedor");
            var devedor = _mapper.Map<Devedor>(model);

            await _devedorRepository.SaveAsync(devedor);

            _logger.LogInformation("Novo devedor cadastrado com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor cadastrado com sucesso!",
                Data = devedor
            });
        }

        [HttpPut("v1/admin/devedores")]
        public async Task<IActionResult> Put([FromBody] DevedorEditViewModel model)
        {
            _logger.LogInformation("Validando alterações no devedor {0}", model.Id);
            model.Validate();
            if (model.Invalid)
            {
                _logger.LogInformation("Alterações no devedor não são válidas:");
                foreach (var notificacao in model.Notifications)
                {
                    _logger.LogInformation("* {0}", notificacao.Message);
                }

                return Ok(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível alterar o devedor",
                    Data = model.Notifications
                });
            }

            _logger.LogInformation("Atualizando devedor");
            var devedor = _mapper.Map<Devedor>(model);

            await _devedorRepository.UpdateAsync(devedor);

            _logger.LogInformation("Devedor atualizado com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor alterado com sucesso!",
                Data = devedor
            });
        }

        [HttpDelete("v1/admin/devedores")]
        public async Task<IActionResult> Delete([FromBody] Devedor devedor)
        {
            _logger.LogInformation("Deletando devedor {0}", devedor.Id);
            await _devedorRepository.DeleteAsync(devedor);

            _logger.LogInformation("Devedor deletado com sucesso");
            return Ok(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor excluído com sucesso!",
                Data = devedor
            });
        }
    }
}