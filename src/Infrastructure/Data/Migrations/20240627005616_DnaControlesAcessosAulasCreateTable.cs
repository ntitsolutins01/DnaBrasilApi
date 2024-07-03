using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaControlesAcessosAulasCreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlesAcessosAulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    IdentificacaoAluno = table.Column<bool>(type: "bit", nullable: false),
                    AulaRequisito = table.Column<bool>(type: "bit", nullable: false),
                    PermanenciaAula = table.Column<bool>(type: "bit", nullable: false),
                    TempoPermanecia = table.Column<TimeSpan>(type: "time", nullable: true),
                    LiberacaoAula = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataLiberacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEncerramento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesAcessosAulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesAcessosAulas_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlesAcessosAulas_AulaId",
                table: "ControlesAcessosAulas",
                column: "AulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlesAcessosAulas");
        }
    }
}
