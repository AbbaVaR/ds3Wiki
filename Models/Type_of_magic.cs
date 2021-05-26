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
        public int Character_characteristicId { get; set; }
        public Character_characteristic Character_characteristic { get; set; }
        public ICollection<Catalyst> Catalysts { get; set; }
        public ICollection<Magic> Magics { get; set; }
    }
}
