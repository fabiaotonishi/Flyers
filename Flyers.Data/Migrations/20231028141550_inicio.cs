using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flyers.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", maxLength: 16, nullable: false),
                    Pessoa = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: true),
                    Nascimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Genero = table.Column<int>(type: "INTEGER", nullable: true),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", maxLength: 16, nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Perfil = table.Column<int>(type: "INTEGER", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", maxLength: 16, nullable: false),
                    Whatsapp = table.Column<string>(type: "varchar(100)", maxLength: 16, nullable: true),
                    Video = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: true),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dominios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dominios_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDominio = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Dados = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Url = table.Column<string>(type: "varchar(100)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Pasta = table.Column<int>(type: "INTEGER", nullable: false),
                    Entidade = table.Column<int>(type: "INTEGER", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDominio = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Termino = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofertas_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDominio = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Destaque = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RedeSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDominio = table.Column<int>(type: "INTEGER", nullable: false),
                    Canal = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedeSociais_Dominios_IdDominio",
                        column: x => x.IdDominio,
                        principalTable: "Dominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfertasProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdOferta = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdHash = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertasProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfertasProdutos_Ofertas_IdOferta",
                        column: x => x.IdOferta,
                        principalTable: "Ofertas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfertasProdutos_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dominios",
                columns: new[] { "Id", "Descricao", "Email", "IdEndereco", "IdHash", "Inativo", "Inclusao", "Nome", "Telefone", "Video", "Whatsapp" },
                values: new object[] { 1, null, "webmaster@mowbi.com.br", null, new Guid("0b49c295-3e71-42ff-9a46-8a56ff4fe1b4"), false, new DateTime(2023, 10, 28, 11, 15, 50, 279, DateTimeKind.Local).AddTicks(4923), "MoWBI", "17 99999-9999", null, null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "IdHash", "Inativo", "Inclusao", "Nome", "Perfil", "Senha", "Telefone" },
                values: new object[] { 1, "administrador@teste.com.br", new Guid("3b26afa0-0285-4971-b773-d17df8a07015"), false, new DateTime(2023, 10, 28, 11, 15, 50, 282, DateTimeKind.Local).AddTicks(4072), "Administrador teste", 1, "25D55AD283AA400AF464C76D713C07AD", "17 99999-9999" });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_IdDominio",
                table: "Arquivos",
                column: "IdDominio");

            migrationBuilder.CreateIndex(
                name: "IX_Dominios_IdEndereco",
                table: "Dominios",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdDominio",
                table: "Ofertas",
                column: "IdDominio");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasProdutos_IdOferta",
                table: "OfertasProdutos",
                column: "IdOferta");

            migrationBuilder.CreateIndex(
                name: "IX_OfertasProdutos_IdProduto",
                table: "OfertasProdutos",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdDominio",
                table: "Produtos",
                column: "IdDominio");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_IdDominio",
                table: "RedeSociais",
                column: "IdDominio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "OfertasProdutos");

            migrationBuilder.DropTable(
                name: "RedeSociais");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Dominios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
