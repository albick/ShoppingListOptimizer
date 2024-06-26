﻿
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string CreatorId { get; set; }
        public Account Creator { get; set; }

        public string CompanyId { get; set; }
        public Account Company { get; set; }
        public ICollection<OpeningHours>? OpeningHours { get; set; }
    }

}
