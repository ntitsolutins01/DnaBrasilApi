using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTabelasFks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoAmbientes");

            migrationBuilder.DropColumn(
                name: "Voucher",
                table: "AlunoVouchers");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "AlunoVouchers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "AlunoVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "AlunoVouchers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Turma",
                table: "AlunoVouchers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlunosAmbientes",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AmbienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosAmbientes", x => new { x.AlunoId, x.AmbienteId });
                    table.ForeignKey(
                        name: "FK_AlunosAmbientes_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosAmbientes_Ambientes_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "Ambientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoVouchers_LocalId",
                table: "AlunoVouchers",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosAmbientes_AmbienteId",
                table: "AlunosAmbientes",
                column: "AmbienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoVouchers_Locais_LocalId",
                table: "AlunoVouchers",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoVouchers_Locais_LocalId",
                table: "AlunoVouchers");

            migrationBuilder.DropTable(
                name: "AlunosAmbientes");

            migrationBuilder.DropIndex(
                name: "IX_AlunoVouchers_LocalId",
                table: "AlunoVouchers");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "AlunoVouchers");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "AlunoVouchers");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "AlunoVouchers");

            migrationBuilder.DropColumn(
                name: "Turma",
                table: "AlunoVouchers");

            migrationBuilder.AddColumn<string>(
                name: "Voucher",
                table: "AlunoVouchers",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlunoAmbientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ambiente = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoAmbientes", x => x.Id);
                });
        }
    }
}
