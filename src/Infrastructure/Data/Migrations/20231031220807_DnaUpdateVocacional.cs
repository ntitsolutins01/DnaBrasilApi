using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateVocacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionarios_Vocacionais_VocacionalId",
                table: "Questionarios");

            migrationBuilder.DropIndex(
                name: "IX_Questionarios_VocacionalId",
                table: "Questionarios");

            migrationBuilder.DropColumn(
                name: "VocacionalId",
                table: "Questionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "Vocacionais",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "QuestionarioId",
                table: "Vocacionais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vocacionais_QuestionarioId",
                table: "Vocacionais",
                column: "QuestionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacionais_Questionarios_QuestionarioId",
                table: "Vocacionais",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocacionais_Questionarios_QuestionarioId",
                table: "Vocacionais");

            migrationBuilder.DropIndex(
                name: "IX_Vocacionais_QuestionarioId",
                table: "Vocacionais");

            migrationBuilder.DropColumn(
                name: "QuestionarioId",
                table: "Vocacionais");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "Vocacionais",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "VocacionalId",
                table: "Questionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_VocacionalId",
                table: "Questionarios",
                column: "VocacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionarios_Vocacionais_VocacionalId",
                table: "Questionarios",
                column: "VocacionalId",
                principalTable: "Vocacionais",
                principalColumn: "Id");
        }
    }
}
