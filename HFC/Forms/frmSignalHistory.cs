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
    public partial class frmSignalHistory : DevExpress.XtraEditors.XtraForm
    {
        public frmSignalHistory()
        {
            InitializeComponent();
        }
        public frmSignalHistory(string mac)
        {
            InitializeComponent();
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải lịch sử Modem .!");
            LoadList(mac);
            Waiting.CloseWaitForm();
        }

        public frmSignalHistory(string mac,int t)
        {
            InitializeComponent();
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải lịch sử Modem .!");
            LoadList(mac,0);
            Waiting.CloseWaitForm();
        }

        void LoadList(string mac,int t)
        {
            Class.NW_SignalLog cls = new Class.NW_SignalLog();
            cls.MacAddress = mac;
            gridItem.DataSource = cls.NW_SignalLog_5Day_GetByMac();
        }


        void LoadList(string mac)
        {
            Class.NW_SignalLog cls = new Class.NW_SignalLog();
            cls.MacAddress = mac;
            gridItem.DataSource = cls.NW_SignalLog_GetByMac();
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