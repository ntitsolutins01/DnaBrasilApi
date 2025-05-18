using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateIdebDimensaoNacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdebDimensoesNacional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtapaEnsinoId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Media = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdebDimensoesNacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdebDimensoesNacional_EtapasEnsino_EtapaEnsinoId",
                        column: x => x.EtapaEnsinoId,
                        principalTable: "EtapasEnsino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdebDimensoesNacional_EtapaEnsinoId",
                table: "IdebDimensoesNacional",
                column: "EtapaEnsinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdebDimensoesNacional");
        }
    }
}
