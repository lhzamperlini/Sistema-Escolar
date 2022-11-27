using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class AdicionarBoletimAoBancodeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TurmaId = table.Column<int>(type: "INTEGER", nullable: true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoTurma = table.Column<int>(type: "INTEGER", nullable: false),
                    AlunoCpf = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletins_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boletins_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletins_AlunoId",
                table: "Boletins",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletins_TurmaId",
                table: "Boletins",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletins");
        }
    }
}
