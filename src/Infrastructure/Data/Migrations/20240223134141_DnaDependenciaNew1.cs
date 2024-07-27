using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDependenciaNew1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Dependencias",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Ano = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                   AutorizacaoSaida = table.Column<bool>(type: "bit", nullable: true),
                   AutorizacaoUsoImagemAudio = table.Column<bool>(type: "bit", nullable: true),
                   AutorizacaoUsoIndicadores = table.Column<bool>(type: "bit", nullable: true),
                   Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Doencas = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                   LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   Naturalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   NomeEscola = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                   Serie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                   TermoCompromisso = table.Column<bool>(type: "bit", nullable: true),
                   TipoEscola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   TipoEscolaridade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   Turma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                   Turno = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Dependencias", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Dependencias_Alunos_Id",
                       column: x => x.Id,
                       principalTable: "Alunos",
                       principalColumn: "Id");
               });

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Dependencias_Alunos_Id",
            //    table: "Dependencias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dependencias_Alunos_Id",
            //    table: "Dependencias",
            //    column: "Id",
            //    principalTable: "Alunos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
