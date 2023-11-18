using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateAlunoComplementos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoComplementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doencas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Naturalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeEscola = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Turma = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TermoCompromisso = table.Column<bool>(type: "bit", nullable: false),
                    AutUsoDeImagem = table.Column<bool>(type: "bit", nullable: false),
                    AutCapitacaoEUsoDeIndicadoresDeSaude = table.Column<bool>(type: "bit", nullable: false),
                    AutSaida = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoComplementos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoComplementos");
        }
    }
}
