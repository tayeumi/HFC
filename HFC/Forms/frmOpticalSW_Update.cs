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
    public partial class frmOpticalSW_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmOpticalSW_Update()
        {
            InitializeComponent();
        }
        bool add = true;
        int id = 0;
        public frmOpticalSW_Update(bool Add_new, string Caption_name, string Form_name, int Code)
        {
            InitializeComponent();
            this.Text = Caption_name;
            add = Add_new;
            id = Code;
            if (add)
            {
               // txtCode.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
               // txtCode.Enabled = false;
            }
        }
        private void call_info(string Form_name, int code)
        {
            Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
            cls.ID = code;
            DataTable dt = cls.NW_OpticalSW_Get();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtIpAddress.Text = dt.Rows[0]["IpAddress"].ToString();           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (add)
            {
                Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
                cls.Name = txtName.Text;
                cls.IpAddress = txtIpAddress.Text;
                if (cls.Insert())
                {
                    MessageBox.Show("Thêm thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }

            }
            else
            {
                Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
                cls.ID = id;
                cls.Name = txtName.Text;
                cls.IpAddress = txtIpAddress.Text;
                if (cls.Update())
                {
                    MessageBox.Show("Cập nhật thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhậtthất bại !");
                }

            }

        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (add)
            {
                Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
                cls.Name = txtName.Text;
                cls.IpAddress = txtIpAddress.Text;
                if (cls.Insert())
                {
                    MessageBox.Show("Thêm thành công !");
                    txtName.Text = "";
                    txtIpAddress.Text = "";
                    add = true;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !");
                }

            }
            else
            {
                Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
                cls.ID = id;
                cls.Name = txtName.Text;
                cls.IpAddress = txtIpAddress.Text;
                if (cls.Update())
                {
                    MessageBox.Show("Cập nhật thành công !");
                    txtIpAddress.Text = "";
                    txtName.Text = "";
                    add = true;
                }
                else
                {
                    MessageBox.Show("Cập nhậtthất bại !");
                }
            }
        }
    }
}