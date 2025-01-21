using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaDeleteFomentoLocalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FomentoLocalidades");
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FomentoLocalidades_Fomentos_FomentoId",
            //    table: "FomentoLocalidades");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FomentoLocalidades_Localidades_LocalidadeId",
            //    table: "FomentoLocalidades");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_FomentoLocalidades",
            //    table: "FomentoLocalidades");

            //migrationBuilder.RenameTable(
            //    name: "FomentoLocalidades",
            //    newName: "FomentoLocalidade");

            //migrationBuilder.RenameIndex(
            //    name: "IX_FomentoLocalidades_LocalidadeId",
            //    table: "FomentoLocalidade",
            //    newName: "IX_FomentoLocalidade_LocalidadeId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "FomentoLocalidade",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_FomentoLocalidade",
            //    table: "FomentoLocalidade",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FomentoLocalidade_FomentoId",
            //    table: "FomentoLocalidade",
            //    column: "FomentoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FomentoLocalidade_Fomentos_FomentoId",
            //    table: "FomentoLocalidade",
            //    column: "FomentoId",
            //    principalTable: "Fomentos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FomentoLocalidade_Localidades_LocalidadeId",
            //    table: "FomentoLocalidade",
            //    column: "LocalidadeId",
            //    principalTable: "Localidades",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FomentoLocalidade_Fomentos_FomentoId",
                table: "FomentoLocalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_FomentoLocalidade_Localidades_LocalidadeId",
                table: "FomentoLocalidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FomentoLocalidade",
                table: "FomentoLocalidade");

            migrationBuilder.DropIndex(
                name: "IX_FomentoLocalidade_FomentoId",
                table: "FomentoLocalidade");

            migrationBuilder.RenameTable(
                name: "FomentoLocalidade",
                newName: "FomentoLocalidades");

            migrationBuilder.RenameIndex(
                name: "IX_FomentoLocalidade_LocalidadeId",
                table: "FomentoLocalidades",
                newName: "IX_FomentoLocalidades_LocalidadeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FomentoLocalidades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FomentoLocalidades",
                table: "FomentoLocalidades",
                columns: new[] { "FomentoId", "LocalidadeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FomentoLocalidades_Fomentos_FomentoId",
                table: "FomentoLocalidades",
                column: "FomentoId",
                principalTable: "Fomentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FomentoLocalidades_Localidades_LocalidadeId",
                table: "FomentoLocalidades",
                column: "LocalidadeId",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
