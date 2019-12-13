using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Server
{
    public class Database
    {
        public readonly MySqlConnection Db = new MySqlConnection(ConfigurationManager
            .ConnectionStrings["Server.Properties.Settings.DatabaseConnectionString"].ConnectionString);

        public void OpenDatabase()
        {
            Db.Open();
            Console.WriteLine("Open database");
        }

        public void CloseDatabase()
        {
            Db.Close();
        }
    }
}
