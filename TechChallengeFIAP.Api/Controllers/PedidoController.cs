using MercadoPago.Resource.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TechChallengeFIAP.Core.AbstractServices;
using TechChallengeFIAP.Core.ConcretServices;
using TechChallengeFIAP.Core.Helpers;
using TechChallengeFIAP.Core.Paginetes;
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
        private readonly IUriService uriService;

        public PedidoController(IPedidoService pedidoService, IUriService uriService)
        {
            _pedidoService = pedidoService;
            this.uriService = uriService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var dados = await _pedidoService.GetAllAsync(filter);
            var pagedReponse = PaginationHelper.CreatePagedReponse<PedidoDTO>(dados.Data, filter, dados.TotalRecords, uriService, route);
            return Ok(pagedReponse);
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
