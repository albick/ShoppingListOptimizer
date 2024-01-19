using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Business.DTOs
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public LocationDTO Location { get; set; }
    }
}
