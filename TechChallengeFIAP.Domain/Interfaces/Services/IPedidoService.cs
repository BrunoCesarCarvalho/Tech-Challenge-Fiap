using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> GetAllAsync();
        Task<int> CreatePedidoAsync(CreatePedidoDTO createPedidoDTO);

        Task<byte[]> GetQrCodeAsync(int IdPedido);

        Task ChangeStatusAsync(int idPedido, int idStatus);
        Task ConfirmPaymentAsync(int idPedido);
    }
}
