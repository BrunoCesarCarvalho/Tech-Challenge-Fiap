using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Entities;

namespace TechChallengeFIAP.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {

        private readonly DataBaseContext _dataBaseContext;

        public ClienteRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<ClienteDTO?> GetByCpfAsync(string cpf)
        {
            var entity = await _dataBaseContext.Cliente.FirstOrDefaultAsync(w => w.Cpf == cpf);

            return entity != null ? new ClienteDTO()
            {
                Id = entity.Id,
                Cpf = entity.Cpf,
                Email = entity.Email,
                Nome = entity.Nome
            } : null;
        }

        public async Task CreateAsync(ClienteCadastroDTO clienteCadastroDTO)
        {
            var entity = new ClienteEntity()
            {
                Cpf = clienteCadastroDTO.Cpf,
                Nome = clienteCadastroDTO.Nome,
                Email = clienteCadastroDTO.Email
            };

            await _dataBaseContext.Cliente.AddAsync(entity);
            await _dataBaseContext.SaveChangesAsync();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataBaseContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
