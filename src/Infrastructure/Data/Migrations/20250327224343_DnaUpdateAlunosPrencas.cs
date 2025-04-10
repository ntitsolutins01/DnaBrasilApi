using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunosPrencas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Presenca",
                table: "AlunosPresencas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Presenca",
                table: "AlunosPresencas",
                type: "int",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
