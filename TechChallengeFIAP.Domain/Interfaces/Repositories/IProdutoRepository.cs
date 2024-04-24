﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IDisposable
    {
        Task<List<ProdutoDTO>> GetAll();
        Task CreateAsync(CreateProdutoDTO createProdutoDTO);
        Task<ProdutoDTO> GetByNomeAsync(string nome);

        Task<ProdutoDTO> GetByIdAsync(int id);

        Task EditAsync(EditProdutoDTO editProdutoDTO);

        Task DeleteAsync(int Id);

        Task<List<ProdutoDTO>> GetListByCategoryAsync(int categoryId);
    }
}