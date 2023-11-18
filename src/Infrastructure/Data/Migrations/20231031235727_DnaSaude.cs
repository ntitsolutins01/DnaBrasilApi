using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaSaude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_SaudeId",
                table: "Laudos",
                column: "SaudeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Saudes_SaudeId",
                table: "Laudos",
                column: "SaudeId",
                principalTable: "Saudes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Saudes_SaudeId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_SaudeId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "SaudeId",
                table: "Laudos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Saudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saudes_AlunoId",
                table: "Saudes",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Alunos_AlunoId",
                table: "Saudes",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
