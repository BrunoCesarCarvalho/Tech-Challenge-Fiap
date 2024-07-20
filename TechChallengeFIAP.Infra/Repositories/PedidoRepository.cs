using Microsoft.EntityFrameworkCore;
using TechChallengeFIAP.Core.Paginetes;
using TechChallengeFIAP.Core.Responses;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Enums;
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

        public async Task<PagedResponse<List<PedidoDTO>>> GetAllAsync(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.PedidoId);


            var pedidos = await _dataBaseContext.Pedido
                .Include(w => w.Cliente)
                .Include(w => w.StatusEtapa)
                .Include(w => w.StatusPagamento)
                .Include(w => w.PedidoProdutos)
                .Where(w => w.Id == filter.PedidoId || w.Id > filter.PedidoId)
                .Take(validFilter.PageSize)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .OrderBy(o => o.Data)
                .ToListAsync();

            var totalRecords = await _dataBaseContext.Pedido.CountAsync();

            var dadosResponse = ToPedidoListDTO(pedidos);

            return new PagedResponse<List<PedidoDTO>>(dadosResponse, validFilter.PageNumber, validFilter.PageSize);
        }

        private static List<PedidoDTO> ToPedidoListDTO(List<PedidoEntity> pedidos)
        {
            return pedidos.Select(x => new PedidoDTO()
            {
                PedidoId = x.Id,
                Data = x.Data,
                ValorTotal = x.ValorTotal,
                QrData = x.QrData,
                Cliente = new ClienteDTO()
                {
                    Id = x.Cliente.Id,
                    Cpf = x.Cliente.Cpf,
                    Email = x.Cliente.Email,
                    Nome = x.Cliente.Nome,
                    DataNascimento = x.Cliente.DataNascimento.ToShortTimeString()
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

        public async Task<PedidoDTO> GetByIdAsync(int IdPedido)
        {
            var pedido = await _dataBaseContext.Pedido
                .Include(w => w.Cliente)
                .Include(w => w.StatusEtapa)
                .Include(w => w.StatusPagamento)
                .Include(w => w.PedidoProdutos)
                .FirstOrDefaultAsync(w => w.Id == IdPedido);

            return new PedidoDTO()
            {
                PedidoId = pedido.Id,
                Data = pedido.Data,
                ValorTotal = pedido.ValorTotal,
                QrData = pedido.QrData,
                Cliente = new ClienteDTO()
                {
                    Id = pedido.Cliente.Id,
                    Cpf = pedido.Cliente.Cpf,
                    Email = pedido.Cliente.Email,
                    Nome = pedido.Cliente.Nome
                },
                StatusEtapa = new PedidoStatusEtapaDTO()
                {
                    Id = pedido.StatusEtapa.Id,
                    Descricao = pedido.StatusEtapa.Descricao
                },
                StatusPagamento = new StatusPagamentoDTO()
                {
                    Id = pedido.StatusPagamento.Id,
                    Descricao = pedido.StatusPagamento.Descricao
                },
                PedidoProdutos = pedido.PedidoProdutos.Select(pp => new PedidoProdutosDTO()
                {
                    Id = pp.Id,
                    IdProduto = pp.IdProduto,
                    Quantidade = pp.Quantidade
                }).ToList()
            };
        }

        public async Task<List<PedidoMercadoPagoDTO>> GetPedidoMercadoPago(int IdPedido)
        {
            var pedidoMercadoPago = await (from p in _dataBaseContext.Pedido
                                           join pp in _dataBaseContext.PedidoProdutos on p.Id equals pp.IdPedido
                                           join pd in _dataBaseContext.Produto on pp.IdProduto equals pd.Id
                                           where p.Id == IdPedido
                                           select new
                                           {
                                               pp.Quantidade,
                                               pd.Valor
                                           }).ToListAsync();

            return pedidoMercadoPago.Select(s => new PedidoMercadoPagoDTO()
            {
                Valor = s.Valor,
                Quantidade = s.Quantidade
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

        public async Task SaveQrDataAsync(string qrData, int idPedido)
        {
            var entity = await _dataBaseContext.Pedido.FirstOrDefaultAsync(w => w.Id == idPedido);
            entity.QrData = qrData;

            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(int idPedido, int idStatus)
        {
            var entity = await _dataBaseContext.Pedido.FirstOrDefaultAsync(w => w.Id == idPedido);
            entity.IdStatusEtapa = idStatus;
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task ConfirmPaymentAsync(int idPedido)
        {
            var entity = await _dataBaseContext.Pedido.FirstOrDefaultAsync(w => w.Id == idPedido);
            entity.IdStatusPagamento = (int)EnumStatusPagamento.Pago;
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<PagedResponse<List<PedidoDTO>>> PedidosActive(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.PedidoId);

            var pedidos = await _dataBaseContext.Pedido
               .Include(w => w.Cliente)
               .Include(w => w.StatusEtapa)
               .Include(w => w.StatusPagamento)
               .Include(w => w.PedidoProdutos)
               .Where(w => w.StatusEtapa.Id != (int)EnumPedidoStatusEtapa.Finalizado)
               .Take(validFilter.PageSize)
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .OrderBy(o => o.Data).ThenBy(o => o.StatusEtapa.Id)
               .ToListAsync();

            var totalRecords = await _dataBaseContext.Pedido.CountAsync();

            var dadosResponse = ToPedidoListDTO(pedidos);

            return new PagedResponse<List<PedidoDTO>>(dadosResponse, validFilter.PageNumber, validFilter.PageSize);

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
