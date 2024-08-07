﻿using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;
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
        Task SaveQrDataAsync(MercadoPagoQrCodeModel mercadoPagoQrCodeModel, int IdPedidoMercadoPago);
        Task<PedidoDTO> GetByIdAsync(int IdPedido);
        Task ChangeStatusAsync(int IdPedidoMercadoPago, int idStatus);

        Task ConfirmPaymentAsync(int IdPedidoMercadoPago);
        Task ConfirmePaymentMercadoPagoAsync(string IdPedidoMercadoPago);

        Task<PedidoDTO?> GetMercadoPagoByIdAsync(string IdPedidoMercadoPago);
    }
}
