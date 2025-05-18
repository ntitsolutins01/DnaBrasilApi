using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoPresenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosPresencas_Aulas_AulaId",
                table: "AlunosPresencas");

            migrationBuilder.RenameColumn(
                name: "AulaId",
                table: "AlunosPresencas",
                newName: "AtividadeId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunosPresencas_AulaId",
                table: "AlunosPresencas",
                newName: "IX_AlunosPresencas_AtividadeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "AlunosPresencas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosPresencas_Atividades_AtividadeId",
                table: "AlunosPresencas",
                column: "AtividadeId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunosPresencas_Atividades_AtividadeId",
                table: "AlunosPresencas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "AlunosPresencas");

            migrationBuilder.RenameColumn(
                name: "AtividadeId",
                table: "AlunosPresencas",
                newName: "AulaId");

            migrationBuilder.RenameIndex(
                name: "IX_AlunosPresencas_AtividadeId",
                table: "AlunosPresencas",
                newName: "IX_AlunosPresencas_AulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunosPresencas_Aulas_AulaId",
                table: "AlunosPresencas",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
