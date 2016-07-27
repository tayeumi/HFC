using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;

namespace HFC.Forms
{
    public partial class frmDHCPService_Restart : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPService_Restart()
        {
            InitializeComponent();
        }

        private void frmDHCPService_Restart_Load(object sender, EventArgs e)
        {
            // webcontrol.Refresh(WebBrowserRefreshOption.Completely); 
            string result = "";
            WebClient client = new WebClient();
           // try
           // {
           //     client.Headers.Add("Cache-Control", "no-cache");
           //     result = client.DownloadString("http://101.99.28.148:1111/dhcprestart.html");
           // }
           // catch { result = "fail"; }
           // webcontrol.DocumentText = result;
           // while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
           // {
           //     Application.DoEvents();
           //     System.Threading.Thread.Sleep(50);
           // }

           // if (webcontrol.DocumentText.IndexOf("Ok") > 0)
           // {
           //    // webcontrol.Navigate("http://101.99.28.152/dhcp/dhcp_update.php");
           //     try
           //     {
           //         client.Headers.Add("Cache-Control", "no-cache");
           //         result = client.DownloadString("http://101.99.28.152/dhcp/dhcp_update.php");
           //     }
           //     catch { result = "fail"; }
           //     webcontrol.DocumentText = result;
           // }
            try
            {
                client.Headers.Add("Cache-Control", "no-cache");
                result = client.DownloadString("http://101.99.28.152/dhcp/dhcp_update.php");
            }
            catch { result = "fail"; }
            webcontrol.DocumentText = result;
        }
    }
}