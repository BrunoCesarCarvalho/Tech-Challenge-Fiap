using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFIAP.Infra.Entities;

namespace TechChallengeFIAP.Infra.Context
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<ProdutoImagensEntity> ProdutoImagens { get; set; }
        public DbSet<CategoriaEntity> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoriaProduto); // Especifica explicitamente a chave estrangeira

            modelBuilder.Entity<ProdutoImagensEntity>()
                .HasOne(pi => pi.Produto)
                .WithMany(p => p.Imagens)
                .HasForeignKey(pi => pi.IdProduto);          

        }
    }
}
