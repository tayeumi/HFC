using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_InterfaceControllerWarning
    {
        public string InterfaceController { get; set; }
        public string Signal { get; set; }
               
        public DataTable NW_InterfaceControllerWarning_GetList_Low()
        {
            string procname = "NW_InterfaceControllerWarning_GetList_Low";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_InterfaceControllerWarning_GetList()
        {
            string procname = "NW_InterfaceControllerWarning_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }


        public bool Insert(DataTable dt)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InterfaceController = dt.Rows[i]["InterfaceController"].ToString();
                    Signal = dt.Rows[i]["Signal"].ToString();

                    db.CreateNewSqlCommand();
                    db.AddParameter("@InterfaceController", InterfaceController);
                    db.AddParameter("@Signal", Signal);
                    db.AddParameter("@Datetime", DateTime.Now);
                    db.ExecuteNonQueryWithTransaction("NW_InterfaceControllerWarning_Insert");

                }
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
        public bool DeleteAll()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.ExecuteNonQueryWithTransaction("NW_InterfaceControllerWarning_DeleteAll");
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
