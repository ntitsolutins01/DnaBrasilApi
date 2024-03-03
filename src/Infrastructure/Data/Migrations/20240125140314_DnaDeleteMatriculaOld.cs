using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteMatriculaOld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Matriculas_Alunos_Id",
            //    table: "Alunos");

            //migrationBuilder.DropTable(
            //    name: "Matriculas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quadrado",
                table: "TalentosEsportivos",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Peso",
                table: "TalentosEsportivos",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Imc",
                table: "TalentosEsportivos",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Altura",
                table: "TalentosEsportivos",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "MatriculasOld",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        DtVencimentoParq = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DtVencimentoAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        NomeResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ParentescoResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CpfResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NomeResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ParentescoResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CpfResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NomeResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ParentescoResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CpfResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
            //        LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MatriculasOld", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MatriculasOld_Alunos_Id",
            //            column: x => x.Id,
            //            principalTable: "Alunos",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatriculasOld");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quadrado",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Peso",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Imc",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Altura",
                table: "TalentosEsportivos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CpfResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtVencimentoAtestadoMedico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtVencimentoParq = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentescoResponsavel3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_Id",
                        column: x => x.Id,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
