using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaConsumoAlimentarUpdateColumnEncaminhamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncaminhamentoId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoAlimentares_EncaminhamentoId",
                table: "ConsumoAlimentares",
                column: "EncaminhamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Encaminhamentos_EncaminhamentoId",
                table: "ConsumoAlimentares",
                column: "EncaminhamentoId",
                principalTable: "Encaminhamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Encaminhamentos_EncaminhamentoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropIndex(
                name: "IX_ConsumoAlimentares_EncaminhamentoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropColumn(
                name: "EncaminhamentoId",
                table: "ConsumoAlimentares");
        }
    }
}
