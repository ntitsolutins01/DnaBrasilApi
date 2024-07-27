using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaVocacionalEncaminhamentoNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncaminhamentoId",
                table: "Vocacionais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vocacionais_EncaminhamentoId",
                table: "Vocacionais",
                column: "EncaminhamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacionais_Encaminhamentos_EncaminhamentoId",
                table: "Vocacionais",
                column: "EncaminhamentoId",
                principalTable: "Encaminhamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocacionais_Encaminhamentos_EncaminhamentoId",
                table: "Vocacionais");

            migrationBuilder.DropIndex(
                name: "IX_Vocacionais_EncaminhamentoId",
                table: "Vocacionais");

            migrationBuilder.DropColumn(
                name: "EncaminhamentoId",
                table: "Vocacionais");
        }
    }
}
