using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Pet
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];

        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int Sex { get; set; }
        public int? Size { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public string TypeName { get; set; }


        // methodes
        public static List<Pet> GetPets(int userid)
        {
            List<Pet> pets = new List<Pet>();
            using(SqlConnection conn= new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Pet] WHERE user_id = @par1", conn);
                comm.Parameters.AddWithValue("@par1", userid);
                SqlDataReader reader = comm.ExecuteReader();

                //lees en verwerkt resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = Convert.ToString(reader["name"]);
                    string remarks = Convert.ToString(reader["remarks"]);
                    int sex = Convert.ToInt32(reader["sex"]);
                    int? size = reader["size"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["size"]);
                    int age = Convert.ToInt32(reader["age"]);
                    int user_id = Convert.ToInt32(reader["user_id"]);
                    string typename = Convert.ToString(reader["type_name"]);
                    
                    pets.Add(new Pet(id, name, remarks, sex, size, age, user_id, typename));
                   
                }
            }
            return pets;
        }

        public static Pet FindById(int id)
        {
            Pet pet = new Pet();
            // ... find pets in database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // open connectie
                conn.Open();

                // voer SQL commando uit
                SqlCommand comm = new SqlCommand("SELECT * FROM [Pet] WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    pet.Id = Convert.ToInt32(reader2["id"]);
                    pet.Name = Convert.ToString(reader2["name"]);
                    pet.Remarks = Convert.ToString(reader2["remarks"]);
                    pet.Sex = Convert.ToInt32(reader2["sex"]);
                    pet.Size = Convert.ToInt32(reader2["size"]);
                    pet.Age = Convert.ToInt32(reader2["age"]);
                    pet.UserId = Convert.ToInt32(reader2["user_id"]);
                    pet.TypeName = Convert.ToString(reader2["type_name"]);
                }
                return pet;
            }
        }


        // constructoren
        public Pet(int id, string name, string remarks, int sex, int? size, int age, int userid, string typename)
        {
            Id = id;
            Name = name;
            Remarks = remarks;
            Sex = sex;
            Age = age;
            UserId = userid;
            TypeName = typename;
        }

        public Pet() { }



        public override string ToString()
        {
            return $"{Id}: {TypeName} {Name}";
        }
    }
}
