using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoCollumnSerieId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_SerieId",
                table: "Alunos",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Series_SerieId",
                table: "Alunos",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Series_SerieId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_SerieId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Alunos");
        }
    }
}
