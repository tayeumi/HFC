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
    public partial class frmDeviceList_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmDeviceList_Update()
        {
            InitializeComponent();
        }
        string _NodeCode;
        public frmDeviceList_Update(bool Add_new, string Caption_name, string NodeCode, string Code)
        {
            InitializeComponent();
            _NodeCode = NodeCode;
            this.Text = Caption_name;
            if (Add_new)
            {
                txtCode.Text = "";
            }
            else
            {
               //// call_info(Form_name, Code);
               // txtCode.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }

            if (txtCode.Text.Length != 14)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] kt = txtCode.Text.Split('.');
            if (kt.Length != 3)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            Class.NW_Device cls = new Class.NW_Device();           
            cls.MacAddress = txtCode.Text;
            cls.NodeCode = _NodeCode;
            cls.Description = txtDescription.Text;
            if (txtCode.Enabled == true)
            {
                if (cls.Insert())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            //else
            //{
            //    if (cls.Update())
            //    {
            //        Class.App.SaveSuccessfully();
            //    }
            //    else
            //    {
            //        Class.App.SaveNotSuccessfully();
            //    }
            //}
           (this.Owner as frmDeviceList).NW_Device_GetByNodeCode();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            if (txtCode.Text.Length != 14)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] kt = txtCode.Text.Split('.');
            if (kt.Length != 3)
            {
                MessageBox.Show("Địa chỉ Mac Address chưa đúng định dạng, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Class.NW_Device cls = new Class.NW_Device();
            cls.MacAddress = txtCode.Text;
            cls.NodeCode = _NodeCode;
            cls.Description = txtDescription.Text;
            if (txtCode.Enabled == true)
            {
                if (cls.Insert())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmDeviceList).NW_Device_GetByNodeCode();
            txtCode.Text = "";
            txtDescription.Text = "";
        }
    }
}