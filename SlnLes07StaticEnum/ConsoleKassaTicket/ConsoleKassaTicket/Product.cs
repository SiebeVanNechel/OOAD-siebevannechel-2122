using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    class Product
    {
        private string _code;
        //Properties
        public string naam { get; set; }
        public decimal eenheidsprijs { get; set; }
        public string code
        {
            get { return _code; }

            set
            {
                if (!ValideerCode(value))
                {
                    throw new ArgumentException("Code is ongeldig");
                }
                else
                {
                    _code = value;
                }
            }
        }

        //Methodes
        private static bool ValideerCode(string str)
        {
            bool correct;
            if (str.Substring(0, 1) != "P" && str.Length != 6)
            {
                correct = false; ;
            }
            else
            {
                correct = true;
            }
            return correct;
        }

        public override string ToString()
        {
            string str = $"({code}) {naam} {eenheidsprijs}";
            return str;
        }

        //Constructor
        public Product(string nm, decimal prijs, string code1)
        {
            naam = nm;
            eenheidsprijs = prijs;
            code = code1;
        }
    }
}
