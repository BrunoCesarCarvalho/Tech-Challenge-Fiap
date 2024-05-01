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

        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<PedidoEntity> Pedido { get; set; }
        public DbSet<PedidoProdutosEntity> PedidoProdutos { get; set; }
        public DbSet<PedidoStatusEtapaEntity> PedidoStatusEtapa { get; set; }
        public DbSet<ProdutoImagensEntity> ProdutoImagens { get; set; }
        public DbSet<StatusPagamentoEntity> StatusPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoriaProduto);

            modelBuilder.Entity<ProdutoImagensEntity>()
                .HasOne(pi => pi.Produto)
                .WithMany(p => p.Imagens)
                .HasForeignKey(pi => pi.IdProduto);


            modelBuilder.Entity<PedidoEntity>()
           .HasOne(p => p.Cliente)
           .WithMany()
           .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<PedidoEntity>()
                .HasOne(p => p.StatusEtapa)
                .WithMany()
                .HasForeignKey(p => p.IdStatusEtapa);

            modelBuilder.Entity<PedidoEntity>()
                .HasOne(p => p.StatusPagamento)
                .WithMany()
                .HasForeignKey(p => p.IdStatusPagamento);

            modelBuilder.Entity<PedidoProdutosEntity>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<PedidoProdutosEntity>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.PedidoProdutos)
                .HasForeignKey(pp => pp.IdPedido);


        }
    }
}
