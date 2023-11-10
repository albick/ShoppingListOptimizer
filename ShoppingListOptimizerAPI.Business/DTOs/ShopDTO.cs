using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public LocationDTO Location { get; set; }

        public AccountDTO Creator { get; set; }
        public AccountDTO Company { get; set; }
        public ICollection<OpeningHoursDTO>? OpeningHours { get; set; }
    }
}
