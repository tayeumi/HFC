namespace HFC.Forms
{
    partial class frmSignalHistory
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colValue4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPrivate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPublic1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPublic2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangthai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // colValue4
            // 
            this.colValue4.Caption = "US SNR";
            this.colValue4.FieldName = "Value4";
            this.colValue4.Name = "colValue4";
            this.colValue4.Visible = true;
            this.colValue4.VisibleIndex = 7;
            this.colValue4.Width = 61;
            // 
            // colValue2
            // 
            this.colValue2.Caption = "US Tx";
            this.colValue2.FieldName = "Value2";
            this.colValue2.Name = "colValue2";
            this.colValue2.Visible = true;
            this.colValue2.VisibleIndex = 5;
            this.colValue2.Width = 59;
            // 
            // colValue1
            // 
            this.colValue1.Caption = "DS SNR";
            this.colValue1.FieldName = "Value1";
            this.colValue1.Name = "colValue1";
            this.colValue1.Visible = true;
            this.colValue1.VisibleIndex = 4;
            this.colValue1.Width = 65;
            // 
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.ItemCheckStatus});
            this.gridItem.Size = new System.Drawing.Size(861, 516);
            this.gridItem.TabIndex = 4;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatetime,
            this.colMacAdress,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colWard,
            this.colCustomerTelephone,
            this.colIpPrivate,
            this.colIpPublic1,
            this.colIpPublic2,
            this.colValue1,
            this.colValue2,
            this.colValue3,
            this.colValue4,
            this.colLocation,
            this.colTrangthai,
            this.colStatus,
            this.gridColumn4});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colValue4;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "ToInt([Value4])<210 And Len([Value4])  > 0";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colValue2;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "ToFloat([Value2])>54.0";
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colValue1;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "ToFloat([Value1])<30.0";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 50;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDatetime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            // 
            // colDatetime
            // 
            this.colDatetime.Caption = "Date";
            this.colDatetime.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.colDatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatetime.FieldName = "DateTime";
            this.colDatetime.Name = "colDatetime";
            this.colDatetime.Visible = true;
            this.colDatetime.VisibleIndex = 0;
            this.colDatetime.Width = 114;
            // 
            // colMacAdress
            // 
            this.colMacAdress.Caption = "Địa chỉ MAC Adress";
            this.colMacAdress.FieldName = "MacAddress";
            this.colMacAdress.Name = "colMacAdress";
            this.colMacAdress.Visible = true;
            this.colMacAdress.VisibleIndex = 2;
            this.colMacAdress.Width = 106;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Khách hàng";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 137;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Caption = "Địa chỉ";
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.Width = 140;
            // 
            // colWard
            // 
            this.colWard.Caption = "Quận";
            this.colWard.FieldName = "Ward";
            this.colWard.Name = "colWard";
            // 
            // colCustomerTelephone
            // 
            this.colCustomerTelephone.Caption = "Điện thoại";
            this.colCustomerTelephone.FieldName = "CustomerTelephone";
            this.colCustomerTelephone.Name = "colCustomerTelephone";
            this.colCustomerTelephone.Width = 98;
            // 
            // colIpPrivate
            // 
            this.colIpPrivate.Caption = "IP Private";
            this.colIpPrivate.FieldName = "IpPrivate";
            this.colIpPrivate.Name = "colIpPrivate";
            this.colIpPrivate.Visible = true;
            this.colIpPrivate.VisibleIndex = 3;
            this.colIpPrivate.Width = 125;
            // 
            // colIpPublic1
            // 
            this.colIpPublic1.Caption = "IP Public1";
            this.colIpPublic1.FieldName = "IpPublic1";
            this.colIpPublic1.Name = "colIpPublic1";
            this.colIpPublic1.Visible = true;
            this.colIpPublic1.VisibleIndex = 10;
            this.colIpPublic1.Width = 101;
            // 
            // colIpPublic2
            // 
            this.colIpPublic2.Caption = "Mac PC";
            this.colIpPublic2.FieldName = "IpPublic2";
            this.colIpPublic2.Name = "colIpPublic2";
            this.colIpPublic2.Visible = true;
            this.colIpPublic2.VisibleIndex = 11;
            this.colIpPublic2.Width = 86;
            // 
            // colValue3
            // 
            this.colValue3.Caption = "DS Rx";
            this.colValue3.FieldName = "Value3";
            this.colValue3.Name = "colValue3";
            this.colValue3.Visible = true;
            this.colValue3.VisibleIndex = 6;
            this.colValue3.Width = 59;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 1;
            this.colLocation.Width = 103;
            // 
            // colTrangthai
            // 
            this.colTrangthai.Caption = "Trạng thái";
            this.colTrangthai.FieldName = "Status";
            this.colTrangthai.Name = "colTrangthai";
            this.colTrangthai.Visible = true;
            this.colTrangthai.VisibleIndex = 8;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.ColumnEdit = this.ItemCheckStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 94;
            // 
            // ItemCheckStatus
            // 
            this.ItemCheckStatus.AutoHeight = false;
            this.ItemCheckStatus.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ItemCheckStatus.Name = "ItemCheckStatus";
            this.ItemCheckStatus.PictureChecked = global::HFC.Properties.Resources._15;
            this.ItemCheckStatus.PictureGrayed = global::HFC.Properties.Resources.offline;
            this.ItemCheckStatus.PictureUnchecked = global::HFC.Properties.Resources._16;
            this.ItemCheckStatus.ValueChecked = "online";
            this.ItemCheckStatus.ValueUnchecked = "offline";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ghi Chú";
            this.gridColumn4.FieldName = "Description";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 147;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 105;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // frmSignalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 516);
            this.Controls.Add(this.gridItem);
            this.Name = "frmSignalHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signal History";
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colMacAdress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colWard;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colIpPrivate;
        private DevExpress.XtraGrid.Columns.GridColumn colIpPublic1;
        private DevExpress.XtraGrid.Columns.GridColumn colIpPublic2;
        private DevExpress.XtraGrid.Columns.GridColumn colValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colValue4;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangthai;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}