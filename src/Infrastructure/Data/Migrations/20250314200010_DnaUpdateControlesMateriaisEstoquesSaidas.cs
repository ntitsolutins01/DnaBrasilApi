using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateControlesMateriaisEstoquesSaidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Materiais_MaterialId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_MaterialId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "IX_ControlesMateriaisEstoquesSaidas_InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Inventarios_InventarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Inventarios_InventarioId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.RenameColumn(
                name: "InventarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_InventarioId",
                table: "ControlesMateriaisEstoquesSaidas",
                newName: "IX_ControlesMateriaisEstoquesSaidas_MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Materiais_MaterialId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
