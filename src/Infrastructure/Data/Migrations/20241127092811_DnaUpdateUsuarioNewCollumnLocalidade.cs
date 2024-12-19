using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateUsuarioNewCollumnLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoLocalidade");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadeId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ContratoId",
            //    table: "Localidades",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios",
                column: "LocalidadeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Localidades_ContratoId",
            //    table: "Localidades",
            //    column: "ContratoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Localidades_Contratos_ContratoId",
            //    table: "Localidades",
            //    column: "ContratoId",
            //    principalTable: "Contratos",
            //    principalColumn: "Id");

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
                name: "FK_Localidades_Contratos_ContratoId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Localidades_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ContratoId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "LocalidadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "Localidades");

            migrationBuilder.CreateTable(
                name: "ContratoLocalidade",
                columns: table => new
                {
                    ContratosId = table.Column<int>(type: "int", nullable: false),
                    LocalidadesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoLocalidade", x => new { x.ContratosId, x.LocalidadesId });
                    table.ForeignKey(
                        name: "FK_ContratoLocalidade_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoLocalidade_Localidades_LocalidadesId",
                        column: x => x.LocalidadesId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratoLocalidade_LocalidadesId",
                table: "ContratoLocalidade",
                column: "LocalidadesId");
        }
    }
}
