using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class MudandoNotasParaOBoletim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaDois",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaTres",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaUm",
                table: "Alunos");

            migrationBuilder.AddColumn<double>(
                name: "Media",
                table: "Boletins",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaDois",
                table: "Boletins",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaTres",
                table: "Boletins",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaUm",
                table: "Boletins",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "Boletins");

            migrationBuilder.DropColumn(
                name: "NotaDois",
                table: "Boletins");

            migrationBuilder.DropColumn(
                name: "NotaTres",
                table: "Boletins");

            migrationBuilder.DropColumn(
                name: "NotaUm",
                table: "Boletins");

            migrationBuilder.AddColumn<double>(
                name: "Media",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaDois",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaTres",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaUm",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
