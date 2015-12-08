using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace HFC.Class
{
    class DHCPRestart
    {
        HttpListener server = new HttpListener();


        public void Start()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
               // IPAddress ipAddr = ipHost.AddressList[3];
                string ip = "";
                for (int i = 1; i < ipHost.AddressList.Length; i++)
                {
                    ip = ipHost.AddressList[i].ToString();
                    server.Prefixes.Add("http://" + ip + ":1111/");  
                }
                              
                // server.Start();
                try
                {
                    server.Start(); //Throws Exception
                }
                catch (HttpListenerException ex)
                {
                    if (ex.Message.Contains("Access is denied"))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
                Console.WriteLine("Listening...");

                while (true)
                {
                    HttpListenerContext context = server.GetContext();
                    HttpListenerResponse response = context.Response;

                    string page = context.Request.Url.ToString();

                    //page = context.Request.Url.LocalPath; ;
                    //   if (page == string.Empty)
                    if (page.Contains("dhcprestart.html"))
                    {
                        string msg = "";  
                        // tao file conf
                        #region Tao file config
                        try
                        {
                            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
                             DataTable dt = cls.NW_Dhcp_Customer_Getlist();
                            if (dt.Rows.Count > 0)
                            {
                                if (System.IO.File.Exists(@"dhcpd.conf.temp"))
                                {
                                    string txt = System.IO.File.ReadAllText(@"dhcpd.conf.temp");
                                    string CPEDynamic = "";
                                    string CPEStatic = "";
                                    string PoolModem = "";
                                    Class.NW_Dhcp_Ip clsIP = new Class.NW_Dhcp_Ip();
                                    Class.NW_Dhcp_Customer clsModem = new Class.NW_Dhcp_Customer();
                                    DataTable dtCPEDynamic = clsIP.NW_Dhcp_Ip_GetbyCPEDynamic();
                                    DataTable dtCPEStatic = clsIP.NW_Dhcp_Ip_GetbyCPEStatic();
                                    DataTable dtPoolModem = clsIP.NW_Dhcp_Ip_GetbyPoolModem();
                                    #region CPEDynamic
                                    for (int i = 0; i < dtCPEDynamic.Rows.Count; i++)
                                    {
                                        CPEDynamic += "\tsubnet " + dtCPEDynamic.Rows[i]["PoolIp"].ToString() + " netmask " + dtCPEDynamic.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                                        "\t\tauthoritative;\n" +
                                                        "\t\toption subnet-mask " + dtCPEDynamic.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                                        "\t\toption domain-name-servers " + dtCPEDynamic.Rows[i]["Dns"].ToString() + ";\n" +
                                                        "\t\toption routers " + dtCPEDynamic.Rows[i]["Router"].ToString() + ";\n" +
                                                        "\t\toption broadcast-address " + dtCPEDynamic.Rows[i]["Broadcast"].ToString() + ";\n" +
                                                        "\t\tpool {\n" +
                                                            "\t\trange " + dtCPEDynamic.Rows[i]["Range"].ToString() + ";\n" +
                                                            "\t\t}\n" +
                                                        "\t}\n" +
                                                        "\tgroup {\n" +
                                                            "\t\tuse-host-decl-names on;\n" +
                                                        "\t}\n";
                                    }
                                    #endregion
                                    #region CPEStatic
                                    for (int i = 0; i < dtCPEStatic.Rows.Count; i++)
                                    {
                                        clsModem.PoolIp = dtCPEStatic.Rows[i]["PoolIp"].ToString();
                                        DataTable dtmodem = clsModem.NW_Dhcp_Customer_GetbyPoolPublic();
                                        string txtmodem = "";
                                        for (int j = 0; j < dtmodem.Rows.Count; j++)
                                        {
                                            string ipcpe = dtmodem.Rows[j]["IpPublic"].ToString();
                                            ipcpe = ipcpe.Replace(":", "-");
                                            string reIPcpe = dtmodem.Rows[j]["MacPc"].ToString().Replace(":", "");
                                            txtmodem += "\t\t# PC an Modem " + dtmodem.Rows[j]["IpAddress"].ToString() + " " + dtmodem.Rows[j]["Note"].ToString() + " Kunde " + dtmodem.Rows[j]["CustomerCode"].ToString() + " " + dtmodem.Rows[j]["CustomerName"].ToString() + "\n" +
                                                        "\t\thost " + ipcpe + " {\n" +
                                                            "\t\t\thardware ethernet " + dtmodem.Rows[j]["MacPc"].ToString() + " ;\n" +
                                                            "\t\t\tfixed-address " + dtmodem.Rows[j]["IpPublic"].ToString() + ";\n" +
                                                            "\t\t\toption host-name 	\"mt" + reIPcpe + "\";\n" +
                                                            "\t\t\tddns-hostname 	\"mt" + reIPcpe + "\";\n" +
                                                        "\t\t}\n";
                                        }

                                        CPEStatic += "\tsubnet " + dtCPEStatic.Rows[i]["PoolIp"].ToString() + " netmask " + dtCPEStatic.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                                    "\t\tauthoritative;\n" +
                                                    "\t\toption subnet-mask " + dtCPEStatic.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                                    "\t\toption domain-name-servers " + dtCPEStatic.Rows[i]["Dns"].ToString() + ";\n" +
                                                    "\t\toption routers " + dtCPEStatic.Rows[i]["Router"].ToString() + ";\n" +
                                                    "\t\toption broadcast-address " + dtCPEStatic.Rows[i]["Broadcast"].ToString() + ";\n" +
                                                    "\t}\n" +
                                                    "\tgroup {\n" +
                                                        "\t\tuse-host-decl-names on;\n" +
                                                        txtmodem +
                                                    "\t}\n";
                                    }
                                    #endregion
                                    #region CableMode
                                    for (int i = 0; i < dtPoolModem.Rows.Count; i++)
                                    {
                                        clsModem.PoolIp = dtPoolModem.Rows[i]["PoolIp"].ToString();
                                        DataTable dtmodem = clsModem.NW_Dhcp_Customer_GetbyPool();
                                        string listmodem = "";
                                        for (int j = 0; j < dtmodem.Rows.Count; j++)
                                        {
                                            string cm = dtmodem.Rows[j]["MacAddress"].ToString();
                                            cm = cm.Replace(":", "");
                                            listmodem += "\t\t#  " + dtmodem.Rows[j]["IpAddress"].ToString() + " Kunde " + dtmodem.Rows[j]["CustomerCode"].ToString() + " " + dtmodem.Rows[j]["CustomerName"].ToString() + "\n" +
                                                            "\t\thost " + cm + " {\n" +
                                                            "\t\t\thardware ethernet " + dtmodem.Rows[j]["MacAddress"].ToString() + " ; \n" +
                                                            "\t\t\tfixed-address " + dtmodem.Rows[j]["IpAddress"].ToString() + ";\n" +
                                                            "\t\t\toption host-name \"cm" + cm + "\";\n" +
                                                            "\t\t\tddns-hostname  \"cm" + cm + "\";\n" +
                                                            "\t\t\toption bootfile-name \"" + dtmodem.Rows[j]["Bootfile"].ToString() + "\";\n" +
                                                            "\t\t\tfilename \"" + dtmodem.Rows[j]["Bootfile"].ToString() + "\";\n" +
                                                            "\t\t}\n";
                                        }
                                        PoolModem += "\tsubnet " + dtPoolModem.Rows[i]["PoolIp"].ToString() + " netmask " + dtPoolModem.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                                    "\t\tauthoritative;\n" +
                                                    "\t\toption subnet-mask " + dtPoolModem.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                                    "\t\toption routers " + dtPoolModem.Rows[i]["Router"].ToString() + ";\n" +
                                                    "\t\toption broadcast-address " + dtPoolModem.Rows[i]["Broadcast"].ToString() + ";\n" +
                                                    "\t}\n" +
                                                    "\tgroup {\n" +
                                                        "\t\tuse-host-decl-names on;\n" +
                                                        listmodem +
                                                     "\t}\n";

                                    }
                                    #endregion

                                    txt = txt.Replace("<_CPEDynamic>", CPEDynamic);
                                    txt = txt.Replace("<_CPEStatic>", CPEStatic);
                                    txt = txt.Replace("<_modemip>", PoolModem);

                                    System.IO.File.WriteAllText(@"dhcpd.conf", txt);
                                }
                                else
                                {
                                    msg="file dhcpd.conf.temp not found!";
                                }
                            }
                            msg = "Create file success!";
                        }
                        catch
                        {
                            msg = "Fail create to file..";
                        }
                        #endregion
                        #region UploadtoServer
                        if (msg == "Create file success!")
                        {
                            msg += "\r\nTranfer file to SERVER ";
                            Class.App.uploadFile("ftp://101.99.28.152/test/", Application.StartupPath + "/dhcpd.conf", "administrator", "831031");
                            try
                            {
                                msg += "Ok";
                            }
                            catch {
                                msg += "Fail";
                            }
                        }
                        #endregion

                        //write respones
                        byte[] buffer = Encoding.UTF8.GetBytes(msg);

                        response.ContentLength64 = buffer.Length;
                        Stream st = response.OutputStream;
                        st.Write(buffer, 0, buffer.Length);
                        st.Close();
                       
                    }                
                    else
                    {
                        string msg = "Access Deny !";

                        byte[] buffer = Encoding.UTF8.GetBytes(msg);

                        response.ContentLength64 = buffer.Length;
                        Stream st = response.OutputStream;
                        st.Write(buffer, 0, buffer.Length);
                        st.Close();
                    }

                    context.Response.Close();
                }
            }
            catch {}

        }

        public void Stop()
        {
            if (server.IsListening)
            {
                server.Stop();
            }
        }
    }
}
