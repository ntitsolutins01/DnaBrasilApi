using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Responsaveis_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Responsaveis_ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Alunos");
        }
    }
}
