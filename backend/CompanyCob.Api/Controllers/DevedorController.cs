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
        private readonly IMapper _mapper;

        public DevedorController(ILogger<DevedorController> logger, IDevedorRepository devedorRepository,
            IMapper mapper)
        {
            _logger = logger;
            _devedorRepository = devedorRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/admin/devedores")]
        public async Task<IActionResult> GetAll()
        {
            var results = await _devedorRepository.GetAll();
            return new JsonResult(results);
        }

        [HttpGet("v1/admin/devedores/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _devedorRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        [HttpPost("v1/admin/devedores")]
        public async Task<IActionResult> Post([FromBody] DevedorEditViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new JsonResult(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o devedor",
                    Data = model.Notifications
                });
            }

            var devedor = _mapper.Map<Devedor>(model);

            await _devedorRepository.Save(devedor);

            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor cadastrado com sucesso!",
                Data = devedor
            });
        }

        [HttpPut("v1/admin/devedores")]
        public async Task<IActionResult> Put([FromBody] DevedorEditViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new JsonResult(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível alterar o devedor",
                    Data = model.Notifications
                });
            }

            var devedor = _mapper.Map<Devedor>(model);

            await _devedorRepository.Update(devedor);
            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor alterado com sucesso!",
                Data = devedor
            });
        }

        [HttpDelete("v1/admin/devedores")]
        public async Task<IActionResult> Delete([FromBody] Devedor devedor)
        {
            await _devedorRepository.Delete(devedor);

            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Devedor excluído com sucesso!",
                Data = devedor
            });
        }
    }
}