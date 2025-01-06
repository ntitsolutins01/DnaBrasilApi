using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateFomentoLinhasAcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "FomentoLinhasAcoes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FomentoLinhasAcoes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FomentoLinhasAcoes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "FomentoLinhasAcoes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FomentoLinhasAcoes");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FomentoLinhasAcoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FomentoLinhasAcoes");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "FomentoLinhasAcoes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FomentoLinhasAcoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FomentoLinhasAcoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "FomentoLinhasAcoes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FomentoLinhasAcoes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
