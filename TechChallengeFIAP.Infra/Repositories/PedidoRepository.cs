using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Entities;

namespace TechChallengeFIAP.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository, IDisposable
    {
        private readonly DataBaseContext _dataBaseContext;
        private bool disposedValue;

        public PedidoRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<List<PedidoDTO>> GetAllAsync()
        {
            var pedidos = await _dataBaseContext.Pedido
                .Include(w => w.Cliente)
                .Include(w => w.StatusEtapa)
                .Include(w => w.StatusPagamento)
                .Include(w => w.PedidoProdutos).ToListAsync();

            return pedidos.Select(x => new PedidoDTO()
            {
                Id = x.Id,
                Data = x.Data,
                ValorTotal = x.ValorTotal,
                Cliente = new ClienteDTO()
                {
                    Id = x.Cliente.Id,
                    Cpf = x.Cliente.Cpf,
                    Email = x.Cliente.Email,
                    Nome = x.Cliente.Nome
                },
                StatusEtapa = new PedidoStatusEtapaDTO()
                {
                    Id = x.StatusEtapa.Id,
                    Descricao = x.StatusEtapa.Descricao
                },
                StatusPagamento = new StatusPagamentoDTO()
                {
                    Id = x.StatusPagamento.Id,
                    Descricao = x.StatusPagamento.Descricao
                },
                PedidoProdutos = x.PedidoProdutos.Select(pp => new PedidoProdutosDTO()
                {
                    Id = pp.Id,                  
                    IdProduto = pp.IdProduto,
                    Quantidade = pp.Quantidade
                }).ToList()                  

            }).ToList();
        }

        public async Task<int> CreatePedidoAsync(CreatePedidoOnlyDTO createPedidoOnlyDTO)
        {
            var entity = new PedidoEntity()
            {
                Data = DateTime.Now,
                IdCliente = createPedidoOnlyDTO.IdCliente,
                IdStatusEtapa = createPedidoOnlyDTO.IdStatusEtapa,
                IdStatusPagamento = createPedidoOnlyDTO.IdStatusPagamento,
                ValorTotal = createPedidoOnlyDTO.ValorTotal,
            };

            await _dataBaseContext.Pedido.AddAsync(entity);
            await _dataBaseContext.SaveChangesAsync();

            return entity.Id; 
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dataBaseContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PedidoRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
