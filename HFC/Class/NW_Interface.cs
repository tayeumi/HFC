using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Interface
    {
        public string Interface { get; set; }
        public string SignalGroup { get; set; }
        public string Description { get; set; }

        public DataTable NW_Interface_Getlist()
        {
            string procname = "NW_Interface_Getlist";
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
                db.AddParameter("@SignalGroup", SignalGroup);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("NW_Interface_Insert");
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
