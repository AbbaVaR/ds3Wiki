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
        public int Type_of_magicId { get; set; }
        public Type_of_magic Type_of_magic { get; set; }
        public int Concentration_costs { get; set; }
        public int Occupied_cells { get; set; }
        public ICollection<Sale_magic> Sale_Magics { get; set; }
    }
}
