using eCommerce.Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext() { }
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutosPedidos> ProdutosPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MiniProjecteCommerce;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(a => a.RG).HasMaxLength(20);
                entity.Property(a => a.CPF).HasMaxLength(20);
                entity.Property(a => a.DataCadastro).HasDefaultValueSql("GETDATE()");
                entity.HasIndex(a => a.Nome);
                entity.HasIndex(a => new { a.CPF, a.Email }).IsUnique();

            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(a => a.DataPedido).HasDefaultValueSql("GETDATE()");

                entity.Property(a => a.TipoPagamento).HasConversion<int>();

                entity.HasMany(a => a.Produtos).WithMany(a => a.Pedidos)
                    .UsingEntity<ProdutosPedidos>(
                        q => q.HasOne(a => a.Produto)
                        .WithMany(a => a.ProdutosPedidos)
                        .HasForeignKey(a => a.ProdutoId),
                        q => q.HasOne(a => a.Pedido)
                        .WithMany(a => a.ProdutosPedidos)
                        .HasForeignKey(a => a.PedidoId),
                        q =>
                        {
                            q.HasKey(a => new { a.PedidoId, a.ProdutoId });
                        }
                        );
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasIndex(a => a.Nome).IsUnique();

                entity.Property(a => a.Preco).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasIndex(a => a.Nome).IsUnique();
            });
        }
    }
}
