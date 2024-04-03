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




            //Seed users
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = "00000000-0000-0000-0000-000000000000", UserName = "Account0", NormalizedUserName = "ACCOUNT0", Email = "Account0@x.com", NormalizedEmail = "ACCOUNT0@X.COM", PasswordHash = hasher.HashPassword(null, "password") },
                new Account { Id = "00000000-0000-0000-0000-000000000001", UserName = "Account1", NormalizedUserName = "ACCOUNT1", Email = "Account1@x.com", NormalizedEmail = "ACCOUNT1@X.COM", PasswordHash = hasher.HashPassword(null, "password") },
                new Account { Id = "00000000-0000-0000-0000-000000000002", UserName = "Account2", NormalizedUserName = "ACCOUNT2", Email = "Account2@x.com", NormalizedEmail = "ACCOUNT2@X.COM", PasswordHash = hasher.HashPassword(null, "password") },
                new Account { Id = "00000000-0000-0000-0000-000000000003", UserName = "Account3", NormalizedUserName = "ACCOUNT3", Email = "Account3@x.com", NormalizedEmail = "ACCOUNT3@X.COM", PasswordHash = hasher.HashPassword(null, "password") },
                new Account { Id = "00000000-0000-0000-0000-000000000004", UserName = "Account4", NormalizedUserName = "ACCOUNT4", Email = "Account4@x.com", NormalizedEmail = "ACCOUNT4@X.COM", PasswordHash = hasher.HashPassword(null, "password") }
                );

            //Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "0", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "1", Name = "Shop", NormalizedName = "SHOP" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            // Seed user-role relationships
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000000", RoleId = "0" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000001", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000002", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000003", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "00000000-0000-0000-0000-000000000004", RoleId = "1" }
            );



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
                .HasForeignKey("CreatorId")
                .IsRequired();


            // ShoppingListItem entity
            modelBuilder.Entity<ShoppingListItem>()
                .HasKey(s => s.Id)
                .HasName("PK_ShoppingListItem");

            modelBuilder.Entity<ShoppingListItem>()
                .HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey("ItemId")
                .IsRequired();

            modelBuilder.Entity<ShoppingListItem>()
                .ToTable("ShoppingListItem", table =>
                {
                    table.HasCheckConstraint("CK_ShoppingListItem_Count", "Count > 0");
                });

            modelBuilder.Entity<ShoppingListItem>()
                .Property(e => e.IsPriority)
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
                .HasForeignKey("LocationId")
                .IsRequired();

            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Creator)
                .WithMany()
                .HasForeignKey("CreatorId")
                .IsRequired();

            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Company)
                .WithMany()
                .HasForeignKey("CompanyId")
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
                    .HasForeignKey("ItemId")
                    .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                    .HasOne(i => i.Creator)
                    .WithMany()
                    .HasForeignKey("CreatorId")
                    .IsRequired();

            modelBuilder.Entity<ItemPriceEntry>()
                    .HasOne(i => i.Shop)
                    .WithMany()
                    .HasForeignKey("ShopId")
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
                    .HasForeignKey("CreatorId")
                    .IsRequired();

            
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
