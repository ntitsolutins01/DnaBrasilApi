using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaProfissionalUpdateLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Profissionais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_LocalidadeId",
                table: "Profissionais",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Localidades_LocalidadeId",
                table: "Profissionais",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Localidades_LocalidadeId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_LocalidadeId",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Profissionais");
        }
    }
}
