using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace DokterspraktijkClassLibrary
{
    public class Patient
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];
        public enum Gendertype { Man = 1, Vrouw = 2 }
        public enum Notificationtype { Email = 2, Gsm = 3 }

        // properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public Gendertype Geslacht { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Paswoord { get; set; }
        public DateTime Geboortedatum { get; set; }
        public BitmapImage Profielfotodata { get; set; }
        public Notificationtype Notificaties { get; set; }

        // methods
        public static List<Patient> GetAll()
        {
            // ... get all patients from database
            List<Patient> patienten = new List<Patient>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //open connectie
                conn.Open();

                //voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam, geslacht, gsm, email, paswoord, geboortedatum, profielfotodata, notificaties FROM [Patient]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string voornaam = Convert.ToString(reader["voornaam"]);
                    string achternaam = Convert.ToString(reader["achternaam"]);
                    Gendertype geslacht = (Gendertype)Convert.ToInt32(reader["Geslacht"]);
                    string gsm = reader["gsm"] == DBNull.Value ? null : (string)Convert.ToString(reader["gsm"]);
                    string email = Convert.ToString(reader["email"]);
                    string paswoord = Convert.ToString(reader["paswoord"]);
                    DateTime geboortedatum = Convert.ToDateTime(reader["geboortedatum"]);

                    BitmapImage bitmapImg = new BitmapImage();

                    if (reader["profielfotodata"] == DBNull.Value)
                    {
                        bitmapImg = null;
                    }
                    else
                    {
                        bitmapImg.BeginInit();
                        bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImg.StreamSource = new System.IO.MemoryStream((byte[])reader["profielfotodata"]);
                        bitmapImg.EndInit();
                    }
                    Notificationtype notificaties = (Notificationtype)Convert.ToInt32(reader["notificaties"]);
                    patienten.Add(new Patient(id, voornaam, achternaam, geslacht, gsm, email, paswoord, geboortedatum, bitmapImg, notificaties));
                }
                return patienten;
            }
        }

        public static Patient FindById(int id)
        {
            Patient patient = new Patient();
            // ... find pets in database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Patient] WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    patient.Id = Convert.ToInt32(reader2["id"]);
                    patient.Voornaam = Convert.ToString(reader2["voornaam"]);
                    patient.Achternaam = Convert.ToString(reader2["achternaam"]);
                    patient.Geslacht = (Gendertype)Convert.ToInt32(reader2["geslacht"]);
                    patient.Gsm = reader2["gsm"] == DBNull.Value ? null : Convert.ToString(reader2["gsm"]);
                    patient.Email = Convert.ToString(reader2["email"]);
                    patient.Paswoord = Convert.ToString(reader2["paswoord"]);
                    patient.Geboortedatum = Convert.ToDateTime(reader2["geboortedatum"]);

                    BitmapImage bitmapImg = new BitmapImage();

                    if (reader2["profielfotodata"] == DBNull.Value)
                    {
                        patient.Profielfotodata = null;
                    }
                    else
                    {
                        bitmapImg.BeginInit();
                        bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImg.StreamSource = new System.IO.MemoryStream((byte[])reader2["profielfotodata"]);
                        bitmapImg.EndInit();
                        patient.Profielfotodata = bitmapImg;
                    }
                    patient.Notificaties=(Notificationtype)Convert.ToInt32(reader2["notificaties"]);
                }
                return patient;
            }
        }

        public int InsertToDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                  "INSERT INTO [Patient](email, gsm, notification) output INSERTED.Id VALUES(@par1,@par2,@par3)", conn);
                comm.Parameters.AddWithValue("@par1", Email);
                comm.Parameters.AddWithValue("@par2", Gsm);
                comm.Parameters.AddWithValue("@par3", Notificaties);

                return (int)comm.ExecuteScalar();
            }
        }
        public void WijzigAfbeelding()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                UploadFoto(openFileDialog.FileName);
            }
        }

        private void UploadFoto(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("UPDATE dbo.[Patient] SET profielfotodata=@par1 WHERE id=@parID", conn);
                comm.Parameters.AddWithValue("@par1", data);
                comm.Parameters.AddWithValue("@parID", Id);
                comm.ExecuteNonQuery();
            }
        }

        public void UpdateInDbDoorGebruiker(int ID, string Email, string Gsm, int Notificaties)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // STANDARD QUERY VERSION
                SqlCommand comm = new SqlCommand(
                    @"UPDATE Patient
                        SET email=@par1, gsm=@par2, notificaties=@par3 
                        WHERE ID = @parID"
                    , conn);
                comm.Parameters.AddWithValue("@par1", Email);
                if (Gsm == null)
                {
                    comm.Parameters.AddWithValue("@par2", DBNull.Value);
                }
                else
                {
                    comm.Parameters.AddWithValue("@par2", Gsm);
                }
                comm.Parameters.AddWithValue("@par3", Notificaties);
                comm.Parameters.AddWithValue("parID", ID);
                comm.ExecuteNonQuery();
            }
        }

        public void UpdateInDbDoorDokter(int ID, string Voornaam, string Achternaam, int Geslacht, DateTime Geboortedatum)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // STANDARD QUERY VERSION
                SqlCommand comm = new SqlCommand(
                    @"UPDATE Patient
                        SET voornaam=@par1, achternaam=@par2, geslacht=@par3, geboortedatum=@par4 
                        WHERE ID = @parID"
                    , conn);
                comm.Parameters.AddWithValue("@par1", Voornaam);
                comm.Parameters.AddWithValue("@par2", Achternaam);
                comm.Parameters.AddWithValue("@par3", Geslacht);
                comm.Parameters.AddWithValue("@par4", Geboortedatum);
                comm.Parameters.AddWithValue("parID", ID);
                comm.ExecuteNonQuery();
            }
        }

        public void DeleteFromDb()
        {
            // verwijder patient
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Patient WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", Id);
                comm.ExecuteNonQuery();
            }
        }

        // constructors

        public Patient() { }

        public Patient( string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, BitmapImage image, Notificationtype notificaties)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geslacht = geslacht;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Geboortedatum = geboortedatum;
            Profielfotodata = image;
            Notificaties = notificaties;
        }

        public Patient(int id, string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, BitmapImage image, Notificationtype notificaties)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geslacht = geslacht;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Geboortedatum = geboortedatum;
            Profielfotodata = image;
            Notificaties = notificaties;
        }

        public Patient(int id, string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, Notificationtype notificaties)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geslacht = geslacht;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Geboortedatum = geboortedatum;
            Notificaties = notificaties;
        }
    }
}
