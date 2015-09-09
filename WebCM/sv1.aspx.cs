using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace WebCM
{
    public partial class sv1 : System.Web.UI.Page
    {
        static TcpClient tcpClient1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["key"] != null)
            {
                txtCommand.Visible = false;
                btnSubmit.Visible = false;
                string _key = Request.Form["key"].ToString().Trim();
                lblKQ.Text = ShowCable(_key);
            }
            else
            {
                txtCommand.Visible = false;
                btnSubmit.Visible = false;
            }
        }
        public string ShowCable(string MacModem)
        {
            string result = "";
            try
            {
                if (tcpClient1 == null)
                {
                    tcpClient1 = new TcpClient("101.99.28.150", 23);
                    tcpClient1.SendTimeout = 10000;
                    tcpClient1.ReceiveTimeout = 10000;
                    Thread.Sleep(50);
                  SendCMD("telcmts");
                  Thread.Sleep(50);
                    SendCMD("login");
                    Thread.Sleep(50);
                    SendCMD("bill");
                    Thread.Sleep(50);
                    SendCMD("123");
                    Thread.Sleep(50);
                }
                if (tcpClient1.Connected)
                {
                    result = SendCMD("sh cable modem phy | include " + MacModem); //| include "+MacModem
                    //while (result.IndexOf("More") > 0)
                    //{
                    //    result += SendCMD(" ");
                    //}                          

                    while (result.Contains("More"))
                    {
                        result = result.Replace("--More--", "");
                        result += SendCMD("\r\n");
                        Thread.Sleep(50);
                    }
                    result += SendCMD("\r\n");
                    result += SendCMD("\r\n");

                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("   ", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("\b", "");
                    result = result.Replace("sh cable modem phy | include " + MacModem, "");
                    result = result.Replace("Router#", "");
                    result = result.Replace("atdma 1.1", "<br>");
                    result = result.Replace("atdma 1.0", "<br>");
                }
                else
                {
                    tcpClient1 = null;
                }
            }
            catch
            {
                return "Server not connect!";
            }
            return result;
        }
        private string GetOutput(TcpClient tcp)
        {
            string t = "";
            NetworkStream clientStream = tcpClient1.GetStream();

            byte[] message = new byte[1024];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 1024);
                    //  Application.DoEvents();
                   // Thread.Sleep(100);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                t += encoder.GetString(message, 0, bytesRead);
                if (t.IndexOf("Password") > 0)
                {
                    break;
                }
                if (t.IndexOf("Router") > 0)
                {
                    break;
                }

                if (t.IndexOf("Username") > 0)
                {
                    break;
                }
                if (t.IndexOf("More") > 0)
                {
                  //  t = t.Replace("--More--", "");
                  //  SendCMD(" ");
                  break;
                }
            }
            return t;
        }

        private string SendCMD(string strCMD)
        {
            if (tcpClient1.Connected)
            {
                string result = "";
                if (strCMD != " ")
                    strCMD = strCMD + "\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient1.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
                result = GetOutput(tcpClient1);
                return result;
            }
            return "Server Not Connect !";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblKQ.Text = ShowCable(txtCommand.Text);
        }
    }
}