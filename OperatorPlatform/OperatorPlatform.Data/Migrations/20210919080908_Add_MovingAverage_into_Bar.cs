using Microsoft.EntityFrameworkCore.Migrations;

namespace OperatorPlatform.Data.Migrations
{
    public partial class Add_MovingAverage_into_Bar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MovingAverage",
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
                name: "MovingAverage",
                table: "Bars");
        }
    }
}
