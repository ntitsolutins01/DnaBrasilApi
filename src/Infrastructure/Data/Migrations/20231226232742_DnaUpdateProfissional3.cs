using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateProfissional3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Profissionais",
                newName: "Telefones");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Profissionais",
                newName: "Sexos");

            migrationBuilder.RenameColumn(
                name: "DtNascimento",
                table: "Profissionais",
                newName: "DtNascimentos");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Profissionais",
                newName: "Celulars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefones",
                table: "Profissionais",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Sexos",
                table: "Profissionais",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "DtNascimentos",
                table: "Profissionais",
                newName: "DtNascimento");

            migrationBuilder.RenameColumn(
                name: "Celulars",
                table: "Profissionais",
                newName: "Celular");
        }
    }
}
