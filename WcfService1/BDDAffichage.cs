﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    public class BDDAffichage
    {
        [DataMember]
        public string nom;
        [DataMember]
        public string prenom;
        [DataMember]
        public int checkpoint;
        [DataMember]
        public int positionClassement;
        [DataMember]
        public string temps;
        [DataMember]
        public string club;

        public List<BDDAffichage> SelectAffichage()
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            try
            {
                List<BDDAffichage> affichagesL = new List<BDDAffichage>();
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT preinscrit.nom, preinscrit.prenom, ,";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BDDAffichage affichage = new BDDAffichage
                    {
                        nom = reader[1].ToString(),
                        prenom = reader[2].ToString(),
                        checkpoint = Convert.ToInt32(reader[3]),
                        positionClassement = Convert.ToInt32(reader[4]),
                        temps = reader[5].ToString(),
                        club = reader[6].ToString()
                    };
                    affichagesL.Add(affichage);
                }
                return affichagesL;
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