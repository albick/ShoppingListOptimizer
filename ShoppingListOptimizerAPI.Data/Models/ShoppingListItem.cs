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
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public Item Item { get; set; }
        [Required]
        public int Count { get; set; }

        public bool IsPriority { get; set; }
    }
}
