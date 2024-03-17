﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Data.Infrastructure
{
    public class MyDbContext : IdentityDbContext<Account>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Account>().HasData(true);
        }*/

        public DbSet<Item> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ItemPriceEntry> ItemPriceEntries { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        
    }


}
