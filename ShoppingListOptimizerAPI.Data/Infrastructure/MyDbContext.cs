using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Data.Infrastructure
{
    public class MyDbContext : IdentityDbContext<Account>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Seeding
            //Seed users
            var hasher = new PasswordHasher<IdentityUser>();
            Account account1 = new Account { Id = "00000000-0000-0000-0000-000000000001", UserName = "User1", NormalizedUserName = "USER1", Email = "Account1@x.com", NormalizedEmail = "ACCOUNT1@X.COM", PasswordHash = hasher.HashPassword(null, "password") };
            Account account2 = new Account { Id = "00000000-0000-0000-0000-000000000002", UserName = "Tesco", NormalizedUserName = "TESCO", Email = "Account2@x.com", NormalizedEmail = "ACCOUNT2@X.COM", PasswordHash = hasher.HashPassword(null, "password") };
            Account account3 = new Account { Id = "00000000-0000-0000-0000-000000000003", UserName = "Auchan", NormalizedUserName = "AUCHAN", Email = "Account3@x.com", NormalizedEmail = "ACCOUNT3@X.COM", PasswordHash = hasher.HashPassword(null, "password") };
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = "00000000-0000-0000-0000-000000000000", UserName = "Admin0", NormalizedUserName = "ADMIN0", Email = "Account0@x.com", NormalizedEmail = "ACCOUNT0@X.COM", PasswordHash = hasher.HashPassword(null, "password") },
                account1,
                account2,
                account3,
                new Account { Id = "00000000-0000-0000-0000-000000000004", UserName = "User4", NormalizedUserName = "USER4", Email = "Account4@x.com", NormalizedEmail = "ACCOUNT4@X.COM", PasswordHash = hasher.HashPassword(null, "password") }
                );

            //Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "0", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "1", Name = "Shop", NormalizedName = "SHOP" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            //Seed user-role relationships
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000000", RoleId = "0" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000001", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000002", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000003", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000004", RoleId = "1" }
            );

            //Seed locations
            Location location1 = new Location { Id = 1, City = "Budaörs", Postcode = "2040", Street = "Kinizsi utca", Number = "1", Longitude = 18.9645663, Latitude = 47.450125 };
            Location location2 = new Location { Id = 2, City = "Budaörs", Postcode = "2040", Street = "Sport utca", Number = "2-4", Longitude = 18.943733936449245, Latitude = 47.45493875 };
            Location location3 = new Location { Id = 3, City = "Székesfehérvár", Postcode = "8000", Street = "Palotai út", Number = "6", Longitude = 18.4041082, Latitude = 47.190059 };
            Location location4 = new Location { Id = 4, City = "Debrecen", Postcode = "4031", Street = "Kishatár utca", Number = "7", Longitude = 21.583815048626832, Latitude = 47.5404098 };
            modelBuilder.Entity<Location>().HasData(
                //tesco
                location1,
                //auchan
                location2,
                //tesco
                location3,
                //auchan
                location4
                );

            //Seed opening hours
            modelBuilder.Entity<OpeningHours>().HasData(
                new OpeningHours { Id = 1, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 2, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 3, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 4, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 5, DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 6, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 7, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 1 },
                new OpeningHours { Id = 8, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 9, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 10, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 11, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 12, DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 13, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 14, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 2 },
                new OpeningHours { Id = 15, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 16, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 17, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 18, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 19, DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 20, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 21, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 3 },
                new OpeningHours { Id = 22, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 23, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 24, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 25, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 26, DayOfWeek = DayOfWeek.Friday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(20, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 27, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 4 },
                new OpeningHours { Id = 28, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(16, 0, 0), ShopId = 4 }
                );


            //Seed shops
            List<Shop> shops = new List<Shop>() {
            new Shop { Id = 1, Name = "TESCO Budaörs", Details = "Tesco Budaörs", LocationId = location1.Id, CreatorId = account2.Id, CompanyId = account2.Id },
            new Shop { Id = 2, Name = "AUCHAN Budaörs", Details = "Auchan Budaörs", LocationId = location2.Id, CreatorId = account3.Id, CompanyId = account3.Id },
            new Shop { Id = 3, Name = "TESCO Székesfehérvár", Details = "Tesco Székesfehérvár", LocationId = location3.Id, CreatorId = account2.Id, CompanyId = account2.Id },
            new Shop { Id = 4, Name = "AUCHAN Debrecen", Details = "Auchan Debrecen", LocationId = location4.Id, CreatorId = account3.Id, CompanyId = account3.Id }
                 };
            modelBuilder.Entity<Shop>().HasData(
                shops
                );

            //Seed items

            Item item1 = new Item { Barcode = "1", Name = "Búzafinomliszt BL55 GYERMELYI 1kg", Details = "Gyermelyi Búzafinomliszt.\r\nBL 55\r\nKiszerelés: 1000g./csomag.\r\nAllergének: glutén.", Unit = "kg", Quantity = 1, CreatorId = account1.Id };
            Item item2 = new Item { Barcode = "2", Name = "Kristálycukor KORONÁS 1kg", Details = "A Koronás Kristálycukor tartósítószer és színezék hozzáadása nélkül.\r\nSzemcséi szabad szemmel is jól láthatóak.\r\nÉtelek és italok édesítésére, ízesítésére egyaránt használható.\r\nMinőségét korlátlan ideig megőrzi.", Unit = "kg", Quantity = 1, CreatorId = account1.Id };
            Item item3 = new Item { Barcode = "3", Name = "Mizse szénsavmentes ásványvíz", Details = "0,5 literes, szénsavmentes természetes ásványvíz.\r\n\r\nAlkalmas nátrium-szegény diétához. Lúgos kémhatású termék, 7,5 pH-val. Vastalanítva.", Unit = "l", Quantity = 0.5, CreatorId = account1.Id };
            Item item4 = new Item { Barcode = "4", Name = "Asztali tengeri só 1kg", Details = "Asztali só.", Unit = "kg", Quantity = 1, CreatorId = account1.Id };
            modelBuilder.Entity<Item>().HasData(
                item1,
                item2,
                item3,
                item4
                );

            //Seed item price entries
            List<ItemPriceEntry> itemPriceEntries = new List<ItemPriceEntry>();
            int id = 1;
            for (int j = 0; j < shops.Count; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    itemPriceEntries.Add(
                        new ItemPriceEntry { Id = id++, Price = 359 + 2 * i+j, CreatedAt = new DateTime(2024, 3, 1).AddDays(i).AddHours(1), ItemId = item1.Barcode, ShopId = shops.ElementAt(j).Id, CreatorId = account1.Id }
                        );
                    itemPriceEntries.Add(
                        new ItemPriceEntry { Id = id++, Price = 889 + 2 * i+j, CreatedAt = new DateTime(2024, 3, 1).AddDays(i).AddHours(1), ItemId = item2.Barcode, ShopId = shops.ElementAt(j).Id, CreatorId = account1.Id }
                        );
                    itemPriceEntries.Add(
                        new ItemPriceEntry { Id = id++, Price = 139 + 2 * i+j, CreatedAt = new DateTime(2024, 3, 1).AddDays(i).AddHours(1), ItemId = item3.Barcode, ShopId = shops.ElementAt(j).Id, CreatorId = account1.Id }
                        );
                    itemPriceEntries.Add(
                        new ItemPriceEntry { Id = id++, Price = 349 + 2 * i+j, CreatedAt = new DateTime(2024, 3, 1).AddDays(i).AddHours(1), ItemId = item4.Barcode, ShopId = shops.ElementAt(j).Id, CreatorId = account1.Id }
                        );
                }
            }
            modelBuilder.Entity<ItemPriceEntry>().HasData(
                itemPriceEntries
                );


            //Seed shopping lists
            modelBuilder.Entity<ShoppingList>().HasData(
                new ShoppingList { Id=1,CreatorId=account1.Id,Name="Shopping List 1",Details="details of shopping list",DateModified= new DateTime(2024, 3, 8).AddHours(1) }
                );

            //Seed shopping list items
            modelBuilder.Entity<ShoppingListItem>().HasData(
                new ShoppingListItem { Id=1,ItemId=item1.Barcode,Count=2,ShoppingListId=1,IsPriority=true}
                );
            #endregion

            #region Constraints
            // ShoppingList entity
            modelBuilder.Entity<ShoppingList>()
                     .HasKey(s => s.Id)
                     .HasName("PK_ShoppingList");

            modelBuilder.Entity<ShoppingList>()
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

            modelBuilder.Entity<ShoppingList>()
                    .ToTable("ShoppingList", table =>
                    {
                        table.HasCheckConstraint("CK_ShoppingList_Name", "CHAR_LENGTH(Name) >= 3");
                    });

            modelBuilder.Entity<ShoppingList>()
                .Property(e => e.Details)
                .HasMaxLength(1000);

            modelBuilder.Entity<ShoppingList>()
                    .HasOne(s => s.Creator)
                    .WithMany()
                    .HasForeignKey(s=>s.CreatorId)
                    .IsRequired();


            // ShoppingListItem entity
            modelBuilder.Entity<ShoppingListItem>()
                    .HasKey(s => s.Id)
                    .HasName("PK_ShoppingListItem");

            modelBuilder.Entity<ShoppingListItem>()
                    .HasOne(e => e.Item)
                    .WithMany()
                    .HasForeignKey(e=>e.ItemId)
                    .IsRequired();

            modelBuilder.Entity<ShoppingListItem>()
                    .ToTable("ShoppingListItem", table =>
                    {
                        table.HasCheckConstraint("CK_ShoppingListItem_Count", "Count > 0");
                    });

            modelBuilder.Entity<ShoppingListItem>()
                .Property(e => e.IsPriority)
                .IsRequired();


            modelBuilder.Entity<ShoppingListItem>()
                        .HasOne<ShoppingList>()
                        .WithMany(s => s.ShoppingListItems)
                        .HasForeignKey(sh => sh.ShoppingListId)
                        .IsRequired();

            // Shop entity
            modelBuilder.Entity<Shop>()
                    .HasKey(s => s.Id)
                    .HasName("PK_Shop");

            modelBuilder.Entity<Shop>()
                    .Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

            modelBuilder.Entity<Shop>()
                    .ToTable("Shop", table =>
                    {
                        table.HasCheckConstraint("CK_Shop_Name", "CHAR_LENGTH(Name) >= 3");
                    });

            modelBuilder.Entity<Shop>()
                .Property(e => e.Details)
                .HasMaxLength(1000);

            modelBuilder.Entity<Shop>()
                    .HasOne(s => s.Location)
                    .WithMany()
                    .HasForeignKey(s => s.LocationId)
                    .IsRequired();

            modelBuilder.Entity<Shop>()
                    .HasOne(s => s.Creator)
                    .WithMany()
                    .HasForeignKey(s => s.CreatorId)
                    .IsRequired();

            modelBuilder.Entity<Shop>()
                    .HasOne(s => s.Company)
                    .WithMany()
                    .HasForeignKey(s => s.CompanyId)
                    .IsRequired();






            // OpeningHours entity
            modelBuilder.Entity<OpeningHours>()
                        .HasKey(o => o.Id)
                        .HasName("PK_OpeningHours");

            modelBuilder.Entity<OpeningHours>()
                        .Property(e => e.DayOfWeek)
                        .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                        .Property(e => e.StartTime)
                        .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                        .Property(e => e.EndTime)
                        .IsRequired();

            modelBuilder.Entity<OpeningHours>()
                        .HasOne<Shop>()
                        .WithMany(s => s.OpeningHours)
                        .HasForeignKey(oh => oh.ShopId)
                        .IsRequired();

            // Location entity
            modelBuilder.Entity<Location>()
                        .HasKey(l => l.Id)
                        .HasName("PK_Location");

            modelBuilder.Entity<Location>()
                        .Property(e => e.City)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Location>()
                        .Property(e => e.Postcode)
                        .IsRequired()
                        .HasMaxLength(20);

            modelBuilder.Entity<Location>()
                        .Property(e => e.Street)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Location>()
                        .Property(e => e.Number)
                        .IsRequired()
                        .HasMaxLength(20);

            modelBuilder.Entity<Location>()
                        .Property(e => e.Longitude)
                        .IsRequired();

            modelBuilder.Entity<Location>()
                        .Property(e => e.Latitude)
                        .IsRequired();

            // ItemPriceEntry entity
            modelBuilder.Entity<ItemPriceEntry>()
                        .HasKey(i => i.Id)
                        .HasName("PK_ItemPriceEntry");

            modelBuilder.Entity<ItemPriceEntry>()
                        .HasOne(i => i.Item)
                        .WithMany()
                        .HasForeignKey(i => i.ItemId)
                        .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                        .HasOne(i => i.Creator)
                        .WithMany()
                        .HasForeignKey(i => i.CreatorId)
                        .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                        .HasOne(i => i.Shop)
                        .WithMany()
                        .HasForeignKey(i => i.ShopId)
                        .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                        .Property(i => i.Price)
                        .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                    .ToTable("ItemPriceEntry", table =>
                    {
                        table.HasCheckConstraint("CK_ItemPriceEntry_Price", "Price > 0");
                    });

            // Item entity
            modelBuilder.Entity<Item>()
                    .HasKey(i => i.Barcode)
                    .HasName("PK_Item");

            modelBuilder.Entity<Item>()
                        .Property(i => i.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Item>()
                   .ToTable("Item", table =>
                   {
                       table.HasCheckConstraint("CK_Item_Name", "CHAR_LENGTH(Name) >= 3");
                   });

            modelBuilder.Entity<Item>()
                    .Property(i => i.Quantity)
                    .IsRequired();

            modelBuilder.Entity<Item>()
                    .ToTable("Item", table =>
                    {
                        table.HasCheckConstraint("CK_Item_Quantity", "Quantity > 0");
                    });

            modelBuilder.Entity<Item>()
                    .Property(i => i.Unit)
                    .IsRequired();

            modelBuilder.Entity<Item>()
                        .HasOne(i => i.Creator)
                        .WithMany()
                        .HasForeignKey(i => i.CreatorId)
                        .IsRequired();
            #endregion

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ItemPriceEntry> ItemPriceEntries { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

    }


}
