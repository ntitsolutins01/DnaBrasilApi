﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateFomentoLinhasAcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FomentoLinhasAcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FomentoId = table.Column<int>(type: "int", nullable: false),
                    LinhaAcaoId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FomentoLinhasAcoes", x => new { x.FomentoId, x.LinhaAcaoId });
                    table.ForeignKey(
                        name: "FK_FomentoLinhasAcoes_Fomentos_FomentoId",
                        column: x => x.FomentoId,
                        principalTable: "Fomentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FomentoLinhasAcoes_LinhasAcoes_LinhaAcaoId",
                        column: x => x.LinhaAcaoId,
                        principalTable: "LinhasAcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FomentoLinhasAcoes_LinhaAcaoId",
                table: "FomentoLinhasAcoes",
                column: "LinhaAcaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FomentoLinhasAcoes");
        }
    }
}