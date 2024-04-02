using Flyers.Core.Entities;
using Flyers.Core.Extensions;
using Flyers.Core.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Flyers.Data.Contexts
{
    public class DadosDbContext : DbContext
    {
        //Mapeamentos
        public DbSet<DominioEntity> Dominios { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<RedeSocialEntity> RedeSociais { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ArquivoEntity> Arquivos { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<OfertaEntity> Ofertas { get; set; }
        public DbSet<OfertaProdutoEntity> OfertasProdutos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }

        //Metodos
        public DadosDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Metodo de configuracao do banco de dados 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuracao do banco de dados SQLite
            //optionsBuilder.UseSqlite(@"Data Source=./Data/Flayers.db;");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Metodo de criacao do banco de dados 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nome das tabelas            
            modelBuilder.Entity<DominioEntity>().ToTable("Dominios");
            modelBuilder.Entity<EnderecoEntity>().ToTable("Enderecos");
            modelBuilder.Entity<RedeSocialEntity>().ToTable("RedeSociais");
            modelBuilder.Entity<UsuarioEntity>().ToTable("Usuarios");
            modelBuilder.Entity<ArquivoEntity>().ToTable("Arquivos");
            modelBuilder.Entity<CategoriaEntity>().ToTable("Categorias");
            modelBuilder.Entity<ProdutoEntity>().ToTable("Produtos");
            modelBuilder.Entity<OfertaEntity>().ToTable("Ofertas");
            modelBuilder.Entity<OfertaProdutoEntity>().ToTable("OfertasProdutos");
            modelBuilder.Entity<ClienteEntity>().ToTable("Clientes");
            modelBuilder.Entity<ClienteFisicaEntity>().ToTable("Clientes");

            //Padroes
            //Propriedades do tipo string
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            //Desativar delete em cascata para todos os relacionamentos
            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Configuracao inicial 
            modelBuilder.Entity<DominioEntity>().HasData(
                new DominioEntity
                {
                    Id = 1,
                    Nome = "MoWBI",
                    Email = "webmaster@mowbi.com.br",
                    Telefone = "17 99999-9999"
                });


            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity
                {
                    Id = 1,
                    Nome = "Administrador teste",
                    Email = "administrador@teste.com.br",
                    Telefone = "17 99999-9999",
                    Senha = "12345678".ToMd5(),
                    Perfil = PerfilValue.Administrador,
                });

             modelBuilder.Entity<OfertaProdutoEntity>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfertaProdutoEntity>()
               .Property(p => p.Desconto)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfertaProdutoEntity>()
               .Property(p => p.PrecoDesconto)
               .HasColumnType("decimal(18,2)");

            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DadosDbContext).Assembly);
        }
    }
}
