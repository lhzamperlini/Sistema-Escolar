using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class AdicionarNotaTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NotaTres",
                table: "Alunos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaTres",
                table: "Alunos");
        }
    }
}
