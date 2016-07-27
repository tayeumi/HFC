using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace HFC.Class
{
   public class MySqlConnect
    {
       protected static String MyConString = "SERVER=101.99.28.152;Uid=hfc;Password=831031;Database=NWManagement;Character Set=utf8;";
        static MySqlConnection connection = new MySqlConnection(MyConString);     

        public static void OpenConnection()
        {
            try
            {               
                connection.Open();
            }
            catch
            {
               
            }
        }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public static DataTable ExecQuery(string sql)
        {
            OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand command = connection.CreateCommand();            
            command.CommandText = sql;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }
        public static void ExecNonQuery(string sql)
        {
            OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
