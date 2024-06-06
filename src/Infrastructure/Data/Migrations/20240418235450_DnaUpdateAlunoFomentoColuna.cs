using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoFomentoColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FomentoId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_FomentoId",
                table: "Alunos",
                column: "FomentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Fomentos_FomentoId",
                table: "Alunos",
                column: "FomentoId",
                principalTable: "Fomentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Fomentos_FomentoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_FomentoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "FomentoId",
                table: "Alunos");
        }
    }
}
