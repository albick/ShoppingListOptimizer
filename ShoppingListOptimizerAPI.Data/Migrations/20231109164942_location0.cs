using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListOptimizerAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class location0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningHoursId",
                table: "Shops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops",
                column: "OpeningHoursId",
                principalTable: "OpeningHours",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops");

            migrationBuilder.AlterColumn<int>(
                name: "OpeningHoursId",
                table: "Shops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops",
                column: "OpeningHoursId",
                principalTable: "OpeningHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
