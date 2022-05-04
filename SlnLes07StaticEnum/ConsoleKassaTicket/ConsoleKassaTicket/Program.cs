using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKassaTicket
{
    public enum Betaalwijze { Visa, Cash, Bancontact }
    class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket1 = new Ticket(Betaalwijze.Visa, "Annie");

            Product bananen = new Product("bananen" ,(decimal) 1.75 , "P02384" );
            Product brood = new Product("brood", (decimal)2.10, "P01820");
            Product kaas = new Product("kaas", (decimal)3.99, "P45612");
            Product koffie = new Product("koffie", (decimal)4.10, "P98754");

            ticket1.producten.Add(bananen);
            ticket1.producten.Add(brood);
            ticket1.producten.Add(kaas);
            ticket1.producten.Add(koffie);
            ticket1.DrukTicket();
        }
    }
}
