using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WcfService1
{
    public class BDDPreinscrit
    {
        [DataMember]
        public int IdPreinscrit;
        [DataMember]
        public string Nom;
        [DataMember]
        public string Prenom;
        [DataMember]
        public string Adresse;
        [DataMember]
        public int CodePostal;
        [DataMember]
        public string Ville;
        [DataMember]
        public string DateNaissance;
        [DataMember]
        public string Telephone;
        [DataMember]
        public string Email;
        [DataMember]
        public int Parcours;
        [DataMember]
        public string Club;
        [DataMember]
        public string Ufolep;
        public void Insert(BDDPreinscrit preinscrit)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO preinscrit(Nom,Prenom,Adresse,CodePostal,Ville,DateNaissance,Telephone,Email,Club,Ufolep,Parcours) VALUES(@Nom,@Prenom,@Adresse,@CodePostal,@Ville,@DateNaissance,@Telephone,@Email,@Club,@Ufolep,@Parcours)";
            //{"Nom":"MARC","Prenom":"Jérémy","Adresse":"59 Cours Clemenceau","CodePostal":"76100","Ville":"Rouen","DateNaissance":"02-06-1998","Telephone":"0782062639","Email":"jeremy.marc.pro@gmail.com","Club":"azerty","Parcours":"1"}
            command.Parameters.AddWithValue("Nom", preinscrit.Nom);
            command.Parameters.AddWithValue("Prenom", preinscrit.Prenom);
            command.Parameters.AddWithValue("Adresse", preinscrit.Adresse);
            command.Parameters.AddWithValue("CodePostal", preinscrit.CodePostal);
            command.Parameters.AddWithValue("Ville", preinscrit.Ville);
            command.Parameters.AddWithValue("DateNaissance", preinscrit.DateNaissance);
            command.Parameters.AddWithValue("Telephone", preinscrit.Telephone);
            command.Parameters.AddWithValue("Email", preinscrit.Email);
            command.Parameters.AddWithValue("Club", preinscrit.Club);
            command.Parameters.AddWithValue("Ufolep", preinscrit.Ufolep);
            command.Parameters.AddWithValue("Parcours", preinscrit.Parcours);
            command.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            conn = null;
        }

        public List<BDDPreinscrit> SelectPreinscrit()
        {
            List<BDDPreinscrit> preinscritL = new List<BDDPreinscrit>();
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM preinscrit";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BDDPreinscrit preinscrit = new BDDPreinscrit()
                    {
                        IdPreinscrit = Convert.ToInt32(reader[0]),
                        Nom = reader[1].ToString(),
                        Prenom = reader[2].ToString(),
                        Adresse = reader[3].ToString(),
                        CodePostal = Convert.ToInt32(reader[4]),
                        Ville = reader[5].ToString(),
                        DateNaissance = reader[6].ToString(),
                        Telephone = reader[7].ToString(),
                        Email = reader[8].ToString(),
                        Club = reader[9].ToString(),
                        Ufolep = reader[10].ToString()
                    };
                    preinscritL.Add(preinscrit);
                }
                return preinscritL;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
    }
}