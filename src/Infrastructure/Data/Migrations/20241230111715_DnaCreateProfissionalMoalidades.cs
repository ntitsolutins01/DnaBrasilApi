using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaCreateProfissionalMoalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ModalidadeProfissional",
            //    columns: table => new
            //    {
            //        ModalidadesId = table.Column<int>(type: "int", nullable: false),
            //        ProfissionaisId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ModalidadeProfissional", x => new { x.ModalidadesId, x.ProfissionaisId });
            //        table.ForeignKey(
            //            name: "FK_ModalidadeProfissional_Modalidades_ModalidadesId",
            //            column: x => x.ModalidadesId,
            //            principalTable: "Modalidades",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ModalidadeProfissional_Profissionais_ProfissionaisId",
            //            column: x => x.ProfissionaisId,
            //            principalTable: "Profissionais",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "ProfissionalModalidades",
                columns: table => new
                {
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProfissionalModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfissionalModalidades_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ModalidadeProfissional_ProfissionaisId",
            //    table: "ModalidadeProfissional",
            //    column: "ProfissionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalModalidades_ModalidadeId",
                table: "ProfissionalModalidades",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalModalidades_ProfissionalId",
                table: "ProfissionalModalidades",
                column: "ProfissionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ModalidadeProfissional");

            migrationBuilder.DropTable(
                name: "ProfissionalModalidades");
        }
    }
}
