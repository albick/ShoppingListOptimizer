using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOptimizerAPI.Data.Models
{
    public class OpeningHours
    {
        public int Id { get; set; }
        public List<HoursMatrixRow> HoursMatrixRows { get; set; }
    }

    public class HoursMatrixRow
    {
        public int Id { get; set; }
        public List <HoursMatrixColumn> HoursMatrixColumns { get; set; }
    }
    public class HoursMatrixColumn
    {
        public int Id { get; set; }
        public bool Value{ get; set; }
    }

}
