using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Type_of_magic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Character_characteristic> Characteristics { get; set; }
    }
}
