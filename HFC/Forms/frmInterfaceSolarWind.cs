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
    public partial class frmInterfaceSolarWind : DevExpress.XtraEditors.XtraForm
    {
        public frmInterfaceSolarWind()
        {
            InitializeComponent();
        }
        void LoadSolarwinds()
        {
            try
            {
               // string txt = "select * from Interfaces where NodeID=18 and InterfaceName LIKE 'Cable Downstream%' or InterfaceName ='gigaether15/0'";
                string txt = "select * from Interfaces where NodeID=18";
                Class.SolarWinds_Get clsSolarwind = new Class.SolarWinds_Get();
                clsSolarwind.DateTime = DateTime.Now;
                DataTable dtSolarWind = clsSolarwind.SolarWinds_GetInterface(txt);
                gridItem.DataSource = dtSolarWind;
            }
            catch
            {
            }
        }

        private void frmInterfaceSolarWind_Load(object sender, EventArgs e)
        {
            LoadSolarwinds();
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải lịch sử Card.!");
            Class.SolarWinds_Get clssl= new Class.SolarWinds_Get();
            DataTable dt = clssl.NW_InterfaceLog_GetList();
            gridItem.DataSource = dt;
            Waiting.CloseWaitForm();
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                string txt = "select * from Interfaces where NodeID=18 and InterfaceName LIKE 'Cable Downstream%' or InterfaceName ='gigaether15/0'";
                Class.SolarWinds_Get clsSolarwind = new Class.SolarWinds_Get();
                clsSolarwind.DateTime = DateTime.Now;
                DataTable dtSolarWind = clsSolarwind.SolarWinds_GetInterface(txt);
                gridItem.DataSource = dtSolarWind;
            }
            catch { }
        }

        private void gridItemDetail_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colInPercentUtil || e.Column==colOutPercentUtil)
            {
                int percent = Convert.ToInt16(e.CellValue);
                if (percent < 80)
                {
                    ProgressBar.StartColor = System.Drawing.Color.SpringGreen;
                    ProgressBar.EndColor = System.Drawing.Color.SpringGreen;
                }
                if (percent > 79 & percent < 90)
                {
                    ProgressBar.StartColor = System.Drawing.Color.Orange;
                    ProgressBar.EndColor = System.Drawing.Color.Orange;
                }
                if (percent > 90 & percent < 99)
                {
                    ProgressBar.StartColor = System.Drawing.Color.Orange;
                    ProgressBar.EndColor = System.Drawing.Color.Red;
                }
                if (percent >99)
                {
                    ProgressBar.StartColor = System.Drawing.Color.Red;
                    ProgressBar.EndColor = System.Drawing.Color.Red;
                }  
            }
        }
  
    }
}