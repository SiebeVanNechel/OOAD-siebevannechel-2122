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
        public int Id { get; set; }
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
                SqlCommand comm = new SqlCommand("SELECT * FROM [User]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string firstname = Convert.ToString(reader["firstname"]);
                    string lastname = Convert.ToString(reader["lastname"]);
                    string role = Convert.ToString(reader["role"]);
                    string login = Convert.ToString(reader["login"]);
                    string password = Convert.ToString(reader["password"]);
                    DateTime createDate = Convert.ToDateTime(reader["createdate"]);
                    users.Add(new User(id, login, password, firstname, lastname, createDate, role));
                }
                return users;
            }
        }
        public static User FindById(int id)
        {
            User user = new User();
            // ... find user in database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [User] WHERE ID = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    user.Id = Convert.ToInt32(reader2["Id"]);
                    user.Firstname = Convert.ToString(reader2["firstname"]);
                    user.Lastname = Convert.ToString(reader2["lastname"]);
                    user.Login = Convert.ToString(reader2["login"]);
                    user.CreateDate = Convert.ToDateTime(reader2["createdate"]);
                    user.Role = Convert.ToString(reader2["role"]);
                }
                return user;
            }
        }
         public void DeleteFromDb()
         {
            // verwijder user
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [User] WHERE i = @parID", conn);
                comm.Parameters.AddWithValue("@parID", Id);
                comm.ExecuteNonQuery();
            }
         }

        public int InsertToDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(
                  "INSERT INTO [User](firstname, lastname, login, password, createdate, role) output INSERTED.Id VALUES(@par1,@par2,@par3,@par4,@par5,@par6)", conn);
                comm.Parameters.AddWithValue("@par1", Firstname);
                comm.Parameters.AddWithValue("@par2", Lastname);
                comm.Parameters.AddWithValue("@par3", Login);
                comm.Parameters.AddWithValue("@par4", Password);
                comm.Parameters.AddWithValue("@par5", CreateDate);
                comm.Parameters.AddWithValue("@par6", Role);
                return (int)comm.ExecuteScalar();
            }
        }
        public void UpdateInDb()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // STANDARD QUERY VERSION
                SqlCommand comm = new SqlCommand(
                    @"UPDATE [User]
                        SET lastname=@par1, firstname=@par2, role=@par3, createdate=@par4, login=@par5 WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@par1", Lastname);
                comm.Parameters.AddWithValue("@par2", Firstname);
                comm.Parameters.AddWithValue("@par3", Role);
                comm.Parameters.AddWithValue("@par4", CreateDate);
                comm.Parameters.AddWithValue("@par5", Login);
                comm.Parameters.AddWithValue("parID", Id);
                comm.ExecuteNonQuery();
            }
        }

        // constructors
        public User(int id, string login, string password, string firstname, string lastname, DateTime create_date, string role)
        {
            Id = id;
            Login = login;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            CreateDate = create_date;
            Role = role;
        }

        public User(string login, string firstname, string lastname, DateTime create_date, string role)
        {
            Login = login;
            Firstname = firstname;
            Lastname = lastname;
            CreateDate = create_date;
            Role = role;
        }

        public User() { }

        public override string ToString()
        {
            return $"{Id}: {Firstname} {Lastname}";
        }
    }
}
