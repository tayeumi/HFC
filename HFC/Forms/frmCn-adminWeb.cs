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
    public partial class frmCn_adminWeb : DevExpress.XtraEditors.XtraForm
    {
        public frmCn_adminWeb()
        {
            InitializeComponent();
        }

        public frmCn_adminWeb(string mac)
        {
            
            InitializeComponent();
            Waiting.ShowWaitForm();
            this.Text +=" : " + mac;
            Class.CN_ADMIN cn = new Class.CN_ADMIN();
            if (!cn.isLogin())
            {
                cn.Connect(Class.CN_ADMIN.User, Class.CN_ADMIN.Passwors);
            }
            string CustomerName = "";
            string Address = "";
            string Ward = "";
            string modemID ="";
            List<string> l = new List<string>();
            if (cn.isLogin())
            {
                // thuc hien lay mac theo dinh dang                           
                mac = mac.Replace(".", "");
                mac = mac.Replace(".", "");
                // khoi thao mac theo dinh dang
                mac = mac.Insert(2, ":");
                mac = mac.Insert(5, ":");
                mac = mac.Insert(8, ":");
                mac = mac.Insert(11, ":");
                mac = mac.Insert(14, ":");

                // l = cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward);
                cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward, out modemID);

            }
            webBrowser.Navigate("http://101.99.28.133/cn-admin/lib/rrd_hf.php?modemID=" + modemID);
            Waiting.CloseWaitForm();
        }

        public frmCn_adminWeb(string IP, int KH,string mac)
        {
            InitializeComponent();
            string loai = "/RgSignal.asp";
            if (mac.Substring(0, 2) == "00")
            {
                loai = "/cmSignal.htm";
            }
            this.Text = "KH: " + IP;
            webBrowser.Navigate("http://"+IP+ loai);

        }

        public frmCn_adminWeb(string mac,string hist)
        {
            InitializeComponent();
            Waiting.ShowWaitForm();

            this.Text += " : " + mac;
            Class.CN_ADMIN cn = new Class.CN_ADMIN();
            if (!cn.isLogin())
            {
                cn.Connect(Class.CN_ADMIN.User, Class.CN_ADMIN.Passwors);
            }
            string CustomerName = "";
            string Address = "";
            string Ward = "";
            string modemID = "";
            List<string> l = new List<string>();
            if (cn.isLogin())
            {
                // thuc hien lay mac theo dinh dang                           
                mac = mac.Replace(".", "");
                mac = mac.Replace(".", "");
                // khoi thao mac theo dinh dang
                mac = mac.Insert(2, ":");
                mac = mac.Insert(5, ":");
                mac = mac.Insert(8, ":");
                mac = mac.Insert(11, ":");
                mac = mac.Insert(14, ":");

                // l = cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward);
                cn.Device_Search(mac, "2", out CustomerName, out Address, out Ward, out modemID);

            }
            webBrowser.Navigate("http://101.99.28.133/cn-admin/inc/hf/view-hf-modem-data.php?modemID=" + modemID);

            Waiting.CloseWaitForm();
        }        
           
        }
    
}