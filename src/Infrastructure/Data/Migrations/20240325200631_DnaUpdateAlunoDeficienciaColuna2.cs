using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoDeficienciaColuna2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosDeficiencias");

            migrationBuilder.AddColumn<int>(
                name: "DeficienciaId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DeficienciaId",
                table: "Alunos",
                column: "DeficienciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Deficiencias_DeficienciaId",
                table: "Alunos",
                column: "DeficienciaId",
                principalTable: "Deficiencias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Deficiencias_DeficienciaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_DeficienciaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DeficienciaId",
                table: "Alunos");

            migrationBuilder.CreateTable(
                name: "AlunosDeficiencias",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DeficienciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDeficiencias", x => new { x.AlunoId, x.DeficienciaId });
                    table.ForeignKey(
                        name: "FK_AlunosDeficiencias_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDeficiencias_Deficiencias_DeficienciaId",
                        column: x => x.DeficienciaId,
                        principalTable: "Deficiencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDeficiencias_DeficienciaId",
                table: "AlunosDeficiencias",
                column: "DeficienciaId");
        }
    }
}
