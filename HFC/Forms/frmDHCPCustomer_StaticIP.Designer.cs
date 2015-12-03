namespace HFC.Forms
{
    partial class frmDHCPCustomer_StaticIP
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
            this.txtIpAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboPoolIp = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.btnAddIP = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMacAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPoolIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(118, 51);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIpAddress.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIpAddress.Size = new System.Drawing.Size(213, 20);
            this.txtIpAddress.TabIndex = 1;
            // 
            // cboPoolIp
            // 
            this.cboPoolIp.Location = new System.Drawing.Point(118, 25);
            this.cboPoolIp.Name = "cboPoolIp";
            this.cboPoolIp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPoolIp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PoolIp", "PoolIp")});
            this.cboPoolIp.Properties.NullText = "[Chọn Pool IP]";
            this.cboPoolIp.Size = new System.Drawing.Size(213, 20);
            this.cboPoolIp.TabIndex = 0;
            this.cboPoolIp.EditValueChanged += new System.EventHandler(this.cboPoolIp_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(64, 105);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(27, 13);
            this.labelControl8.TabIndex = 11;
            this.labelControl8.Text = "Note:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Pool Ip:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(119, 102);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(214, 20);
            this.txtNote.TabIndex = 2;
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(247, 139);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(84, 34);
            this.btnAddIP.TabIndex = 4;
            this.btnAddIP.Text = "Lưu";
            this.btnAddIP.Click += new System.EventHandler(this.btnAddIP_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "IP Address:";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Location = new System.Drawing.Point(118, 77);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(214, 20);
            this.txtMacAddress.TabIndex = 2;
            this.txtMacAddress.Validated += new System.EventHandler(this.txtMacAddress_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(63, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "MacPC:";
            // 
            // frmDHCPCustomer_StaticIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 190);
            this.Controls.Add(this.btnAddIP);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.cboPoolIp);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMacAddress);
            this.Controls.Add(this.txtNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDHCPCustomer_StaticIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add IP WAN Static";
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPoolIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacAddress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit txtIpAddress;
        private DevExpress.XtraEditors.LookUpEdit cboPoolIp;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnAddIP;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMacAddress;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}