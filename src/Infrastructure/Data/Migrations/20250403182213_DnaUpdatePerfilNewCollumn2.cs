using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdatePerfilNewCollumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoolEad",
                table: "Perfis");

            migrationBuilder.AddColumn<bool>(
                name: "Ead",
                table: "Perfis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Perfis",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ead",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Perfis");

            migrationBuilder.AddColumn<int>(
                name: "BoolEad",
                table: "Perfis",
                type: "int",
                maxLength: 1,
                nullable: true);
        }
    }
}
