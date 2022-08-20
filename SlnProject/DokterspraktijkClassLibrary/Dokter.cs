using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        public BitmapImage Profielfotodata { get; set; }
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
                SqlCommand comm = new SqlCommand("SELECT * FROM [Dokter]", conn);
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

                    BitmapImage bitmapImg = new BitmapImage();
                    bitmapImg.BeginInit();
                    bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImg.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfotodata"]);
                    bitmapImg.EndInit();

                    int rizivnummer = Convert.ToInt32(reader["rizivnummer"]);
                    byte isgeconventioneerd = Convert.ToByte(reader["isgeconventioneerd"]);
                    dokters.Add(new Dokter(id, voornaam, achternaam, gsm, email, paswoord, bitmapImg, rizivnummer,isgeconventioneerd));
                }
                return dokters;
            }
        }

        public static Dokter FindById(int id)
        {
            Dokter dokter = new Dokter();

            // ... find pets in database
            using (SqlConnection conn = new SqlConnection(connString))
            {

                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Dokter] WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    dokter.Id = Convert.ToInt32(reader2["id"]);
                    dokter.Voornaam = Convert.ToString(reader2["voornaam"]);
                    dokter.Achternaam = Convert.ToString(reader2["achternaam"]);
                    dokter.Gsm = reader2["gsm"] == DBNull.Value ? null : Convert.ToString(reader2["gsm"]);
                    dokter.Email = Convert.ToString(reader2["email"]);
                    dokter.Paswoord = Convert.ToString(reader2["paswoord"]);

                    BitmapImage bitmapImg = new BitmapImage();

                    if (reader2["profielfotodata"] == DBNull.Value)
                    {
                        dokter.Profielfotodata = null;
                    }
                    else
                    {
                        bitmapImg.BeginInit();
                        bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImg.StreamSource = new System.IO.MemoryStream((byte[])reader2["profielfotodata"]);
                        bitmapImg.EndInit();
                        dokter.Profielfotodata = bitmapImg;
                    }
                    dokter.Rizivnummer = Convert.ToInt32(reader2["rizivnummer"]);
                    dokter.Isgeconventioneerd = Convert.ToByte(reader2["isgeconventioneerd"]);
                }
                return dokter;
            }
        }

        public static Dokter FindByName(string naam)
        {
            Dokter dokter = new Dokter();

            // ... find pets in database
            using (SqlConnection conn = new SqlConnection(connString))
            {

                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Dokter] WHERE Voornaam = @parVOORNAAM", conn);
                comm.Parameters.AddWithValue("@parVOORNAAM", naam);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    dokter.Id = Convert.ToInt32(reader2["id"]);
                    dokter.Voornaam = Convert.ToString(reader2["voornaam"]);
                    dokter.Achternaam = Convert.ToString(reader2["achternaam"]);
                    dokter.Gsm = reader2["gsm"] == DBNull.Value ? null : Convert.ToString(reader2["gsm"]);
                    dokter.Email = Convert.ToString(reader2["email"]);
                    dokter.Paswoord = Convert.ToString(reader2["paswoord"]);

                    BitmapImage bitmapImg = new BitmapImage();

                    if (reader2["profielfotodata"] == DBNull.Value)
                    {
                        dokter.Profielfotodata = null;
                    }
                    else
                    {
                        bitmapImg.BeginInit();
                        bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImg.StreamSource = new System.IO.MemoryStream((byte[])reader2["profielfotodata"]);
                        bitmapImg.EndInit();
                        dokter.Profielfotodata = bitmapImg;
                    }
                    dokter.Rizivnummer = Convert.ToInt32(reader2["rizivnummer"]);
                    dokter.Isgeconventioneerd = Convert.ToByte(reader2["isgeconventioneerd"]);
                }
                return dokter;
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

        public Dokter(int id, string voornaam, string achternaam, string gsm, string email, string paswoord, BitmapImage profieldata, int rizivnummer, byte isgeconventioneerd)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Profielfotodata = profieldata;
            Rizivnummer = rizivnummer;
            Isgeconventioneerd = isgeconventioneerd;
        }
    }
}
