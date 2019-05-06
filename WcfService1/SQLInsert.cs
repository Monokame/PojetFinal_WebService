using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WcfService1
{
    public class SQLInsert
    {
        public string InsertXbee(string str)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO portique (idPortique,infoCarte,Temps) VALUES (@portique,@carteId, @date)";
                //{'portique':'1','carteId':'12316548461','date':'11:34:52'}
                BDDXbee xbee = JsonConvert.DeserializeObject<BDDXbee>(str);
                command.Parameters.AddWithValue("portique", xbee.portique);
                command.Parameters.AddWithValue("carteId", xbee.carteId);
                command.Parameters.AddWithValue("date", xbee.date);
                command.ExecuteNonQuery();
                return "Success !";
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

        public string InsertAlerte(string str)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO alerte (alerte) VALUES (@alerte)";
                dynamic alerte = JsonConvert.DeserializeObject(str);
                command.Parameters.AddWithValue("alerte", alerte.alerte);
                command.ExecuteNonQuery();
                return "Success !";
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