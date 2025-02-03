using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateAtividadeAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadeAlunos",
                columns: table => new
                {
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeAlunos", x => new { x.AtividadeId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_AtividadeAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeAlunos_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeAlunos_AlunoId",
                table: "AtividadeAlunos",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeAlunos");
        }
    }
}
