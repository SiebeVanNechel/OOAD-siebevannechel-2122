using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class Door : LockableItem
    {
        public Item Key { get; set; }
        public Room NextRoom { get; set; }

        public Door (string name, string desc) : base(name, desc) { }

        public Door(string name, string desc, Room nxt) : base(name, desc)
        {
            NextRoom = nxt;
        }
    }
}
