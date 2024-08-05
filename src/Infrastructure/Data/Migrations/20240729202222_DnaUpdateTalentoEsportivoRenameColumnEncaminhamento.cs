using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTalentoEsportivoRenameColumnEncaminhamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Encaminhamento",
                table: "TalentosEsportivos",
                newName: "EncaminhamentoTexo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncaminhamentoTexo",
                table: "TalentosEsportivos",
                newName: "Encaminhamento");
        }
    }
}
