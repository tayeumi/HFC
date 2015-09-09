using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class SolarWinds_Get
    {
        public string InterfaceName { get; set; }
        public string FullName { get; set; }
        public float Inbps { get; set; }
        public float Outbps { get; set; }
        public double InBandwidth { get; set; }
        public double OutBandwidth { get; set; }
        public int InPercentUtil { get; set; }
        public int OutPercentUtil { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastSync { get; set; }
        public string StrDate { get; set; }

        public DataTable SolarWinds_GetInterface(string txtQuery)
        {
            SolarWindsAccess db = new SolarWindsAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(txtQuery);
        }

        public DataTable NW_InterfaceLog_GetList()
        {
            string procname = "NW_InterfaceLog_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public bool Insert(DataTable dt)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InterfaceName = dt.Rows[i]["InterfaceName"].ToString();
                    FullName = dt.Rows[i]["FullName"].ToString();
                    Inbps = (float)dt.Rows[i]["Inbps"];
                    Outbps = (float)dt.Rows[i]["Outbps"];
                    InBandwidth = (double)dt.Rows[i]["InBandwidth"];
                    OutBandwidth = (double)dt.Rows[i]["OutBandwidth"];
                    InPercentUtil = int.Parse(dt.Rows[i]["InPercentUtil"].ToString());
                    OutPercentUtil = int.Parse(dt.Rows[i]["OutPercentUtil"].ToString());
                    LastSync = (DateTime)dt.Rows[i]["LastSync"];
                    Status = dt.Rows[i]["Status"].ToString();


                    db.CreateNewSqlCommand();
                    db.AddParameter("@InterfaceName", InterfaceName);
                    db.AddParameter("@FullName", FullName);
                    db.AddParameter("@Inbps", Inbps);
                    db.AddParameter("@Outbps", Outbps);
                    db.AddParameter("@InBandwidth", InBandwidth);
                    db.AddParameter("@OutBandwidth", OutBandwidth);
                    db.AddParameter("@InPercentUtil", InPercentUtil);
                    db.AddParameter("@OutPercentUtil", OutPercentUtil);
                    db.AddParameter("@DateTime", DateTime);
                    db.AddParameter("@StrDate", StrDate);
                    db.AddParameter("@LastSync", LastSync);
                    db.AddParameter("@Status", Status);

                    db.ExecuteNonQueryWithTransaction("NW_InterfaceLog_Insert");
                }
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
