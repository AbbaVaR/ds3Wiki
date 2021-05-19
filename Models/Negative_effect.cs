using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Negative_effect
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Effect { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
