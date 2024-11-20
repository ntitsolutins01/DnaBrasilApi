using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateTextoQuestaoUpdateAulaQuestaoEadNewCollumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AulaId",
                table: "QuestoesEad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestoesEad_AulaId",
                table: "QuestoesEad",
                column: "AulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestoesEad_Aulas_AulaId",
                table: "QuestoesEad",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestoesEad_Aulas_AulaId",
                table: "QuestoesEad");

            migrationBuilder.DropIndex(
                name: "IX_QuestoesEad_AulaId",
                table: "QuestoesEad");

            migrationBuilder.DropColumn(
                name: "AulaId",
                table: "QuestoesEad");
        }
    }
}
