using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebCM
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

       
        public DataTable NW_SignalLog_5Day_GetByMacLike()
        {
            string procname = "NW_SignalLog_5Day_GetByMacLike";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MacAddress", MacAddress);
            return db.ExecuteDataTable(procname);
        }
      
    }
}