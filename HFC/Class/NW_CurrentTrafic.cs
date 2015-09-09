using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_CurrentTrafic
    {
        public string MacAddress { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string DS { get; set; }
        public string US { get; set; }
        public DateTime DateTime { get; set; }
        public string CurrentDS { get; set; }
        public string CurrentUS { get; set; }

        public DataTable NW_CurrentTrafic_GetAll()
        {
            string procname = "NW_CurrentTrafic_GetAll";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Trafic_Get()
        {
            string procname = "NW_Trafic_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            db.AddParameter("@Month", Month);
            db.AddParameter("@Year", Year);
            return db.ExecuteDataTable(procname);
        }

        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@MacAddress", MacAddress);
                db.AddParameter("@DS", DS);
                db.AddParameter("@US", US);
                db.AddParameter("@DateTime", DateTime);
                db.AddParameter("@CurrentDS", CurrentDS);
                db.AddParameter("@CurrentUS", CurrentUS);
                db.ExecuteNonQueryWithTransaction("NW_CurrentTrafic_Insert");
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
                db.ExecuteNonQueryWithTransaction("NW_CurrentTrafic_DeleteAll");
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
