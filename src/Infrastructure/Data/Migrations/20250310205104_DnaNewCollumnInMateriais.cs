using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaNewCollumnInMateriais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Materiais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_LocalidadeId",
                table: "Materiais",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Localidades_LocalidadeId",
                table: "Materiais",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Localidades_LocalidadeId",
                table: "Materiais");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_LocalidadeId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Materiais");
        }
    }
}
