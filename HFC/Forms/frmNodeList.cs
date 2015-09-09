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
    public partial class frmNodeList : DevExpress.XtraEditors.XtraForm
    {
        public frmNodeList()
        {
            InitializeComponent();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNodeList_Update frm = new frmNodeList_Update(true, "Thêm Node", null, null);
            frm.Owner = this;
            frm.ShowDialog(); 
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnEdit.Enabled)
                return;
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
               // DataRow drow = gridItemDetail.GetDataRow(SelectedRow);

                string _value = gridItemDetail.GetFocusedRowCellValue(colNodeCode).ToString();// drow["NodeCode"].ToString();

                frmNodeList_Update frm = new frmNodeList_Update(false, "Cập nhật Node", "CV", _value);
                frm.Owner = this;
                frm.ShowDialog();
            }
        }

        private void frmNodeList_Load(object sender, EventArgs e)
        {
            NW_Node_GetList();
        }
        public void NW_Node_GetList()
        {
            Class.NW_Node cls = new Class.NW_Node();
            DataTable dt = cls.NW_Node_GetList();
            gridItem.DataSource = dt;
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int SelectedRow = gridItemDetail.FocusedRowHandle;
            if (SelectedRow >= 0)
            {
                DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                string _value = drow["NodeCode"].ToString();
                string _total = drow["Total"].ToString();
                if (_total != "0" && _total != "")
                {
                    MessageBox.Show("Node đang chứa nhiều thiết bị, Vui lòng xóa thiết bị trước.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Class.App.ConfirmDeletion() == DialogResult.No)
                    return;

                Class.NW_Node cls = new Class.NW_Node();
                cls.NodeCode = _value;
                if (cls.Delete())
                {
                    Class.App.DeleteSuccessfully();
                    NW_Node_GetList();
                }
                else
                {
                    Class.App.DeleteNotSuccessfully();
                }
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
             int SelectedRow = gridItemDetail.FocusedRowHandle;
             if (SelectedRow >= 0)
             {
                 string _value2 = "";
                 string _value = gridItemDetail.GetFocusedRowCellValue(colNodeCode).ToString();// drow["NodeCode"].ToString();
                  _value2 = gridItemDetail.GetFocusedRowCellValue(colDescription).ToString();
                  if (_value2.Length > 5)
                  {
                      frmNodeList_UpdateByPath frm = new frmNodeList_UpdateByPath(_value, _value2);
                      frm.ShowDialog();
                  }
                  else
                  {
                      MessageBox.Show("Node này chưa được cập nhật tọa độ GPS !");
                  }
             }
        }
    }
}