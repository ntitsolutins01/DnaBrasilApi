using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateDependenciaTalentoNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Dependencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doencas = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Naturalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NomeEscola = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TipoEscola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoEscolaridade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Turno = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ano = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Turma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TermoCompromisso = table.Column<bool>(type: "bit", nullable: true),
                    AutorizacaoUsoImagemAudio = table.Column<bool>(type: "bit", nullable: true),
                    AutorizacaoUsoIndicadores = table.Column<bool>(type: "bit", nullable: true),
                    AutorizacaoSaida = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependencias_Alunos_Id",
                        column: x => x.Id,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                });


            migrationBuilder.CreateTable(
                name: "TalentosEsportivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    Flexibilidade = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    PreensaoManual = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Velocidade = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    ImpulsaoHorizontal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    AptidaoFisica = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Abdominal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Imc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quadrado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Encaminhamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentosEsportivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentosEsportivos_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentosEsportivos_ProfissionalId",
                table: "TalentosEsportivos",
                column: "ProfissionalId");


            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_TalentosEsportivos_TalentoEsportivoId",
                table: "Laudos",
                column: "TalentoEsportivoId",
                principalTable: "TalentosEsportivos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependencias_Alunos_Id",
                table: "Dependencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_TalentosEsportivos_TalentoEsportivoId",
                table: "Laudos");

            migrationBuilder.DropTable(
                name: "TalentosEsportivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependencias",
                table: "Dependencias");

            migrationBuilder.RenameTable(
                name: "Dependencias",
                newName: "DependenciasOld");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DependenciasOld",
                table: "DependenciasOld",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TalentosEsportivosOld",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    Abdominal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AptidaoFisica = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Encaminhamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flexibilidade = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Imc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImpulsaoHorizontal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PreensaoManual = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Quadrado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Velocidade = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentosEsportivosOld", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentosEsportivosOld_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentosEsportivosOld_ProfissionalId",
                table: "TalentosEsportivosOld",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DependenciasOld_Alunos_Id",
                table: "DependenciasOld",
                column: "Id",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_TalentosEsportivosOld_TalentoEsportivoId",
                table: "Laudos",
                column: "TalentoEsportivoId",
                principalTable: "TalentosEsportivosOld",
                principalColumn: "Id");
        }
    }
}
