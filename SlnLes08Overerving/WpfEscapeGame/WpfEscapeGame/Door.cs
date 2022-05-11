using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class Door
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; } = false;

        public Item Key { get; set; }
        public Room NextRoom { get; set; }

        public Door(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public Door(string name, string desc, Room nxt)
        {
            Name = name;
            Description = desc;
            NextRoom = nxt;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
