using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaControleEstoqueUpdateCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Profissionais_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.RenameColumn(
                name: "ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "IX_ControlesMateriaisEstoquesSaidas_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Usuarios_UsuarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Usuarios_UsuarioId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_UsuarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "IX_ControlesMateriaisEstoquesSaidas_ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Profissionais_ProfissionalId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
