﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Dhcp_Customer
    {
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public string MacAddress_CMTS { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PoolIp { get; set; }
        public string Bootfile { get; set; }
        public string IpPublic { get; set; }
        public string MacPc { get; set; }
        public string PoolPublic { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }


        public DataTable NW_Dhcp_Customer_Getlist()
        {
            string procname = "NW_Dhcp_Customer_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public DataTable NW_Dhcp_Customer_GetbyPool()
        {
            string procname = "NW_Dhcp_Customer_GetbyPool";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@PoolIp", PoolIp);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Customer_GetbyPool_MySQL()
        {
            string sql = " select * from NW_Dhcp_Customer where PoolIp='"+PoolIp+"'";
            return Class.MySqlConnect.ExecQuery(sql);
        }

        public DataTable NW_Dhcp_Customer_GetbyPoolPublic()
        {
            string procname = "NW_Dhcp_Customer_GetbyPoolPublic";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@PoolIp", PoolIp);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Customer_GetbyPoolPublic_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where PoolPublic='"+PoolIp+"'";
            return Class.MySqlConnect.ExecQuery(sql);
        }
        public DataTable NW_Dhcp_Customer_GetbyMacaddress()
        {
            string procname = "NW_Dhcp_Customer_GetbyMacaddress";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Customer_GetbyMacaddress_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where MacAddress='"+MacAddress+"'";

            return Class.MySqlConnect.ExecQuery(sql);
        }
        public DataTable NW_Dhcp_Customer_GetbyIp()
        {
            string procname = "NW_Dhcp_Customer_GetbyIp";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@IpAddress", IpAddress);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Customer_GetbyIp_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where IpAddress='"+IpAddress+"'";
            return Class.MySqlConnect.ExecQuery(sql);
        }
        public bool Insert()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@IpAddress", IpAddress);
                db.AddParameter("@MacAddress", MacAddress);
                db.AddParameter("@MacAddress_CMTS", MacAddress_CMTS);
                db.AddParameter("@CustomerCode", CustomerCode);
                db.AddParameter("@CustomerName", CustomerName);
                db.AddParameter("@CustomerAddress", CustomerAddress);
                db.AddParameter("@PoolIp", PoolIp);
                db.AddParameter("@Bootfile", Bootfile);
                db.AddParameter("@IpPublic", IpPublic);
                db.AddParameter("@MacPc", MacPc);
                db.AddParameter("@PoolPublic", PoolPublic);
                db.AddParameter("@Location", Location);
                db.AddParameter("@Note", Note);
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_Insert");
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

        public bool InsertMySQL()
        {
            try{
                string sql = "insert into NW_Dhcp_Customer(IpAddress,MacAddress,MacAddress_CMTS,CustomerCode,CustomerName,CustomerAddress,PoolIp,Bootfile,IpPublic,MacPc,PoolPublic,Location,Note)values('"+IpAddress+"','"+MacAddress+"','"+MacAddress_CMTS+"','"+CustomerCode+"','"+CustomerName+"','"+CustomerAddress+"','"+PoolIp+"','"+Bootfile+"','"+IpPublic+"','"+MacPc+"','"+PoolPublic+"','"+Location+"','"+Note+"')";
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }

        public bool NW_Dhcp_Customer_UpdateIPStatic()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@IpAddress", IpAddress);
                db.AddParameter("@IpPublic", IpPublic);               
                db.AddParameter("@PoolPublic", PoolPublic);
                db.AddParameter("@MacPc", MacPc);
                db.AddParameter("@Note", Note);
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_UpdateIPStatic");
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
        public bool NW_Dhcp_Customer_UpdateIPStatic_MySQL()
        {
            string sql = "update NW_Dhcp_Customer set IpPublic='"+IpPublic+"',PoolPublic='"+PoolPublic+"',MacPc='"+MacPc+"',Note='"+Note+"' where IpAddress='"+IpAddress+"'";
            
            try
            {
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {                
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
        public bool NW_Dhcp_Customer_DeleteIPStatic()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@IpAddress", IpAddress);
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_DeleteIPStatic");
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
        public bool NW_Dhcp_Customer_DeleteIPStatic_MySQL()
        {
           
            try
            {
                string sql = "update NW_Dhcp_Customer set IpPublic='',PoolPublic='',MacPc='' where IpAddress='"+IpAddress+"'";
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
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
                db.AddParameter("@IpAddress", IpAddress);
                db.AddParameter("@MacAddress", MacAddress);
                db.AddParameter("@MacAddress_CMTS", MacAddress_CMTS);
                db.AddParameter("@CustomerCode", CustomerCode);
                db.AddParameter("@CustomerName", CustomerName);
                db.AddParameter("@CustomerAddress", CustomerAddress);
                db.AddParameter("@Bootfile", Bootfile);
                db.AddParameter("@Location", Location);
                db.AddParameter("@Note", Note);
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_Update");
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
        public bool UpdateMySQL()
        {
           
            try
            {
                string sql = "Update NW_Dhcp_Customer set MacAddress='"+MacAddress+"',MacAddress_CMTS='"+MacAddress_CMTS+"',CustomerCode='"+CustomerCode+"',CustomerName='"+CustomerName+"',CustomerAddress='"+CustomerAddress+"',Bootfile='"+Bootfile+"',Location='"+Location+"',Note='"+Note+"' where IpAddress='"+IpAddress+"'";
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
        public bool NW_Dhcp_Customer_DeleteAll()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_DeleteAll");
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
        public bool NW_Dhcp_Customer_DeleteAll_MySQL()
        {
            
            try
            {
                string sql = "delete from NW_Dhcp_Customer";
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
               
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
        public bool NW_Dhcp_Customer_Delete()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@IpAddress", IpAddress);
                db.ExecuteNonQueryWithTransaction("NW_Dhcp_Customer_Delete");
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

        public bool NW_Dhcp_Customer_Delete_MySQL()
        {            
            try
            {
                string sql = "delete from NW_Dhcp_Customer where IpAddress='" + IpAddress+"'";
                Class.MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
               
                Class.App.Log_Write(ex.Message);
                return false;
            }
        }
    }
}
