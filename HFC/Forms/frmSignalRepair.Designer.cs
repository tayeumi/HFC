namespace HFC.Forms
{
    partial class frmSignalRepair
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignalRepair));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridSNRValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOffline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.txtDevice = new DevExpress.XtraBars.BarEditItem();
            this.txtDeviceDetail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnRemote = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnAuto = new DevExpress.XtraBars.BarButtonItem();
            this.checkRemote = new DevExpress.XtraBars.BarCheckItem();
            this.checkPhy = new DevExpress.XtraBars.BarCheckItem();
            this.checkIpPublic = new DevExpress.XtraBars.BarCheckItem();
            this.btnGetme = new DevExpress.XtraBars.BarButtonItem();
            this.btnStopCMTS = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridSNR = new DevExpress.XtraGrid.GridControl();
            this.gridSNRDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSNRInterfaceController = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTimeUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridNodeStatus = new DevExpress.XtraGrid.GridControl();
            this.gridNodeStatusDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.groupItem = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.radioRemote = new DevExpress.XtraEditors.RadioGroup();
            this.gridItemRemote = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetailRemote = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCardInfoRemote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemoteGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCapnhattuModem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXemWebParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddtoNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLog1Thang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBieudo1Thang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnResetModem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistrict = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPrivate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPublic1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpPublic2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.timerCountNotUse = new System.Windows.Forms.Timer(this.components);
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.timerNhieu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSNRDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNodeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNodeStatusDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupItem)).BeginInit();
            this.groupItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioRemote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemRemote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetailRemote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSNRValue
            // 
            this.gridSNRValue.Caption = "Value";
            this.gridSNRValue.FieldName = "Signal";
            this.gridSNRValue.Name = "gridSNRValue";
            this.gridSNRValue.Visible = true;
            this.gridSNRValue.VisibleIndex = 1;
            this.gridSNRValue.Width = 42;
            // 
            // colOnline
            // 
            this.colOnline.Caption = "Online";
            this.colOnline.FieldName = "Value1";
            this.colOnline.Name = "colOnline";
            this.colOnline.Visible = true;
            this.colOnline.VisibleIndex = 1;
            this.colOnline.Width = 45;
            // 
            // colValue4
            // 
            this.colValue4.Caption = "US SNR";
            this.colValue4.FieldName = "Value4";
            this.colValue4.Name = "colValue4";
            this.colValue4.OptionsColumn.AllowEdit = false;
            this.colValue4.Visible = true;
            this.colValue4.VisibleIndex = 6;
            this.colValue4.Width = 61;
            // 
            // colValue2
            // 
            this.colValue2.Caption = "US Tx";
            this.colValue2.FieldName = "Value2";
            this.colValue2.Name = "colValue2";
            this.colValue2.OptionsColumn.ReadOnly = true;
            this.colValue2.Visible = true;
            this.colValue2.VisibleIndex = 4;
            this.colValue2.Width = 59;
            // 
            // colValue1
            // 
            this.colValue1.Caption = "DS SNR";
            this.colValue1.FieldName = "Value1";
            this.colValue1.Name = "colValue1";
            this.colValue1.OptionsColumn.ReadOnly = true;
            this.colValue1.Visible = true;
            this.colValue1.VisibleIndex = 3;
            this.colValue1.Width = 65;
            // 
            // colOffline
            // 
            this.colOffline.Caption = "Offline";
            this.colOffline.FieldName = "Value2";
            this.colOffline.Name = "colOffline";
            this.colOffline.Visible = true;
            this.colOffline.VisibleIndex = 2;
            this.colOffline.Width = 46;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnConnect,
            this.txtDevice,
            this.btnRemote,
            this.btnLoadCustomer,
            this.btnAuto,
            this.checkRemote,
            this.checkPhy,
            this.checkIpPublic,
            this.btnGetme,
            this.btnStopCMTS});
            this.barManager1.MaxItemId = 16;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtDeviceDetail});
            this.barManager1.StatusBar = this.barMenu;
            // 
            // barMenu
            // 
            this.barMenu.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barMenu.BarAppearance.Normal.Options.UseFont = true;
            this.barMenu.BarName = "Status bar";
            this.barMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnConnect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtDevice, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRemote, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLoadCustomer, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAuto, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.checkRemote),
            new DevExpress.XtraBars.LinkPersistInfo(this.checkPhy),
            new DevExpress.XtraBars.LinkPersistInfo(this.checkIpPublic),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGetme, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnStopCMTS, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DrawDragBorder = false;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Status bar";
            // 
            // btnConnect
            // 
            this.btnConnect.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnConnect.Caption = "Kết nối CMTS";
            this.btnConnect.Id = 1;
            this.btnConnect.ImageIndex = 3;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Tag = "";
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // txtDevice
            // 
            this.txtDevice.Caption = "Nhập Mac vào đây..";
            this.txtDevice.Edit = this.txtDeviceDetail;
            this.txtDevice.Id = 6;
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Width = 100;
            // 
            // txtDeviceDetail
            // 
            this.txtDeviceDetail.AutoHeight = false;
            this.txtDeviceDetail.Name = "txtDeviceDetail";
            this.txtDeviceDetail.NullText = "Nhập địa chỉ Mac";
            this.txtDeviceDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeviceDetail_KeyDown);
            this.txtDeviceDetail.Leave += new System.EventHandler(this.txtDeviceDetail_Leave);
            // 
            // btnRemote
            // 
            this.btnRemote.Caption = "Show Signals";
            this.btnRemote.Id = 7;
            this.btnRemote.ImageIndex = 4;
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemote_ItemClick);
            // 
            // btnLoadCustomer
            // 
            this.btnLoadCustomer.Caption = "Tải thông tin khách hàng";
            this.btnLoadCustomer.Id = 9;
            this.btnLoadCustomer.ImageIndex = 2;
            this.btnLoadCustomer.Name = "btnLoadCustomer";
            this.btnLoadCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadCustomer_ItemClick);
            // 
            // btnAuto
            // 
            this.btnAuto.Caption = "Tự tải thông số";
            this.btnAuto.Id = 10;
            this.btnAuto.ImageIndex = 7;
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAuto_ItemClick);
            // 
            // checkRemote
            // 
            this.checkRemote.Caption = "(Remote";
            this.checkRemote.Id = 11;
            this.checkRemote.Name = "checkRemote";
            // 
            // checkPhy
            // 
            this.checkPhy.Caption = "Phy";
            this.checkPhy.Id = 12;
            this.checkPhy.Name = "checkPhy";
            // 
            // checkIpPublic
            // 
            this.checkIpPublic.Caption = "IpPublic)";
            this.checkIpPublic.Id = 13;
            this.checkIpPublic.Name = "checkIpPublic";
            // 
            // btnGetme
            // 
            this.btnGetme.Caption = "Get Me";
            this.btnGetme.Id = 14;
            this.btnGetme.ImageIndex = 6;
            this.btnGetme.Name = "btnGetme";
            this.btnGetme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGetme_ItemClick);
            // 
            // btnStopCMTS
            // 
            this.btnStopCMTS.Caption = "Stop CMTS";
            this.btnStopCMTS.Id = 15;
            this.btnStopCMTS.ImageIndex = 8;
            this.btnStopCMTS.Name = "btnStopCMTS";
            this.btnStopCMTS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStopCMTS_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(698, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 392);
            this.barDockControlBottom.Size = new System.Drawing.Size(698, 59);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(698, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(199)))), ((int)(((byte)(216)))));
            this.hideContainerRight.Controls.Add(this.dockPanel1);
            this.hideContainerRight.Controls.Add(this.dockPanel2);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(675, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(23, 392);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("dcee7b4d-f54e-42df-bbcb-2c04ac597dbb");
            this.dockPanel1.Location = new System.Drawing.Point(344, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(250, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(250, 383);
            this.dockPanel1.Text = "SNR Total";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridSNR);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(244, 356);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridSNR
            // 
            this.gridSNR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSNR.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridSNR.Location = new System.Drawing.Point(0, 0);
            this.gridSNR.MainView = this.gridSNRDetail;
            this.gridSNR.Name = "gridSNR";
            this.gridSNR.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit3});
            this.gridSNR.Size = new System.Drawing.Size(244, 356);
            this.gridSNR.TabIndex = 1;
            this.gridSNR.UseEmbeddedNavigator = true;
            this.gridSNR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSNRDetail});
            // 
            // gridSNRDetail
            // 
            this.gridSNRDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridSNRInterfaceController,
            this.gridSNRValue,
            this.gridTimeUpdate});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridSNRValue;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "ToFloat([Signal]) < 20.0 And Len([Signal] )>3";
            this.gridSNRDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridSNRDetail.GridControl = this.gridSNR;
            this.gridSNRDetail.Name = "gridSNRDetail";
            this.gridSNRDetail.OptionsBehavior.Editable = false;
            this.gridSNRDetail.OptionsCustomization.AllowFilter = false;
            this.gridSNRDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridSNRDetail.OptionsView.RowAutoHeight = true;
            this.gridSNRDetail.OptionsView.ShowGroupPanel = false;
            this.gridSNRDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // gridSNRInterfaceController
            // 
            this.gridSNRInterfaceController.Caption = "Card Info";
            this.gridSNRInterfaceController.FieldName = "InterfaceController";
            this.gridSNRInterfaceController.Name = "gridSNRInterfaceController";
            this.gridSNRInterfaceController.Visible = true;
            this.gridSNRInterfaceController.VisibleIndex = 0;
            this.gridSNRInterfaceController.Width = 66;
            // 
            // gridTimeUpdate
            // 
            this.gridTimeUpdate.Caption = "Time Update";
            this.gridTimeUpdate.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.gridTimeUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridTimeUpdate.FieldName = "Datetime";
            this.gridTimeUpdate.Name = "gridTimeUpdate";
            this.gridTimeUpdate.Visible = true;
            this.gridTimeUpdate.VisibleIndex = 2;
            this.gridTimeUpdate.Width = 118;
            // 
            // repositoryItemPictureEdit3
            // 
            this.repositoryItemPictureEdit3.CustomHeight = 105;
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            this.repositoryItemPictureEdit3.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit3.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.ID = new System.Guid("c978471f-151f-4008-9711-62d9292dca0f");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(260, 200);
            this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel2.SavedIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(260, 390);
            this.dockPanel2.Text = "Node Status";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.gridNodeStatus);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(252, 363);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gridNodeStatus
            // 
            this.gridNodeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNodeStatus.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridNodeStatus.Location = new System.Drawing.Point(0, 0);
            this.gridNodeStatus.MainView = this.gridNodeStatusDetail;
            this.gridNodeStatus.Name = "gridNodeStatus";
            this.gridNodeStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit4,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.gridNodeStatus.Size = new System.Drawing.Size(252, 363);
            this.gridNodeStatus.TabIndex = 4;
            this.gridNodeStatus.UseEmbeddedNavigator = true;
            this.gridNodeStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNodeStatusDetail});
            // 
            // gridNodeStatusDetail
            // 
            this.gridNodeStatusDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOffline,
            this.colOnline,
            this.colNodeName});
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colOnline;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "0";
            this.gridNodeStatusDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
            this.gridNodeStatusDetail.GridControl = this.gridNodeStatus;
            this.gridNodeStatusDetail.IndicatorWidth = 10;
            this.gridNodeStatusDetail.Name = "gridNodeStatusDetail";
            this.gridNodeStatusDetail.OptionsBehavior.Editable = false;
            this.gridNodeStatusDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridNodeStatusDetail.OptionsSelection.MultiSelect = true;
            this.gridNodeStatusDetail.OptionsView.ColumnAutoWidth = false;
            this.gridNodeStatusDetail.OptionsView.RowAutoHeight = true;
            this.gridNodeStatusDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridNodeStatusDetail.OptionsView.ShowGroupPanel = false;
            this.gridNodeStatusDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // colNodeName
            // 
            this.colNodeName.Caption = "Node";
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.Visible = true;
            this.colNodeName.VisibleIndex = 0;
            this.colNodeName.Width = 133;
            // 
            // repositoryItemPictureEdit4
            // 
            this.repositoryItemPictureEdit4.CustomHeight = 105;
            this.repositoryItemPictureEdit4.Name = "repositoryItemPictureEdit4";
            this.repositoryItemPictureEdit4.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit4.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.PictureChecked = global::HFC.Properties.Resources._15;
            this.repositoryItemCheckEdit2.PictureGrayed = global::HFC.Properties.Resources.offline;
            this.repositoryItemCheckEdit2.PictureUnchecked = global::HFC.Properties.Resources._16;
            this.repositoryItemCheckEdit2.ValueChecked = "online";
            this.repositoryItemCheckEdit2.ValueUnchecked = "offline";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.PictureChecked = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemCheckEdit3.PictureGrayed = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemCheckEdit3.PictureUnchecked = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_mode.png");
            this.imageCollection1.Images.SetKeyName(1, "del_mode.png");
            this.imageCollection1.Images.SetKeyName(2, "edit_mode.png");
            this.imageCollection1.Images.SetKeyName(3, "wifi_connect.png");
            this.imageCollection1.Images.SetKeyName(4, "download(1).png");
            this.imageCollection1.Images.SetKeyName(5, "download.png");
            this.imageCollection1.Images.SetKeyName(6, "download_manager.png");
            this.imageCollection1.Images.SetKeyName(7, "timer.png");
            this.imageCollection1.Images.SetKeyName(8, "Action_Exit.png");
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // groupItem
            // 
            this.groupItem.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupItem.AppearanceCaption.Options.UseFont = true;
            this.groupItem.Controls.Add(this.splitContainerControl1);
            this.groupItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupItem.Location = new System.Drawing.Point(0, 0);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(675, 392);
            this.groupItem.TabIndex = 22;
            this.groupItem.Text = "Giám sát Thiết bị ( Nhiễu )";
            this.groupItem.DoubleClick += new System.EventHandler(this.groupItem_DoubleClick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 16);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(671, 374);
            this.splitContainerControl1.SplitterPosition = 192;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(192, 374);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.radioRemote);
            this.xtraTabPage1.Controls.Add(this.gridItemRemote);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(190, 341);
            this.xtraTabPage1.Text = "Interface Signal";
            // 
            // radioRemote
            // 
            this.radioRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioRemote.EditValue = "All";
            this.radioRemote.Location = new System.Drawing.Point(10, 308);
            this.radioRemote.MenuManager = this.barManager1;
            this.radioRemote.Name = "radioRemote";
            this.radioRemote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioRemote.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("All", "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Remote", "Remote"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("PHY", "PHY")});
            this.radioRemote.Size = new System.Drawing.Size(184, 25);
            this.radioRemote.TabIndex = 3;
            // 
            // gridItemRemote
            // 
            this.gridItemRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemRemote.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItemRemote.Location = new System.Drawing.Point(1, 3);
            this.gridItemRemote.MainView = this.gridItemDetailRemote;
            this.gridItemRemote.Name = "gridItemRemote";
            this.gridItemRemote.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItemRemote.Size = new System.Drawing.Size(190, 305);
            this.gridItemRemote.TabIndex = 1;
            this.gridItemRemote.UseEmbeddedNavigator = true;
            this.gridItemRemote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetailRemote});
            // 
            // gridItemDetailRemote
            // 
            this.gridItemDetailRemote.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCardInfoRemote,
            this.colRemoteGroup});
            this.gridItemDetailRemote.GridControl = this.gridItemRemote;
            this.gridItemDetailRemote.GroupCount = 1;
            this.gridItemDetailRemote.Name = "gridItemDetailRemote";
            this.gridItemDetailRemote.OptionsBehavior.Editable = false;
            this.gridItemDetailRemote.OptionsCustomization.AllowFilter = false;
            this.gridItemDetailRemote.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetailRemote.OptionsView.RowAutoHeight = true;
            this.gridItemDetailRemote.OptionsView.ShowGroupPanel = false;
            this.gridItemDetailRemote.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetailRemote.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRemoteGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridItemDetailRemote.DoubleClick += new System.EventHandler(this.gridItemDetailRemote_DoubleClick);
            // 
            // colCardInfoRemote
            // 
            this.colCardInfoRemote.Caption = "Card Info";
            this.colCardInfoRemote.FieldName = "Interface";
            this.colCardInfoRemote.Name = "colCardInfoRemote";
            this.colCardInfoRemote.Visible = true;
            this.colCardInfoRemote.VisibleIndex = 0;
            this.colCardInfoRemote.Width = 93;
            // 
            // colRemoteGroup
            // 
            this.colRemoteGroup.Caption = "Card";
            this.colRemoteGroup.FieldName = "SignalGroup";
            this.colRemoteGroup.Name = "colRemoteGroup";
            this.colRemoteGroup.Visible = true;
            this.colRemoteGroup.VisibleIndex = 1;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gridItem
            // 
            this.gridItem.ContextMenuStrip = this.contextMenuStrip1;
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.ItemCheckStatus,
            this.repositoryItemPictureEdit2,
            this.repositoryItemCheckEdit1});
            this.gridItem.Size = new System.Drawing.Size(473, 374);
            this.gridItem.TabIndex = 2;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCapnhattuModem,
            this.btnXemWebParameter,
            this.btnExportExcel,
            this.toolStripMenuItem1,
            this.btnCheckAll,
            this.btnUncheckAll,
            this.btnAddtoNode,
            this.toolStripMenuItem2,
            this.btnLog1Thang,
            this.btnBieudo1Thang,
            this.toolStripMenuItem4,
            this.btnResetModem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 242);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnCapnhattuModem
            // 
            this.btnCapnhattuModem.Image = global::HFC.Properties.Resources.BO_StateMachine_32x32;
            this.btnCapnhattuModem.Name = "btnCapnhattuModem";
            this.btnCapnhattuModem.Size = new System.Drawing.Size(189, 22);
            this.btnCapnhattuModem.Text = "Cập nhật từ modem";
            this.btnCapnhattuModem.Click += new System.EventHandler(this.btnCapnhattuModem_Click);
            // 
            // btnXemWebParameter
            // 
            this.btnXemWebParameter.Name = "btnXemWebParameter";
            this.btnXemWebParameter.Size = new System.Drawing.Size(189, 22);
            this.btnXemWebParameter.Text = "Xem Web KH";
            this.btnXemWebParameter.Click += new System.EventHandler(this.btnXemIpPrivate_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::HFC.Properties.Resources.Excel;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(189, 22);
            this.btnExportExcel.Text = "Export to Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(189, 22);
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(189, 22);
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnAddtoNode
            // 
            this.btnAddtoNode.Image = global::HFC.Properties.Resources.Action_Navigation_History_Forward;
            this.btnAddtoNode.Name = "btnAddtoNode";
            this.btnAddtoNode.Size = new System.Drawing.Size(189, 22);
            this.btnAddtoNode.Text = "Add Selected to Node";
            this.btnAddtoNode.Click += new System.EventHandler(this.btnAddtoNode_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // btnLog1Thang
            // 
            this.btnLog1Thang.Image = global::HFC.Properties.Resources.offline;
            this.btnLog1Thang.Name = "btnLog1Thang";
            this.btnLog1Thang.Size = new System.Drawing.Size(189, 22);
            this.btnLog1Thang.Text = "Xem Log 1 tháng";
            this.btnLog1Thang.Click += new System.EventHandler(this.btnLog1Thang_Click);
            // 
            // btnBieudo1Thang
            // 
            this.btnBieudo1Thang.Image = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.btnBieudo1Thang.Name = "btnBieudo1Thang";
            this.btnBieudo1Thang.Size = new System.Drawing.Size(189, 22);
            this.btnBieudo1Thang.Text = "Xem biểu đồ 1 tháng";
            this.btnBieudo1Thang.Click += new System.EventHandler(this.btnBieudo1Thang_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(186, 6);
            // 
            // btnResetModem
            // 
            this.btnResetModem.Name = "btnResetModem";
            this.btnResetModem.Size = new System.Drawing.Size(189, 22);
            this.btnResetModem.Text = "Reset Modem";
            this.btnResetModem.Click += new System.EventHandler(this.btnResetModem_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatetime,
            this.colMacAdress,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colWard,
            this.colDistrict,
            this.colCustomerTelephone,
            this.colIpPrivate,
            this.colIpPublic1,
            this.colIpPublic2,
            this.colValue1,
            this.colValue2,
            this.colValue3,
            this.colValue4,
            this.colLocation,
            this.colStatus,
            this.gridColumn4,
            this.colChecked,
            this.colChart,
            this.colOn});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colValue4;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "ToInt([Value4])<210 And Len([Value4])  > 0";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Aqua;
            styleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.White;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colValue2;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "ToFloat([Value2])>54.0 And Len([Value2])  > 0";
            styleFormatCondition5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            styleFormatCondition5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            styleFormatCondition5.Appearance.Options.UseFont = true;
            styleFormatCondition5.Appearance.Options.UseForeColor = true;
            styleFormatCondition5.ApplyToRow = true;
            styleFormatCondition5.Column = this.colValue1;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition5.Expression = "ToFloat([Value1])<30.0 And Len([Value1])  > 0";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.IndicatorWidth = 50;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsSelection.MultiSelect = true;
            this.gridItemDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridItemDetail.OptionsView.ColumnAutoWidth = false;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            this.gridItemDetail.DoubleClick += new System.EventHandler(this.gridItemDetail_DoubleClick);
            // 
            // colDatetime
            // 
            this.colDatetime.Caption = "Date";
            this.colDatetime.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.colDatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatetime.FieldName = "DateTime";
            this.colDatetime.Name = "colDatetime";
            this.colDatetime.OptionsColumn.AllowEdit = false;
            this.colDatetime.Visible = true;
            this.colDatetime.VisibleIndex = 0;
            this.colDatetime.Width = 114;
            // 
            // colMacAdress
            // 
            this.colMacAdress.Caption = "Địa chỉ MAC Adress";
            this.colMacAdress.FieldName = "MacAddress";
            this.colMacAdress.Name = "colMacAdress";
            this.colMacAdress.OptionsColumn.AllowEdit = false;
            this.colMacAdress.Visible = true;
            this.colMacAdress.VisibleIndex = 1;
            this.colMacAdress.Width = 147;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Khách hàng";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.Width = 137;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Caption = "Địa chỉ";
            this.colCustomerAddress.FieldName = "CustomerAddress";
            this.colCustomerAddress.Name = "colCustomerAddress";
            this.colCustomerAddress.OptionsColumn.AllowEdit = false;
            this.colCustomerAddress.Width = 140;
            // 
            // colWard
            // 
            this.colWard.Caption = "Phường";
            this.colWard.FieldName = "Ward";
            this.colWard.Name = "colWard";
            this.colWard.OptionsColumn.AllowEdit = false;
            // 
            // colDistrict
            // 
            this.colDistrict.Caption = "Quận";
            this.colDistrict.FieldName = "District";
            this.colDistrict.Name = "colDistrict";
            this.colDistrict.OptionsColumn.AllowEdit = false;
            // 
            // colCustomerTelephone
            // 
            this.colCustomerTelephone.Caption = "Điện thoại";
            this.colCustomerTelephone.FieldName = "CustomerTelephone";
            this.colCustomerTelephone.Name = "colCustomerTelephone";
            this.colCustomerTelephone.OptionsColumn.AllowEdit = false;
            this.colCustomerTelephone.Width = 98;
            // 
            // colIpPrivate
            // 
            this.colIpPrivate.Caption = "IP Private";
            this.colIpPrivate.FieldName = "IpPrivate";
            this.colIpPrivate.Name = "colIpPrivate";
            this.colIpPrivate.OptionsColumn.ReadOnly = true;
            this.colIpPrivate.Visible = true;
            this.colIpPrivate.VisibleIndex = 2;
            this.colIpPrivate.Width = 135;
            // 
            // colIpPublic1
            // 
            this.colIpPublic1.Caption = "IP Public1";
            this.colIpPublic1.FieldName = "IpPublic1";
            this.colIpPublic1.Name = "colIpPublic1";
            this.colIpPublic1.OptionsColumn.AllowEdit = false;
            this.colIpPublic1.Width = 101;
            // 
            // colIpPublic2
            // 
            this.colIpPublic2.Caption = "Mac PC";
            this.colIpPublic2.FieldName = "IpPublic2";
            this.colIpPublic2.Name = "colIpPublic2";
            this.colIpPublic2.OptionsColumn.AllowEdit = false;
            this.colIpPublic2.Width = 61;
            // 
            // colValue3
            // 
            this.colValue3.Caption = "DS Rx";
            this.colValue3.FieldName = "Value3";
            this.colValue3.Name = "colValue3";
            this.colValue3.OptionsColumn.ReadOnly = true;
            this.colValue3.Visible = true;
            this.colValue3.VisibleIndex = 5;
            this.colValue3.Width = 59;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.AllowEdit = false;
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 7;
            this.colLocation.Width = 116;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.ColumnEdit = this.ItemCheckStatus;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
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
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Width = 147;
            // 
            // colChecked
            // 
            this.colChecked.Caption = "Checked";
            this.colChecked.FieldName = "Checked";
            this.colChecked.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colChecked.Name = "colChecked";
            this.colChecked.OptionsFilter.AllowAutoFilter = false;
            this.colChecked.OptionsFilter.AllowFilter = false;
            this.colChecked.Visible = true;
            this.colChecked.VisibleIndex = 10;
            this.colChecked.Width = 58;
            // 
            // colChart
            // 
            this.colChart.Caption = "Chart";
            this.colChart.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colChart.FieldName = "Chart";
            this.colChart.Name = "colChart";
            this.colChart.OptionsColumn.AllowEdit = false;
            this.colChart.Visible = true;
            this.colChart.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.PictureChecked = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemCheckEdit1.PictureGrayed = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemCheckEdit1.PictureUnchecked = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            // 
            // colOn
            // 
            this.colOn.Caption = "Tình trạng";
            this.colOn.FieldName = "Status";
            this.colOn.Name = "colOn";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 105;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.InitialImage = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // timerAuto
            // 
            this.timerAuto.Interval = 10000;
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // timerCountNotUse
            // 
            this.timerCountNotUse.Interval = 1000;
            this.timerCountNotUse.Tick += new System.EventHandler(this.timerCountNotUse_Tick);
            // 
            // alertControl
            // 
            this.alertControl.AllowHtmlText = true;
            this.alertControl.AutoHeight = true;
            // 
            // timerNhieu
            // 
            this.timerNhieu.Interval = 60000;
            this.timerNhieu.Tick += new System.EventHandler(this.timerNhieu_Tick);
            // 
            // frmSignalRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 451);
            this.Controls.Add(this.groupItem);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frmSignalRepair";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sửa nhiễu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSignalRepair_FormClosed);
            this.Load += new System.EventHandler(this.frmSignalRepair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSNRDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNodeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNodeStatusDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupItem)).EndInit();
            this.groupItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioRemote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemRemote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetailRemote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem btnConnect;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupItem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridItemRemote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetailRemote;
        private DevExpress.XtraGrid.Columns.GridColumn colCardInfoRemote;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colMacAdress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerAddress;
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
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoteGroup;
        private DevExpress.XtraBars.BarEditItem txtDevice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtDeviceDetail;
        private DevExpress.XtraBars.BarButtonItem btnRemote;
        private DevExpress.XtraEditors.RadioGroup radioRemote;
        private DevExpress.XtraBars.BarButtonItem btnLoadCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colWard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrict;
        private DevExpress.XtraGrid.Columns.GridColumn colChecked;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnAddtoNode;
        private DevExpress.XtraGrid.Columns.GridColumn colChart;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colOn;
        private DevExpress.XtraBars.BarButtonItem btnAuto;
        private System.Windows.Forms.Timer timerAuto;
        private DevExpress.XtraBars.BarCheckItem checkRemote;
        private DevExpress.XtraBars.BarCheckItem checkPhy;
        private DevExpress.XtraBars.BarCheckItem checkIpPublic;
        private DevExpress.XtraBars.BarButtonItem btnGetme;
        private DevExpress.XtraBars.BarButtonItem btnStopCMTS;
        private System.Windows.Forms.Timer timerCountNotUse;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private System.Windows.Forms.Timer timerNhieu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btnLog1Thang;
        private System.Windows.Forms.ToolStripMenuItem btnBieudo1Thang;
        private System.Windows.Forms.ToolStripMenuItem btnCheckAll;
        private System.Windows.Forms.ToolStripMenuItem btnUncheckAll;
        private System.Windows.Forms.ToolStripMenuItem btnXemWebParameter;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridSNR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSNRDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridSNRInterfaceController;
        private DevExpress.XtraGrid.Columns.GridColumn gridSNRValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridTimeUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit3;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraGrid.GridControl gridNodeStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridNodeStatusDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colOffline;
        private DevExpress.XtraGrid.Columns.GridColumn colOnline;
        private DevExpress.XtraGrid.Columns.GridColumn colNodeName;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private System.Windows.Forms.ToolStripMenuItem btnCapnhattuModem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem btnResetModem;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}