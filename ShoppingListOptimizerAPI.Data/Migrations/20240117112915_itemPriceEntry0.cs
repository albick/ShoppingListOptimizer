using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListOptimizerAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class itemPriceEntry0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPriceEntries_AspNetUsers_ShopId",
                table: "ItemPriceEntries");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "ItemPriceEntries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPriceEntries_Shops_ShopId",
                table: "ItemPriceEntries",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPriceEntries_Shops_ShopId",
                table: "ItemPriceEntries");

            migrationBuilder.AlterColumn<string>(
                name: "ShopId",
                table: "ItemPriceEntries",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPriceEntries_AspNetUsers_ShopId",
                table: "ItemPriceEntries",
                column: "ShopId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
