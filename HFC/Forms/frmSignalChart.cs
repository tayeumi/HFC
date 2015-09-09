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
    public partial class frmSignalChart : DevExpress.XtraEditors.XtraForm
    {
        public frmSignalChart()
        {
            InitializeComponent();
            LoadChart("001a.ad83.9e9c");
        }
        string Mac = "";
        public frmSignalChart(string mac)
        {
            InitializeComponent();
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải biểu đồ .!");
            LoadChart(mac);
            this.Text = "Chart For Device " + mac;
            Waiting.CloseWaitForm();
            Mac = mac;
        }
        public frmSignalChart(string mac,int t)
        {
            InitializeComponent();
            Waiting.ShowWaitForm();
            Waiting.SetWaitFormDescription("Đang tải biểu đồ .!");
            LoadChart(mac,t);
            this.Text = "Chart For Device " + mac;
            Waiting.CloseWaitForm();
            Mac = mac;
        }
        DataTable dt = new DataTable();
        void LoadChart(string mac)
        {
            Class.NW_SignalLog cls = new Class.NW_SignalLog();
            cls.MacAddress = mac;
            dt = cls.NW_SignalLog_GetByMac();

            Series Dssnr = new Series("DSSNR \r\n "+mac, ViewType.Line);

            Series UsTx = new Series("USTX \r\n " + mac, ViewType.Line);

            Series DsRx = new Series("DSRX \r\n " + mac, ViewType.Line);

            Series UsSnr = new Series("USSNR \r\n " + mac, ViewType.StepArea);

            Series UsNoise = new Series("", ViewType.StepArea);

           // Series Remote = new Series("Remote \r\n " + mac, ViewType.Line);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Status"].ToString() == "online")
                {

                    Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value1"].ToString()));
                    UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value2"].ToString()));
                    DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value3"].ToString()));
                }
                else
                {
                    Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                }

                if (dt.Rows[i]["value4"].ToString() != "")
                {
                    UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                    if (int.Parse(dt.Rows[i]["value4"].ToString()) < 210)
                    {
                        UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                    }
                    else
                    {
                        UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    }
                }
                else
                {
                    UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                }
            }
            // chartDSSNR.Series.AddRange(new Series[] { Dssnr });
            // chartUSTx.Series.AddRange(new Series[] { UsTx });
            // chartDSRx.Series.AddRange(new Series[] { DsRx });
             chartUSSnr.Series.AddRange(new Series[] { UsSnr,UsNoise });
             chartRemote.Series.AddRange(new Series[] { UsTx, Dssnr , DsRx });
        }
        void LoadChart(string mac,int t)
        {
            Class.NW_SignalLog cls = new Class.NW_SignalLog();
            cls.MacAddress = mac;
            dt = cls.NW_SignalLog_5Day_GetByMac();

            Series Dssnr = new Series("DSSNR \r\n " + mac, ViewType.Line);

            Series UsTx = new Series("USTX \r\n " + mac, ViewType.Line);

            Series DsRx = new Series("DSRX \r\n " + mac, ViewType.Line);

            Series UsSnr = new Series("USSNR \r\n " + mac, ViewType.StepArea);

            Series UsNoise = new Series("", ViewType.StepArea);

            // Series Remote = new Series("Remote \r\n " + mac, ViewType.Line);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Status"].ToString() == "online")
                {

                    Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value1"].ToString()));
                    UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value2"].ToString()));
                    DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value3"].ToString()));
                }
                else
                {
                    Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                }

                if (dt.Rows[i]["value4"].ToString() != "")
                {
                    UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                    if (int.Parse(dt.Rows[i]["value4"].ToString()) < 210)
                    {
                        UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                    }
                    else
                    {
                        UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    }
                }
                else
                {
                    UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                }
            }
            // chartDSSNR.Series.AddRange(new Series[] { Dssnr });
            // chartUSTx.Series.AddRange(new Series[] { UsTx });
            // chartDSRx.Series.AddRange(new Series[] { DsRx });
            chartUSSnr.Series.AddRange(new Series[] { UsSnr, UsNoise });
            chartRemote.Series.AddRange(new Series[] { UsTx, Dssnr, DsRx });
        }
        private void chartUSSnr_DoubleClick(object sender, EventArgs e)
        {
            frmSignalChartDetail frm = new frmSignalChartDetail(dt, 3);
            frm.ShowDialog();
        }

        private void chartRemote_DoubleClick(object sender, EventArgs e)
        {
            frmSignalChartDetail frm = new frmSignalChartDetail(dt, 0);
            frm.ShowDialog();
        }

        private void btnThamKhao_Click(object sender, EventArgs e)
        {          
            frmCn_adminWeb frm = new frmCn_adminWeb(Mac);
            frm.ShowDialog();
        }

        private void dateChoose_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] result = dt.Select("Date=#" + ((DateTime)dateChoose.EditValue).ToString("yyyy-MM-dd") + "#");
                if (result != null)
                {
                    if (result.Length > 0)
                    {
                        chartUSSnr.Series.Clear();
                        chartRemote.Series.Clear();

                        Series Dssnr = new Series("DSSNR \r\n " + Mac, ViewType.Line);

                        Series UsTx = new Series("USTX \r\n " + Mac, ViewType.Line);

                        Series DsRx = new Series("DSRX \r\n " + Mac, ViewType.Line);

                        Series UsSnr = new Series("USSNR \r\n " + Mac, ViewType.StepArea);

                        Series UsNoise = new Series("", ViewType.StepArea);

                        for (int i = 0; i < result.Length; i++)
                        {
                            // result[i][
                            if (result[i]["Status"].ToString() == "online")
                            {

                                Dssnr.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), result[i]["value1"].ToString()));
                                UsTx.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), result[i]["value2"].ToString()));
                                DsRx.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), result[i]["value3"].ToString()));
                            }
                            else
                            {
                                Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                                UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                                DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            }

                            if (result[i]["value4"].ToString() != "")
                            {
                                UsSnr.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), result[i]["value4"].ToString()));
                                if (int.Parse(result[i]["value4"].ToString()) < 210)
                                {
                                    UsNoise.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), result[i]["value4"].ToString()));
                                }
                                else
                                {
                                    UsNoise.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                                }
                            }
                            else
                            {
                                UsSnr.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                                UsNoise.Points.Add(new SeriesPoint(((DateTime)result[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            }

                        }

                        chartUSSnr.Series.AddRange(new Series[] { UsSnr, UsNoise });
                        chartRemote.Series.AddRange(new Series[] { UsTx, Dssnr, DsRx });
                    }
                }
            }
            catch { }
        }

        private void checkChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChoose.Checked)
                dateChoose.Enabled = true;
            else
            {
                dateChoose.Enabled = false;
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải tất cả");
                chartUSSnr.Series.Clear();
                chartRemote.Series.Clear();
                Series Dssnr = new Series("DSSNR \r\n " + Mac, ViewType.Line);

                Series UsTx = new Series("USTX \r\n " + Mac, ViewType.Line);

                Series DsRx = new Series("DSRX \r\n " + Mac, ViewType.Line);

                Series UsSnr = new Series("USSNR \r\n " + Mac, ViewType.StepArea);

                Series UsNoise = new Series("", ViewType.StepArea);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Status"].ToString() == "online")
                    {

                        Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value1"].ToString()));
                        UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value2"].ToString()));
                        DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value3"].ToString()));
                    }
                    else
                    {
                        Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    }

                    if (dt.Rows[i]["value4"].ToString() != "")
                    {
                        UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                        if (int.Parse(dt.Rows[i]["value4"].ToString()) < 210)
                        {
                            UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                        }
                        else
                        {
                            UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        }
                    }
                    else
                    {
                        UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                    }
                }
                chartUSSnr.Series.AddRange(new Series[] { UsSnr, UsNoise });
                chartRemote.Series.AddRange(new Series[] { UsTx, Dssnr, DsRx });
                Waiting.CloseWaitForm();
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
                dateChoose.Enabled = false;
                Waiting.ShowWaitForm();
                Waiting.SetWaitFormDescription("Đang tải tất cả");
                chartUSSnr.Series.Clear();
                chartRemote.Series.Clear();
                Series Dssnr = new Series("DSSNR \r\n " + Mac, ViewType.Line);

                Series UsTx = new Series("USTX \r\n " + Mac, ViewType.Line);

                Series DsRx = new Series("DSRX \r\n " + Mac, ViewType.Line);

                Series UsSnr = new Series("USSNR \r\n " + Mac, ViewType.StepArea);

                Series UsNoise = new Series("", ViewType.StepArea);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Status"].ToString() == "online")
                    {
                        if (dt.Rows[i]["value1"].ToString() != "0" && dt.Rows[i]["value2"].ToString() != "0" )
                        {
                            Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value1"].ToString()));
                            UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value2"].ToString()));
                            DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value3"].ToString()));
                        }
                    }
                    else
                    {
                        if (checkEdit1.Checked == false)
                        {
                            Dssnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            UsTx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            DsRx.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        }
                    }

                    if (dt.Rows[i]["value4"].ToString() != "")
                    {
                        UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                        if (int.Parse(dt.Rows[i]["value4"].ToString()) < 210)
                        {
                            UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                        }
                        else
                        {
                            if (checkEdit1.Checked == false)
                            {
                                UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            }
                        }
                    }
                    else
                    {
                        if (checkEdit1.Checked == false)
                        {
                            UsSnr.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            UsNoise.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        }
                    }
                }
                chartUSSnr.Series.AddRange(new Series[] { UsSnr, UsNoise });
                chartRemote.Series.AddRange(new Series[] { UsTx, Dssnr, DsRx });
                Waiting.CloseWaitForm();
                       
        }
    }
}