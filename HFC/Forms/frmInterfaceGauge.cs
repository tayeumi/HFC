using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HFC.Forms
{
    public partial class frmInterfaceGauge : DevExpress.XtraEditors.XtraForm
    {
        public frmInterfaceGauge()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void frmInterfaceGauge_Load(object sender, EventArgs e)
        {
            loadInterface();
        }
        void loadInterface()
        {
            Class.NW_InterfaceGauge cls = new Class.NW_InterfaceGauge();
            dt = cls.NW_InterfaceGauge_Getlist();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;           
        }
        double _in = 0;
        double _out = 0;
        double _inLast = 0;
        double _outLast = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Class.NW_InterfaceGauge cls = new Class.NW_InterfaceGauge();
            cls.GetInfoOID(dt, out dt);  
            labelControl1.Text = textEdit1.Text = dt.Rows[0]["InBandwidth"].ToString();
            labelControl2.Text = textEdit2.Text = dt.Rows[0]["OutBandwidth"].ToString();
            _in = double.Parse(dt.Rows[0]["InBandwidth"].ToString());
            _out = double.Parse(dt.Rows[0]["OutBandwidth"].ToString());

            if (_inLast != 0)
            {
                textEdit1.Text = ((((_in - _inLast) * 8) * 100)/10000000000).ToString();
                textEdit2.Text = ((((_out   - _outLast) * 8) * 100) / 10000000000).ToString();
            }
            _inLast = double.Parse(dt.Rows[0]["InBandwidth"].ToString());
            _outLast = double.Parse(dt.Rows[0]["OutBandwidth"].ToString());

        }

    }
}