using System;
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
                command.CommandText = "SELECT preinscrit.Nom, preinscrit.Prenom,portique.idPortique,portique.Temps,preinscrit.Club " +
                    "FROM preinscrit, portique,rfid " +
                    "WHERE rfid.InfoCarte=portique.infoCarte and preinscrit.IdPreinscrit = rfid.idPreinscrit " +
                    "ORDER BY portique.idPortique DESC, portique.Temps ASC";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BDDAffichage affichage = new BDDAffichage
                    {
                        nom = reader[0].ToString(),
                        prenom = reader[1].ToString(),
                        checkpoint = Convert.ToInt32(reader[2]),
                        temps = reader[3].ToString(),
                        club = reader[4].ToString()
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