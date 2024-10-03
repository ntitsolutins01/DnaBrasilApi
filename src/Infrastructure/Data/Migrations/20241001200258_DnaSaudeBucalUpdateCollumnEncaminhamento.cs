using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaSaudeBucalUpdateCollumnEncaminhamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncaminhamentoId",
                table: "SaudeBucais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaudeBucais_EncaminhamentoId",
                table: "SaudeBucais",
                column: "EncaminhamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Encaminhamentos_EncaminhamentoId",
                table: "SaudeBucais",
                column: "EncaminhamentoId",
                principalTable: "Encaminhamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Encaminhamentos_EncaminhamentoId",
                table: "SaudeBucais");

            migrationBuilder.DropIndex(
                name: "IX_SaudeBucais_EncaminhamentoId",
                table: "SaudeBucais");

            migrationBuilder.DropColumn(
                name: "EncaminhamentoId",
                table: "SaudeBucais");
        }
    }
}
