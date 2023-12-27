using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    public partial class BreweryDataBase : Migration
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
                name: "Wholesalers",
                columns: table => new
                {
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.WholesalerId);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholContent = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "BreweryId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Sales_Beers_BeerFK",
                        column: x => x.BeerFK,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Wholesalers_WholesalerFK",
                        column: x => x.WholesalerFK,
                        principalTable: "Wholesalers",
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
                        name: "FK_Stocks_Beers_BeerFK",
                        column: x => x.BeerFK,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Wholesalers_WholesalerFK",
                        column: x => x.WholesalerFK,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WholesalerFK",
                table: "Sales",
                column: "WholesalerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BeerFK",
                table: "Stocks",
                column: "BeerFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
