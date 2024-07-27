using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaLaudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_ConsumoAlimentares_ConsumoAlimentarId",
                table: "Questionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_SaudeBucais_SaudeBucalId",
                table: "Questionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais");

            migrationBuilder.DropIndex(
                name: "IX_Questionarios_ConsumoAlimentarId",
                table: "Questionarios");

            migrationBuilder.DropIndex(
                name: "IX_Questionarios_SaudeBucalId",
                table: "Questionarios");

            migrationBuilder.DropColumn(
                name: "ConsumoAlimentarId",
                table: "Questionarios");

            migrationBuilder.DropColumn(
                name: "SaudeBucalId",
                table: "Questionarios");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "SaudeBucais",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucais_AlunoId",
                table: "SaudeBucais",
                newName: "IX_SaudeBucais_QuestionarioId");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "ConsumoAlimentares",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoAlimentares_AlunoId",
                table: "ConsumoAlimentares",
                newName: "IX_ConsumoAlimentares_QuestionarioId");

            migrationBuilder.AddColumn<int>(
                name: "ConsumoId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaudeBucalId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_ConsumoId",
                table: "Laudos",
                column: "ConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_SaudeBucalId",
                table: "Laudos",
                column: "SaudeBucalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Questionarios_QuestionarioId",
                table: "ConsumoAlimentares",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoId",
                table: "Laudos",
                column: "ConsumoId",
                principalTable: "ConsumoAlimentares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_SaudeBucais_SaudeBucalId",
                table: "Laudos",
                column: "SaudeBucalId",
                principalTable: "SaudeBucais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Questionarios_QuestionarioId",
                table: "SaudeBucais",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Questionarios_QuestionarioId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_SaudeBucais_SaudeBucalId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Questionarios_QuestionarioId",
                table: "SaudeBucais");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_ConsumoId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_SaudeBucalId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "ConsumoId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "SaudeBucalId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "SaudeBucais",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucais_QuestionarioId",
                table: "SaudeBucais",
                newName: "IX_SaudeBucais_AlunoId");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "ConsumoAlimentares",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoAlimentares_QuestionarioId",
                table: "ConsumoAlimentares",
                newName: "IX_ConsumoAlimentares_AlunoId");

            migrationBuilder.AddColumn<int>(
                name: "ConsumoAlimentarId",
                table: "Questionarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaudeBucalId",
                table: "Questionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_ConsumoAlimentarId",
                table: "Questionarios",
                column: "ConsumoAlimentarId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_SaudeBucalId",
                table: "Questionarios",
                column: "SaudeBucalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_ConsumoAlimentares_ConsumoAlimentarId",
                table: "Questionarios",
                column: "ConsumoAlimentarId",
                principalTable: "ConsumoAlimentares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_SaudeBucais_SaudeBucalId",
                table: "Questionarios",
                column: "SaudeBucalId",
                principalTable: "SaudeBucais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
