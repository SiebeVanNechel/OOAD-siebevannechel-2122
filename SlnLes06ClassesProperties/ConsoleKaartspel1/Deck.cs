using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel1
{
    class Deck
    {
        //Property kaarten
        public List<Kaart> Kaarten { get; set; } = new List<Kaart>();
        private Random rand = new Random();
        private static readonly object syncLock = new object();

        //Constructor vullKaarten
        public Deck()
        {
            char[] soortKaart = { 'C', 'S', 'H', 'D' };
            for (int i = 0; i < soortKaart.Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Kaart newKaart = new Kaart(soortKaart[j], i);
                    Kaarten.Add(newKaart);
                }
            }
        }

        //Methode Scudden
        public int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return rand.Next(min, max);
            }
        }
        public void Schudden()
        {
            for (int i = 0; i < Kaarten.Count; i++)
            {
                //FisherYates in-place shuffle
                var temp = Kaarten[i];
                var index = RandomNumber(0, Kaarten.Count);
                Kaarten[i] = Kaarten[index];
                Kaarten[index] = temp;
            }
        }

        //Methode NeemKaart
        public Kaart NeemKaart()
        {
            Random rnd = new Random();
            Kaart GetrokkenKaart = Kaarten[rnd.Next(0, Kaarten.Count())];
            Kaarten.Remove(GetrokkenKaart);
            return GetrokkenKaart;
        }
    }
}
