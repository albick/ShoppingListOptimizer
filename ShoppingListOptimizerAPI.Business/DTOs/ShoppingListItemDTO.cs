using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ShoppingListItemDTO
    {
        public int Id { get; set; }

        public ItemDTO Item { get; set; }

        //constraint 0>
        public int Count { get; set; }

        public bool IsPriority { get; set; }
    }
}
