using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OMS.Utility
{
    class DBConnection
    {
        static string connString = ConfigurationManager.AppSettings["my_conn"];
        private static MySqlConnection myConnection =  new MySqlConnection(connString);
        MySqlCommand myCommand;

        MySqlDataReader rdr; MySqlDataReader rdr2;

        public static void connDB()
        {
            myConnection.Open();
        }

        public static void disconnDB()
        {
            myConnection.Close();
        }
        public static MySqlConnection getConn()
        {
            return myConnection;
        }

    }
}
