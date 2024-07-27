using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoTalentoEsportivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TalentoEsportivoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TalentoEsportivoId",
                table: "Alunos",
                column: "TalentoEsportivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_TalentosEsportivos_TalentoEsportivoId",
                table: "Alunos",
                column: "TalentoEsportivoId",
                principalTable: "TalentosEsportivos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_TalentosEsportivos_TalentoEsportivoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TalentoEsportivoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TalentoEsportivoId",
                table: "Alunos");
        }
    }
}
