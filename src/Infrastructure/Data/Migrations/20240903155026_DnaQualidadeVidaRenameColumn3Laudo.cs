using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQualidadeVidaRenameColumn3Laudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Modalidades_ModalidadeId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_ConsumoId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "ConsumoId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "StatusQualidadeDeVida",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "ModalidadeId",
                table: "Laudos",
                newName: "ConsumoAlimentarId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_ModalidadeId",
                table: "Laudos",
                newName: "IX_Laudos_ConsumoAlimentarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoAlimentarId",
                table: "Laudos",
                column: "ConsumoAlimentarId",
                principalTable: "ConsumoAlimentares",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoAlimentarId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "ConsumoAlimentarId",
                table: "Laudos",
                newName: "ModalidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_ConsumoAlimentarId",
                table: "Laudos",
                newName: "IX_Laudos_ModalidadeId");

            migrationBuilder.AddColumn<int>(
                name: "ConsumoId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusQualidadeDeVida",
                table: "Laudos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_ConsumoId",
                table: "Laudos",
                column: "ConsumoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_ConsumoAlimentares_ConsumoId",
                table: "Laudos",
                column: "ConsumoId",
                principalTable: "ConsumoAlimentares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Modalidades_ModalidadeId",
                table: "Laudos",
                column: "ModalidadeId",
                principalTable: "Modalidades",
                principalColumn: "Id");
        }
    }
}
