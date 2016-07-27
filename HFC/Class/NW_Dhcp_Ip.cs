using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Dhcp_Ip
    {
        public int ID { get; set; }
        public string PoolIp { get; set; }
        public string Name { get; set; }
        public string SubnetMask { get; set; }
        public string Router { get; set; }
        public string Broadcast { get; set; }
        public string Dns { get; set; }
        public string Range { get; set; }
        public bool Static { get; set; }

        public DataTable NW_Dhcp_Ip_Getlist()
        {
            string procname = "NW_Dhcp_Ip_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Ip_GetbyCPEDynamic()
        {
            string procname = "NW_Dhcp_Ip_GetbyCPEDynamic";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Ip_GetbyCPEDynamic_MySQL()
        {
            string sql = "select * from NW_Dhcp_Ip where Name like 'CPE%' and Static=0";

            return Class.MySqlConnect.ExecQuery(sql);
        }
        public DataTable NW_Dhcp_Ip_GetbyCPEStatic()
        {
            string procname = "NW_Dhcp_Ip_GetbyCPEStatic";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
      
        public DataTable NW_Dhcp_Ip_GetbyCPEStatic_MySQL()
        {
            string sql = "select * from NW_Dhcp_Ip where Name like 'CPE%' and Static=1";

            return Class.MySqlConnect.ExecQuery(sql);
        }
        public DataTable NW_Dhcp_Ip_GetbyPoolModem()
        {
            string procname = "NW_Dhcp_Ip_GetbyPoolModem";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Ip_GetbyPoolModem_MySQL()
        {
            string sql = "select * from NW_Dhcp_Ip where Name like '%Modem%'";
            return Class.MySqlConnect.ExecQuery(sql);
        }
        public DataTable NW_Dhcp_Ip_GetIPbyPool()
        {
            string procname = "NW_Dhcp_Ip_GetIPbyPool";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@PoolIp", PoolIp);
            return db.ExecuteDataTable(procname);
        }
        public DataTable NW_Dhcp_Ip_GetIPbyPool_MySQL()
        {
            string sql = "select * from NW_Dhcp_Ip where PoolIP ='" + PoolIp + "'";
            return Class.MySqlConnect.ExecQuery(sql);
        }
      
    }
}
