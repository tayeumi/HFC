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
            this.components = new System.ComponentModel.Container();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddStaticIP = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddIP = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelIP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateDHCPFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDHCPRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDHCPTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAddress_CMTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoolIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBootfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPublic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacPc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoolPublic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.txtLink = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.groupImport = new DevExpress.XtraEditors.GroupControl();
            this.btnCountIP = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImport)).BeginInit();
            this.groupImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.ContextMenuStrip = this.contextMenuStrip1;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(-1, 74);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItem.Size = new System.Drawing.Size(872, 372);
            this.gridItem.TabIndex = 3;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel,
            this.toolStripMenuItem1,
            this.btnAddStaticIP,
            this.toolStripMenuItem2,
            this.btnCreateDHCPFile,
            this.btnDHCPRestart,
            this.btnDHCPTemplate,
            this.toolStripMenuItem3,
            this.btnExportExcel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 198);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::HFC.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(170, 22);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::HFC.Properties.Resources.Edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(170, 22);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::HFC.Properties.Resources.Delete;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(170, 22);
            this.btnDel.Text = "Xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // btnAddStaticIP
            // 
            this.btnAddStaticIP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddIP,
            this.btnDelIP});
            this.btnAddStaticIP.Image = global::HFC.Properties.Resources.Action_Navigation_History_Forward;
            this.btnAddStaticIP.Name = "btnAddStaticIP";
            this.btnAddStaticIP.Size = new System.Drawing.Size(170, 22);
            this.btnAddStaticIP.Text = "Cấp IP Tĩnh";
            // 
            // btnAddIP
            // 
            this.btnAddIP.Image = global::HFC.Properties.Resources.add;
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(134, 22);
            this.btnAddIP.Text = "Cấp IP tĩnh";
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // btnDelIP
            // 
            this.btnDelIP.Image = global::HFC.Properties.Resources.Delete;
            this.btnDelIP.Name = "btnDelIP";
            this.btnDelIP.Size = new System.Drawing.Size(134, 22);
            this.btnDelIP.Text = "Xóa IP Tĩnh";
            this.btnDelIP.Click += new System.EventHandler(this.btnDelIP_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // btnCreateDHCPFile
            // 
            this.btnCreateDHCPFile.Image = global::HFC.Properties.Resources.Action_LocalizationImport;
            this.btnCreateDHCPFile.Name = "btnCreateDHCPFile";
            this.btnCreateDHCPFile.Size = new System.Drawing.Size(170, 22);
            this.btnCreateDHCPFile.Text = "Create DHCP conf";
            this.btnCreateDHCPFile.Click += new System.EventHandler(this.btnCreateDHCPFile_Click);
            // 
            // btnDHCPRestart
            // 
            this.btnDHCPRestart.Image = global::HFC.Properties.Resources.Action_Reload;
            this.btnDHCPRestart.Name = "btnDHCPRestart";
            this.btnDHCPRestart.Size = new System.Drawing.Size(170, 22);
            this.btnDHCPRestart.Text = "DHCP Restart";
            this.btnDHCPRestart.Click += new System.EventHandler(this.btnDHCPRestart_Click);
            // 
            // btnDHCPTemplate
            // 
            this.btnDHCPTemplate.Image = global::HFC.Properties.Resources.Action_ChooseSkin;
            this.btnDHCPTemplate.Name = "btnDHCPTemplate";
            this.btnDHCPTemplate.Size = new System.Drawing.Size(170, 22);
            this.btnDHCPTemplate.Text = "DHCP Template";
            this.btnDHCPTemplate.Click += new System.EventHandler(this.btnDHCPTemplate_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(170, 22);
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIpAddress,
            this.colMacAddress,
            this.colMacAddress_CMTS,
            this.colCustomerCode,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colPoolIp,
            this.colBootfile,
            this.colIpPublic,
            this.colMacPc,
            this.colPoolPublic,
            this.colNote,
            this.colLocation});
            this.gridItemDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsSelection.MultiSelect = true;
            this.gridItemDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetail.DoubleClick += new System.EventHandler(this.gridItemDetail_DoubleClick);
            // 
            // colIpAddress
            // 
            this.colIpAddress.Caption = "Ip Address";
            this.colIpAddress.FieldName = "IpAddress";
            this.colIpAddress.Name = "colIpAddress";
            this.colIpAddress.Visible = true;
            this.colIpAddress.VisibleIndex = 0;
            this.colIpAddress.Width = 93;
            // 
            // colMacAddress
            // 
            this.colMacAddress.Caption = "MacAddress";
            this.colMacAddress.FieldName = "MacAddress";
            this.colMacAddress.Name = "colMacAddress";
            this.colMacAddress.Visible = true;
            this.colMacAddress.VisibleIndex = 1;
            this.colMacAddress.Width = 129;
            // 
            // colMacAddress_CMTS
            // 
            this.colMacAddress_CMTS.Caption = "MacAddress_CMTS";
            this.colMacAddress_CMTS.FieldName = "MacAddress_CMTS";
            this.colMacAddress_CMTS.Name = "colMacAddress_CMTS";
            this.colMacAddress_CMTS.Width = 114;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "CustomerCode";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 2;
            this.colCustomerCode.Width = 111;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "CustomerName";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 3;
            this.colCustomerName.Width = 146;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Caption = "CustomerAddress";
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Width = 123;
            // 
            // colPoolIp
            // 
            this.colPoolIp.Caption = "PoolIp";
            this.colPoolIp.FieldName = "PoolIp";
            this.colPoolIp.Name = "colPoolIp";
            this.colPoolIp.Visible = true;
            this.colPoolIp.VisibleIndex = 4;
            this.colPoolIp.Width = 119;
            // 
            // colBootfile
            // 
            this.colBootfile.Caption = "Bootfile";
            this.colBootfile.FieldName = "Bootfile";
            this.colBootfile.Name = "colBootfile";
            this.colBootfile.Visible = true;
            this.colBootfile.VisibleIndex = 5;
            this.colBootfile.Width = 113;
            // 
            // colIpPublic
            // 
            this.colIpPublic.Caption = "IpPublic";
            this.colIpPublic.FieldName = "IpPublic";
            this.colIpPublic.Name = "colIpPublic";
            this.colIpPublic.Visible = true;
            this.colIpPublic.VisibleIndex = 6;
            this.colIpPublic.Width = 122;
            // 
            // colMacPc
            // 
            this.colMacPc.Caption = "MacPc";
            this.colMacPc.FieldName = "MacPc";
            this.colMacPc.Name = "colMacPc";
            this.colMacPc.Visible = true;
            this.colMacPc.VisibleIndex = 7;
            this.colMacPc.Width = 143;
            // 
            // colPoolPublic
            // 
            this.colPoolPublic.Caption = "PoolPublic";
            this.colPoolPublic.FieldName = "PoolPublic";
            this.colPoolPublic.Name = "colPoolPublic";
            this.colPoolPublic.Visible = true;
            this.colPoolPublic.VisibleIndex = 8;
            this.colPoolPublic.Width = 141;
            // 
            // colNote
            // 
            this.colNote.Caption = "Note";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 9;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 10;
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
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Link";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(396, 30);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(86, 24);
            this.btnFile.TabIndex = 6;
            this.btnFile.Text = "(1)Chọn file";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(488, 30);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(86, 24);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "(2)Read";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // groupImport
            // 
            this.groupImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupImport.Controls.Add(this.btnCountIP);
            this.groupImport.Controls.Add(this.btnFile);
            this.groupImport.Controls.Add(this.btnDeleteAll);
            this.groupImport.Controls.Add(this.btnImport);
            this.groupImport.Controls.Add(this.btnRead);
            this.groupImport.Controls.Add(this.txtLink);
            this.groupImport.Controls.Add(this.labelControl1);
            this.groupImport.Location = new System.Drawing.Point(3, 3);
            this.groupImport.Name = "groupImport";
            this.groupImport.Size = new System.Drawing.Size(868, 67);
            this.groupImport.TabIndex = 7;
            this.groupImport.Text = "Import from file cn-admin";
            // 
            // btnCountIP
            // 
            this.btnCountIP.Location = new System.Drawing.Point(764, 31);
            this.btnCountIP.Name = "btnCountIP";
            this.btnCountIP.Size = new System.Drawing.Size(94, 24);
            this.btnCountIP.TabIndex = 7;
            this.btnCountIP.Text = "CountIP";
            this.btnCountIP.Click += new System.EventHandler(this.btnCountIP_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(672, 30);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(86, 24);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(580, 30);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(86, 24);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "(3) Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmDHCPCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 448);
            this.Controls.Add(this.groupImport);
            this.Controls.Add(this.gridItem);
            this.Name = "frmDHCPCustomer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DHCP Customer";
            this.Load += new System.EventHandler(this.frmDHCPCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImport)).EndInit();
            this.groupImport.ResumeLayout(false);
            this.groupImport.PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPoolIp;
        private DevExpress.XtraGrid.Columns.GridColumn colBootfile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraEditors.TextEdit txtLink;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFile;
        private DevExpress.XtraEditors.SimpleButton btnRead;
        private DevExpress.XtraEditors.GroupControl groupImport;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn colIpPublic;
        private DevExpress.XtraGrid.Columns.GridColumn colMacPc;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colPoolPublic;
        private DevExpress.XtraEditors.SimpleButton btnDeleteAll;
        private DevExpress.XtraEditors.SimpleButton btnCountIP;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCreateDHCPFile;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnAddStaticIP;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btnAddIP;
        private System.Windows.Forms.ToolStripMenuItem btnDelIP;
        private System.Windows.Forms.ToolStripMenuItem btnDHCPRestart;
        private System.Windows.Forms.ToolStripMenuItem btnDHCPTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem btnExportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}