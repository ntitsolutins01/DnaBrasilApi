using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateUsuarioRemoverColunaLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }
    }
}
