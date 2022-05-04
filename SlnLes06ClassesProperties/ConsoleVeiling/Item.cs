using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Item
    {
        private string _item;
        private int _bedrag;

        //Propertie Item
        public string Voorwerp
        {
            get { return _item; }
            set
            {
                if (_item == "")
                {
                    throw new ArgumentException("Item is leeg");
                }
                else
                {
                    _item = value;
                }
            }
        }

        //Propertie Prijs
        public int Bedrag
        {
            get { return _bedrag; }
            set
            {   
                if (_bedrag < 0)
                {
                    throw new ArgumentException("Prijs mag niet negatief zijn.");
                }
                _bedrag = value;
            }
        }


        //Constructor
        public Item(string item, int bedrag)
        {
            _item = item;
            Bedrag = bedrag;
        }
    }
}
