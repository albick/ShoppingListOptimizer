using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ShopOptimizationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationDTO Location { get; set; }
        public double DistanceFromUser { get; set; } = 0;
        public double PriceSum { get; set; } = 0;
        public double PricePrioritySum { get; set; } = 0;
        public List<ShopOptimizationItemDTO> Items { get; set; } = new List<ShopOptimizationItemDTO>();
    }
}
