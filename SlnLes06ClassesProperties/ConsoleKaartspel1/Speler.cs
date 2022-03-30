using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Speler
    {
        //Properties
        public string Naam { get; set; }
        public List<Kaart> Kaarten { get; set; } = new List<Kaart>();
        private bool _heeftnogkaarten;
        public bool HeeftNogKaarten
        {
            get
            {
                _heeftnogkaarten = Kaarten.Count <= 0 ? false : true;
                return _heeftnogkaarten;
            }
        }

        //Constructoren
        public Speler(string naam)
        {
            Naam = naam;
        }
        public Speler(string naam, List<Kaart> kaarten)
        {
            Naam = naam;
            Kaarten = kaarten;
        }
        
        //Methode LegKaart
        public Kaart LegKaart()
        {
            Random rnd = new Random();
            Kaart TeLeggenKaart = Kaarten[rnd.Next(0, Kaarten.Count())];
            Kaarten.Remove(TeLeggenKaart);
            return TeLeggenKaart;
        }
    }
}
