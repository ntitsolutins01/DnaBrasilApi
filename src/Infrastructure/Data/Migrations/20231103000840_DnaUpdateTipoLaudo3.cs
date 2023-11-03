using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTipoLaudo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdadeFinal",
                table: "TipoLaudos");

            migrationBuilder.DropColumn(
                name: "IdadeInicial",
                table: "TipoLaudos");

            migrationBuilder.DropColumn(
                name: "ScoreTotal",
                table: "TipoLaudos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TipoLaudos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdadeFinal",
                table: "TipoLaudos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "IdadeInicial",
                table: "TipoLaudos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "ScoreTotal",
                table: "TipoLaudos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TipoLaudos",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 6);
        }
    }
}
