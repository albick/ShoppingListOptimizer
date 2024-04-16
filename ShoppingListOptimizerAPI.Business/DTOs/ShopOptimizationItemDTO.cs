using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ShopOptimizationItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceSum { get; set; }
        public int Count { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public bool IsPriority { get; set; }
    }
}
