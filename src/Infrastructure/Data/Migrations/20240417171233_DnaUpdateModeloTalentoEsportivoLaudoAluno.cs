using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateModeloTalentoEsportivoLaudoAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_TalentosEsportivos_TalentoEsportivoId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "ContratosAlunos");

            migrationBuilder.DropTable(
                name: "ContratosLocalidades");

            migrationBuilder.DropTable(
                name: "ContratosProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TalentoEsportivoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TalentoEsportivoId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "TalentosEsportivos",
                type: "int",
                nullable: true);

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
                name: "ContratoLocalidade",
                columns: table => new
                {
                    ContratosId = table.Column<int>(type: "int", nullable: false),
                    LocalidadesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoLocalidade", x => new { x.ContratosId, x.LocalidadesId });
                    table.ForeignKey(
                        name: "FK_ContratoLocalidade_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoLocalidade_Localidades_LocalidadesId",
                        column: x => x.LocalidadesId,
                        principalTable: "Localidades",
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
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoContrato_ContratosId",
                table: "AlunoContrato",
                column: "ContratosId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoLocalidade_LocalidadesId",
                table: "ContratoLocalidade",
                column: "LocalidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoProfissional_ProfissionaisId",
                table: "ContratoProfissional",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropTable(
                name: "AlunoContrato");

            migrationBuilder.DropTable(
                name: "ContratoLocalidade");

            migrationBuilder.DropTable(
                name: "ContratoProfissional");

            migrationBuilder.DropIndex(
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.AddColumn<int>(
                name: "TalentoEsportivoId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContratosAlunos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosAlunos", x => new { x.ContratoId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_ContratosAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosAlunos_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosLocalidades",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    LocalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosLocalidades", x => new { x.ContratoId, x.LocalidadeId });
                    table.ForeignKey(
                        name: "FK_ContratosLocalidades_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosLocalidades_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosProfissionais",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosProfissionais", x => new { x.ContratoId, x.ProfissionalId });
                    table.ForeignKey(
                        name: "FK_ContratosProfissionais_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosProfissionais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TalentoEsportivoId",
                table: "Alunos",
                column: "TalentoEsportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAlunos_AlunoId",
                table: "ContratosAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosLocalidades_LocalidadeId",
                table: "ContratosLocalidades",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosProfissionais_ProfissionalId",
                table: "ContratosProfissionais",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_TalentosEsportivos_TalentoEsportivoId",
                table: "Alunos",
                column: "TalentoEsportivoId",
                principalTable: "TalentosEsportivos",
                principalColumn: "Id");
        }
    }
}
