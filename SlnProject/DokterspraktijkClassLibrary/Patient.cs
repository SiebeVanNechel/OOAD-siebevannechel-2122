﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DokterspraktijkClassLibrary
{
    public class Patient
    {
        // variabelen
        public static string connString = ConfigurationManager.AppSettings["connStr"];
        public enum Gendertype { Onbekent = 0, Man = 1, Vrouw = 2, Nvt = 9 }

        // properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public Gendertype Geslacht { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Paswoord { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Image { get; set; }
        public int Notificaties { get; set; }

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
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam, geslacht, gsm, email, paswoord, geboortedatum, notificaties FROM [Patient]", conn);
                SqlDataReader reader = comm.ExecuteReader();

                // lees en verwerk de resultaten
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string voornaam = Convert.ToString(reader["voornaam"]);
                    string achternaam = Convert.ToString(reader["achternaam"]);
                    Gendertype geslacht = (Gendertype)Convert.ToInt32(reader["Geslacht"]);
                    string gsm = Convert.ToString(reader["gsm"]);
                    string email = Convert.ToString(reader["email"]);
                    string paswoord = Convert.ToString(reader["paswoord"]);
                    DateTime geboortedatum = Convert.ToDateTime(reader["geboortedatum"]);
                    // string image = Convert.ToString(reader["image"]);
                    int notificaties = Convert.ToInt32(reader["notificaties"]);
                    patienten.Add(new Patient(id, voornaam, achternaam, geslacht, gsm, email, paswoord, geboortedatum, notificaties));
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
                SqlCommand comm = new SqlCommand("SELECT id, voornaam, achternaam, geslacht, gsm, email, paswoord, geboortedatum, notificaties FROM [Patient] WHERE Id = @parID", conn);
                comm.Parameters.AddWithValue("@parID", id);
                SqlDataReader reader2 = comm.ExecuteReader();

                // lees en verwerk resultaten
                while (reader2.Read())
                {
                    patient.Id = Convert.ToInt32(reader2["id"]);
                    patient.Voornaam = Convert.ToString(reader2["voornaam"]);
                    patient.Achternaam = Convert.ToString(reader2["achternaam"]);
                    patient.Geslacht = (Gendertype)Convert.ToInt32(reader2["geslacht"]);
                    /* int? gsm = reader2["gsm"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader2["gsm"]);
                     patient.Gsm = gsm;*/
                    patient.Gsm = Convert.ToString(reader2["gsm"]);
                    patient.Email = Convert.ToString(reader2["email"]);
                    patient.Paswoord = Convert.ToString(reader2["paswoord"]);
                    patient.Geboortedatum = Convert.ToDateTime(reader2["geboortedatum"]);
                    patient.Notificaties=Convert.ToInt32(reader2["notificaties"]);
                }
                return patient;
            }
        }

        // constructors

        public Patient() { }

        public Patient( string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, string image, int notificaties)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geslacht = geslacht;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Geboortedatum = geboortedatum;
            Image = image;
            Notificaties = notificaties;
        }

        public Patient(int id, string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, string image, int notificaties)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geslacht = geslacht;
            Gsm = gsm;
            Email = email;
            Paswoord = paswoord;
            Geboortedatum = geboortedatum;
            Image = image;
            Notificaties = notificaties;
        }

        public Patient(int id, string voornaam, string achternaam, Gendertype geslacht, string gsm, string email, string paswoord, DateTime geboortedatum, int notificaties)
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
