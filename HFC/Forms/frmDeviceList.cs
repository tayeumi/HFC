using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HFC.Forms
{
    public partial class frmDeviceList : DevExpress.XtraEditors.XtraForm
    {
        public frmDeviceList()
        {
            InitializeComponent();
        }

        private void frmDeviceList_Load(object sender, EventArgs e)
        {
            NW_Node_GetList();
        }
        void NW_Node_GetList()
        {
            Class.NW_Node cls = new Class.NW_Node();
            DataTable dt = cls.NW_Node_GetList();
            gridItemNode.DataSource = dt;
        }

        public void NW_Device_GetByNodeCode()
        {
             int SelectedRow = gridItemDetailNode.FocusedRowHandle;
             if (SelectedRow >= 0)
             {
                 DataRow drow = gridItemDetailNode.GetDataRow(SelectedRow);
                 string _NodeCode = drow["NodeCode"].ToString();

                 Class.NW_Device cls = new Class.NW_Device();
                 cls.NodeCode = _NodeCode;
                 DataTable dt = cls.NW_Device_GetByNodeCode();
                 gridItem.DataSource = dt;
             }

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             int SelectedRow = gridItemDetailNode.FocusedRowHandle;
             if (SelectedRow >= 0)
             {
                 DataRow drow = gridItemDetailNode.GetDataRow(SelectedRow);
                 string _NodeCode = drow["NodeCode"].ToString();
                 string _NodeName = drow["NodeName"].ToString();

                 frmDeviceList_Update frm = new frmDeviceList_Update(true, "Thêm Device cho Node: " + _NodeName, _NodeCode, null);
                 frm.Owner = this;
                 frm.ShowDialog(); 
             }
             else
             {
                 MessageBox.Show("Bạn Chưa chọn Node cần thêm, vui lòng chọn Node trước. !", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

             }
        }

       

        private void gridItemDetailNode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NW_Device_GetByNodeCode();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selectedRows = gridItemDetail.GetSelectedRows();
            if (selectedRows.Length > 1)
            {
                if (Class.App.ConfirmDeletionMulti() == DialogResult.No)
                    return;
                Class.NW_Device cls = new Class.NW_Device();
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    int rowHandle = selectedRows[i];
                    string mac="";
                    if (!gridItemDetail.IsGroupRow(rowHandle))
                    {
                        mac = gridItemDetail.GetRowCellValue(rowHandle, colMacAdress).ToString();
                    }

                    cls.MacAddress = mac;
                    if (cls.Delete())
                    {
                       // Class.App.DeleteSuccessfully(mac);                       
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }
                MessageBox.Show(" Hoàn thành thao tác xóa !");
                NW_Device_GetByNodeCode();
               
            }
            else
            {
                int SelectedRow = gridItemDetail.FocusedRowHandle;
                if (SelectedRow >= 0)
                {
                    DataRow drow = gridItemDetail.GetDataRow(SelectedRow);
                    string _MacAddress = drow["MacAddress"].ToString();
                    if (Class.App.ConfirmDeletion() == DialogResult.No)
                        return;

                    Class.NW_Device cls = new Class.NW_Device();
                    cls.MacAddress = _MacAddress;
                    if (cls.Delete())
                    {
                        Class.App.DeleteSuccessfully();
                        NW_Device_GetByNodeCode();
                    }
                    else
                    {
                        Class.App.DeleteNotSuccessfully();
                    }
                }
            }
        }
        bool indicatorIcon = true;
        private void gridItemDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            //Check whether the indicator cell belongs to a data row
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }
    }
}