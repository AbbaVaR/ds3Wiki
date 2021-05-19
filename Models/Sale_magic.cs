using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Sale_magic
    {
        public int Id { get; set; }
        public ICollection<Character> Charters { get; set; }
        public ICollection<Magic> Magics { get; set; }
    }
}
