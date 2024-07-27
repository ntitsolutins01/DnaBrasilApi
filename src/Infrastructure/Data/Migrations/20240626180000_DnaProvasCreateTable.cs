using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaProvasCreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvaRequisito = table.Column<bool>(type: "bit", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    MediaAprovacao = table.Column<int>(type: "int", nullable: false),
                    LiberacaoProva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLiberacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoProva = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PermitirTentativas = table.Column<bool>(type: "bit", nullable: false),
                    Tentativas = table.Column<int>(type: "int", nullable: false),
                    LiberarTentativa = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provas_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provas_AulaId",
                table: "Provas",
                column: "AulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provas");
        }
    }
}
