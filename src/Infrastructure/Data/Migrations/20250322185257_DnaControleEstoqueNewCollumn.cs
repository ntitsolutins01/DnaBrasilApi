using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaControleEstoqueNewCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Profissionais_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Profissionais_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "ControlesMateriaisEstoquesSaidas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
