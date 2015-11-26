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
        public string PoolIP { get; set; }
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
    }
}
