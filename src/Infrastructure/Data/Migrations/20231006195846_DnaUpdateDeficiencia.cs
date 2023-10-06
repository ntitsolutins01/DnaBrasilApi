using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateDeficiencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Deficiencias");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Deficiencias",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Deficiencias",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Deficiencias",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
