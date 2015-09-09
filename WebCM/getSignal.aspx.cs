using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebCM
{
    public partial class getSignal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            NW_SignalLog cls = new NW_SignalLog();
            cls.MacAddress = txtMac.Text;
            DataTable dt = cls.NW_SignalLog_5Day_GetByMacLike();
            if (dt.Rows.Count > 0)
            {
                gridItem.DataSource = dt;
                gridItem.DataBind();

            }
        }

        protected void gridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // you already know you're looking at this row, so check your cell text
                string tt = e.Row.Cells[7].Text.Trim();
                string _phat = e.Row.Cells[5].Text.Trim();
                int phy = 0;
                float phat = 0;
                float.TryParse(_phat, out phat);
                int.TryParse(tt, out phy);
                if (phy < 210)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                if (phat > 53.0)
                {
                    e.Row.BackColor = System.Drawing.Color.LawnGreen;
                }

            }
        }
    }
}