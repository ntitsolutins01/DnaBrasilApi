using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateDadosAlunoRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadeId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Etnia",
                table: "Alunos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadeId",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Etnia",
                table: "Alunos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Localidades_LocalidadeId",
                table: "Alunos",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");
        }
    }
}
