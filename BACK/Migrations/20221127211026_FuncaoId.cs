using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class FuncaoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nota3Tres",
                table: "Alunos",
                newName: "NotaTres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotaTres",
                table: "Alunos",
                newName: "Nota3Tres");
        }
    }
}
