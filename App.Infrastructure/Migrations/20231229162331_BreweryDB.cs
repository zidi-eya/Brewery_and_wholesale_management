using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    public partial class BreweryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.BreweryId);
                });

            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholContent = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_Beer_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "BreweryId");
                });

            migrationBuilder.CreateTable(
                name: "Wholesaler",
                columns: table => new
                {
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesaler", x => x.WholesalerId);
                    table.ForeignKey(
                        name: "FK_Wholesaler_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "BreweryId");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    BeerFK = table.Column<int>(type: "int", nullable: false),
                    WholesalerFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => new { x.BeerFK, x.WholesalerFK, x.SaleId });
                    table.ForeignKey(
                        name: "FK_Sales_Beer_BeerFK",
                        column: x => x.BeerFK,
                        principalTable: "Beer",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Wholesaler_WholesalerFK",
                        column: x => x.WholesalerFK,
                        principalTable: "Wholesaler",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false),
                    BeerFK = table.Column<int>(type: "int", nullable: false),
                    WholesalerFK = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.WholesalerFK, x.BeerFK, x.StockId });
                    table.ForeignKey(
                        name: "FK_Stocks_Beer_BeerFK",
                        column: x => x.BeerFK,
                        principalTable: "Beer",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Wholesaler_WholesalerFK",
                        column: x => x.WholesalerFK,
                        principalTable: "Wholesaler",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BreweryId",
                table: "Beer",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WholesalerFK",
                table: "Sales",
                column: "WholesalerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BeerFK",
                table: "Stocks",
                column: "BeerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Wholesaler_BreweryId",
                table: "Wholesaler",
                column: "BreweryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Wholesaler");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
