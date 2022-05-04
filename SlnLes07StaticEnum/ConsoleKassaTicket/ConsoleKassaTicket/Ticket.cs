using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    class Ticket
    {
        private string _betaaldMet = "Cash";
        //Properties
        public List<Product> producten { get; set; } = new List<Product>();
        public Betaalwijze betaaldMet { get; set; }
        public string kassierster { get; set; }
        public decimal totaalprijs { get; }
        //Methode
        public void DrukTicket()
        {
            decimal extraKosten = 0;
            decimal totaal = 0;
            if (Betaalwijze.Visa==betaaldMet)
            {
                extraKosten = (decimal)0.12;
            }
            Console.WriteLine($@"KASSATICKET
===========
Uw kassier: {kassierster}
");

            foreach (Product product in producten)
            {
                Console.WriteLine(product);
                totaal += (decimal)product.eenheidsprijs;
            }
            Console.WriteLine("\r\n" + "-----------");
            Console.WriteLine("Visa kosten: " + extraKosten);
            totaal += extraKosten;
            Console.WriteLine("Totaal: " + totaal);
            Console.ReadKey();
        }
        //Constructor
        public Ticket(Betaalwijze betaaloptie, string kassier)
        {
            betaaldMet = betaaloptie;
            kassierster = kassier;
        }
    }
}
