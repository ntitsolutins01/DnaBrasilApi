using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateModeloCarteirinhaNewCollumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlImagem",
                table: "ModelosCarteirinhas",
                newName: "UrlImagemVerso");

            migrationBuilder.RenameColumn(
                name: "NomeImagem",
                table: "ModelosCarteirinhas",
                newName: "NomeImagemVerso");

            migrationBuilder.AddColumn<string>(
                name: "NomeImagemFrente",
                table: "ModelosCarteirinhas",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagemFrente",
                table: "ModelosCarteirinhas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeImagemFrente",
                table: "ModelosCarteirinhas");

            migrationBuilder.DropColumn(
                name: "UrlImagemFrente",
                table: "ModelosCarteirinhas");

            migrationBuilder.RenameColumn(
                name: "UrlImagemVerso",
                table: "ModelosCarteirinhas",
                newName: "UrlImagem");

            migrationBuilder.RenameColumn(
                name: "NomeImagemVerso",
                table: "ModelosCarteirinhas",
                newName: "NomeImagem");
        }
    }
}
