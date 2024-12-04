using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Localidades_Contratos_ContratoId",
            //    table: "Localidades");

            migrationBuilder.DropTable(
                name: "AlunoContrato");

            migrationBuilder.DropTable(
                name: "ContratoProfissional");

            migrationBuilder.DropTable(
                name: "Contratos");

            //migrationBuilder.DropIndex(
            //    name: "IX_Localidades_ContratoId",
            //    table: "Localidades");

            //migrationBuilder.DropColumn(
            //    name: "ContratoId",
            //    table: "Localidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContratoId",
                table: "Localidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anexo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DtFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtIni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoContrato",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    ContratosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoContrato", x => new { x.AlunosId, x.ContratosId });
                    table.ForeignKey(
                        name: "FK_AlunoContrato_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoContrato_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoProfissional",
                columns: table => new
                {
                    ContratosId = table.Column<int>(type: "int", nullable: false),
                    ProfissionaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoProfissional", x => new { x.ContratosId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_ContratoProfissional_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoProfissional_Profissionais_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ContratoId",
                table: "Localidades",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoContrato_ContratosId",
                table: "AlunoContrato",
                column: "ContratosId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoProfissional_ProfissionaisId",
                table: "ContratoProfissional",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Contratos_ContratoId",
                table: "Localidades",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "Id");
        }
    }
}
