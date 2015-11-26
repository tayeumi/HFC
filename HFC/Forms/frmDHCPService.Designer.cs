namespace HFC.Forms
{
    partial class frmDHCPService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoolIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubnetMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRouter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colBroadcast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatic = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItem.Size = new System.Drawing.Size(645, 451);
            this.gridItem.TabIndex = 2;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colPoolIP,
            this.colSubnetMask,
            this.colRouter,
            this.colBroadcast,
            this.colDns,
            this.colRange,
            this.colStatic});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 35;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 149;
            // 
            // colPoolIP
            // 
            this.colPoolIP.Caption = "PoolIP";
            this.colPoolIP.FieldName = "PoolIP";
            this.colPoolIP.Name = "colPoolIP";
            this.colPoolIP.Visible = true;
            this.colPoolIP.VisibleIndex = 2;
            this.colPoolIP.Width = 96;
            // 
            // colSubnetMask
            // 
            this.colSubnetMask.Caption = "SubnetMask";
            this.colSubnetMask.FieldName = "SubnetMask";
            this.colSubnetMask.Name = "colSubnetMask";
            this.colSubnetMask.Visible = true;
            this.colSubnetMask.VisibleIndex = 3;
            this.colSubnetMask.Width = 114;
            // 
            // colRouter
            // 
            this.colRouter.Caption = "Router";
            this.colRouter.FieldName = "Router";
            this.colRouter.Name = "colRouter";
            this.colRouter.Visible = true;
            this.colRouter.VisibleIndex = 4;
            this.colRouter.Width = 131;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // colBroadcast
            // 
            this.colBroadcast.Caption = "Broadcast";
            this.colBroadcast.FieldName = "Broadcast";
            this.colBroadcast.Name = "colBroadcast";
            this.colBroadcast.Visible = true;
            this.colBroadcast.VisibleIndex = 5;
            this.colBroadcast.Width = 123;
            // 
            // colDns
            // 
            this.colDns.Caption = "Dns";
            this.colDns.FieldName = "Dns";
            this.colDns.Name = "colDns";
            this.colDns.Visible = true;
            this.colDns.VisibleIndex = 6;
            this.colDns.Width = 123;
            // 
            // colRange
            // 
            this.colRange.Caption = "Range";
            this.colRange.FieldName = "Range";
            this.colRange.Name = "colRange";
            this.colRange.Visible = true;
            this.colRange.VisibleIndex = 7;
            this.colRange.Width = 231;
            // 
            // colStatic
            // 
            this.colStatic.Caption = "Static";
            this.colStatic.FieldName = "Static";
            this.colStatic.Name = "colStatic";
            this.colStatic.Visible = true;
            this.colStatic.VisibleIndex = 8;
            this.colStatic.Width = 76;
            // 
            // frmDHCPService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 451);
            this.Controls.Add(this.gridItem);
            this.Name = "frmDHCPService";
            this.Text = "frmDHCPService";
            this.Load += new System.EventHandler(this.frmDHCPService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPoolIP;
        private DevExpress.XtraGrid.Columns.GridColumn colSubnetMask;
        private DevExpress.XtraGrid.Columns.GridColumn colRouter;
        private DevExpress.XtraGrid.Columns.GridColumn colBroadcast;
        private DevExpress.XtraGrid.Columns.GridColumn colDns;
        private DevExpress.XtraGrid.Columns.GridColumn colRange;
        private DevExpress.XtraGrid.Columns.GridColumn colStatic;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
    }
}