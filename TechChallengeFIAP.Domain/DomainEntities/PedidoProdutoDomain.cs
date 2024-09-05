using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DomainEntities.Interfaces;
using TechChallengeFIAP.Domain.InterfacesUserCases.Repositories;
using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.Entities
{
    public class PedidoProdutoDomain : IPedidoProdutoDomain
    {
        private readonly IPedidoProdutosRepository _pedidoProdutosRepository;

        public PedidoProdutoDomain(IPedidoProdutosRepository pedidoProdutosRepository)
        {
            _pedidoProdutosRepository = pedidoProdutosRepository;
        }

        public async Task CreateAsync(List<CreatePedidoProdutosOnlyDTO> listCreatePedidoProdutosDTO)
        {
            await _pedidoProdutosRepository.CreateAsync(listCreatePedidoProdutosDTO);
        }
    }
}
