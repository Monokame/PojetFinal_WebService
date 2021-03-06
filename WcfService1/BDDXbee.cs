﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    public class BDDXbee
    {
        [DataMember]
        public string temps;
        [DataMember]
        public string carteId;
        [DataMember]
        public string portique;

        public string InsertXbee(BDDXbee xbee)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            try
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO portique(idPortique,infoCarte,Temps) VALUES(@portique,@carteId,@temps)";
                //{"portique":"1","carteId":"316548461","date":"11:34:52"}
                command.Parameters.AddWithValue("portique", xbee.portique);
                command.Parameters.AddWithValue("carteId", xbee.carteId);
                command.Parameters.AddWithValue("temps", xbee.temps);
                command.ExecuteNonQuery();
                return "Success !";
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
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