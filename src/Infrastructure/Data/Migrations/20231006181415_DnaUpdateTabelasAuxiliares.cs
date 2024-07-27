using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTabelasAuxiliares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMunicipio",
                table: "Locais");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Locais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Locais",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Locais_MunicipioId",
                table: "Locais",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locais_Municipio_MunicipioId",
                table: "Locais",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locais_Municipio_MunicipioId",
                table: "Locais");

            migrationBuilder.DropIndex(
                name: "IX_Locais_MunicipioId",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locais");

            migrationBuilder.AddColumn<int>(
                name: "IdMunicipio",
                table: "Locais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
