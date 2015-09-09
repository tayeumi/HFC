namespace HFC.Forms
{
    partial class frmNodeList_UpdateByPath
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPath = new DevExpress.XtraEditors.MemoEdit();
            this.webControl = new System.Windows.Forms.WebBrowser();
            this.btnViewmaps = new DevExpress.XtraEditors.SimpleButton();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAddlocation = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreviewLine = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 1;
            this.btnClose.Location = new System.Drawing.Point(463, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 29);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ImageIndex = 0;
            this.btnUpdate.Location = new System.Drawing.Point(372, 154);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 29);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(91, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(126, 20);
            this.txtCode.TabIndex = 23;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 13);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "GPS Ảnh hưởng :";
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Mã (<color=red>*</color>):";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Location = new System.Drawing.Point(91, 135);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(141, 13);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Tọa độ cách nhau bằng dấu ;";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(91, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.NullText = "Tọa độ cách nhau bằng dấu ;";
            this.txtPath.Size = new System.Drawing.Size(445, 87);
            this.txtPath.TabIndex = 24;
            // 
            // webControl
            // 
            this.webControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webControl.Location = new System.Drawing.Point(3, 192);
            this.webControl.MinimumSize = new System.Drawing.Size(20, 20);
            this.webControl.Name = "webControl";
            this.webControl.ScriptErrorsSuppressed = true;
            this.webControl.Size = new System.Drawing.Size(549, 20);
            this.webControl.TabIndex = 29;
            this.webControl.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // btnViewmaps
            // 
            this.btnViewmaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewmaps.ImageIndex = 0;
            this.btnViewmaps.Location = new System.Drawing.Point(282, 154);
            this.btnViewmaps.Name = "btnViewmaps";
            this.btnViewmaps.Size = new System.Drawing.Size(87, 29);
            this.btnViewmaps.TabIndex = 25;
            this.btnViewmaps.Text = "Preview(Fill)";
            this.btnViewmaps.Click += new System.EventHandler(this.btnViewmaps_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocation.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblLocation.Location = new System.Drawing.Point(389, 135);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 13);
            this.lblLocation.TabIndex = 28;
            this.lblLocation.TextChanged += new System.EventHandler(this.lblLocation_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAddlocation
            // 
            this.btnAddlocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddlocation.Enabled = false;
            this.btnAddlocation.ImageIndex = 0;
            this.btnAddlocation.Location = new System.Drawing.Point(189, 154);
            this.btnAddlocation.Name = "btnAddlocation";
            this.btnAddlocation.Size = new System.Drawing.Size(87, 29);
            this.btnAddlocation.TabIndex = 25;
            this.btnAddlocation.Text = "Add Location";
            this.btnAddlocation.Click += new System.EventHandler(this.btnAddlocation_Click);
            // 
            // btnPreviewLine
            // 
            this.btnPreviewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewLine.ImageIndex = 0;
            this.btnPreviewLine.Location = new System.Drawing.Point(96, 154);
            this.btnPreviewLine.Name = "btnPreviewLine";
            this.btnPreviewLine.Size = new System.Drawing.Size(87, 29);
            this.btnPreviewLine.TabIndex = 25;
            this.btnPreviewLine.Text = "Preview(Line)";
            this.btnPreviewLine.Click += new System.EventHandler(this.btnPreviewLine_Click);
            // 
            // frmNodeList_UpdateByPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(556, 189);
            this.Controls.Add(this.webControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddlocation);
            this.Controls.Add(this.btnPreviewLine);
            this.Controls.Add(this.btnViewmaps);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNodeList_UpdateByPath";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật Phạm vi sự cố ";
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtPath;
        private System.Windows.Forms.WebBrowser webControl;
        private DevExpress.XtraEditors.SimpleButton btnViewmaps;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnAddlocation;
        private DevExpress.XtraEditors.SimpleButton btnPreviewLine;
    }
}