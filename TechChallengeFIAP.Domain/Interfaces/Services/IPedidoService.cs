using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter);
        Task<int> CreatePedidoAsync(CreatePedidoDTO createPedidoDTO);

        Task<byte[]> GetQrCodeAsync(int IdPedido);

        Task ChangeStatusAsync(int idPedido, int idStatus);
        Task ConfirmPaymentAsync(int idPedido);
    }
}
