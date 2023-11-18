using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLaudo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Alunos_AlunoId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_AlunoId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Laudos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Laudos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_AlunoId",
                table: "Laudos",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Alunos_AlunoId",
                table: "Laudos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
