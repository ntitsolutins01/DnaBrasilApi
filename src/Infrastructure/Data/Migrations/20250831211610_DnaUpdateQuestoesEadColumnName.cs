using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateQuestoesEadColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoAlternativa",
                table: "RespostasEad");

            migrationBuilder.RenameColumn(
                name: "Questao",
                table: "QuestoesEad",
                newName: "NumeroQuestao");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "RespostasEad",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<bool>(
                name: "RespostaCerta",
                table: "RespostasEad",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaCerta",
                table: "RespostasEad");

            migrationBuilder.RenameColumn(
                name: "NumeroQuestao",
                table: "QuestoesEad",
                newName: "Questao");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "RespostasEad",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<string>(
                name: "TipoAlternativa",
                table: "RespostasEad",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }
    }
}
