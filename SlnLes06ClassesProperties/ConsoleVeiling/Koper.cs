using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Koper
    {
        private string _naamKoper;
        //Properties
        public string NaamKoper {
            get { return _naamKoper; }
            set
            {
                if (_naamKoper == "")
                {
                    throw new ArgumentException("Naam is leeg");
                }
                else
                {
                    _naamKoper = value;
                }
            } 
        }

        //Constructoren
        public Koper(string naamKoper)
        {
            NaamKoper = naamKoper;
        }

    }
}
