using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class LockableItem : Actor
    {
        public LockableItem(string name, string desc) : base(name, desc) { }
        public bool IsLocked { get; set; } = false;
    }
}
