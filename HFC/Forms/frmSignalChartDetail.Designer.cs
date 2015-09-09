namespace HFC.Forms
{
    partial class frmSignalChartDetail
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnViewLine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSpLine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStepArea = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSplineArea = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRangeArea = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAreaStacked = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            this.chartControl.ContextMenuStrip = this.contextMenuStrip1;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartControl.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartControl.Size = new System.Drawing.Size(647, 463);
            this.chartControl.TabIndex = 0;
            this.chartControl.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl_CustomDrawSeriesPoint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewLine,
            this.btnSpLine,
            this.btnBar,
            this.btnPlot,
            this.btnStepArea,
            this.btnSplineArea,
            this.btnRangeArea,
            this.btnAreaStacked});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 180);
            // 
            // btnViewLine
            // 
            this.btnViewLine.Name = "btnViewLine";
            this.btnViewLine.Size = new System.Drawing.Size(162, 22);
            this.btnViewLine.Text = "Line View";
            this.btnViewLine.Click += new System.EventHandler(this.btnViewLine_Click);
            // 
            // btnSpLine
            // 
            this.btnSpLine.Name = "btnSpLine";
            this.btnSpLine.Size = new System.Drawing.Size(162, 22);
            this.btnSpLine.Text = "Spline View";
            this.btnSpLine.Click += new System.EventHandler(this.btnSpLine_Click);
            // 
            // btnBar
            // 
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(162, 22);
            this.btnBar.Text = "Bar View";
            this.btnBar.Click += new System.EventHandler(this.btnBar_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(162, 22);
            this.btnPlot.Text = "Plot View";
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // btnStepArea
            // 
            this.btnStepArea.Name = "btnStepArea";
            this.btnStepArea.Size = new System.Drawing.Size(162, 22);
            this.btnStepArea.Text = "Step Area View";
            this.btnStepArea.Click += new System.EventHandler(this.btnStepArea_Click);
            // 
            // btnSplineArea
            // 
            this.btnSplineArea.Name = "btnSplineArea";
            this.btnSplineArea.Size = new System.Drawing.Size(162, 22);
            this.btnSplineArea.Text = "Spline Area View";
            this.btnSplineArea.Click += new System.EventHandler(this.btnSplineArea_Click);
            // 
            // btnRangeArea
            // 
            this.btnRangeArea.Name = "btnRangeArea";
            this.btnRangeArea.Size = new System.Drawing.Size(162, 22);
            this.btnRangeArea.Text = "Range Area View";
            this.btnRangeArea.Click += new System.EventHandler(this.btnRangeArea_Click);
            // 
            // btnAreaStacked
            // 
            this.btnAreaStacked.Name = "btnAreaStacked";
            this.btnAreaStacked.Size = new System.Drawing.Size(162, 22);
            this.btnAreaStacked.Text = "Line3D View";
            this.btnAreaStacked.Click += new System.EventHandler(this.btnAreaStacked_Click);
            // 
            // frmSignalChartDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 463);
            this.Controls.Add(this.chartControl);
            this.Name = "frmSignalChartDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Signal Chart Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnViewLine;
        private System.Windows.Forms.ToolStripMenuItem btnSpLine;
        private System.Windows.Forms.ToolStripMenuItem btnBar;
        private System.Windows.Forms.ToolStripMenuItem btnPlot;
        private System.Windows.Forms.ToolStripMenuItem btnStepArea;
        private System.Windows.Forms.ToolStripMenuItem btnSplineArea;
        private System.Windows.Forms.ToolStripMenuItem btnRangeArea;
        private System.Windows.Forms.ToolStripMenuItem btnAreaStacked;
    }
}