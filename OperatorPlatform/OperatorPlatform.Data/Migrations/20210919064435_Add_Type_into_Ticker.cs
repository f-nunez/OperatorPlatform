using Microsoft.EntityFrameworkCore.Migrations;

namespace OperatorPlatform.Data.Migrations
{
    public partial class Add_Type_into_Ticker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tickers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tickers");
        }
    }
}
