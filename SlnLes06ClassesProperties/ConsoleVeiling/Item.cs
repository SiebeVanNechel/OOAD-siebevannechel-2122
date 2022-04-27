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
        public string NaamItem
        {
            get { return _item; }
            set
            {
                try
                {
                    if (_item == "")
                    {
                        throw new ArgumentException("Item is leeg");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Item is ongeldig");
                }
            }
        }

        //Propertie Prijs
        public int MinPrijs
        {
            get { return _minPrijs; }
            set
            {
                try
                {
                    _minPrijs = value;
                    if (_minPrijs < 0)
                    {
                        throw new ArgumentException("Prijs mag niet negatief zijn.");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Prijs is ongeldig");
                }
            }
        }


        //Constructor
        public Item(string naamItem, int minPrijs)
        {
            NaamItem = naamItem;
            MinPrijs = minPrijs;
        }
    }
}
