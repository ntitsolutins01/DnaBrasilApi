using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoColunaByteImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadeId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "ByteImage",
                table: "Alunos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFoto",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ByteImage",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NomeFoto",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "LocalidadeId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Alunos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
