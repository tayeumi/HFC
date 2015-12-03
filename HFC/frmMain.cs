using System;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraBars.Helpers;
using System.Xml;

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

                
    }
}