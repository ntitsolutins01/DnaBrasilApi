using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaUpdateFkAlunoDeficiencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentar_Profissionais_ProfissionalId",
                table: "ConsumoAlimentar");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVida_Profissionais_ProfissionalId",
                table: "QualidadeDeVida");

            migrationBuilder.DropForeignKey(
                name: "FK_Saude_Profissionais_ProfissionalId",
                table: "Saude");

            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucal_Profissionais_ProfissionalId",
                table: "SaudeBucal");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentoEsportivo_Profissionais_ProfissionalId",
                table: "TalentoEsportivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Vocacional_Profissionais_ProfissionalId",
                table: "Vocacional");

            migrationBuilder.DropTable(
                name: "AlunoDados");

            migrationBuilder.DropTable(
                name: "AlunoDeficiencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vocacional",
                table: "Vocacional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TalentoEsportivo",
                table: "TalentoEsportivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaudeBucal",
                table: "SaudeBucal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saude",
                table: "Saude");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualidadeDeVida",
                table: "QualidadeDeVida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumoAlimentar",
                table: "ConsumoAlimentar");

            migrationBuilder.RenameTable(
                name: "Vocacional",
                newName: "Vocacionais");

            migrationBuilder.RenameTable(
                name: "TalentoEsportivo",
                newName: "TalentosEsportivos");

            migrationBuilder.RenameTable(
                name: "SaudeBucal",
                newName: "SaudeBucais");

            migrationBuilder.RenameTable(
                name: "Saude",
                newName: "Saudes");

            migrationBuilder.RenameTable(
                name: "QualidadeDeVida",
                newName: "QualidadeDeVidas");

            migrationBuilder.RenameTable(
                name: "ConsumoAlimentar",
                newName: "ConsumoAlimentares");

            migrationBuilder.RenameIndex(
                name: "IX_Vocacional_ProfissionalId",
                table: "Vocacionais",
                newName: "IX_Vocacionais_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_TalentoEsportivo_ProfissionalId",
                table: "TalentosEsportivos",
                newName: "IX_TalentosEsportivos_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucal_ProfissionalId",
                table: "SaudeBucais",
                newName: "IX_SaudeBucais_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Saude_ProfissionalId",
                table: "Saudes",
                newName: "IX_Saudes_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVida_ProfissionalId",
                table: "QualidadeDeVidas",
                newName: "IX_QualidadeDeVidas_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoAlimentar_ProfissionalId",
                table: "ConsumoAlimentares",
                newName: "IX_ConsumoAlimentares_ProfissionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vocacionais",
                table: "Vocacionais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalentosEsportivos",
                table: "TalentosEsportivos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaudeBucais",
                table: "SaudeBucais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saudes",
                table: "Saudes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualidadeDeVidas",
                table: "QualidadeDeVidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumoAlimentares",
                table: "ConsumoAlimentares",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomePai = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDeficiencia",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    DeficienciasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDeficiencia", x => new { x.AlunosId, x.DeficienciasId });
                    table.ForeignKey(
                        name: "FK_AlunoDeficiencia_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDeficiencia_Deficiencias_DeficienciasId",
                        column: x => x.DeficienciasId,
                        principalTable: "Deficiencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDeficiencia_DeficienciasId",
                table: "AlunoDeficiencia",
                column: "DeficienciasId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EstadoId",
                table: "Alunos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_MunicipioId",
                table: "Alunos",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucais_Profissionais_ProfissionalId",
                table: "SaudeBucais",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentosEsportivos_Profissionais_ProfissionalId",
                table: "TalentosEsportivos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacionais_Profissionais_ProfissionalId",
                table: "Vocacionais",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumoAlimentares_Profissionais_ProfissionalId",
                table: "ConsumoAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_QualidadeDeVidas_Profissionais_ProfissionalId",
                table: "QualidadeDeVidas");

            migrationBuilder.DropForeignKey(
                name: "FK_SaudeBucais_Profissionais_ProfissionalId",
                table: "SaudeBucais");

            migrationBuilder.DropForeignKey(
                name: "FK_Saudes_Profissionais_ProfissionalId",
                table: "Saudes");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentosEsportivos_Profissionais_ProfissionalId",
                table: "TalentosEsportivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vocacionais_Profissionais_ProfissionalId",
                table: "Vocacionais");

            migrationBuilder.DropTable(
                name: "AlunoDeficiencia");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vocacionais",
                table: "Vocacionais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TalentosEsportivos",
                table: "TalentosEsportivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saudes",
                table: "Saudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaudeBucais",
                table: "SaudeBucais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualidadeDeVidas",
                table: "QualidadeDeVidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumoAlimentares",
                table: "ConsumoAlimentares");

            migrationBuilder.RenameTable(
                name: "Vocacionais",
                newName: "Vocacional");

            migrationBuilder.RenameTable(
                name: "TalentosEsportivos",
                newName: "TalentoEsportivo");

            migrationBuilder.RenameTable(
                name: "Saudes",
                newName: "Saude");

            migrationBuilder.RenameTable(
                name: "SaudeBucais",
                newName: "SaudeBucal");

            migrationBuilder.RenameTable(
                name: "QualidadeDeVidas",
                newName: "QualidadeDeVida");

            migrationBuilder.RenameTable(
                name: "ConsumoAlimentares",
                newName: "ConsumoAlimentar");

            migrationBuilder.RenameIndex(
                name: "IX_Vocacionais_ProfissionalId",
                table: "Vocacional",
                newName: "IX_Vocacional_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_TalentosEsportivos_ProfissionalId",
                table: "TalentoEsportivo",
                newName: "IX_TalentoEsportivo_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Saudes_ProfissionalId",
                table: "Saude",
                newName: "IX_Saude_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_SaudeBucais_ProfissionalId",
                table: "SaudeBucal",
                newName: "IX_SaudeBucal_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_QualidadeDeVidas_ProfissionalId",
                table: "QualidadeDeVida",
                newName: "IX_QualidadeDeVida_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsumoAlimentares_ProfissionalId",
                table: "ConsumoAlimentar",
                newName: "IX_ConsumoAlimentar_ProfissionalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vocacional",
                table: "Vocacional",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalentoEsportivo",
                table: "TalentoEsportivo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saude",
                table: "Saude",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaudeBucal",
                table: "SaudeBucal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualidadeDeVida",
                table: "QualidadeDeVida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumoAlimentar",
                table: "ConsumoAlimentar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunoDados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomePai = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Social = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoDados_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDados_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDeficiencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deficiencia = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDeficiencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDados_EstadoId",
                table: "AlunoDados",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDados_MunicipioId",
                table: "AlunoDados",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumoAlimentar_Profissionais_ProfissionalId",
                table: "ConsumoAlimentar",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualidadeDeVida_Profissionais_ProfissionalId",
                table: "QualidadeDeVida",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saude_Profissionais_ProfissionalId",
                table: "Saude",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaudeBucal_Profissionais_ProfissionalId",
                table: "SaudeBucal",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentoEsportivo_Profissionais_ProfissionalId",
                table: "TalentoEsportivo",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocacional_Profissionais_ProfissionalId",
                table: "Vocacional",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
