using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Pet
    {
        // variabelen
        private static string connString = ConfigurationManager.AppSettings["connString"];
        public string Name { get; set; }

        /*public static List<Pet> GetAllPets()
        {

            //SQL in WPF
        }*/
    }
}
