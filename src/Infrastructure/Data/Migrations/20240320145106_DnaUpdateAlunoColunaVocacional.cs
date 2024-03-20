using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoColunaVocacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VocacionalId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_VocacionalId",
                table: "Alunos",
                column: "VocacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Vocacionais_VocacionalId",
                table: "Alunos",
                column: "VocacionalId",
                principalTable: "Vocacionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Vocacionais_VocacionalId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_VocacionalId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "VocacionalId",
                table: "Alunos");
        }
    }
}
