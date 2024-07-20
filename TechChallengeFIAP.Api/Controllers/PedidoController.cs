using MercadoPago.Resource.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TechChallengeFIAP.Core.AbstractServices;
using TechChallengeFIAP.Core.ConcretServices;
using TechChallengeFIAP.Core.Helpers;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Enums;
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

        /// <summary>
        /// Metodo que obtém todos os Pedidos realizados no sistema
        /// </summary>
        /// <returns>Uma lista de Pedidos.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var dados = await _pedidoService.GetAllAsync(filter);
            var pagedReponse = PaginationHelper.CreatePagedReponse<PedidoDTO>(dados.Data, filter, dados.TotalRecords, uriService, route);
            return Ok(pagedReponse);
        }


        /// <summary>
        /// Metodo que retorna os Pedidos com Status (Recebido, EmPreparacao, Pronto)
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("pedido-active")]
        public async Task<IActionResult> GetPedidoActive([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var dados = await _pedidoService.PedidosActive(filter);
            var pagedReponse = PaginationHelper.CreatePagedReponse<PedidoDTO>(dados.Data, filter, dados.TotalRecords, uriService, route);
            return Ok(pagedReponse);
        }

        /// <summary>
        /// Metodo que cria os pedidos no sistema, para clientes que informam os dados ou não, para aqueles que informam, apenas deixar o CPF em branco;
        /// O status fica como Pendente e o QRCode é criado
        /// </summary>
        /// <returns>Retorno o ID do pedido criado.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePedidoDTO createPedidoDTO)
        {
            var idPedido = await _pedidoService.CreatePedidoAsync(createPedidoDTO);
            return StatusCode(StatusCodes.Status201Created, idPedido);
        }

        /// <summary>
        /// Metodo que altera o status do Pedido
        /// </summary>
        [HttpPut("change-status/{id}/{enumPedidoStatusEtapa}")]
        public async Task<IActionResult> ChangeStatusAsync([FromRoute] int id, [FromRoute] EnumPedidoStatusEtapa enumPedidoStatusEtapa)
        {
            await _pedidoService.ChangeStatusAsync(id, (int)enumPedidoStatusEtapa);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Metodo que retorna o QrCode para cliente, passando o ID do pedido que foi criado
        /// </summary>
        /// <returns>Retorna o QR para pagamento.</returns>
        [HttpGet("qr-code/{id}")]
        public async Task<IActionResult> GetQrCodeAsync([FromRoute] int id)
        {
            var image = await _pedidoService.GetQrCodeAsync(id);
            return File(image, "image/jpeg");
        }

        /// <summary>
        /// Metodo que confirma o pagamento do cliente, o status fica como Pago no sistema
        /// </summary>       
        [HttpPut("confirm-payment/{Id}")]
        public async Task<IActionResult> ConfirmePaymentAsync([FromRoute] int Id)
        {
            await _pedidoService.ConfirmPaymentAsync(Id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
