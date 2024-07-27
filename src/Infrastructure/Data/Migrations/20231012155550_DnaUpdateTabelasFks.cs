using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTabelasFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoMatriculas");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locais_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtVencimentoParq = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencimentoAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeResponsavel1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentescoResponsavel1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CpfResponsavel1 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NomeResponsavel2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentescoResponsavel2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CpfResponsavel2 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    NomeResponsavel3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentescoResponsavel3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CpfResponsavel3 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locais_MunicipioId",
                table: "Locais",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_LocalId",
                table: "Matriculas",
                column: "LocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.CreateTable(
                name: "AlunoMatriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CpfPrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CpfSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CpfTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtVencAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencPARQ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomePrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoPrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoMatriculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_MunicipioId",
                table: "Localidades",
                column: "MunicipioId");
        }
    }
}
