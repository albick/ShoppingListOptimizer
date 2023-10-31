using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingListOptimizerAPI.Data.Models;

namespace ShoppingListOptimizerAPI.Data.Infrastructure
{
    public class MyDbContext : IdentityDbContext<Account>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

       

        public DbSet<Item> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
