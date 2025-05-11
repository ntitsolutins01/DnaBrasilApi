using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaRemoveCertificadoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCursosCertificados_Certificados_CertificadoId",
                table: "AlunoCursosCertificados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoCursosCertificados",
                table: "AlunoCursosCertificados");

            migrationBuilder.AlterColumn<int>(
                name: "CertificadoId",
                table: "AlunoCursosCertificados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoCursosCertificados",
                table: "AlunoCursosCertificados",
                columns: new[] { "AlunoId", "CursoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCursosCertificados_Certificados_CertificadoId",
                table: "AlunoCursosCertificados",
                column: "CertificadoId",
                principalTable: "Certificados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCursosCertificados_Certificados_CertificadoId",
                table: "AlunoCursosCertificados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoCursosCertificados",
                table: "AlunoCursosCertificados");

            migrationBuilder.AlterColumn<int>(
                name: "CertificadoId",
                table: "AlunoCursosCertificados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoCursosCertificados",
                table: "AlunoCursosCertificados",
                columns: new[] { "AlunoId", "CursoId", "CertificadoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCursosCertificados_Certificados_CertificadoId",
                table: "AlunoCursosCertificados",
                column: "CertificadoId",
                principalTable: "Certificados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
