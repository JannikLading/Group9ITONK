using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delopgaveprojekt.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haandvaerkers",
                columns: table => new
                {
                    HaandvaerkerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HVAnsaettelsedato = table.Column<DateTime>(nullable: false),
                    HVEfternavn = table.Column<string>(nullable: true),
                    HVFagomraade = table.Column<string>(nullable: true),
                    HVFornavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haandvaerkers", x => x.HaandvaerkerId);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasses",
                columns: table => new
                {
                    VTKId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VTKAnskaffet = table.Column<DateTime>(nullable: false),
                    VTKFabrikat = table.Column<string>(nullable: true),
                    VTKEjesAf = table.Column<int>(nullable: true),
                    VTKModel = table.Column<string>(nullable: true),
                    VTKSerienummer = table.Column<string>(nullable: true),
                    VTKFarve = table.Column<string>(nullable: true),
                    EjesAfNavigationHaandvaerkerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasses", x => x.VTKId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasses_Haandvaerkers_EjesAfNavigationHaandvaerkerId",
                        column: x => x.EjesAfNavigationHaandvaerkerId,
                        principalTable: "Haandvaerkers",
                        principalColumn: "HaandvaerkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejs",
                columns: table => new
                {
                    VTId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VTAnskaffet = table.Column<DateTime>(nullable: false),
                    VTFabrikat = table.Column<string>(nullable: true),
                    VTModel = table.Column<string>(nullable: true),
                    VTSerienr = table.Column<string>(nullable: true),
                    VTType = table.Column<string>(nullable: true),
                    LiggerIvtk = table.Column<int>(nullable: true),
                    LiggerIvtkNavigationVTKId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejs", x => x.VTId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejs_Vaerktoejskasses_LiggerIvtkNavigationVTKId",
                        column: x => x.LiggerIvtkNavigationVTKId,
                        principalTable: "Vaerktoejskasses",
                        principalColumn: "VTKId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejs_LiggerIvtkNavigationVTKId",
                table: "Vaerktoejs",
                column: "LiggerIvtkNavigationVTKId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasses_EjesAfNavigationHaandvaerkerId",
                table: "Vaerktoejskasses",
                column: "EjesAfNavigationHaandvaerkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoejs");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasses");

            migrationBuilder.DropTable(
                name: "Haandvaerkers");
        }
    }
}
