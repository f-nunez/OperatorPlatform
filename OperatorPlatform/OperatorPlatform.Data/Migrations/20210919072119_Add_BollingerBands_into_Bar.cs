using Microsoft.EntityFrameworkCore.Migrations;

namespace OperatorPlatform.Data.Migrations
{
    public partial class Add_BollingerBands_into_Bar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BollingerLowerBandFirst",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BollingerLowerBandSecond",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BollingerLowerBandThird",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BollingerUpperBandFirst",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BollingerUpperBandSecond",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BollingerUpperBandThird",
                table: "Bars",
                type: "decimal(17,8)",
                precision: 17,
                scale: 8,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BollingerLowerBandFirst",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BollingerLowerBandSecond",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BollingerLowerBandThird",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BollingerUpperBandFirst",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BollingerUpperBandSecond",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BollingerUpperBandThird",
                table: "Bars");
        }
    }
}
