namespace HFC.Forms
{
    partial class frmTraffic
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.ItemCheckStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbThang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMacaddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartDS = new DevExpress.XtraCharts.ChartControl();
            this.chartUS = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
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
            this.repositoryItemPictureEdit1,
            this.ItemCheckStatus,
            this.repositoryItemPictureEdit2,
            this.repositoryItemCheckEdit1});
            this.gridItem.Size = new System.Drawing.Size(485, 370);
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
            this.colDS,
            this.colUS,
            this.gridColumn1,
            this.gridColumn2});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "ToInt([Value4])<210 And Len([Value4])  > 0";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Aqua;
            styleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.White;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "ToFloat([Value2])>54.0 And Len([Value2])  > 0";
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "ToFloat([Value1])<30.0 And Len([Value1])  > 0";
            this.gridItemDetail.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
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
            this.colDatetime.Width = 132;
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
            // colDS
            // 
            this.colDS.Caption = "DS(KB)";
            this.colDS.FieldName = "DS";
            this.colDS.Name = "colDS";
            this.colDS.Visible = true;
            this.colDS.VisibleIndex = 2;
            // 
            // colUS
            // 
            this.colUS.Caption = "US(KB)";
            this.colUS.FieldName = "US";
            this.colUS.Name = "colUS";
            this.colUS.Visible = true;
            this.colUS.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CurrentDS";
            this.gridColumn1.FieldName = "CurrentDS";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CurrentUS";
            this.gridColumn2.FieldName = "CurrentUS";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 105;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = "[Chưa có hình]";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
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
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.InitialImage = global::HFC.Properties.Resources.Action_Chart_Printing_Preview;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tháng:";
            // 
            // cbThang
            // 
            this.cbThang.EditValue = "1";
            this.cbThang.Location = new System.Drawing.Point(74, 12);
            this.cbThang.Name = "cbThang";
            this.cbThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbThang.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang.Size = new System.Drawing.Size(40, 20);
            this.cbThang.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(121, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Năm:";
            // 
            // cbNam
            // 
            this.cbNam.EditValue = "2015";
            this.cbNam.Location = new System.Drawing.Point(152, 12);
            this.cbNam.Name = "cbNam";
            this.cbNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbNam.Properties.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbNam.Size = new System.Drawing.Size(66, 20);
            this.cbNam.TabIndex = 5;
            // 
            // txtMacaddress
            // 
            this.txtMacaddress.Location = new System.Drawing.Point(307, 11);
            this.txtMacaddress.Name = "txtMacaddress";
            this.txtMacaddress.Size = new System.Drawing.Size(106, 20);
            this.txtMacaddress.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(239, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "MacAddress:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(432, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(70, 24);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 43);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridItem);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(677, 370);
            this.splitContainerControl1.SplitterPosition = 485;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.chartDS);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.chartUS);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(186, 370);
            this.splitContainerControl2.SplitterPosition = 175;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // chartDS
            // 
            this.chartDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDS.Location = new System.Drawing.Point(0, 0);
            this.chartDS.Name = "chartDS";
            this.chartDS.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartDS.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartDS.Size = new System.Drawing.Size(186, 175);
            this.chartDS.TabIndex = 5;
            // 
            // chartUS
            // 
            this.chartUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartUS.Location = new System.Drawing.Point(0, 0);
            this.chartUS.Name = "chartUS";
            this.chartUS.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.chartUS.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartUS.Size = new System.Drawing.Size(186, 189);
            this.chartUS.TabIndex = 6;
            // 
            // frmTraffic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 414);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtMacaddress);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmTraffic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Customer Traffic";
            this.Load += new System.EventHandler(this.frmTraffic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colMacAdress;
        private DevExpress.XtraGrid.Columns.GridColumn colDS;
        private DevExpress.XtraGrid.Columns.GridColumn colUS;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbThang;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbNam;
        private DevExpress.XtraEditors.TextEdit txtMacaddress;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraCharts.ChartControl chartDS;
        private DevExpress.XtraCharts.ChartControl chartUS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}