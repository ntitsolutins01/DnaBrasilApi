using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTalentosEsportivosColunasNovas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quadrado",
                table: "TalentosEsportivos",
                newName: "ShuttleRun");

            migrationBuilder.RenameColumn(
                name: "AptidaoFisica",
                table: "TalentosEsportivos",
                newName: "Vo2Max");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vo2Max",
                table: "TalentosEsportivos",
                newName: "AptidaoFisica");

            migrationBuilder.RenameColumn(
                name: "ShuttleRun",
                table: "TalentosEsportivos",
                newName: "Quadrado");
        }
    }
}
