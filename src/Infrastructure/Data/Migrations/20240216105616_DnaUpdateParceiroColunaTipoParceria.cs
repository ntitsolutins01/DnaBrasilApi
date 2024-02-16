using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateParceiroColunaTipoParceria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoParceria",
                table: "Parceiros");

            migrationBuilder.AddColumn<int>(
                name: "TipoParceriaId",
                table: "Parceiros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_TipoParceriaId",
                table: "Parceiros",
                column: "TipoParceriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parceiros_TiposParcerias_TipoParceriaId",
                table: "Parceiros",
                column: "TipoParceriaId",
                principalTable: "TiposParcerias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parceiros_TiposParcerias_TipoParceriaId",
                table: "Parceiros");

            migrationBuilder.DropIndex(
                name: "IX_Parceiros_TipoParceriaId",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "TipoParceriaId",
                table: "Parceiros");

            migrationBuilder.AddColumn<int>(
                name: "TipoParceria",
                table: "Parceiros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
