using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class Actor
    {
        public Actor(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public override string ToString()
        {
            return Name;
        }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
