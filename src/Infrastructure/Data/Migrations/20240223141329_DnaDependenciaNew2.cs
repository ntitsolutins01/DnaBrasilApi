using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDependenciaNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Dependencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Dependencias");
        }
    }
}
