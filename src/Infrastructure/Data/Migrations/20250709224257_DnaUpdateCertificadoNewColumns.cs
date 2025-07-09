using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateCertificadoNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlFrente",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "HtmlVerso",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "ImagemFrente",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "ImagemVerso",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "NomeImagemFrente",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "NomeImagemVerso",
                table: "Certificados");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Certificados",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Certificados",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Certificados");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Certificados");

            migrationBuilder.AddColumn<string>(
                name: "HtmlFrente",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HtmlVerso",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemFrente",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagemVerso",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeImagemFrente",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeImagemVerso",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
