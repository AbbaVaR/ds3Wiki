using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Armor> Armors { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Sale_magic> Sale_Magics { get; set; }
        public ICollection<NPC_location> NPC_Locations { get; set; }
    }
}