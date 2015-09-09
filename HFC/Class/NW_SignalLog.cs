using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
   public class NW_SignalLog
    {
        public string MacAddress { get; set; }      
        public string IpPrivate { get; set; }
        public string IpPublic1 { get; set; }
        public string IpPublic2 { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string CurrentDS { get; set; }
        public string CurrentUS { get; set; }

        public DataTable NW_SignalLog_GetByMac()
        {
            string procname = "NW_SignalLog_GetByMac";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_SignalLog_5Day_GetByMac()
        {
            string procname = "NW_SignalLog_5Day_GetByMac";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_SignalLog_5Day_GetByMacLike()
        {
            string procname = "NW_SignalLog_5Day_GetByMacLike";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
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
                db.AddParameter("@IpPrivate", IpPrivate);
                db.AddParameter("@IpPublic1", IpPublic1);
                db.AddParameter("@IpPublic2", IpPublic2);
                db.AddParameter("@Value1", Value1);
                db.AddParameter("@Value2", Value2);
                db.AddParameter("@Value3", Value3);
                db.AddParameter("@Value4", Value4);
                db.AddParameter("@Status", Status);
                db.AddParameter("@Location", Location);               
                db.AddParameter("@DateTime", DateTime);
                db.AddParameter("@Description", Description);
                db.AddParameter("@CurrentDS", CurrentDS);
                db.AddParameter("@CurrentUS", CurrentUS);
                db.ExecuteNonQueryWithTransaction("NW_SignalLog_Insert");
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

        public bool DeleteFor30Day()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.ExecuteNonQueryWithTransaction("NW_SignalLog_DeleteFor30Day");
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
