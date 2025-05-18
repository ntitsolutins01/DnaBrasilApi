using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateIdebDimensaoEstadual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdebDimensaoEstadual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtapaEnsinoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Media = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdebDimensaoEstadual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdebDimensaoEstadual_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdebDimensaoEstadual_EtapasEnsino_EtapaEnsinoId",
                        column: x => x.EtapaEnsinoId,
                        principalTable: "EtapasEnsino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdebDimensaoEstadual_EstadoId",
                table: "IdebDimensaoEstadual",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_IdebDimensaoEstadual_EtapaEnsinoId",
                table: "IdebDimensaoEstadual",
                column: "EtapaEnsinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdebDimensaoEstadual");
        }
    }
}
