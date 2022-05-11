using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    class Room : Actor
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public List<Door> Doors { get; set; } = new List<Door>();

        public string Image { get; set; }
        public Room(string name, string desc,string img) : base(name, desc)
        {
            Image = img;
        }
    }
}
