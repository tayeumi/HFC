using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using SnmpSharpNet;


namespace HFC.Forms
{
    public partial class frmSignalRepair : DevExpress.XtraEditors.XtraForm
    {
        public frmSignalRepair()
        {
            InitializeComponent();
        }
        string template_grid = Application.StartupPath + @"\Templates\Templates_SignalRepair.xml";

        private void frmSignalRepair_Load(object sender, EventArgs e)
        {
           
           // LoadRemoteCard();
            Class.NW_Interface cls = new Class.NW_Interface();
            gridItemRemote.DataSource = cls.NW_Interface_Getlist();


            NW_Device_GetList();

            // restore layout
            if (File.Exists(template_grid))
            {
                // gridItemDetail.SaveLayoutToXml(template_grid);
                gridItemDetail.RestoreLayoutFromXml(template_grid);
            }
        }
        void NW_Device_GetList()
        {
            Class.NW_Device cls = new Class.NW_Device();
            cls.MacAddress = " ";
            dt = cls.NW_Device_GetByMac();
            gridItem.DataSource = dt;

            LoadLowSignal();
           
        }

        DataTable dt = new DataTable();
       
        private void gridItemDetailRemote_DoubleClick(object sender, EventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            if (btnConnect.Enabled)
                btnConnect_ItemClick(null, null);

            if (btnConnect.Enabled)
                return;

            timerCountNotUse.Enabled = true;
            count = 0;// de tu dong ngat knoi CMTS sau 4 phút ko sử dụng

            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông số Remote.!");

                if (!btnConnect.Enabled)
                {
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();
                    string value1 = "";
                    string value2 = "";
                    string value3 = "";
                    string mac = "";
                    string IpPrivate = "";
                    string status = "";
                    string location = "";

                    int SelectedRow = gridItemDetailRemote.FocusedRowHandle;
                    if (SelectedRow >= 0)
                    {
                       
                        dt.Rows.Clear();
                        DataRow drow = gridItemDetailRemote.GetDataRow(SelectedRow);
                        string _Card = drow["Interface"].ToString();
                        string[] list = null;

                        if (radioRemote.EditValue.ToString() == "All" || radioRemote.EditValue.ToString() == "Remote")
                        {
                            // lay remote
                            cmts.Remote_Card(_Card, out list);
                            if (list != null)
                            {

                                DataRow dr;
                                for (int i = 0; i < list.Length; i++)
                                {
                                    // lay online
                                    if (list[i].IndexOf("MOT") < 0) // kiem tra
                                    {
                                        Regex r = new Regex(@"(\d+)/0(.*)[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}(.*)line");
                                        Match m = r.Match(list[i]);
                                        while (m.Success)
                                        {
                                            string kq = m.Value;
                                            kq = kq.Trim();
                                            while (kq.IndexOf("  ") > 0)
                                            {
                                                kq = kq.Replace("  ", " ");
                                            }
                                            string[] cat = kq.Split(' ');
                                            if (cat.Length == 10)
                                            {

                                                location = cat[0] + "-" + cat[1] + "-" + cat[2];
                                                mac = cat[3];
                                                value1 = cat[4];
                                                value2 = cat[5];
                                                value3 = cat[6];
                                                status = cat[9];

                                                if (mac.Trim() != "")
                                                {
                                                    dr = dt.NewRow();
                                                    dr["MacAddress"] = mac;
                                                    dr["IpPrivate"] = IpPrivate;
                                                    dr["value1"] = value1;
                                                    dr["value2"] = value2;
                                                    dr["value3"] = value3;
                                                    dr["Location"] = location;
                                                    dr["Status"] = status;
                                                    dr["DateTime"] = dtime;
                                                    dt.Rows.Add(dr);
                                                }

                                            }

                                            m = m.NextMatch();
                                        }                                      

                                    }
                                }
                            }
                            // lay IP private va trang thai
                            if (dt.Rows.Count > 1) // co Remote thi moi lay PHY
                            {
                                string[] listI = null;
                                cmts.Stast_Card(_Card, out listI);
                                if (listI != null)
                                {
                                    for (int ll = 0; ll < dt.Rows.Count; ll++)
                                    {

                                        for (int li = 0; li < listI.Length; li++)
                                        {
                                            Regex rIp = new Regex(@"(\d+)/0(.*)(\d+).(\d+).(\d+).(\d+) (.*)[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}");
                                            Match _rip = rIp.Match(listI[li]);
                                                    while (_rip.Success)
                                                    {
                                                        string kqIP = _rip.Value;
                                                        while (kqIP.IndexOf("  ") > 0)
                                                        {
                                                            kqIP = kqIP.Replace("  ", " ");
                                                        }
                                                        string[] catchuoi = kqIP.Split(' ');
                                                        if (catchuoi.Length == 9)
                                                        {
                                                            if (catchuoi[8] == dt.Rows[ll]["MacAddress"].ToString())
                                                            {
                                                                dt.Rows[ll]["IpPrivate"] = catchuoi[7];
                                                                dt.Rows[ll]["Status"] = catchuoi[4];
                                                            }
                                                            
                                                        }

                                                        _rip = _rip.NextMatch();
                                                    }

                                        }

                                    }
                                }
                            }
                            //
                            if (radioRemote.EditValue.ToString() == "All")
                            {
                                // lay PHY
                                if (dt.Rows.Count > 1) // co Remote thi moi lay PHY
                                {                                   
                                    string value4 = "";
                                    string mac2 = "";
                                    string[] list2 = null;
                                    Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");
                                    List<string> list3= new List<string>();
                                    cmts.PHY_Card(_Card   , out list2,out list3);
                                    if (list2 != null)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            for (int j = 0; j < list2.Length; j++)
                                            {
                                                if (list2[j].IndexOf("MOT") < 0) // kiem tra
                                                {

                                                    Regex rMac = new Regex(@"(\w+).(\w+).(\w+).(\w+)");
                                                    Match m3 = rMac.Match(list2[j]);
                                                    if (m3.Success)
                                                    {
                                                        string kq2 = m3.Value;
                                                        mac2 = kq2;

                                                        Regex rPHY = new Regex(@" (\d+){3} ");
                                                        Match m4 = rPHY.Match(list2[j]);
                                                        if (m4.Success)
                                                        {
                                                            string kq = m4.Value;
                                                            value4 = kq;
                                                        }
                                                        if (dt.Rows[i]["MacAddress"].ToString() == mac2)
                                                        {
                                                            if (value4 == "")
                                                            {
                                                                value4 = "";
                                                            }
                                                            else
                                                            {
                                                                if (value4.Trim().Length > 3)
                                                                    value4 = "0";
                                                            }
                                                            dt.Rows[i]["value4"] = value4;
                                                        }
                                                    }                                                    
                                                }
                                            }
                                        }
                                    }
                                    // bo sung them
                                    if (list3 != null)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            for (int j = 0; j < list3.Count; j++)
                                            {
                                                if (list3[j].IndexOf("MOT") < 0) // kiem tra
                                                {

                                                    Regex rMac = new Regex(@"(\w+).(\w+).(\w+).(\w+)");
                                                    Match m3 = rMac.Match(list3[j]);
                                                    if (m3.Success)
                                                    {
                                                        string kq2 = m3.Value;
                                                        mac2 = kq2;

                                                        Regex rPHY = new Regex(@" (\d+){3} ");
                                                        Match m4 = rPHY.Match(list3[j]);
                                                        if (m4.Success)
                                                        {
                                                            string kq = m4.Value;
                                                            value4 = kq;
                                                        }
                                                        if (dt.Rows[i]["MacAddress"].ToString() == mac2)
                                                        {
                                                            if (value4 == "")
                                                            {
                                                                value4 = "";
                                                            }
                                                            else
                                                            {
                                                                if (value4.Trim().Length > 3)
                                                                    value4 = "0";
                                                            }
                                                            dt.Rows[i]["value4"] = value4;

                                                            // bo sung them lay phy
                                                            if (dt.Rows[i]["Status"].ToString() == "online")
                                                            {
                                                                if (dt.Rows[i]["value4"].ToString().Trim() == "")
                                                                {
                                                                    Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                                                                    // Thread.Sleep(1);
                                                                    cmts.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                                                                    dt.Rows[i]["value4"] = value4;
                                                                }
                                                            }
                                                            // het bo sung
                                                        }
                                                       
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    /// hêt bo sung
                                }
                            }
                            // het lay PHY
                        }
                        // chi lay PHY
                        if (radioRemote.EditValue.ToString() == "PHY")
                        {
                            dt.Rows.Clear();                            
                            string value4 = "";
                            string mac2 = "";
                            string[] list2 = null;
                            Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");
                            List<string> list3 = new List<string>();
                            cmts.PHY_Card(_Card, out list2, out list3);
                            if (list2 != null)
                            {
                                DataRow dr;
                                for (int j = 0; j < list2.Length; j++)
                                {
                                    if (list2[j].IndexOf("MOT") < 0) // kiem tra
                                    {
                                        value4 = "";
                                        Regex rMac = new Regex(@"[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4} ");
                                        Match m3 = rMac.Match(list2[j]);
                                        if (m3.Success)
                                        {
                                            string kq2 = m3.Value.Trim();
                                            mac2 = kq2;
                                            //\d+)/0(.*)[a-f0-9\-]{4}
                                            Regex rPHY = new Regex(@" (\d+)/0(.*) [0-9\-]{3} ");
                                            Match m4 = rPHY.Match(list2[j]);
                                            if (m4.Success)
                                            {
                                                string kq = m4.Value.Trim();
                                                while (kq.IndexOf("  ") > 0)
                                                    kq = kq.Replace("  ", " ");

                                                string[] catgt = kq.Split(' ');
                                                if (catgt.Length == 5)
                                                {
                                                    value4 = catgt[4];

                                                    dr = dt.NewRow();
                                                    dr["Location"] = catgt[0] + "-" + catgt[1] + "-" + catgt[2];
                                                    dr["MacAddress"] = mac2;
                                                    dr["value4"] = value4;
                                                    dr["DateTime"] = dtime;
                                                    dr["Status"] = "online";
                                                    dt.Rows.Add(dr);

                                                }
                                            }
                                        }
                                    }

                                }
                            }// het chi lay PHY thoi

                            // bo sung them neu lay thieu PHY
                            if (list3 != null)
                            {
                                DataRow dr;
                                for (int j = 0; j < list3.Count; j++)
                                {
                                    if (list3[j].IndexOf("MOT") < 0) // kiem tra
                                    {
                                        value4 = "";
                                        Regex rMac = new Regex(@"(\w+).(\w+).(\w+).(\w+)");
                                        Match m3 = rMac.Match(list3[j]);
                                        if (m3.Success)
                                        {
                                            string kq2 = m3.Value;
                                            mac2 = kq2;

                                            Regex rPHY = new Regex(@" (\d+){3} ");
                                            Match m4 = rPHY.Match(list3[j]);
                                            if (m4.Success)
                                            {
                                                string kq = m4.Value;
                                                value4 = kq;

                                                dr = dt.NewRow();
                                                dr["MacAddress"] = mac2;
                                                dr["value4"] = value4;
                                                dr["DateTime"] = dtime;
                                                dr["Status"] = "online";
                                                dt.Rows.Add(dr);
                                            }
                                        }
                                    }

                                }
                            }
                            // Het bo sung them
                        }
                    }
                }

                Waiting.CloseWaitForm();
            }
            catch (Exception ex) {
                Waiting.CloseWaitForm();
                MessageBox.Show(ex.Message);
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
            }
        }

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
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

        private void btnRemote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            if (btnConnect.Enabled)
                btnConnect_ItemClick(null, null);

            try
            {
                if (btnConnect.Enabled)
                    return;
                timerCountNotUse.Enabled = true;
                count = 0;// de tu dong ngat knoi CMTS sau 4 phút ko sử dụng
                //MessageBox.Show(txtDeviceDetail.GetDisplayText(txtDevice));

                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông số Remote.!");              
                if (txtDevice.EditValue != null && txtDevice.EditValue.ToString().Length > 3)
                {                    
                    Class.CMTS cmts = new Class.CMTS();
                    string value1 = "";
                    string value2 = "";
                    string value3 = "";
                    string IpPrivate = "";
                    string mac = "";
                    string status = "";
                    string location = "";
                    //string location2 = "";
                    DateTime dtime = DateTime.Now;
                    dt.Rows.Clear();                   
                    string _Card = txtDevice.EditValue.ToString().ToLower();
                    string[] list = null;
                                       
                        // lay remote
                        cmts.Remote_Card(_Card, out list);
                        if (list != null)
                        {

                            DataRow dr;
                            for (int i = 0; i < list.Length; i++)
                            {
                                                                                               
                                    // loc thong so
                                    Regex r = new Regex(@"(\d+)/0(.*)[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}(.*)line");
                                    Match m = r.Match(list[i]);
                                    while (m.Success)
                                    {
                                        string kq = m.Value;
                                        kq = kq.Trim();
                                        while (kq.IndexOf("  ") > 0)
                                        {
                                            kq = kq.Replace("  ", " ");
                                        }
                                        string[] cat = kq.Split(' ');
                                        if (cat.Length >8)
                                        {
                                           
                                            location = cat[0] + "-" + cat[1] + "-" + cat[2];
                                            mac = cat[3];
                                            value1 = cat[4];
                                            value2 = cat[5];
                                            value3 = cat[6];
                                            status = cat[9];

                                            if (mac.Trim() != "")
                                            {
                                                dr = dt.NewRow();
                                                dr["MacAddress"] = mac;
                                                dr["IpPrivate"] = IpPrivate;
                                                dr["value1"] = value1;
                                                dr["value2"] = value2;
                                                dr["value3"] = value3;
                                                dr["Location"] = location;
                                                dr["Status"] = status;
                                                dr["DateTime"] = dtime;
                                                dt.Rows.Add(dr);
                                            }

                                        }

                                        m = m.NextMatch();
                                    }                                  
  
                                
                            }
                        }                       
                   
                    
                    // lay PHY                       
                        if (checkPhy.Checked)
                        {
                            if (dt.Rows.Count > 0 && dt.Rows.Count < 5) // co Remote thi moi lay PHY
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["Status"].ToString() == "online")
                                    {
                                        mac = dt.Rows[i]["MacAddress"].ToString();
                                        string value4 = "";
                                        Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");
                                        cmts.Phy(mac, out value4);
                                        dt.Rows[i]["value4"] = value4;
                                        string IpPublic1 = "";
                                        string IpPublic2 = "";
                                        if (checkIpPublic.Checked)
                                        {
                                            // tai ip public
                                            Waiting.SetWaitFormDescription("Đang tải thông số IP Wan .!");
                                            string[] listIP = null;
                                            cmts.IPPublic(mac, out listIP);
                                            if (listIP != null)
                                            {
                                                Regex r = new Regex(@" [0-9\-]{3}.[0-9\-]{2}.(\d+).(\d+) ");
                                                int ck = 0;
                                                for (int k = 0; k < listIP.Length; k++)
                                                {
                                                    Match m = r.Match(listIP[k]);
                                                    while (m.Success)
                                                    {
                                                        if (m.Value.ToString().IndexOf("192.168") < 0)
                                                        {
                                                            ck++;
                                                            if (ck == 1)
                                                                IpPublic1 = m.Value.Trim();
                                                            if (ck == 2)
                                                                IpPublic2 = m.Value.Trim();

                                                            dt.Rows[i]["IpPublic1"] = IpPublic1;
                                                            dt.Rows[i]["IpPublic2"] = IpPublic2;
                                                        }
                                                        else if (m.Value.ToString().IndexOf("172.") < 0)
                                                        {
                                                            ck++;
                                                            if (ck == 1)
                                                                IpPublic1 = m.Value.Trim();
                                                            if (ck == 2)
                                                                IpPublic2 = m.Value.Trim();

                                                            dt.Rows[i]["IpPublic1"] = IpPublic1;
                                                            dt.Rows[i]["IpPublic2"] = IpPublic2;
                                                        }

                                                        m = m.NextMatch();
                                                    }

                                                }
                                            }
                                            // het lay ip wan
                                        }
                                    }
                                }

                            }
                            // het lay PHY   
                        }
                        // lay ip va trang thai
                        if (checkIpPublic.Checked)
                        {
                            Waiting.SetWaitFormDescription("Đang tải IP.!");
                            if (dt.Rows.Count > 0) // co Remote thi moi lay PHY
                            {
                                string[] listI = null;
                                cmts.Stast_Card(_Card, out listI);
                                if (listI != null)
                                {
                                    for (int ll = 0; ll < dt.Rows.Count; ll++)
                                    {

                                        for (int li = 0; li < listI.Length; li++)
                                        {
                                            Regex rIp = new Regex(@"(\d+)/0(.*)(\d+).(\d+).(\d+).(\d+) (.*)[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}");
                                            Match _rip = rIp.Match(listI[li]);
                                            while (_rip.Success)
                                            {
                                                string kqIP = _rip.Value;
                                                while (kqIP.IndexOf("  ") > 0)
                                                {
                                                    kqIP = kqIP.Replace("  ", " ");
                                                }
                                                string[] catchuoi = kqIP.Split(' ');
                                                if (catchuoi.Length == 9)
                                                {
                                                    if (catchuoi[8] == dt.Rows[ll]["MacAddress"].ToString())
                                                    {
                                                        dt.Rows[ll]["IpPrivate"] = catchuoi[7];
                                                        dt.Rows[ll]["Status"] = catchuoi[4];
                                                    }

                                                }

                                                _rip = _rip.NextMatch();
                                            }

                                        }

                                    }
                                }
                            }
                        }
                    // het lay ip va trang thai

                }
                gridItem.DataSource = dt;
                Waiting.CloseWaitForm();
            }
            catch {
                Waiting.CloseWaitForm();
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;            
            }
        }

        private void frmSignalRepair_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                gridItemDetail.SaveLayoutToXml(template_grid);
                this.Dispose();
            }
            catch { }
        }

        private void btnLoadCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang kết nối đến hệ thống khách hàng.!");
            
            if (gridItemDetail.RowCount > 0)
            {
                Class.CN_ADMIN cn = new Class.CN_ADMIN();
                if (!cn.isLogin())
                {
                    cn.Connect(Class.CN_ADMIN.User, Class.CN_ADMIN.Passwors);
                }
                string mac = "";
                List<string> l = new List<string>();
                Waiting.SetWaitFormDescription("Đang kêt kiểm tra đăng nhập.!");
                if (cn.isLogin())
                {
                    Waiting.SetWaitFormDescription("Đang Tải thông tin khách hàng.!");

                    for (int i = 0; i < gridItemDetail.RowCount; i++)
                    {

                        if (gridItemDetail.GetRowCellValue(i,colMacAdress).ToString().Length > 1)
                        {
                            // thuc hien lay mac theo dinh dang
                            mac = gridItemDetail.GetRowCellValue(i, colMacAdress).ToString().ToString();
                            mac = mac.Replace(".", "");
                            mac = mac.Replace(".", "");
                            // khoi thao mac theo dinh dang
                            mac = mac.Insert(2, ":");
                            mac = mac.Insert(5, ":");
                            mac = mac.Insert(8, ":");
                            mac = mac.Insert(11, ":");
                            mac = mac.Insert(14, ":");
                           
                            string CustomerName = "";
                            string Address = "";
                            string Ward = "";
                            string District="";
                            //     cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward);
                            cn.Device__Edit_View(mac, out CustomerName, out Address, out Ward, out District);
                            gridItemDetail.SetRowCellValue(i, colCustomerName, CustomerName);
                           // dt.Rows[i]["CustomerName"] = CustomerName;
                            gridItemDetail.SetRowCellValue(i, colCustomerAddress, Address);
                            //dt.Rows[i]["CustomerAddress"] = Address;
                            gridItemDetail.SetRowCellValue(i, colWard, Ward);
                            //dt.Rows[i]["Ward"] = Ward;
                            gridItemDetail.SetRowCellValue(i, colDistrict, District);
                           // dt.Rows[i]["District"] = District;
                            //}
                        }
                    }
                }
                Waiting.SetWaitFormDescription("Hoàn tất quá trình tải.!");
            }

            Waiting.CloseWaitForm();
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            if (dt.Rows.Count < 1)
                e.Cancel = true;
            
            if (Waiting.IsSplashFormVisible)
                    e.Cancel = true;

            btnAddtoNode.Enabled = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Checked"] != DBNull.Value)
                {
                    if ((bool)dt.Rows[i]["Checked"])
                    {
                        btnAddtoNode.Enabled = true;
                        break;
                    }
                }
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
                             frmCn_adminWeb frm = new frmCn_adminWeb(mac,"history CNADMIN");
                             frm.ShowDialog();

                        }                       
                        else 
                        {
                            frmSignalHistory frm = new frmSignalHistory(mac,0);
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btnAddtoNode_Click(object sender, EventArgs e)
        {
            frmDeviceToNode frm = new frmDeviceToNode(dt);
            frm.ShowDialog();
        }

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
                return;
            if (btnConnect.Enabled)
            {
                timerAuto.Enabled = false;
                btnAuto.Caption = "Tự tải thông số";
                return;
            }
            AutoLoad();
        }

        private void btnAuto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnConnect.Enabled)
            {
                timerAuto.Enabled = false;
                btnAuto.Caption = "Tự tải thông số";
                return;
            }
            if (txtDevice.EditValue.ToString().Length<3)
            {
                timerAuto.Enabled = false;
                btnAuto.Caption = "Tự tải thông số";
                return;
            }

            if (btnAuto.Caption == "Tự tải thông số")
            {
                timerAuto.Enabled = true;
                btnAuto.Caption = "";
                btnAuto.Caption = "Ngừng tải thông số";
            }
            else
            {
                timerAuto.Enabled = false;
                btnAuto.Caption = "Tự tải thông số";

            }
        }

        void AutoLoad()
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            try
            {
                if (btnConnect.Enabled)
                    return;
                timerAuto.Enabled = false;
                Waiting.ShowWaitForm();

                Waiting.SetWaitFormDescription("Đang tải thông số Remote.!");
                if (checkRemote.Checked)
                {
                    if (txtDevice.EditValue != null && txtDevice.EditValue.ToString().Length > 3)
                    {

                        Class.CMTS cmts = new Class.CMTS();
                        string value1 = "";
                        string value2 = "";
                        string value3 = "";
                        string IpPrivate = "";
                        string mac = "";
                        string status = "";
                        string location = "";
                        string location2 = "";
                        DateTime dtime = DateTime.Now;
                        dt.Rows.Clear();
                        string _Card = txtDevice.EditValue.ToString().ToLower();
                        string[] list = null;
                        int dem = 0;
                        // lay remote
                        cmts.Remote_Card(_Card, out list);
                        if (list != null)
                        {

                            DataRow dr;
                            for (int i = 0; i < list.Length; i++)
                            {
                                // lay online
                                
                                if (list[i].IndexOf("online") > 0)
                                    status = "online";
                                else
                                    status = "offline";
                                // location
                                Regex r2 = new Regex(@"(\d+)/(\d+)/(\w+) ");
                                Match m2 = r2.Match(list[i]);
                                while (m2.Success)
                                {
                                    dem++;
                                    if(dem==1)
                                    location = m2.Value.Trim();
                                    if(dem==2)
                                        location2 = m2.Value.Trim();
                                    m2 = m2.NextMatch();
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

                                    if (mac.Trim() != "")
                                    {
                                        dr = dt.NewRow();
                                        dr["MacAddress"] = mac;
                                        dr["IpPrivate"] = IpPrivate;
                                        dr["value1"] = value1;
                                        dr["value2"] = value2;
                                        dr["value3"] = value3;
                                        dr["Location"] = location;
                                        dr["Status"] = status;
                                        dr["DateTime"] = dtime;
                                        dt.Rows.Add(dr);
                                    }

                                    // neu du lieu bi kep
                                    if (location2 != "")
                                    {
                                        string txt = list[i].Substring(list[i].IndexOf(location2));
                                        Regex r3 = new Regex(@" (\d+).(\d+).(\d+).(\d+)(.*)(\w+).(\w+).(\w+)(.*)(\d+) ");
                                        Match m3 = r.Match(txt);
                                        if (m3.Success)
                                        {
                                            kq = m3.Value;
                                            kq = kq.Trim();
                                            kq = kq.Replace("  ", " ");
                                            kq = kq.Replace("  ", " ");
                                            kq = kq.Replace("  ", " ");

                                            cat = kq.Split(' ');

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

                                            if (mac.Trim() != "")
                                            {
                                                dr = dt.NewRow();
                                                dr["MacAddress"] = mac;
                                                dr["IpPrivate"] = IpPrivate;
                                                dr["value1"] = value1;
                                                dr["value2"] = value2;
                                                dr["value3"] = value3;
                                                dr["Location"] = location;
                                                dr["Status"] = status;
                                                dr["DateTime"] = dtime;
                                                dt.Rows.Add(dr);
                                            }
                                        }

                                    }
                                    // Het lay du lieu kep
                                }                               

                            }
                        }
                        // lay PHY                       
                        if (checkPhy.Checked)
                        {
                            if (dt.Rows.Count > 0 && dt.Rows.Count < 5) // co Remote thi moi lay PHY
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["Status"].ToString() == "online")
                                    {
                                        mac = dt.Rows[i]["MacAddress"].ToString();
                                        string value4 = "";
                                        Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");
                                        cmts.Phy(mac, out value4);
                                        dt.Rows[i]["value4"] = value4;
                                        string IpPublic1 = "";
                                        string IpPublic2 = "";
                                        // tai ip public
                                        if (checkIpPublic.Checked)
                                        {
                                            Waiting.SetWaitFormDescription("Đang tải thông số IP Wan .!");
                                            string[] listIP = null;
                                            cmts.IPPublic(mac, out listIP);
                                            if (listIP != null)
                                            {
                                                Regex r = new Regex(@" (\d+).(\d+).(\d+).(\d+) ");
                                                int ck = 0;
                                                for (int k = 0; k < listIP.Length; k++)
                                                {

                                                    Match m = r.Match(listIP[k]);
                                                    while (m.Success)
                                                    {
                                                        if (m.Value.ToString().IndexOf("192.168") < 0)
                                                        {
                                                            ck++;
                                                            if (ck == 1)
                                                                IpPublic1 = m.Value.Trim();
                                                            if (ck == 2)
                                                                IpPublic2 = m.Value.Trim();

                                                            dt.Rows[0]["IpPublic1"] = IpPublic1;
                                                            dt.Rows[0]["IpPublic2"] = IpPublic2;
                                                        }
                                                        m = m.NextMatch();
                                                    }

                                                }
                                            }
                                            /// het lay IP
                                        }
                                    }
                                }

                            }
                        }

                        // het lay PHY                      
                    }
                }
              if (!checkRemote.Checked && checkPhy.Checked)
                {
                    if (txtDevice.EditValue != null && txtDevice.EditValue.ToString().Length > 3)
                    {
                        Class.CMTS cmts = new Class.CMTS();
                        DateTime dtime = DateTime.Now;
                        dt.Rows.Clear();
                        string xulyphy;//, u, d;
                        xulyphy = txtDevice.EditValue.ToString();                        
                        string value4 = "";
                        string mac2 = "";
                        string[] list2 = null;
                        Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");
                        List<string> list3 = new List<string>();
                        cmts.PHY_Card(xulyphy, out list2, out list3);
                        if (list2 != null)
                        {
                            DataRow dr;
                            int dem = 0;
                            for (int j = 0; j < list2.Length; j++)
                            {
                                  value4 = "";
                                  dem = 0;
                                    Regex rMac = new Regex(@"(\w+){4}.(\w+){4}.(\w+){4} ");
                                    Match m3 = rMac.Match(list2[j]);
                                
                                    while (m3.Success)
                                    {
                                        dem++;
                                        string kq2 = m3.Value;
                                        kq2 = kq2.Replace("TDMA", "");
                                        if (dem == 1)
                                        {
                                            mac2 = kq2;

                                            Regex rPHY = new Regex(@" (\d+){3} ");
                                            Match m4 = rPHY.Match(list2[j]);
                                            if (m4.Success)
                                            {
                                                string kq = m4.Value;
                                                value4 = kq;

                                                dr = dt.NewRow();
                                                dr["MacAddress"] = mac2;
                                                dr["value4"] = value4;
                                                dr["DateTime"] = dtime;
                                                dr["Status"] = "online";
                                                dt.Rows.Add(dr);
                                            }
                                        }
                                        if (dem == 2)
                                        {
                                            mac2 = kq2;
                                            string txt = list2[j].Substring(list2[j].IndexOf(kq2));
                                            Regex rPHY = new Regex(@" (\d+){3} ");
                                            Match m5 = rPHY.Match(txt);
                                            if (m5.Success)
                                            {
                                               string kq = m5.Value;
                                                value4 = kq;

                                                dr = dt.NewRow();
                                                dr["MacAddress"] = mac2;
                                                dr["value4"] = value4;
                                                dr["DateTime"] = dtime;
                                                dr["Status"] = "online";
                                                dt.Rows.Add(dr);
                                            }

                                        }
                                        m3 = m3.NextMatch();
                                    }                                

                            }
                        }// het chi lay PHY thoi
                    }

                }
                timerAuto.Enabled = true;
                gridItem.DataSource = dt;
                Waiting.CloseWaitForm();
            }
            catch
            {
                Waiting.CloseWaitForm();
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;                
            }



        }

      

        private void txtDeviceDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //txtDevice.Refresh();txt
               // txtDevice.Edit.EndUpdate();
              if (txtDevice.EditValue != null)
              {
                    string mac =txtDevice.EditValue.ToString().ToLower();

                    if (mac.Length == 14)
                    {
                        frmSignalHistory frm = new frmSignalHistory(mac, 0);
                        frm.ShowDialog();
                    }
                    else
                    {
                        
                        btnRemote_ItemClick(null, null);
                    }
              }
                            
            }
           
                
               
            
         
        }

        private void btnGetme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                return;
            }
            if (btnConnect.Enabled)
                btnConnect_ItemClick(null, null);

            try
            {
                if (btnConnect.Enabled)
                    return;
                Waiting.ShowWaitForm();
                dt.Rows.Clear();
                Waiting.SetWaitFormDescription("Đang tải thông số thiết bị.!");
                string link = "http://101.99.28.157/ip.php";
                string result = "";
                WebClient client = new WebClient();
                try
                {
                    client.Headers.Add("Cache-Control", "no-cache");
                    result = client.DownloadString(link);
                }
                catch { }

                if (result != "")
                {
                    Waiting.SetWaitFormDescription("Đang tải thông số thiết bị.! \r\n Ip: "+result);
                    string value1="";
                    string value2 = "";
                    string value3 = "";
                    string value4 = "";
                    string location = "";
                    string mac="";
                    string status= "";
                    string IpPrivate="";
                    string IpPublic1="";
                    Class.CMTS cmts = new Class.CMTS();
                    Application.DoEvents();
                    cmts.Getme(result, out value1, out value2, out value3, out value4, out mac,out IpPrivate,out location,out status);
                    IpPublic1 = result;
                    if (mac != "")
                    {
                        //MessageBox.Show(mac);
                        DataRow dr;
                        dr = dt.NewRow();
                        dr["MacAddress"] = mac;
                        dr["IpPrivate"] = IpPrivate;
                        dr["value1"] = value1;
                        dr["value2"] = value2;
                        dr["value3"] = value3;
                        dr["value4"] = value4;
                        dr["Location"] = location;
                        dr["Status"] = status;
                        dr["IpPublic1"] = IpPublic1;  
                        dt.Rows.Add(dr);
                    }
                }

                gridItem.DataSource = dt;
                Waiting.CloseWaitForm();
            }
            catch
            {
                Waiting.CloseWaitForm();
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
            }
        }

        private void btnStopCMTS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Class.CMTS.tcpClient.Connected)
                {
                    Class.CMTS.Disconnect();
                    btnConnect.Enabled = true;
                }
            }
            catch { }
        }

        int count = 0;
        private void timerCountNotUse_Tick(object sender, EventArgs e)
        {
            count++;
            if (count > 240)
            {
                btnStopCMTS_ItemClick(null, null);
                count = 0;
            }
        }

        string tb = "";
        void LoadLowSignal()
        {
            Class.NW_InterfaceControllerWarning cls = new Class.NW_InterfaceControllerWarning();
            DataTable dttb = cls.NW_InterfaceControllerWarning_GetList_Low();
            gridSNR.DataSource = cls.NW_InterfaceControllerWarning_GetList();
            tb = "";
            if (dttb.Rows.Count > 0)
            {                
                for (int i = 0; i < dttb.Rows.Count; i++)
                {
                    tb += "(<i> "+((DateTime)dttb.Rows[i]["Datetime"]).ToString("dd/MM/yy H:m") +"</i> ) " + dttb.Rows[i]["InterfaceController"].ToString() + ":<color=red> " + dttb.Rows[i]["Signal"].ToString() +"</color> \n";
                   
                }
                             
                    if (File.Exists(Application.StartupPath + @"/media/buzz.wav"))
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

                        player.SoundLocation = Application.StartupPath + "/media/buzz.wav";
                        player.Play();
                    }
                    alertControl.Show(this, "Danh sách Nhiễu:", tb);
                
            }
            Class.NW_Device clsnode = new Class.NW_Device();
            gridNodeStatus.DataSource = clsnode.NW_Device_GetStatic();

        }

        private void timerNhieu_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadLowSignal();
            }
            catch { }
        }

        private void btnLog1Thang_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle > -1)
            {
                string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                if (mac != "")
                {
                    frmSignalHistory frm = new frmSignalHistory(mac);
                    frm.ShowDialog();
                }
            }
                     
        }

        private void btnBieudo1Thang_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle > -1)
            {
                string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                if (mac != "")
                {
                    frmSignalChart frm = new frmSignalChart(mac);
                    frm.ShowDialog();
                }
            }
        }

        private void groupItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                LoadLowSignal();
            }
            catch { }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.RowCount > 0)
            {
                for (int i = 0; i < gridItemDetail.RowCount; i++)
                {
                    gridItemDetail.SetRowCellValue(i, colChecked, true);
                }
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.RowCount > 0)
            {
                for (int i = 0; i < gridItemDetail.RowCount; i++)
                {
                    gridItemDetail.SetRowCellValue(i, colChecked, false);
                }
            }
        }

        private void btnXemIpPrivate_Click(object sender, EventArgs e)
        {
            if (gridItemDetail.FocusedRowHandle > -1)
            {
                string IP = gridItemDetail.GetFocusedRowCellValue(colIpPrivate).ToString();
                string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                if (IP.Trim() != "")
                {
                    frmCn_adminWeb frm = new frmCn_adminWeb(IP,0,mac);
                    frm.Show();
                }
            }
                     
        }

        private void btnCapnhattuModem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridItemDetail.FocusedRowHandle > -1)
                {
                    string IP = gridItemDetail.GetFocusedRowCellValue(colIpPrivate).ToString();
                    string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                    if (IP.Trim() != "")
                    {
                        if (IP.Trim() != "0.0.0.0")
                        {
                            // SNMP community name
                            OctetString community = new OctetString("LBC");

                            // Define agent parameters class
                            AgentParameters param = new AgentParameters(community);
                            // Set SNMP version to 1 (or 2)
                            param.Version = SnmpVersion.Ver1;

                            IpAddress agent = new IpAddress(IP);

                            // Construct target
                            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

                            // Pdu class used for all requests
                            Pdu pdu = new Pdu(PduType.Get);
                            pdu.VbList.Add("1.3.6.1.2.1.10.127.1.1.4.1.5.3"); //Noise  -- value1   
                            pdu.VbList.Add("1.3.6.1.2.1.10.127.1.2.2.1.3.2"); //US Power Level --- value2
                            pdu.VbList.Add("1.3.6.1.2.1.10.127.1.1.1.1.6.3"); //DS Power level     -- value3    


                            // Make SNMP request
                            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

                            // If result is null then agent didn't reply or we couldn't parse the reply.
                            if (result != null)
                            {
                                // ErrorStatus other then 0 is an error returned by 
                                // the Agent - see SnmpConstants for error definitions
                                if (result.Pdu.ErrorStatus != 0)
                                {
                                    // agent reported an error with the request
                                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                                        result.Pdu.ErrorStatus,
                                        result.Pdu.ErrorIndex);
                                }
                                else
                                {
                                    // Reply variables are returned in the same order as they were added
                                    //  to the VbList                   
                                    //  MessageBox.Show(result.Pdu.VbList[0].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) + ") " + result.Pdu.VbList[0].Value.ToString());
                                    //   MessageBox.Show(result.Pdu.VbList[1].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[1].Value.Type) + ") " + result.Pdu.VbList[1].Value.ToString());
                                    //  MessageBox.Show(result.Pdu.VbList[2].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[2].Value.Type) + ") " + result.Pdu.VbList[2].Value.ToString());
                                    gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue1, (float.Parse(result.Pdu.VbList[0].Value.ToString()) / 10).ToString());
                                    gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue2, (float.Parse(result.Pdu.VbList[1].Value.ToString()) / 10).ToString());
                                    gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue3, (float.Parse(result.Pdu.VbList[2].Value.ToString()) / 10).ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("No response received from SNMP agent.");
                            }
                            target.Close();

                        }
                    }
                }
            }
            catch { }
        }

        private void txtDeviceDetail_Leave(object sender, EventArgs e)
        {
            txtDevice.Refresh();
          // string tt= .ToString();
        }

        private void btnResetModem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridItemDetail.FocusedRowHandle > -1)
                {
                    string IP = gridItemDetail.GetFocusedRowCellValue(colIpPrivate).ToString();
                    string mac = gridItemDetail.GetFocusedRowCellValue(colMacAdress).ToString();
                    if (IP.Trim() != "")
                    {
                        if (IP.Trim() != "0.0.0.0")
                        {
                            UdpTarget target = new UdpTarget((IPAddress)new IpAddress(IP));
                            // Create a SET PDU
                            Pdu pdu = new Pdu(PduType.Set);
                            // Set sysLocation.0 to a new string
                           // pdu.VbList.Add(new Oid("1.3.6.1.2.1.1.6.0"), new OctetString("Some other value"));
                            // Set a value to integer
                            pdu.VbList.Add(new Oid(".1.3.6.1.2.1.69.1.1.3.0"), new Integer32(1));
                            // Set a value to unsigned integer
                         //   pdu.VbList.Add(new Oid("1.3.6.1.2.1.67.1.1.1.1.6.0"), new UInteger32(101));
                            // Set Agent security parameters
                            AgentParameters aparam = new AgentParameters(SnmpVersion.Ver2, new OctetString("LBC"));
                            // Response packet
                            SnmpV2Packet response;
                            try
                            {
                                // Send request and wait for response
                                response = target.Request(pdu, aparam) as SnmpV2Packet;
                            }
                            catch (Exception ex)
                            {
                                // If exception happens, it will be returned here
                                Console.WriteLine(String.Format("Request failed with exception: {0}", ex.Message));
                                target.Close();
                                return;
                            }
                            // Make sure we received a response
                            if (response == null)
                            {
                                Console.WriteLine("Error in sending SNMP request.");
                            }
                            else
                            {
                                // Check if we received an SNMP error from the agent
                                if (response.Pdu.ErrorStatus != 0)
                                {
                                    Console.WriteLine(String.Format("SNMP agent returned ErrorStatus {0} on index {1}",
                                      response.Pdu.ErrorStatus, response.Pdu.ErrorIndex));
                                }
                                else
                                {
                                    // Everything is ok. Agent will return the new value for the OID we changed
                                    Console.WriteLine(String.Format("Agent response {0}: {1}",
                                      response.Pdu[0].Oid.ToString(), response.Pdu[0].Value.ToString()));
                                }
                            }

                        }
                    }
                }
            }
            catch { }
        }

       
       
    }
}