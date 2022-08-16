using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DokterspraktijkClassLibrary
{
    class Patient
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        // properties
        public int Id { get; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int Geslacht { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Passwoord { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Imgage { get; set; }
        public int Notificaties { get; set; }
    }
}
