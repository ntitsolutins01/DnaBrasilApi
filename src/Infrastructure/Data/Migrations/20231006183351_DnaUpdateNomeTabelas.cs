using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateNomeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Municipio_MunicipioId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Estado_EstadoId",
                table: "Municipio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.RenameTable(
                name: "Municipio",
                newName: "Municipios");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

            migrationBuilder.RenameIndex(
                name: "IX_Municipio_EstadoId",
                table: "Municipios",
                newName: "IX_Municipios_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Municipios_MunicipioId",
                table: "Localidades",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_EstadoId",
                table: "Municipios",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Municipios_MunicipioId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_EstadoId",
                table: "Municipios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipios",
                table: "Municipios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.RenameTable(
                name: "Municipios",
                newName: "Municipio");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_EstadoId",
                table: "Municipio",
                newName: "IX_Municipio_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipio",
                table: "Municipio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Municipio_MunicipioId",
                table: "Localidades",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Estado_EstadoId",
                table: "Municipio",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id");
        }
    }
}
