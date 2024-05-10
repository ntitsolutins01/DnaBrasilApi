using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateSaudeBucais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Questionarios_QuestionarioId",
                table: "SaudeBucais");

            migrationBuilder.RenameColumn(
                name: "StatusSaudeBucais",
                table: "SaudeBucais",
                newName: "StatusSaudeBucal");

            migrationBuilder.RenameColumn(
                name: "QuestionarioId",
                table: "SaudeBucais",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucais_QuestionarioId",
                table: "SaudeBucais",
                newName: "IX_SaudeBucais_AlunoId");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "SaudeBucais",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais");

            migrationBuilder.RenameColumn(
                name: "StatusSaudeBucal",
                table: "SaudeBucais",
                newName: "StatusSaudeBucais");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "SaudeBucais",
                newName: "QuestionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucais_AlunoId",
                table: "SaudeBucais",
                newName: "IX_SaudeBucais_QuestionarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "SaudeBucais",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Questionarios_QuestionarioId",
                table: "SaudeBucais",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
