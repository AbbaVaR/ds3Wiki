using System.Collections.Generic;

namespace ds3Wiki.Models
{
    public class Catalyst
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type_of_catalyst { get; set; }
        public int Spell_Buff { get; set; }
        public int Type_of_magicId { get; set; }
        public Type_of_magic Type_of_magic { get; set; }
    }
}
