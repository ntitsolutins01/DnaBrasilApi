using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDropAlunosCertificados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCertificados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunosCertificados",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CertificadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCertificados", x => new { x.AlunoId, x.CertificadoId });
                    table.ForeignKey(
                        name: "FK_AlunosCertificados_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCertificados_Certificados_CertificadoId",
                        column: x => x.CertificadoId,
                        principalTable: "Certificados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCertificados_CertificadoId",
                table: "AlunosCertificados",
                column: "CertificadoId");
        }
    }
}
