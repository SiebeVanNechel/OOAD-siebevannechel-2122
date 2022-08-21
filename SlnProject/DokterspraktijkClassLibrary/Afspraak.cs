using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokterspraktijkClassLibrary
{
    public class Afspraak
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        // properties
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public string Klacht { get; set; }
        public int PatientId { get; set; }
        public int DokterId { get; set; }

        // methods
        public static List<Afspraak> GetAll()
        {
            // ... get all dokters from database
            List<Afspraak> afspraken = new List<Afspraak>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //open connectie
                conn.Open();

                //voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT id, moment, klacht, patient_id, dokter_id FROM [Afspraak]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    DateTime moment = Convert.ToDateTime(reader["moment"]);
                    string klacht = Convert.ToString(reader["klacht"]);
                    int patientid = Convert.ToInt32(reader["patient_id"]);
                    int dokterid = Convert.ToInt32(reader["dokter_id"]);
                    afspraken.Add(new Afspraak(id, moment, klacht, patientid, dokterid));
                }
                return afspraken;
            }

        }

        public static Afspraak FindById(int id)
        {
            Afspraak afspraak = new Afspraak();
            // ... find pets in database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Afspraak] WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    afspraak.Id = Convert.ToInt32(reader2["id"]);
                    afspraak.Moment = Convert.ToDateTime(reader2["moment"]);
                    afspraak.Klacht = Convert.ToString(reader2["klacht"]);
                    afspraak.PatientId = Convert.ToInt32(reader2["patient_id"]);
                    afspraak.DokterId = Convert.ToInt32(reader2["dokter_id"]);
                }
                return afspraak;
            }
        }

        public int InsertToDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                  "INSERT INTO Afspraak(moment, klacht, patient_id, dokter_id) output INSERTED.ID VALUES(@par1,@par2,@par3,@par4)", conn);
                comm.Parameters.AddWithValue("@par1", Moment);
                comm.Parameters.AddWithValue("@par2", Klacht);
                comm.Parameters.AddWithValue("@par3", PatientId);
                comm.Parameters.AddWithValue("@par4", DokterId);

                return (int)comm.ExecuteScalar();
            }
        }

        public void DeleteFromDb()
        {
            // verwijder afspraak
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM Afspraak WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", Id);
                comm.ExecuteNonQuery();
            }
        }
        public Afspraak() { }

        public Afspraak(int id, DateTime moment, string klacht, int patientid, int dokterid)
        {
            Id = id;
            Moment = moment;
            Klacht = klacht;
            PatientId = patientid;
            DokterId = dokterid;
        }

        public Afspraak(int id, DateTime moment, string klacht)
        {
            Id = id;
            Moment = moment;
            Klacht = klacht;
        }

        public override string ToString()
        {
            string uur = Moment.ToString("HH:mm");
            string naam = "";
            List<Patient> patienten = Patient.GetAll();
            foreach(Patient patient in patienten)
            {
                if (patient.Id==PatientId)
                {
                    naam = patient.Voornaam + " " + patient.Achternaam;
                }
            }
            Patient.GetAll();
            return $"{uur} - {naam}";
        }
    }
}