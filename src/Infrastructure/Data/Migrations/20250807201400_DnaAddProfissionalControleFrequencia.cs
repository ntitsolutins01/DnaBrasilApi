using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaAddProfissionalControleFrequencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "ControlesFrequenciasEscolares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlesFrequenciasEscolares_ProfissionalId",
                table: "ControlesFrequenciasEscolares",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesFrequenciasEscolares_Profissionais_ProfissionalId",
                table: "ControlesFrequenciasEscolares",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesFrequenciasEscolares_Profissionais_ProfissionalId",
                table: "ControlesFrequenciasEscolares");

            migrationBuilder.DropIndex(
                name: "IX_ControlesFrequenciasEscolares_ProfissionalId",
                table: "ControlesFrequenciasEscolares");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "ControlesFrequenciasEscolares");
        }
    }
}
