using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class Item
    {

        [Key]
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        
        public Account Creator { get; set; }

    }
}
