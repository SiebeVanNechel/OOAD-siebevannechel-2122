using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class User
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        // properties
        public int Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string Role { get; set; }

        // methods
        public static List<User> GetAll()
        {
            // ... get all users from database
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //open connectie
                conn.Open();

                //voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM User", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string firstname = Convert.ToString(reader["firstname"]);
                    string lastname = Convert.ToString(reader["lastname"]);
                    string role = Convert.ToString(reader["role"]);
                    string login = Convert.ToString(reader["login"]);
                    string password = Convert.ToString(reader["password"]);
                    DateTime createDate = Convert.ToDateTime(reader["create_date"]);
                    users.Add(new User(login, password,firstname, lastname, createDate, role));
                }
                return users;
            }
        }
       /* public static User FindById(int userId)
        {
            // ... find user in database
        }
        public void DeleteFromDb()
        {
            // ... delete current user from database 
        }
        public int InsertToDb()
        {
            // ... add current user to database and return id
            string connString = ConfigurationManager.AppSettings["connString"];

            //vind id van geselecteerde user
            //string selected = (string)lbxResults.SelectedItem;
            //string[] parts = selected.Split(:);
           // int id = Convert.ToInt32(parts[0]);

            //verwijder user
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM User WHERE ID = @par1", conn);
               // comm.Parameters.AddWithValue("@par1", id);
                comm.ExecuteNonQuery();
                //lbxResults.Items.Remove(lbxResults.SelectedItem);
            }
        }
        public void UpdateInDb()
        {
            // ... update current user in database 
            string connString = ConfigurationManager.AppSettings["connString"];

            //voeg user toe
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand comm = new SqlCommand(
                @"UPDATE User
                SET firstname=@par1, lastname=@par2, role=@par3
                WHERE ID = @par4", conn
                );
                comm.Parameters.AddWithValue("@par1", txtFirst.Text);
                comm.Parameters.AddWithValue("@par2", txtLast.Text);
                comm.Parameters.AddWithValue("@par3", txtRole.Text);
            }
        }*/

        // constructors
        public User(string login, string password, string firstname, string lastname, DateTime create_date, string role)
        {
            Login = login;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            CreateDate = create_date;
            Role = role;
        }
    }
}
