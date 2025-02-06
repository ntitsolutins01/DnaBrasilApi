using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateEstadoMunicipioCodigoIbge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Municipios",
                newName: "CodigoIbge");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Estados",
                newName: "CodigoIbge");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoIbge",
                table: "Municipios",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "CodigoIbge",
                table: "Estados",
                newName: "Codigo");
        }
    }
}
