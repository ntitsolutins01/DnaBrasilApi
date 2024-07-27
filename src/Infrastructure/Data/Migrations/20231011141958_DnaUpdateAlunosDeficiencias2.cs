using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunosDeficiencias2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDeficiencia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoDeficiencia",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    DeficienciasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDeficiencia", x => new { x.AlunosId, x.DeficienciasId });
                    table.ForeignKey(
                        name: "FK_AlunoDeficiencia_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDeficiencia_Deficiencias_DeficienciasId",
                        column: x => x.DeficienciasId,
                        principalTable: "Deficiencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDeficiencia_DeficienciasId",
                table: "AlunoDeficiencia",
                column: "DeficienciasId");
        }
    }
}
