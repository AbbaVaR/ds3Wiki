using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Magic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Type_of_magic> Types_of_magic { get; set; }
        public int Concentration_costs { get; set; }
        public int Occupied_cells { get; set; }
    }
}
