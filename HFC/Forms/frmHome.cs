using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;

namespace HFC.Forms
{
    public partial class frmHome : DevExpress.XtraEditors.XtraForm
    {
        public frmHome()
        {
            InitializeComponent();
        }
        void Load24h(int load)
        {
            Class.NW_Device_Status cl = new Class.NW_Device_Status();
            DataTable dt = new DataTable();
            if (load == 0) { dt = cl.NW_Device_Status_Get24h(); } else { dt = cl.NW_Device_Status_GetList(); }
               
               
            
                Series Modems = new Series("Modem", ViewType.SplineArea);
                Series PCs = new Series("PCs ", ViewType.SplineArea);
                Series I0 = new Series("Card 0/0", ViewType.Line);
                Series I1 = new Series("Card 1/0", ViewType.Line);
                Series I2 = new Series("Card 2/0", ViewType.Line);
                Series I3 = new Series("Card 3/0", ViewType.Line);
                Series I4 = new Series("Card 4/0", ViewType.Line);
                Series I5 = new Series("Card 5/0", ViewType.Line);
                Series I9 = new Series("Card 9/0", ViewType.Line);
                Series I10 = new Series("Card 10/0", ViewType.Line);
                Series I11 = new Series("Card 11/0", ViewType.Line);
                I0.Points.Clear();
                I1.Points.Clear();
                I2.Points.Clear();
                I3.Points.Clear();
                I4.Points.Clear();
                I5.Points.Clear();
                I9.Points.Clear();
                I10.Points.Clear();
                I11.Points.Clear();

                Modems.Points.Clear();
                PCs.Points.Clear();
                chartDevicePC.Series.Clear();
                chartInterface.Series.Clear();

                chartDevicePC1.Series.Clear();
                chartInterface1.Series.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   if(dt.Rows[i]["Interface"].ToString()=="Totals"){
                    Modems.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                    Modems.LegendText = "Modems: " + dt.Rows[i]["Modems"].ToString();
                    PCs.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Hosts"].ToString()));
                    PCs.LegendText = "PCs: " + dt.Rows[i]["Hosts"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 0/0")
                   {
                       I0.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I0.LegendText = "Cable 0/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 1/0")
                   {
                       I1.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I1.LegendText = "Cable 1/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 2/0")
                   {
                       I2.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I2.LegendText = "Cable 2/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 3/0")
                   {
                       I3.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I3.LegendText = "Cable 3/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 4/0")
                   {
                       I4.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I4.LegendText = "Cable 4/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 5/0")
                   {
                       I5.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I5.LegendText = "Cable 5/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 9/0")
                   {
                       I9.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I9.LegendText = "Cable 9/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 10/0")
                   {
                       I10.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I10.LegendText = "Cable 10/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                   if (dt.Rows[i]["Interface"].ToString() == "Cable 11/0")
                   {
                       I11.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HH"), dt.Rows[i]["Modems"].ToString()));
                       I11.LegendText = "Cable 11/0: " + dt.Rows[i]["Modems"].ToString();
                   }
                                       
                }
                Modems.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                PCs.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I0.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I9.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I10.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                I11.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            
                chartDevicePC.Series.AddRange(new Series[] { Modems });
                chartDevicePC1.Series.AddRange(new Series[] { PCs });
                chartInterface1.Series.AddRange(new Series[] { I0,I1, I2, I3 });
                chartInterface.Series.AddRange(new Series[] {  I4, I5, I9, I10, I11 });
            


        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            Load24h(0);
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.SelectedIndex == 0)
            {
                Load24h(0);
            }
            else
            {
                Load24h(1);
            }
        }
    }
}