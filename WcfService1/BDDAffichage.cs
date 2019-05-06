using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WcfService1
{
    public class BDDAffichage
    {
        public string nom;
        public string prenom;
        public int checkpoint;
        public int positionClassement;
        public string temps;
        public string club;

        public List<BDDAffichage> SelectAffichage()
        {
            List<BDDAffichage> affichagesL = new List<BDDAffichage>();
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
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