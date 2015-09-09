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
    public partial class frmTraffic : DevExpress.XtraEditors.XtraForm
    {
        public frmTraffic()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                Class.NW_CurrentTrafic tf = new Class.NW_CurrentTrafic();
                tf.MacAddress = txtMacaddress.Text;
                tf.Month = cbThang.EditValue.ToString();
                tf.Year = cbNam.EditValue.ToString();
                DataTable dt = tf.NW_Trafic_Get();
                gridItem.DataSource = dt;

                Series Ds = new Series("DS: KByte ", ViewType.SwiftPlot);
                Series Us = new Series("US: KByte  ", ViewType.SwiftPlot);
                Ds.Points.Clear();
                Us.Points.Clear();
                chartDS.Series.Clear();
                chartUS.Series.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Ds.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HHmm"), dt.Rows[i]["DS"].ToString()));
                    Us.Points.Add(new SeriesPoint(((DateTime)dt.Rows[i]["DateTime"]).ToString("dd/MM/yy HHmm"), dt.Rows[i]["US"].ToString()));
                                       
                }
                chartDS.Series.AddRange(new Series[] { Ds });
                chartUS.Series.AddRange(new Series[] { Us });
               
            }
            catch {
                MessageBox.Show(" KHÔNG TÌM THẤY YÊU CẦU !");
            }
        }

        private void frmTraffic_Load(object sender, EventArgs e)
        {
            cbNam.EditValue = DateTime.Now.Year;
            cbThang.EditValue = DateTime.Now.Month;

        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }
    }
}