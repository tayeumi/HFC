using System;
using System.Data;
using System.Windows.Forms;

namespace HFC
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string taikhoan = "";
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length < 1)
            {
                MessageBox.Show(" Chưa nhập đủ thông tin ");
                return;
            }            
            if (txtTaiKhoan.Text == "admin"& txtMatkhau.Text=="1111")
            {
                // MessageBox.Show(" Đăng nhập thành công !");
                taikhoan = txtTaiKhoan.Text;
                Class.App.client_User = txtTaiKhoan.Text;
                if (checkLuuPass.Checked)
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", txtTaiKhoan.Text);
                }
                else
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", "");

                }
                
                this.Close();
            }
            if (txtTaiKhoan.Text == "user" & txtMatkhau.Text == "user")
            {
                // MessageBox.Show(" Đăng nhập thành công !");
                taikhoan = txtTaiKhoan.Text;
                Class.App.client_User = txtTaiKhoan.Text;
                if (checkLuuPass.Checked)
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", txtTaiKhoan.Text);
                }
                else
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", "");

                }
                this.Close();
            }
                if (txtTaiKhoan.Text == "super" & txtMatkhau.Text == "super")
            {
                // MessageBox.Show(" Đăng nhập thành công !");
                taikhoan = txtTaiKhoan.Text;
                Class.App.client_User = txtTaiKhoan.Text;
                if (checkLuuPass.Checked)
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", txtTaiKhoan.Text);
                }
                else
                {
                    Class.RegistryWriter rg = new Class.RegistryWriter();
                    rg.WriteKey("user_client", "");

                }

                this.Close();
            }
                if (txtTaiKhoan.Text == "lapmoi" & txtMatkhau.Text == "lapmoilapmoi")
                {
                    // MessageBox.Show(" Đăng nhập thành công !");
                    taikhoan = txtTaiKhoan.Text;
                    Class.App.client_User = txtTaiKhoan.Text;
                    if (checkLuuPass.Checked)
                    {
                        Class.RegistryWriter rg = new Class.RegistryWriter();
                        rg.WriteKey("user_client", txtTaiKhoan.Text);
                    }
                    else
                    {
                        Class.RegistryWriter rg = new Class.RegistryWriter();
                        rg.WriteKey("user_client", "");

                    }

                    this.Close();
                }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            Class.RegistryWriter rg = new Class.RegistryWriter();
            string user = rg.valuekey("user_client");
            if (user != "Blue" & user != "")
            {
                txtTaiKhoan.Text = user;
                checkLuuPass.Checked = true;
            }
            else
            {
                txtTaiKhoan.Text = "";
                checkLuuPass.Checked = false;
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (taikhoan == "")
            {
                Application.Exit();
            }
        }

            
    }
}