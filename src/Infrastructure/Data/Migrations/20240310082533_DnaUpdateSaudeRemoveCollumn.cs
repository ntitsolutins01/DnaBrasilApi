using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateSaudeRemoveCollumn : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
