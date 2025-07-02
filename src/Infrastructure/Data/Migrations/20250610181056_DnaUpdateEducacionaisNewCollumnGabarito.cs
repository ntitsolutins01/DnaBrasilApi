using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateEducacionaisNewCollumnGabarito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educacionais_Series_SerieId",
                table: "Educacionais");

            migrationBuilder.DropIndex(
                name: "IX_Educacionais_SerieId",
                table: "Educacionais");

            migrationBuilder.DropColumn(
                name: "Pdf",
                table: "Educacionais");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Educacionais");

            migrationBuilder.AddColumn<string>(
                name: "Gabarito",
                table: "Educacionais",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gabarito",
                table: "Educacionais");

            migrationBuilder.AddColumn<string>(
                name: "Pdf",
                table: "Educacionais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Educacionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Educacionais_SerieId",
                table: "Educacionais",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educacionais_Series_SerieId",
                table: "Educacionais",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
