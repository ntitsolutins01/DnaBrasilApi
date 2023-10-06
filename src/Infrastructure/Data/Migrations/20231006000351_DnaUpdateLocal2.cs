using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLocal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Locais");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Locais",
                newName: "IdMunicipio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMunicipio",
                table: "Locais",
                newName: "IdEstado");

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Locais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
