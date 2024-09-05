using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.InterfacesUserCases.Services
{
    public interface IPedidoUserCase
    {
        Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter);
        Task<PagedResponse<List<PedidoDTO>>> PedidosActive(PaginationFilter filter);
        Task<int> CreatePedidoAsync(CreatePedidoDTO createPedidoDTO);

        Task<byte[]> GetQrCodeAsync(int IdPedido);

        Task ChangeStatusAsync(int idPedido, int idStatus);
        Task ConfirmPaymentAsync(int idPedido);
        Task ConfirmePaymentMercadoPagoAsync(string IdPedidoMercadoPago);
    }
}
