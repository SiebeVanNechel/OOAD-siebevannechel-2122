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

            return $"{uur} - {Klacht}";
        }
    }
}