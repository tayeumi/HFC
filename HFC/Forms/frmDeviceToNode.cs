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
    public partial class frmDeviceToNode : DevExpress.XtraEditors.XtraForm
    {
        public frmDeviceToNode()
        {
            InitializeComponent();
        }
        DataTable Data = new DataTable();
        public frmDeviceToNode(DataTable dt)
        {
            InitializeComponent();
            NW_Node_GetList();
            Data = dt;
        }
        
        void NW_Node_GetList()
        {
            Class.NW_Node cls = new Class.NW_Node();
            DataTable dt = cls.NW_Node_GetList();
            gridItemNode.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (gridItemDetailNode.SelectedRowsCount > 0)
            {
                if (gridItemDetailNode.FocusedRowHandle > -1)
                {
                    string Node = gridItemDetailNode.GetFocusedRowCellValue(colNodeCode).ToString();
                    Class.NW_Device cls = new Class.NW_Device();
                    for (int i = 0; i < Data.Rows.Count; i++)
                    {
                        if (Data.Rows[i]["Checked"] != DBNull.Value)
                        {
                            if ((bool)Data.Rows[i]["Checked"])
                            {
                                cls.MacAddress = Data.Rows[i]["MacAddress"].ToString();
                                cls.NodeCode = Node;
                                cls.Description = "";
                                if (!cls.Insert())
                                {
                                    MessageBox.Show("Không thêm được mac : " + cls.MacAddress);
                                }
                            }
                        }
                    }
                    MessageBox.Show(" Hoàn thành quá trình thực hiện thêm .!");
                    this.Close();
                }
            }
        }
    }
}