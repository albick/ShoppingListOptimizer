using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ItemDTO
    {
        public string Barcode { get; set; }

        public string Name { get; set; }
        public string Details { get; set; }

        public double Quantity { get; set; }

        public string Unit { get; set; }

        public Account Creator { get; set; }
    }
}
