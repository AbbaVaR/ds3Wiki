using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Gem_Location
    {
        public int Id { get; set; }
        public int Improvement_pathId { get; set; }
        public Improvement_path Improvement_path { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
