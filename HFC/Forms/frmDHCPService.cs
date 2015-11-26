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
    public partial class frmDHCPService : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPService()
        {
            InitializeComponent();
        }

        void NW_Dhcp_Ip_Getlist()
        {
            Class.NW_Dhcp_Ip cls = new Class.NW_Dhcp_Ip();
            DataTable dt= cls.NW_Dhcp_Ip_Getlist();
            gridItem.DataSource=dt;

        }

        private void frmDHCPService_Load(object sender, EventArgs e)
        {
            NW_Dhcp_Ip_Getlist();
        }
    }
}