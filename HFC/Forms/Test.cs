using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HFC.Forms
{
    public partial class Test : Form
    {
        DataTable table = new DataTable();
        BindingSource bind = new BindingSource();


        public Test()
        {
            InitializeComponent();
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Value", typeof(Int32)));
            bind.DataSource = table;
            table.Rows.Add("dasdsa", "77777");
            table.Rows.Add("11111", "222222");
            gridControl1.DataSource = bind;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //table.Columns.Add(new DataColumn("Check", typeof(bool)));
            table.Rows.Add("333", "333333");
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Value", typeof(Int32)));
            table.Rows.Add("new1", "77777");
            table.Rows.Add("new2", "222222");
            bind.DataSource = table;
        }
    }
}
