using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTextoLaudoLenghtColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "TextosLaudos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "TextosLaudos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "TextosLaudos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "TextosLaudos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "TextosLaudos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "TextosLaudos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
