﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.Threading;

namespace HFC.Forms
{
    public partial class frmSignalRequest : DevExpress.XtraEditors.XtraForm
    {
        public frmSignalRequest()
        {
            InitializeComponent();
        }
        DataTable dtInterface = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtPHY = new DataTable();
        DataTable dtSNR = new DataTable();
        DataTable dtIP = new DataTable();
        DataTable dtIPPublic = new DataTable();
        DataTable dtTraffic = new DataTable();
        DataTable dtTraffic_select = new DataTable();
        DataTable dtDevice = new DataTable();
        private void frmSignalRequest_Load(object sender, EventArgs e)
        {
            LoadInterface();
            NW_Device_GetList();
            loadSNR();
        }
        void loadSNR()
        {
            Class.NW_InterfaceControllerWarning cls = new Class.NW_InterfaceControllerWarning();
            dtSNR = cls.NW_InterfaceControllerWarning_GetList();
        }

        void LoadInterface()
        {
            Class.NW_Interface cls = new Class.NW_Interface();
            dtInterface = cls.NW_Interface_Getlist();
        }

        void NW_Device_GetList()
        {
            Class.NW_Device cls = new Class.NW_Device();
            cls.MacAddress = " ";
            dt = cls.NW_Device_GetByMac();
            dtPHY = cls.NW_Device_GetByMac();
            dtIP=cls.NW_Device_GetByMac();
            dtIPPublic = cls.NW_Device_GetByMac();
            dtTraffic = cls.NW_Device_GetByMac(); 
        }

        private void btnConnect_Click(object sender, EventArgs e)
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

        private void btnRemote_Click(object sender, EventArgs e)
        {
            try
            {
                if (Waiting.IsSplashFormVisible)
                {
                    Class.App.Log_WriteApp(" Treo o remote ");
                    return;
                }
                if (btnConnect.Enabled)
                    return;
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
                        string[] list = null;
                        dt.Rows.Clear();
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
                    }

                    Waiting.CloseWaitForm();
                    gridItem.DataSource = dt;
                }
                catch
                {
                    Waiting.CloseWaitForm();
                    //  MessageBox.Show(ex.Message);
                    Class.CMTS.tcpClient = null;
                    btnConnect.Enabled = true;
                }
            }
            catch { }
        }

        private void btnPHY_Click(object sender, EventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                Class.App.Log_WriteApp(" Treo o PHY ");
                return;
            }
            if (btnConnect.Enabled)
                return;
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải thông số PHY.!");

                if (!btnConnect.Enabled)
                {
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();
                    string value4 = "";
                    string mac = "";
                    string[] list = null;
                    dtPHY.Rows.Clear();
                    list = null;
                    List<string> list1 = new List<string>();
                    // lay remote
                    cmts.PHY_Card_all(out list, Waiting,out list1);
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
                               

                                Regex rPHY = new Regex(@" [0-9\-]{3} ");
                                Match m4 = rPHY.Match(list[i]);
                                if (m4.Success)
                                {
                                    string kq = m4.Value;
                                    value4 = kq;

                                    dr = dtPHY.NewRow();
                                    dr["MacAddress"] = mac;
                                    dr["value4"] = value4;
                                    dr["DateTime"] = dtime;
                                    dr["Status"] = "online";
                                    dtPHY.Rows.Add(dr);
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

                                Regex rPHY = new Regex(@" [0-9\-]{3} ");
                                Match m4 = rPHY.Match(list1[i]);
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

                                        dr = dtPHY.NewRow();
                                        dr["MacAddress"] = mac;
                                        dr["value4"] = value4;
                                        dr["DateTime"] = dtime;
                                        dr["Status"] = "online";
                                        dtPHY.Rows.Add(dr);
                                    }
                                }
                            }

                        }
                    }
                    // het phan bo sung
                }

                Waiting.CloseWaitForm();
                gridItem.DataSource = dtPHY;
            }
            catch 
            {
                Waiting.CloseWaitForm();
               // MessageBox.Show(ex.Message);
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = true;
                if (Class.CMTS.tcpClient.Connected)
                {
                    Class.CMTS.Disconnect();
                    btnConnect.Enabled = true;
                }
            }
            catch
            {
                btnStartFor10P_Click(null, null);
                Class.App.Log_WriteApp(" Treo o Disconnect ");

            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect_Click(null, null);
                Thread.Sleep(10);
                btnSNR_Click(null, null);
                Thread.Sleep(10);                
                btnRemote_Click(null, null);
                Thread.Sleep(10);
                btnPHY_Click(null, null);
                Thread.Sleep(10);
                btnLoadIP_Click(null, null);
                Thread.Sleep(10);
                btnIPPublic_Click(null, null);
                Thread.Sleep(10);
               // btnTraffic_Click(null, null);
                //Thread.Sleep(10);
                AppendData();
                gridItem.DataSource = dt;
                Thread.Sleep(10);          

                if (checkInsertData.Checked)
                    InsertData();

                btnDisconnect_Click(null, null);
            }
            catch
            {
                btnDisconnect_Click(null, null);
                //timer10.Enabled = true;
            }
        }

        void AppendData()
        {
            Waiting.ShowWaitForm();            
            
            Waiting.SetWaitFormDescription("Bắt đầu tiến hành nối Dữ liệu.!");

            string txt = "";
            DataRow[] result = null;
            DataRow[] resultIP = null;
            DataRow[] resultIPPublic = null;
           // DataRow[] resultTraffic = null;
            String value4 = "";
            Class.CMTS cls = new Class.CMTS();
            if (dt.Rows.Count > 0)
            {                
                    // begin Append
                   for( int i =0;i<dt.Rows.Count;i++)
                   {
                        txt = dt.Rows[i]["MacAddress"].ToString();
                        result = dtPHY.Select("MacAddress ='"+ txt +"'");
                        resultIP = dtIP.Select("MacAddress ='" + txt + "'");
                        resultIPPublic = dtIPPublic.Select("MacAddress ='" + txt + "'");
                        //resultTraffic = dtTraffic.Select("MacAddress ='" + txt + "'");
                       foreach (DataRow row in result)
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
                               if (value4 == "")
                                   value4 = "";
                               else
                               {
                                   if (int.Parse(value4) > 500)
                                       value4 = "0";
                               }
                               dt.Rows[i]["value4"] = value4;

                           }
                           else if (dt.Rows[i]["value4"].ToString().Trim() == "")
                           {
                               Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                               Thread.Sleep(2);
                               cls.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                               if (value4 == "")
                                   value4 = "";
                               else
                               {
                                   if (int.Parse(value4) > 500)
                                       value4 = "0";
                               }
                               dt.Rows[i]["value4"] = value4;
                           }
                       }
                       foreach (DataRow rowIp in resultIP)
                       {
                           dt.Rows[i]["IpPrivate"] = rowIp["IpPrivate"].ToString();
                           dt.Rows[i]["Status"] = rowIp["Status"].ToString();
                       }

                       foreach (DataRow rowIppublic in resultIPPublic)
                       {
                           if (dt.Rows[i]["IpPublic1"].ToString().Length > 5)
                           {
                               dt.Rows[i]["IpPublic1"] =dt.Rows[i]["IpPublic1"].ToString() + "-" + rowIppublic["IpPublic1"].ToString();

                               dt.Rows[i]["IpPublic2"] = dt.Rows[i]["IpPublic2"].ToString() + "-" + rowIppublic["IpPublic2"].ToString();
                           }
                           else
                           {
                               dt.Rows[i]["IpPublic1"] = rowIppublic["IpPublic1"].ToString();

                               dt.Rows[i]["IpPublic2"] = rowIppublic["IpPublic2"].ToString();
                           }
                       }
                       //foreach (DataRow rowTraffic in resultTraffic)
                       //{
                       //    dt.Rows[i]["CurrentDS"] = rowTraffic["CurrentDS"].ToString();
                       //    dt.Rows[i]["CurrentUS"] = rowTraffic["CurrentUS"].ToString();
                       //}

                     Waiting.SetWaitFormDescription("Bắt đầu tiến hành nối Dữ liệu.!("+(i+1)+")");
                     Thread.Sleep(1);
                     Application.DoEvents();
                   }
                
            }

            Waiting.CloseWaitForm();

        }

        void InsertData()
        {
            Waiting.ShowWaitForm();
            if (dt.Rows.Count > 0)
            {
                // them dl truoc khi insert
                int x = 0;
                int dem = 0;
                while (x < 3)
                {
                    dem = 0;
                    string value4;
                    Class.CMTS cmts = new Class.CMTS();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        value4 = "";

                        if (dt.Rows[i]["Status"].ToString() == "online")
                        {                         

                            if (dt.Rows[i]["Status"].ToString() == "online" && dt.Rows[i]["Value4"].ToString() == "")
                            {
                                dem++;
                                Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                                Thread.Sleep(2);
                                cmts.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                                Thread.Sleep(2);
                                if (value4 == "")
                                    value4 = "";
                                else
                                {

                                    if (int.Parse(value4) > 500)
                                        value4 = "0";
                                    if (value4.Length == 5)
                                    {
                                        value4 = value4.Substring(2);
                                    }
                                }
                                dt.Rows[i]["value4"] = value4;
                            }
                        }
                        if (value4 == "")
                        {
                            if (dt.Rows[i]["Status"].ToString() == "online")
                            {
                                if (dt.Rows[i]["Status"].ToString() == "online" && dt.Rows[i]["Value4"].ToString() == "")
                                {
                                    dem++;
                                    Waiting.SetWaitFormDescription(" Tải lại PHY mac " + dt.Rows[i]["MacAddress"].ToString());
                                    Thread.Sleep(2);
                                    cmts.Phy(dt.Rows[i]["MacAddress"].ToString(), out value4);
                                    if (value4 == "")
                                        value4 = "";
                                    else
                                    {
                                        if (int.Parse(value4) > 500)
                                            value4 = "0";
                                    }
                                    dt.Rows[i]["value4"] = value4;
                                }
                            }
                        }
                    }
                    if (dem == 0)
                        break;
                    x++;
                    Thread.Sleep(2);
                }

                Class.NW_SignalLog cls = new Class.NW_SignalLog();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                   Waiting.SetWaitFormDescription("Lưu dữ liệu thiết bị : "+(i+1));
                  cls.MacAddress = dt.Rows[i]["MacAddress"].ToString();
                  cls.IpPrivate = dt.Rows[i]["IpPrivate"].ToString();
                  cls.IpPublic1 = dt.Rows[i]["IpPublic1"].ToString();
                  cls.IpPublic2 = dt.Rows[i]["IpPublic2"].ToString();
                  cls.Value1 = dt.Rows[i]["Value1"].ToString();
                  cls.Value2 = dt.Rows[i]["Value2"].ToString();
                  cls.Value3 = dt.Rows[i]["Value3"].ToString();
                  cls.Value4 = dt.Rows[i]["Value4"].ToString();
                  cls.Status = dt.Rows[i]["Status"].ToString();
                  cls.Location = dt.Rows[i]["Location"].ToString();
                  cls.DateTime = (DateTime)dt.Rows[i]["DateTime"];
                  cls.Description = dt.Rows[i]["Description"].ToString();
                  cls.CurrentDS = dt.Rows[i]["CurrentDS"].ToString();
                  cls.CurrentUS = dt.Rows[i]["CurrentUS"].ToString();
                  cls.Insert();
                }
            }
            Waiting.CloseWaitForm();
        }
        int num = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            timerRepeat.Enabled = true;            
        }

        private void timerRepeat_Tick(object sender, EventArgs e)
        {
            try
            {
                num++;
                if (num >= int.Parse(txtTimeRe.Text))
                {
                    timerRepeat.Enabled = false;
                    btnLoadAll_Click(null, null);
                    num = 0;
                    timerRepeat.Enabled = true;
                }
                lblTime.Text = "Time: " + num;
            }
            catch
            {
                num = 0;
                timerRepeat.Enabled = true;
            }
        }

        private void btnStartFor10P_Click(object sender, EventArgs e)
        {
            if (checkTraffic.Checked)
            {
                btnStartFor10P.Enabled = false;
                timer30.Enabled = true;
            }
            else if (checkMaps.Checked)
            {
                btnStartFor10P.Enabled = false;
                timerMaps.Enabled = true;
                timerMaps_Tick(null, null);
            }
            else
            {
                btnStartFor10P.Enabled = false;
                timer10.Enabled = true;
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            try
            {
                int Min = DateTime.Now.Minute;
                if (Min == 0  || Min == 20 || Min == 40)
                {
                    if (Min == 10)
                    {
                        if(checkBW.Checked)
                            Load_InsertInterface();
                    }

                        timer10.Enabled = false;
                        btnLoadAll_Click(null, null);
                        timer10.Enabled = true;                   
                }
            }
            catch (Exception ex)
            {
                Class.App.Log_WriteApp(ex.Message.ToString());
                timer10.Enabled = true;
            }
        }
              

        void Load_InsertInterface()
        {
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang đọc và tải Interface từ SolarWinds");
                string txt = "select * from Interfaces where NodeID=18 and InterfaceName LIKE 'Cable Downstream%' or InterfaceName ='gigaether15/0'";
                Class.SolarWinds_Get clsSolarwind = new Class.SolarWinds_Get();
                clsSolarwind.DateTime = DateTime.Now;
                clsSolarwind.StrDate = DateTime.Now.ToString("dd/MM/yyyy H") + "h";
                DataTable dtSolarWind = clsSolarwind.SolarWinds_GetInterface(txt);
                if (dtSolarWind.Rows.Count > 0)
                    clsSolarwind.Insert(dtSolarWind);
                Waiting.CloseWaitForm();
            }
            catch {
                Waiting.CloseWaitForm();
            }
        }

        private void checkBW_CheckedChanged(object sender, EventArgs e)
        {
           // Load_InsertInterface();
        }

        private void btnSNR_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();

            Waiting.SetWaitFormDescription("Đang truy xuất Thông số nhiễu.!");
            try
            {
                if (!btnConnect.Enabled)
                {
                    string Signal0 = "";
                    string Signal1 = "";
                    string Signal2 = "";
                    string Signal3 = "";
                    string Signal4 = "";
                    string Signal5 = "";
                    string Signal6 = "";
                    string Signal7 = "";
                    dtSNR.Rows.Clear();
                    DataRow dr;
                    Class.CMTS cmts = new Class.CMTS();

                    cmts.SNR("0/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "0/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }

                    cmts.SNR("1/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "1/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }

                    cmts.SNR("2/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "2/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }

                    cmts.SNR("3/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "3/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }
                    cmts.SNR("4/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "4/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }

                    cmts.SNR("5/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "5/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }
                    cmts.SNR("9/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "9/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }
                    cmts.SNR("10/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "10/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);
                    }
                    cmts.SNR("11/0", out Signal0, out Signal1, out Signal2, out Signal3, out Signal4, out Signal5, out Signal6, out Signal7);
                    if (Signal0 != "")
                    {
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U0";
                        dr["Signal"] = Signal0;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U1";
                        dr["Signal"] = Signal1;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U2";
                        dr["Signal"] = Signal2;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U3";
                        dr["Signal"] = Signal3;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U4";
                        dr["Signal"] = Signal4;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U5";
                        dr["Signal"] = Signal5;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U6";
                        dr["Signal"] = Signal6;
                        dtSNR.Rows.Add(dr);
                        dr = dtSNR.NewRow();
                        dr["InterfaceController"] = "11/0-U7";
                        dr["Signal"] = Signal7;
                        dtSNR.Rows.Add(dr);


                    }

                    if (dtSNR.Rows.Count > 0)
                    {

                        Class.NW_InterfaceControllerWarning clsI = new Class.NW_InterfaceControllerWarning();
                        clsI.DeleteAll();
                        Waiting.SetWaitFormDescription(" Tiến hành ghi dữ liệu !");
                        clsI.Insert(dtSNR);
                    }
                }
            }
            catch {
                btnDisconnect_Click(null, null);
                Class.App.Log_WriteApp(" Treo o tai SNR ");                
            }
            Waiting.CloseWaitForm();
        }

        private void btnLoadIP_Click(object sender, EventArgs e)
        {            
            if (Waiting.IsSplashFormVisible)
            {
                Class.App.Log_WriteApp(" Treo o Load IP ");
                return;
            }
            if (btnConnect.Enabled)
                return;
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải IP.!");

                if (!btnConnect.Enabled)
                {
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();                   
                    string[] list = null;
                    dtIP.Rows.Clear();
                    list = null;
                 
                    // lay remote
                    cmts.Stast_Card_All(out list);
                    if (list != null)
                    {
                        DataRow dr;
                        for (int i = 0; i< list.Length; i++)
                        {
                            Regex rIp = new Regex(@"(\d+)/0(.*)(\d+).(\d+).(\d+).(\d+) (.*)[a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}");
                            Match _rip = rIp.Match(list[i]);
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
                                    dr = dtIP.NewRow();
                                    dr["MacAddress"] = catchuoi[8];
                                    dr["IpPrivate"] = catchuoi[7];
                                    dr["DateTime"] = dtime;
                                    dr["Status"] = catchuoi[4];
                                    dtIP.Rows.Add(dr);

                                }

                                _rip = _rip.NextMatch();
                            }
                        }


                    }

                   
                }

                Waiting.CloseWaitForm();
                gridItem.DataSource = dtIP;
            }
            catch
            {
                Waiting.CloseWaitForm();
                // MessageBox.Show(ex.Message);
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
            }


        }

        private void btnIPPublic_Click(object sender, EventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                Class.App.Log_WriteApp(" Treo o tai IP Public ");
                return;
            }
            if (btnConnect.Enabled)
                return;
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải IP Public.!");

                if (!btnConnect.Enabled)
                {
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();
                    string[] list = null;
                    dtIPPublic.Rows.Clear();
                    list = null;

                    // lay remote
                    cmts.Get_IPPublic(out list);
                    if (list != null)
                    {
                        DataRow dr;
                        for (int i = 0; i < list.Length; i++)
                        {
                            Regex rIp = new Regex(@" [a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4} (.*)  [a-f0-9\-]{4}.[a-f0-9\-]{4}.[a-f0-9\-]{4}");
                            Match _rip = rIp.Match(list[i]);
                            while (_rip.Success)
                            {
                                string kqIP = _rip.Value.Trim();
                                while (kqIP.IndexOf("  ") > 0)
                                {
                                    kqIP = kqIP.Replace("  ", " ");
                                }
                                string[] catchuoi = kqIP.Split(' ');
                                if (catchuoi.Length == 3)
                                {
                                    dr = dtIPPublic.NewRow();
                                    dr["MacAddress"] = catchuoi[0];
                                    dr["IpPublic1"] = catchuoi[1];
                                    dr["IpPublic2"] = catchuoi[2];
                                    dr["DateTime"] = dtime;
                                    dtIPPublic.Rows.Add(dr);

                                }

                                _rip = _rip.NextMatch();
                            }
                        }


                    }


                }

                Waiting.CloseWaitForm();
                gridItem.DataSource = dtIPPublic;
            }
            catch
            {
                Waiting.CloseWaitForm();
                Class.CMTS.tcpClient = null;
                btnConnect.Enabled = true;
            }
        }
               

        private void btnTraffic_Click(object sender, EventArgs e)
        {
            if (Waiting.IsSplashFormVisible)
            {
                Class.App.Log_WriteApp("Treo o traffic dau tien ");
                return;
            }
            if (btnConnect.Enabled)
                return;
            try
            {
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải Traffic.!");

                if (!btnConnect.Enabled)
                {
                    DateTime dtime = DateTime.Now;
                    Class.CMTS cmts = new Class.CMTS();
                    string list = null;
                    dtTraffic.Rows.Clear();
                    list = null;
                    string[] cat = null;
                    // lay tracffic
                    #region traffic
                    Waiting.SetWaitFormDescription("Đang tải Traffic 0/0.!");
                    cmts.Get_Traffic("sh cable modem 0/0 stats \r\n", out list);
                    if (list != null)
                    {
                        //DataRow dr;
                        //Regex rTraffic = new Regex(@"MAC (.*)\n\rIP (.*)\n\r(.*):(.*):(.*)\n\rNumber (.*)\n\rTotal (.*)\n\rAverage (.*)\n\rInstant (.*)\n\rTotal (.*)\n\rAverage (.*)\n\rInstant (.*)\n\rTime(.*)\n\rTotal");
                        //Match _rTr = rTraffic.Match(list);
                        //while (_rTr.Success)
                        //{
                        //    string kqtr = _rTr.Value.Trim();
                        //    while (kqtr.IndexOf("  ") > 0)
                        //    {
                        //        kqtr = kqtr.Replace("  ", " ");
                        //    }
                        //    cat = kqtr.Split('\n');
                        //    int t = cat.Length;
                        //    if (cat.Length == 12)
                        //    {
                        //        cat[0] = cat[0].Replace("MAC Address:", "").ToString().Trim();
                        //        cat[0] = cat[0].Replace("\r", "").ToString().Trim();
                        //        cat[4] = cat[4].Replace("\rTotal US Data:", "").ToString().Trim();
                        //        cat[4] = cat[4].Replace("KBytes", "").ToString().Trim();
                        //        cat[7] = cat[7].Replace("\rTotal DS Data:", "").ToString().Trim();
                        //        cat[7] = cat[7].Replace("KBytes", "").ToString().Trim();
                        //        dr = dtTraffic.NewRow();
                        //        dr["MacAddress"] = cat[0];
                        //        dr["CurrentUS"] = cat[4];
                        //        dr["CurrentDS"] = cat[7];
                        //        dr["DateTime"] = dtime;
                        //        dtTraffic.Rows.Add(dr);

                        //    }
                        //    _rTr = _rTr.NextMatch();
                        //}
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                             while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                             cat = sp[i].Split(' ');
                             if (cat.Length == 8)
                             {                                 
                                 dr = dtTraffic.NewRow();
                                 dr["MacAddress"] = cat[5];
                                 dr["CurrentUS"] = cat[6];
                                 dr["CurrentDS"] = cat[7];
                                 dr["DateTime"] = dtime;
                                 dtTraffic.Rows.Add(dr);

                             }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 1/0.!");
                    // card 1/0
                    cmts.Get_Traffic("sh cable modem 1/0 stats \r\n", out list);
                    if (list != null)
                    {                        
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 2/0.!");
                    // card 2/0
                    cmts.Get_Traffic("sh cable modem 2/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 3/0.!");
                    // card 3/0
                    cmts.Get_Traffic("sh cable modem 3/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 4/0.!");
                    // card 4/0
                    cmts.Get_Traffic("sh cable modem 4/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 5/0.!");
                    // card 5/0
                    cmts.Get_Traffic("sh cable modem 5/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 9/0.!");
                    // card 9/0
                    cmts.Get_Traffic("sh cable modem 9/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 10/0.!");
                    // card 10/0
                    cmts.Get_Traffic("sh cable modem 10/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }

                    }
                    Waiting.SetWaitFormDescription("Đang tải Traffic 11/0.!");
                    // card 11/0
                    cmts.Get_Traffic("sh cable modem 11/0 stats \r\n", out list);
                    if (list != null)
                    {
                        string[] sp = list.Split('\n');
                        DataRow dr;
                        for (int i = 0; i < sp.Length; i++)
                        {
                            cat = null;
                            sp[i] = sp[i].Replace("\r", "");
                            sp[i] = sp[i].Trim();
                            while (sp[i].IndexOf("  ") > 0)
                            {
                                sp[i] = sp[i].Replace("  ", " ");
                            }
                            cat = sp[i].Split(' ');
                            if (cat.Length == 8)
                            {
                                dr = dtTraffic.NewRow();
                                dr["MacAddress"] = cat[5];
                                dr["CurrentUS"] = cat[6];
                                dr["CurrentDS"] = cat[7];
                                dr["DateTime"] = dtime;
                                dtTraffic.Rows.Add(dr);

                            }
                        }
                    }
                    #endregion
                }

                Waiting.CloseWaitForm();
                gridItem.DataSource = dtTraffic;
            }
            catch(Exception ex)
            {
                
                Waiting.CloseWaitForm();
                btnDisconnect_Click(null, null);
                Class.App.Log_WriteApp(ex.Message.ToString());
            }
        }

        private void timer30_Tick(object sender, EventArgs e)
        {
            try
            {
                int Min = DateTime.Now.Minute;
                if (Min == 10 || Min == 30 || Min == 50)
                {                    
                    timer30.Enabled = false;
                    try
                    {
                        btnConnect_Click(null, null);
                        Thread.Sleep(10);                       
                        btnTraffic_Click(null, null);
                        Thread.Sleep(10); 
                        btnDisconnect_Click(null, null);
                        // xu ly insert
                        Class.NW_CurrentTrafic cur = new Class.NW_CurrentTrafic();
                        dtTraffic_select = cur.NW_CurrentTrafic_GetAll();
                        DateTime timenow = DateTime.Now;
                        if (dtTraffic_select.Rows.Count < 1)
                        {
                            // lan dau insert ko can kiem tra va tinh luuluong
                            // tien hanh insert
                            Waiting.ShowWaitForm();
                            Waiting.SetWaitFormDescription(" Đang lưu dữ liệu ! ");
                           
                            for (int i = 0; i < dtTraffic.Rows.Count; i++)
                            {
                                cur.MacAddress = dtTraffic.Rows[i]["MacAddress"].ToString();
                                cur.DS = dtTraffic.Rows[i]["CurrentDS"].ToString();
                                cur.US = dtTraffic.Rows[i]["CurrentUS"].ToString();
                                cur.DateTime = timenow;
                                cur.CurrentDS = dtTraffic.Rows[i]["CurrentDS"].ToString();
                                cur.CurrentUS = dtTraffic.Rows[i]["CurrentUS"].ToString();
                                cur.Insert();
                                Waiting.SetWaitFormDescription(" Đang lưu dữ liệu ! (" + (i + 1).ToString() + ")");
                            }
                            Waiting.CloseWaitForm();
                        }
                        else
                        {
                            // het lan dau insert
                            DataRow[] result = null;
                            DataRow dr;
                            for (int i = 0; i < dtTraffic.Rows.Count; i++)
                            {
                                // cap nhat mac thieu luu luong
                                result = dtTraffic_select.Select("MacAddress ='" + dtTraffic.Rows[i]["MacAddress"].ToString() + "'");
                                if (result.Length > 0)
                                {
                                   
                                }
                                else
                                {
                                    dr = dtTraffic_select.NewRow();
                                    dr["MacAddress"] = dtTraffic.Rows[i]["MacAddress"].ToString();
                                    dr["DS"] = "0";
                                    dr["US"] = "0";
                                    dr["CurrentDS"] = "0";
                                    dr["CurrentUS"] = "0";
                                    dtTraffic_select.Rows.Add(dr);
                                }
                            }
                            Waiting.ShowWaitForm();
                            Waiting.SetWaitFormDescription(" Đang tính Lưu lượng ! ");
                            // bat dau tinh luu luong su dung
                           
                            double currds = 0;
                            double currus = 0;
                            double Oldcurrds = 0;
                            double Oldcurrus = 0;

                            for (int j = 0; j < dtTraffic_select.Rows.Count; j++)
                            {
                                result = dtTraffic.Select("MacAddress ='" + dtTraffic_select.Rows[j]["MacAddress"].ToString() + "'");
                                currds = 0;
                                currus = 0;
                                Oldcurrds = 0;
                                Oldcurrus = 0;
                                if (result.Length > 0)
                                {
                                    foreach (DataRow row in result)
                                    {
                                        dtTraffic_select.Rows[j]["DateTime"] = row["DateTime"];
                                        double.TryParse(row["CurrentDS"].ToString(), out currds);
                                        double.TryParse(row["CurrentUS"].ToString(), out currus);
                                        double.TryParse(dtTraffic_select.Rows[j]["CurrentDS"].ToString(), out Oldcurrds);
                                        double.TryParse(dtTraffic_select.Rows[j]["CurrentUS"].ToString(), out Oldcurrus);
                                        if (currds > Oldcurrds)
                                        {
                                            dtTraffic_select.Rows[j]["CurrentDS"] = currds;
                                            dtTraffic_select.Rows[j]["DS"] = (currds - Oldcurrds).ToString();
                                        }
                                        else if (currds == Oldcurrds)
                                        {
                                            dtTraffic_select.Rows[j]["CurrentDS"] = currds;
                                            dtTraffic_select.Rows[j]["DS"] = "0";
                                        }
                                        else
                                        {
                                            dtTraffic_select.Rows[j]["CurrentDS"] = currds;
                                            dtTraffic_select.Rows[j]["DS"] = currds.ToString();
                                        }

                                        if (currus > Oldcurrus)
                                        {
                                            dtTraffic_select.Rows[j]["CurrentUS"] = currus;
                                            dtTraffic_select.Rows[j]["US"] = (currus - Oldcurrus).ToString();
                                        }
                                        else if (currus == Oldcurrus)
                                        {
                                            dtTraffic_select.Rows[j]["CurrentUS"] = currus;
                                            dtTraffic_select.Rows[j]["US"] = "0";
                                        }
                                        else
                                        {
                                            dtTraffic_select.Rows[j]["CurrentUS"] = currus;
                                            dtTraffic_select.Rows[j]["US"] = currus.ToString();
                                        }

                                    }
                                }
                                else
                                {
                                    dtTraffic_select.Rows[j]["DateTime"] =timenow;
                                    dtTraffic_select.Rows[j]["DS"] = "0";
                                    dtTraffic_select.Rows[j]["US"] = "0";                                   
                                }
                            }
                            
                            // tinh xong luu luong, bat dau ghi du lieu vao csdl
                            
                            Waiting.SetWaitFormDescription(" Đang lưu dữ liệu ! ");
                            cur.DeleteAll();
                           
                            for (int i = 0; i < dtTraffic_select.Rows.Count; i++)
                            {
                                cur.MacAddress = dtTraffic_select.Rows[i]["MacAddress"].ToString();
                                cur.DS = dtTraffic_select.Rows[i]["DS"].ToString();
                                cur.US = dtTraffic_select.Rows[i]["US"].ToString();
                                cur.DateTime = (DateTime)dtTraffic_select.Rows[i]["DateTime"];
                                cur.CurrentDS = dtTraffic_select.Rows[i]["CurrentDS"].ToString();
                                cur.CurrentUS = dtTraffic_select.Rows[i]["CurrentUS"].ToString();
                                cur.Insert();
                                Waiting.SetWaitFormDescription(" Đang lưu dữ liệu ! (" + (i + 1).ToString() + ")");
                                Thread.Sleep(1);
                            }
                            Waiting.CloseWaitForm();

                        }
                    }
                    catch (Exception ex)
                    {
                        btnDisconnect_Click(null, null);
                        timer30.Enabled = true;
                        Class.App.Log_WriteApp(ex.Message.ToString());
                    }
                    timer30.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                timer30.Enabled = true;
                Class.App.Log_WriteApp(ex.Message.ToString());
            }
        }

        private void timerMaps_Tick(object sender, EventArgs e)
        {
            try
            {
                btnConnect_Click(null, null);
                Thread.Sleep(10);               
                btnRemote_Click(null, null);
                Thread.Sleep(10);                
                btnDisconnect_Click(null, null);
                loadDevice();
                gridItem.DataSource = dtDevice;
                Class.NW_Device de = new Class.NW_Device();
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Tiến trình lưu dữ liệu !");
                for (int i = 0; i < dtDevice.Rows.Count; i++)
                {
                    Waiting.SetWaitFormDescription("Tiến trình lưu dữ liệu ! (" +i.ToString()+")");
                    de.MacAddress = dtDevice.Rows[i]["MacAddress"].ToString();
                    de.Value1 = dtDevice.Rows[i]["Value1"].ToString();
                    de.Value2 = dtDevice.Rows[i]["Value2"].ToString();
                    de.Value3 = dtDevice.Rows[i]["Value3"].ToString();
                    de.DateTime = (DateTime)dtDevice.Rows[i]["DateTime"];
                    de.Status = dtDevice.Rows[i]["Status"].ToString();
                    de.Update();
                }
                Waiting.CloseWaitForm();
            }
            catch (Exception ex)
            {
                Class.App.Log_WriteApp(ex.Message.ToString());
                btnDisconnect_Click(null, null);
                //timer10.Enabled = true;
            }
        }

        void loadDevice()
        {
            dtDevice.Rows.Clear();
            Class.NW_Device dev = new Class.NW_Device();
            dtDevice = dev.NW_Device_GetList();
            DataRow[] result = null;
            string txt = "";
            for (int i = 0; i < dtDevice.Rows.Count; i++)
            {
                txt = dtDevice.Rows[i]["MacAddress"].ToString();
                result = dt.Select("MacAddress ='" + txt + "'");
                if (result.Length > 0)
                {
                    foreach (DataRow row in result)
                    {
                        dtDevice.Rows[i]["Status"] = row["Status"].ToString();
                        dtDevice.Rows[i]["Value1"] = row["Value1"].ToString();
                        dtDevice.Rows[i]["Value2"] = row["Value2"].ToString();
                        dtDevice.Rows[i]["Value3"] = row["Value3"].ToString();
                        dtDevice.Rows[i]["DateTime"] = (DateTime)row["DateTime"];
                    }
                }
                else
                {
                    dtDevice.Rows[i]["Status"] = "offline";
                }
            }
        }

    }
}