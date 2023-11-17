using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasil.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateContratosLocalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "ContratosLocais");

           
            migrationBuilder.CreateTable(
                name: "ContratosLocalidades",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    LocalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosLocalidades", x => new { x.ContratoId, x.LocalidadeId });
                    table.ForeignKey(
                        name: "FK_ContratosLocalidades_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosLocalidades_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosLocalidades_LocalidadeId",
                table: "ContratosLocalidades",
                column: "LocalidadeId");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "ContratosLocalidades");

            
            migrationBuilder.CreateTable(
                name: "ContratosLocais",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosLocais", x => new { x.ContratoId, x.LocalId });
                    table.ForeignKey(
                        name: "FK_ContratosLocais_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosLocais_Localidades_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosLocais_LocalId",
                table: "ContratosLocais",
                column: "LocalId");

            
        }
    }
}
