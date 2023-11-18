using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateDependencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoComplementos");

            migrationBuilder.CreateTable(
                name: "Dependencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    Doencas = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Naturalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NomeEscola = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TipoEscola = table.Column<int>(type: "int", nullable: false),
                    TipoEscolaridade = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Dependencias_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependencias");

            migrationBuilder.CreateTable(
                name: "AlunoComplementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AutCapitacaoEUsoDeIndicadoresDeSaude = table.Column<bool>(type: "bit", nullable: false),
                    AutSaida = table.Column<bool>(type: "bit", nullable: false),
                    AutUsoDeImagem = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doencas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Naturalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeEscola = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TermoCompromisso = table.Column<bool>(type: "bit", nullable: false),
                    Turma = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoComplementos", x => x.Id);
                });
        }
    }
}
