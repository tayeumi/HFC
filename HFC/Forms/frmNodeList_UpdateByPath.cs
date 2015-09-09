using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace HFC.Forms
{
    public partial class frmNodeList_UpdateByPath : DevExpress.XtraEditors.XtraForm
    {
        public frmNodeList_UpdateByPath()
        {
            InitializeComponent();
        }
        string location = "";
        public frmNodeList_UpdateByPath(string node, string firstLocarion)
        {
            InitializeComponent();
            txtCode.Text = node;
            txtCode.Enabled = false;
            Class.NW_Node cls = new Class.NW_Node();
            cls.NodeCode = node;
            DataTable dt = cls.NW_Node_Get();
            if(dt.Rows.Count==1){
                txtPath.Text = dt.Rows[0]["Path"].ToString();
            }

            if (txtPath.Text.Length < 1)
            {
                txtPath.Text = firstLocarion;
            }
            location = firstLocarion;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Class.NW_Node cls = new Class.NW_Node();
            cls.NodeCode = txtCode.Text;
            cls.Path = txtPath.Text;
            if (cls.UpdateByPath())
            {
                Class.App.SaveSuccessfully();
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }            
        }

        private void btnViewmaps_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            try
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Text = System.IO.Path.GetFileName(System.Environment.GetCommandLineArgs()[0]);

                if (txtPath.Text.Length > 5)
                {
                    if (File.Exists("path.txt"))
                    {
                        TextReader tr = new StreamReader("path.txt");
                        string msg = tr.ReadToEnd();
                        tr.Close();
                        string path = "";
                        string line = "";
                        string _path = txtPath.Text;
                        string[] catpath = _path.Split(';');
                        string lat1 = "";
                        string lng1 = "";
                        string first = "";
                        path += "var path" + 1 + " = [";

                        line = "\n var flightPath = new google.maps.Polygon({ \n" +
                               " paths: path" + 1 + " ,\n" +
                                "strokeColor: '#FF0000',\n" +
                                "strokeOpacity: 0.8,\n" +
                                "strokeWeight: 2,\n" +
                                "fillColor: '#FF0000',\n" +
                                "fillOpacity: 0.35\n" +
                              "});\n" +
                              " flightPath.setMap(map);\n";

                        for (int j = 0; j < catpath.Length; j++)
                        {
                            lat1 = catpath[j].ToString().Substring(0, catpath[j].ToString().IndexOf(','));
                            lng1 = catpath[j].ToString().Substring(catpath[j].IndexOf(',') + 1);
                            path += "\n{lat:" + lat1 + ",lng: " + lng1 + "} ,";
                            // path += "\n new google.maps.LatLng("+lat1+", "+lng1+"),";
                            first = "{lat:" + lat1 + ", lng:" + lng1 + "}";//"{lat:" + lat1 + ",lng: " + lng1 + "}";
                        }
                        path = path.TrimEnd(',');
                        path += "\n];\n";

                        msg = msg.Replace("_addpath", path);
                        msg = msg.Replace("_addline", line);
                        msg = msg.Replace("_first", first);

                        TextWriter sw = new StreamWriter(@"path.html", false);
                        sw.Write(msg);
                        sw.Close();
                        webControl.Navigate(Application.StartupPath+"\\path.html");                    }
                        while (webControl.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(50);
                        }
                        webControl.Refresh();
                    // while(webControl.doc   
                    // webControl.DocumentText = msg;
                   // } 
                }
            }
            catch { }
        }

        void getlatlng()
        {
            try
            {
                
                    HtmlElement htmlelement = webControl.Document.GetElementById("latlng");
                    if (htmlelement == null)
                    {
                        return;
                    }
                    else
                    {
                        lblLocation.Text = webControl.Document.GetElementById("latlng").OuterText;
                    }
                
            }
            catch { }
        }       

        private void timer1_Tick(object sender, EventArgs e)
        {
            getlatlng(); ;
        }

        private void lblLocation_TextChanged(object sender, EventArgs e)
        {
            if (lblLocation.Text.Length > 0)
                btnAddlocation.Enabled = true;
            else
                btnAddlocation.Enabled = false;
        }

        private void btnAddlocation_Click(object sender, EventArgs e)
        {
            txtPath.Text += ";"+lblLocation.Text;
            txtPath.Text = txtPath.Text.TrimStart(';');
        }

        private void btnPreviewLine_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            try
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //this.Text = System.IO.Path.GetFileName(System.Environment.GetCommandLineArgs()[0]);

                if (txtPath.Text.Length > 5)
                {
                    if (File.Exists("path.txt"))
                    {
                        TextReader tr = new StreamReader("path.txt");
                        string msg = tr.ReadToEnd();
                        tr.Close();
                        string path = "";
                        string line = "";
                        string _path = txtPath.Text;
                        string[] catpath = _path.Split(';');
                        string lat1 = "";
                        string lng1 = "";
                        string first = "";
                        path += "var path" + 1 + " = [";

                        line = "\n var flightPath = new google.maps.Polyline({ \n" +
                               " path: path" + 1 + " ,\n" +
                                "geodesic: true,\n"+
                                "strokeColor: '#FF0000', \n"+
                                "strokeOpacity: 1.0,\n"+
                                "strokeWeight: 2\n"+
                              "});\n" +
                              " flightPath.setMap(map);\n";

                        for (int j = 0; j < catpath.Length; j++)
                        {
                            lat1 = catpath[j].ToString().Substring(0, catpath[j].ToString().IndexOf(','));
                            lng1 = catpath[j].ToString().Substring(catpath[j].IndexOf(',') + 1);
                            path += "\n{lat:" + lat1 + ",lng: " + lng1 + "} ,";
                            // path += "\n new google.maps.LatLng("+lat1+", "+lng1+"),";
                            first = "{lat:" + lat1 + ", lng:" + lng1 + "}";//"{lat:" + lat1 + ",lng: " + lng1 + "}";
                        }
                        path = path.TrimEnd(',');
                        path += "\n];\n";

                        msg = msg.Replace("_addpath", path);
                        msg = msg.Replace("_addline", line);
                        msg = msg.Replace("_first", first);

                        TextWriter sw = new StreamWriter(@"path.html", false);
                        sw.Write(msg);
                        sw.Close();
                        webControl.Navigate(Application.StartupPath + "\\path.html");
                    }
                    while (webControl.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                    }
                    webControl.Refresh();
                    // while(webControl.doc   
                    // webControl.DocumentText = msg;
                    // } 
                }
            }
            catch { }
        }
    }
}