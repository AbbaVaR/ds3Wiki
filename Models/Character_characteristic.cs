using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Character_characteristic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Influence { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Type_of_magic> Type_Of_Magics { get; set; }


    }
}
