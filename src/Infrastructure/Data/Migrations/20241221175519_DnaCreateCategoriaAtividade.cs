using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateCategoriaAtividade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdadeInicial = table.Column<int>(type: "int", nullable: false),
                    IdadeFinal = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstruturaId = table.Column<int>(type: "int", nullable: false),
                    LinhaAcaoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false),
                    Turma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HrInicial = table.Column<TimeSpan>(type: "time", nullable: true),
                    HrFinal = table.Column<TimeSpan>(type: "time", nullable: true),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    LocalidadeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_Estruturas_EstruturaId",
                        column: x => x.EstruturaId,
                        principalTable: "Estruturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_LinhasAcoes_LinhaAcaoId",
                        column: x => x.LinhaAcaoId,
                        principalTable: "LinhasAcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_CategoriaId",
                table: "Atividades",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_EstruturaId",
                table: "Atividades",
                column: "EstruturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_LinhaAcaoId",
                table: "Atividades",
                column: "LinhaAcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_LocalidadeId",
                table: "Atividades",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ModalidadeId",
                table: "Atividades",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ProfissionalId",
                table: "Atividades",
                column: "ProfissionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
