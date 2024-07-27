using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateProfissionaisAmbientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProfissionaisAmbientes",
                columns: table => new
                {
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    AmbienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionaisAmbientes", x => new { x.ProfissionalId, x.AmbienteId });
                    table.ForeignKey(
                        name: "FK_ProfissionaisAmbientes_Ambientes_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "Ambientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfissionaisAmbientes_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisAmbientes_AmbienteId",
                table: "ProfissionaisAmbientes",
                column: "AmbienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "ProfissionaisAmbientes");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Municipios_MunicipioId",
                table: "Alunos",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
