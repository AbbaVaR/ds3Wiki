using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Gem_Location
    {
        public int Id { get; set; }
        public ICollection<Improvement_path> Gems { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
