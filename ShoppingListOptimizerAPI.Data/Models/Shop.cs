using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Location Location { get; set; }

        public Account Creator { get; set; }
        public Account Company { get; set; }
        //15 mins intervals 4*24*7=672 chars represent it
        [MaxLength(672)]
        public string? OpeningHours { get; set; }
    }
}
