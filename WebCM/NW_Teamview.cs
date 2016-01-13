using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebCM
{
    public class NW_Teamview
    {
        public string ID { get; set; }
        public string Pass { get; set; }
        public string User { get; set; }
        public string PC { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }

        public DataTable NW_Teamview_Getlist()
        {
            string procname = "NW_Teamview_Getlist";
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
                db.AddParameter("@ID", ID);
                db.AddParameter("@Pass", Pass);
                db.AddParameter("@User", User);
                db.AddParameter("@PC", PC);
                db.AddParameter("@DateTime", DateTime);
                db.AddParameter("@Location", Location);
                db.ExecuteNonQueryWithTransaction("NW_Teamview_Insert");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();               
                return false;
            }
        }
        public bool Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@ID", ID);
                db.ExecuteNonQueryWithTransaction("NW_Teamview_Delete");
                db.CommitTransaction();
                return true;
            }
            catch 
            {
                db.RollbackTransaction();
                return false;
            }
        }
    }
}