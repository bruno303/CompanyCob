using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelaController : ControllerBase
    {
        private readonly ILogger<ParcelaController> _logger;

        public ParcelaController(ILogger<ParcelaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("Hello World");
        }
    }
}
