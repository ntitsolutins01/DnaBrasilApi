using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateIdebDimensaoEstadualNomeTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdebDimensaoEstadual_Estados_EstadoId",
                table: "IdebDimensaoEstadual");

            migrationBuilder.DropForeignKey(
                name: "FK_IdebDimensaoEstadual_EtapasEnsino_EtapaEnsinoId",
                table: "IdebDimensaoEstadual");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdebDimensaoEstadual",
                table: "IdebDimensaoEstadual");

            migrationBuilder.RenameTable(
                name: "IdebDimensaoEstadual",
                newName: "IdebDimensoesEstadual");

            migrationBuilder.RenameIndex(
                name: "IX_IdebDimensaoEstadual_EtapaEnsinoId",
                table: "IdebDimensoesEstadual",
                newName: "IX_IdebDimensoesEstadual_EtapaEnsinoId");

            migrationBuilder.RenameIndex(
                name: "IX_IdebDimensaoEstadual_EstadoId",
                table: "IdebDimensoesEstadual",
                newName: "IX_IdebDimensoesEstadual_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdebDimensoesEstadual",
                table: "IdebDimensoesEstadual",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdebDimensoesEstadual_Estados_EstadoId",
                table: "IdebDimensoesEstadual",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdebDimensoesEstadual_EtapasEnsino_EtapaEnsinoId",
                table: "IdebDimensoesEstadual",
                column: "EtapaEnsinoId",
                principalTable: "EtapasEnsino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdebDimensoesEstadual_Estados_EstadoId",
                table: "IdebDimensoesEstadual");

            migrationBuilder.DropForeignKey(
                name: "FK_IdebDimensoesEstadual_EtapasEnsino_EtapaEnsinoId",
                table: "IdebDimensoesEstadual");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdebDimensoesEstadual",
                table: "IdebDimensoesEstadual");

            migrationBuilder.RenameTable(
                name: "IdebDimensoesEstadual",
                newName: "IdebDimensaoEstadual");

            migrationBuilder.RenameIndex(
                name: "IX_IdebDimensoesEstadual_EtapaEnsinoId",
                table: "IdebDimensaoEstadual",
                newName: "IX_IdebDimensaoEstadual_EtapaEnsinoId");

            migrationBuilder.RenameIndex(
                name: "IX_IdebDimensoesEstadual_EstadoId",
                table: "IdebDimensaoEstadual",
                newName: "IX_IdebDimensaoEstadual_EstadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdebDimensaoEstadual",
                table: "IdebDimensaoEstadual",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdebDimensaoEstadual_Estados_EstadoId",
                table: "IdebDimensaoEstadual",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdebDimensaoEstadual_EtapasEnsino_EtapaEnsinoId",
                table: "IdebDimensaoEstadual",
                column: "EtapaEnsinoId",
                principalTable: "EtapasEnsino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
