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
    public partial class frmDHCPCustomer_StaticIP : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPCustomer_StaticIP()
        {
            InitializeComponent();
        }
        public bool add_edit=false;
        string ipaddress = "";
        public frmDHCPCustomer_StaticIP(string IPAddress,string Title,string Note)
        {
            InitializeComponent();
            this.Text = Title;
            ipaddress = IPAddress;
            Class.NW_Dhcp_Ip clsIP = new Class.NW_Dhcp_Ip();
            DataTable dtip = clsIP.NW_Dhcp_Ip_GetbyCPEStatic_MySQL();
            cboPoolIp.Properties.DataSource = dtip;
            cboPoolIp.Properties.DisplayMember = "PoolIp";
            cboPoolIp.Properties.ValueMember = "PoolIp";
            txtNote.Text = Note;
        }

        private void cboPoolIp_EditValueChanged(object sender, EventArgs e)
        {
            Class.NW_Dhcp_Ip cls = new Class.NW_Dhcp_Ip();
            Class.NW_Dhcp_Customer clscus = new Class.NW_Dhcp_Customer();
            clscus.PoolIp = cboPoolIp.EditValue.ToString();
            DataTable dtcus = clscus.NW_Dhcp_Customer_GetbyPoolPublic_MySQL();
            cls.PoolIp = cboPoolIp.EditValue.ToString();
            DataTable dt = cls.NW_Dhcp_Ip_GetIPbyPool_MySQL();
            string ip = "";
            bool check = false; ;
            if (dt.Rows.Count > 0)
            {
                string range = dt.Rows[0]["RangeIP"].ToString();
                string[] cat = range.Split(' ');
                if (cat.Length > 1)
                {
                    txtIpAddress.Properties.Items.Clear();
                    string[] temp = cat[0].Split('.');
                    int start = 0;
                    int end = 0;
                    if (temp.Length > 2)
                    {
                        start = int.Parse(temp[3]);
                    }
                    temp = cat[1].Split('.');
                    if (temp.Length > 2)
                    {
                        end = int.Parse(temp[3]);
                    }

                    for (int i = start; i < end; i++)
                    {
                        ip = temp[0] + "." + temp[1] + "." + temp[2] + "." + i.ToString();
                        check = false;
                        for (int j = 0; j < dtcus.Rows.Count; j++)
                        {
                            if (ip == dtcus.Rows[j]["IpPublic"].ToString())
                            {
                                check = true;
                            }

                        }
                        if (check == false)
                        {
                            txtIpAddress.Properties.Items.Add(ip);
                        }

                    }
                }
            }
            if (txtIpAddress.Properties.Items.Count > 0)
            {
                txtIpAddress.Text = txtIpAddress.Properties.Items[0].ToString();
            }
            else
            {
                txtIpAddress.Text = "";
            }
        }

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            if (cboPoolIp.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtIpAddress.Text == "")
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtMacAddress.Text == "")
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            cls.IpAddress = ipaddress;
            cls.PoolPublic = cboPoolIp.EditValue.ToString();
            cls.IpPublic = txtIpAddress.Text;
            cls.MacPc = txtMacAddress.Text;
            cls.Note = txtNote.Text;
            if (cls.NW_Dhcp_Customer_UpdateIPStatic_MySQL())
            {
                Class.App.SaveSuccessfully();
                add_edit = true;
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }
            this.Close();
        }

        private void txtMacAddress_Validated(object sender, EventArgs e)
        {
            txtMacAddress.Text = txtMacAddress.Text.Replace("-", ":").ToLower();
            string input = txtMacAddress.Text;
            // input = input.Replace(" ", "").Replace(":", "").Replace("-", "");

            Regex r = new Regex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");


            if (!r.IsMatch(input))
            {
                MessageBox.Show(" Mac Address không hợp lệ ! ");
                txtMacAddress.Focus();
            }
        }
    }
}