using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateSaudeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "Saudes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "StatusSaude",
                table: "Saudes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes");

            migrationBuilder.DropColumn(
                name: "StatusSaude",
                table: "Saudes");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "Saudes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
