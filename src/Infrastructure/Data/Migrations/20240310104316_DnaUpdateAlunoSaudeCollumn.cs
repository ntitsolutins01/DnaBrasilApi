using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoSaudeCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Encaminhamento",
                table: "Laudos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Encaminhamento",
                table: "Laudos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);
        }
    }
}
