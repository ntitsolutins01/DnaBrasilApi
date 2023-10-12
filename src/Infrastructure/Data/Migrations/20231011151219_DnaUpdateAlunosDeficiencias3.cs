using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunosDeficiencias3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Dependencias");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosDeficiencias");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Dependencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
