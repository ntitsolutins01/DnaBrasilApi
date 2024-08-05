using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTalentoEsportivoNovaColunaEncaminhamentoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncaminhamentoId",
                table: "TalentosEsportivos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TalentosEsportivos_EncaminhamentoId",
                table: "TalentosEsportivos",
                column: "EncaminhamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TalentosEsportivos_Encaminhamentos_EncaminhamentoId",
                table: "TalentosEsportivos",
                column: "EncaminhamentoId",
                principalTable: "Encaminhamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentosEsportivos_Encaminhamentos_EncaminhamentoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropIndex(
                name: "IX_TalentosEsportivos_EncaminhamentoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropColumn(
                name: "EncaminhamentoId",
                table: "TalentosEsportivos");
        }
    }
}
