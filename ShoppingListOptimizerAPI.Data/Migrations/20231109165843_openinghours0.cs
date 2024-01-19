using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListOptimizerAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class openinghours0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "HoursMatrixColumn");

            migrationBuilder.DropTable(
                name: "HoursMatrixRow");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropIndex(
                name: "IX_Shops_OpeningHoursId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "OpeningHoursId",
                table: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "Shops",
                type: "varchar(672)",
                maxLength: 672,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Shops");

            migrationBuilder.AddColumn<int>(
                name: "OpeningHoursId",
                table: "Shops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HoursMatrixRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OpeningHoursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursMatrixRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursMatrixRow_OpeningHours_OpeningHoursId",
                        column: x => x.OpeningHoursId,
                        principalTable: "OpeningHours",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HoursMatrixColumn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoursMatrixRowId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursMatrixColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursMatrixColumn_HoursMatrixRow_HoursMatrixRowId",
                        column: x => x.HoursMatrixRowId,
                        principalTable: "HoursMatrixRow",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_OpeningHoursId",
                table: "Shops",
                column: "OpeningHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursMatrixColumn_HoursMatrixRowId",
                table: "HoursMatrixColumn",
                column: "HoursMatrixRowId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursMatrixRow_OpeningHoursId",
                table: "HoursMatrixRow",
                column: "OpeningHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_OpeningHours_OpeningHoursId",
                table: "Shops",
                column: "OpeningHoursId",
                principalTable: "OpeningHours",
                principalColumn: "Id");
        }
    }
}
