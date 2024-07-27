using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateParceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParceiroId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ParceiroId",
                table: "Alunos",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Parceiros_ParceiroId",
                table: "Alunos",
                column: "ParceiroId",
                principalTable: "Parceiros",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Parceiros_ParceiroId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ParceiroId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ParceiroId",
                table: "Alunos");
        }
    }
}
