using Microsoft.AspNetCore.Mvc;
using TechChallengeFIAP.Domain.InterfacesUserCases.Services;
using TechChallengeFIAP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechChallengeFIAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteUserCase _clienteService;

        public ClienteController(IClienteUserCase clienteService)
        {
            _clienteService = clienteService;
        }


        /// <summary>
        /// Metodo que obtém o cliente pelo seu CPF
        /// </summary>
        /// <returns>Retorna o cliente da busca</returns>

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpfAsync([FromRoute] string cpf)
        {
            var res = await _clienteService.GetByCpfAsync(cpf);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(await _clienteService.GetByCpfAsync(cpf));
        }


        /// <summary>
        /// Metodo que cria um novo cliente
        /// </summary>
        /// <returns>Retorna o ID do cliente criado</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ClienteCadastroModel clienteCadastroDTO)
        {
            await _clienteService.CreateAsync(clienteCadastroDTO);
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        /// Metodo obtém uma lista de clientes que são candidatos a uma promoção
        /// </summary>
        /// <returns>Retorna uma lista clientes</returns>
        [HttpGet("promotions")]
        public async Task<IActionResult> GetByPromotionsAsync([FromQuery] string cpf = null, [FromQuery] string dtNascIni = null, [FromQuery] string dtNascFin = null)
        {
            return Ok(await _clienteService.GetByPromotionsAsync(cpf, dtNascIni, dtNascFin));
        }


    }
}
