using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using IWshRuntimeLibrary;

namespace Update
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void checkfileDll()
        {           
            string[] DllFile = new string[] { "DevExpress.OfficeSkins.v12.2.dll", "DevExpress.XtraRichEdit.v12.2.dll", "DevExpress.XtraReports.v12.2.dll", "DevExpress.BonusSkins.v12.2.dll", "DevExpress.Xpo.v12.2.dll", "DevExpress.XtraTreeList.v12.2.dll", "DevExpress.Data.v12.2.dll", "DevExpress.Printing.v12.2.Core.dll", "DevExpress.Utils.v12.2.dll", "DevExpress.XtraBars.v12.2.dll", "DevExpress.XtraEditors.v12.2.dll", "DevExpress.XtraGrid.v12.2.dll", "DevExpress.XtraLayout.v12.2.dll", "DevExpress.XtraNavBar.v12.2.dll", "Microsoft.Office.Interop.Excel.dll"};
            for (int i = 0; i < DllFile.Length; i++)
            {
                if (!System.IO.File.Exists(@DllFile[i].ToString()))
                {
                    this.Text = " Loading:  " + DllFile[i].ToString();                    
                    downloadData(DllFile[i].ToString());
                    saveData(DllFile[i].ToString(),0);
                }
            }

            update = 1;
            Application.Exit();
        }  

        private void Update_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           // timer1.Enabled = true;
        }

        private byte[] downloadedData;
        //Connects to a URL and attempts to download the file
        int bytebuffer = 1024; //set cai nay de tang toc do down.
        private void downloadData(string url)
        {           
            string Link = "http://101.99.28.157/tool/update/hfc/";
            url = Link + url;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            downloadedData = new byte[0];
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
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                progressBar1.Maximum = dataLength;
                lbProgress.Text = "0/" + dataLength.ToString();

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
                        progressBar1.Value = progressBar1.Maximum;
                        lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
                        {
                            progressBar1.Value += bytesRead;
                            lbProgress.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();

                            progressBar1.Refresh();
                            Application.DoEvents();
                        }
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
        int update = 0;
        private void saveData(string fileName,int exit)
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
                if (exit == 1)
                {
                    update = 1;
                    this.Close();
                }
            }
        }

        private void Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.IO.File.Exists(@"HFC.exe"))
            {
                if (update == 1)
                {
                   System.Diagnostics.Process.Start("HFC.exe");
                   if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Quản lý nhân sự LBC.lnk"))
                   {
                       CreateShortcut();
                   }
                }
            }
        }



        public void CloseAllProgame()
        {
           
                foreach (Process proc in Process.GetProcessesByName("HFC"))
                {
                    proc.Kill();
                }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // checkfileDll();
            timer1.Enabled = false;
            btnStart_Click(null, null);
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CloseAllProgame();

            Thread.Sleep(200);

            if (System.IO.File.Exists(@"HFC.exe"))
            {
                System.IO.File.Delete(@"HFC.exe");
            }
            if (System.IO.File.Exists(@"Config.xml"))
            {
                System.IO.File.Delete(@"Config.xml");
            }


            if (!System.IO.File.Exists(@"DevExpress.Utils.v12.2.dll"))
            {
                downloadData("DevExpress.Utils.v12.2.dll");
                saveData("DevExpress.Utils.v12.2.dll", 0);
            }
            if (!System.IO.File.Exists(@"DevExpress.Data.v12.2.dll"))
            {
                downloadData("DevExpress.Data.v12.2.dll");
                saveData("DevExpress.Data.v12.2.dll", 0);
            }

            if (!System.IO.File.Exists(@"DevExpress.XtraEditors.v12.2.dll"))
            {
                downloadData("DevExpress.XtraEditors.v12.2.dll");
                saveData("DevExpress.XtraEditors.v12.2.dll", 0);
            }

            if (!System.IO.File.Exists(@"DevExpress.XtraWizard.v12.2.dll"))
            {
                downloadData("DevExpress.XtraWizard.v12.2.dll");
                saveData("DevExpress.XtraWizard.v12.2.dll", 0);
            }

            if (!System.IO.File.Exists(@"DevExpress.BonusSkins.v12.2.dll"))
            {
                downloadData("DevExpress.BonusSkins.v12.2.dll");
                saveData("DevExpress.BonusSkins.v12.2.dll", 0);
            }
            if (!System.IO.File.Exists(@"DevExpress.Office.v12.2.Core.dll"))
            {
                downloadData("DevExpress.Office.v12.2.Core.dll");
                saveData("DevExpress.Office.v12.2.Core.dll", 0);
            }




            if (!System.IO.File.Exists(@"Interop.IWshRuntimeLibrary.dll"))
            {
                downloadData("Interop.IWshRuntimeLibrary.dll");
                saveData("Interop.IWshRuntimeLibrary.dll", 0);
            }


            if (!Directory.Exists(@"media"))
            {
                Directory.CreateDirectory(@"media");
            }

            if (!Directory.Exists(@"Templates"))
            {
                Directory.CreateDirectory(@"Templates");
            }

            if (!Directory.Exists(@"images"))
            {
                Directory.CreateDirectory(@"images");
            }
            if (!Directory.Exists(@"ImportFile"))
            {
                Directory.CreateDirectory(@"ImportFile");
            }
            if (!Directory.Exists(@"Team"))
            {
                Directory.CreateDirectory(@"Team");
            }

            /*
            if (!System.IO.File.Exists(@"images/bgtb.png"))
            {
                downloadData("images/bgtb.png");
                saveData("images/bgtb.png", 0);
            }

            if (!System.IO.File.Exists(@"images/LBC-logo.png"))
            {
                downloadData("images/LBC-logo.png");
                saveData("images/LBC-logo.png", 0);
            }
            */
            if (!System.IO.File.Exists(@"media/default_ring.wav"))
            {
                downloadData("media/default_ring.wav");
                saveData("media/default_ring.wav", 0);
            }           

            if (!System.IO.File.Exists(@"media/buzz.wav"))
            {
                downloadData("media/buzz.wav");
                saveData("media/buzz.wav", 0);
            }
            if (!System.IO.File.Exists(@"media/Yahoo_ring_03.wav"))
            {
                downloadData("media/Yahoo_ring_03.wav");
                saveData("media/Yahoo_ring_03.wav", 0);
            }
            if (!System.IO.File.Exists(@"media/yodel.wav"))
            {
                downloadData("media/yodel.wav");
                saveData("media/yodel.wav", 0);
            }

            if (!System.IO.File.Exists(@"Config.xml"))
            {
                downloadData("Config.xml");
                saveData("Config.xml", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer.exe"))
            {
                downloadData("Team/TeamViewer.exe");
                saveData("Team/TeamViewer.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer_.exe"))
            {
                downloadData("Team/TeamViewer_.exe");
                saveData("Team/TeamViewer_.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer_Desktop.exe"))
            {
                downloadData("Team/TeamViewer_Desktop.exe");
                saveData("Team/TeamViewer_Desktop.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer_Resource_en.dll"))
            {
                downloadData("Team/TeamViewer_Resource_en.dll");
                saveData("Team/TeamViewer_Resource_en.dll", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer_Service.exe"))
            {
                downloadData("Team/TeamViewer_Service.exe");
                saveData("Team/TeamViewer_Service.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/TeamViewer_StaticRes.dll"))
            {
                downloadData("Team/TeamViewer_StaticRes.dll");
                saveData("Team/TeamViewer_StaticRes.dll", 0);
            }
            if (!System.IO.File.Exists(@"Team/tv_w32.dll"))
            {
                downloadData("Team/tv_w32.dll");
                saveData("Team/tv_w32.dll", 0);
            }
            if (!System.IO.File.Exists(@"Team/tv_x64.dll"))
            {
                downloadData("Team/tv_x64.dll");
                saveData("Team/tv_x64.dll", 0);
            }
            if (!System.IO.File.Exists(@"Team/tv_w32.exe"))
            {
                downloadData("Team/tv_w32.exe");
                saveData("Team/tv_w32.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/tv_x64.exe"))
            {
                downloadData("Team/tv_x64.exe");
                saveData("Team/tv_w32.exe", 0);
            }
            if (!System.IO.File.Exists(@"Team/tvinfo.ini"))
            {
                downloadData("Team/tvinfo.ini");
                saveData("Team/tvinfo.ini", 0);
            }

            if (!System.IO.File.Exists(@"HFC.exe"))
            {
                downloadData("HFC.exe");
                saveData("HFC.exe", 1);
            }
             
        }

        private void CreateShortcut()
        {
            try
            {
                if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\PTH Network Management.lnk"))
                {

                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                //  string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + "\\IT.lnk";
                string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\IT.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "PTH Network Management";
                shortcut.Hotkey = "Ctrl+Shift+N";
            
                shortcut.TargetPath = System.Environment.CurrentDirectory + @"\HFC.exe";
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
                shortcut.Save();
              
                    if (System.IO.File.Exists(shortcutAddress))
                    {
                        System.IO.File.Move(shortcutAddress, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\PTH Network Management.lnk");
                    }
                }
            }
            catch { }
        }
    }
}
