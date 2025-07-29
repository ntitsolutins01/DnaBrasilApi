using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLaudoNewColumnLaudoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducacionalId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_EducacionalId",
                table: "Laudos",
                column: "EducacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalId",
                table: "Laudos",
                column: "EducacionalId",
                principalTable: "Educacionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_EducacionalId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "EducacionalId",
                table: "Laudos");
        }
    }
}
