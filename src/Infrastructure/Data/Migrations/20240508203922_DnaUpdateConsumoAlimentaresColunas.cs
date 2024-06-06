using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateConsumoAlimentaresColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Questionarios_QuestionarioId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropIndex(
                name: "IX_ConsumoAlimentares_QuestionarioId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropColumn(
                name: "QuestionarioId",
                table: "ConsumoAlimentares");

            migrationBuilder.RenameColumn(
                name: "StatusConsumoAlimentares",
                table: "ConsumoAlimentares",
                newName: "StatusConsumoAlimentar");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoAlimentares_AlunoId",
                table: "ConsumoAlimentares",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropIndex(
                name: "IX_ConsumoAlimentares_AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.RenameColumn(
                name: "StatusConsumoAlimentar",
                table: "ConsumoAlimentares",
                newName: "StatusConsumoAlimentares");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestionarioId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoAlimentares_QuestionarioId",
                table: "ConsumoAlimentares",
                column: "QuestionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Questionarios_QuestionarioId",
                table: "ConsumoAlimentares",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id");
        }
    }
}
