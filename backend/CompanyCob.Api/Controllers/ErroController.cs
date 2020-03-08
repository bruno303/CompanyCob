using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class ErroController : ControllerBase
    {
        private readonly ILogger<ErroController> _logger;

        public ErroController(ILogger<ErroController> logger)
        {
            _logger = logger;
        }

        public IActionResult ErrorHandler()
        {
            _logger.LogError("Erro capturado. Enviando resposta ao cliente...");

            return Problem();
        }
    }
}
