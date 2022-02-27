using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YaBao.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Продукты_Типы товаров_ProductTypeId",
                table: "Продукты");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Продукты",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Продукты_Типы товаров_ProductTypeId",
                table: "Продукты",
                column: "ProductTypeId",
                principalTable: "Типы товаров",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Продукты_Типы товаров_ProductTypeId",
                table: "Продукты");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Продукты",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Продукты_Типы товаров_ProductTypeId",
                table: "Продукты",
                column: "ProductTypeId",
                principalTable: "Типы товаров",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
