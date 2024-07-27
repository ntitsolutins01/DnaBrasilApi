using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateDependenciaNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependencias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DependenciasOld_Alunos_Id",
                table: "DependenciasOld");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DependenciasOld",
                table: "DependenciasOld");

            migrationBuilder.RenameTable(
                name: "DependenciasOld",
                newName: "Dependencias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependencias",
                table: "Dependencias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependencias_Alunos_Id",
                table: "Dependencias",
                column: "Id",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
