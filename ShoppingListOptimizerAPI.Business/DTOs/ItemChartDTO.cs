using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ItemChartDTO
    {
        public string Name { get; set; }
        public List<ItemChartSeriesDTO>? Series { get; set; }
    }
}
