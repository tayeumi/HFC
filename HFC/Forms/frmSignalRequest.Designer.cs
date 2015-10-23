namespace HFC.Forms
{
    partial class frmSignalRequest
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colValue4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemote = new DevExpress.XtraEditors.SimpleButton();
            this.btnPHY = new DevExpress.XtraEditors.SimpleButton();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
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
            this.colValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnLoadAll = new DevExpress.XtraEditors.SimpleButton();
            this.checkInsertData = new DevExpress.XtraEditors.CheckEdit();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTimeRe = new DevExpress.XtraEditors.TextEdit();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.timerRepeat = new System.Windows.Forms.Timer(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnStartFor10P = new DevExpress.XtraEditors.SimpleButton();
            this.timer10 = new System.Windows.Forms.Timer(this.components);
            this.checkBW = new DevExpress.XtraEditors.CheckEdit();
            this.btnSNR = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadIP = new DevExpress.XtraEditors.SimpleButton();
            this.btnIPPublic = new DevExpress.XtraEditors.SimpleButton();
            this.btnTraffic = new DevExpress.XtraEditors.SimpleButton();
            this.checkTraffic = new DevExpress.XtraEditors.CheckEdit();
            this.timer30 = new System.Windows.Forms.Timer(this.components);
            this.checkMaps = new DevExpress.XtraEditors.CheckEdit();
            this.timerMaps = new System.Windows.Forms.Timer(this.components);
            this.btnMaps = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInsertData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeRe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTraffic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMaps.Properties)).BeginInit();
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
            // btnRemote
            // 
            this.btnRemote.Location = new System.Drawing.Point(78, 10);
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(93, 35);
            this.btnRemote.TabIndex = 0;
            this.btnRemote.Text = "Thông số Remote";
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            // 
            // btnPHY
            // 
            this.btnPHY.Location = new System.Drawing.Point(171, 10);
            this.btnPHY.Name = "btnPHY";
            this.btnPHY.Size = new System.Drawing.Size(79, 35);
            this.btnPHY.TabIndex = 0;
            this.btnPHY.Text = "Thông số PHY";
            this.btnPHY.Click += new System.EventHandler(this.btnPHY_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(3, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Kết nối CMTS";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(607, 10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(99, 35);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Ngắt kết nối CMTS";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // gridItem
            // 
            this.gridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 60);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.ItemCheckStatus});
            this.gridItem.Size = new System.Drawing.Size(1226, 497);
            this.gridItem.TabIndex = 3;
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
            this.colCurrentUS,
            this.colCurrentDS,
            this.colLocation,
            this.colStatus,
            this.gridColumn4});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colValue4;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "ToInt([Value4])<210 And Len([Value4])  > 0";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
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
            this.colIpPublic1.Width = 101;
            // 
            // colIpPublic2
            // 
            this.colIpPublic2.Caption = "IP Public2";
            this.colIpPublic2.FieldName = "IpPublic2";
            this.colIpPublic2.Name = "colIpPublic2";
            this.colIpPublic2.Width = 61;
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
            // colValue2
            // 
            this.colValue2.Caption = "US Tx";
            this.colValue2.FieldName = "Value2";
            this.colValue2.Name = "colValue2";
            this.colValue2.Visible = true;
            this.colValue2.VisibleIndex = 5;
            this.colValue2.Width = 59;
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
            // colCurrentUS
            // 
            this.colCurrentUS.Caption = "CurrentUS";
            this.colCurrentUS.FieldName = "CurrentUS";
            this.colCurrentUS.Name = "colCurrentUS";
            this.colCurrentUS.Visible = true;
            this.colCurrentUS.VisibleIndex = 10;
            // 
            // colCurrentDS
            // 
            this.colCurrentDS.Caption = "CurrentDS";
            this.colCurrentDS.FieldName = "CurrentDS";
            this.colCurrentDS.Name = "colCurrentDS";
            this.colCurrentDS.Visible = true;
            this.colCurrentDS.VisibleIndex = 9;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 1;
            this.colLocation.Width = 116;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.ColumnEdit = this.ItemCheckStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
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
            // btnLoadAll
            // 
            this.btnLoadAll.Location = new System.Drawing.Point(547, 10);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(58, 35);
            this.btnLoadAll.TabIndex = 4;
            this.btnLoadAll.Text = "Tải Dữ liệu";
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // checkInsertData
            // 
            this.checkInsertData.Location = new System.Drawing.Point(706, 11);
            this.checkInsertData.Name = "checkInsertData";
            this.checkInsertData.Properties.Caption = "Insert Data";
            this.checkInsertData.Size = new System.Drawing.Size(86, 19);
            this.checkInsertData.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 32);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Repeat(s)";
            // 
            // txtTimeRe
            // 
            this.txtTimeRe.EditValue = "30";
            this.txtTimeRe.Location = new System.Drawing.Point(147, 14);
            this.txtTimeRe.Name = "txtTimeRe";
            this.txtTimeRe.Size = new System.Drawing.Size(40, 20);
            this.txtTimeRe.TabIndex = 8;
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTime.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(196, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Time: ";
            // 
            // timerRepeat
            // 
            this.timerRepeat.Interval = 1000;
            this.timerRepeat.Tick += new System.EventHandler(this.timerRepeat_Tick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnStart);
            this.panelControl1.Controls.Add(this.txtTimeRe);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblTime);
            this.panelControl1.Location = new System.Drawing.Point(956, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(262, 44);
            this.panelControl1.TabIndex = 9;
            // 
            // btnStartFor10P
            // 
            this.btnStartFor10P.Location = new System.Drawing.Point(879, 9);
            this.btnStartFor10P.Name = "btnStartFor10P";
            this.btnStartFor10P.Size = new System.Drawing.Size(75, 31);
            this.btnStartFor10P.TabIndex = 10;
            this.btnStartFor10P.Text = "Start For 10p";
            this.btnStartFor10P.Click += new System.EventHandler(this.btnStartFor10P_Click);
            // 
            // timer10
            // 
            this.timer10.Interval = 1000;
            this.timer10.Tick += new System.EventHandler(this.timer10_Tick);
            // 
            // checkBW
            // 
            this.checkBW.Location = new System.Drawing.Point(706, 27);
            this.checkBW.Name = "checkBW";
            this.checkBW.Properties.Caption = "Insert BW";
            this.checkBW.Size = new System.Drawing.Size(75, 19);
            this.checkBW.TabIndex = 11;
            this.checkBW.CheckedChanged += new System.EventHandler(this.checkBW_CheckedChanged);
            // 
            // btnSNR
            // 
            this.btnSNR.Location = new System.Drawing.Point(309, 10);
            this.btnSNR.Name = "btnSNR";
            this.btnSNR.Size = new System.Drawing.Size(98, 35);
            this.btnSNR.TabIndex = 4;
            this.btnSNR.Text = "Thông số SNR";
            this.btnSNR.Click += new System.EventHandler(this.btnSNR_Click);
            // 
            // btnLoadIP
            // 
            this.btnLoadIP.Location = new System.Drawing.Point(250, 10);
            this.btnLoadIP.Name = "btnLoadIP";
            this.btnLoadIP.Size = new System.Drawing.Size(58, 35);
            this.btnLoadIP.TabIndex = 4;
            this.btnLoadIP.Text = "Tải IP";
            this.btnLoadIP.Click += new System.EventHandler(this.btnLoadIP_Click);
            // 
            // btnIPPublic
            // 
            this.btnIPPublic.Location = new System.Drawing.Point(408, 10);
            this.btnIPPublic.Name = "btnIPPublic";
            this.btnIPPublic.Size = new System.Drawing.Size(82, 35);
            this.btnIPPublic.TabIndex = 4;
            this.btnIPPublic.Text = "Tải IP Public";
            this.btnIPPublic.Click += new System.EventHandler(this.btnIPPublic_Click);
            // 
            // btnTraffic
            // 
            this.btnTraffic.Location = new System.Drawing.Point(490, 10);
            this.btnTraffic.Name = "btnTraffic";
            this.btnTraffic.Size = new System.Drawing.Size(56, 35);
            this.btnTraffic.TabIndex = 4;
            this.btnTraffic.Text = "Traffic";
            this.btnTraffic.Click += new System.EventHandler(this.btnTraffic_Click);
            // 
            // checkTraffic
            // 
            this.checkTraffic.Location = new System.Drawing.Point(788, 11);
            this.checkTraffic.Name = "checkTraffic";
            this.checkTraffic.Properties.Caption = "Only Traffic";
            this.checkTraffic.Size = new System.Drawing.Size(79, 19);
            this.checkTraffic.TabIndex = 11;
            this.checkTraffic.CheckedChanged += new System.EventHandler(this.checkBW_CheckedChanged);
            // 
            // timer30
            // 
            this.timer30.Interval = 1000;
            this.timer30.Tick += new System.EventHandler(this.timer30_Tick);
            // 
            // checkMaps
            // 
            this.checkMaps.Location = new System.Drawing.Point(788, 28);
            this.checkMaps.Name = "checkMaps";
            this.checkMaps.Properties.Caption = "Maps";
            this.checkMaps.Size = new System.Drawing.Size(79, 19);
            this.checkMaps.TabIndex = 11;
            this.checkMaps.CheckedChanged += new System.EventHandler(this.checkBW_CheckedChanged);
            // 
            // timerMaps
            // 
            this.timerMaps.Interval = 1000;
            this.timerMaps.Tick += new System.EventHandler(this.timerMaps_Tick);
            // 
            // btnMaps
            // 
            this.btnMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaps.Location = new System.Drawing.Point(3, 559);
            this.btnMaps.Name = "btnMaps";
            this.btnMaps.Size = new System.Drawing.Size(80, 32);
            this.btnMaps.TabIndex = 6;
            this.btnMaps.Text = "Maps";
            this.btnMaps.Click += new System.EventHandler(this.btnMaps_Click);
            // 
            // frmSignalRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 593);
            this.Controls.Add(this.btnMaps);
            this.Controls.Add(this.checkMaps);
            this.Controls.Add(this.checkTraffic);
            this.Controls.Add(this.checkBW);
            this.Controls.Add(this.btnStartFor10P);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.checkInsertData);
            this.Controls.Add(this.btnSNR);
            this.Controls.Add(this.btnTraffic);
            this.Controls.Add(this.btnIPPublic);
            this.Controls.Add(this.btnLoadIP);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.gridItem);
            this.Controls.Add(this.btnPHY);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRemote);
            this.Name = "frmSignalRequest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Request Thông Số";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSignalRequest_FormClosed);
            this.Load += new System.EventHandler(this.frmSignalRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInsertData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeRe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTraffic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkMaps.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemote;
        private DevExpress.XtraEditors.SimpleButton btnPHY;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnDisconnect;
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
        private DevExpress.XtraEditors.SimpleButton btnLoadAll;
        private DevExpress.XtraEditors.CheckEdit checkInsertData;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTimeRe;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private System.Windows.Forms.Timer timerRepeat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnStartFor10P;
        private System.Windows.Forms.Timer timer10;
        private DevExpress.XtraEditors.CheckEdit checkBW;
        private DevExpress.XtraEditors.SimpleButton btnSNR;
        private DevExpress.XtraEditors.SimpleButton btnLoadIP;
        private DevExpress.XtraEditors.SimpleButton btnIPPublic;
        private DevExpress.XtraEditors.SimpleButton btnTraffic;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentUS;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentDS;
        private DevExpress.XtraEditors.CheckEdit checkTraffic;
        private System.Windows.Forms.Timer timer30;
        private DevExpress.XtraEditors.CheckEdit checkMaps;
        private System.Windows.Forms.Timer timerMaps;
        private DevExpress.XtraEditors.SimpleButton btnMaps;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}