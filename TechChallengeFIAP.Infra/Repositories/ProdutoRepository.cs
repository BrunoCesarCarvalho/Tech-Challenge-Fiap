using Microsoft.EntityFrameworkCore;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Entities;

namespace TechChallengeFIAP.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository, IDisposable
    {
        private readonly DataBaseContext _dataBaseContext;

        public ProdutoRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<List<ProdutoDTO>> GetAll()
        {
            var produtos = await _dataBaseContext.Produto
                .Include(w => w.Categoria)
                .Include(img => img.Imagens)
                .ToListAsync();

            return produtos.Select(x => new ProdutoDTO()
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Valor = x.Valor,
                Nome = x.Nome,
                IdCategoriaProduto = x.IdCategoriaProduto,
                CategoriaDTO = new CategoriaDTO()
                {
                    Id = x.IdCategoriaProduto,
                    Nome = x.Categoria.Nome
                },
                ProdutoImagensDTO = x.Imagens.Select(y => new ProdutoImagensDTO()
                {
                    Id = y.Id,
                    Foto = y.Foto,
                    IdProduto = y.IdProduto,
                }).ToList()
            }).ToList();
        }

        public async Task<ProdutoDTO?> GetByNomeAsync(string nome)
        {
            var produto = await _dataBaseContext.Produto.FirstOrDefaultAsync(w => w.Nome.Trim() == nome.Trim());

            return produto != null ?
             new ProdutoDTO
             {
                 Id = produto.Id,
                 Nome = nome,
                 Descricao = produto.Descricao,
                 Valor = produto.Valor,
                 IdCategoriaProduto = produto.IdCategoriaProduto,
             } : null;
        }

        public async Task<ProdutoDTO?> GetByIdAsync(int id)
        {
            var produto = await _dataBaseContext.Produto.FirstOrDefaultAsync(w => w.Id == id);

            return produto != null ? new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                IdCategoriaProduto = produto.IdCategoriaProduto,
            } : null;
        }

        public async Task EditAsync(EditProdutoDTO editProdutoDTO)
        {
            var entity = await _dataBaseContext.Produto.FirstOrDefaultAsync(w => w.Id == editProdutoDTO.Id);

            using var transaction = _dataBaseContext.Database.BeginTransaction();

            entity.Descricao = editProdutoDTO.Descricao;
            entity.IdCategoriaProduto = editProdutoDTO.IdCategoriaProduto;
            entity.Nome = editProdutoDTO.Nome;
            entity.Valor = editProdutoDTO.Valor;
            await _dataBaseContext.SaveChangesAsync();

            _dataBaseContext.ProdutoImagens.RemoveRange(_dataBaseContext.ProdutoImagens.Where(w => w.IdProduto == editProdutoDTO.Id));
            await _dataBaseContext.SaveChangesAsync();

            var produtoImagensEntity = editProdutoDTO.EditProdutoImagensDTO.Select(x => new ProdutoImagensEntity()
            {
                IdProduto = x.Id,
                Foto = x.Foto,
            });

            await _dataBaseContext.ProdutoImagens.AddRangeAsync(produtoImagensEntity);
            await _dataBaseContext.SaveChangesAsync();

            await transaction.CommitAsync();

        }

        public async Task DeleteAsync(int Id)
        {

            using var transaction = _dataBaseContext.Database.BeginTransaction();

            var entityImagens = await _dataBaseContext.ProdutoImagens.Where(w => w.IdProduto == Id).ToListAsync();
            _dataBaseContext.ProdutoImagens.RemoveRange(entityImagens);

            var entity = await _dataBaseContext.Produto.FirstOrDefaultAsync(w => w.Id == Id);
            _dataBaseContext.Remove(entity);
            await _dataBaseContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task CreateAsync(CreateProdutoDTO createProdutoDTO)
        {
            using var transaction = _dataBaseContext.Database.BeginTransaction();

            try
            {
                var entity = new ProdutoEntity();
                entity.Descricao = createProdutoDTO.Descricao;
                entity.IdCategoriaProduto = createProdutoDTO.IdCategoriaProduto;
                entity.Nome = createProdutoDTO.Nome;
                entity.Valor = createProdutoDTO.Valor;

                await _dataBaseContext.Produto.AddAsync(entity);
                await _dataBaseContext.SaveChangesAsync();

                int idProdutoInsert = entity.Id;

                var produtoImagens = createProdutoDTO.ProdutoImagens.Select(x => new ProdutoImagensEntity()
                {
                    IdProduto = idProdutoInsert,
                    Foto = x.Foto
                });

                await _dataBaseContext.AddRangeAsync(produtoImagens);
                await _dataBaseContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProdutoDTO>> GetListByIdCategoryAsync(int categoryId)
        {
            return await _dataBaseContext.Produto.Where(w => w.IdCategoriaProduto == categoryId).Select(x => new ProdutoDTO
            {
                Descricao = x.Descricao,
                Id = x.Id,
                Nome = x.Nome,
                Valor = x.Valor,
                CategoriaDTO = new CategoriaDTO()
                {
                    Id = categoryId,
                    Nome = x.Categoria.Nome,
                },
                ProdutoImagensDTO = x.Imagens.Select(s => new ProdutoImagensDTO()
                {
                    Id = s.Id,
                    Foto = s.Foto,

                }).ToList()
            }).ToListAsync();
        }

        public async Task<List<ProdutoDTO>> GetListByNomeCategoryAsync(string nome)
        {
            return await _dataBaseContext.Produto.Where(w => w.Categoria.Nome == nome).Select(x => new ProdutoDTO
            {
                Descricao = x.Descricao,
                Id = x.Id,
                IdCategoriaProduto = x.IdCategoriaProduto,
                Nome = x.Nome,
                Valor = x.Valor
            }).ToListAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataBaseContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
