using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SnmpSharpNet;
using System.Net;

namespace HFC.Class
{
    class NW_InterfaceGauge
    {
        public string _community = "ptanh";
        public string _ipHost = "101.99.28.129";

        public DataTable NW_InterfaceGauge_Getlist()
        {
            string procname = "NW_InterfaceGauge_Getlist";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }

        public void GetInfoOID(DataTable dtInterfaceGauge,out DataTable dt)
        {
            dt = dtInterfaceGauge.Copy();
            if (dtInterfaceGauge.Rows.Count > 0)
            {
                // SNMP community name
                OctetString community = new OctetString(_community);

                // Define agent parameters class
                AgentParameters param = new AgentParameters(community);
                // Set SNMP version to 1 (or 2)
                param.Version = SnmpVersion.Ver1;
                // Construct the agent address object
                // IpAddress class is easy to use here because
                //  it will try to resolve constructor parameter if it doesn't
                //  parse to an IP address
                IpAddress agent = new IpAddress(_ipHost);

                // Construct target
                UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

                // Pdu class used for all requests
                Pdu pdu = new Pdu(PduType.Get);

                for (int i = 0; i < dtInterfaceGauge.Rows.Count; i++)
                {
                    pdu.VbList.Add(dtInterfaceGauge.Rows[i]["OIDIn"].ToString());
                    pdu.VbList.Add(dtInterfaceGauge.Rows[i]["OIDOut"].ToString());                  
                }
                // Make SNMP request
                SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

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
                    }
                    else
                    {
                        // Reply variables are returned in the same order as they were added
                        //  to the VbList                   
                        // MessageBox.Show(result.Pdu.VbList[0].Oid.ToString() + " (" + SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type) + ") " + result.Pdu.VbList[0].Value.ToString());                        

                        for (int i = 0; i < dtInterfaceGauge.Rows.Count; i++)
                        {
                            dtInterfaceGauge.Rows[i]["InBandwidth"] = result.Pdu.VbList[i+i].Value.ToString();
                            dtInterfaceGauge.Rows[i]["OutBandwidth"] = result.Pdu.VbList[i+i+1].Value.ToString();
                        }
                        dt = dtInterfaceGauge;
                    }
                }
                else
                {
                    Console.WriteLine("No response received from SNMP agent.");
                }
                target.Close();
            }
        }
    }
}
