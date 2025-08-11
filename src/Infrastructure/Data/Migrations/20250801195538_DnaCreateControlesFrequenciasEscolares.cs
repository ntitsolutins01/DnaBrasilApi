using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateControlesFrequenciasEscolares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlesFrequenciasEscolares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Controle = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: true),
                    SerieId = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesFrequenciasEscolares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesFrequenciasEscolares_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlesFrequenciasEscolares_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlesFrequenciasEscolares_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlesFrequenciasEscolares_AlunoId",
                table: "ControlesFrequenciasEscolares",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlesFrequenciasEscolares_DisciplinaId",
                table: "ControlesFrequenciasEscolares",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlesFrequenciasEscolares_SerieId",
                table: "ControlesFrequenciasEscolares",
                column: "SerieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlesFrequenciasEscolares");
        }
    }
}
