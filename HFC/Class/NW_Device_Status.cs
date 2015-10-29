using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Device_Status
    {
        public string Interface { get; set; }
        public int Modems { get; set; }
        public int Hosts { get; set; }
        public DateTime DateTime { get; set; }


        public DataTable NW_Device_Status_GetByInterface()
        {
            string procname = "NW_Device_Status_GetByInterface";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Interface", Interface);
            return db.ExecuteDataTable(procname);
        }

        public DataTable NW_Device_Status_Get24h()
        {
            string procname = "NW_Device_Status_Get24h";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();            
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Device_Status_GetList()
        {
            string procname = "NW_Device_Status_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@Interface", Interface);
                db.AddParameter("@Modems", Modems);
                db.AddParameter("@Hosts", Hosts);
                db.AddParameter("@DateTime", DateTime);
                db.ExecuteNonQueryWithTransaction("NW_Device_Status_Insert");
                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
    }
}
