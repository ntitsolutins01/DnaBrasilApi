using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaVocacionalRenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusVocacionail",
                table: "Vocacionais",
                newName: "StatusVocacional");

            migrationBuilder.RenameColumn(
                name: "Resposta",
                table: "Vocacionais",
                newName: "Respostas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusVocacional",
                table: "Vocacionais",
                newName: "StatusVocacionail");

            migrationBuilder.RenameColumn(
                name: "Respostas",
                table: "Vocacionais",
                newName: "Resposta");
        }
    }
}
