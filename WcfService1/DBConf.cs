using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    public class DBConf
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "projetvtt";
            string username = "root";
            string password = "";

            return DBConn.GetDBConnection(host, port, database, username, password);
        }
    }
}