using System;
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
        public string CusstomerAddress { get; set; }
        public string PoolIp { get; set; }
        public string Bootfile { get; set; }

        public DataTable NW_Dhcp_Customer_Getlist()
        {
            string procname = "NW_Dhcp_Customer_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
    }
}
