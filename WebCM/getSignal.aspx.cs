using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SnmpSharpNet;
using System.Net;

namespace WebCM
{
    public partial class getSignal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       static string _Ip { get; set; }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            _Ip = "";
            if (txtMac.Text.Length > 3)
            {
                NW_SignalLog cls = new NW_SignalLog();
                cls.MacAddress = txtMac.Text;
                DataTable dt = cls.NW_SignalLog_5Day_GetByMacLike();
                if (dt.Rows.Count > 0)
                {
                    gridItem.DataSource = dt;
                    gridItem.DataBind();

                    _Ip = dt.Rows[0]["IpPrivate"].ToString();
                    if (dt.Rows.Count > 0)
                        btnReset.Visible = true;
                    else
                        btnReset.Visible = false;
                }
            }
        }

        protected void gridItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // you already know you're looking at this row, so check your cell text
                string tt = e.Row.Cells[7].Text.Trim();
                string _phat = e.Row.Cells[5].Text.Trim();
                int phy = 0;
                float phat = 0;
                float.TryParse(_phat, out phat);
                int.TryParse(tt, out phy);
                if (phy < 210)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                if (phat > 53.0)
                {
                    e.Row.BackColor = System.Drawing.Color.LawnGreen;
                }

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string IP = _Ip;
            try
            {                
                    if (IP.Trim() != "")
                    {
                        if (IP.Trim() != "0.0.0.0")
                        {
                            UdpTarget target = new UdpTarget((IPAddress)new IpAddress(IP));
                            // Create a SET PDU
                            Pdu pdu = new Pdu(PduType.Set);
                            // Set sysLocation.0 to a new string
                            // pdu.VbList.Add(new Oid("1.3.6.1.2.1.1.6.0"), new OctetString("Some other value"));
                            // Set a value to integer
                            pdu.VbList.Add(new Oid(".1.3.6.1.2.1.69.1.1.3.0"), new Integer32(1));
                            // Set a value to unsigned integer
                            //   pdu.VbList.Add(new Oid("1.3.6.1.2.1.67.1.1.1.1.6.0"), new UInteger32(101));
                            // Set Agent security parameters
                            AgentParameters aparam = new AgentParameters(SnmpVersion.Ver2, new OctetString("LBC"));
                            // Response packet
                            SnmpV2Packet response;
                            try
                            {
                                // Send request and wait for response
                                response = target.Request(pdu, aparam) as SnmpV2Packet;
                            }
                            catch (Exception ex)
                            {
                                // If exception happens, it will be returned here
                                Console.WriteLine(String.Format("Request failed with exception: {0}", ex.Message));
                                target.Close();
                                return;
                            }
                            // Make sure we received a response
                            if (response == null)
                            {
                                Console.WriteLine("Error in sending SNMP request.");
                            }
                            else
                            {
                                // Check if we received an SNMP error from the agent
                                if (response.Pdu.ErrorStatus != 0)
                                {
                                    Console.WriteLine(String.Format("SNMP agent returned ErrorStatus {0} on index {1}",
                                      response.Pdu.ErrorStatus, response.Pdu.ErrorIndex));
                                }
                                else
                                {
                                    // Everything is ok. Agent will return the new value for the OID we changed
                                    Console.WriteLine(String.Format("Agent response {0}: {1}",
                                      response.Pdu[0].Oid.ToString(), response.Pdu[0].Value.ToString()));
                                }
                            }

                        }
                    }

                    Response.Write("<script>alert('Reset Modem OK !')</script>");
                
            }
            catch { Response.Write("<script>alert('Chưa reset được Modem. Có thể modem đang offline !')</script>"); }
        }
    }
}