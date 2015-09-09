using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HFC.Class
{
   public class SolarWinds
    {
        public static string svr = "101.99.28.156";//".";
        public static string db = "NetPerforMonitor"; // "NWManagement";   
        public static string user = "sa"; //Class.App.DecryptString(get_config("user"), "UserID");
        public static string password = "adminlbc"; //Class.App.DecryptString(get_config("pass"), "PasswordID");
        private static SqlConnection _cnn = new SqlConnection(@"Data Source=" + svr + "; Initial Catalog=" + db + ";User ID=" + user + ";Password=" + password + "");
        public static SqlConnection SqlConnection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        public static void Open()
        {
            _cnn.Open();
        }

        public static void Close()
        {
            _cnn.Close();

        }             
   
   }

   public class SolarWindsAccess
   {
       SqlCommand cmd;
       SqlTransaction _sqlTran;
       #region "Open-Close Connection"
       /// <summary>
       /// Open Connection
       /// </summary>
       private void Open()
       {
           SolarWinds.Open();
       }

       /// <summary>
       /// Close Connection
       /// </summary>
       private void Close()
       {
           SolarWinds.Close();
       }
       #endregion

       #region "Transaction"
       /// <summary>
       /// BeginTransction
       /// </summary>
       public void BeginTransaction()
       {
           SolarWinds.Open();
           _sqlTran = SolarWinds.SqlConnection.BeginTransaction();
       }

       /// <summary>
       /// Close Connection
       /// </summary>
       public void CommitTransaction()
       {
           _sqlTran.Commit();
           SolarWinds.Close();
       }

       public void RollbackTransaction()
       {
           _sqlTran.Rollback();
           SolarWinds.Close();
       }
       #endregion
             
       public void CreateNewSqlCommand()
       {
           cmd = new SqlCommand();
           cmd.CommandTimeout = 0;
           cmd.CommandType = CommandType.Text;
           cmd.Connection = SolarWinds.SqlConnection;
       }             
       public DataTable ExecuteDataTable(string strQuery)
       {
           DataTable dt = new DataTable();
           try
           {
               SqlDataAdapter da = new SqlDataAdapter();
               cmd.CommandText = strQuery;
               da.SelectCommand = cmd;
               da.Fill(dt);
           }
           catch (Exception ex)
           {
               Class.App.Log_Write(ex.Message);
              // throw ex;
           }

           return dt;
       }
   }
}
