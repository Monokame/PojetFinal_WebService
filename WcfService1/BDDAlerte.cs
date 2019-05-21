using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WcfService1
{
    public class BDDAlerte
    {
        [DataMember]
        public string alerte;
        public string InsertAlerte(BDDAlerte alerte)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO alerte (alerte) VALUES (@alerte)";
                command.Parameters.AddWithValue("alerte", alerte.alerte);
                command.ExecuteNonQuery();
                return "Success";
            }
            catch (Exception e)
            {
                return e.ToString();
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