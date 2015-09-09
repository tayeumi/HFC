namespace HFC.Forms
{
    partial class frmSignalChart
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
            DevExpress.XtraCharts.StackedLineSeriesLabel stackedLineSeriesLabel2 = new DevExpress.XtraCharts.StackedLineSeriesLabel();
            DevExpress.XtraCharts.StackedLineSeriesView stackedLineSeriesView2 = new DevExpress.XtraCharts.StackedLineSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.chartUSSnr = new DevExpress.XtraCharts.ChartControl();
            this.Waiting = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HFC.frmWaiting), true, true);
            this.chartRemote = new DevExpress.XtraCharts.ChartControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThamKhao = new System.Windows.Forms.ToolStripMenuItem();
            this.dateChoose = new DevExpress.XtraEditors.DateEdit();
            this.checkChoose = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUSSnr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateChoose.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChoose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChoose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chartUSSnr
            // 
            this.chartUSSnr.AppearanceNameSerializable = "The Trees";
            this.chartUSSnr.Location = new System.Drawing.Point(7, 353);
            this.chartUSSnr.Name = "chartUSSnr";
            this.chartUSSnr.PaletteName = "Palette 1";
            this.chartUSSnr.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(239)))), ((int)(((byte)(157))))), System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(239)))), ((int)(((byte)(157)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red)}));
            this.chartUSSnr.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            stackedLineSeriesLabel2.LineVisible = true;
            this.chartUSSnr.SeriesTemplate.Label = stackedLineSeriesLabel2;
            this.chartUSSnr.SeriesTemplate.View = stackedLineSeriesView2;
            this.chartUSSnr.Size = new System.Drawing.Size(806, 147);
            this.chartUSSnr.TabIndex = 3;
            this.chartUSSnr.DoubleClick += new System.EventHandler(this.chartUSSnr_DoubleClick);
            // 
            // chartRemote
            // 
            this.chartRemote.Location = new System.Drawing.Point(8, 8);
            this.chartRemote.Name = "chartRemote";
            this.chartRemote.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.chartRemote.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartRemote.Size = new System.Drawing.Size(807, 341);
            this.chartRemote.TabIndex = 4;
            this.chartRemote.DoubleClick += new System.EventHandler(this.chartRemote_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThamKhao});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 26);
            // 
            // btnThamKhao
            // 
            this.btnThamKhao.Name = "btnThamKhao";
            this.btnThamKhao.Size = new System.Drawing.Size(189, 22);
            this.btnThamKhao.Text = "Tham khảo cn-admin";
            this.btnThamKhao.Click += new System.EventHandler(this.btnThamKhao_Click);
            // 
            // dateChoose
            // 
            this.dateChoose.EditValue = null;
            this.dateChoose.Enabled = false;
            this.dateChoose.Location = new System.Drawing.Point(702, 323);
            this.dateChoose.Name = "dateChoose";
            this.dateChoose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChoose.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateChoose.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateChoose.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateChoose.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateChoose.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateChoose.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateChoose.Size = new System.Drawing.Size(105, 20);
            this.dateChoose.TabIndex = 5;
            this.dateChoose.EditValueChanged += new System.EventHandler(this.dateChoose_EditValueChanged);
            // 
            // checkChoose
            // 
            this.checkChoose.Location = new System.Drawing.Point(701, 300);
            this.checkChoose.Name = "checkChoose";
            this.checkChoose.Properties.Caption = "Chọn 1 ngày";
            this.checkChoose.Size = new System.Drawing.Size(107, 19);
            this.checkChoose.TabIndex = 7;
            this.checkChoose.CheckedChanged += new System.EventHandler(this.checkChoose_CheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(701, 280);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Online Only";
            this.checkEdit1.Size = new System.Drawing.Size(107, 19);
            this.checkEdit1.TabIndex = 7;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // frmSignalChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 505);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.checkChoose);
            this.Controls.Add(this.dateChoose);
            this.Controls.Add(this.chartRemote);
            this.Controls.Add(this.chartUSSnr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSignalChart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart For Device";
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUSSnr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemote)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateChoose.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChoose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkChoose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartUSSnr;
        private DevExpress.XtraCharts.ChartControl chartRemote;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnThamKhao;
        private DevExpress.XtraEditors.DateEdit dateChoose;
        private DevExpress.XtraEditors.CheckEdit checkChoose;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager Waiting;
    }
}