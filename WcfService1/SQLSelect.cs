using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WcfService1
{
    public class SQLSelect
    {
        public Stream SelectPreinscrit()
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
                        id = Convert.ToInt32(reader[0]),
                        IdPreinscrit = Convert.ToInt32(reader[1]),
                        Nom = reader[2].ToString(),
                        Prenom = reader[3].ToString(),
                        Adresse = reader[4].ToString(),
                        CodePostal = Convert.ToInt32(reader[5]),
                        Ville = reader[6].ToString(),
                        DateNaissance = reader[7].ToString(),
                        Telephone = reader[8].ToString(),
                        Email = reader[9].ToString(),
                        Club = reader[10].ToString(),
                        Ufolep = reader[11].ToString()
                    };
                    preinscritL.Add(preinscrit);
                }
                string str = JsonConvert.SerializeObject(preinscritL);
                byte[] encoded = Encoding.Default.GetBytes(str);
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                return new MemoryStream(encoded);
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

        public Stream SelectAffichage()
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
                        prenom=reader[2].ToString(),
                        checkpoint=Convert.ToInt32(reader[3]),
                        positionClassement=Convert.ToInt32(reader[4]),
                        temps=reader[5].ToString(),
                        club=reader[6].ToString()
                    };
                }
                string str = JsonConvert.SerializeObject(affichagesL);
                byte[] encoded = Encoding.Default.GetBytes(str);
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                return new MemoryStream(encoded);
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