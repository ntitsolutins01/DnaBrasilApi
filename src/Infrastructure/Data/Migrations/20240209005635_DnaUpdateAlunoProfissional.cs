using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfissionalId",
                table: "Alunos",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Profissionais_ProfissionalId",
                table: "Alunos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Profissionais_ProfissionalId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ProfissionalId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Alunos");
        }
    }
}
