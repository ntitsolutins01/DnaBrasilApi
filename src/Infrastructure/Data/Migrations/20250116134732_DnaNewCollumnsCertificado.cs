using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaNewCollumnsCertificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeFotoVerso",
                table: "Certificados",
                newName: "NomeImagemVerso");

            migrationBuilder.RenameColumn(
                name: "NomeFotoFrente",
                table: "Certificados",
                newName: "NomeImagemFrente");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemVerso",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemFrente",
                table: "Certificados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeImagemVerso",
                table: "Certificados",
                newName: "NomeFotoVerso");

            migrationBuilder.RenameColumn(
                name: "NomeImagemFrente",
                table: "Certificados",
                newName: "NomeFotoFrente");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemVerso",
                table: "Certificados",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagemFrente",
                table: "Certificados",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
