using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;

namespace TechChallengeFIAP.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
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
            //var exist = await _produtoRepository.GetByIdAsync(id);
            //if (exist != null)
            //{
            //    _produtoRepository.DeleteAsync(exist);
            //}
            //else throw new Exception("Produto não existe.");

           await  _produtoRepository.DeleteAsync(id);
        }

        public async Task<List<ProdutoDTO>> GetAllAsync()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<List<ProdutoDTO>> GetListByCategoryAsync(int categoryId)
        {
            return await _produtoRepository.GetListByCategoryAsync(categoryId);
        }
    }
}
