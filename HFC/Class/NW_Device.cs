using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Device
    {
        public string MacAddress { get; set; }
        public string NodeCode { get; set; }
        public string Description { get; set; }
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

        public DataTable NW_Device_GetList()
        {
            string procname = "NW_Device_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public DataTable NW_Device_GetStatic()
        {
            string procname = "NW_Device_GetStatic";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Device_GetByMac()
        {
            string procname = "NW_Device_GetByMac";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Device_GetByNodeCode()
        {
            string procname = "NW_Device_GetByNodeCode";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@NodeCode", NodeCode);
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
                db.AddParameter("@NodeCode", NodeCode);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("NW_Device_Insert");
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
                db.AddParameter("@MacAddress", MacAddress);                
                db.AddParameter("@Value1", Value1);
                db.AddParameter("@Value2", Value2);
                db.AddParameter("@Value3", Value3);
                db.AddParameter("@DateTime", DateTime);
                db.AddParameter("@Status", Status);               
                db.ExecuteNonQueryWithTransaction("NW_Device_Update");
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
        public bool UpdateSignal()
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
                db.AddParameter("@Location", Location);
                db.AddParameter("@Status", Status);
                db.AddParameter("@DateTime", DateTime);
                db.ExecuteNonQueryWithTransaction("NW_Device_UpdateSignal");
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
                db.AddParameter("@MacAddress", MacAddress);               
                db.ExecuteNonQueryWithTransaction("NW_Device_Delete");
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
