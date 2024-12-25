using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateGruposMateriais_TiposMateriais_Materiais_ControlesMensaisEstoque_ControlesMateriaisEstoquesSaidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposMateriais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMateriais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposMateriais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoMaterialId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMateriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposMateriais_GruposMateriais_GrupoMaterialId",
                        column: x => x.GrupoMaterialId,
                        principalTable: "GruposMateriais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMaterialId = table.Column<int>(type: "int", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdAdquirida = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiais_TiposMateriais_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalTable: "TiposMateriais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlesMateriaisEstoquesSaidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesMateriaisEstoquesSaidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesMateriaisEstoquesSaidas_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlesMensaisEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    QtdPrevista = table.Column<int>(type: "int", nullable: true),
                    DataMesSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalSaidas = table.Column<int>(type: "int", nullable: true),
                    TotalEstoque = table.Column<int>(type: "int", nullable: true),
                    QtdMateriaisDanificadosExtraviados = table.Column<int>(type: "int", nullable: true),
                    JustificativaDanificadosExtraviados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDanificadosExtraviados = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_ControlesMateriaisEstoquesSaidas_MaterialId",
                table: "ControlesMateriaisEstoquesSaidas",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMensaisEstoque_MaterialId",
                table: "ControlesMensaisEstoque",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_TipoMaterialId",
                table: "Materiais",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposMateriais_GrupoMaterialId",
                table: "TiposMateriais",
                column: "GrupoMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlesMateriaisEstoquesSaidas");

            migrationBuilder.DropTable(
                name: "ControlesMensaisEstoque");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "TiposMateriais");

            migrationBuilder.DropTable(
                name: "GruposMateriais");
        }
    }
}
