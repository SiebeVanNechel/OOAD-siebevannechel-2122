using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Bod
    {
        private string _naamBieder;
        
        //Properties
        public string NaamBieder
        {
            get { return _naamBieder; }
            set
            {
                if (_naamBieder == "")
                {
                    throw new ArgumentException("Naam is leeg");
                }
                else
                {
                    _naamBieder = value;
                }
            }
        }
        public Item Item { get; set; }


        //Constructoren
        public Bod(int bedrag, string naambieder, Item item)
        {
            item.Bedrag = bedrag;
            NaamBieder = naambieder;
            Item = item;
        }
    }
}
