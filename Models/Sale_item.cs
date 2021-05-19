using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Sale_item
    {
        public int Id { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
