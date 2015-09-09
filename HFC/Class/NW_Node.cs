using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HFC.Class
{
    class NW_Node
    {
        public string NodeCode { get; set; }
        public string NodeName { get; set; }
        public string NodeGroup { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public DataTable NW_Node_GetList()
        {
            string procname = "NW_Node_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public DataTable NW_Node_Get()
        {
            string procname = "NW_Node_Get";
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
                db.AddParameter("@NodeCode", NodeCode);
                db.AddParameter("@NodeName", NodeName);
                db.AddParameter("@NodeGroup", NodeGroup);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("NW_Node_Insert");
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
                db.AddParameter("@NodeCode", NodeCode);
                db.AddParameter("@NodeName", NodeName);
                db.AddParameter("@NodeGroup", NodeGroup);
                db.AddParameter("@Description", Description);
                db.ExecuteNonQueryWithTransaction("NW_Node_Update");
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
        public bool UpdateByPath()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@NodeCode", NodeCode);
                db.AddParameter("@Path", Path);                
                db.ExecuteNonQueryWithTransaction("NW_Node_UpdateByPath");
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
                db.AddParameter("@NodeCode", NodeCode);               
                db.ExecuteNonQueryWithTransaction("NW_Node_Delete");
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

        public string GetNewCode()
        {
            string procname = "NW_Node_GetList";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            DataTable dt = db.ExecuteDataTable(procname);
            if (dt.Rows.Count > 0)
            {
                string _strCode = dt.Rows[dt.Rows.Count - 1][0].ToString();
                _strCode = _strCode.Substring(2, _strCode.Length - 2);
                int next_id = int.Parse(_strCode) + 1;
                switch (next_id.ToString().Length)
                {
                    case 1:
                        return "N00000" + next_id.ToString();
                    case 2:
                        return "N0000" + next_id.ToString();
                    case 3:
                        return "N000" + next_id.ToString();
                    case 4:
                        return "N00" + next_id.ToString();
                    case 5:
                        return "N0" + next_id.ToString();
                    case 6:
                        return "N" + next_id.ToString();
                }
            }
            return "N000001";

        }
    }
}
