using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateLocalToLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratosLocais_Locais_LocalId",
                table: "ContratosLocais");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Locais_LocalId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Locais_LocalId",
                table: "Vouchers");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.CreateTable(
                name: "Localidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidade_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidade_MunicipioId",
                table: "Localidade",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratosLocais_Localidade_LocalId",
                table: "ContratosLocais",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Localidade_LocalId",
                table: "Matriculas",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Localidade_LocalId",
                table: "Vouchers",
                column: "LocalId",
                principalTable: "Localidade",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContratosLocais_Localidade_LocalId",
                table: "ContratosLocais");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Localidade_LocalId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Localidade_LocalId",
                table: "Vouchers");

            migrationBuilder.DropTable(
                name: "Localidade");

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locais_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locais_MunicipioId",
                table: "Locais",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContratosLocais_Locais_LocalId",
                table: "ContratosLocais",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Locais_LocalId",
                table: "Matriculas",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Locais_LocalId",
                table: "Vouchers",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id");
        }
    }
}
