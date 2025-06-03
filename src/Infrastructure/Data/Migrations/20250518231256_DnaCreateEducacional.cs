using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateEducacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educacionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    Pdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respostas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EncaminhamentoId = table.Column<int>(type: "int", nullable: true),
                    StatusEducacional = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educacionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educacionais_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Educacionais_Encaminhamentos_EncaminhamentoId",
                        column: x => x.EncaminhamentoId,
                        principalTable: "Encaminhamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Educacionais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Educacionais_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educacionais_AlunoId",
                table: "Educacionais",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacionais_EncaminhamentoId",
                table: "Educacionais",
                column: "EncaminhamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacionais_ProfissionalId",
                table: "Educacionais",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacionais_SerieId",
                table: "Educacionais",
                column: "SerieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educacionais");
        }
    }
}
