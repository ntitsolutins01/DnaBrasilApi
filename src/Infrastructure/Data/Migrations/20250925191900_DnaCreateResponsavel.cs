using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateResponsavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeResponsavel",
                table: "Alunos");

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrauParentescoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsaveis_GrauParentescos_GrauParentescoId",
                        column: x => x.GrauParentescoId,
                        principalTable: "GrauParentescos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_GrauParentescoId",
                table: "Responsaveis",
                column: "GrauParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_Cpf",
                table: "Responsaveis",
                column: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.AddColumn<string>(
                name: "NomeResponsavel",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
