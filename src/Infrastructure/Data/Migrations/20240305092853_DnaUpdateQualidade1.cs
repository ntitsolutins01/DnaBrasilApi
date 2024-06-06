using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateQualidade1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Questionarios_QuestionarioId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "QualidadeDeVidas",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVidas_QuestionarioId",
                table: "QualidadeDeVidas",
                newName: "IX_QualidadeDeVidas_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "QualidadeDeVidas",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVidas_AlunoId",
                table: "QualidadeDeVidas",
                newName: "IX_QualidadeDeVidas_QuestionarioId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "QualidadeDeVidas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Questionarios_QuestionarioId",
                table: "QualidadeDeVidas",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
