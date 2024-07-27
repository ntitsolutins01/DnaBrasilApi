using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteAlunosLaudos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosLaudos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_AlunoId",
                table: "Laudos",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Alunos_AlunoId",
                table: "Laudos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Alunos_AlunoId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_AlunoId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Laudos");

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
    }
}
