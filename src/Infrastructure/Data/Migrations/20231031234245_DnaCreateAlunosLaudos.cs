using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateAlunosLaudos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunosLaudos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    LaudoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosLaudos", x => new { x.AlunoId, x.LaudoId });
                    table.ForeignKey(
                        name: "FK_AlunosLaudos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosLaudos_Laudos_LaudoId",
                        column: x => x.LaudoId,
                        principalTable: "Laudos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosLaudos_LaudoId",
                table: "AlunosLaudos",
                column: "LaudoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosLaudos");
        }
    }
}
