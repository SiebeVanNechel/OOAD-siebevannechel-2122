using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] namen = { "Siebe", "Piet", "Jonas", "Floris", "Joost", "Mieke" };
            string[] spel = { "Schaak", "Dammen", "Backgammon" };

            List<string> lines = new List<string>();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "spel.csv");

            for (int i = 1; i <= 100; i++)
            {
                //Random spel en spelers bepalen
                string speler1 = namen[rnd.Next(0, 6)];
                string speler2 = namen[rnd.Next(0, 6)];
                string spelkeuze = spel[rnd.Next(0, 3)];
                int score1 = rnd.Next(0, 3);
                int score2 = 3 - score1;

                //Wedstrijd toevoegen aan list
                lines.Add($"{i};{speler1};{speler2};{spelkeuze};{score1}-{score2}");
            }

            using (StreamWriter writer = File.CreateText(filePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }

            }
        }
    }
}
