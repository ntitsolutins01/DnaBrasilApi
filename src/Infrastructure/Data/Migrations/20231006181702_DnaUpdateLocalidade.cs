using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locais_Municipio_MunicipioId",
                table: "Locais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locais",
                table: "Locais");

            migrationBuilder.RenameTable(
                name: "Locais",
                newName: "Localidades");

            migrationBuilder.RenameIndex(
                name: "IX_Locais_MunicipioId",
                table: "Localidades",
                newName: "IX_Localidades_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localidades",
                table: "Localidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Municipio_MunicipioId",
                table: "Localidades",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Municipio_MunicipioId",
                table: "Localidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localidades",
                table: "Localidades");

            migrationBuilder.RenameTable(
                name: "Localidades",
                newName: "Locais");

            migrationBuilder.RenameIndex(
                name: "IX_Localidades_MunicipioId",
                table: "Locais",
                newName: "IX_Locais_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locais",
                table: "Locais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locais_Municipio_MunicipioId",
                table: "Locais",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id");
        }
    }
}
