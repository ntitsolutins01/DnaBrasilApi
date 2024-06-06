using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateSaudeColunaAlunoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Saudes_SaudeId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_SaudeId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SaudeId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Saudes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saudes_AlunoId",
                table: "Saudes",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Alunos_AlunoId",
                table: "Saudes",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saudes_Alunos_AlunoId",
                table: "Saudes");

            migrationBuilder.DropIndex(
                name: "IX_Saudes_AlunoId",
                table: "Saudes");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Saudes");

            migrationBuilder.AddColumn<int>(
                name: "SaudeId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_SaudeId",
                table: "Alunos",
                column: "SaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Saudes_SaudeId",
                table: "Alunos",
                column: "SaudeId",
                principalTable: "Saudes",
                principalColumn: "Id");
        }
    }
}
