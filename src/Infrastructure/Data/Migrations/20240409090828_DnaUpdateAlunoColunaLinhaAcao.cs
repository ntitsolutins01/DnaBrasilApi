using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoColunaLinhaAcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreasDesejadas",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ModalidadeLinhaAcao",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "LinhaAcaoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_LinhaAcaoId",
                table: "Alunos",
                column: "LinhaAcaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_LinhasAcoes_LinhaAcaoId",
                table: "Alunos",
                column: "LinhaAcaoId",
                principalTable: "LinhasAcoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_LinhasAcoes_LinhaAcaoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_LinhaAcaoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "LinhaAcaoId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "AreasDesejadas",
                table: "Alunos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModalidadeLinhaAcao",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
