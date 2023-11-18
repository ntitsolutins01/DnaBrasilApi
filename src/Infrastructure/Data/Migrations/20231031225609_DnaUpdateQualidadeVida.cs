using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateQualidadeVida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "QualidadeDeVidas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "QualidadeDeVidas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "QualidadeDeVidaId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VocacionalId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_QualidadeDeVidaId",
                table: "Laudos",
                column: "QualidadeDeVidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_VocacionalId",
                table: "Laudos",
                column: "VocacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_QualidadeDeVidas_QualidadeDeVidaId",
                table: "Laudos",
                column: "QualidadeDeVidaId",
                principalTable: "QualidadeDeVidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Vocacionais_VocacionalId",
                table: "Laudos",
                column: "VocacionalId",
                principalTable: "Vocacionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_QualidadeDeVidas_QualidadeDeVidaId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Vocacionais_VocacionalId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_QualidadeDeVidaId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_VocacionalId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "QualidadeDeVidaId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "VocacionalId",
                table: "Laudos");

            migrationBuilder.AlterColumn<string>(
                name: "Resposta",
                table: "QualidadeDeVidas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "QualidadeDeVidas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
