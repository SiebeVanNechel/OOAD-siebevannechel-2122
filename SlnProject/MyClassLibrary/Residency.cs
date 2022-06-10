using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{

    class Residency
    {
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }
        public int Package_Id { get; set; }
        public int Pet_Id { get; set; }

        // methodes
        public static List<Residency> GetResidency(int loginid)
        {
            List<Residency> residency = new List<Residency>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Residency] WHERE loginid = @par1", conn);
                comm.Parameters.AddWithValue("@par1", loginid);
                SqlDataReader reader = comm.ExecuteReader();

                //lees en verwerkt resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    DateTime startdate = Convert.ToDateTime(reader["startdate"]);
                    DateTime enddate = Convert.ToDateTime(reader["enddate"]);
                    string remarks = Convert.ToString(reader["remarks"]);
                    //string ? remarks = reader["remarks"] == DBNull.Value ? null : (string?)Convert.ToString(reader["remarks"]);

                    residency.Add(new Residency(id, startdate, enddate, remarks));

                }
            }
            return residency;
        }

        public Residency() { }

        public Residency(int id, DateTime startdate, DateTime enddate, string remarks, int packageId, int pet_id)
        {
            Id = id;
            StartDate = startdate;
            EndDate = enddate;
            Remarks = remarks;
            Package_Id = packageId;
            Pet_Id = pet_id;
        }

        public Residency(int id, DateTime startdate, DateTime enddate, string remarks)
        {
            Id = id;
            StartDate = startdate;
            EndDate = enddate;
            Remarks = remarks;
        }
    }
}
