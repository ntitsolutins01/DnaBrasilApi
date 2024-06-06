using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLaudoColunaModalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Encaminhamento",
                table: "Laudos");

            migrationBuilder.AddColumn<int>(
                name: "ModalidadeId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_ModalidadeId",
                table: "Laudos",
                column: "ModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Modalidades_ModalidadeId",
                table: "Laudos",
                column: "ModalidadeId",
                principalTable: "Modalidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Modalidades_ModalidadeId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_ModalidadeId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "ModalidadeId",
                table: "Laudos");

            migrationBuilder.AddColumn<string>(
                name: "Encaminhamento",
                table: "Laudos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);
        }
    }
}
