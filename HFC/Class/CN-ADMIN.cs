using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HFC.Class
{
   public class CN_ADMIN
    {
      public static WebBrowser webcontrol = new System.Windows.Forms.WebBrowser();
      static string hostLogin = "http://101.99.28.133/cn-admin/?mod=modem";
      static string urlServer = "http://101.99.28.133";
      public static string User = "tracuu";
      public static string Passwors = "lbc123456";
      public void Connect(string user, string password)
      {
          //  webcontrol.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(webcontrol_DocumentCompleted);
          string postdata = "usernameWanted=" + user + "&passwordTried=" + password;
          System.Text.Encoding a = System.Text.Encoding.UTF8;
          byte[] sentdata = a.GetBytes(postdata);
          webcontrol.Navigate(hostLogin, "", sentdata, "Content-Type: application/x-www-form-urlencoded\r\n");
          while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
          {
              Application.DoEvents();
              System.Threading.Thread.Sleep(50);
          }
      }

      public bool isLogin()
      {
          string Url = urlServer + "/cn-admin/";
          webcontrol.Navigate(Url);
          while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
          {
              Application.DoEvents();
              System.Threading.Thread.Sleep(50);
          }
          string result = webcontrol.DocumentText;
          if (result.IndexOf("Logout") > 0)
          {
              return true;
          }
          return false;
      }

      public List<string> Device_Search(string MacModem, string SearchMode,out string CustomerName, out string Address,out string Ward, out string ModemID)
      {
          List<string> l = new List<string>();
          CustomerName = "";
          Address = "";
          Ward = "";
          ModemID = "";
          if (isLogin())
          {
              string url = "";
              if (SearchMode == "0")
              {
                  url = urlServer + "/cn-admin/?mod=modem&do=search&search_mode=contains&search_type=mMac&search=" + MacModem + "&cmts=view&nID=&searchit=";
              }
              else if (SearchMode == "1")
              {
                  url = urlServer + "/cn-admin/?mod=modem&do=search&search_mode=begins&search_type=mMac&search=" + MacModem + "&cmts=view&nID=&searchit=";
              }
              else
              {
                  url = urlServer + "/cn-admin/?mod=modem&do=search&search_mode=matches&search_type=mMac&search=" + MacModem + "&cmts=view&nID=&searchit=";
              }

              webcontrol.Navigate(url);
              while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
              {
                  Application.DoEvents();
                  System.Threading.Thread.Sleep(50);
              }
              string content = webcontrol.DocumentText;
              Regex r = new Regex(@"<input (.*\s){6}<td valign=center>(.*)<br>(.*)</td>(.*\s){2}<td valign=center>(.*)<br>(.*)</td>(.*\s){2}<td valign=center>(.*)<br>(.*)</td>(.*\s){2}<td valign=center>(.*)<br>(.*)</td>(.*\s){2}<td valign=center>(.*)<br>(.*)</td>");
              Match m = r.Match(content);
              string txt = "";
              while (m.Success)
              {
                  // Lấy ModemID
                  string[] modemid = m.Groups[0].Value.Split(' ');
                  string _modemid = modemid[3].ToString();
                  _modemid = _modemid.Replace("value='", "");
                  _modemid = _modemid.Replace("'>", "");

                  txt = _modemid.Trim() +
                      "|" + m.Groups[2].Value.ToString().Trim() +
                      "|" + m.Groups[3].Value.ToString().Trim() +
                      "|" + m.Groups[5].Value.ToString().Trim() +
                      "|" + m.Groups[6].Value.ToString().Trim() +
                       "|" + m.Groups[7].Value.ToString().Trim() +
                      "|" + m.Groups[8].Value.ToString().Trim() +
                       "|" + m.Groups[9].Value.ToString().Trim() +
                      "|" + m.Groups[10].Value.ToString().Trim() +
                      "|" + m.Groups[11].Value.ToString().Trim() +
                        "|" + m.Groups[12].Value.ToString().Trim() +
                          "|" + m.Groups[13].Value.ToString().Trim() +
                      "|" + m.Groups[14].Value.ToString().Trim() +
                      "|" + m.Groups[15].Value.ToString().Trim();
                  
                  ModemID = _modemid.Trim();
                  CustomerName = m.Groups[6].Value.ToString().Trim();
                  Address = m.Groups[8].Value.ToString().Trim() +" "+ m.Groups[9].Value.ToString().Trim();
                  Ward = m.Groups[9].Value.ToString().Trim();
                  l.Add(txt);
                  m = m.NextMatch();
              }
          }

          return l;
      }

      public void Device__Edit_View(string MacDevice, out string CustomerName, out string Address, out string Ward, out string District)
      {
          CustomerName = "";
          Address = "";
          Ward = "";
          District = "";
          if (isLogin())
          {
              string Url = urlServer + "/cn-admin/?mod=modem&cmts=modemdata&ToDo=edit&cmtsID=&dwsID=&upsID=&nID=&macadr=" + MacDevice;
              webcontrol.Navigate(Url);
              while (webcontrol.ReadyState != WebBrowserReadyState.Complete)
              {
                  Application.DoEvents();
                  System.Threading.Thread.Sleep(50);
              }
              string content = webcontrol.DocumentText;
              if (content.IndexOf("Customer Data") > 0)
              {
                  Regex r = new Regex(@"value=(.*)></b></td>(.*\s){5}value=(.*)></b></td>(.*\s){5}value=(.*)><input type=(.*)value=(.*)><input type=(.*)value=(.*)></b></td>");
                  Match m = r.Match(content);
                  
                  if (m.Success)
                  {
                      // Lấy ModemID
                      string[] modemid = m.Groups[0].Value.Split(' ');

                      string _modemid = m.Groups[0].Value.ToString();
                      _modemid = m.Groups[1].Value.ToString();     /// ten
                      _modemid = m.Groups[2].Value.ToString(); 
                      _modemid = m.Groups[3].Value.ToString();     // 
                      _modemid = m.Groups[4].Value.ToString();
                      _modemid = m.Groups[5].Value.ToString();      //dia chi
                      _modemid = m.Groups[6].Value.ToString();
                      _modemid = m.Groups[7].Value.ToString();     //phuong
                      _modemid = m.Groups[8].Value.ToString();
                      _modemid = m.Groups[9].Value.ToString();//    quan
                      CustomerName = m.Groups[1].Value.ToString().Replace('"',' ');
                      CustomerName = CustomerName.Trim();
                      Address = m.Groups[5].Value.ToString().Replace('"', ' ')  + m.Groups[7].Value.ToString().Replace('"', ' ') + m.Groups[9].Value.ToString().Replace('"', ' ');
                      Address = Address.Replace("  ", " ");
                      Ward = m.Groups[7].Value.ToString().Replace('"', ' ');
                      Ward = Ward.Trim();
                      District = m.Groups[9].Value.ToString().Replace('"', ' ');
                      District = District.Trim();  
                  }
              }
          }
      }

   }
}
