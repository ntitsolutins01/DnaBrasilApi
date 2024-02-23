using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnaBrasilApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DnaModalidades2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbdominalPranchaFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AbdominalPranchaIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlturaFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlturaIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnvergaduraFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnvergaduraIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlexibilidadeFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlexibilidadeIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpulsaoFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpulsaoIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PesoFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PesoIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreensaoManualFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreensaoManualIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShutlleRunFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShutlleRunIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VinteMetrosFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VinteMetrosIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vo2MaxFim",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vo2MaxIni",
                table: "Modalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbdominalPranchaFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "AbdominalPranchaIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "AlturaFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "AlturaIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "EnvergaduraFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "EnvergaduraIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "FlexibilidadeFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "FlexibilidadeIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "ImpulsaoFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "ImpulsaoIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "PesoFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "PesoIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "PreensaoManualFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "PreensaoManualIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "ShutlleRunFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "ShutlleRunIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "VinteMetrosFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "VinteMetrosIni",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "Vo2MaxFim",
                table: "Modalidades");

            migrationBuilder.DropColumn(
                name: "Vo2MaxIni",
                table: "Modalidades");
        }
    }
}
