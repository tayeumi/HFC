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
    public partial class frmDeviceList_Request_Static : DevExpress.XtraEditors.XtraForm
    {
        public frmDeviceList_Request_Static()
        {
            InitializeComponent();
        }

        private void frmDeviceList_Request_Static_Load(object sender, EventArgs e)
        {
            Class.NW_Device cls = new Class.NW_Device();
            gridItem.DataSource = cls.NW_Device_GetStatic();
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
    }
}