using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.Drawing;


namespace HFC
{
    public partial class frmintro : Form
    {
        public frmintro()
        {
            InitializeComponent();
        }

        private void IntroTime_Tick(object sender, EventArgs e)
        {
            IntroTime.Interval = 80;
            if (this.Opacity > 0.01)
            {
                this.Opacity = this.Opacity - 0.05;
            }
            else
            {
                IntroTime.Enabled = false;
                this.Hide();
                try
                {
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                }

            }
            lblfile.Text = "";
            lblCheck.Text = "   Load file:  Success !                     ";
        }

        private void frmintro_Load(object sender, EventArgs e)
        {
            // delete first 
            if (Application.StartupPath != "E:\\HFC Project\\HFC\\bin\\Debug") // lap trinh thi ko xoa va tai lai file nay
            {
                //if (System.IO.File.Exists("node.txt"))
                //{
                //    System.IO.File.Delete("node.txt");
                //}
                //if (System.IO.File.Exists("nodewarning.txt"))
                //{
                //    System.IO.File.Delete("nodewarning.txt");
                //}
                //if (System.IO.File.Exists("path.txt"))
                //{
                //    System.IO.File.Delete("path.txt");
                //}
            }
           Checkfile.Enabled = true;
           try
           {
               

               //if (rg.valuekey("media") == "Blue") // cai nay ko ko
               //{
               //    // Class.DataServices.media = "default_ring.wav";

               //}
               //else
               //{
               //    //  Class.DataServices.media = rg.valuekey("media");
               //}
               Class.RegistryWriter rg = new Class.RegistryWriter();
               Class.App.media = rg.valuekey("media");
               //string _user = Class.App.EncryptString("hrm", "UserID");
               //string _pass = Class.App.EncryptString("adminlbc", "PasswordID");
               //rg.WriteKey("user", _user);
               //rg.WriteKey("pass", _pass);
               if (rg.valuekey("autoupdate") == "Blue")
               {
                   rg.WriteKey("autoupdate", "1");
               }

               if (!Directory.Exists(@"Templates"))
               {
                   Directory.CreateDirectory(@"Templates");
               }

               if (!Directory.Exists(@"media"))
               {
                   Directory.CreateDirectory(@"media");
               }
               if (!Directory.Exists(@"Report"))
               {
                   Directory.CreateDirectory(@"Report");
               }
               if (!Directory.Exists(@"Team"))
               {
                   Directory.CreateDirectory(@"Team");
               }
           }
           catch { }
        }

        private void checkfileDll()
        {
            // kiem tra DLL neu khong co thuc hien down load ve:
            /*Dll:
             * Dev Data v11
             * Dev Printing v11
             * Dev XtraBars
             * Dev XtraEDit
             * Dev XtraGrid
             * Dev XtraLayout
             * Dev XtraNavBar
             */
            //string DllError="";

            string[] DllFile = new string[] {
                "Microsoft.SqlServer.SmoExtended.dll",
                "Microsoft.SqlServer.Smo.dll", 
                "Microsoft.SqlServer.Management.Sdk.Sfc.dll",
                "Microsoft.SqlServer.ConnectionInfo.dll",                
                "Update.exe",
                "DevExpress.XtraWizard.v12.2.dll",
                "DevExpress.XtraVerticalGrid.v12.2.dll",
                "DevExpress.XtraTreeList.v12.2.dll",
                "DevExpress.XtraRichEdit.v12.2.dll",
                "DevExpress.XtraReports.v12.2.Extensions.dll",
                "DevExpress.XtraReports.v12.2.dll", 
                "DevExpress.XtraPrinting.v12.2.dll",
                "DevExpress.XtraPivotGrid.v12.2.dll",
                "DevExpress.XtraNavBar.v12.2.dll",
                "DevExpress.XtraLayout.v12.2.dll",
                "DevExpress.XtraGrid.v12.2.dll",
                "DevExpress.XtraEditors.v12.2.dll",
                "DevExpress.XtraCharts.v12.2.Wizard.dll",
                "DevExpress.XtraCharts.v12.2.UI.dll",
                "DevExpress.XtraCharts.v12.2.dll",
                "DevExpress.XtraBars.v12.2.dll",
                "DevExpress.Xpo.v12.2.dll",
                "DevExpress.Utils.v12.2.UI.dll",
                "DevExpress.Utils.v12.2.dll",
                "DevExpress.RichEdit.v12.2.Core.dll",
                "DevExpress.Printing.v12.2.Core.dll",
                "DevExpress.PivotGrid.v12.2.Core.dll",
                "DevExpress.Office.v12.2.Core.dll",
                "DevExpress.Data.v12.2.dll",
                "DevExpress.Charts.v12.2.Core.dll",
                "DevExpress.BonusSkins.v12.2.dll",                 
                "Microsoft.Office.Interop.Excel.dll", 
                "DevExpress.XtraGauges.v12.2.Core.dll", 
                "DevExpress.XtraGauges.v12.2.Presets.dll", 
                "DevExpress.XtraGauges.v12.2.Win.dll", 
                "node.txt", 
                "dhcpd.conf.temp",
                "path.txt",
                "nodewarning.txt",                 
                "Config.xml",
                "SnmpSharpNet.dll" };
            lblSLFile.Visible = false;
            for (int i = 0; i < DllFile.Length; i++)            
            {
                lblSLFile.Text = (i+1).ToString()+"/" + DllFile.Length;
                if (!System.IO.File.Exists(@DllFile[i].ToString()))
                {
                    lblSLFile.Visible = true;
                    lblCheck.Text = " Loading:                                           ";
                    lblfile.Text = DllFile[i].ToString();
                    downloadData(DllFile[i].ToString());
                    saveData(DllFile[i].ToString());
                }            
            }

           // return DllError;
        }       

        private byte[] downloadedData;
        //Connects to a URL and attempts to download the file
        int bytebuffer = 1024; //set cai nay de tang toc do down.
        private void downloadData(string url)
        {
           /* string Link = "http://itpro.googlecode.com/files/"; */
            string Link = "http://101.99.28.157/tool/update/hfc/";
            url = Link + url;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            
            downloadedData = new byte[0];
            int rate = 0;
            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[bytebuffer]; // old [1024]

                //Get Total Size
                Int64 dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
              //  progressBar1.Maximum = dataLength;
                //lbProgress.Text = "0/" + dataLength.ToString();
                progressBar1.Maximum = 100;
                Int64 btyRead = 0;
                this.Text = "Downloading...";
                Application.DoEvents();               
                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    
                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        progressBar1.Value = 100;
                      //  lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();
                        progressBar1.CreateGraphics().DrawString("100" + "%",
        new Font("Arial", (float)9, FontStyle.Regular),
        Brushes.White, new PointF(progressBar1.Width / 2 - 10,
            progressBar1.Height / 2 - 7));
                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);
                      
                        //Update the progress bar
                        btyRead += bytesRead;
                        // text value                        
                        rate = Convert.ToInt32((btyRead * 100) / dataLength);
                        progressBar1.Value = rate;
                        progressBar1.Refresh();
                        if (rate < 55)
                        {
                            progressBar1.CreateGraphics().DrawString(rate.ToString() + "%",
          new Font("Arial", (float)9, FontStyle.Regular),
          Brushes.Green, new PointF(progressBar1.Width / 2 - 10,
              progressBar1.Height / 2 - 7));
                        }
                        else
                        {
                            progressBar1.CreateGraphics().DrawString(rate.ToString() + "%",
         new Font("Arial", (float)9, FontStyle.Regular),
         Brushes.White, new PointF(progressBar1.Width / 2 - 10,
             progressBar1.Height / 2 - 7));
                        }
                        //             
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                MessageBox.Show("Lỗi kết nối. không load được thư viện phần mềm");
                Application.Exit();
            }

           // txtData.Text = downloadedData.Length.ToString();
            //this.Text = "Download Data through HTTP";
        }
        // Save Data After Download
        private void saveData(string fileName)
        {
            if (downloadedData != null && downloadedData.Length != 0)
            {                
                    this.Text = "Saving Data...";
                    Application.DoEvents();

                    //Write the bytes to a file
                    FileStream newFile = new FileStream(@fileName, FileMode.Create);
                    newFile.Write(downloadedData, 0, downloadedData.Length);
                    newFile.Close();
                    this.Text = "Download Data";
                   // MessageBox.Show("Saved Successfully");                
            }
        }

        private void Checkfile_Tick(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            if (rg.valuekey("autoupdate") == "1")
            {
                Checkfile.Enabled = false;
                checkfileDll();
                kiemtraphienban();
                IntroTime.Enabled = true;
            }
            else
            {
                Checkfile.Enabled = false;
                IntroTime.Enabled = true;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int update = 0;
        private void kiemtraphienban()
        {
            
         //  if (System.IO.File.Exists("http://hfc.lbc.com.vn/tool/update/it/Config.xml"))
           // {
                string verht = version(@"Config.xml");
                string vernew = version("http://101.99.28.157/tool/update/hfc/Config.xml");
                if (vernew != "")  // bo qua nếu không tìm được phiên bản mới
                {
                    if (verht != vernew)
                    {
                        update = 1;
                        this.Close();
                    }
                }
           // }           
        }

        private static string version(string url)
        {
            string _config = "";
            string server="";
             XmlReader xmlReader;
            if (url.IndexOf("http") > 0)
            {
                xmlReader = XmlReader.Create(url);
            }
            else
            {
                 xmlReader = new XmlTextReader(url);
            }
            
          try{
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "version")
                    {
                        _config = xmlReader.ReadElementString();
                    }
                    if (xmlReader.Name == "server")
                    {
                        server = xmlReader.ReadElementString();
                    }
                }
                xmlReader.Close();
                
            }catch (Exception ex)
            {
                Class.App.Log_Write(ex.Message + " - Không kiểm tra được phiên bản phần mềm ");
            }
            //Bo phan nay thay bang phan khac
            /*
            Ping Pingsender = new Ping();
            string data = "aaaaaabbbaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 540;
            PingReply reply = Pingsender.Send(server, timeout, buffer);
            if (reply.Status == IPStatus.Success)
            {
                
            }
            else
            {
                if (server == "192.168.1.15")
                {
                    updateXml("server", "101.99.28.157");
                }
                else
                {
                    updateXml("server", "192.168.1.15");
                }
            }
              */
            // thay bang
            /*
            Cursor.Current = Cursors.WaitCursor;
            TcpClient TcpScan = new TcpClient();
            try
            {
                
                TcpScan.Connect(server, 1433);
                Application.DoEvents();
                TcpScan.Close();               
            }

            catch
            {
                if (server == "192.168.1.15")
                {
                    updateXml("server", "101.99.28.157");
                }
                else
                {
                    updateXml("server", "192.168.1.15");
                }
            }
             */ 
            Cursor.Current = Cursors.Default;
            // su dung kiem tra port
            return _config;
        }

        private static void updateXml(string key,string value)
        {
            try
            {
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load("Config.xml");
                XmlNode node;
                node = myXmlDocument.DocumentElement;
                // MessageBox.Show(node.Name);
                foreach (XmlNode nodechild in node.ChildNodes)
                {
                    //MessageBox.Show(nodechild.Name);
                    if (nodechild.Name == key)
                    {
                        nodechild.InnerText = value;
                    }

                }
                myXmlDocument.Save("Config.xml");
            }
            catch
            {
            }
        }

        private void frmintro_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (update == 1)
            { 
                update = 0;
                if (System.IO.File.Exists(@"Update.exe"))
                {                   
                       System.Diagnostics.Process.Start(@"Update.exe");
                   
                }             
            }
        }

       
        

    }
}
