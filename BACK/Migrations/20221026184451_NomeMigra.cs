using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class NomeMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Media",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Nota3Tres",
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
                name: "NotaUm",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Nota3Tres",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaDois",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NotaUm",
                table: "Alunos");
        }
    }
}
