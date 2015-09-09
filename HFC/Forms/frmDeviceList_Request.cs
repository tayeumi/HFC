using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace HFC.Forms
{
    public partial class frmDeviceList_Request : DevExpress.XtraEditors.XtraForm
    {
        public frmDeviceList_Request()
        {
            InitializeComponent();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_DeviceList_Request.xml";
        private void frmDeviceList_Request_Load(object sender, EventArgs e)
        {
            NW_Node_GetList();
            NW_Device_GetList();

            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }

        }
        void NW_Node_GetList()
        {
            Class.NW_Node cls = new Class.NW_Node();
            DataTable dt = cls.NW_Node_GetList();
            gridItemNode.DataSource = dt;
        }

        void NW_Device_GetList()
        {
            Class.NW_Device cls = new Class.NW_Device();
            dt = cls.NW_Device_GetList();
            gridItem.DataSource = dt;
            cls.MacAddress = "";
            dtRe = cls.NW_Device_GetByMac();
            dtPhy = cls.NW_Device_GetByMac();

        }
        DataTable dt=new DataTable();
        DataTable dtRe = new DataTable();
        DataTable dtPhy = new DataTable();

        public void NW_Device_GetByNodeCode()
        {
            int SelectedRow = gridItemDetailNode.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetailNode.GetDataRow(SelectedRow);
                string _NodeCode = drow["NodeCode"].ToString();

                //Class.NW_Device cls = new Class.NW_Device();
                //cls.NodeCode = _NodeCode;
                //dt = cls.NW_Device_GetByNodeCode();
                //gridItem.DataSource = dt;
                DataView dv = new DataView();
                dv = dt.DefaultView;
                dv.RowFilter = "NodeCode='" + _NodeCode + "'";

            }

        }

        private void gridItemDetailNode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NW_Device_GetByNodeCode();
           
        }

        private void gridItemDetail_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridItemDetail.RowCount > 0)
            {
                btnLoad.Enabled = true;
                btnLoadAdd.Enabled = true;
            }
            else
            {
                btnLoad.Enabled = false;
                btnLoadAdd.Enabled = false;
            }
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang kết nối đến CMTS");

                Class.CMTS cmts = new Class.CMTS();
                cmts.Connect(Class.CMTS.CMTS_Host);
                if (Class.CMTS.tcpClient.Connected)
                {
                    btnConnect.Enabled = false;
                }

                Waiting.CloseWaitForm();
            }
            catch { }
        }

        private void btnLoad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (btnConnect.Enabled)
                {
                    return;
                }
                else
                {
                    if (!Class.CMTS.tcpClient.Connected)
                    {
                        btnConnect.Enabled = true;
                        return;
                    }
                }
                Waiting.ShowWaitForm();
                 // lay Remote
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();
                    string value1 = "";
                    string value2 = "";
                    string value3 = "";
                    string mac = "";
                    string IpPrivate = "";
                    string status = "";
                    string location = "";
                    string[] list = null;
                    dtRe.Rows.Clear();
                    list = null;
                    // lay remote
                    cmts.Remote_Card_all(out list, Waiting);
                    if (list != null)
                    {
                        DataRow dr;
                        for (int i = 0; i < list.Length; i++)
                        {
                            // lay online
                            if (list[i].IndexOf("MOT") < 0) // kiem tra
                            {
                                if (list[i].IndexOf("online") > 0)
                                    status = "online";
                                else
                                    status = "offline";
                                // location
                                Regex r2 = new Regex(@"(\d+)/(\d+)/(\w+) ");
                                Match m2 = r2.Match(list[i]);
                                if (m2.Success)
                                {
                                    location = m2.Value.Trim();
                                }
                                // loc thong so
                                Regex r = new Regex(@" (\d+).(\d+).(\d+).(\d+)(.*)(\w+).(\w+).(\w+)(.*)(\d+) ");
                                Match m = r.Match(list[i]);
                                if (m.Success)
                                {
                                    string kq = m.Value;
                                    kq = kq.Trim();
                                    kq = kq.Replace("  ", " ");
                                    kq = kq.Replace("  ", " ");
                                    kq = kq.Replace("  ", " ");

                                    string[] cat = kq.Split(' ');

                                    IpPrivate = cat[0];
                                    mac = cat[1];
                                    value1 = cat[2];
                                    value2 = cat[3];
                                    value3 = cat[4];
                                    if (IpPrivate.Equals("0.0.0.0"))
                                    {
                                        mac = cat[2];
                                        value1 = cat[3];
                                        value2 = cat[4];
                                        value3 = cat[5];
                                    }
                                }
                                if (mac.Trim() != "")
                                {
                                    dr = dtRe.NewRow();
                                    dr["MacAddress"] = mac;
                                    dr["IpPrivate"] = IpPrivate;
                                    dr["value1"] = value1;
                                    dr["value2"] = value2;
                                    dr["value3"] = value3;
                                    dr["Location"] = location;
                                    dr["Status"] = status;
                                    dr["DateTime"] = dtime;
                                    dtRe.Rows.Add(dr);
                                }
                            }
                        }

                    }    
                    /// het lay Remote
                /// lay PHY
                /// 
                   
                    string value4 = "";                   
                   
                    dtPhy.Rows.Clear();
                    list = null;
                    List<string> list1 = new List<string>();
                    // lay remote
                    cmts.PHY_Card_all(out list, Waiting, out list1);
                    if (list != null)
                    {
                        DataRow dr;
                        for (int i = 0; i < list.Length; i++)
                        {
                            value4 = "";
                            Regex rMac = new Regex(@"(\w+).(\w+).(\w+).(\w+)");
                            Match m3 = rMac.Match(list[i]);
                            if (m3.Success)
                            {
                                string kq2 = m3.Value;
                                mac = kq2;

                                Regex rPHY = new Regex(@" (\d+){3} ");
                                Match m4 = rPHY.Match(list[i]);
                                if (m4.Success)
                                {
                                    string kq = m4.Value;
                                    value4 = kq;
                                    if (value4 != "")
                                    {
                                        if (value4.Length >= 6)
                                        {
                                            value4 = value4.Substring(0, 4);
                                        }
                                        if (int.Parse(value4) > 500)
                                        {
                                            value4 = "0";
                                        }

                                        dr = dtPhy.NewRow();
                                        dr["MacAddress"] = mac;
                                        dr["value4"] = value4;
                                        dr["DateTime"] = dtime;
                                        dr["Status"] = "online";
                                        dtPhy.Rows.Add(dr);
                                    }
                                }
                            }
                        }


                    }

                    // bo sung
                    if (list1 != null)
                    {
                        DataRow dr;
                        for (int i = 0; i < list1.Count; i++)
                        {
                            value4 = "";
                            Regex rMac = new Regex(@"(\w+).(\w+).(\w+).(\w+)");
                            Match m3 = rMac.Match(list1[i]);
                            if (m3.Success)
                            {
                                string kq2 = m3.Value;
                                mac = kq2;

                                Regex rPHY = new Regex(@" (\d+){3} ");
                                Match m4 = rPHY.Match(list1[i]);
                                if (m3.Success)
                                {
                                    string kq = m4.Value;
                                    value4 = kq;
                                    if (value4 != "")
                                    {
                                        if (value4.Length >= 6)
                                        {
                                            value4 = value4.Substring(0, 4);
                                        }
                                        if (int.Parse(value4) > 500)
                                        {
                                            value4 = "0";
                                        }

                                        dr = dtPhy.NewRow();
                                        dr["MacAddress"] = mac;
                                        dr["value4"] = value4;
                                        dr["DateTime"] = dtime;
                                        dr["Status"] = "online";
                                        dtPhy.Rows.Add(dr);
                                    }
                                }
                            }

                        }
                    }
                    // het phan bo sung
                // noi du lieu
                    string txt = "";
                    DataRow[] result = null;
                    DataRow[] result2 = null;
                    value4 = "";
                    Class.CMTS cls = new Class.CMTS();
                    if (dt.Rows.Count > 0)
                    {
                        if (dtRe.Rows.Count > 0)
                        {
                            // begin Append
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                txt = dt.Rows[i]["MacAddress"].ToString();
                                result = dtRe.Select("MacAddress ='" + txt + "'");
                                dt.Rows[i]["DateTime"] =dtime;
                                foreach (DataRow row in result)
                                {
                                    dt.Rows[i]["IpPrivate"] = row["IpPrivate"].ToString();
                                    dt.Rows[i]["Location"] = row["Location"].ToString();
                                    dt.Rows[i]["value1"] = row["value1"].ToString();
                                    dt.Rows[i]["value2"] = row["value2"].ToString();
                                    dt.Rows[i]["value3"] = row["value3"].ToString();
                                    dt.Rows[i]["Status"] = row["Status"].ToString();
                                }

                                result2 = dtPhy.Select("MacAddress ='" + txt + "'");
                                foreach (DataRow row in result2)
                                {                                   
                                    dt.Rows[i]["value4"] = row["value4"].ToString();
                                }

                                if (dt.Rows[i]["Status"].ToString() == "online")
                                {
                                    if (dt.Rows[i]["value4"] == DBNull.Value)
                                    {
                                        Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                                        Thread.Sleep(2);
                                        cls.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                                        dt.Rows[i]["value4"] = value4;

                                    }
                                    else if (dt.Rows[i]["value4"].ToString().Trim() == "")
                                    {
                                        Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                                        Thread.Sleep(2);
                                        cls.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                                        dt.Rows[i]["value4"] = value4;
                                    }
                                }
                                Waiting.SetWaitFormDescription("Bắt đầu tiến hành nối Dữ liệu.!(" + (i + 1) + ")");
                                Thread.Sleep(1);                                              

                            }
                        }   
                    }
                    // het theo kieu load het Modem
                    /////////////////////////////////////////////////////////////
                           
                

                //Waiting.SetWaitFormDescription("Lưu thông số thiết bị vào CSDL");
                //Class.NW_Device clsdv = new Class.NW_Device();

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Waiting.SetWaitFormDescription("Lưu dữ liệu thiết bị : " + (i + 1));
                //    Thread.Sleep(1);
                //    clsdv.MacAddress = dt.Rows[i]["MacAddress"].ToString();
                //    clsdv.IpPrivate = dt.Rows[i]["IpPrivate"].ToString();
                //    clsdv.IpPublic1 = dt.Rows[i]["IpPublic1"].ToString();
                //    clsdv.IpPublic2 = dt.Rows[i]["IpPublic2"].ToString();
                //    clsdv.Value1 = dt.Rows[i]["Value1"].ToString();
                //    clsdv.Value2 = dt.Rows[i]["Value2"].ToString();
                //    clsdv.Value3 = dt.Rows[i]["Value3"].ToString();
                //    clsdv.Value4 = dt.Rows[i]["Value4"].ToString();
                //    clsdv.Location = dt.Rows[i]["Location"].ToString();
                //    clsdv.Status = dt.Rows[i]["Status"].ToString();
                //    clsdv.DateTime = (DateTime)dt.Rows[i]["DateTime"];
                //    clsdv.UpdateSignal();
                //}                   

                Waiting.CloseWaitForm();
                //btnChart_ItemClick(null, null);
            }
            catch {
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
                if(Waiting.IsSplashFormVisible)
                     Waiting.CloseWaitForm();
            }

           
        }

        private void gridItemDetail_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (gridItemDetail.FocusedRowHandle > -1)
                {
                    string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                    if (mac != "")
                    {
                        if (gridItemDetail.FocusedColumn.Name == "colChart")
                        {
                            frmSignalChart frm = new frmSignalChart(mac,1);
                            frm.ShowDialog();
                        }
                        else if (gridItemDetail.FocusedColumn.Name == "colIpPrivate")
                        {
                            frmCn_adminWeb frm = new frmCn_adminWeb(mac, "history CNADMIN");
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmSignalHistory frm = new frmSignalHistory(mac,1);
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btnLoadAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang kêt nôi đến hệ thống khách hàng.!");
            gridItem.Enabled = false;
            if (gridItemDetail.RowCount > 0)
            {
                Class.CN_ADMIN cn = new Class.CN_ADMIN();
                if (!cn.isLogin())
                {
                    cn.Connect(Class.CN_ADMIN.User, Class.CN_ADMIN.Passwors);
                }
                string mac = "";
                string CustomerName = "";
                string Address = "";
                string Ward = "";
                string District = "";
                List<string> l = new List<string>();
               
                Waiting.SetWaitFormDescription("Đang kêt kiểm tra đăng nhập.!");
                if (cn.isLogin())
                {
                    Waiting.SetWaitFormDescription("Đang Tải thông tin khách hàng.!");
                    for (int i = 0; i < gridItemDetail.RowCount; i++)
                    {
                        CustomerName = ""; Address = "";
                        if (gridItemDetail.GetRowCellDisplayText(i,colMacAdress).ToString().Length > 1)
                        {
                            // thuc hien lay mac theo dinh dang
                            mac = gridItemDetail.GetRowCellDisplayText(i, colMacAdress).ToString();
                            mac = mac.Replace(".", "");
                            mac = mac.Replace(".", "");
                            // khoi thao mac theo dinh dang
                            mac = mac.Insert(2, ":");
                            mac = mac.Insert(5, ":");
                            mac = mac.Insert(8, ":");
                            mac = mac.Insert(11, ":");
                            mac = mac.Insert(14, ":");

                            // l = cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward);
                            cn.Device__Edit_View(mac, out CustomerName, out Address, out Ward, out District);
                            gridItemDetail.SetRowCellValue(i, colCustomerName, CustomerName);
                            gridItemDetail.SetRowCellValue(i, colCustomerAddress, Address);
                            gridItemDetail.SetRowCellValue(i, colWard, Ward);
                            gridItemDetail.SetRowCellValue(i, colDisTrict, District);
                            //dt.Rows[i]["CustomerName"] = CustomerName;
                            //dt.Rows[i]["CustomerAddress"] = Address;
                            //dt.Rows[i]["Ward"] = Ward;
                            //dt.Rows[i]["District"] = District;
                        }
                    }
                }
               
                Waiting.SetWaitFormDescription("Hoàn tất quá trình tải.!");
            }
            gridItem.Enabled = true;
            Waiting.CloseWaitForm();
        }

        private void frmDeviceList_Request_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
                this.Dispose();
            }
            catch { }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 1)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel File|*.xlsx";
                saveFile.Title = "Exprot to Excel File";
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                    gridItem.ExportToXlsx(saveFile.FileName);

            }
        }

        void LoadBieuDoNode()
        {
            Class.NW_Node clsN= new Class.NW_Node();
            Class.NW_Device clsDe= new Class.NW_Device();
            DataTable dtDevice = new DataTable();
            DataTable dtNode = clsN.NW_Node_GetList();
            dtNode.Columns.Add("TotalOn");
            dtNode.Columns.Add("TotalOff");
            int on = 0;
            int off = 0;
            for (int i = 0; i < dtNode.Rows.Count; i++)
            {
                on = 0; off = 0;
                clsDe.NodeCode=dtNode.Rows[i]["NodeCode"].ToString();
                dtDevice = clsDe.NW_Device_GetByNodeCode();

                for (int j = 0; j < dtDevice.Rows.Count; j++)
                {
                    if (dtDevice.Rows[j]["Status"].ToString() == "online")
                        on++;
                    else
                        off++;
                }
                dtNode.Rows[i]["TotalOn"] = on;
                dtNode.Rows[i]["TotalOff"] = off;
            }
            // load bieu do
            frmSignalChartDetail frm = new frmSignalChartDetail(dtNode);
            frm.ShowDialog();
        }

        private void btnChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadBieuDoNode();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            NW_Node_GetList();
            NW_Device_GetList();
        }

        private void btnNodeStatic_Click(object sender, EventArgs e)
        {
            frmDeviceList_Request_Static frm = new frmDeviceList_Request_Static();
            frm.Show();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
                Class.NW_Device cls = new Class.NW_Device();
                DataTable dtt = cls.NW_Device_GetStatic();
                if (dtt.Rows.Count > 0)
                {
                    int dem = 0;
                    string tb = "Cảnh báo node mất tín hiệu: \r\n";
                    for (int i = 0; i < dtt.Rows.Count; i++)
                    {
                        if ((int)dtt.Rows[i]["Value1"] == 0)
                        {
                            tb += dtt.Rows[i]["NodeName"].ToString() + "\r\n";
                            dem++;
                        }
                    }
                    if (dem > 0)
                    {
                        if (File.Exists(Application.StartupPath + @"/media/buzz.wav"))
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

                            player.SoundLocation = Application.StartupPath + "/media/buzz.wav";
                            player.Play();
                        }
                        alertControl.Show(this, "Cảnh báo tín hiệu :", tb);
                    }

                }
            
        }
    }
}