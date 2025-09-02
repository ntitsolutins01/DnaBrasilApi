using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateAlunoIndexDeficiencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos");

            migrationBuilder.CreateIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos",
                column: "Aviso")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DeficienciaId",
                table: "Alunos",
                column: "DeficienciaId")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos");

            migrationBuilder.CreateIndex(
                name: "IX_TextosLaudos_Aviso",
                table: "TextosLaudos",
                column: "Aviso");
        }
    }
}
