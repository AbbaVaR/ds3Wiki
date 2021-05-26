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
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int Character_characteristicId{ get; set; }
        public Character_characteristic Character_characteristic { get; set; }
    }
}
