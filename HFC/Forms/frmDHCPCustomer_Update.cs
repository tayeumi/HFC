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
    public partial class frmDHCPCustomer_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPCustomer_Update()
        {
            InitializeComponent();
        }
       public bool add_edit = false;
        public frmDHCPCustomer_Update(bool Add_new, string Caption_name, string Form_name, string Code)
        {
            InitializeComponent();
            this.Text = Caption_name;
            //NW_Dhcp_Ip_GetbyPoolModem();
            NW_Dhcp_Ip_GetbyPoolModem_MySQL();
            if (Add_new)
            {
                call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);               
            }
        }
        void NW_Dhcp_Ip_GetbyPoolModem()
        {
            Class.NW_Dhcp_Ip clsIP = new Class.NW_Dhcp_Ip();
            DataTable dtip = clsIP.NW_Dhcp_Ip_GetbyPoolModem();
            cboPoolIp.Properties.DataSource = dtip;
            cboPoolIp.Properties.DisplayMember = "PoolIp";
            cboPoolIp.Properties.ValueMember = "PoolIp";

        }
        void NW_Dhcp_Ip_GetbyPoolModem_MySQL()
        {
            string sql = "select * from NW_Dhcp_Ip where Name like '%Modem%'";
            DataTable dtip = Class.MySqlConnect.ExecQuery(sql);
            cboPoolIp.Properties.DataSource = dtip;
            cboPoolIp.Properties.DisplayMember = "PoolIp";
            cboPoolIp.Properties.ValueMember = "PoolIp";

        }
        private void call_info(string Form_name, string code)
        {
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            cls.IpAddress = code;
            DataTable dt = cls.NW_Dhcp_Customer_GetbyIp_MySQL();
            txtMacAddress.Text = dt.Rows[0]["MacAddress"].ToString();
            cboPoolIp.EditValue = dt.Rows[0]["PoolIp"].ToString();
            txtIpAddress.Text = dt.Rows[0]["IpAddress"].ToString();
            txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
            txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
            txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            cboBootfile.Text = dt.Rows[0]["Bootfile"].ToString();
            txtLocation.Text = dt.Rows[0]["Location"].ToString();
            txtNote.Text = dt.Rows[0]["Note"].ToString();
            txtIpAddress.Enabled = false;
            cboPoolIp.Enabled = false;
        }
        void call_Code_New()
        {
            txtMacAddress.Text = "";
            txtIpAddress.Text = "";
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            cboBootfile.Text = "";
            txtLocation.Text = "";
            txtNote.Text = "";
            cboBootfile.Text = cboBootfile.Properties.Items[0].ToString();
            txtMacAddress.Focus();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboPoolIp.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtMacAddress.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }

            if (txtIpAddress.Text.Length < 5)
            {
                MessageBox.Show("Địa chỉ IP Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMacAddress.Text.Length != 17)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            cls.MacAddress = txtMacAddress.Text;
            string mac = txtMacAddress.Text;
            mac = mac.Replace(":", "");
            mac = mac.Insert(4, ".");
            mac = mac.Insert(9, ".");
            cls.MacAddress_CMTS= mac;
            cls.IpAddress = txtIpAddress.Text;
            cls.PoolIp = cboPoolIp.EditValue.ToString();
            cls.CustomerCode = txtCustomerCode.Text;
            cls.CustomerName = txtCustomerName.Text;
            cls.CustomerAddress = txtCustomerAddress.Text;
            cls.Bootfile = cboBootfile.EditValue.ToString();
            cls.Location = txtLocation.Text;
            cls.Note = txtNote.Text;

            cls.IpPublic = "";
            cls.PoolPublic = "";
            cls.MacPc = "";
            if (txtIpAddress.Enabled)
            {
                if (cls.InsertMySQL())
                {
                    Class.App.SaveSuccessfully();
                    add_edit = true;
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }

            }
            else
            {
                if (cls.UpdateMySQL())
                {
                    Class.App.SaveSuccessfully();
                    add_edit = true;
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }

            }
            this.Close();

        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (cboPoolIp.EditValue == null)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtMacAddress.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtIpAddress.Text.Length < 5)
            {
                MessageBox.Show("Địa chỉ IP Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMacAddress.Text.Length != 17)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            cls.MacAddress = txtMacAddress.Text;
            string mac = txtMacAddress.Text;
            mac = mac.Replace(":", "");
            mac = mac.Insert(4, ".");
            mac = mac.Insert(9, ".");
            cls.MacAddress_CMTS = mac;
            cls.IpAddress = txtIpAddress.Text;
            cls.PoolIp = cboPoolIp.EditValue.ToString();
            cls.CustomerCode = txtCustomerCode.Text;
            cls.CustomerName = txtCustomerName.Text;
            cls.CustomerAddress = txtCustomerAddress.Text;
            cls.Bootfile = cboBootfile.EditValue.ToString();
            cls.Location = txtLocation.Text;
            cls.Note = txtNote.Text;

            cls.IpPublic = "";
            cls.PoolPublic = "";
            cls.MacPc = "";
            if (txtIpAddress.Enabled)
            {
                if (cls.InsertMySQL())
                {
                    Class.App.SaveSuccessfully();
                    add_edit = true;
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            else
            {
                if (cls.UpdateMySQL())
                {
                    Class.App.SaveSuccessfully();
                    add_edit = true;
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            
            txtIpAddress.Enabled = true;
            cboPoolIp.Enabled = true;
            call_Code_New();
            //NW_Dhcp_Ip_GetbyPoolModem();
            NW_Dhcp_Ip_GetbyPoolModem_MySQL();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPoolIp_EditValueChanged(object sender, EventArgs e)
        {
            Class.NW_Dhcp_Ip cls = new Class.NW_Dhcp_Ip();
            Class.NW_Dhcp_Customer clscus = new Class.NW_Dhcp_Customer();
            clscus.PoolIp = cboPoolIp.EditValue.ToString();
            DataTable dtcus = clscus.NW_Dhcp_Customer_GetbyPool_MySQL();
            cls.PoolIp = cboPoolIp.EditValue.ToString();
            DataTable dt = cls.NW_Dhcp_Ip_GetIPbyPool();
            string ip = "";
            bool check = false; ;
            if (dt.Rows.Count > 0)
            {
                string range=dt.Rows[0]["Range"].ToString();
                string[] cat = range.Split(' ');
                if (cat.Length > 1)
                {
                    txtIpAddress.Properties.Items.Clear();
                    string[]temp=cat[0].Split('.');
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

                    for (int i=start; i < end; i++)
                    {
                         ip = temp[0] + "." + temp[1] + "." + temp[2] + "." + i.ToString();
                        check = false;
                        for(int j=0;j<dtcus.Rows.Count;j++)
                        {
                            if (ip == dtcus.Rows[j]["IpAddress"].ToString())
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
            if (txtIpAddress.Enabled)
            {
                Class.NW_Dhcp_Customer clscus = new Class.NW_Dhcp_Customer();
                clscus.MacAddress = txtMacAddress.Text;
                DataTable dt = clscus.NW_Dhcp_Customer_GetbyMacaddress_MySQL();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(" Mac Address đã có, vui lòng chọn mac khác ! ");
                    txtMacAddress.Focus();
                }
            }
           
        }

       
    }
}