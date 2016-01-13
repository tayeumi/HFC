using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;

namespace HFC.Forms
{
    public partial class frmTeamview : DevExpress.XtraEditors.XtraForm
    {
        public frmTeamview()
        {
            InitializeComponent();
        }

        private void frmTeamview_Load(object sender, EventArgs e)
        {
            teamview();
        }

        void teamview()
        {
            Class.NW_Teamview cls = new Class.NW_Teamview();
            DataTable dt =cls.NW_Teamview_Getlist();
            gridItem.DataSource = dt;
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\Team\\TeamViewer.exe"))
            {
                string id = gridItemDetail.GetFocusedRowCellValue(colID).ToString().Replace(" ", "");
                string pass = gridItemDetail.GetFocusedRowCellValue(colPass).ToString();
                Process.Start(Application.StartupPath + "\\Team\\TeamViewer.exe", "-i "+id+" --Password "+pass);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            teamview();
        }
    }
}