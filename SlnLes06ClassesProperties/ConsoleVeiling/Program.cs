using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    class Program
    {
        static void Main(string[] args)
        {
            Koper koperJef = new Koper("Jef");
            Koper koperJos = new Koper("Jos");
            Koper koperJean = new Koper("Jean");

            Item itemKast = new Item("Kast", 350);
            Item itemStoel = new Item("Stoel", 150);
            Item itemTafel = new Item("Tafel", 400);

            List<Koper> kopers = new List<Koper>();
            kopers.Add(koperJef);
            kopers.Add(koperJos);
            kopers.Add(koperJean);

            List<Item> items = new List<Item>();
            items.Add(itemKast);
            items.Add(itemStoel);
            items.Add(itemTafel);

            List<Bod> bieders = new List<Bod>();

            foreach(Item item in items)
            {
                bool verderBieden = true;
                string naamBieder = "";
                while (verderBieden)
                {
                    int aantalGestopt = 0;
                    Console.WriteLine("== Bieden op " + item.Voorwerp + " vanaf " + item.Bedrag + " euro. ==");
                    foreach (Koper koper in kopers)
                    {
                        Console.WriteLine(koper.NaamKoper + ": Wil je hoger bieden dan " + item.Bedrag + "? (ja/nee)");
                        string hogerBieden = Console.ReadLine();
                        if (hogerBieden == "ja")
                        {
                            Console.WriteLine("Geef een hoger bedrag in dan " + item.Bedrag);
                            int nieuwMinPrijs = int.Parse(Console.ReadLine());
                            while(nieuwMinPrijs < item.Bedrag)
                            {
                                Console.WriteLine("Geef een hoger bedrag in dan " + item.Bedrag);
                                nieuwMinPrijs = int.Parse(Console.ReadLine());
                            }
                            item.Bedrag = nieuwMinPrijs;
                            naamBieder = koper.NaamKoper;
                        }
                        else
                        {
                            aantalGestopt++;
                            if (aantalGestopt == kopers.Count - 1)
                            {
                                verderBieden = false;
                            }
                        }
                    }
                    bieders.Add(new Bod(item.Bedrag, naamBieder, item));
                }
                Console.WriteLine(item.Voorwerp + " is verkocht aan " + item.Bedrag + " euro."+ "\r\n");
            }
            foreach(Bod bod in bieders)
            {
                Console.WriteLine("## " + bod.Item.Voorwerp + " is verkocht aan " + bod.NaamBieder + " voor " + bod.Item.Bedrag + " euro. ##");
            }
            Console.ReadLine();
        }
    }
}
