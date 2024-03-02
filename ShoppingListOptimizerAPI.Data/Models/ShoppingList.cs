using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class ShoppingList
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Details { get; set; }

        public DateTime DateModified { get; set; }

        [Required]
        public Account Creator { get; set; }

        public List<ShoppingListItem>? ShoppingListItems { get; set; }
    }
}
