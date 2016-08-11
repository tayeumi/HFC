using System;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using Microsoft.Win32;

namespace HFC
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();           
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string skin = defaultGiaoDien.LookAndFeel.SkinName;
            Class.RegistryWriter rg = new Class.RegistryWriter();
            rg.WriteKey("style", skin);
            Application.Exit();
        }
        private static string config(string url, string bien)
        {
            string _config = "";
            XmlTextReader xmlReader = new XmlTextReader(url);
            while (xmlReader.Read())
            {
                if (xmlReader.Name == bien)
                {
                    _config = xmlReader.ReadElementString();
                }
            }
            xmlReader.Close();
            return _config;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            this.defaultGiaoDien.LookAndFeel.SkinName = rg.valuekey("style");

            this.Text = this.Text + " " + config("Config.xml", "company") + " V" + config("Config.xml", "version");
            btnDangNhap_ItemClick(null, null);
            SkinHelper.InitSkinPopupMenu(barSubItem4);


        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Owner = this;
            frm.ShowDialog();
            ribbon.SelectedPage= Menu_Action;
            if (Class.App.client_User != "admin")
            {
                Menu_Get.Visible = false;
                groupDHCP.Visible = false;
                if (Class.App.client_User == "super")
                {
                    btnDanhSachNode.Enabled = true;
                    btnDanhsachDevice.Enabled = true;
                }
                else
                {
                    btnDanhSachNode.Enabled = false;
                    btnDanhsachDevice.Enabled = false;
                }

                if (Class.App.client_User == "lapmoi")
                {
                    groupDHCP.Visible = true;
                }
            }
            else
            {
                Menu_Get.Visible = true;
                groupDHCP.Visible = true;


            }
        }

        private void btnDanhSachNode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmNodeList), this))
            {
                Forms.frmNodeList frm = new Forms.frmNodeList();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnDanhsachDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmDeviceList), this))
            {
                Forms.frmDeviceList frm = new Forms.frmDeviceList();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            
            if (!Class.App.IsFocusForm(typeof(Forms.frmDeviceList_Request), this))
            {
                //Class.NW_SignalLog cls = new Class.NW_SignalLog();
                //cls.DeleteFor30Day();
                Forms.frmDeviceList_Request frm = new Forms.frmDeviceList_Request();
                frm.MdiParent = this;
                frm.Show();
            }
           
            Waiting.CloseWaitForm();
        }

        private void btnCauHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCauHinh frm = new frmCauHinh();
            frm.ShowDialog();
        }

        private void btnSignalRepair_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmSignalRepair), this))
            {
                Forms.frmSignalRepair frm = new Forms.frmSignalRepair();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnCMTSRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmSignalRequest), this))
            {
                Forms.frmSignalRequest frm = new Forms.frmSignalRequest();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnBandWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmInterfaceSolarWind), this))
            {
                Forms.frmInterfaceSolarWind frm = new Forms.frmInterfaceSolarWind();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnTraffic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmTraffic), this))
            {
                Forms.frmTraffic frm = new Forms.frmTraffic();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnMonitor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmTrafficMonitor), this))
            {
                Forms.frmTrafficMonitor frm = new Forms.frmTrafficMonitor();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnMaps_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Class.App.IsFocusForm(typeof(Forms.frmMaps), this))
            {
                Forms.frmMaps frm = new Forms.frmMaps();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!Class.App.IsFocusForm(typeof(Forms.frmHome), this))
            {
                Forms.frmHome frm = new Forms.frmHome();
                frm.MdiParent = this;
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnOpticalSW_ItemClick(object sender, ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!Class.App.IsFocusForm(typeof(Forms.frmOpticalSW), this))
            {
                Forms.frmOpticalSW frm = new Forms.frmOpticalSW();
                frm.MdiParent = this;
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        private void btnDHCPCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!Class.App.IsFocusForm(typeof(Forms.frmDHCPCustomer), this))
            {
                Forms.frmDHCPCustomer frm = new Forms.frmDHCPCustomer();
                frm.MdiParent = this;
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void btnKetNoiTuXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("TeamViewer"))
                {
                    if (!p.HasExited)
                    {
                        p.Kill();
                        p.WaitForInputIdle();
                    }
                }
                // ghi regedit cho phep het noi qua mang LAN
                RegistryKey rekey64 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\TeamViewer\\Version7");
                RegistryKey writekey64 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\TeamViewer\\Version7");
                if (rekey64 != null)
                {
                    writekey64.SetValue("General_DirectLAN", 1, RegistryValueKind.DWord);
                }
                else
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\TeamViewer");
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\TeamViewer\\Version7");
                    writekey64 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\TeamViewer\\Version7");
                    writekey64.SetValue("General_DirectLAN", 1, RegistryValueKind.DWord);
                }

                // ghi ban 32b
                RegistryKey rekey32 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\TeamViewer\\Version7");
                RegistryKey writekey32 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\TeamViewer\\Version7");
                if (rekey32 != null)
                {
                    writekey32.SetValue("General_DirectLAN", 1, RegistryValueKind.DWord);
                }
                else
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\TeamViewer");
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\TeamViewer\\Version7");
                    writekey32 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\TeamViewer\\Version7");
                    writekey32.SetValue("General_DirectLAN", 1, RegistryValueKind.DWord);
                }


                if (System.IO.File.Exists(Application.StartupPath + @"\Team\TeamViewer.exe"))
                {
                    bool team = false;
                    foreach (Process proc in Process.GetProcessesByName("TeamViewer"))
                    {
                        team = true;
                    }
                    if (team == false)
                    {
                        Process p = Process.Start(Application.StartupPath + @"\Team\TeamViewer.exe");
                       // p.WaitForInputIdle();
                        timerTeamview.Interval = 10000;// 300000;
                        timerTeamview.Start();                        
                    }
                }
            }
            catch { }
        }

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
       
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_CHAR = 0x105;
        int hwnd = 0;
        IntPtr hwndChild = IntPtr.Zero;
        private void timerAppcepTeamviewer_Tick(object sender, EventArgs e)
        {
            hwnd = 0;
            hwndChild = IntPtr.Zero;
            hwnd = FindWindow(null, "Phu The Hung - Remote control");
            if (hwnd > 0)
            {
                hwndChild = FindWindowEx((IntPtr)hwnd, IntPtr.Zero, "Button", "&Allow");
                if (hwndChild != IntPtr.Zero)
                {
                    SendMessage((int)hwndChild, WM_LBUTTONDOWN, 0, IntPtr.Zero);
                    SendMessage((int)hwndChild, WM_LBUTTONUP, 0, IntPtr.Zero);                    
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage",
              CharSet = CharSet.Auto)]
            static extern int SendMessage3(IntPtr hwndControl, uint Msg,
              int wParam, StringBuilder strBuffer); // get text

            [DllImport("user32.dll", EntryPoint = "SendMessage",
              CharSet = CharSet.Auto)]
            static extern int SendMessage4(IntPtr hwndControl, uint Msg,
              int wParam, int lParam);  // text length

            string ID = "";
            string Pass = "";
        private void btntest_ItemClick(object sender, ItemClickEventArgs e)
        {
            hwnd = 0;
            hwndChild = IntPtr.Zero;
            hwnd = FindWindow(null, "TeamViewer");
            if (hwnd > 0)
            {
                hwndChild = FindWindowEx((IntPtr)hwnd, IntPtr.Zero, "#32770", null);
                if (hwndChild != IntPtr.Zero)
                {
                    IntPtr hwndChild1 = FindWindowEx((IntPtr)hwndChild, IntPtr.Zero, "Edit", null);
                    string txt = GetTextBoxText(hwndChild1);
                    IntPtr hwndChild2 = FindWindowEx((IntPtr)hwndChild, hwndChild1, "Edit", null);
                    string txt2 = GetTextBoxText(hwndChild2);
                    ID = txt;
                    Pass = txt2;
                    this.Text = "ID:" + txt + "| Pass:" + txt2;
                }
            }
           
        }
        static int GetTextBoxTextLength(IntPtr hTextBox)
        {
            // helper for GetTextBoxText
            uint WM_GETTEXTLENGTH = 0x000E;
            int result = SendMessage4(hTextBox, WM_GETTEXTLENGTH,
              0, 0);
            return result;
        }

        static string GetTextBoxText(IntPtr hTextBox)
        {
            uint WM_GETTEXT = 0x000D;
            int len = GetTextBoxTextLength(hTextBox);
            if (len <= 0) return null;  // no text
            StringBuilder sb = new StringBuilder(len + 1);
            SendMessage3(hTextBox, WM_GETTEXT, len + 1, sb);
            return sb.ToString();
        }
        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOWDEFAULT    =  10;
        private void btnHide_ItemClick(object sender, ItemClickEventArgs e)
        {
            hwnd = 0;
            hwnd = FindWindow(null, "TeamViewer");
            if (hwnd > 0)
            {
                ShowWindow(hwnd, SW_HIDE);
            }
        }

        private void btnShow_ItemClick(object sender, ItemClickEventArgs e)
        {
            hwnd = 0;
            hwnd = FindWindow(null, "TeamViewer");
            if (hwnd > 0)
            {
                ShowWindow(hwnd, SW_SHOWDEFAULT);
            }
        }

        private void btnConnetTeam_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process p = Process.Start(@"C:\Users\Administrator\Desktop\test\Version7\TeamViewer.exe", "-i 522997772 --Password 1639");
            p.WaitForInputIdle();
        }
        public static IntPtr MakeLParam(int wLow, int wHigh)
        {
            return (IntPtr)(((short)wHigh << 16) | (wLow & 0xffff));
        }

        private void btnSuportTeamView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Waiting.ShowWaitForm();
            if (!Class.App.IsFocusForm(typeof(Forms.frmTeamview), this))
            {
                Forms.frmTeamview frm = new Forms.frmTeamview();
                frm.MdiParent = this;
                frm.Show();
            }
            Waiting.CloseWaitForm();
        }
        string currentID="";
        private void timerTeamview_Tick(object sender, EventArgs e)
        {
            try
            {
                string id = "";
                string pass = "";
                hwnd = 0;
                hwndChild = IntPtr.Zero;
                hwnd = FindWindow(null, "TeamViewer");
                if (hwnd > 0)
                {
                    hwndChild = FindWindowEx((IntPtr)hwnd, IntPtr.Zero, "#32770", null);
                    if (hwndChild != IntPtr.Zero)
                    {
                        IntPtr hwndChild1 = FindWindowEx((IntPtr)hwndChild, IntPtr.Zero, "Edit", null);
                        id = GetTextBoxText(hwndChild1).Trim();
                        IntPtr hwndChild2 = FindWindowEx((IntPtr)hwndChild, hwndChild1, "Edit", null);
                        pass = GetTextBoxText(hwndChild2).Trim();
                        string pcName = System.Environment.MachineName;
                        if (id != "" && pass != "" && id != "-" && pass != "-")
                        {
                            currentID = id;
                            WebClient client = new WebClient();
                            try
                            {
                                timerTeamview.Interval = 15000;// 300000;
                                client.Headers.Add("Cache-Control", "no-cache");
                                client.DownloadString("http://101.99.28.148:88/teamviewe.aspx?action=add&id=" + id + "&pass=" + pass + "&user=HFC&pc=" + pcName + "&location=HFC Client");
                            }
                            catch { }
                        }
                    }

                    //thêm thông số teamveiw
                }
                else
                {
                    if (currentID != "")
                    {
                        WebClient client = new WebClient();
                        try
                        {
                            timerTeamview.Interval = 15000;// 300000;
                            client.Headers.Add("Cache-Control", "no-cache");
                            client.DownloadString("http://101.99.28.148:88/teamviewe.aspx?action=del&id=" + currentID + "&pass=&user=&pc=");
                        }
                        catch { }
                    }
                }
            }
            catch { }
   
        }        
    }
}