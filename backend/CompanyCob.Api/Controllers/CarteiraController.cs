using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using System.Threading.Tasks;
using CompanyCob.Api.ViewModel;
using AutoMapper;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly ILogger<CarteiraController> _logger;
        private readonly ICarteiraRepository _carteiraRepository;
        private readonly IMapper _mapper;

        public CarteiraController(ILogger<CarteiraController> logger, ICarteiraRepository carteiraRepository,
            IMapper mapper)
        {
            _logger = logger;
            _carteiraRepository = carteiraRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/admin/carteiras")]
        public async Task<IActionResult> GetAll()
        {
            var results = await _carteiraRepository.GetAll();
            return new JsonResult(results);
        }

        [HttpGet("v1/admin/carteiras/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _carteiraRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        [HttpPost("v1/admin/carteiras")]
        public async Task<IActionResult> Post([FromBody] CarteiraEditViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new JsonResult(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a carteira",
                    Data = model.Notifications
                });
            }

            var carteira = _mapper.Map<Carteira>(model);

            await _carteiraRepository.Save(carteira);

            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira cadastrada com sucesso!",
                Data = carteira
            });
        }

        [HttpPut("v1/admin/carteiras")]
        public async Task<IActionResult> Put([FromBody] CarteiraEditViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new JsonResult(new ResultViewModel()
                {
                    Success = false,
                    Message = "Não foi possível alterar a carteira",
                    Data = model.Notifications
                });
            }

            var carteira = _mapper.Map<Carteira>(model);

            await _carteiraRepository.Update(carteira);
            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira alterada com sucesso!",
                Data = carteira
            });
        }

        [HttpDelete("v1/admin/carteiras")]
        public async Task<IActionResult> Delete([FromBody] Carteira carteira)
        {
            await _carteiraRepository.Delete(carteira);

            return new JsonResult(new ResultViewModel()
            {
                Success = true,
                Message = "Carteira excluída com sucesso!",
                Data = carteira
            });
        }
    }
}
