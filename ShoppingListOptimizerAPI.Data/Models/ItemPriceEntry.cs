using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class ItemPriceEntry
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public Item Item { get; set; }
        public Account Creator { get; set; }
        public Shop Shop { get; set; }
    }
}
