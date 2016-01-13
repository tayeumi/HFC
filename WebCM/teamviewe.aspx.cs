using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCM
{
    public partial class teamviewe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                NW_Teamview team = new NW_Teamview();
                if (Request.QueryString["action"] != null)
                {
                    if (Request.QueryString["action"].ToString() == "add")
                    {
                        if (Request.QueryString["pass"] != null)
                        {
                            team.ID = Request.QueryString["id"].ToString();
                            team.Pass = Request.QueryString["pass"].ToString();
                            team.User = Request.QueryString["user"].ToString();
                            team.PC = Request.QueryString["pc"].ToString();
                            team.DateTime = DateTime.Now;
                            team.Location = Request.QueryString["location"].ToString();
                            team.Insert();
                        }
                    }
                    else if (Request.QueryString["action"].ToString() == "del")
                    {
                        team.ID = Request.QueryString["id"].ToString();
                        team.Delete();
                    }
                }
            }
        }
    }
}