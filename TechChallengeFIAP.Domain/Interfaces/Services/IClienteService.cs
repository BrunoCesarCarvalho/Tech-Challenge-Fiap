using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>?> GetByPromotionsAsync(string cpf, string dtNascIni, string dtNascFin);
        Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
        Task<ClienteDTO> GetByCpfAsync(string cpf);
    }
}
