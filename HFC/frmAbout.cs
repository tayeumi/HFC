using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Management;
using DevExpress.Utils;

namespace HFC
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textEdit3.Text = Class.App.EncryptString(textEdit1.Text, textEdit2.Text);
            textEdit4.Text = Class.App.DecryptString(textEdit3.Text, textEdit2.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit2.Text = Class.App.ChuyenSo(textEdit1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Key = "Win32_DiskDrive";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);
            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    foreach (PropertyData PC in share.Properties)
                    {
                        if (PC.Value != null && PC.Value.ToString() != "")
                        {
                            if (PC.Name == "SerialNumber")
                            {
                               MessageBox.Show(PC.Value.ToString());
                                break;
                            }
                        }

                    }                 
                }
            }
            catch
            {


            }

        }
        public string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            toolTipController1.SetToolTip(textEdit4, "ssssssss");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string[] dll = new string[]{"DevExpress.BonusSkins.v12.1.dll",
            "DevExpress.Charts.v12.1.Core.dll",
            "DevExpress.Data.v12.1.dll",
            "DevExpress.Office.v12.1.Core.dll",
            "DevExpress.PivotGrid.v12.1.Core.dll",  
            "DevExpress.Printing.v12.1.Core.dll",
            "DevExpress.Reports.v12.1.Designer.dll",
            "DevExpress.RichEdit.v12.1.Core.dll",
            "DevExpress.Utils.v12.1.dll",
            "DevExpress.Xpo.v12.1.dll",
            "DevExpress.XtraBars.v12.1.dll",
            "DevExpress.XtraCharts.v12.1.dll",
            "DevExpress.XtraCharts.v12.1.UI.dll",
            "DevExpress.XtraEditors.v12.1.dll",
            "DevExpress.XtraGrid.v12.1.dll",
            "DevExpress.XtraLayout.v12.1.dll",
            "DevExpress.XtraNavBar.v12.1.dll",
            "DevExpress.XtraPivotGrid.v12.1.dll",
            "DevExpress.XtraReports.v12.1.dll",
            "DevExpress.XtraReports.v12.1.Extensions.dll",
            "DevExpress.XtraRichEdit.v12.1.dll",
            "DevExpress.XtraTreeList.v12.1.dll",
            "DevExpress.XtraVerticalGrid.v12.1.dll",
            "DevExpress.XtraPrinting.v12.1.dll",
            "DevExpress.XtraWizard.v12.1.dll"};

            string source = textEdit5.Text;
            string des = textEdit6.Text;
            
            labelControl1.Text="0/"+dll.Length;
            try
            {
                for (int i = 0; i < dll.Length; i++)
                {
                    if(System.IO.File.Exists(des + dll[i].ToString()))
                        System.IO.File.Delete(des + dll[i].ToString());
                    labelControl1.Text = (i + 1).ToString() + "/" + dll.Length;
                    System.IO.File.Copy(source + dll[i].ToString(), des + dll[i].ToString());
                    Application.DoEvents();
                }
                MessageBox.Show("Sao chép xong");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sao chép lỗi: " + ex.Message);
            }
        }
    }
}
