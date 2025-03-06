using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaNewCollumnFomento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Cursos_CursoId",
                table: "Certificados");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Certificados",
                newName: "FomentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificados_CursoId",
                table: "Certificados",
                newName: "IX_Certificados_FomentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Fomentos_FomentoId",
                table: "Certificados",
                column: "FomentoId",
                principalTable: "Fomentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificados_Fomentos_FomentoId",
                table: "Certificados");

            migrationBuilder.RenameColumn(
                name: "FomentoId",
                table: "Certificados",
                newName: "CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificados_FomentoId",
                table: "Certificados",
                newName: "IX_Certificados_CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificados_Cursos_CursoId",
                table: "Certificados",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
