using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OutSource
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
               
        public DataTable NW_Dhcp_Customer_GetbyPool_MySQL()
        {
            string sql = " select * from NW_Dhcp_Customer where PoolIp='" + PoolIp + "'";
            return MySqlConnect.ExecQuery(sql);
        }
       
        public DataTable NW_Dhcp_Customer_GetbyPoolPublic_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where PoolPublic='" + PoolIp + "'";
            return MySqlConnect.ExecQuery(sql);
        }
      
        public DataTable NW_Dhcp_Customer_GetbyMacaddress_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where MacAddress='" + MacAddress + "'";

            return MySqlConnect.ExecQuery(sql);
        }
       
        public DataTable NW_Dhcp_Customer_GetbyIp_MySQL()
        {
            string sql = "select * from NW_Dhcp_Customer where IpAddress='" + IpAddress + "'";
            return MySqlConnect.ExecQuery(sql);
        }       

        public bool InsertMySQL()
        {
            try
            {
                string sql = "insert into NW_Dhcp_Customer(IpAddress,MacAddress,MacAddress_CMTS,CustomerCode,CustomerName,CustomerAddress,PoolIp,Bootfile,IpPublic,MacPc,PoolPublic,Location,Note)values('" + IpAddress + "','" + MacAddress + "','" + MacAddress_CMTS + "','" + CustomerCode + "','" + CustomerName + "','" + CustomerAddress + "','" + PoolIp + "','" + Bootfile + "','" + IpPublic + "','" + MacPc + "','" + PoolPublic + "','" + Location + "','" + Note + "')";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch 
            {                               
                return false;
            }
        }
       
        public bool NW_Dhcp_Customer_UpdateIPStatic_MySQL()
        {
            string sql = "update NW_Dhcp_Customer set IpPublic='" + IpPublic + "',PoolPublic='" + PoolPublic + "',MacPc='" + MacPc + "',Note='" + Note + "' where IpAddress='" + IpAddress + "'";

            try
            {
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch 
            {
                return false;
            }
        }      
        public bool NW_Dhcp_Customer_DeleteIPStatic_MySQL()
        {

            try
            {
                string sql = "update NW_Dhcp_Customer set IpPublic='',PoolPublic='',MacPc='' where IpAddress='" + IpAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch 
            {                
                return false;
            }
        }
        
        public bool UpdateMySQL()
        {
            try
            {
                string sql = "Update NW_Dhcp_Customer set MacAddress='" + MacAddress + "',MacAddress_CMTS='" + MacAddress_CMTS + "',CustomerCode='" + CustomerCode + "',CustomerName='" + CustomerName + "',CustomerAddress='" + CustomerAddress + "',Bootfile='" + Bootfile + "',Location='" + Location + "',Note='" + Note + "' where IpAddress='" + IpAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch 
            {              
                return false;
            }
        }
        
        //public bool NW_Dhcp_Customer_DeleteAll_MySQL()
        //{

        //    try
        //    {
        //        string sql = "delete from NW_Dhcp_Customer";
        //        MySqlConnect.ExecNonQuery(sql);
        //        return true;
        //    }
        //    catch 
        //    {                           
        //        return false;
        //    }
        //}
       
        public bool NW_Dhcp_Customer_Delete_MySQL()
        {
            try
            {
                string sql = "delete from NW_Dhcp_Customer where IpAddress='" + IpAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch
            {               
                return false;
            }
        }

        public bool NW_Dhcp_Customer_DeActivebyIP_MySQL()
        {
            try
            {
                string sql = "update  NW_Dhcp_Customer set Bootfile='auto/offline.bin' where IpAddress='" + IpAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool NW_Dhcp_Customer_ActiveByIP_MySQL()
        {
            try
            {
                string sql = "update  NW_Dhcp_Customer set Bootfile='"+Bootfile+"' where IpAddress='" + IpAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool NW_Dhcp_Customer_DeActivebyMac_MySQL()
        {
            try
            {
                string sql = "update  NW_Dhcp_Customer set Bootfile='auto/offline.bin' where MacAddress='" + MacAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool NW_Dhcp_Customer_ActiveByMac_MySQL()
        {
            try
            {
                string sql = "update  NW_Dhcp_Customer set Bootfile='" + Bootfile + "' where MacAddress='" + MacAddress + "'";
                MySqlConnect.ExecNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
