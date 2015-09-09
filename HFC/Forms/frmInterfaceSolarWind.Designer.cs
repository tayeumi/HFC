namespace HFC.Forms
{
    partial class frmInterfaceSolarWind
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInterfaceNameInterfaceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInbps = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutbps = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInBandwidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutBandwidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInPercentUtil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colOutPercentUtil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastSync = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).BeginInit();
            this.SuspendLayout();
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
            this.ItemCheckStatus,
            this.ProgressBar});
            this.gridItem.Size = new System.Drawing.Size(554, 374);
            this.gridItem.TabIndex = 5;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCurrent,
            this.btnLoadAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 48);
            // 
            // btnCurrent
            // 
            this.btnCurrent.Image = global::HFC.Properties.Resources.Action_Navigation_Next_Object;
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(143, 22);
            this.btnCurrent.Text = "Load Current";
            this.btnCurrent.Click += new System.EventHandler(this.btnCurrent_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Image = global::HFC.Properties.Resources.Action_Navigation_Next_Object;
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(143, 22);
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInterfaceNameInterfaceName,
            this.colInbps,
            this.colOutbps,
            this.colInBandwidth,
            this.colOutBandwidth,
            this.colInPercentUtil,
            this.colOutPercentUtil,
            this.colLastSync,
            this.colStrDate,
            this.colStatus});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "ToInt([Value4])<210 And Len([Value4])  > 0";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "ToFloat([Value2])>54.0";
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "ToFloat([Value1])<30.0";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.GroupCount = 1;
            this.gridItemDetail.IndicatorWidth = 50;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridItemDetail.OptionsBehavior.Editable = false;
            this.gridItemDetail.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetail.OptionsView.RowAutoHeight = true;
            this.gridItemDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStrDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridItemDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridItemDetail_CustomDrawRowIndicator);
            this.gridItemDetail.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridItemDetail_CustomRowCellEdit);
            // 
            // colInterfaceNameInterfaceName
            // 
            this.colInterfaceNameInterfaceName.Caption = "Interface Name";
            this.colInterfaceNameInterfaceName.FieldName = "InterfaceName";
            this.colInterfaceNameInterfaceName.Name = "colInterfaceNameInterfaceName";
            this.colInterfaceNameInterfaceName.Visible = true;
            this.colInterfaceNameInterfaceName.VisibleIndex = 0;
            // 
            // colInbps
            // 
            this.colInbps.Caption = "Inbps";
            this.colInbps.FieldName = "Inbps";
            this.colInbps.Name = "colInbps";
            this.colInbps.Visible = true;
            this.colInbps.VisibleIndex = 1;
            // 
            // colOutbps
            // 
            this.colOutbps.Caption = "Outbps";
            this.colOutbps.FieldName = "Outbps";
            this.colOutbps.Name = "colOutbps";
            this.colOutbps.Visible = true;
            this.colOutbps.VisibleIndex = 2;
            // 
            // colInBandwidth
            // 
            this.colInBandwidth.Caption = "InBandwidth";
            this.colInBandwidth.FieldName = "InBandwidth";
            this.colInBandwidth.Name = "colInBandwidth";
            this.colInBandwidth.Visible = true;
            this.colInBandwidth.VisibleIndex = 3;
            // 
            // colOutBandwidth
            // 
            this.colOutBandwidth.Caption = "OutBandwidth";
            this.colOutBandwidth.FieldName = "OutBandwidth";
            this.colOutBandwidth.Name = "colOutBandwidth";
            this.colOutBandwidth.Visible = true;
            this.colOutBandwidth.VisibleIndex = 4;
            // 
            // colInPercentUtil
            // 
            this.colInPercentUtil.Caption = "InPercentUtil";
            this.colInPercentUtil.ColumnEdit = this.ProgressBar;
            this.colInPercentUtil.FieldName = "InPercentUtil";
            this.colInPercentUtil.Name = "colInPercentUtil";
            this.colInPercentUtil.Visible = true;
            this.colInPercentUtil.VisibleIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.ProgressBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ProgressBar.EndColor = System.Drawing.Color.Red;
            this.ProgressBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.ProgressBar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.ProgressBar.ShowTitle = true;
            this.ProgressBar.StartColor = System.Drawing.Color.SpringGreen;
            this.ProgressBar.Step = 2;
            // 
            // colOutPercentUtil
            // 
            this.colOutPercentUtil.Caption = "OutPercentUtil";
            this.colOutPercentUtil.ColumnEdit = this.ProgressBar;
            this.colOutPercentUtil.FieldName = "OutPercentUtil";
            this.colOutPercentUtil.Name = "colOutPercentUtil";
            this.colOutPercentUtil.Visible = true;
            this.colOutPercentUtil.VisibleIndex = 6;
            // 
            // colLastSync
            // 
            this.colLastSync.Caption = "LastSync";
            this.colLastSync.DisplayFormat.FormatString = "dd/MM/yyyy H:m:s";
            this.colLastSync.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colLastSync.FieldName = "LastSync";
            this.colLastSync.Name = "colLastSync";
            this.colLastSync.Visible = true;
            this.colLastSync.VisibleIndex = 7;
            // 
            // colStrDate
            // 
            this.colStrDate.Caption = "DateTime";
            this.colStrDate.FieldName = "StrDate";
            this.colStrDate.Name = "colStrDate";
            this.colStrDate.Visible = true;
            this.colStrDate.VisibleIndex = 8;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
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
            this.ItemCheckStatus.ValueChecked = "1                   ";
            this.ItemCheckStatus.ValueUnchecked = "0                   ";
            // 
            // frmInterfaceSolarWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 374);
            this.Controls.Add(this.gridItem);
            this.Name = "frmInterfaceSolarWind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Interface Bandwidth";
            this.Load += new System.EventHandler(this.frmInterfaceSolarWind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colInterfaceNameInterfaceName;
        private DevExpress.XtraGrid.Columns.GridColumn colInbps;
        private DevExpress.XtraGrid.Columns.GridColumn colOutbps;
        private DevExpress.XtraGrid.Columns.GridColumn colInBandwidth;
        private DevExpress.XtraGrid.Columns.GridColumn colOutBandwidth;
        private DevExpress.XtraGrid.Columns.GridColumn colInPercentUtil;
        private DevExpress.XtraGrid.Columns.GridColumn colOutPercentUtil;
        private DevExpress.XtraGrid.Columns.GridColumn colLastSync;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnLoadAll;
        private System.Windows.Forms.ToolStripMenuItem btnCurrent;
        private DevExpress.XtraGrid.Columns.GridColumn colStrDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}