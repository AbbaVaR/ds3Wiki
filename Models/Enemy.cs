using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds3Wiki.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Types { get; set; }
        public int HP { get; set; }
        public int Received_money { get; set; }
    }
}
