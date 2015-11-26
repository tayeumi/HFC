using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace HFC.Class
{
  public class CMTS
    {
        public static TcpClient tcpClient{get;set;}
        public static string CMTS_Host = get_config("CMTS");//".";;
        public static string CMTS_Pass=Class.App.DecryptString(get_config("CMTS_TEL"), "PasswordID");
        public static string CMTS_Login = Class.App.DecryptString(get_config("CMTS_user"),"UserID");//".";;;
        public static string CMTS_PassLogin=Class.App.DecryptString(get_config("CMTS_pass"), "PasswordID");
             
        public static int _Theard=20;

        public static string get_config(string _id)
        {
            RegistryWriter rg = new RegistryWriter();
            return rg.valuekey(_id);
        }

        public void Connect(string host)
        {
            if (tcpClient == null)
            {
                tcpClient = new TcpClient(host, 23);
                tcpClient.SendTimeout = 10000;
                tcpClient.ReceiveTimeout = 50000;                
                Thread.Sleep(100);
                SendCMD(CMTS_Pass);
                Thread.Sleep(100);
                SendCMD("login");
                Thread.Sleep(100);
                SendCMD(CMTS_Login);
                Thread.Sleep(100);
                SendCMD(CMTS_PassLogin);
                Thread.Sleep(100);
            }
        }
        static public void Disconnect()
        {
            if (tcpClient.Connected)
            {                
                    string strCMD = "exit \r\n";
                    string t = "";
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    byte[] buffer = encoder.GetBytes(strCMD);
                    NetworkStream clientStream = tcpClient.GetStream();
                    clientStream.Write(buffer, 0, buffer.Length);
                    Thread.Sleep(100);
                   
                    byte[] message = new byte[8192 * 30];
                   
                    if (clientStream.CanRead && clientStream.DataAvailable)
                    {
                        
                        try
                        {                            
                            int bytesRead;
                            string result = "";
                            while (true)
                            {
                                try
                                {
                                    bytesRead = 0;                                    
                                    bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                    if (bytesRead == 0)
                                    {
                                        break;
                                    }
                                    t = encoder.GetString(message, 0, bytesRead);
                                    t = t.Trim();
                                    result += t;
                                    if (t.EndsWith("--More--"))
                                    {
                                        buffer = encoder.GetBytes(" ");
                                        clientStream.Write(buffer, 0, buffer.Length);
                                        Thread.Sleep(10);
                                        // Application.DoEvents();
                                    }
                                    if (t.EndsWith("MOT:7A#"))
                                    {
                                        break;
                                    }
                                    //                          
                                   
                                }
                                catch
                                {
                                    break;
                                }
                            }                          

                        }
                        catch { }
                    }                
                tcpClient.Close();
                tcpClient = null;
            }            
        }
        private void SendCMD(string strCMD)
        {
            if (tcpClient.Connected)
            {               
                if (strCMD != " ")
                    strCMD = strCMD + "\r\n";
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);                            
            }           
        }

        private string SendCMD_Output(string strCMD)
        {
            if (tcpClient.Connected)
            {
                if (strCMD != " ")
                    strCMD = strCMD + "\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
                return GetOutput();
            }
            return "Error";
        }

        private string GetOutput()
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

        public void Remote(string MacAddress, out string IpPrivate, out string value1, out string value2, out string value3, out string result, out string status, out string location,out string mac)
        {
            value1 = "";
            value2 = "";
            value3 = "";
            result = "";
            IpPrivate = "";
            status = "";
            mac = "";
            location = "";
            string t;
            string result2 = "";
            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem remote | include " + MacAddress + "\r\n ";                   

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(2000);
                //Application.DoEvents();
                byte[] message = new byte[8192 * 10];
                
                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

               

                if (clientStream.CanRead && clientStream.DataAvailable)                
                {                     
                    try
                    {
                        int bytesRead;                       
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                bytesRead = clientStream.Read(message, 0, 8192 * 10);
                                Thread.Sleep(10);
                               // Application.DoEvents();
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                result2 += t;
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }                      

                    }
                    catch { }
                    result2 = result2.Replace("line", "line \n"); 
                   // t = encoder.GetString(message);
                   // t = t.Trim();
                    result2 = result2.Substring(result2.IndexOf("cable"));

                    if (result2.IndexOf("online") > 0)
                        status="online";
                       else
                         status="offline";

                    Regex r2 = new Regex(@"(\d+)/(\d+)/(\w+) ");
                    Match m2 = r2.Match(result2);
                    if (m2.Success)
                    {
                        location = m2.Value.Trim();
                    }


                    // loc thong so
                   Regex r = new Regex(@" (\d+).(\d+).(\d+).(\d+)(.*)(\d+){2} ");
                   Match m = r.Match(result2);
                   if (m.Success)
                    {                      
                        string kq = m.Value;
                        kq = kq.Trim();
                        kq = kq.Replace("  ", " ");
                        kq = kq.Replace("  ", " ");
                        kq = kq.Replace("  ", " ");
                        
                        string[] cat = kq.Split(' ');
                       if(cat.Length>=1)
                        IpPrivate = cat[0];
                       if (cat.Length >= 2)
                        mac = cat[1];
                       if (cat.Length >= 3)
                        value1 = cat[2];
                       if (cat.Length >= 4)
                        value2 = cat[3];
                       if (cat.Length >= 5)
                        value3 = cat[4];                      
                    }       

                    result = "Ok";   
                }
                //else
                //{
                //    result = "Error";   
                //}

            }
                    
        }
        public void Phy(string MacAddress,out string value4)
        {
            value4 = "";           
            string t;           
            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem phy | include " + MacAddress + "\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(50);
                //Application.DoEvents();
                byte[] message = new byte[8192 * 10];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);                

                if (clientStream.CanRead && clientStream.DataAvailable)               
                {
                    try
                    {
                        int bytesRead;
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                bytesRead = clientStream.Read(message, 0, 8192 * 10);
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }

                    }
                    catch { }
                    t = encoder.GetString(message);                    
                   
                    t = t.Trim();
                    // loc thong so
                    Regex r = new Regex(@" (\d+){3} ");
                    Match m = r.Match(t);
                    if (m.Success)
                    {
                        string kq = m.Value;
                        value4 = kq;                       
                    }                   
                }               
            }
        }

        public void Stast(string MacAddress, out string Ipadd,out string Stast)
        {
            Ipadd =Stast= "";
            string t;
            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem | include " + MacAddress + "\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(50);
                //Application.DoEvents();
                byte[] message = new byte[8192 * 10];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    try
                    {
                        int bytesRead;
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                bytesRead = clientStream.Read(message, 0, 8192 * 10);
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }

                    }
                    catch { }
                    t = encoder.GetString(message);

                    t = t.Trim();
                    // loc thong so
                    Regex r = new Regex(@" (\d+).(\d+).(\d+).(\d+) ");
                    Match m = r.Match(t);
                    if (m.Success)
                    {
                        string kq = m.Value;
                        Ipadd = kq;
                    }

                    if (t.IndexOf("dhcp(d)") > 0)
                    {
                        Stast="dhcp(d)";
                    }
                }
            }
        }

        public void Stast_Card(string Card, out string[] List)
        {
            List = null;
            string t = "";

            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem | include \"" + Card + "\"\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
                byte[] message = new byte[8192 * 40];

                do
                {
                    Thread.Sleep(50);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    //blocks until a client sends a message  
                    try
                    {
                        int bytesRead;
                        string result = "";
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                bytesRead = clientStream.Read(message, 0, 8192 * 40);

                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                result += t+ " \n ";
                                if (t.EndsWith("--More--"))
                                {
                                    buffer = encoder.GetBytes(" ");
                                    clientStream.Write(buffer, 0, buffer.Length);
                                    Thread.Sleep(50);
                                    Application.DoEvents();
                                }
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }

                        List = result.Split('\n');
                        for (int i = 0; i < List.Length; i++)
                        {
                            List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                             List[i] = List[i].ToString().Replace("NEW_MOT:7A#", "");
                            List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");                            
                            List[i] = List[i].ToString().Replace("\r", "");
                            
                        }

                    }
                    catch { }

                }
            }
        }
        public void Remote_Card(string Card,out string[] List)
        {           
           List = null;
           string t="";
           

            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem remote | include \"" + Card + "\"\r\n";   
           
                  ASCIIEncoding encoder = new ASCIIEncoding();
                   byte[] buffer = encoder.GetBytes(strCMD);
                   NetworkStream clientStream = tcpClient.GetStream();
                   clientStream.Write(buffer, 0, buffer.Length);
                   Thread.Sleep(100);                  
                   byte[] message = new byte[8192 * 30];

                    do
                    {
                        Thread.Sleep(20);
                    } while (!clientStream.DataAvailable);

                    if (clientStream.CanRead && clientStream.DataAvailable)
                    {
                        //blocks until a client sends a message  
                        try
                        {                          
                            int bytesRead;
                            string result = "";
                            while (true)
                            {
                                try
                                {
                                    bytesRead = 0;      
                                    bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                   
                                    if (bytesRead == 0)
                                    {
                                        break;
                                    }
                                    t = encoder.GetString(message, 0, bytesRead);
                                    t = t.Trim();
                                    result += t;
                                    if (t.EndsWith("--More--"))
                                    {
                                        buffer = encoder.GetBytes(" ");
                                        clientStream.Write(buffer, 0, buffer.Length);
                                        Thread.Sleep(50);
                                        Application.DoEvents();
                                    }
                                    if (t.EndsWith("MOT:7A#"))
                                    {
                                        break;
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }
                            result = result.Replace("line", "line \n");
                            List = result.Split('\n');
                            for (int i = 0; i < List.Length; i++)
                            {
                                List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                                List[i] = List[i].ToString().Replace("\r", "");
                            }

                        }
                        catch { }

                    }                                             

            }

        }

        public void PHY_Card(string Card, out string[] List, out List<string> list1)
        {
            List = null;
            string t = "";
            list1 = null;

            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem phy | include \"" + Card + "\"\r\n";
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
               
                byte[] message = new byte[8192 * 30];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    //blocks until a client sends a message  
                    try
                    {
                       // clientStream.Read(message, 0, (int)8192 * 30);
                      //  Thread.Sleep(_Theard);
                       
                      //  t = encoder.GetString(message);
                        int bytesRead;
                        string result = "";
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;                                
                                bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                result += t;
                                if (t.EndsWith("--More--"))
                                {
                                    buffer = encoder.GetBytes(" ");
                                    clientStream.Write(buffer, 0, buffer.Length);
                                    Thread.Sleep(100);                                    
                                }
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                        result = result.Replace("TDMA", "TDMA \n");
                        List = result.Split('\n');
                        list1 = new List<string>();
                        for (int i = 0; i < List.Length; i++)
                        {
                            List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                            List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");

                            List[i] = List[i].ToString().Replace("\r", "");
                            


                            if (List[i].ToString().Trim().EndsWith("TDMA"))
                            {
                                if (List[i].ToString().Trim().Length > 100)
                                {
                                    string txt = List[i];
                                    txt = txt.Substring(txt.IndexOf("TDMA") + 4);
                                    list1.Add(txt);
                                }
                            }
                        }

                    }
                    catch { }

                }              

            }

        }

        public void Remote_Card_all(out string[] List, DevExpress.XtraSplashScreen.SplashScreenManager Wait)
        {

            List = null;

            string t = "";          

            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem remote\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
               // Application.DoEvents();
                byte[] message = new byte[8192 * 30];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    //blocks until a client sends a message  
                    try
                    {
                       // clientStream.Read(message, 0, (int)8192 * 30);
                       // Thread.Sleep(_Theard);
                      //  t = encoder.GetString(message);
                        int bytesRead;
                        string result = "";
                            while (true)
                            {
                                try
                                {
                                    bytesRead = 0;
                                    //buffer = encoder.GetBytes(" ");
                                    //clientStream.Write(buffer, 0, buffer.Length);
                                    //Thread.Sleep(20);
                                    bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                    if (bytesRead == 0)
                                    {
                                        break;
                                    }
                                    t = encoder.GetString(message, 0, bytesRead);
                                    t=t.Trim();
                                    result += t;
                                    if (t.EndsWith("--More--"))
                                    {
                                        buffer = encoder.GetBytes(" ");
                                        clientStream.Write(buffer, 0, buffer.Length);
                                        Thread.Sleep(10);
                                       // Application.DoEvents();
                                    }
                                    if(t.EndsWith("MOT:7A#"))
                                    {
                                        break;
                                    }
                                    //                          
                                    if (Wait != null)
                                    {
                                        if (Wait.IsSplashFormVisible)
                                        {
                                            Regex r2 = new Regex(@"(\d+)/(.*)L0 ");
                                            Match m2 = r2.Match(t);
                                            string location="";
                                            if (m2.Success)
                                            {
                                               location = m2.Value.Trim();
                                            }
                                            Wait.SetWaitFormDescription("Đang tải Remote ( " + location+" )");
                                        }
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        result = result.Replace("line", "line \n");
                        List = result.Split('\n');
                        for (int i = 0; i < List.Length; i++)
                        {
                            List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                            List[i] = List[i].ToString().Replace("\r", "");
                        }

                    }
                    catch { }

                }

            }

        }

        public void PHY_Card_all(out string[] List, DevExpress.XtraSplashScreen.SplashScreenManager Wait,out List<string> list1)
        {           
            List = null;
            list1 = null;
            string t = "";

            if (tcpClient.Connected)
            {
                string strCMD = "sh cable modem phy\r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(100);
                //Application.DoEvents();
                byte[] message = new byte[8192 * 30];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    //blocks until a client sends a message  
                    try
                    {
                        //clientStream.Read(message, 0, (int)8192 * 30);
                       // Thread.Sleep(_Theard);
                        //t = encoder.GetString(message);
                        int bytesRead;
                        string result = "";
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                //buffer = encoder.GetBytes(" ");
                                //clientStream.Write(buffer, 0, buffer.Length);
                                //Thread.Sleep(20);
                                bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                result += t;
                                if (t.EndsWith("--More--"))
                                {
                                    buffer = encoder.GetBytes(" ");
                                    clientStream.Write(buffer, 0, buffer.Length);
                                    Thread.Sleep(50);
                                   // Application.DoEvents();
                                    Class.App.Wait++;
                                }
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                                if (Wait != null)
                                {
                                    if (Wait.IsSplashFormVisible)
                                    {
                                        Regex r2 = new Regex(@" (\d+)/(.*)L0 ");
                                        Match m2 = r2.Match(t);
                                        string location = "";
                                        if (m2.Success)
                                        {
                                            location = m2.Value.Trim();
                                        }
                                        Wait.SetWaitFormDescription("Đang tải PHY ( " + location + " )");
                                        Thread.Sleep(2);
                                    }
                                }
                            }
                            catch 
                            {
                              //  MessageBox.Show(ex.Message);
                                break;
                            }
                        }

                      // List<string> list = new List<string>();                     
                        result = result.Replace("TDMA", "TDMA \n");
                        result = result.Replace("\r--More--\b\b\b\b\b\b\b\b\b[K", "");
                        result = result.Replace("\r", "");
                        List = result.Split('\n');
                        
                        list1 = new List<string>();
                        //for (int i = 0; i < List.Length; i++)
                        //{
                            
                        //    List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                        //    List[i] = List[i].ToString().Replace("\r", "");
                        //    List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");                            

                        //    if (List[i].ToString().Trim().EndsWith("TDMA"))
                        //    {
                        //        if(List[i].ToString().Trim().Length>20)
                        //        {
                        //            string txt = List[i];
                        //            //txt = txt.Substring(txt.IndexOf("TDMA")+4);
                        //            list1.Add(txt);
                        //        }
                        //    }
                        //}
                        //TextWriter sw = new StreamWriter(@"Temp.txt", true);
                        //sw.WriteLine(result);
                        //sw.Close();
                    }
                    catch { }

                }

            }

        }

        public void IPPublic(string Mac, out string[] List)
        {

            List = null;
            string t = "";


            if (tcpClient.Connected)
            {
                string strCMD = "sh host authorization | include \"" + Mac + "\" \r\n";

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(strCMD);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(buffer, 0, buffer.Length);
                Thread.Sleep(50);
                //Application.DoEvents();
                byte[] message = new byte[8192 * 30];

                do
                {
                    Thread.Sleep(20);
                } while (!clientStream.DataAvailable);

                if (clientStream.CanRead && clientStream.DataAvailable)
                {
                    //blocks until a client sends a message  
                    try
                    {
                        int bytesRead;
                        string result = "";
                        while (true)
                        {
                            try
                            {
                                bytesRead = 0;
                                bytesRead = clientStream.Read(message, 0, 8192 * 30);
                                if (bytesRead == 0)
                                {
                                    break;
                                }
                                t = encoder.GetString(message, 0, bytesRead);
                                t = t.Trim();
                                result += t;                               
                                if (t.EndsWith("MOT:7A#"))
                                {
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }

                        List = result.Split('\n');
                        for (int i = 0; i < List.Length; i++)
                        {
                            List[i] = List[i].ToString().Replace("\r", "");
                        }

                    }
                    catch { }

                }

            }

        }

      public void Getme(string IpWan,out string Value1,out string Value2,out string Value3,out string Value4,out string mac,out string IpPrivate,out string location,out string Status)
      {
          Value1 = Value2 = Value3 = Value4 = mac = IpPrivate = location = Status = "";        
        
          string[] cat = IpWan.Split('.');
          if (cat[3].Length == 1)
          {
              IpWan = IpWan + "  ";
          }
          if (cat[3].Length == 2)
          {
              IpWan = IpWan + " ";
          }
          string t = "";
          //MessageBox.Show(cat[3].ToString());
          if (tcpClient.Connected)
          {
              string strCMD = "sh host authorization | include \"" + IpWan + "\"\r\n";

              ASCIIEncoding encoder = new ASCIIEncoding();
              byte[] buffer = encoder.GetBytes(strCMD);
              NetworkStream clientStream = tcpClient.GetStream();
              clientStream.Write(buffer, 0, buffer.Length);
              Thread.Sleep(100);
              byte[] message = new byte[8192 * 30];

              do
              {
                  Thread.Sleep(20);
              } while (!clientStream.DataAvailable);

              if (clientStream.CanRead && clientStream.DataAvailable)
              {
                  //blocks until a client sends a message  
                  try
                  {
                      int bytesRead;
                      string result = "";
                      while (true)
                      {
                          try
                          {
                              bytesRead = 0;
                              bytesRead = clientStream.Read(message, 0, 8192 * 30);

                              if (bytesRead == 0)
                              {
                                  break;
                              }
                              t = encoder.GetString(message, 0, bytesRead);
                              t = t.Trim();
                              result += t;                              
                              if (t.EndsWith("MOT:7A#"))
                              {
                                  break;
                              }
                          }
                          catch
                          {
                              break;
                          }
                      }
                   result=  result.Substring(result.IndexOf("authorization"));  
                   Regex r = new Regex(@"(\w+){4}.(\w+){4}.(\w+){4}");
                   Match m = r.Match(result);
                  // MessageBox.Show(result);
                   if (m.Success)
                   {
                       mac = m.Value.ToString();
                       //MessageBox.Show(mac);
                       if (mac != "")
                       {
                           Remote(mac, out IpPrivate, out Value1, out Value2, out Value3, out Value4, out Status, out location, out Value4);
                          // MessageBox.Show(Value1);
                           if (Status == "online")
                           {
                               Phy(mac, out Value4);
                           }
                       }
                   }

                  }
                  catch { }

              }

          }

      }

       public void SNR(string card,out string signal0,out string signal1,out string signal2,out string signal3,out string signal4,out string signal5,out string signal6,out string signal7)
          {

              signal0=signal1=signal2=signal3=signal4=signal5=signal6=signal7="";
              if (tcpClient.Connected)
              {
                 
                  string strCMD = "sh controllers cable "+card+" | include SNR \r\n";

                  string t = "";
                  ASCIIEncoding encoder = new ASCIIEncoding();
                  byte[] buffer = encoder.GetBytes(strCMD);
                  NetworkStream clientStream = tcpClient.GetStream();
                  clientStream.Write(buffer, 0, buffer.Length);
                  Thread.Sleep(100);
                  byte[] message = new byte[8192 * 30];

                  do
                  {
                      Thread.Sleep(20);
                  } while (!clientStream.DataAvailable);

                  if (clientStream.CanRead && clientStream.DataAvailable)
                  {
                      //blocks until a client sends a message  
                      try
                      {
                          int bytesRead;
                          string result = "";
                          while (true)
                          {
                              try
                              {
                                  bytesRead = 0;
                                  bytesRead = clientStream.Read(message, 0, 8192 * 30);

                                  if (bytesRead == 0)
                                  {
                                      break;
                                  }
                                  t = encoder.GetString(message, 0, bytesRead);
                                  t = t.Trim();
                                  result += t;
                                  if (t.EndsWith("MOT:7A#"))
                                  {
                                      break;
                                  }
                              }
                              catch
                              {
                                  break;
                              }
                          }
                          int tinh = 0;
                          if (result != "")
                          {
                              string[] SplSNR=result.Split('\n');
                              if (SplSNR.Length > 0)
                              {
                                  for (int ii = 0; ii < SplSNR.Length; ii++)
                                  {
                                      if (SplSNR[ii].IndexOf("SNR") > 0)
                                      {
                                          if (card == "10/0")
                                          {
                                              if (ii == 1)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal0 = catt[2].Trim();
                                              }
                                              if (ii == 2)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal1 = catt[2].Trim();
                                              }
                                              if (ii == 3)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal2 = catt[2].Trim();
                                              }
                                              if (ii == 4)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal3 = catt[2].Trim();
                                              }
                                              if (ii == 5)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal4 = catt[2].Trim();
                                              }
                                              if (ii == 6)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal5 = catt[2].Trim();
                                              }
                                              if (ii == 7)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal6 = catt[2].Trim();
                                              }
                                              if (ii == 8)
                                              {
                                                  string[] catt = SplSNR[ii].Split(' ');
                                                  signal7 = catt[2].Trim();
                                              }

                                          }else
                                          {
                                              if (SplSNR[ii].IndexOf("\t") > 0)
                                              {
                                                  string[] cat = SplSNR[ii].Split('\t');
                                                  if (cat.Length > 0)
                                                  {
                                                      if (tinh == 0)
                                                      {
                                                          signal0 = cat[1].Trim();
                                                      }
                                                      if (tinh == 1)
                                                      {
                                                          signal1 = cat[1].Trim();
                                                      }
                                                      if (tinh == 2)
                                                      {
                                                          signal2 = cat[1].Trim();
                                                      }
                                                      if (tinh == 3)
                                                      {
                                                          signal3 = cat[1].Trim();
                                                      }
                                                      if (tinh == 4)
                                                      {
                                                          signal4 = cat[1].Trim();
                                                      }
                                                      if (tinh == 5)
                                                      {
                                                          signal5 = cat[1].Trim();
                                                      }
                                                      if (tinh == 6)
                                                      {
                                                          signal6 = cat[1].Trim();
                                                      }
                                                      if (tinh == 7)
                                                      {
                                                          signal7 = cat[1].Trim();
                                                      }
                                                  }
                                                  tinh++;
                                              }
                                          }
                                      }

                                  }
                              }

                          }
                          ///////////////////////////////

                      }
                      catch { }

                  }

              }

          }

       public void Stast_Card_All(out string[] List)
       {
           List = null;
           string t = "";

           if (tcpClient.Connected)
           {
               string strCMD = "sh cable modem \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }
                              
                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }

                       List = result.Split('\n');
                       for (int i = 0; i < List.Length; i++)
                       {
                           List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("NEW_MOT:7A#", "");
                           List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("\r", "");

                       }

                   }
                   catch { }

               }
           }
       }

       public void Get_IPPublic(out string[] List)
       {
           List = null;
           string t = "";

           if (tcpClient.Connected)
           {
               string strCMD = "sh host au | i Host \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }

                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }

                       List = result.Split('\n');
                       for (int i = 0; i < List.Length; i++)
                       {
                           List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("NEW_MOT:7A#", "");
                           List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("\r", "");

                       }

                   }
                   catch { }

               }
           }
       }

       public void Get_Traffic(out string List)
       {
           List = null;
           string t = "";

           if (tcpClient.Connected)
           {
               string strCMD = "sh cable modem throughput \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }

                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }
                       result = result.Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");
                       result = result.Replace("MAC Address:", "\n\rMAC Address:");
                       while (result.IndexOf("\n\r\n\r") > 0)
                       {
                           result = result.Replace("\n\r\n\r", "\n\r");
                       }

                       List = result;                                              

                   }
                   catch { }

               }
           }
       }

       public void Get_Traffic(string strCMD, out string List)
       {
           List = null;
           string t = "";

           if (tcpClient.Connected)
           {
               //string strCMD = "sh cable modem throughput \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }

                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }
                       result = result.Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");                      
                       List = result;
                   }
                   catch { }

               }
           }
       }

       public void Get_TrafficMac(string Mac, out string DS, out string US)
       {          
           string t = "";
           DS = "";
           US = "";
           if (tcpClient.Connected)
           {
               string strCMD = "sh cable modem "+Mac+" stats  \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }

                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }
                       result = result.Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");
                       result = result.Replace("0/0", "\n\r0/0");
                       result = result.Replace("1/0", "\n\r1/0");
                       result = result.Replace("2/0", "\n\r2/0");
                       result = result.Replace("3/0", "\n\r3/0");
                       result = result.Replace("4/0", "\n\r4/0");
                       result = result.Replace("5/0", "\n\r5/0");
                       result = result.Replace("9/0", "\n\r9/0");
                       result = result.Replace("10/0", "\n\r10/0");
                       result = result.Replace("11/0", "\n\r11/0");
                       while (result.IndexOf("\n\r\n\r") > 0)
                       {
                           result = result.Replace("\n\r\n\r", "\n\r");
                       }
                       string[] sp = result.Split('\n');
                       string[] cat = null;
                       for (int i = 0; i < sp.Length; i++)
                       {
                           cat = null;
                           sp[i] = sp[i].Replace("\r", "");
                           sp[i] = sp[i].Trim();
                           while (sp[i].IndexOf("  ") > 0)
                           {
                               sp[i] = sp[i].Replace("  ", " ");
                           }
                           cat = sp[i].Split(' ');
                           if (cat.Length == 8)
                           {
                               
                             //  dr["MacAddress"] = cat[5];
                               //dr["CurrentUS"] = cat[6];
                              // dr["CurrentDS"] = cat[7];
                               DS = cat[7];
                               US = cat[6];                            

                           }
                       }

                   }
                   catch { }

               }
           }
       }

       public void Get_DeviceStatus(out string[] List)
       {
           List = null;
           string t = "";

           if (tcpClient.Connected)
           {
               string strCMD = "sh host authorization summary \r\n";

               ASCIIEncoding encoder = new ASCIIEncoding();
               byte[] buffer = encoder.GetBytes(strCMD);
               NetworkStream clientStream = tcpClient.GetStream();
               clientStream.Write(buffer, 0, buffer.Length);
               Thread.Sleep(100);
               byte[] message = new byte[8192 * 40];

               do
               {
                   Thread.Sleep(100);
               } while (!clientStream.DataAvailable);

               if (clientStream.CanRead && clientStream.DataAvailable)
               {
                   //blocks until a client sends a message  
                   try
                   {
                       int bytesRead;
                       string result = "";
                       while (true)
                       {
                           try
                           {
                               bytesRead = 0;
                               bytesRead = clientStream.Read(message, 0, 8192 * 40);

                               if (bytesRead == 0)
                               {
                                   break;
                               }

                               t = encoder.GetString(message, 0, bytesRead);
                               t = t.Trim();
                               result += t;
                               if (t.EndsWith("--More--"))
                               {
                                   buffer = encoder.GetBytes(" ");
                                   clientStream.Write(buffer, 0, buffer.Length);
                                   Thread.Sleep(50);
                                   Application.DoEvents();
                               }
                               if (t.EndsWith("MOT:7A#"))
                               {
                                   break;
                               }
                           }
                           catch
                           {
                               break;
                           }
                       }
                       while (result.IndexOf("  ") > 0)
                       {
                           result = result.Replace("  ", " ");
                       }

                       List = result.Split('\n');
                       for (int i = 0; i < List.Length; i++)
                       {
                           List[i] = List[i].ToString().Replace("\r--More-- \b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("NEW_MOT:7A#", "");
                           List[i] = List[i].ToString().Replace("--More--\b\b\b\b\b\b\b\b\b[K", "");
                           List[i] = List[i].ToString().Replace("\r", "");

                       }

                   }
                   catch { }

               }
           }
       }
  }
}
