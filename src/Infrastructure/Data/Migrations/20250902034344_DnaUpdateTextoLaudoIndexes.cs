using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTextoLaudoIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos",
                column: "Aviso");

            migrationBuilder.CreateIndex(
                name: "IX_TextosLaudos_Classificacao_Idade_Sexo",
                table: "TextosLaudos",
                columns: new[] { "Classificacao", "Idade", "Sexo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos");

            migrationBuilder.DropIndex(
                name: "IX_TextosLaudos_Classificacao_Idade_Sexo",
                table: "TextosLaudos");
        }
    }
}
