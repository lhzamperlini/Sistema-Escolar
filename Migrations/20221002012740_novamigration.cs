using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class novamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Professores_professorId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_professorId",
                table: "Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoDisciplinas",
                table: "AlunoDisciplinas");

            migrationBuilder.DropColumn(
                name: "professorId",
                table: "Disciplinas");

            migrationBuilder.AddColumn<string>(
                name: "Nomeprofessor",
                table: "Disciplinas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AlunoDisciplinas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "cpfAluno",
                table: "AlunoDisciplinas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoDisciplinas",
                table: "AlunoDisciplinas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_AlunoId",
                table: "AlunoDisciplinas",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoDisciplinas",
                table: "AlunoDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_AlunoDisciplinas_AlunoId",
                table: "AlunoDisciplinas");

            migrationBuilder.DropColumn(
                name: "Nomeprofessor",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "cpfAluno",
                table: "AlunoDisciplinas");

            migrationBuilder.AddColumn<int>(
                name: "professorId",
                table: "Disciplinas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AlunoDisciplinas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoDisciplinas",
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_professorId",
                table: "Disciplinas",
                column: "professorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Professores_professorId",
                table: "Disciplinas",
                column: "professorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
