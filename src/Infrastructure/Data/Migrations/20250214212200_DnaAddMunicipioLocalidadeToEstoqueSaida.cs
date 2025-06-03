using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaAddMunicipioLocalidadeToEstoqueSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlesMensaisEstoque");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Localidades_LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Municipios_MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Localidades_LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlesMateriaisEstoquesSaidas_Municipios_MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropIndex(
                name: "IX_ControlesMateriaisEstoquesSaidas_MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.CreateTable(
                name: "ControlesMensaisEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDanificadosExtraviados = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataMesSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JustificativaDanificadosExtraviados = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdMateriaisDanificadosExtraviados = table.Column<int>(type: "int", nullable: true),
                    QtdPrevista = table.Column<int>(type: "int", nullable: true),
                    TotalEstoque = table.Column<int>(type: "int", nullable: true),
                    TotalSaidas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesMensaisEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesMensaisEstoque_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMensaisEstoque_MaterialId",
                table: "ControlesMensaisEstoque",
                column: "MaterialId");
        }
    }
}
