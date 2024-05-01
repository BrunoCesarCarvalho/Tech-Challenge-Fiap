using Microsoft.AspNetCore.Mvc;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechChallengeFIAP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _pedidoService.GetAllAsync());
        }             

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePedidoDTO createPedidoDTO)
        {
            await _pedidoService.CreatePedidoAsync(createPedidoDTO);
            return StatusCode(StatusCodes.Status201Created);
        }                
    }
}
