using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoGrauParentesco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrauParentescoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_GrauParentescoId",
                table: "Alunos",
                column: "GrauParentescoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_GrauParentescos_GrauParentescoId",
                table: "Alunos",
                column: "GrauParentescoId",
                principalTable: "GrauParentescos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_GrauParentescos_GrauParentescoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_GrauParentescoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "GrauParentescoId",
                table: "Alunos");
        }
    }
}
