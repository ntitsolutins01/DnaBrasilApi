using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaNovasColunasSTatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusVocacionais",
                table: "Vocacionais",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusTalentosEsportivos",
                table: "TalentosEsportivos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusSaude",
                table: "Saudes",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusSaudeBucais",
                table: "SaudeBucais",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusQualidadeDeVidas",
                table: "QualidadeDeVidas",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusConsumoAlimentares",
                table: "ConsumoAlimentares",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusVocacionais",
                table: "Vocacionais");

            migrationBuilder.DropColumn(
                name: "StatusTalentosEsportivos",
                table: "TalentosEsportivos");

            migrationBuilder.DropColumn(
                name: "StatusSaudeBucais",
                table: "SaudeBucais");

            migrationBuilder.DropColumn(
                name: "StatusQualidadeDeVidas",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "StatusConsumoAlimentares",
                table: "ConsumoAlimentares");

            migrationBuilder.AlterColumn<string>(
                name: "StatusSaude",
                table: "Saudes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
