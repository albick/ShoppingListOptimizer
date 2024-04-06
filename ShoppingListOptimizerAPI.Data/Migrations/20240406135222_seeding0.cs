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
                    { "0", "d8ee14dd-47d7-4937-bfcd-535c83625153", "Admin", "ADMIN" },
                    { "1", "22c35fe2-2cdf-4ef3-9ed7-5c875ce95108", "Shop", "SHOP" },
                    { "2", "00e0264b-ef37-4902-b432-964ff9dbf234", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000000", 0, "78350e97-202a-4b02-87bd-8160711088ff", "Account0@x.com", false, null, false, null, "ACCOUNT0@X.COM", "ADMIN0", "AQAAAAEAACcQAAAAEILkm2PTi72TqLhCs0p6DFcDa9hqaqMAaEqdDREC3myPzO2Cg4S4gT5OHJTGMGDsjQ==", null, false, "57a9c217-1f60-4e16-a899-629263a45633", false, "Admin0" },
                    { "00000000-0000-0000-0000-000000000001", 0, "e698bd78-f37c-475b-9285-bf514781f94f", "Account1@x.com", false, null, false, null, "ACCOUNT1@X.COM", "USER1", "AQAAAAEAACcQAAAAEFuQ8iJ+Gso0U1z0Vr9VnZD4RS5Ul4xsnmHgM0ZxWH7pMkM57KvdTVVAD/CpTd0ahA==", null, false, "cd2feee7-5dca-4a24-8775-9b397698d2ee", false, "User1" },
                    { "00000000-0000-0000-0000-000000000002", 0, "941053cd-3931-40f2-b43e-8ceed5f6692f", "Account2@x.com", false, null, false, null, "ACCOUNT2@X.COM", "TESCO", "AQAAAAEAACcQAAAAEEql4wiXHPHaT7EL8TqyZS59QI60twBO7FwsDXmLcyuI2HxzW1Yqt4i3Msws/BqgPQ==", null, false, "eb4c92bf-7dcf-4a6c-8700-dbc263b4eeb0", false, "Tesco" },
                    { "00000000-0000-0000-0000-000000000003", 0, "964168a0-cc3d-4ac8-b458-a9dfed3d7d9a", "Account3@x.com", false, null, false, null, "ACCOUNT3@X.COM", "AUCHAN", "AQAAAAEAACcQAAAAECDrkWWqWP7KR/T5+FmvJvrnqqLqe5IwM7WfOLOCK5JVhHoq9dxO/YN+06Nr/UIKxA==", null, false, "2ee8e31c-453c-4e26-b345-2559af9b826e", false, "Auchan" },
                    { "00000000-0000-0000-0000-000000000004", 0, "da217a0b-b144-4528-af42-c207d664947a", "Account4@x.com", false, null, false, null, "ACCOUNT4@X.COM", "USER4", "AQAAAAEAACcQAAAAELKdZUPAj08rU5mgUw8HeOhm5o+xtFOer7YQgyR8UuCPUMM7dqsyRkCTijerl91TAQ==", null, false, "f769b0bc-927c-46b0-a5e1-334a0d0dbd9c", false, "User4" }
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
                table: "Item",
                columns: new[] { "Barcode", "CreatorId", "Details", "Name", "Quantity", "Unit" },
                values: new object[,]
                {
                    { "1", "00000000-0000-0000-0000-000000000001", "Gyermelyi Búzafinomliszt.\r\nBL 55\r\nKiszerelés: 1000g./csomag.\r\nAllergének: glutén.", "Búzafinomliszt BL55 GYERMELYI 1kg", 1.0, "kg" },
                    { "2", "00000000-0000-0000-0000-000000000001", "A Koronás Kristálycukor tartósítószer és színezék hozzáadása nélkül.\r\nSzemcséi szabad szemmel is jól láthatóak.\r\nÉtelek és italok édesítésére, ízesítésére egyaránt használható.\r\nMinőségét korlátlan ideig megőrzi.", "Kristálycukor KORONÁS 1kg", 1.0, "kg" },
                    { "3", "00000000-0000-0000-0000-000000000001", "0,5 literes, szénsavmentes természetes ásványvíz.\r\n\r\nAlkalmas nátrium-szegény diétához. Lúgos kémhatású termék, 7,5 pH-val. Vastalanítva.", "Mizse szénsavmentes ásványvíz", 0.5, "l" },
                    { "4", "00000000-0000-0000-0000-000000000001", "Asztali só.", "Asztali tengeri só 1kg", 1.0, "kg" }
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
                table: "ItemPriceEntry",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "ItemId", "Price", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 359.0, 1 },
                    { 2, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 889.0, 1 },
                    { 3, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 139.0, 1 },
                    { 4, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 349.0, 1 },
                    { 5, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 361.0, 1 },
                    { 6, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 891.0, 1 },
                    { 7, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 141.0, 1 },
                    { 8, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 351.0, 1 },
                    { 9, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 363.0, 1 },
                    { 10, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 893.0, 1 },
                    { 11, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 143.0, 1 },
                    { 12, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 353.0, 1 },
                    { 13, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 365.0, 1 },
                    { 14, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 895.0, 1 },
                    { 15, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 145.0, 1 },
                    { 16, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 355.0, 1 },
                    { 17, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 367.0, 1 },
                    { 18, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 897.0, 1 },
                    { 19, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 147.0, 1 },
                    { 20, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 357.0, 1 },
                    { 21, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 369.0, 1 },
                    { 22, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 899.0, 1 },
                    { 23, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 149.0, 1 },
                    { 24, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 359.0, 1 },
                    { 25, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 371.0, 1 },
                    { 26, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 901.0, 1 },
                    { 27, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 151.0, 1 },
                    { 28, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 361.0, 1 },
                    { 29, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 360.0, 2 },
                    { 30, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 890.0, 2 },
                    { 31, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 140.0, 2 },
                    { 32, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 350.0, 2 },
                    { 33, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 362.0, 2 },
                    { 34, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 892.0, 2 },
                    { 35, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 142.0, 2 },
                    { 36, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 352.0, 2 },
                    { 37, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 364.0, 2 },
                    { 38, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 894.0, 2 },
                    { 39, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 144.0, 2 },
                    { 40, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 354.0, 2 },
                    { 41, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 366.0, 2 },
                    { 42, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 896.0, 2 },
                    { 43, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 146.0, 2 },
                    { 44, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 356.0, 2 },
                    { 45, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 368.0, 2 },
                    { 46, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 898.0, 2 },
                    { 47, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 148.0, 2 },
                    { 48, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 358.0, 2 },
                    { 49, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 370.0, 2 },
                    { 50, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 900.0, 2 },
                    { 51, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 150.0, 2 },
                    { 52, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 360.0, 2 },
                    { 53, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 372.0, 2 },
                    { 54, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 902.0, 2 },
                    { 55, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 152.0, 2 },
                    { 56, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 362.0, 2 },
                    { 57, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 361.0, 3 },
                    { 58, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 891.0, 3 },
                    { 59, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 141.0, 3 },
                    { 60, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 351.0, 3 },
                    { 61, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 363.0, 3 },
                    { 62, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 893.0, 3 },
                    { 63, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 143.0, 3 },
                    { 64, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 353.0, 3 },
                    { 65, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 365.0, 3 },
                    { 66, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 895.0, 3 },
                    { 67, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 145.0, 3 },
                    { 68, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 355.0, 3 },
                    { 69, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 367.0, 3 },
                    { 70, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 897.0, 3 },
                    { 71, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 147.0, 3 },
                    { 72, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 357.0, 3 },
                    { 73, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 369.0, 3 },
                    { 74, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 899.0, 3 },
                    { 75, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 149.0, 3 },
                    { 76, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 359.0, 3 },
                    { 77, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 371.0, 3 },
                    { 78, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 901.0, 3 },
                    { 79, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 151.0, 3 },
                    { 80, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 361.0, 3 },
                    { 81, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 373.0, 3 },
                    { 82, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 903.0, 3 },
                    { 83, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 153.0, 3 },
                    { 84, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 363.0, 3 },
                    { 85, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 362.0, 4 },
                    { 86, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 892.0, 4 },
                    { 87, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 142.0, 4 },
                    { 88, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 352.0, 4 },
                    { 89, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 364.0, 4 },
                    { 90, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 894.0, 4 },
                    { 91, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 144.0, 4 },
                    { 92, new DateTime(2024, 3, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 354.0, 4 },
                    { 93, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 366.0, 4 },
                    { 94, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 896.0, 4 },
                    { 95, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 146.0, 4 },
                    { 96, new DateTime(2024, 3, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 356.0, 4 },
                    { 97, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 368.0, 4 },
                    { 98, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 898.0, 4 },
                    { 99, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 148.0, 4 },
                    { 100, new DateTime(2024, 3, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 358.0, 4 },
                    { 101, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 370.0, 4 },
                    { 102, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 900.0, 4 },
                    { 103, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 150.0, 4 },
                    { 104, new DateTime(2024, 3, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 360.0, 4 },
                    { 105, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 372.0, 4 },
                    { 106, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 902.0, 4 },
                    { 107, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 152.0, 4 },
                    { 108, new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 362.0, 4 },
                    { 109, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "1", 374.0, 4 },
                    { 110, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "2", 904.0, 4 },
                    { 111, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "3", 154.0, 4 },
                    { 112, new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "00000000-0000-0000-0000-000000000001", "4", 364.0, 4 }
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
