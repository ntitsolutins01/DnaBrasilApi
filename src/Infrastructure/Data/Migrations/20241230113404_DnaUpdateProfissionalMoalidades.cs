using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateProfissionalMoalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProfissionalModalidades",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "ProfissionalModalidades",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProfissionalModalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "ProfissionalModalidades",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ProfissionalModalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfissionalModalidades",
                table: "ProfissionalModalidades",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfissionalModalidades",
                table: "ProfissionalModalidades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfissionalModalidades");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ProfissionalModalidades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProfissionalModalidades");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ProfissionalModalidades");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ProfissionalModalidades");
        }
    }
}
