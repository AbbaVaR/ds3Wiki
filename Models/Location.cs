using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bonfire { get; set; }
        public ICollection<Game_info> Games_info { get; set; }
    }
}
