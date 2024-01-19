using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ItemPriceEntryDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public ItemDTO Item { get; set; }
        public Account Creator { get; set; }
        public ShopDTO Shop { get; set; }
    }
}
