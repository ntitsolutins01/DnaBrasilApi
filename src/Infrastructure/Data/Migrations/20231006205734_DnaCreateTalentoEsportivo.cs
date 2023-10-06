using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateTalentoEsportivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TalentoEsportivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    Flexibilidade = table.Column<int>(type: "int", nullable: false),
                    PreensaoManual = table.Column<int>(type: "int", nullable: false),
                    Velocidade = table.Column<int>(type: "int", nullable: false),
                    ImpulsaoHorizontal = table.Column<int>(type: "int", nullable: false),
                    AptidaoFisica = table.Column<int>(type: "int", nullable: false),
                    Agilidade = table.Column<int>(type: "int", nullable: false),
                    Abdominal = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentoEsportivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentoEsportivo_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentoEsportivo_ProfissionalId",
                table: "TalentoEsportivo",
                column: "ProfissionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalentoEsportivo");
        }
    }
}
