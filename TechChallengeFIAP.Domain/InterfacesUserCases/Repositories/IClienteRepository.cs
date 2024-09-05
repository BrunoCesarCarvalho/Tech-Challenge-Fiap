

using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.InterfacesUserCases.Repositories
{
    public interface IClienteRepository
    {
        Task<List<ClienteDTO>?> GetByPromotionsAsync(string cpf, string dtNascIni, string dtNascFin);
        Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
        Task<ClienteDTO> GetByCpfAsync(string cpf);
    }
}
