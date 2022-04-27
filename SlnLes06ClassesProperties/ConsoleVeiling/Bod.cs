using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Bod
    {
        private int _prijsbod;
        private string _naamBieder = "";
        private string _naamItem = "";
        
        //Properties
        public int PrijsBod
        {
            get { return _prijsbod; }
            set
            {
                try
                {
                    _prijsbod = value;
                    if(_prijsbod < 0)
                    {
                        throw new ArgumentException("Prijs mag niet negatief zijn.");
                    }
                }
                catch(Exception ex)
                {
                    throw new ArgumentException("Prijs is ongeldig");
                }
            }
        }
        public string NaamBieder
        {
            get { return _naamBieder; }
            set
            {
                try
                {
                    if (_naamBieder == "")
                    {
                        throw new ArgumentException("Naam is leeg");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Naam bieder is ongeldig");
                }
            }
        }
        public string NaamItem
        {
            get { return _naamItem; }
            set
            {
                try
                {
                    if (_naamItem == "")
                    {
                        throw new ArgumentException("Naam is leeg");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Naam item is ongeldig");
                }
            }
        }


        //Constructoren
        public Bod(int prijsbod, string naambieder, string naamitem)
        {
            PrijsBod = prijsbod;
            NaamBieder = naambieder;
            NaamItem = naamitem;
        }
    }
}
