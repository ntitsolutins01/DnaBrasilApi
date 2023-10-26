using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Vocacionais");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "SaudeBucais");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ConsumoAlimentares");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "TalentosEsportivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Altura",
                table: "Saudes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Saudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Massa",
                table: "Saudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "SaudeBucais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "ConsumoAlimentares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Etnia",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DtIni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anexo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pergunta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    ConsumoAlimentarId = table.Column<int>(type: "int", nullable: true),
                    QualidadeDeVidaId = table.Column<int>(type: "int", nullable: true),
                    SaudeBucalId = table.Column<int>(type: "int", nullable: true),
                    VocacionalId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionarios_ConsumoAlimentares_ConsumoAlimentarId",
                        column: x => x.ConsumoAlimentarId,
                        principalTable: "ConsumoAlimentares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questionarios_QualidadeDeVidas_QualidadeDeVidaId",
                        column: x => x.QualidadeDeVidaId,
                        principalTable: "QualidadeDeVidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questionarios_SaudeBucais_SaudeBucalId",
                        column: x => x.SaudeBucalId,
                        principalTable: "SaudeBucais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questionarios_TipoLaudos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoLaudos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionarios_Vocacionais_VocacionalId",
                        column: x => x.VocacionalId,
                        principalTable: "Vocacionais",
                        principalColumn: "Id");
                });

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
                name: "ContratosLocais",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosLocais", x => new { x.ContratoId, x.LocalId });
                    table.ForeignKey(
                        name: "FK_ContratosLocais_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosLocais_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
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
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Saudes_AlunoId",
                table: "Saudes",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_SaudeBucais_AlunoId",
                table: "SaudeBucais",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_QualidadeDeVidas_AlunoId",
                table: "QualidadeDeVidas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoAlimentares_AlunoId",
                table: "ConsumoAlimentares",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAlunos_AlunoId",
                table: "ContratosAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosLocais_LocalId",
                table: "ContratosLocais",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosProfissionais_ProfissionalId",
                table: "ContratosProfissionais",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_ConsumoAlimentarId",
                table: "Questionarios",
                column: "ConsumoAlimentarId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_QualidadeDeVidaId",
                table: "Questionarios",
                column: "QualidadeDeVidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_SaudeBucalId",
                table: "Questionarios",
                column: "SaudeBucalId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_TipoId",
                table: "Questionarios",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_VocacionalId",
                table: "Questionarios",
                column: "VocacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Alunos_AlunoId",
                table: "Saudes",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Alunos_AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Alunos_AlunoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Alunos_AlunoId",
                table: "SaudeBucais");

            migrationBuilder.DropForeignKey(
                name: "FK_Saudes_Alunos_AlunoId",
                table: "Saudes");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropTable(
                name: "ContratosAlunos");

            migrationBuilder.DropTable(
                name: "ContratosLocais");

            migrationBuilder.DropTable(
                name: "ContratosProfissionais");

            migrationBuilder.DropTable(
                name: "Questionarios");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropIndex(
                name: "IX_Saudes_AlunoId",
                table: "Saudes");

            migrationBuilder.DropIndex(
                name: "IX_SaudeBucais_AlunoId",
                table: "SaudeBucais");

            migrationBuilder.DropIndex(
                name: "IX_QualidadeDeVidas_AlunoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropIndex(
                name: "IX_ConsumoAlimentares_AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Saudes");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Saudes");

            migrationBuilder.DropColumn(
                name: "Massa",
                table: "Saudes");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "SaudeBucais");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "ConsumoAlimentares");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Vocacionais",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "SaudeBucais",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ConsumoAlimentares",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Etnia",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
