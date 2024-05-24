using Microsoft.EntityFrameworkCore;
using TechChallengeFIAP.Domain.DTOs;
using TechChallengeFIAP.Domain.Interfaces.Repositories;
using TechChallengeFIAP.Infra.Context;
using TechChallengeFIAP.Infra.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                Nome = entity.Nome,
                DataNascimento = entity.DataNascimento.ToShortDateString()
            } : null;
        }

        public async Task<List<ClienteDTO>?> GetByPromotionsAsync(string cpf, string dtNascIni, string dtNascFin)
        {
            var query = _dataBaseContext.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(p => p.Cpf.Contains(cpf));
            }

            if (!string.IsNullOrEmpty(dtNascIni))
            {
                query = query.Where(p => p.DataNascimento >= Convert.ToDateTime(dtNascIni));
            }

            if (!string.IsNullOrEmpty(dtNascFin))
            {
                query = query.Where(p => p.DataNascimento <= Convert.ToDateTime(dtNascFin));
            }

            var entity = await query.ToListAsync();

            return entity.Select(s => new ClienteDTO()
            {
                Id = s.Id,
                Cpf = s.Cpf,
                Email = s.Email,
                Nome = s.Nome,
                DataNascimento = s.DataNascimento.ToShortDateString()

            }).ToList();
        }

        public async Task<int> CreateAsync(ClienteCadastroDTO clienteCadastroDTO)
        {
            var entity = new ClienteEntity()
            {
                Cpf = clienteCadastroDTO.Cpf,
                Nome = clienteCadastroDTO.Nome,
                Email = clienteCadastroDTO.Email,
                DataNascimento = Convert.ToDateTime(clienteCadastroDTO.DataNascimento)
            };

            await _dataBaseContext.Cliente.AddAsync(entity);
            await _dataBaseContext.SaveChangesAsync();

            return entity.Id;
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
