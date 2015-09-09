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
    public partial class frmNodeList_Update : DevExpress.XtraEditors.XtraForm
    {
        public frmNodeList_Update()
        {
            InitializeComponent();
        }
        public frmNodeList_Update(bool Add_new, string Caption_name, string Form_name, string Code)
        {
            InitializeComponent();

            this.Text = Caption_name;
            if (Add_new)
            {
                txtCode.Text = call_Code_New();
            }
            else
            {
                call_info(Form_name, Code);
                txtCode.Enabled = false;
            }
        }

        private string call_Code_New()
        {
            Class.NW_Node cls = new Class.NW_Node();
            return cls.GetNewCode();
        }
        private void call_info(string Form_name, string code)
        {
            Class.NW_Node cls = new Class.NW_Node();
            cls.NodeCode = code;
            DataTable dt = cls.NW_Node_Get();
            txtCode.Text = dt.Rows[0]["NodeCode"].ToString();
            txtName.Text = dt.Rows[0]["NodeName"].ToString();
            txtGroup.Text = dt.Rows[0]["NodeGroup"].ToString();         
            txtDescription.Text = dt.Rows[0]["Description"].ToString();            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.NW_Node cls = new Class.NW_Node();
            cls.NodeCode = txtCode.Text;
            cls.NodeName = txtName.Text;
            cls.NodeGroup = txtGroup.Text;
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
            else
            {
                if (cls.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmNodeList).NW_Node_GetList();
            this.Close();
        }

        private void btnUpdateNew_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length < 1)
            {
                Class.App.InputNotAccess();
                return;
            }
            Class.NW_Node cls = new Class.NW_Node();
            cls.NodeCode = txtCode.Text;
            cls.NodeName = txtName.Text;
            cls.NodeGroup = txtGroup.Text;
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
            else
            {
                if (cls.Update())
                {
                    Class.App.SaveSuccessfully();
                }
                else
                {
                    Class.App.SaveNotSuccessfully();
                }
            }
            (this.Owner as frmNodeList).NW_Node_GetList();
            txtCode.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            this.Text = "Thêm Node";
            txtCode.Text = call_Code_New();

        }      

    }
}