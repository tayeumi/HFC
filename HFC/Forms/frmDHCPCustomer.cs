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
        DataTable dtIpPublic = new DataTable();
        public void NW_Dhcp_Customer_Getlist()
        {
          //  Waiting.ShowWaitForm();
           // Waiting.SetWaitFormDescription("Đang tải thông tin khách hàng");
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            dt = cls.NW_Dhcp_Customer_Getlist();
            dtIpPublic = cls.NW_Dhcp_Customer_Getlist();
            gridItem.DataSource = dt;
         //   Waiting.CloseWaitForm();
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
            dtIpPublic.Rows.Clear();
            if (txtLink.Text.Length > 3)
            {
               string[] lines = System.IO.File.ReadAllLines(txtLink.Text);
             // string txtt = System.IO.File.ReadAllText(txtLink.Text);
               DataRow dr;
               DataRow drpub;
               string mac = "";
               string ip = "";
               string bootfile = "";
               string code = "";
               string name = "";
               string macCMTS = "";
               string pool = "";
               string poolpublic = "";
               string[] temp = null;
               string macpc = "";
               string ippublic = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    #region doc IP khach hang
                    if (lines[i].ToString().Trim().StartsWith("#  192.168."))
                    {
                        if (lines[i + 8].ToString().Trim() == "}")
                        {
                            if (lines[i - 8].ToString().Trim().StartsWith("subnet"))
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
                    #endregion

                    #region Doc IP Public
                    if (lines[i].ToString().Trim().StartsWith("# PC an Modem"))
                    {
                        if (lines[i-9].ToString().Trim().StartsWith("subnet"))
                        {
                            poolpublic = lines[i - 9].ToString().Trim();
                            temp = poolpublic.Split(' ');
                            if(temp.Length>2)
                                poolpublic=temp[1];
                        }

                        if (lines[i +6].ToString().Trim()=="}")
                        {
                            macpc = lines[i + 2].ToString().Trim();
                            temp = macpc.Split(' ');
                            if (temp.Length > 2)
                                macpc = temp[2];

                            ippublic = lines[i + 3].ToString().Trim();
                            temp = ippublic.Split(' ');
                            if (temp.Length > 1)
                                ippublic = temp[1];
                            ippublic = ippublic.Replace(";", "");

                            ip = lines[i].ToString().Trim();
                            temp = ip.Split(' ');
                            if (temp.Length > 4)
                                ip = temp[4];

                            // add datatable
                            drpub = dtIpPublic.NewRow();
                            drpub["IpAddress"] = ip;
                            drpub["PoolPublic"] = poolpublic;
                            drpub["MacPc"] = macpc;
                            drpub["IpPublic"] = ippublic;
                            drpub["Note"] = temp[5];
                            int t=0;
                            int bien = 0;
                            string note = "";
                            for (int n = 0; n < temp.Length; n++)
                            {
                                if (temp[n] == "Kunde")
                                {
                                    bien = n;
                                }
                            }
                            for (t = 5; t < bien; t++)
                            {
                                note += temp[t] + " ";
                            }
                            drpub["Note"] =note;
                            dtIpPublic.Rows.Add(drpub);
                        }

                    }
                    #endregion
                }
              
            }
            if (dt.Rows.Count > 0)
                btnImport.Enabled = true;
            else
                btnImport.Enabled = false;

            // merge 2 data
            DataRow[] result = null;
            string txt = ""; ;
            if (dt.Rows.Count > 0)
            {
                if (dtIpPublic.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txt = dt.Rows[i]["IpAddress"].ToString();
                        result = dtIpPublic.Select("IpAddress ='" + txt + "'");
                        foreach (DataRow row in result)
                        {
                            dt.Rows[i]["PoolPublic"] = row["PoolPublic"].ToString();
                            dt.Rows[i]["MacPc"] = row["MacPc"].ToString();
                            dt.Rows[i]["IpPublic"] = row["IpPublic"].ToString();
                            dt.Rows[i]["Note"] = row["Note"].ToString();  
                        }
                    }
                }

            }
            //gridItem.DataSource = dtIpPublic;

        }

        private void frmDHCPCustomer_Load(object sender, EventArgs e)
        {
            NW_Dhcp_Customer_Getlist();
            //if (dt.Rows.Count > 0)
            //{
            //    groupImport.Enabled = false; 

            //}
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                Waiting.ShowWaitForm();
                Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
                string fail = "";
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    Application.DoEvents();
                    Waiting.SetWaitFormDescription("Đang lưu ...("+(i+1).ToString()+")");
                    cls.IpAddress = dt.Rows[i]["IpAddress"].ToString();
                    cls.MacAddress = dt.Rows[i]["MacAddress"].ToString();
                    cls.MacAddress_CMTS = dt.Rows[i]["MacAddress_CMTS"].ToString();
                    cls.CustomerCode = dt.Rows[i]["CustomerCode"].ToString();
                    cls.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                    cls.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                    cls.PoolIp = dt.Rows[i]["PoolIp"].ToString();
                    cls.Bootfile = dt.Rows[i]["Bootfile"].ToString();
                    cls.IpPublic = dt.Rows[i]["IpPublic"].ToString();
                    cls.MacPc = dt.Rows[i]["MacPc"].ToString();
                    cls.PoolPublic = dt.Rows[i]["PoolPublic"].ToString();
                    cls.Location = dt.Rows[i]["Location"].ToString();
                    cls.Note = dt.Rows[i]["Note"].ToString();
                    //if (cls.IpAddress == "192.168.11.63")
                    //{
                    //    string degug = "";
                    //}
                    if (!cls.Insert())
                    {
                        fail += "\r\n" + dt.Rows[i]["IpAddress"].ToString();
                    }

                }
                Waiting.CloseWaitForm();
                //MessageBox.Show("Hoàn thành Insert !");
                //MessageBox.Show(fail);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
           if (cls.NW_Dhcp_Customer_DeleteAll())
               MessageBox.Show("Đã xóa xong! ");

        }

        private void btnCountIP_Click(object sender, EventArgs e)
        {
            Waiting.ShowWaitForm();
            DataRow[] rows;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Waiting.SetWaitFormDescription("Dòng "+(i+1).ToString());
                Application.DoEvents();
                rows = dt.Select("IpAddress='"+dt.Rows[i]["IpAddress"].ToString()+"'");
               // rows = dt.Select("MacAddress='" + dt.Rows[i]["MacAddress"].ToString() + "'");
                dt.Rows[i]["Note"] = rows.Length;
            }
            Waiting.CloseWaitForm();
        }

        private void btnCreateDHCPFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (System.IO.File.Exists(@"dhcpd.conf.temp"))
                    {
                        string txt = System.IO.File.ReadAllText(@"dhcpd.conf.temp");
                        string CPEDynamic = "";
                        string CPEStatic = "";
                        string PoolModem = "";
                        Class.NW_Dhcp_Ip clsIP = new Class.NW_Dhcp_Ip();
                        Class.NW_Dhcp_Customer clsModem = new Class.NW_Dhcp_Customer();
                        DataTable dtCPEDynamic = clsIP.NW_Dhcp_Ip_GetbyCPEDynamic();
                        DataTable dtCPEStatic = clsIP.NW_Dhcp_Ip_GetbyCPEStatic();
                        DataTable dtPoolModem = clsIP.NW_Dhcp_Ip_GetbyPoolModem();
                        #region CPEDynamic
                        for (int i = 0; i < dtCPEDynamic.Rows.Count; i++)
                        {
                            CPEDynamic += "\tsubnet " + dtCPEDynamic.Rows[i]["PoolIp"].ToString() + " netmask " + dtCPEDynamic.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                            "\t\tauthoritative;\n" +
                                            "\t\toption subnet-mask " + dtCPEDynamic.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                            "\t\toption domain-name-servers " + dtCPEDynamic.Rows[i]["Dns"].ToString() + ";\n" +
                                            "\t\toption routers " + dtCPEDynamic.Rows[i]["Router"].ToString() + ";\n" +
                                            "\t\toption broadcast-address " + dtCPEDynamic.Rows[i]["Broadcast"].ToString() + ";\n" +
                                            "\t\tpool {\n" +
                                                "\t\trange " + dtCPEDynamic.Rows[i]["Range"].ToString() + ";\n" +
                                                "\t\t}\n" +
                                            "\t}\n" +
                                            "\tgroup {\n" +
                                                "\t\tuse-host-decl-names on;\n" +
                                            "\t}\n";
                        }
                        #endregion
                        #region CPEStatic
                        for (int i = 0; i < dtCPEStatic.Rows.Count; i++)
                        {
                            clsModem.PoolIp = dtCPEStatic.Rows[i]["PoolIp"].ToString();
                            DataTable dtmodem = clsModem.NW_Dhcp_Customer_GetbyPoolPublic();
                            string txtmodem = "";
                            for (int j = 0; j < dtmodem.Rows.Count; j++)
                            {
                                string ipcpe = dtmodem.Rows[j]["IpPublic"].ToString();
                                ipcpe = ipcpe.Replace(":", "-");
                                string reIPcpe = ipcpe.Replace(":", "");
                                txtmodem += "\t\t# PC an Modem " + dtmodem.Rows[j]["IpAddress"].ToString() + " " + dtmodem.Rows[j]["Note"].ToString() + " Kunde " + dtmodem.Rows[j]["CustomerCode"].ToString() + " " + dtmodem.Rows[j]["CustomerName"].ToString() + "\n" +
                                            "\t\thost " + ipcpe + " {\n" +
                                                "\t\t\thardware ethernet " + dtmodem.Rows[j]["MacPc"].ToString() + " ;\n" +
                                                "\t\t\tfixed-address " + dtmodem.Rows[j]["IpPublic"].ToString() + ";\n" +
                                                "\t\t\toption host-name 	\"mt" + reIPcpe + "\";\n" +
                                                "\t\t\tddns-hostname 	\"mt" + reIPcpe + "\";\n" +
                                            "\t\t}\n";
                            }

                            CPEStatic += "\tsubnet " + dtCPEStatic.Rows[i]["PoolIp"].ToString() + " netmask " + dtCPEStatic.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                        "\t\tauthoritative;\n" +
                                        "\t\toption subnet-mask " + dtCPEStatic.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                        "\t\toption domain-name-servers " + dtCPEStatic.Rows[i]["Dns"].ToString() + ";\n" +
                                        "\t\toption routers " + dtCPEStatic.Rows[i]["Router"].ToString() + ";\n" +
                                        "\t\toption broadcast-address " + dtCPEStatic.Rows[i]["Broadcast"].ToString() + ";\n" +
                                        "\t}\n" +
                                        "\tgroup {\n" +
                                            "\t\tuse-host-decl-names on;\n" +
                                            txtmodem +
                                        "\t}\n";
                        }
                        #endregion
                        #region CableMode
                        for (int i = 0; i < dtPoolModem.Rows.Count; i++)
                        {
                            clsModem.PoolIp = dtPoolModem.Rows[i]["PoolIp"].ToString();
                            DataTable dtmodem = clsModem.NW_Dhcp_Customer_GetbyPool();
                            string listmodem = "";
                            for (int j = 0; j < dtmodem.Rows.Count; j++)
                            {
                                string cm = dtmodem.Rows[j]["MacAddress"].ToString();
                                cm = cm.Replace(":", "");
                                listmodem += "\t\t#  " + dtmodem.Rows[j]["IpAddress"].ToString() + " Kunde " + dtmodem.Rows[j]["CustomerCode"].ToString() + " " + dtmodem.Rows[j]["CustomerName"].ToString() + "\n" +
                                                "\t\thost " + cm + " {\n" +
                                                "\t\t\thardware ethernet " + dtmodem.Rows[j]["MacAddress"].ToString() + " ; \n" +
                                                "\t\t\tfixed-address " + dtmodem.Rows[j]["IpAddress"].ToString() + ";\n" +
                                                "\t\t\toption host-name \"cm" + cm + "\";\n" +
                                                "\t\t\tddns-hostname  \"cm" + cm + "\";\n" +
                                                "\t\t\toption bootfile-name \"" + dtmodem.Rows[j]["Bootfile"].ToString() + "\";\n" +
                                                "\t\t\tfilename \"" + dtmodem.Rows[j]["Bootfile"].ToString() + "\";\n" +
                                                "\t\t}\n";
                            }
                            PoolModem += "\tsubnet " + dtPoolModem.Rows[i]["PoolIp"].ToString() + " netmask " + dtPoolModem.Rows[i]["SubnetMask"].ToString() + " {\n" +
                                        "\t\tauthoritative;\n" +
                                        "\t\toption subnet-mask " + dtPoolModem.Rows[i]["SubnetMask"].ToString() + ";\n" +
                                        "\t\toption routers " + dtPoolModem.Rows[i]["Router"].ToString() + ";\n" +
                                        "\t\toption broadcast-address " + dtPoolModem.Rows[i]["Broadcast"].ToString() + ";\n" +
                                        "\t}\n" +
                                        "\tgroup {\n" +
                                            "\t\tuse-host-decl-names on;\n" +
                                            listmodem +
                                         "\t}\n";

                        }
                        #endregion

                        txt = txt.Replace("<_CPEDynamic>", CPEDynamic);
                        txt = txt.Replace("<_CPEStatic>", CPEStatic);
                        txt = txt.Replace("<_modemip>", PoolModem);

                        System.IO.File.WriteAllText(@"dhcpd.conf", txt);
                    }
                    else
                    {
                        MessageBox.Show("file dhcpd.conf.temp not found!");
                    }
                }
                MessageBox.Show("Hoàn thành tạo file !");
            }
            catch {
                MessageBox.Show("Lỗi tạo file..");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {            
                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;
                    Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();               
                    string IP = "";
                    IP = gridItemDetail.GetFocusedRowCellValue(colIpAddress).ToString();  
                    cls.IpAddress = IP;
                    if (cls.NW_Dhcp_Customer_Delete())
                    {
                         Class.App.DeleteSuccessfully(IP);
                         NW_Dhcp_Customer_Getlist();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }      
                           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDHCPCustomer_Update frm = new frmDHCPCustomer_Update(true, "Thêm Modem ", null, null);
            frm.Owner = this;
            frm.ShowDialog();
            if (frm.add_edit)
            {
                NW_Dhcp_Customer_Getlist();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string code = gridItemDetail.GetFocusedRowCellValue(colIpAddress).ToString();
            frmDHCPCustomer_Update frm = new frmDHCPCustomer_Update(false, "Cập nhật Modem ", null, code);
            frm.Owner = this;
            frm.ShowDialog();
            if (frm.add_edit)
            {
                NW_Dhcp_Customer_Getlist();
            }
        }

       

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            string code = gridItemDetail.GetFocusedRowCellValue(colIpAddress).ToString();
            string cus = gridItemDetail.GetFocusedRowCellValue(colCustomerName).ToString();
            string note = gridItemDetail.GetFocusedRowCellValue(colNote).ToString();
            frmDHCPCustomer_StaticIP frm = new frmDHCPCustomer_StaticIP(code, "Cập nhật IP Wan [" + cus + "]",note);
            frm.Owner = this;
            frm.ShowDialog();
            if (frm.add_edit)
            {
                NW_Dhcp_Customer_Getlist();
            }
        }

        private void btnDelIP_Click(object sender, EventArgs e)
        {
            Class.NW_Dhcp_Customer cls = new Class.NW_Dhcp_Customer();
            cls.IpAddress = gridItemDetail.GetFocusedRowCellValue(colIpAddress).ToString();
            if (cls.NW_Dhcp_Customer_DeleteIPStatic())
            {
                MessageBox.Show("Xóa IP Static thành công !");
                NW_Dhcp_Customer_Getlist();
            }
            else
            {
                MessageBox.Show("Xóa IP Static thất bại !");

            }
        }
    }
}