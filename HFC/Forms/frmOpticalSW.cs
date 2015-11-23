using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SnmpSharpNet;
using System.Net;

namespace HFC.Forms
{
    public partial class frmOpticalSW : DevExpress.XtraEditors.XtraForm
    {
        public frmOpticalSW()
        {
            InitializeComponent();
        }

        private void frmOpticalSW_Load(object sender, EventArgs e)
        {
            NW_OpticalSW_Getlist();
        }
        DataTable dt = new DataTable();
        void NW_OpticalSW_Getlist()
        {
            Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
            dt = cls.NW_OpticalSW_Getlist();
            gridItem.DataSource = dt;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOpticalSW_Update frm = new frmOpticalSW_Update(true, "Thêm Address", null, -1);
            frm.Owner = this;
            frm.ShowDialog();
            NW_OpticalSW_Getlist();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {               
                int _value = int.Parse(gridItemDetail.GetFocusedRowCellValue(colID).ToString());

                frmOpticalSW_Update frm = new frmOpticalSW_Update(false, "Cập nhật Address", "CV", _value);
                frm.Owner = this;
                frm.ShowDialog();
                NW_OpticalSW_Getlist();
            }
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                int _value = int.Parse(drow["ID"].ToString());               

                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.NW_OpticalSW cls = new Class.NW_OpticalSW();
                cls.ID = _value;
                if (cls.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    NW_OpticalSW_Getlist();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                string IP = "";
                float valuea;
                float valueb;
                string status="";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IP = dt.Rows[i]["IpAddress"].ToString();
                    dt.Rows[i]["Status"] = "Connecting";
                    getSNMP(IP, out valuea, out valueb,out status);
                    if (valuea != 0)
                    {
                        dt.Rows[i]["ValueA"] = valuea;
                        dt.Rows[i]["ValueB"] = valueb;                       
                    }
                    dt.Rows[i]["Status"] = status;
                }
            }
        }


        void getSNMP(string ip,out float ValueA,out float ValueB,out string Status)
        {            
                ValueA = 0;
                ValueB = 0;
                Status = "";
                // SNMP community name
                OctetString community = new OctetString("PUBLIC");

                // Define agent parameters class
                AgentParameters param = new AgentParameters(community);
                // Set SNMP version to 1 (or 2)
                param.Version = SnmpVersion.Ver1;

                IpAddress agent = new IpAddress(ip);

                // Construct target
                UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

                // Pdu class used for all requests
                Pdu pdu = new Pdu(PduType.Get);
                pdu.VbList.Add("1.3.6.1.4.1.33826.1.1.5.1.2.1"); //a
                pdu.VbList.Add("1.3.6.1.4.1.33826.1.1.5.1.2.2"); //b  
                Application.DoEvents();
                // Make SNMP request
            try{
                    SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);
                    Application.DoEvents();
                    // If result is null then agent didn't reply or we couldn't parse the reply.
                    if (result != null)
                    {
                        // ErrorStatus other then 0 is an error returned by 
                        // the Agent - see SnmpConstants for error definitions
                        if (result.Pdu.ErrorStatus != 0)
                        {
                            // agent reported an error with the request
                            Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                                result.Pdu.ErrorStatus,
                                result.Pdu.ErrorIndex);
                            Status = "false";
                        }
                        else
                        {
                            // Reply variables are returned in the same order as they were added
                            //  to the VbList                   
                            //  MessageBox.Show(result.Pdu.VbList[0].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) + ") " + result.Pdu.VbList[0].Value.ToString());
                            //   MessageBox.Show(result.Pdu.VbList[1].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[1].Value.Type) + ") " + result.Pdu.VbList[1].Value.ToString());
                            //  MessageBox.Show(result.Pdu.VbList[2].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[2].Value.Type) + ") " + result.Pdu.VbList[2].Value.ToString());
                            ValueA = float.Parse(result.Pdu.VbList[0].Value.ToString()) / 10;
                            ValueB = float.Parse(result.Pdu.VbList[1].Value.ToString()) / 10;
                            Status = "done";
                        }
                    }
                    else
                    {
                        Console.WriteLine("No response received from SNMP agent.");
                    }
                    target.Close();

                }
                catch
                {                  
                    Status = "false";
                }
              }
           
        
    }
}