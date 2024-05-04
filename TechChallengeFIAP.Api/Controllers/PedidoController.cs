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
            var idPedido = await _pedidoService.CreatePedidoAsync(createPedidoDTO);
            return StatusCode(StatusCodes.Status201Created, idPedido);
        }

        [HttpGet("qr-code/{id}")]
        public async Task<IActionResult> GetQrCodeAsync([FromRoute] int id)
        {
            var image = await _pedidoService.GetQrCodeAsync(id);
            return File(image, "image/jpeg");
        }

        [HttpPut("change-status/{id}/{idStatus}")]
        public async Task<IActionResult> ChangeStatusAsync([FromRoute] int id, [FromBody] int idStatus)
        {
            await _pedidoService.ChangeStatusAsync(id, idStatus);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("confirm-payment/{Id}")]
        public async Task<IActionResult> ConfirmePaymentAsync([FromRoute] int Id)
        {
            await _pedidoService.ConfirmPaymentAsync(Id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
