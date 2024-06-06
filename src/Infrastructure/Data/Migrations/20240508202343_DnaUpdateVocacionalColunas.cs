using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateVocacionalColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Vocacionais_VocacionalId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vocacionais_Questionarios_QuestionarioId",
                table: "Vocacionais");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_VocacionalId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "VocacionalId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "StatusVocacionais",
                table: "Vocacionais",
                newName: "StatusVocacionail");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "Vocacionais",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vocacionais_QuestionarioId",
                table: "Vocacionais",
                newName: "IX_Vocacionais_AlunoId");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "Vocacionais",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacionais_Alunos_AlunoId",
                table: "Vocacionais",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocacionais_Alunos_AlunoId",
                table: "Vocacionais");

            migrationBuilder.RenameColumn(
                name: "StatusVocacionail",
                table: "Vocacionais",
                newName: "StatusVocacionais");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Vocacionais",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vocacionais_AlunoId",
                table: "Vocacionais",
                newName: "IX_Vocacionais_QuestionarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "Vocacionais",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "VocacionalId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_VocacionalId",
                table: "Alunos",
                column: "VocacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Vocacionais_VocacionalId",
                table: "Alunos",
                column: "VocacionalId",
                principalTable: "Vocacionais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacionais_Questionarios_QuestionarioId",
                table: "Vocacionais",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
