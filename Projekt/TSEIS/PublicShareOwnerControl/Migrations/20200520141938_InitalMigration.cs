using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicShareOwnerControl.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTraders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTraders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPortefolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StockShares = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPortefolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPortefolios_StockTraders_Id",
                        column: x => x.Id,
                        principalTable: "StockTraders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockPortefolios");

            migrationBuilder.DropTable(
                name: "StockTraders");
        }
    }
}
