using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateQualidade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RespostaId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QualidadeDeVidas_RespostaId",
                table: "QualidadeDeVidas",
                column: "RespostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Respostas_RespostaId",
                table: "QualidadeDeVidas",
                column: "RespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Respostas_RespostaId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropIndex(
                name: "IX_QualidadeDeVidas_RespostaId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "RespostaId",
                table: "QualidadeDeVidas");
        }
    }
}
