using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaBao.Migrations
{
    public partial class init : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Акции",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Акции", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Типы товаров",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Типы товаров", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Слайды",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Слайды", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Слайды_Акции_StockId",
                        column: x => x.StockId,
                        principalTable: "Акции",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Продукты",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Продукты", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Продукты_Типы товаров_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "Типы товаров",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    StocksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => new { x.ProductsId, x.StocksId });
                    table.ForeignKey(
                        name: "FK_ProductStock_Акции_StocksId",
                        column: x => x.StocksId,
                        principalTable: "Акции",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStock_Продукты_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Продукты",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Продукты_ProductTypeId",
                table: "Продукты",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Слайды_StockId",
                table: "Слайды",
                column: "StockId",
                unique: true,
                filter: "[StockId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_StocksId",
                table: "ProductStock",
                column: "StocksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Слайды");

            migrationBuilder.DropTable(
                name: "ProductStock");

            migrationBuilder.DropTable(
                name: "Акции");

            migrationBuilder.DropTable(
                name: "Продукты");

            migrationBuilder.DropTable(
                name: "Типы товаров");
        }
    }
}
