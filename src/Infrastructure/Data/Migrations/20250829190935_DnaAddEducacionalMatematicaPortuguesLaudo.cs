using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaAddEducacionalMatematicaPortuguesLaudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "EducacionalId",
                table: "Laudos",
                newName: "EducacionalPortuguesId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_EducacionalId",
                table: "Laudos",
                newName: "IX_Laudos_EducacionalPortuguesId");

            migrationBuilder.AddColumn<int>(
                name: "EducacionalMatematicaId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_EducacionalMatematicaId",
                table: "Laudos",
                column: "EducacionalMatematicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalMatematicaId",
                table: "Laudos",
                column: "EducacionalMatematicaId",
                principalTable: "Educacionais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalPortuguesId",
                table: "Laudos",
                column: "EducacionalPortuguesId",
                principalTable: "Educacionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalMatematicaId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalPortuguesId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_EducacionalMatematicaId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "EducacionalMatematicaId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "EducacionalPortuguesId",
                table: "Laudos",
                newName: "EducacionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_EducacionalPortuguesId",
                table: "Laudos",
                newName: "IX_Laudos_EducacionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Educacionais_EducacionalId",
                table: "Laudos",
                column: "EducacionalId",
                principalTable: "Educacionais",
                principalColumn: "Id");
        }
    }
}
