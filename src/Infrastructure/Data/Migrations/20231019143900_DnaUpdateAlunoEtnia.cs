using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoEtnia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Profissionais",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Etnia",
                table: "Alunos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Etnia",
                table: "Alunos");
        }
    }
}
