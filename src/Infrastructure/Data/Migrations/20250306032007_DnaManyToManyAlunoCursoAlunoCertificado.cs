using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaManyToManyAlunoCursoAlunoCertificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosCursos",
                table: "AlunosCursos");

            migrationBuilder.DropIndex(
                name: "IX_AlunosCursos_AlunoId",
                table: "AlunosCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosCertificados",
                table: "AlunosCertificados");

            migrationBuilder.DropIndex(
                name: "IX_AlunosCertificados_AlunoId",
                table: "AlunosCertificados");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunosCursos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AlunosCursos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AlunosCursos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AlunosCursos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AlunosCursos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunosCertificados");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AlunosCertificados");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AlunosCertificados");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AlunosCertificados");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AlunosCertificados");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosCursos",
                table: "AlunosCursos",
                columns: new[] { "AlunoId", "CursoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosCertificados",
                table: "AlunosCertificados",
                columns: new[] { "AlunoId", "CertificadoId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosCursos",
                table: "AlunosCursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunosCertificados",
                table: "AlunosCertificados");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AlunosCursos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AlunosCursos",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AlunosCursos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "AlunosCursos",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AlunosCursos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AlunosCertificados",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "AlunosCertificados",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AlunosCertificados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "AlunosCertificados",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AlunosCertificados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosCursos",
                table: "AlunosCursos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunosCertificados",
                table: "AlunosCertificados",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_AlunoId",
                table: "AlunosCursos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCertificados_AlunoId",
                table: "AlunosCertificados",
                column: "AlunoId");
        }
    }
}
