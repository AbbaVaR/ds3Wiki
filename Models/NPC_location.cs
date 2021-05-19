using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class NPC_location
    {
        public int Id { get; set; }
        public ICollection<Location> Location { get; set; }
        public ICollection<Enemy> Enemies { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
