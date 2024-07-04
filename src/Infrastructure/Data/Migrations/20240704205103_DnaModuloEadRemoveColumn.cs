using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaModuloEadRemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas");

            migrationBuilder.DropForeignKey(
                name: "FK_ModulosEad_Usuarios_ProfessorId",
                table: "ModulosEad");

            migrationBuilder.DropIndex(
                name: "IX_ModulosEad_ProfessorId",
                table: "ModulosEad");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "ModulosEad");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "ControlesPresencas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "ModulosEad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "ControlesPresencas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModulosEad_ProfessorId",
                table: "ModulosEad",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesPresencas_Eventos_EventoId",
                table: "ControlesPresencas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModulosEad_Usuarios_ProfessorId",
                table: "ModulosEad",
                column: "ProfessorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
