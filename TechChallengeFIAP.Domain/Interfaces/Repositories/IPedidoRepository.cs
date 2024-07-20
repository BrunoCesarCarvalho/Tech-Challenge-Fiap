using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter);

        Task<PagedResponse<List<PedidoDTO>>> PedidosActive(PaginationFilter filter);
        Task<int> CreatePedidoAsync(CreatePedidoOnlyDTO createPedidoOnlyDTO);
        Task<List<PedidoMercadoPagoDTO>> GetPedidoMercadoPago(int IdPedido);
        Task SaveQrDataAsync(string qrData, int idPedido);
        Task<PedidoDTO> GetByIdAsync(int IdPedido);
        Task ChangeStatusAsync(int idPedido, int idStatus);

        Task ConfirmPaymentAsync(int idPedido);
    }
}
