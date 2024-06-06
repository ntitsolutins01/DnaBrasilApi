using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoNovasColunas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutorizacaoConsentimentoAssentimento",
                table: "Alunos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutorizacaoSaida",
                table: "Alunos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CopiaDocAlunoResponsavel",
                table: "Alunos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ParticipacaoProgramaCompartilhamentoDados",
                table: "Alunos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UtilizacaoImagem",
                table: "Alunos",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorizacaoConsentimentoAssentimento",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AutorizacaoSaida",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CopiaDocAlunoResponsavel",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ParticipacaoProgramaCompartilhamentoDados",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "UtilizacaoImagem",
                table: "Alunos");
        }
    }
}
