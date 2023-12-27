using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTalento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agilidade",
                table: "TalentosEsportivos");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Profissionais",
                newName: "CpfCnpj");

            migrationBuilder.AlterColumn<string>(
                name: "Encaminhamento",
                table: "TalentosEsportivos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpfCnpj",
                table: "Profissionais",
                newName: "Cpf");

            migrationBuilder.AlterColumn<decimal>(
                name: "Encaminhamento",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Agilidade",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
