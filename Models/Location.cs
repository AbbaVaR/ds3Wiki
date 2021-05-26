using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ds3Wiki.Models;

namespace ds3Wiki.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bonfire { get; set; }
        public int Game_InfoId { get; set; }
        public Game_info Game_Info { get; set; }
        public ICollection<Armor> Armors { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<NPC_location> NPC_Locations { get; set; }
        public ICollection<Gem_Location> Gem_Locations { get; set; }




    }
}
