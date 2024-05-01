using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTO>> GetAllAsync();
        Task CreateAsync(CreateProdutoDTO createProdutoDTO);
        Task EditAsync(EditProdutoDTO editProdutoDTO);
        Task DeleteAsync(int id);

        Task<List<ProdutoDTO>> GetListByIdCategoryAsync(int categoryId);
        Task<List<ProdutoDTO>> GetListByNomeCategoryAsync(string nome);
    }
}
