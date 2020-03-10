using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using CompanyCob.Service;
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
        private readonly ICalculoDividaService _calculoDividaService;

        public CalculoController(
            ILogger<CalculoController> logger,
            ICalculoDividaService calculoDividaService)
        {
            _logger = logger;
            _calculoDividaService = calculoDividaService;
        }

        [HttpGet("v1/calculo/{idDevedor}/{idDivida}")]
        public async Task<IActionResult> GetCalculoDivida(int idDevedor, int idDivida)
        {
            _logger.LogInformation($"Calculo da dívida {idDivida} do devedor {idDevedor}");

            var result = await _calculoDividaService.Calcular(idDivida, idDevedor);

            if (!result.Sucesso)
            {
                _logger.LogInformation(result.Mensagem);
                return BadRequest(new { result = false, message = result.Mensagem });
            }

            _logger.LogInformation($"Cálculo do parcelamento da dívida {idDivida} realizado com sucesso");
            return Ok(new { result = true, message = "", data = result.Resultado });
        }
    }
}
