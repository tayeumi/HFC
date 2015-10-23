using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HFC.Class;
using System.Threading;

namespace HFC.Forms
{
    public partial class frmMaps : DevExpress.XtraEditors.XtraForm
    {
        public frmMaps()
        {
            InitializeComponent();
            LoadSV();
        }
        private Thread serverThread;
        MyWebServer mWebserver = new MyWebServer();
       

        private void frmMaps_FormClosing(object sender, FormClosingEventArgs e)
        {
           // serverThread = null;
            mWebserver.Stop();
        }

        void LoadSV()
        {
            serverThread = new Thread(new ThreadStart(mWebserver.Start));
            serverThread.IsBackground = true;
            serverThread.Start();
           // this.Text = "Listening...";
        }

        private void frmMaps_Load(object sender, EventArgs e)
        {
            //webControl.Navigate("http://127.0.0.1:100/");
            checknodeDown();            
        }

        void Nodefail()
        {
            MyWebServer.detail = "<span style=color:red><b>CẢNH BÁO MẤT TÍN HIỆU:</b></span> <br>NODE: ABCXYZ";
            MyWebServer.lat = "10.8133611";
            MyWebServer.lng = "106.6974304";
            webControl.Navigate("http://127.0.0.1:100/nodewarning.html");
            while (webControl.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }
            webControl.Refresh();

        }
        void checknodeDown()
        {
            Class.NW_Device clsnode = new Class.NW_Device();
            DataTable dt = clsnode.NW_Device_GetStatic();
            int checkloi=0;
            for( int i=0;i<dt.Rows.Count;i++)
            {
                if (dt.Rows[i]["Description"].ToString().Length > 3)
                {
                    if (dt.Rows[i]["Description"].ToString().IndexOf(',') > 0)
                    {
                        if (dt.Rows[i]["Value1"].ToString() == "0")
                        {                            
                            checkloi = 1;
                        }  
                    }
                }               
            }

            if (checkloi == 0)
            {
                NodeToMaps();
            }
            else
            {
                webControl.Navigate("http://127.0.0.1:100/nodewarning.html?"+DateTime.Now.Millisecond);
                while (webControl.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(50);
                }
                webControl.Refresh();
            }

        }
        void NodeToMaps()
        {
            webControl.Navigate("http://127.0.0.1:100/node.html?" + DateTime.Now.Millisecond);            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                checknodeDown();
            }
            catch { }
        }

        private void frmMaps_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}