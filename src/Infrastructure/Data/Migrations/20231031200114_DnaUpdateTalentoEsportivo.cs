using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateTalentoEsportivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Alunos_Matriculas_MatriculaId",
            //    table: "Alunos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Alunos_Vouchers_VoucherId",
            //    table: "Alunos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Dependencias_Alunos_AlunoId",
            //    table: "Dependencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos");

            migrationBuilder.DropIndex(
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos");

            //migrationBuilder.DropIndex(
            //    name: "IX_Dependencias_AlunoId",
            //    table: "Dependencias");

            //migrationBuilder.DropIndex(
            //    name: "IX_Alunos_MatriculaId",
            //    table: "Alunos");

            //migrationBuilder.DropIndex(
            //    name: "IX_Alunos_VoucherId",
            //    table: "Alunos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "TalentosEsportivos");

            //migrationBuilder.DropColumn(
            //    name: "AlunoId",
            //    table: "Dependencias");

            //migrationBuilder.DropColumn(
            //    name: "MatriculaId",
            //    table: "Alunos");

            //migrationBuilder.DropColumn(
            //    name: "VoucherId",
            //    table: "Alunos");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Vouchers",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Matriculas",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Dependencias",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dependencias_Alunos_Id",
            //    table: "Dependencias",
            //    column: "Id",
            //    principalTable: "Alunos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Matriculas_Alunos_Id",
            //    table: "Matriculas",
            //    column: "Id",
            //    principalTable: "Alunos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Vouchers_Alunos_Id",
            //    table: "Vouchers",
            //    column: "Id",
            //    principalTable: "Alunos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependencias_Alunos_Id",
                table: "Dependencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_Id",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Alunos_Id",
                table: "Vouchers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Vouchers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "TalentosEsportivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Matriculas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dependencias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Dependencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_TalentosEsportivos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TalentosEsportivos_Alunos_AlunoId",
                table: "TalentosEsportivos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
