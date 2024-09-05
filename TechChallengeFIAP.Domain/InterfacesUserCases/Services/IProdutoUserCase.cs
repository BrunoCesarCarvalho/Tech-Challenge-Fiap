using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.InterfacesUserCases.Services
{
    public interface IProdutoUserCase
    {
        Task<List<ProdutoDTO>> GetAllAsync();
        Task CreateAsync(CreateProdutoDTO createProdutoDTO);
        Task EditAsync(EditProdutoDTO editProdutoDTO);
        Task DeleteAsync(int id);

        Task<List<ProdutoDTO>> GetListByIdCategoryAsync(int categoryId);
        Task<List<ProdutoDTO>> GetListByNomeCategoryAsync(string nome);
    }
}
