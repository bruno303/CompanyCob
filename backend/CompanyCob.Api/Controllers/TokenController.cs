using CompanyCob.Domain.Model.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCob.Api.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDevedorRepository _devedorRepository;

        public TokenController(IConfiguration configuration, IDevedorRepository devedorRepository)
        {
            _configuration = configuration;
            _devedorRepository = devedorRepository;
        }

        [HttpGet("v1/token/{cpf}")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestToken(long cpf)
        {
            var devedor = await _devedorRepository.GetByCpfAsync(cpf);
            if (devedor != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, cpf.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecutiryKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "CompanyCob",
                    audience: "CompanyCob",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return NotFound("Devedor não encontrado");
        }
    }
}
