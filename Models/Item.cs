using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Consumable { get; set; }
        public string Use_for { get; set; }
    }
}
