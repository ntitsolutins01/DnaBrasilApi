using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTextoLaudoNovaColuna13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "TextosLaudos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "TextosLaudos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "TextosLaudos");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "TextosLaudos");
        }
    }
}
