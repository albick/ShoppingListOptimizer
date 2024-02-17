using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ItemQueryResultDTO
    {
        public double Price {  get; set; }
        public DateTime CreatedAt { get; set; }
        public ItemDTO Item { get; set; }
        public ShopDTO Shop { get; set; }
        public double Distance { get; set; }
    }
}
