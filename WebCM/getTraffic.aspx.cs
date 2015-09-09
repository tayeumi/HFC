using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebCM
{
    public partial class getTraffic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            NW_Traffic tf = new NW_Traffic();
            tf.MacAddress = txtMac.Text;
            tf.Month = DateTime.Now.Month.ToString();
            tf.Year = DateTime.Now.Year.ToString();
            DataTable dt=tf.NW_Trafic_Getlike();
            GridItem.DataSource = dt;
            GridItem.DataBind();
            ChartItem.DataSource = dt;
            ChartItem.Series["Series1"].XValueMember = "DateTime";
            ChartItem.Series["Series1"].YValueMembers = "DS";
            ChartItem.Series["Series2"].XValueMember = "DateTime";
            ChartItem.Series["Series2"].YValueMembers = "US";
            ChartItem.DataBind();

        }
    }
}