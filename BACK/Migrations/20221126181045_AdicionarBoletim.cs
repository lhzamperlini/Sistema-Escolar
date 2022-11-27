using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class AdicionarBoletim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota3Tres",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Nota3Tres",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
