using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;

namespace TechChallengeFIAP.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO?> GetByCpfAsync(string cpf);
        Task CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
    }
}
