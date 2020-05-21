using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicShareOwnerControl.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockPortefolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockShares = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPortefolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTraders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PortefolioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTraders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTraders_StockPortefolios_PortefolioId",
                        column: x => x.PortefolioId,
                        principalTable: "StockPortefolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTraders_PortefolioId",
                table: "StockTraders",
                column: "PortefolioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTraders");

            migrationBuilder.DropTable(
                name: "StockPortefolios");
        }
    }
}
