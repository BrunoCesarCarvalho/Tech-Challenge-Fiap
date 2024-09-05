using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Integrations.MercadoPagoFIAP.Models;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.Domain.DomainEntities.Interfaces;
using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.DomainEntities
{
    public class DomainPedido : IPedidoDomain
    {
        public int? PedidoId { get; set; }
        public string? PedidoIdMercadoPago { get; set; }
        public DateTime? Data { get; set; }
        public decimal? ValorTotal { get; set; }
        public string QrData { get; set; }


        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        public DomainPedido(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }


        public async Task<decimal> GetTotalAmount(List<CreatePedidoProdutosDTO> createPedidoProdutosDTOs)
        {
            decimal totalAmount = 0;
            foreach (var produto in createPedidoProdutosDTOs)
            {
                var valueProduct = await _produtoRepository.GetByIdAsync(produto.IdProduto);

                totalAmount += valueProduct.Valor * produto.Quantidade;
            }

            return totalAmount;
        }

        public async Task<int> CreatePedidoAsync(CreatePedidoOnlyDTO createPedidoOnlyDTO)
        {
            return await _pedidoRepository.CreatePedidoAsync(createPedidoOnlyDTO);
        }

        public async Task<List<PedidoMercadoPagoDTO>> GetPedidoMercadoPago(int IdPedido)
        {
            return await _pedidoRepository.GetPedidoMercadoPago(IdPedido);
        }

        public async Task SaveQrCodeAsync(MercadoPagoQrCodeModel mercadoPagoQrCodeModel, int IdPedidoMercadoPago)
        {
            await _pedidoRepository.SaveQrCodeAsync(mercadoPagoQrCodeModel, IdPedidoMercadoPago);
        }

        public async Task<PedidoDTO?> GetByIdAsync(int IdPedido)
        {
            return await _pedidoRepository.GetByIdAsync(IdPedido);
        }

        public async Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter)
        {
            return await _pedidoRepository.GetAllAsync(filter);
        }
    }
}
