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
        public string InsertPreinscrit(string str)
        {
            MySqlConnection conn = DBConf.GetDBConnection();
            conn.Open();
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO preinscrit(IdPreinscrit,Nom,Prenom,Adresse,CodePostal,Ville,DateNaissance,Telephone,Email,Club,Ufolep) VALUES(@IdPreinscrit,@Nom,@Prenom,@Adresse,@CodePostal,@Ville,@DateNaissance,@Telephone,@Email,@Club,@Ufolep)";
                //{"Nom":"MARC","Prenom":"Jérémy","Adresse":"59 Cours Clemenceau","CodePostal":"76100","Ville":"Rouen","DateNaissance":"02-06-1998","Telephone":"0782062639","Email":"jeremy.marc.pro@gmail.com","Club":"azerty"}
                BDDPreinscrit preinscrit = JsonConvert.DeserializeObject<BDDPreinscrit>(str);
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