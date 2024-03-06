using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateTextoLaudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPesoResposta",
                table: "Respostas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "TextosLaudos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLaudoId = table.Column<int>(type: "int", nullable: true),
                    Classificacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PontoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aviso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextosLaudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextosLaudos_TipoLaudos_TipoLaudoId",
                        column: x => x.TipoLaudoId,
                        principalTable: "TipoLaudos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextosLaudos_TipoLaudoId",
                table: "TextosLaudos",
                column: "TipoLaudoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextosLaudos");

            migrationBuilder.AlterColumn<int>(
                name: "ValorPesoResposta",
                table: "Respostas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
