using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loreggia.Delivery.Track.Autenticador.Repository.Migrations
{
    public partial class CriarTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    codigo = table.Column<Guid>(nullable: false),
                    apagado = table.Column<bool>(nullable: false),
                    dataDeCriacao = table.Column<DateTime>(nullable: false),
                    codigo_empresa = table.Column<int>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    email_verificado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
