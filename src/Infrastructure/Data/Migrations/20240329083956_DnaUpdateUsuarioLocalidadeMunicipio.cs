using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateUsuarioLocalidadeMunicipio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MunicipioId",
                table: "Usuarios",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Municipios_MunicipioId",
                table: "Usuarios",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Municipios_MunicipioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MunicipioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Usuarios");
        }
    }
}
