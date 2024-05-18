using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Domain.Interfaces.Services;
using TechChallengeFIAP.Domain.Validations;

namespace TechChallengeFIAP.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO)
        {
            var exist = await _clienteRepository.GetByCpfAsync(clienteCadastroDTO.Cpf);
            if (exist == null)
            {
                var id = await _clienteRepository.CreateAsync(clienteCadastroDTO);
                return id;
            }
            throw new Exception("Cliente já existe.");
        }

        public async Task<ClienteDTO> GetByCpfAsync(string cpf)
        {
            return await _clienteRepository.GetByCpfAsync(cpf);
        }

        public async Task<List<ClienteDTO>?> GetByPromotionsAsync(string cpf, string dtNascIni, string dtNascFin)
        {
            return await _clienteRepository.GetByPromotionsAsync(cpf, dtNascIni, dtNascFin);
        }

    }
}
