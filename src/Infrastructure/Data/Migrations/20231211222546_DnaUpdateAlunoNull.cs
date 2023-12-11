using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetUserId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtNascimento",
                table: "Alunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Etnia",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Alunos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "DtNascimento",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Etnia",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Alunos");
        }
    }
}
