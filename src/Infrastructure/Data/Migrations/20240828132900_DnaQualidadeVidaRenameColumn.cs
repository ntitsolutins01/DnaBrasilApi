using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQualidadeVidaRenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resposta",
                table: "QualidadeDeVidas",
                newName: "Respostas");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Respostas",
                table: "QualidadeDeVidas",
                newName: "Resposta");
        }
    }
}
