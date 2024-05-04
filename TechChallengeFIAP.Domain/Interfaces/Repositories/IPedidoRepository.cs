using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<PedidoDTO>> GetAllAsync();
        Task<int> CreatePedidoAsync(CreatePedidoOnlyDTO createPedidoOnlyDTO);
        Task<List<PedidoMercadoPagoDTO>> GetPedidoMercadoPago(int IdPedido);
        Task SaveQrDataAsync(string qrData, int idPedido);
        Task<PedidoDTO> GetByIdAsync(int IdPedido);
        Task ChangeStatusAsync(int idPedido, int idStatus);

        Task ConfirmPaymentAsync(int idPedido);
    }
}
