using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Catalyst> Catalysts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Character_characteristic> Character_Characteristics { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Game_info> Games_Info { get; set; }
        public DbSet<Gem_Location> Gem_Locations { get; set; }
        public DbSet<Improvement_path> Improvement_Paths { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Magic> Magics { get; set; }
        public DbSet<Negative_effect> Negative_Effects { get; set; }
        public DbSet<NPC_location> NPC_Locations { get; set; }
        public DbSet<Sale_item> Sale_Items { get; set; }
        public DbSet<Sale_magic> Sale_Magics { get; set; }
        public DbSet<Type_of_magic> Type_Of_Magics { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
