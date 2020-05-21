using Microsoft.EntityFrameworkCore.Migrations;

namespace StockTraderBroker.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferStockId = table.Column<int>(nullable: false),
                    StockAmount = table.Column<int>(nullable: false),
                    StockPrice = table.Column<double>(nullable: false),
                    StockBuyerId = table.Column<int>(nullable: false),
                    StockSellerId = table.Column<int>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    TransactionComplete = table.Column<bool>(nullable: false),
                    StockTransferComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTrades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTrades");
        }
    }
}
