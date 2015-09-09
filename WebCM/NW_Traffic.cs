using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebCM
{
    public class NW_Traffic
    {
        public string MacAddress { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DataTable NW_Trafic_Getlike()
        {
            string procname = "NW_Trafic_Getlike";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            db.AddParameter("@Month", Month);
            db.AddParameter("@Year", Year);
            return db.ExecuteDataTable(procname);
        }
    }
}