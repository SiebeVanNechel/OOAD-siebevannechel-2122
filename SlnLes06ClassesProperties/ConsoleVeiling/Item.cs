using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Item
    {
        private string _item = "";
        private int _minPrijs;

        //Propertie Item
        public string NaamItem { get; set; }

        //Propertie Prijs
        public int MinPrijs { get; set; }


        //Constructor
        public Item(string naamItem, int minPrijs)
        {
            NaamItem = naamItem;
            MinPrijs = minPrijs;
        }
    }
}
