using Microsoft.AspNetCore.Mvc;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechChallengeFIAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpfAsync([FromRoute] string cpf)
        {

            return Ok(await _clienteService.GetByCpfAsync(cpf));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ClienteCadastroDTO clienteCadastroDTO)
        {
            await _clienteService.CreateAsync(clienteCadastroDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("promotions")]
        public async Task<IActionResult> GetByPromotionsAsync([FromQuery] string cpf = null, [FromQuery] string dtNascIni = null, [FromQuery] string dtNascFin = null)
        {
            return Ok(await _clienteService.GetByPromotionsAsync(cpf, dtNascIni, dtNascFin));
        }
    }
}
