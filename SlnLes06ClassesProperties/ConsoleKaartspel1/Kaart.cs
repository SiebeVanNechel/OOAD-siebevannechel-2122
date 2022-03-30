using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Kaart
    {
        private int _nummer;
        private char _kleur;

        //propertie Nummer
        public int Nummer
        {
            get { return _nummer; }
            set
            {
                if (value < 1 && value > 13)
                {
                    throw new ArgumentOutOfRangeException($"Nummer moet tussen 1 en 13 liggen.");
                }
                _nummer = value;
            } 
        }

        //propertie Kleur
        public char Kleur
        {
            get { return _kleur; }
            set
            {
                if (value == 'C' || value == 'S' || value == 'H' || value == 'D')
                {
                    throw new ArgumentOutOfRangeException($"Kleur moet C, S, H of D zijn.");
                }
                _kleur = value;
            }
        }

        //Constructor nummer + kleur
        public Kaart(char kleur,int nummer)
        {
            Nummer = nummer;
            Kleur = kleur;
        }
    }
}
