using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OperatorPlatform.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarsToLookBack = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickers_Exchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExchangeBarId = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    ReceivedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TimeFrame = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndicatorId = table.Column<int>(type: "int", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alerts_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Close = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    ExchangeBarId = table.Column<int>(type: "int", nullable: false),
                    High = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    Low = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    Open = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeFrame = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    OperationStatus = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    Leverage = table.Column<int>(type: "int", nullable: false),
                    StopLoss = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    StopProfit = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(17,8)", precision: 17, scale: 8, nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: false),
                    BarId = table.Column<int>(type: "int", nullable: false),
                    TickerId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Tickers_TickerId",
                        column: x => x.TickerId,
                        principalTable: "Tickers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IndicatorId",
                table: "Alerts",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_TickerId",
                table: "Alerts",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_TickerId",
                table: "Bars",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_AlertId",
                table: "Operations",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_BarId",
                table: "Operations",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_TickerId",
                table: "Operations",
                column: "TickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickers_ExchangeId",
                table: "Tickers",
                column: "ExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Tickers");

            migrationBuilder.DropTable(
                name: "Exchanges");
        }
    }
}
