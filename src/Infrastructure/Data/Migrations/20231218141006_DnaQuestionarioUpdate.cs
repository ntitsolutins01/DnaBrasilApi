using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQuestionarioUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_TipoLaudos_TipoId",
                table: "Questionarios");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "Questionarios",
                newName: "TipoLaudoId");

            migrationBuilder.RenameIndex(
                name: "IX_Questionarios_TipoId",
                table: "Questionarios",
                newName: "IX_Questionarios_TipoLaudoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_TipoLaudos_TipoLaudoId",
                table: "Questionarios",
                column: "TipoLaudoId",
                principalTable: "TipoLaudos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_TipoLaudos_TipoLaudoId",
                table: "Questionarios");

            migrationBuilder.RenameColumn(
                name: "TipoLaudoId",
                table: "Questionarios",
                newName: "TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Questionarios_TipoLaudoId",
                table: "Questionarios",
                newName: "IX_Questionarios_TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_TipoLaudos_TipoId",
                table: "Questionarios",
                column: "TipoId",
                principalTable: "TipoLaudos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
