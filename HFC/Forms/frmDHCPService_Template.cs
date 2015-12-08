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
    public partial class frmDHCPService_Template : DevExpress.XtraEditors.XtraForm
    {
        public frmDHCPService_Template()
        {
            InitializeComponent();  
        }
        string file = "";
        string txt = "";
        public frmDHCPService_Template(string _file)
        {
            InitializeComponent();
            file = _file;    
            if (System.IO.File.Exists(file))
                txtDHCP.Lines = System.IO.File.ReadAllLines(file);
            txt = txtDHCP.Text;
        }
        public static DialogResult ConfirmChangedData()
        {
            return MessageBox.Show("Dữ liệu đã thay đổi, bạn có muốn lưu hay không ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void frmDHCPService_Template_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt != txtDHCP.Text)
            {
                if (DialogResult.Yes == ConfirmChangedData())
                {
                    ////
                    try
                    {
                        System.IO.File.WriteAllLines(file, txtDHCP.Lines);
                    }catch{

                        MessageBox.Show("Luu File loi");
                    }
                   
                }
            }
        }
    }
}