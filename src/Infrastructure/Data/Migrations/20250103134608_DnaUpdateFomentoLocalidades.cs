using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateFomentoLocalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "FomentoLocalidades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FomentoLocalidades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FomentoLocalidades");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "FomentoLocalidades");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FomentoLocalidades");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FomentoLocalidades",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "FomentoLocalidades");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "FomentoLocalidades",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FomentoLocalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FomentoLocalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "FomentoLocalidades",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FomentoLocalidades",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
