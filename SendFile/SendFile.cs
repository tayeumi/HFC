using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;

namespace SendFile
{
    public partial class SendFile : Form
    {
        public SendFile()
        {
            InitializeComponent();
        }

        private void SendFile_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"Config.xml"))
            {
                string ver = version("Config.xml");
                string[] sulyver = ver.Split('.');
                int tangver = int.Parse(sulyver[1]) + 1;
                txtVer.Text = sulyver[0] +"."+tangver.ToString();
            }
        }
        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            //Create FTP request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = false;
            request.UseBinary = true;
            request.KeepAlive = false;
            request.Proxy = null;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();  
        }

        private void Send_Click(object sender, EventArgs e)
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load("Config.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
           // MessageBox.Show(node.Name);
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                //MessageBox.Show(nodechild.Name);
                if (nodechild.Name == "version")
                {
                    nodechild.InnerText = txtVer.Text;
                }

            }
            myXmlDocument.Save("Config.xml");

          uploadFile(host.Text, linkfile.Text, username.Text, password.Text);
          uploadFile(host.Text, txtUpdate.Text, username.Text, password.Text);
          uploadFile(host.Text, "Config.xml", username.Text, password.Text);
          MessageBox.Show("Gửi yêu cầu xử lý thành công.");
          XmlDocument myXmlDocument1 = new XmlDocument();
          myXmlDocument1.Load(@"E:\HFC Project\HFC\bin\Debug\Config.xml");
          XmlNode node1;
          node1 = myXmlDocument1.DocumentElement;
          // MessageBox.Show(node.Name);
          foreach (XmlNode nodechild in node1.ChildNodes)
          {
              //MessageBox.Show(nodechild.Name);
              if (nodechild.Name == "version")
              {
                  nodechild.InnerText = txtVer.Text;
              }

          }
          myXmlDocument1.Save(@"E:\HFC Project\HFC\bin\Debug\Config.xml");

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(version());
        }
        private static string version(string url)
        {
            string _config = "";
            XmlTextReader xmlReader = new XmlTextReader(url);
            while (xmlReader.Read())
            {
                if (xmlReader.Name == "version")
                {
                    _config = xmlReader.ReadElementString();
                }
            }
            xmlReader.Close();
            return _config;
        }
    }
}
