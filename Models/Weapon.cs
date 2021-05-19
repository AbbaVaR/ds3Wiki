using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Types { get; set; }
        public int Damage { get; set; }
        public int Distance { get; set; }
        public string Support_for_improvement { get; set; }
        public ICollection<Character_characteristic> Characteristics { get; set; }
        public ICollection<Negative_effect> Effects { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Character> Characters { get; set; }

    }
}
