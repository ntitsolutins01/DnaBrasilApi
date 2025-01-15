using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteAlunoModalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosModalidades");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NomeContato",
            //    table: "Parceiros",
            //    type: "nvarchar(150)",
            //    maxLength: 150,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(150)",
            //    oldMaxLength: 150);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeContato",
                table: "Parceiros",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AlunosModalidades",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosModalidades", x => new { x.AlunoId, x.ModalidadeId });
                    table.ForeignKey(
                        name: "FK_AlunosModalidades_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosModalidades_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosModalidades_ModalidadeId",
                table: "AlunosModalidades",
                column: "ModalidadeId");
        }
    }
}
