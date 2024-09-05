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
    public class ClienteDomain: IClienteDomain
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteDomain(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO)
        {
            return await _clienteRepository.CreateAsync(clienteCadastroDTO);
        }

        public async Task<ClienteDTO> GetByCpfAsync(string cpf)
        {
            return await _clienteRepository.GetByCpfAsync(cpf);
        }
    }
}
