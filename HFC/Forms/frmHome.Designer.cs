namespace HFC.Forms
{
    partial class frmHome
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
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel7 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView4 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel8 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView5 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel9 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView6 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel10 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel11 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView5 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel12 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView6 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle4 = new DevExpress.XtraCharts.ChartTitle();
            this.chartDevicePC = new DevExpress.XtraCharts.ChartControl();
            this.cboFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chartInterface = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartDevicePC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInterface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDevicePC
            // 
            this.chartDevicePC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram3.AxisX.Range.ScrollingRange.SideMarginsEnabled = false;
            xyDiagram3.AxisX.Range.SideMarginsEnabled = false;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram3.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            this.chartDevicePC.Diagram = xyDiagram3;
            this.chartDevicePC.Location = new System.Drawing.Point(4, 29);
            this.chartDevicePC.Name = "chartDevicePC";
            pointSeriesLabel7.LineVisible = false;
            series5.Label = pointSeriesLabel7;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.LegendText = "tyy";
            series5.Name = "Series 1";
            series5.View = splineAreaSeriesView4;
            pointSeriesLabel8.LineVisible = true;
            series6.Label = pointSeriesLabel8;
            series6.Name = "Series 2";
            series6.View = splineAreaSeriesView5;
            this.chartDevicePC.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series5,
        series6};
            pointSeriesLabel9.LineVisible = true;
            this.chartDevicePC.SeriesTemplate.Label = pointSeriesLabel9;
            splineAreaSeriesView6.Transparency = ((byte)(0));
            this.chartDevicePC.SeriesTemplate.View = splineAreaSeriesView6;
            this.chartDevicePC.Size = new System.Drawing.Size(702, 158);
            this.chartDevicePC.TabIndex = 6;
            chartTitle3.Text = "BSR 64000 Modems / PCs";
            this.chartDevicePC.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle3});
            // 
            // cboFilter
            // 
            this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilter.EditValue = "24 hour";
            this.cboFilter.Location = new System.Drawing.Point(563, 5);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFilter.Properties.Items.AddRange(new object[] {
            "24 hour",
            "1 month"});
            this.cboFilter.Size = new System.Drawing.Size(138, 20);
            this.cboFilter.TabIndex = 7;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // chartInterface
            // 
            this.chartInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram4.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram4.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram4.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram4.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram4.AxisY.VisibleInPanesSerializable = "-1";
            this.chartInterface.Diagram = xyDiagram4;
            this.chartInterface.Location = new System.Drawing.Point(4, 193);
            this.chartInterface.Name = "chartInterface";
            pointSeriesLabel10.LineVisible = true;
            series7.Label = pointSeriesLabel10;
            series7.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.Name = "Series 1";
            series7.View = lineSeriesView4;
            pointSeriesLabel11.LineVisible = true;
            series8.Label = pointSeriesLabel11;
            series8.Name = "Series 2";
            series8.View = lineSeriesView5;
            this.chartInterface.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7,
        series8};
            pointSeriesLabel12.LineVisible = true;
            this.chartInterface.SeriesTemplate.Label = pointSeriesLabel12;
            this.chartInterface.SeriesTemplate.View = lineSeriesView6;
            this.chartInterface.Size = new System.Drawing.Size(701, 397);
            this.chartInterface.TabIndex = 8;
            chartTitle4.Text = "BSR 64000 Interfaces";
            this.chartInterface.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle4});
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 589);
            this.Controls.Add(this.chartInterface);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.chartDevicePC);
            this.Name = "frmHome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDevicePC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInterface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartDevicePC;
        private DevExpress.XtraEditors.ComboBoxEdit cboFilter;
        private DevExpress.XtraCharts.ChartControl chartInterface;
    }
}