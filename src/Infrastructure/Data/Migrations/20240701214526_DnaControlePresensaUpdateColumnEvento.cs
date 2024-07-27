using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaControlePresensaUpdateColumnEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "ControlesPresencas",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControlesPresencas_EventoId",
                table: "ControlesPresencas",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas");

            migrationBuilder.DropIndex(
                name: "IX_ControlesPresencas_EventoId",
                table: "ControlesPresencas");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "ControlesPresencas");
        }
    }
}
