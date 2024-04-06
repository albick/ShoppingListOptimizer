using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingListOptimizerAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Postcode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Barcode);
                    table.CheckConstraint("CK_Item_Name", "CHAR_LENGTH(Name) >= 3");
                    table.CheckConstraint("CK_Item_Quantity", "Quantity > 0");
                    table.ForeignKey(
                        name: "FK_Item_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "char(50)", fixedLength: true, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.CheckConstraint("CK_Shop_Name", "CHAR_LENGTH(Name) >= 3");
                    table.ForeignKey(
                        name: "FK_Shop_AspNetUsers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "char(50)", fixedLength: true, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                    table.CheckConstraint("CK_ShoppingList_Name", "CHAR_LENGTH(Name) >= 3");
                    table.ForeignKey(
                        name: "FK_ShoppingList_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemPriceEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(type: "double", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ItemId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPriceEntry", x => x.Id);
                    table.CheckConstraint("CK_ItemPriceEntry_Price", "Price > 0");
                    table.ForeignKey(
                        name: "FK_ItemPriceEntry_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPriceEntry_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPriceEntry_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningHours_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsPriority = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItem", x => x.Id);
                    table.CheckConstraint("CK_ShoppingListItem_Count", "Count > 0");
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_ShoppingList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0", "a50f57a4-d3d5-4674-b5d8-403cb9416b75", "Admin", "ADMIN" },
                    { "1", "9cab94c7-b4be-4232-b26d-64750a9367ef", "Shop", "SHOP" },
                    { "2", "c1dd4f71-f6b6-4433-9f7b-7dc9d27f300a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000000", 0, "4ce768ab-f0bb-4705-beb3-b79d9c264527", "Account0@x.com", false, null, false, null, "ACCOUNT0@X.COM", "ADMIN0", "AQAAAAEAACcQAAAAEP3uYJp4AurpyY7NYMia5Dyt21MvCvGZOGSXW/RH+DEGdUyxNsyAmhZnigaSdiykpQ==", null, false, "a3961caf-0302-4940-8ebf-29bc01e97bfe", false, "Admin0" },
                    { "00000000-0000-0000-0000-000000000001", 0, "65341b4d-dbc3-4972-8308-0c3c3e8e5503", "Account1@x.com", false, null, false, null, "ACCOUNT1@X.COM", "USER1", "AQAAAAEAACcQAAAAEApVIxb9Awx6xsF22jkhWCWW7bhqsqQt+79ZFR7yXbJ8hc0Fz8ZeOaVW9Eb0k9sc2A==", null, false, "1e50f2df-2697-415b-ac7e-3b8b3c7976bf", false, "User1" },
                    { "00000000-0000-0000-0000-000000000002", 0, "ceba9665-21b2-46a7-bd52-9cc56a66cc01", "Account2@x.com", false, null, false, null, "ACCOUNT2@X.COM", "TESCO", "AQAAAAEAACcQAAAAECNQUwh12XcabmS6dSCgfa7aBB0mQ0dbh7o4TCBLYjaiV/6tPKHcau90E8MiOvZ9HQ==", null, false, "5424316e-e0ef-4b4d-aed0-37490676be5f", false, "Tesco" },
                    { "00000000-0000-0000-0000-000000000003", 0, "f7c1a863-676d-4097-91bb-ccfc3310a8d9", "Account3@x.com", false, null, false, null, "ACCOUNT3@X.COM", "AUCHAN", "AQAAAAEAACcQAAAAEAVtRMvwnfAhXD/kXKf0oT2zYbE5cCzGqDSKxEXPb6kLe6AG6XBdrW+B5lNpZawClg==", null, false, "e664753c-a67c-4c6a-ae59-843954985bc0", false, "Auchan" },
                    { "00000000-0000-0000-0000-000000000004", 0, "392c853a-f6ee-4b72-b5e3-1f6adaeb959e", "Account4@x.com", false, null, false, null, "ACCOUNT4@X.COM", "USER4", "AQAAAAEAACcQAAAAEPCmHMA21Z+gAScOTasOLH0jEcRjY8RqnwdYXS/AdZWXmnLCvYd+VbhIYC9Ydd/FdA==", null, false, "2ef4fb1f-b33f-42c8-ab72-eb1863eb2eb1", false, "User4" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Latitude", "Longitude", "Number", "Postcode", "Street" },
                values: new object[,]
                {
                    { 1, "Budaörs", 47.450125, 18.964566300000001, "1", "2040", "Kinizsi utca" },
                    { 2, "Budaörs", 47.454938749999997, 18.943733936449245, "2-4", "2040", "Sport utca" },
                    { 3, "Székesfehérvár", 47.190058999999998, 18.4041082, "6", "8000", "Palotai út" },
                    { 4, "Debrecen", 47.540409799999999, 21.583815048626832, "7", "4031", "Kishatár utca" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0", "00000000-0000-0000-0000-000000000000" },
                    { "2", "00000000-0000-0000-0000-000000000001" },
                    { "1", "00000000-0000-0000-0000-000000000002" },
                    { "1", "00000000-0000-0000-0000-000000000003" },
                    { "1", "00000000-0000-0000-0000-000000000004" }
                });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "CompanyId", "CreatorId", "Details", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002", "Tesco Budaörs", 1, "TESCO Budaörs" },
                    { 2, "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000003", "Auchan Budaörs", 2, "AUCHAN Budaörs" },
                    { 3, "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002", "Tesco Székesfehérvár", 3, "TESCO Székesfehérvár" },
                    { 4, "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000003", "Auchan Debrecen", 4, "AUCHAN Debrecen" }
                });

            migrationBuilder.InsertData(
                table: "OpeningHours",
                columns: new[] { "Id", "DayOfWeek", "EndTime", "ShopId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 20, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 2, 2, new TimeSpan(0, 20, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 3, 3, new TimeSpan(0, 20, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 4, 4, new TimeSpan(0, 20, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 5, 5, new TimeSpan(0, 20, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 6, 6, new TimeSpan(0, 16, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 7, 0, new TimeSpan(0, 16, 0, 0, 0), 1, new TimeSpan(0, 6, 0, 0, 0) },
                    { 8, 1, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 9, 2, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 10, 3, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 11, 4, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 12, 5, new TimeSpan(0, 20, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 13, 6, new TimeSpan(0, 16, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 14, 0, new TimeSpan(0, 16, 0, 0, 0), 2, new TimeSpan(0, 6, 0, 0, 0) },
                    { 15, 1, new TimeSpan(0, 20, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 16, 2, new TimeSpan(0, 20, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 17, 3, new TimeSpan(0, 20, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 18, 4, new TimeSpan(0, 20, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 19, 5, new TimeSpan(0, 20, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 20, 6, new TimeSpan(0, 16, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 21, 0, new TimeSpan(0, 16, 0, 0, 0), 3, new TimeSpan(0, 6, 0, 0, 0) },
                    { 22, 1, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 23, 2, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 24, 3, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 25, 4, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 26, 5, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 27, 6, new TimeSpan(0, 16, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) },
                    { 28, 0, new TimeSpan(0, 16, 0, 0, 0), 4, new TimeSpan(0, 6, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CreatorId",
                table: "Item",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPriceEntry_CreatorId",
                table: "ItemPriceEntry",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPriceEntry_ItemId",
                table: "ItemPriceEntry",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPriceEntry_ShopId",
                table: "ItemPriceEntry",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_ShopId",
                table: "OpeningHours",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_CompanyId",
                table: "Shop",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_CreatorId",
                table: "Shop",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_LocationId",
                table: "Shop",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_CreatorId",
                table: "ShoppingList",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ItemId",
                table: "ShoppingListItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ShoppingListId",
                table: "ShoppingListItem",
                column: "ShoppingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ItemPriceEntry");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropTable(
                name: "ShoppingListItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
