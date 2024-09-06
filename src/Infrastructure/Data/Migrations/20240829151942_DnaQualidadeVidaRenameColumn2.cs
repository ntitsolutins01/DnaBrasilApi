using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQualidadeVidaRenameColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Encaminhamentos_EncaminhamentoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropIndex(
                name: "IX_QualidadeDeVidas_EncaminhamentoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "EncaminhamentoId",
                table: "QualidadeDeVidas");

            migrationBuilder.AddColumn<string>(
                name: "Encaminhamento",
                table: "QualidadeDeVidas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Encaminhamento",
                table: "QualidadeDeVidas");

            migrationBuilder.AddColumn<int>(
                name: "EncaminhamentoId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualidadeDeVidas_EncaminhamentoId",
                table: "QualidadeDeVidas",
                column: "EncaminhamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Encaminhamentos_EncaminhamentoId",
                table: "QualidadeDeVidas",
                column: "EncaminhamentoId",
                principalTable: "Encaminhamentos",
                principalColumn: "Id");
        }
    }
}
