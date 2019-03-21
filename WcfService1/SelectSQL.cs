using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class SelectSQL
    {
        public string SelectPreinscrit()
        {
            List<Preinscrit> preinscritL = new List<Preinscrit>();
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "SELECT * FROM preinscrit";

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Preinscrit preinscrit = new Preinscrit()
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
                string output = JsonConvert.SerializeObject(preinscritL);

                return output;
            }
            catch (Exception e)
            {
                return e.ToString(); ;
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