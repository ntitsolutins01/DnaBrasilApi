using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Estados_EstadoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoVouchers_Locais_LocalId",
                table: "AlunoVouchers");

            migrationBuilder.DropTable(
                name: "SistemaSocioeconomico");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EstadoId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoVouchers",
                table: "AlunoVouchers");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Social",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "AlunoVouchers",
                newName: "Vouchers");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Alunos",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Alunos",
                newName: "Cep");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoVouchers_LocalId",
                table: "Vouchers",
                newName: "IX_Vouchers_LocalId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "NomePai",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMae",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Alunos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Alunos",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Alunos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RedeSocial",
                table: "Alunos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Alunos",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Alunos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoParceria = table.Column<int>(type: "int", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCnpj = table.Column<int>(type: "int", maxLength: 18, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parceiros_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parceiros_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_EstadoId",
                table: "Parceiros",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_MunicipioId",
                table: "Parceiros",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Locais_LocalId",
                table: "Vouchers",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Locais_LocalId",
                table: "Vouchers");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "RedeSocial",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "AlunoVouchers");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Alunos",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Alunos",
                newName: "CEP");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_LocalId",
                table: "AlunoVouchers",
                newName: "IX_AlunoVouchers_LocalId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "NomePai",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMae",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Alunos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Alunos",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoNumero",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Alunos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "Alunos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoVouchers",
                table: "AlunoVouchers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SistemaSocioeconomico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CpfCnpj = table.Column<int>(type: "int", maxLength: 18, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TipoParceria = table.Column<int>(type: "int", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaSocioeconomico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SistemaSocioeconomico_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SistemaSocioeconomico_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EstadoId",
                table: "Alunos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaSocioeconomico_EstadoId",
                table: "SistemaSocioeconomico",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaSocioeconomico_MunicipioId",
                table: "SistemaSocioeconomico",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Estados_EstadoId",
                table: "Alunos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoVouchers_Locais_LocalId",
                table: "AlunoVouchers",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
