using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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
           
            webcontrol.Navigate("http://101.99.28.148:1111/dhcprestart.html");
            while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }

            if (webcontrol.DocumentText.IndexOf("Ok") > 0)
            {
                webcontrol.Navigate("http://101.99.28.152/dhcp/dhcp_update.php");
            }        
        }
    }
}