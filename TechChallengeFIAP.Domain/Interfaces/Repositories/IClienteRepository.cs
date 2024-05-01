using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<ClienteDTO?> GetByCpfAsync(string cpf);
        Task CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
    }
}
