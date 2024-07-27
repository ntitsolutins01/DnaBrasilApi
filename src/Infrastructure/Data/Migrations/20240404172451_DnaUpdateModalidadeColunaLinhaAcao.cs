using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateModalidadeColunaLinhaAcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinhaAcaoId",
                table: "Modalidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modalidades_LinhaAcaoId",
                table: "Modalidades",
                column: "LinhaAcaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidades_LinhasAcoes_LinhaAcaoId",
                table: "Modalidades",
                column: "LinhaAcaoId",
                principalTable: "LinhasAcoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modalidades_LinhasAcoes_LinhaAcaoId",
                table: "Modalidades");

            migrationBuilder.DropIndex(
                name: "IX_Modalidades_LinhaAcaoId",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "LinhaAcaoId",
                table: "Modalidades");
        }
    }
}
