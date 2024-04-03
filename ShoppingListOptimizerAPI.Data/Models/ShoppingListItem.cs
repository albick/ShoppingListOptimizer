using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }

        public bool IsPriority { get; set; }
    }
}
