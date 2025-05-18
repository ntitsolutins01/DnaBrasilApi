using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateUpdadeControleMaterialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Localidades_LocalidadeId",
                table: "Materiais");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_LocalidadeId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "QtdAdquirida",
                table: "Materiais");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Materiais",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    LocalidadeId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventarios_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventarios_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArquivosInventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    PathArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeArquivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivosInventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArquivosInventarios_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivosInventarios_InventarioId",
                table: "ArquivosInventarios",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_LocalidadeId",
                table: "Inventarios",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_MaterialId",
                table: "Inventarios",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivosInventarios");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Materiais",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Materiais",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtdAdquirida",
                table: "Materiais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_LocalidadeId",
                table: "Materiais",
                column: "LocalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Localidades_LocalidadeId",
                table: "Materiais",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }
    }
}
