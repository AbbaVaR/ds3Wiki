using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class NPC_location
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
