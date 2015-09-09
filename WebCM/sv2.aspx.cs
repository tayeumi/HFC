using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using SnmpSharpNet;
using System.Net;

namespace WebCM
{
    public partial class sv21 : System.Web.UI.Page
    {
       
            protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Request.Form["key"] != null)
                {
                    txtCommand.Visible = false;
                    btnSubmit.Visible = false;
                    string _key = Request.Form["key"].ToString().Trim();
                    if (_key.IndexOf("168.") > 0)
                    {

                        // kiem tra neu key la IP thi log thang vao modem

                        _key = _key.Trim();
                        try
                        {
                            string IP = _key;
                            if (IP.Trim() != "")
                            {
                                if (IP.Trim() != "0.0.0.0")
                                {
                                    // SNMP community name
                                    OctetString community = new OctetString("LBC");

                                    // Define agent parameters class
                                    AgentParameters param = new AgentParameters(community);
                                    // Set SNMP version to 1 (or 2)
                                    param.Version = SnmpVersion.Ver1;

                                    IpAddress agent = new IpAddress(IP);

                                    // Construct target
                                    UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

                                    // Pdu class used for all requests
                                    Pdu pdu = new Pdu(PduType.Get);
                                    pdu.VbList.Add("1.3.6.1.2.1.10.127.1.1.4.1.5.3"); //Noise  -- value1   
                                    pdu.VbList.Add("1.3.6.1.2.1.10.127.1.2.2.1.3.2"); //US Power Level --- value2
                                    pdu.VbList.Add("1.3.6.1.2.1.10.127.1.1.1.1.6.3"); //DS Power level     -- value3    


                                    // Make SNMP request
                                    SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

                                    // If result is null then agent didn't reply or we couldn't parse the reply.
                                    if (result != null)
                                    {
                                        // ErrorStatus other then 0 is an error returned by 
                                        // the Agent - see SnmpConstants for error definitions
                                        if (result.Pdu.ErrorStatus != 0)
                                        {
                                            // agent reported an error with the request
                                            Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                                                result.Pdu.ErrorStatus,
                                                result.Pdu.ErrorIndex);
                                            lblKQ.Text = "Device Offline";
                                        }
                                        else
                                        {
                                            // Reply variables are returned in the same order as they were added
                                            //  to the VbList                   
                                            lblKQ.Text += "DS SNR: " + (float.Parse(result.Pdu.VbList[0].Value.ToString()) / 10).ToString() + "   \r\n";
                                            lblKQ.Text += "US Tx: " + (float.Parse(result.Pdu.VbList[1].Value.ToString()) / 10).ToString() + "   \r\n";
                                            lblKQ.Text += "DS Rx: " + (float.Parse(result.Pdu.VbList[2].Value.ToString()) / 10).ToString() + "   \n\r";
                                            // gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue1, (float.Parse(result.Pdu.VbList[0].Value.ToString()) / 10).ToString());
                                            //  gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue2, (float.Parse(result.Pdu.VbList[1].Value.ToString()) / 10).ToString());
                                            // gridItemDetail.SetRowCellValue(gridItemDetail.FocusedRowHandle, colValue3, (float.Parse(result.Pdu.VbList[2].Value.ToString()) / 10).ToString());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No response received from SNMP agent.");
                                        lblKQ.Text = "Device Offline";
                                    }
                                    target.Close();

                                }
                            }

                        }
                        catch { lblKQ.Text = "Device Offline"; }



                        // lblKQ.Text = _key;
                    }
                    else
                    {
                        if (Request.Form["mode"] != null)
                        {
                            if (Request.Form["mode"].ToString().Trim() == "phy")
                            {
                                string result = ShowCable(_key, "phy");
                                string[] sp = result.Split('|');
                                result = "";
                                for (int i = 0; i < sp.Length; i++)
                                {
                                    string _mac = "";
                                    if (sp[i].Length > 13)
                                    {
                                        string txt = sp[i].Trim();
                                        _mac = txt.Substring(0, 14);
                                        _mac = _mac.Trim();
                                    }
                                    if (_mac != "")
                                    {
                                        if (!_mac.Contains("Server"))
                                        {
                                            _mac = "<a href=http://101.99.28.156:88/sv2.aspx?macip=" + _mac + ">" + _mac + "</a>" + sp[i].Trim().Substring(14) + "<br>";
                                            result += _mac.Trim();
                                        }
                                        else
                                        {
                                            _mac = _mac + sp[i].Trim().Substring(14) + "<br>";
                                            result += _mac.Trim();
                                        }
                                    }
                                }
                                lblKQ.Text = result.Trim();
                            }
                            else
                            {
                                lblKQ.Text = ShowCable(_key, "remote");
                            }
                        }
                        else
                        {
                            string result = ShowCable(_key, "phy");
                            string[] sp = result.Split('|');
                            result = "";
                            for (int i = 0; i < sp.Length; i++)
                            {
                                string _mac = "";
                                if (sp[i].Length > 13)
                                {
                                    string txt = sp[i].Trim();
                                    _mac = txt.Substring(0, 14);
                                    _mac = _mac.Trim();
                                }
                                if (_mac != "")
                                {
                                    if (!_mac.Contains("Server"))
                                    {
                                        _mac = "<a href=http://101.99.28.156:88/sv2.aspx?macip=" + _mac + ">" + _mac + "</a>" + sp[i].Trim().Substring(14) + "<br>";
                                        result += _mac.Trim();
                                    }
                                    else
                                    {
                                        _mac = _mac + sp[i].Trim().Substring(14) + "<br>";
                                        result += _mac.Trim();
                                    }
                                }
                            }
                            lblKQ.Text = result.Trim();
                            // lblKQ.Text = ShowCable(_key, "phy");
                        }
                        DateTime datetime = DateTime.Now;
                        // giai phong telnet
                        if (datetime.Minute.ToString() == "5" || datetime.Minute.ToString() == "10" || datetime.Minute.ToString() == "15" || datetime.Minute.ToString() == "20" || datetime.Minute.ToString() == "25" || datetime.Minute.ToString() == "30" || datetime.Minute.ToString() == "35" || datetime.Minute.ToString() == "40" || datetime.Minute.ToString() == "45" || datetime.Minute.ToString() == "50" || datetime.Minute.ToString() == "55")
                        {
                            SendCMD("exit");
                            tcpClient = null;
                        }
                        
                    }
                }       // het key
                else
                {
                    if (Request.QueryString["macip"] != null)
                    {
                        string _mac = Request.QueryString["macip"].ToString().Trim();
                        try
                        {
                            string result = SendCMD("sh host authorization | include " + _mac);
                            result = result.Replace("sh host authorization | include " + _mac, "");
                            result = result.Replace("Host", "<br>Host");
                            result = result.Replace("Modem", "<br>Modem");
                            result = result.Replace("MOT:7A#", "");
                            lblKQ.Text = result.Trim();
                           
                        }
                        catch (Exception ex)
                        {
                            lblKQ.Text = ex.Message;
                        }
                    }

                    txtCommand.Visible = false;
                    btnSubmit.Visible = false;                   
                }
            
        }

        static TcpClient tcpClient;       
        public string ShowCable(string MacModem,string mode)
        {
            string result = "";
            try
            {
                if (tcpClient == null)
                {
                    tcpClient = new TcpClient("101.99.28.129", 23);
                    tcpClient.SendTimeout =10000;
                    tcpClient.ReceiveTimeout = 10000;
                    //tcpClient.SendBufferSize = 1024;
                    //tcpClient.ReceiveBufferSize = 1024;

                    Thread.Sleep(50);
                    SendCMD("telcmlbc");
                    Thread.Sleep(50);
                    SendCMD("login technical");
                    Thread.Sleep(50);
                    SendCMD("teclbclbc");
                    Thread.Sleep(50);
                }
                if (tcpClient.Connected)
                {
                    if (mode == "phy")
                    {
                        result = SendCMD(" sh cable modem phy | include " + MacModem); //| include "+MacModem
                    }
                    else
                    {
                        result = SendCMD(" sh cable modem remote | include " + MacModem); //| include "+MacModem
                    }

                    while (result.Contains("More"))
                    {
                        result = result.Replace("--More--", "");
                        result += SendCMD("\r\n");
                        Thread.Sleep(50);
                    }
                    result += SendCMD("\r\n");
                    result += SendCMD("\r\n");

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

                   // result = result.Replace("    ", "");
                    //result = result.Replace("    ", "");
                    //result = result.Replace("    ", "");
                          
                                     
                    result = result.Replace("sh cable modem phy | include " + MacModem, "");
                    result = result.Replace("sh cable modem remote | include " + MacModem, "");
                    result = result.Replace("NEW_MOT:7A#", "");
                    result = result.Replace("MOT:7A#", "");
                    result = result.Replace("online", "on<br>");
                    result = result.Replace("offline", "off<br>");
                    result = result.Replace("[K", "");
                    result = result.Replace("TDMA", "|");
                    result = result.Replace("--More--", "");
                    result = result.Trim();
                    
                }
                else
                {
                    tcpClient = null;
                }
            }
            catch
            {
               
            }
            return result;
        }
        private string GetOutput(TcpClient tcp)
        {
            string t = "";
            NetworkStream clientStream = tcpClient.GetStream();

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
                if (t.IndexOf("MOT") > 0)
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
            if (tcpClient.Connected)
            {
                string result = "";
                if (strCMD != " ")
                    strCMD = strCMD + "\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
                result = GetOutput(tcpClient);                                
               // buffer = encoder.GetBytes("exit \r\n");
              //  clientStream.Write(buffer, 0, buffer.Length);
              //  Thread.Sleep(100);
              //  tcpClient = null;
                return result;
               
            }
            return "Server Not Connect !";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = ShowCable(txtCommand.Text, "phy");
            string[] sp = result.Split('!');
            result = "";
            for (int i = 0; i < sp.Length; i++)
            {
                string _mac = "";
                if (sp[i].Length > 13)
                {
                    string txt = sp[i].Trim();
                    _mac = txt.Substring(0, 14);
                    _mac = _mac.Trim();
                }
                if (_mac != "")
                {
                    _mac = "<a href=http://101.99.28.156:88/sv2.aspx?macip=" + _mac + ">" + _mac + "</a>" + sp[i].Trim().Substring(14) + "<br>";
                    result += _mac;
                }
            }
            lblKQ.Text = result;

            /*

             */
        }
        
    }
}