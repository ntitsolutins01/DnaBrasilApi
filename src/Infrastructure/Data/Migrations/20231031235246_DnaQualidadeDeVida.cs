using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQualidadeDeVida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_QualidadeDeVidas_QualidadeDeVidaId",
                table: "Questionarios");

            migrationBuilder.DropIndex(
                name: "IX_Questionarios_QualidadeDeVidaId",
                table: "Questionarios");

            migrationBuilder.DropColumn(
                name: "QualidadeDeVidaId",
                table: "Questionarios");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "QualidadeDeVidas",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVidas_AlunoId",
                table: "QualidadeDeVidas",
                newName: "IX_QualidadeDeVidas_QuestionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Questionarios_QuestionarioId",
                table: "QualidadeDeVidas",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Questionarios_QuestionarioId",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "QualidadeDeVidas",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVidas_QuestionarioId",
                table: "QualidadeDeVidas",
                newName: "IX_QualidadeDeVidas_AlunoId");

            migrationBuilder.AddColumn<int>(
                name: "QualidadeDeVidaId",
                table: "Questionarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "QualidadeDeVidas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_QualidadeDeVidaId",
                table: "Questionarios",
                column: "QualidadeDeVidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_QualidadeDeVidas_QualidadeDeVidaId",
                table: "Questionarios",
                column: "QualidadeDeVidaId",
                principalTable: "QualidadeDeVidas",
                principalColumn: "Id");
        }
    }
}
