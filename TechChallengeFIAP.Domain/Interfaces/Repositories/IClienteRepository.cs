using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<List<ClienteDTO>?> GetByPromotionsAsync(string cpf, string dtNascIni, string dtNascFin);
        Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
        Task<ClienteDTO> GetByCpfAsync(string cpf);
    }
}
