using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokterspraktijkClassLibrary
{
    public class Dokter
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        // properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Paswoord { get; set; }
        public string Profieldata { get; set; }
        public int Rizivnummer { get; set; }
        public byte Isgeconventioneerd { get; set; }

        // methods
        public static List<Dokter> GetAll()
        {
            // ... get all dokters from database
            List<Dokter> dokters = new List<Dokter>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //open connectie
                conn.Open();

                //voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam, gsm, email, paswoord, rizivnummer, isgeconventioneerd FROM [Dokter]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string voornaam = Convert.ToString(reader["voornaam"]);
                    string achternaam = Convert.ToString(reader["achternaam"]);
                    string gsm = Convert.ToString(reader["gsm"]);
                    string email = Convert.ToString(reader["email"]);
                    string paswoord = Convert.ToString(reader["paswoord"]);
                    int rizivnummer = Convert.ToInt32(reader["rizivnummer"]);
                    byte isgeconventioneerd = Convert.ToByte(reader["isgeconventioneerd"]);
                    dokters.Add(new Dokter(id, voornaam, achternaam, gsm, email, paswoord, rizivnummer,isgeconventioneerd));
                }
                return dokters;
            }
        }
        // constructoren

        public Dokter() { }

        public Dokter(int id, string voornaam, string achternaam, string gsm, string email, string paswoord, int rizivnummer, byte isgeconventioneerd)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Rizivnummer = rizivnummer;
            Isgeconventioneerd = isgeconventioneerd;
        }

        public Dokter(int id, string voornaam, string achternaam, string gsm, string email, string paswoord, string profieldata, int rizivnummer, byte isgeconventioneerd)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Profieldata = profieldata;
            Rizivnummer = rizivnummer;
            Isgeconventioneerd = isgeconventioneerd;
        }
    }
}
