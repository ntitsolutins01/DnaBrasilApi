using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateSistemaSocioeconomico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SistemaSocioeconomico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipoParceria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaSocioeconomico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SistemaSocioeconomico_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemaSocioeconomico_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SistemaSocioeconomico_EstadoId",
                table: "SistemaSocioeconomico",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaSocioeconomico_MunicipioId",
                table: "SistemaSocioeconomico",
                column: "MunicipioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SistemaSocioeconomico");
        }
    }
}
