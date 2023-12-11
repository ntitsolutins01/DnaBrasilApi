using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoNovasColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_LocalidadeId",
                table: "Alunos",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_LocalidadeId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Alunos");
        }
    }
}
