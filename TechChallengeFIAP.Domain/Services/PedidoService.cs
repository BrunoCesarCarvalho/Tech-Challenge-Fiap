using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Enums;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;

namespace TechChallengeFIAP.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoProdutosRepository _pedidoProdutosRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IPedidoProdutosRepository pedidoProdutosRepository, IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _pedidoProdutosRepository = pedidoProdutosRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<PedidoDTO>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task CreatePedidoAsync(CreatePedidoDTO createPedidoDTO)
        {

            var clienteDTO = await _clienteRepository.GetByCpfAsync(createPedidoDTO.Cliente.Cpf);

            var createPedidoOnlyDTO = new CreatePedidoOnlyDTO();
            decimal totalAmount = 0;
            foreach (var produto in createPedidoDTO.ListPedidoProdutos)
            {
                var valueProduct = await _produtoRepository.GetByIdAsync(produto.IdProduto);

                totalAmount += valueProduct.Valor * produto.Quantidade;
            }

            createPedidoOnlyDTO.ValorTotal = totalAmount;
            createPedidoOnlyDTO.IdCliente = clienteDTO.Id;
            createPedidoOnlyDTO.IdStatusEtapa = (int)EnumPedidoStatusEtapa.Recebido;
            createPedidoOnlyDTO.IdStatusPagamento = (int)EnumStatusPagamento.Pendente;

            var idPedido = await _pedidoRepository.CreatePedidoAsync(createPedidoOnlyDTO);

            var listCreatePedidoProdutosOnlyDTO = new List<CreatePedidoProdutosOnlyDTO>();

            foreach (var pedidosProdutos in createPedidoDTO.ListPedidoProdutos)
            {
                var createPedidoProdutosOnlyDTO = new CreatePedidoProdutosOnlyDTO()
                {
                    IdPedido = idPedido,
                    IdProduto = pedidosProdutos.IdProduto,
                    Quantidade = pedidosProdutos.Quantidade,
                };

                listCreatePedidoProdutosOnlyDTO.Add(createPedidoProdutosOnlyDTO);
            }

            await _pedidoProdutosRepository.CreateAsync(listCreatePedidoProdutosOnlyDTO);
        }
    }
}
