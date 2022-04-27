using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Koper
    {
        private string _naamKoper = "";
        //Properties
        public string NaamKoper {
            get { return _naamKoper; }
            set
            {
                try
                {
                    if (_naamKoper == "")
                    {
                        throw new ArgumentException("Naam is leeg");
                    }
                }
                catch(Exception ex)
                {
                    throw new ArgumentException("Naam is ongeldig");
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
