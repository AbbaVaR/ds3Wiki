using System.Collections.Generic;

namespace ds3Wiki.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Physical_protection { get; set; }
        public int Fire_protection { get; set; }
        public int Lightning_protection { get; set; }
        public int Magic_protection { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
