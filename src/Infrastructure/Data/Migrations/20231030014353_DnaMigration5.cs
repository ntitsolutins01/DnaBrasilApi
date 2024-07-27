using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Dependencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Alunos",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_MatriculaId",
                table: "Alunos",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_VoucherId",
                table: "Alunos",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Vouchers_VoucherId",
                table: "Alunos",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Matriculas_MatriculaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Vouchers_VoucherId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Dependencias_Alunos_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropIndex(
                name: "IX_Dependencias_AlunoId",
                table: "Dependencias");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_MatriculaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_VoucherId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Dependencias");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "Alunos");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Alunos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);
        }
    }
}
