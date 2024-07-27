using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteMatriculaAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Alunos_MatriculaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtVencimentoParq = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencimentoAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.CreateTable(
                name: "MatriculasOld",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CpfResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtVencimentoAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencimentoParq = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculasOld", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatriculasOld_Alunos_Id",
                        column: x => x.Id,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                });
        }
    }
}
