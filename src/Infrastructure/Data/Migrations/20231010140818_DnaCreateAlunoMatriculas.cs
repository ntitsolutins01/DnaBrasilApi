using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateAlunoMatriculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoMatriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtVencPARQ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomePrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoPrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CpfPrimResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CpfSegResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ParentescoTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CpfTerResponsavel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoMatriculas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoMatriculas");
        }
    }
}
