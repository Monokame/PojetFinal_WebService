using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    public class BDDValidation
    {
        [DataMember]
        public int infoCarte;
        [DataMember]
        public int idPreinscrit;

        public string InsertValidation(BDDValidation validation)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO rfid(InfoCarte,idPreinscrit) VALUES(@infoCarte,@idPreinscrit)";
                command.Parameters.AddWithValue("InfoCarte", validation.infoCarte);
                command.Parameters.AddWithValue("idPreinscrit", validation.infoCarte);
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