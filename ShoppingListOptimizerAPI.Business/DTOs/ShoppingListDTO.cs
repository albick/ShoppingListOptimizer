using ShoppingListOptimizerAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class ShoppingListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public DateTime DateModified { get; set; }

        public AccountDTO Creator { get; set; }

        public List<ShoppingListItemDTO> ShoppingListItems { get; set; }
    }
}
