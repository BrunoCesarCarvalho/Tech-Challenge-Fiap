using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.InterfacesUserCases.Repositories
{
    public interface IProdutoRepository : IDisposable
    {
        Task<List<ProdutoDTO>> GetAll();
        Task CreateAsync(CreateProdutoDTO createProdutoDTO);
        Task<ProdutoDTO> GetByNomeAsync(string nome);
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task EditAsync(EditProdutoDTO editProdutoDTO);
        Task DeleteAsync(int Id);
        Task<List<ProdutoDTO>> GetListByIdCategoryAsync(int categoryId);
        Task<List<ProdutoDTO>> GetListByNomeCategoryAsync(string nome);
        Task<bool> GetProductWithPedido(int idProduto);
    }
}
