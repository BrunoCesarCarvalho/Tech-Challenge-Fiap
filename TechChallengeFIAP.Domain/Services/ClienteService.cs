using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;

namespace TechChallengeFIAP.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CreateAsync(ClienteCadastroDTO clienteCadastroDTO)
        {
            var exist = await _clienteRepository.GetByCpfAsync(clienteCadastroDTO.Cpf);
            if (exist == null)
            {
                await _clienteRepository.CreateAsync(clienteCadastroDTO);
                return;
            }
            throw new Exception("Cliente já existe.");
        }

        public async Task<ClienteDTO?> GetByCpfAsync(string cpf)
        {
            return await _clienteRepository.GetByCpfAsync(cpf);
        }
    }
}
