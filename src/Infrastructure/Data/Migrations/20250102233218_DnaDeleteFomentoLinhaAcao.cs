using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteFomentoLinhaAcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FomentosLinhasAcoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FomentosLinhasAcoes",
                columns: table => new
                {
                    FomentoId = table.Column<int>(type: "int", nullable: false),
                    LinhaAcaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FomentosLinhasAcoes", x => new { x.FomentoId, x.LinhaAcaoId });
                    table.ForeignKey(
                        name: "FK_FomentosLinhasAcoes_Fomentos_FomentoId",
                        column: x => x.FomentoId,
                        principalTable: "Fomentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FomentosLinhasAcoes_LinhasAcoes_LinhaAcaoId",
                        column: x => x.LinhaAcaoId,
                        principalTable: "LinhasAcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FomentosLinhasAcoes_LinhaAcaoId",
                table: "FomentosLinhasAcoes",
                column: "LinhaAcaoId");
        }
    }
}
