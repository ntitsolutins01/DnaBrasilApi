using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateSistemaSocioeconomico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "SistemaSocioeconomico");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "SistemaSocioeconomico");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "SistemaSocioeconomico");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "SistemaSocioeconomico");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPessoa",
                table: "SistemaSocioeconomico",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoParceria",
                table: "SistemaSocioeconomico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "SistemaSocioeconomico",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "SistemaSocioeconomico",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SistemaSocioeconomico",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "SistemaSocioeconomico",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "SistemaSocioeconomico",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "CpfCnpj",
                table: "SistemaSocioeconomico",
                type: "int",
                maxLength: 18,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCnpj",
                table: "SistemaSocioeconomico");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SistemaSocioeconomico");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPessoa",
                table: "SistemaSocioeconomico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TipoParceria",
                table: "SistemaSocioeconomico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "SistemaSocioeconomico",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "SistemaSocioeconomico",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "SistemaSocioeconomico",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "SistemaSocioeconomico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "SistemaSocioeconomico",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoNumero",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "SistemaSocioeconomico",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
