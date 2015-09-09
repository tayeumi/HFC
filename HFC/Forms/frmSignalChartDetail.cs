using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;

namespace HFC.Forms
{
    public partial class frmSignalChartDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmSignalChartDetail()
        {
            InitializeComponent();
        }
        Series Series_Point;
        Series Series_Point1;
        Series Series_Point2;
        Series Series_Point3;
        Series Series_Point4;

        public frmSignalChartDetail(DataTable dt, int Type)
        {

            InitializeComponent();
            if (dt.Rows.Count > 0)
            {   
                string mac = dt.Rows[0]["MacAddress"].ToString();
                Series_Point = new Series("USSNR \r\n" + mac, ViewType.StepArea);
                Series_Point1 = new Series("DSSNR \r\n" + mac, ViewType.Line);
                Series_Point2 = new Series("USTX \r\n" + mac, ViewType.Line);
                Series_Point3 = new Series("DSRX \r\n" + mac, ViewType.Line);
                Series_Point4 = new Series("", ViewType.StepArea);

                if (Type == 0)
                {
                    Series_Point1 = new Series("DSSNR \r\n" + mac, ViewType.Line);
                    Series_Point2 = new Series("USTX \r\n" + mac, ViewType.Line);
                    Series_Point3 = new Series("DSRX \r\n" + mac, ViewType.Line);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Status"].ToString() == "online")
                        {

                            Series_Point1.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value1"].ToString()));
                            Series_Point2.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value2"].ToString()));
                            Series_Point3.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value3"].ToString()));
                        }
                        else
                        {
                            Series_Point1.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            Series_Point2.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            Series_Point3.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        }

                    }
                    chartControl.Series.AddRange(new Series[] { Series_Point2,Series_Point1, Series_Point3 });

                }

                if (Type == 3)
                {
                    Series_Point = new Series("USSNR \r\n" + mac, ViewType.StepArea);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["value4"].ToString() != "")
                        {
                            Series_Point.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                            if (int.Parse(dt.Rows[i]["value4"].ToString()) < 210)
                            {
                                Series_Point4.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), dt.Rows[i]["value4"].ToString()));
                            }
                            else
                            {
                                Series_Point4.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            }
                        }
                        else
                        {
                            Series_Point.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                            Series_Point4.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy H"), "0"));
                        }
                    }
                    chartControl.Series.AddRange(new Series[] { Series_Point, Series_Point4 });

                }
            }

            if (Type == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series(dt.Rows[i]["NodeName"].ToString(), ViewType.Bar);
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["NodeName"].ToString(), dt.Rows[i]["TotalOn"].ToString()));
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["NodeName"].ToString(), dt.Rows[i]["TotalOff"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1 });

                }
            }
        }
        public frmSignalChartDetail(DataTable dt)
        {
            InitializeComponent();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Series series1 = new Series("On", ViewType.StackedBar);
                    Series series2 = new Series("Off", ViewType.StackedBar);
                    series1.Points.Add(new SeriesPoint(dt.Rows[i]["NodeName"].ToString(), dt.Rows[i]["TotalOn"].ToString()));
                    series2.Points.Add(new SeriesPoint(dt.Rows[i]["NodeName"].ToString(), dt.Rows[i]["TotalOff"].ToString()));
                    chartControl.Series.AddRange(new Series[] { series1, series2 });
                }
                for (int i = 0; i < chartControl.Series.Count; i++)
                {
                    chartControl.Series[i].LabelsVisibility = DefaultBoolean.True;                  

                }
                contextMenuStrip1.Enabled = false;               
            }
        }
        private void btnViewLine_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.Line);
            Series_Point1.ChangeView(ViewType.Line);
            Series_Point2.ChangeView(ViewType.Line);
            Series_Point3.ChangeView(ViewType.Line);
            Series_Point4.ChangeView(ViewType.Line);
        }

        private void btnSpLine_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.Spline);
            Series_Point1.ChangeView(ViewType.Spline);
            Series_Point2.ChangeView(ViewType.Spline);
            Series_Point3.ChangeView(ViewType.Spline);
            Series_Point4.ChangeView(ViewType.Spline);
        }

        private void btnBar_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.Bar);
            Series_Point1.ChangeView(ViewType.Bar);
            Series_Point2.ChangeView(ViewType.Bar);
            Series_Point3.ChangeView(ViewType.Bar);
            Series_Point4.ChangeView(ViewType.Bar);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.SwiftPlot);
            Series_Point1.ChangeView(ViewType.SwiftPlot);
            Series_Point2.ChangeView(ViewType.SwiftPlot);
            Series_Point3.ChangeView(ViewType.SwiftPlot);
            Series_Point4.ChangeView(ViewType.SwiftPlot);
        }

        private void btnStepArea_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.StepArea);
            Series_Point1.ChangeView(ViewType.StepArea);
            Series_Point2.ChangeView(ViewType.StepArea);
            Series_Point3.ChangeView(ViewType.StepArea);
            Series_Point4.ChangeView(ViewType.StepArea);
        }

        private void btnSplineArea_Click(object sender, EventArgs e)
        {
            Series_Point.ChangeView(ViewType.SplineArea);
            Series_Point1.ChangeView(ViewType.SplineArea);
            Series_Point2.ChangeView(ViewType.SplineArea);
            Series_Point3.ChangeView(ViewType.SplineArea);
            Series_Point4.ChangeView(ViewType.SplineArea);
        }

        private void btnRangeArea_Click(object sender, EventArgs e)
        {
            Series_Point1.ChangeView(ViewType.RangeArea);
            Series_Point2.ChangeView(ViewType.RangeArea);
            Series_Point3.ChangeView(ViewType.RangeArea);
            Series_Point4.ChangeView(ViewType.RangeArea);
        }

        private void btnAreaStacked_Click(object sender, EventArgs e)
        {
            Series_Point1.ChangeView(ViewType.Line3D);
            Series_Point2.ChangeView(ViewType.Line3D);
            Series_Point3.ChangeView(ViewType.Line3D);
            Series_Point4.ChangeView(ViewType.Line3D);
        }
       
        private void chartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            //RectangleFillStyle fillstyle = (RectangleFillStyle)((BarDrawOptions)e.SeriesDrawOptions).FillStyle;
            //RectangleGradientFillOptions opts = (RectangleGradientFillOptions)fillstyle.Options;
            
            //if (dem==0)
            //{
            //    opts.Color2 = Color.Green;
            //    e.SeriesDrawOptions.Color = Color.White;
            //    dem = 1;
            //}
            //else if (dem==1)
            //{
            //    opts.Color2 = Color.Red;
            //    e.SeriesDrawOptions.Color = Color.Yellow;
            //    dem = 0;
            //}
        }

       
      
    }
}