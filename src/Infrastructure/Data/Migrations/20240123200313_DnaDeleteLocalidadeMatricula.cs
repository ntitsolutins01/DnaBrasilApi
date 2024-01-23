using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteLocalidadeMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Localidades_LocalidadeId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_LocalidadeId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Matriculas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Matriculas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_LocalidadeId",
                table: "Matriculas",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Localidades_LocalidadeId",
                table: "Matriculas",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }
    }
}
