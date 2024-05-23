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
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string CreatorId { get; set; }
        public Account Creator { get; set; }
    }
}
