using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.DomainEntities.Interfaces
{
    public interface IPedidoDomain
    {
        Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter);
        Task<decimal> GetTotalAmount(List<CreatePedidoProdutosDTO> createPedidoProdutosDTOs);
        Task<int> CreatePedidoAsync(CreatePedidoOnlyDTO createPedidoOnlyDTO);
        Task<List<PedidoMercadoPagoDTO>> GetPedidoMercadoPago(int IdPedido);
        Task<PedidoDTO?> GetByIdAsync(int IdPedido);
        Task SaveQrCodeAsync(MercadoPagoQrCodeModel mercadoPagoQrCodeModel, int IdPedidoMercadoPago);
    }
}
