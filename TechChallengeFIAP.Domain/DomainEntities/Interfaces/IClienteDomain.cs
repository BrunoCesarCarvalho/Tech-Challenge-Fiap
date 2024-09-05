using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.DTOs;

namespace TechChallengeFIAP.Domain.DomainEntities.Interfaces
{
    public interface IClienteDomain
    {
        Task<ClienteDTO> GetByCpfAsync(string cpf);
        Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO);
    }
}
