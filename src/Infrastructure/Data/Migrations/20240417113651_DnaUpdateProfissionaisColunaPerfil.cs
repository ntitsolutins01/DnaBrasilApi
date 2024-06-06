using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateProfissionaisColunaPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Profissionais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_PerfilId",
                table: "Profissionais",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Perfis_PerfilId",
                table: "Profissionais",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Perfis_PerfilId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_PerfilId",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Profissionais");
        }
    }
}
