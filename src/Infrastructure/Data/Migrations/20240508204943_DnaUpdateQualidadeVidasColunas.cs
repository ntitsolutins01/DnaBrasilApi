using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateQualidadeVidasColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Respostas_RespostaId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropIndex(
                name: "IX_QualidadeDeVidas_RespostaId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "RespostaId",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "StatusQualidadeDeVidas",
                table: "QualidadeDeVidas",
                newName: "StatusQualidadeDeVida");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "QualidadeDeVidas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "QualidadeDeVidas");

            migrationBuilder.RenameColumn(
                name: "StatusQualidadeDeVida",
                table: "QualidadeDeVidas",
                newName: "StatusQualidadeDeVidas");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RespostaId",
                table: "QualidadeDeVidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QualidadeDeVidas_RespostaId",
                table: "QualidadeDeVidas",
                column: "RespostaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Respostas_RespostaId",
                table: "QualidadeDeVidas",
                column: "RespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
