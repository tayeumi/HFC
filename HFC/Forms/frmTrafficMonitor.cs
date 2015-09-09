
using System.Data;
using System;
using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Model;
namespace HFC.Forms
{
    public partial class frmTrafficMonitor : DevExpress.XtraEditors.XtraForm
    {
        public frmTrafficMonitor()
        {
            InitializeComponent();
        }
        DataTable dtTraffic = new DataTable();
        private void frmTrafficMonitor_Load(object sender, System.EventArgs e)
        {
           
            dtTraffic.Columns.Add("DateTime", typeof(DateTime));
            dtTraffic.Columns.Add("DS");
            dtTraffic.Columns.Add("US");
            dtTraffic.Columns.Add("CurrentDS");
            dtTraffic.Columns.Add("CurrentUS");

            arcScaleComponent1.EnableAnimation = true;
            arcScaleComponent1.EasingMode = EasingMode.EaseInOut;
            arcScaleComponent1.EasingFunction = new ElasticEase();

            arcScaleComponent2.EnableAnimation = true;
            arcScaleComponent2.EasingMode = EasingMode.EaseInOut;
            arcScaleComponent2.EasingFunction = new ElasticEase();

            arcScaleComponent3.EnableAnimation = true;
            arcScaleComponent3.EasingMode = EasingMode.EaseInOut;
            arcScaleComponent3.EasingFunction = new ElasticEase();

            arcScaleComponent4.EnableAnimation = true;
            arcScaleComponent4.EasingMode = EasingMode.EaseInOut;
            arcScaleComponent4.EasingFunction = new ElasticEase();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtMac.Text.Length!=14)
            {
                return;
            }
            btnStartOntime.Enabled = false;
            txtMac.Enabled = false;
            btnStart.Enabled = false;
            txtMac.Enabled = false;
            dtTraffic.Rows.Clear();
            this.Text = "Monitoring";
            timer1.Enabled = true;
            get();
            chart();
          
        }
        void get()
        {
            Class.CMTS cmts = new Class.CMTS();
            cmts.Connect(Class.CMTS.CMTS_Host);
            if (Class.CMTS.tcpClient.Connected)
            {
                DataRow dr;
                string _ds = "";
                string _us = "";
                cmts.Get_TrafficMac(txtMac.Text,out _ds,out _us);
                if (_ds != "")
                {
                    if (dtTraffic.Rows.Count < 1)
                    {
                        dr = dtTraffic.NewRow();
                        dr["DateTime"] = DateTime.Now;
                        dr["DS"] = _ds;
                        dr["US"] = _us;
                        dr["CurrentDS"] = _ds;
                        dr["CurrentUS"] = _us;
                        dtTraffic.Rows.Add(dr);
                    }
                    else
                    {
                        // tinh trafic
                        double currds = 0;
                        double currus = 0;
                        double Oldcurrds = 0;
                        double Oldcurrus = 0;
                        double.TryParse(_ds, out currds);
                        double.TryParse(_us, out currus);
                        double.TryParse(dtTraffic.Rows[dtTraffic.Rows.Count - 1]["CurrentDS"].ToString(), out Oldcurrds);
                        double.TryParse(dtTraffic.Rows[dtTraffic.Rows.Count - 1]["CurrentUS"].ToString(), out Oldcurrus);

                        dr = dtTraffic.NewRow();
                        dr["DateTime"] = DateTime.Now;
                        if (currds > Oldcurrds)
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = (currds - Oldcurrds).ToString();
                        }
                        else if (currds == Oldcurrds)
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = "0";
                        }
                        else
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = currds.ToString();
                        }
                        if (currus > Oldcurrus)
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = (currus - Oldcurrus).ToString();
                        }
                        else if (currus == Oldcurrus)
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = "0";
                        }
                        else
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = currus.ToString();
                        }                        
                        dtTraffic.Rows.Add(dr);
                        float down = 0;
                        float up = 0;
                        float speeddown = 0;
                        float speedup = 0;

                        float speeddownM = 0;
                        float speedupM = 0;

                        float.TryParse(dr["DS"].ToString(), out down);
                        float.TryParse(dr["US"].ToString(), out up);
                        speeddown = down / 60;
                        speedup = up / 60;
                        this.Text = " Monitoring ( Download: " + speeddown.ToString("n") + "Kbps - Upload: " + speedup.ToString("n") + "Kbps)";
                        arcScaleComponent1.Value = speeddown;
                        arcScaleComponent2.Value = speedup;
                        speeddownM = (speeddown * 8) / 1000;
                        speedupM = (speedup * 8) / 1000;
                        arcScaleComponent3.Value = speeddownM;
                        arcScaleComponent4.Value = speedupM;

                        lblds1.Text = speeddown.ToString("n");
                        lblds2.Text = speeddownM.ToString("n");
                        lblus1.Text = speedup.ToString("n");
                        lblus2.Text = speedupM.ToString("n");

                    }
                }
            }
        }
        void getOntime()
        {
            Class.CMTS cmts = new Class.CMTS();
            cmts.Connect(Class.CMTS.CMTS_Host);
            if (Class.CMTS.tcpClient.Connected)
            {
                DataRow dr;
                string _ds = "";
                string _us = "";
                cmts.Get_TrafficMac(txtMac.Text, out _ds, out _us);
                if (_ds != "")
                {
                    if (dtTraffic.Rows.Count < 1)
                    {
                        dr = dtTraffic.NewRow();
                        dr["DateTime"] = DateTime.Now;
                        dr["DS"] = _ds;
                        dr["US"] = _us;
                        dr["CurrentDS"] = _ds;
                        dr["CurrentUS"] = _us;
                        dtTraffic.Rows.Add(dr);
                    }
                    else
                    {
                        // tinh trafic
                        double currds = 0;
                        double currus = 0;
                        double Oldcurrds = 0;
                        double Oldcurrus = 0;
                        double.TryParse(_ds, out currds);
                        double.TryParse(_us, out currus);
                        double.TryParse(dtTraffic.Rows[dtTraffic.Rows.Count - 1]["CurrentDS"].ToString(), out Oldcurrds);
                        double.TryParse(dtTraffic.Rows[dtTraffic.Rows.Count - 1]["CurrentUS"].ToString(), out Oldcurrus);

                        dr = dtTraffic.NewRow();
                        dr["DateTime"] = DateTime.Now;
                        if (currds > Oldcurrds)
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = (currds - Oldcurrds).ToString();
                        }
                        else if (currds == Oldcurrds)
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = "0";
                        }
                        else
                        {
                            dr["CurrentDS"] = currds;
                            dr["DS"] = currds.ToString();
                        }
                        if (currus > Oldcurrus)
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = (currus - Oldcurrus).ToString();
                        }
                        else if (currus == Oldcurrus)
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = "0";
                        }
                        else
                        {
                            dr["CurrentUS"] = currus;
                            dr["US"] = currus.ToString();
                        }
                        dtTraffic.Rows.Add(dr);
                        float down = 0;
                        float up = 0;
                        float speeddown = 0;
                        float speedup = 0;
                        float speeddownM = 0;
                        float speedupM = 0;
                        float.TryParse(dr["DS"].ToString(), out down);
                        float.TryParse(dr["US"].ToString(), out up);
                        speeddown = down / 3;
                        speedup = up / 3;
                        this.Text = " Monitoring ( Download: " + speeddown.ToString("n") + "KBps - Upload: " + speedup.ToString("n") + "KBps)";
                       
                       arcScaleComponent1.Value = speeddown;
                       arcScaleComponent2.Value = speedup;
                       speeddownM = (speeddown * 8) / 1000;
                       speedupM = (speedup * 8) / 1000;
                       arcScaleComponent3.Value = speeddownM;
                       arcScaleComponent4.Value = speedupM;
                       lblds1.Text = speeddown.ToString("n");
                       lblds2.Text = speeddownM.ToString("n");
                       lblus1.Text = speedup.ToString("n");
                       lblus2.Text = speedupM.ToString("n");

                      
                    }
                }
            }
        }
        void chart()
        {           
            Series Ds = new Series("DS: KByte ", ViewType.SwiftPlot);
            Series Us = new Series("US: KByte  ", ViewType.SwiftPlot);
            Ds.Points.Clear();
            Us.Points.Clear();
            chartDS.Series.Clear();
            chartUS.Series.Clear();
            for (int i = 1; i < dtTraffic.Rows.Count; i++)
            {
                Ds.Points.Add(new SeriesPoint(((DateTime)dtTraffic.Rows[i]["DateTime"]).ToString("HHmmss"), dtTraffic.Rows[i]["DS"].ToString()));
                Us.Points.Add(new SeriesPoint(((DateTime)dtTraffic.Rows[i]["DateTime"]).ToString("HHmmss"), dtTraffic.Rows[i]["US"].ToString()));

            }
            chartDS.Series.AddRange(new Series[] { Ds });
            chartUS.Series.AddRange(new Series[] { Us });

        }
        void chartOntime()
        {
            Series Ds = new Series("DS: KByte ", ViewType.SwiftPlot);
            Series Us = new Series("US: KByte  ", ViewType.SwiftPlot);
            Ds.Points.Clear();
            Us.Points.Clear();
            chartDS.Series.Clear();
            chartUS.Series.Clear();
            for (int i = 1; i < dtTraffic.Rows.Count; i++)
            {
                Ds.Points.Add(new SeriesPoint(((DateTime)dtTraffic.Rows[i]["DateTime"]).ToString("HHmmss"), dtTraffic.Rows[i]["DS"].ToString()));
                Us.Points.Add(new SeriesPoint(((DateTime)dtTraffic.Rows[i]["DateTime"]).ToString("HHmmss"), dtTraffic.Rows[i]["US"].ToString()));

            }
            chartDS.Series.AddRange(new Series[] { Ds });
            chartUS.Series.AddRange(new Series[] { Us });

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                get();
                chart();
                gridItem.DataSource = dtTraffic;
                timer1.Enabled = true;
                if (dtTraffic.Rows.Count > 1000)
                {
                    btnStop_Click(null, null);
                }
            }
            catch { timer1.Enabled = true; }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            txtMac.Enabled = true;
            btnStartOntime.Enabled = true;
            btnStart.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Enabled = false;
                getOntime();
                chartOntime();
                gridItem.DataSource = dtTraffic;
                timer2.Enabled = true;
                if (dtTraffic.Rows.Count > 1000)
                {
                    btnStop_Click(null, null);
                }
            }
            catch { timer2.Enabled = true; }
        }

        private void btnStartOntime_Click(object sender, EventArgs e)
        {
            if (txtMac.Text.Length != 14)
            {
                return;
            }
            txtMac.Enabled = false;
            btnStart.Enabled = false;
            btnStartOntime.Enabled = false;
            dtTraffic.Rows.Clear();
            this.Text = "Monitoring";
            timer2.Enabled = true;
            getOntime();
            chartOntime();
        }
    
    }
}