using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLocalidade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratosLocais_Localidade_LocalId",
                table: "ContratosLocais");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidade_Municipios_MunicipioId",
                table: "Localidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Localidade_LocalId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Localidade_LocalId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localidade",
                table: "Localidade");

            migrationBuilder.RenameTable(
                name: "Localidade",
                newName: "Localidades");

            migrationBuilder.RenameIndex(
                name: "IX_Localidade_MunicipioId",
                table: "Localidades",
                newName: "IX_Localidades_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localidades",
                table: "Localidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratosLocais_Localidades_LocalId",
                table: "ContratosLocais",
                column: "LocalId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Municipios_MunicipioId",
                table: "Localidades",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Localidades_LocalId",
                table: "Matriculas",
                column: "LocalId",
                principalTable: "Localidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Localidades_LocalId",
                table: "Vouchers",
                column: "LocalId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratosLocais_Localidades_LocalId",
                table: "ContratosLocais");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Municipios_MunicipioId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Localidades_LocalId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Localidades_LocalId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localidades",
                table: "Localidades");

            migrationBuilder.RenameTable(
                name: "Localidades",
                newName: "Localidade");

            migrationBuilder.RenameIndex(
                name: "IX_Localidades_MunicipioId",
                table: "Localidade",
                newName: "IX_Localidade_MunicipioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localidade",
                table: "Localidade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratosLocais_Localidade_LocalId",
                table: "ContratosLocais",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidade_Municipios_MunicipioId",
                table: "Localidade",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Localidade_LocalId",
                table: "Matriculas",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Localidade_LocalId",
                table: "Vouchers",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id");
        }
    }
}
