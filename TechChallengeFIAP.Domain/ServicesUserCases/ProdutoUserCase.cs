using TechChallengeFIAP.DTOs;
using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.Domain.InterfacesUserCases.Services;

namespace TechChallengeFIAP.Domain.ServicesUserCases
{
    public class ProdutoUserCase : IProdutoUserCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUserCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task CreateAsync(CreateProdutoDTO createProdutoDTO)
        {
            var exist = await _produtoRepository.GetByNomeAsync(createProdutoDTO.Nome);

            if (exist == null)
            {
                await _produtoRepository.CreateAsync(createProdutoDTO);
            }
            else throw new Exception("Produto já existe.");
        }

        public async Task EditAsync(EditProdutoDTO editProdutoDTO)
        {
            var exist = await _produtoRepository.GetByIdAsync(editProdutoDTO.Id);

            if (exist != null)
            {
                await _produtoRepository.EditAsync(editProdutoDTO);
            }
            else throw new Exception("Produto não existe.");
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto != null)
            {
                var exist = await _produtoRepository.GetProductWithPedido(id);
                if (exist)
                    throw new Exception("Produto com Pedido Ativo.");

                await _produtoRepository.DeleteAsync(produto.Id);
            }
            else throw new Exception("Produto não existe.");
        }

        public async Task<List<ProdutoDTO>> GetAllAsync()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<List<ProdutoDTO>> GetListByIdCategoryAsync(int categoryId)
        {
            return await _produtoRepository.GetListByIdCategoryAsync(categoryId);
        }

        public async Task<List<ProdutoDTO>> GetListByNomeCategoryAsync(string nome)
        {
            return await _produtoRepository.GetListByNomeCategoryAsync(nome);
        }
    }
}
