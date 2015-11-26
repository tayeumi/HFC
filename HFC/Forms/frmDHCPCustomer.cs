using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace HFC.Forms
{
    public partial class frmDHCPCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPCustomer()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        void NW_Dhcp_Customer_Getlist()
        {
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            dt = cls.NW_Dhcp_Customer_Getlist();
            gridItem.DataSource = dt;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "DHCP conf|*.conf";
            open.Title = "Select config file";
            open.ShowDialog();
            txtLink.Text = open.FileName;
            if (txtLink.Text.Length > 0)
                btnRead.Enabled = true;
            else
                btnRead.Enabled = false;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            if (txtLink.Text.Length > 3)
            {
               string[] lines = System.IO.File.ReadAllLines(txtLink.Text);
              //  string txt = System.IO.File.ReadAllText(txtLink.Text);
               DataRow dr;
               string mac = "";
               string ip = "";
               string bootfile = "";
               string code = "";
               string name = "";
               string macCMTS = "";
               string pool = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].ToString().StartsWith("\t\t#  192.168."))
                    {
                        if (lines[i + 8].ToString() == "\t\t}")
                        {
                            if (lines[i - 8].ToString().StartsWith("\tsubnet"))
                            {
                                pool = lines[i - 8].ToString();
                                pool = pool.Trim();
                                pool = pool.Substring(pool.IndexOf(" "));
                                pool = pool.Trim();
                                pool = pool.Substring(0,pool.IndexOf(" "));
                                pool = pool.Trim();
                            }
                            dr = dt.NewRow();
                            mac = lines[i + 2].ToString();
                            mac = mac.Replace("hardware ethernet", "");
                            mac = mac.Replace(";", "");
                            mac = mac.Trim();
                            ip = lines[i + 3].ToString();
                            ip = ip.Replace("fixed-address", "");
                            ip = ip.Replace(";", "");
                            ip = ip.Trim();
                            bootfile = lines[i + 7].ToString();
                            bootfile = bootfile.Replace("filename", "");
                            bootfile = bootfile.Replace(";", "");
                            bootfile = bootfile.Replace("\"", "");
                            bootfile = bootfile.Trim();

                            code = lines[i].ToString();
                            code = code.Substring(code.IndexOf("Kunde"));
                            code = code.Replace("Kunde", "");
                            code = code.Trim();
                            if (code.Length > 2)
                            {
                                if (code.IndexOf(" ") > 0)
                                {
                                    name = code.Substring(code.IndexOf(" ")).Trim();                                
                                    code = code.Substring(0, code.IndexOf(" ")).Trim();
                                }
                            }

                            macCMTS = mac;
                            macCMTS = macCMTS.Replace(":", "");
                            macCMTS = macCMTS.Insert(4, ".");
                            macCMTS = macCMTS.Insert(9, ".");

                            dr["IpAddress"] = ip;
                            dr["MacAddress"] = mac;
                            dr["Bootfile"] = bootfile;
                            dr["CustomerCode"] = code;
                            dr["CustomerName"] = name;
                            dr["MacAddress_CMTS"] = macCMTS;
                            dr["PoolIp"] = pool;
                            dt.Rows.Add(dr);
                        }
                    }
                }
              //  Regex r = new Regex(@"\t\t#(.*)\t\t}");
              //Match m = r.Match(txt);
             
              //while (m.Success)
              //{
              //    string x = m.Groups[0].Value.ToString(); ;

              //}
            }
        }

        private void frmDHCPCustomer_Load(object sender, EventArgs e)
        {
            NW_Dhcp_Customer_Getlist();
        }
    }
}