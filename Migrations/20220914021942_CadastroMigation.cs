using Microsoft.EntityFrameworkCore.Migrations;

namespace PagamentoAPI.Migrations
{
    public partial class CadastroMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    CadastroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Idade = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.CadastroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
