using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaQuestoesRespostasEadCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestoesEad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Questao = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestoesEad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RespostasEad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestaoId = table.Column<int>(type: "int", nullable: false),
                    TipoResposta = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TipoAlternativa = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Resposta = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ValorPesoResposta = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasEad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasEad_QuestoesEad_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "QuestoesEad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostasEad_QuestaoId",
                table: "RespostasEad",
                column: "QuestaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasEad");

            migrationBuilder.DropTable(
                name: "QuestoesEad");
        }
    }
}
