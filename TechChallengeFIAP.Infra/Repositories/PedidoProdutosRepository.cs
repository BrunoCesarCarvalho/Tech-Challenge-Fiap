using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.DTOs;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Entities;

namespace TechChallengeFIAP.Infra.Repositories
{
    public class PedidoProdutosRepository : IPedidoProdutosRepository, IDisposable
    {
        private readonly DataBaseContext _dataBaseContext;
        private bool disposedValue;
        private bool disposedValue1;

        public PedidoProdutosRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task CreateAsync(List<CreatePedidoProdutosOnlyDTO> listCreatePedidoProdutosDTO)
        {            
            var pedidoProdutosEntity = listCreatePedidoProdutosDTO.Select(x => new PedidoProdutosEntity()
            {
                IdPedido = x.IdPedido,
                IdProduto = x.IdProduto,
                Quantidade = x.Quantidade,
            });

            await _dataBaseContext.PedidoProdutos.AddRangeAsync(pedidoProdutosEntity);
            await _dataBaseContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue1)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dataBaseContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue1 = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PedidoProdutosRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
