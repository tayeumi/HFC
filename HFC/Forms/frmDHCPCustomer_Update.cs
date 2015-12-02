using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HFC.Forms
{
    public partial class frmDHCPCustomer_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPCustomer_Update()
        {
            InitializeComponent();
        }
        public frmDHCPCustomer_Update(bool Add_new, string Caption_name, string Form_name, string Code)
        {
            InitializeComponent();
            this.Text = Caption_name;
            if (Add_new)
            {
                call_Code_New();
            }
            else
            {
                //call_info(Form_name, Code);
               // txtCode.Enabled = false;
            }
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

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMacAddress.Text.Length < 1)
            {
                Class.App.InputNotAccess();
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
            if (cls.Insert())
            {
                Class.App.SaveSuccessfully();
                this.Close();
            }
            else
            {
                Class.App.SaveNotSuccessfully();
            }

        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}