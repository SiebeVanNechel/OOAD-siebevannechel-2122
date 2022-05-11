using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class Item : LockableItem
    {
        public Item Key { get; set; }

        public Item HiddenItem { get; set; }

        public bool IsPortable { get; set; } = true;
        public Item(string name, string desc) : base(name, desc) { }

        public Item(string name, string desc, bool portable):base(name,desc)
        {
            IsPortable = portable;
        }
    }
}
