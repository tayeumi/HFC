namespace HFC.Forms
{
    partial class frmDHCPCustomer
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
            this.colIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAddress_CMTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CusstomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoolIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBootfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.txtLink = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(-1, 74);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItem.Size = new System.Drawing.Size(701, 360);
            this.gridItem.TabIndex = 3;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIpAddress,
            this.colMacAddress,
            this.colMacAddress_CMTS,
            this.colCustomerCode,
            this.colCustomerName,
            this.CusstomerAddress,
            this.colPoolIp,
            this.colBootfile});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // colIpAddress
            // 
            this.colIpAddress.Caption = "Ip Address";
            this.colIpAddress.FieldName = "IpAddress";
            this.colIpAddress.Name = "colIpAddress";
            this.colIpAddress.Visible = true;
            this.colIpAddress.VisibleIndex = 0;
            this.colIpAddress.Width = 149;
            // 
            // colMacAddress
            // 
            this.colMacAddress.Caption = "MacAddress";
            this.colMacAddress.FieldName = "MacAddress";
            this.colMacAddress.Name = "colMacAddress";
            this.colMacAddress.Visible = true;
            this.colMacAddress.VisibleIndex = 1;
            this.colMacAddress.Width = 96;
            // 
            // colMacAddress_CMTS
            // 
            this.colMacAddress_CMTS.Caption = "MacAddress_CMTS";
            this.colMacAddress_CMTS.FieldName = "MacAddress_CMTS";
            this.colMacAddress_CMTS.Name = "colMacAddress_CMTS";
            this.colMacAddress_CMTS.Visible = true;
            this.colMacAddress_CMTS.VisibleIndex = 2;
            this.colMacAddress_CMTS.Width = 114;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "CustomerCode";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 3;
            this.colCustomerCode.Width = 131;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "CustomerName";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 123;
            // 
            // CusstomerAddress
            // 
            this.CusstomerAddress.Caption = "CusstomerAddress";
            this.CusstomerAddress.FieldName = "CusstomerAddress";
            this.CusstomerAddress.Name = "CusstomerAddress";
            this.CusstomerAddress.Visible = true;
            this.CusstomerAddress.VisibleIndex = 5;
            this.CusstomerAddress.Width = 123;
            // 
            // colPoolIp
            // 
            this.colPoolIp.Caption = "PoolIp";
            this.colPoolIp.FieldName = "PoolIp";
            this.colPoolIp.Name = "colPoolIp";
            this.colPoolIp.Visible = true;
            this.colPoolIp.VisibleIndex = 6;
            this.colPoolIp.Width = 231;
            // 
            // colBootfile
            // 
            this.colBootfile.Caption = "Bootfile";
            this.colBootfile.FieldName = "Bootfile";
            this.colBootfile.Name = "colBootfile";
            this.colBootfile.Visible = true;
            this.colBootfile.VisibleIndex = 7;
            this.colBootfile.Width = 76;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(43, 31);
            this.txtLink.Name = "txtLink";
            this.txtLink.Properties.ReadOnly = true;
            this.txtLink.Size = new System.Drawing.Size(347, 20);
            this.txtLink.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Link";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(396, 30);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(86, 24);
            this.btnFile.TabIndex = 6;
            this.btnFile.Text = "Chọn file";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(488, 30);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(86, 24);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnFile);
            this.groupControl1.Controls.Add(this.btnRead);
            this.groupControl1.Controls.Add(this.txtLink);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(697, 67);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Import from file";
            // 
            // frmDHCPCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 436);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridItem);
            this.Name = "frmDHCPCustomer";
            this.Text = "frmDHCPCustomer";
            this.Load += new System.EventHandler(this.frmDHCPCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colIpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colMacAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colMacAddress_CMTS;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn CusstomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPoolIp;
        private DevExpress.XtraGrid.Columns.GridColumn colBootfile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraEditors.TextEdit txtLink;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFile;
        private DevExpress.XtraEditors.SimpleButton btnRead;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}