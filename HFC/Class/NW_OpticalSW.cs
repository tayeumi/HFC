using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_OpticalSW
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string ValueA { get; set; }
        public string ValueB { get; set; }
        public DateTime DateTime { get; set; }

        public DataTable NW_OpticalSW_Getlist()
        {
            string procname = "NW_OpticalSW_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_OpticalSW_Get()
        {
            string procname = "NW_OpticalSW_Get";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ID", ID);
            return db.ExecuteDataTable(procname);
        }
        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@Name", Name);
                db.AddParameter("@IpAddress", IpAddress);               
                db.ExecuteNonQueryWithTransaction("NW_OpticalSW_Insert");
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
        public bool Update()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@ID", ID);
                db.AddParameter("@Name", Name);
                db.AddParameter("@IpAddress", IpAddress);                
                db.ExecuteNonQueryWithTransaction("NW_OpticalSW_Update");
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
        public bool Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@ID", ID);
                db.ExecuteNonQueryWithTransaction("NW_OpticalSW_Delete");
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
