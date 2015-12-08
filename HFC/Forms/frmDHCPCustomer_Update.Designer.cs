namespace HFC.Forms
{
    partial class frmDHCPCustomer_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDHCPCustomer_Update));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMacAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerAddress = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnUpdateNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboBootfile = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboPoolIp = new DevExpress.XtraEditors.LookUpEdit();
            this.txtIpAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLocation = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBootfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPoolIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "(*) Mac Address:";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Location = new System.Drawing.Point(146, 12);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(254, 20);
            this.txtMacAddress.TabIndex = 0;
            this.txtMacAddress.Validated += new System.EventHandler(this.txtMacAddress_Validated);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(61, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "IP Address:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(39, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(78, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Customer Code:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 110);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Customer Name:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 143);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(92, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Customer Address:";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(146, 74);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(254, 20);
            this.txtCustomerCode.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(146, 106);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(254, 20);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(146, 139);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(254, 20);
            this.txtCustomerAddress.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 1;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(327, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "save.gif");
            this.imageCollection1.Images.SetKeyName(1, "ProgramOff.bmp");
            // 
            // btnUpdateNew
            // 
            this.btnUpdateNew.ImageIndex = 0;
            this.btnUpdateNew.ImageList = this.imageCollection1;
            this.btnUpdateNew.Location = new System.Drawing.Point(236, 249);
            this.btnUpdateNew.Name = "btnUpdateNew";
            this.btnUpdateNew.Size = new System.Drawing.Size(88, 29);
            this.btnUpdateNew.TabIndex = 10;
            this.btnUpdateNew.Text = "Lưu && Thêm";
            this.btnUpdateNew.Click += new System.EventHandler(this.btnUpdateNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageIndex = 0;
            this.btnUpdate.ImageList = this.imageCollection1;
            this.btnUpdate.Location = new System.Drawing.Point(146, 249);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 29);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Lưu && Đóng";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(77, 168);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Bootfile:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(73, 194);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Location:";
            // 
            // cboBootfile
            // 
            this.cboBootfile.Location = new System.Drawing.Point(146, 165);
            this.cboBootfile.Name = "cboBootfile";
            this.cboBootfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBootfile.Properties.Items.AddRange(new object[] {
            "3-512.cfg",
            "5-512000.cfg",
            "7-640000.cfg",
            "10-640000.cfg",
            "full.cfg",
            "test.cfg",
            "auto/offline.bin"});
            this.cboBootfile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBootfile.Size = new System.Drawing.Size(254, 20);
            this.cboBootfile.TabIndex = 6;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(146, 217);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(254, 20);
            this.txtNote.TabIndex = 8;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(72, 220);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(27, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Note:";
            // 
            // cboPoolIp
            // 
            this.cboPoolIp.Location = new System.Drawing.Point(147, 43);
            this.cboPoolIp.Name = "cboPoolIp";
            this.cboPoolIp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPoolIp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PoolIp", "PoolIp")});
            this.cboPoolIp.Properties.NullText = "[Chọn Pool IP]";
            this.cboPoolIp.Size = new System.Drawing.Size(123, 20);
            this.cboPoolIp.TabIndex = 1;
            this.cboPoolIp.EditValueChanged += new System.EventHandler(this.cboPoolIp_EditValueChanged);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(276, 43);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIpAddress.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtIpAddress.Size = new System.Drawing.Size(124, 20);
            this.txtIpAddress.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(146, 191);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLocation.Properties.Items.AddRange(new object[] {
            "BT-01",
            "BT-02",
            "BT-03",
            "BT-05",
            "BT-06",
            "BT-07",
            "BT-11",
            "BT-12",
            "BT-13",
            "BT-14",
            "BT-15",
            "BT-17",
            "BT-19",
            "BT-21",
            "BT-22",
            "BT-24",
            "BT-25",
            "BT-26",
            "BT-27",
            "GV-01",
            "GV-03",
            "GV-04",
            "GV-05",
            "GV-06",
            "GV-07",
            "GV-08",
            "GV-09",
            "GV-10",
            "GV-11",
            "GV-12",
            "GV-13",
            "GV-14",
            "GV-15",
            "GV-16",
            "GV-17",
            "Hiep Binh Chanh",
            "HUB",
            "KY THUAT TEST",
            "LAP MOI",
            "TD-Binh Chieu",
            "TD-Hiep Binh Phuoc",
            "TD-Linh Trung",
            "TD-Truong Tho"});
            this.txtLocation.Size = new System.Drawing.Size(253, 20);
            this.txtLocation.TabIndex = 7;
            // 
            // frmDHCPCustomer_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(479, 292);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.cboPoolIp);
            this.Controls.Add(this.cboBootfile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdateNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.txtMacAddress);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDHCPCustomer_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDHCPCustomer_Update";
            ((System.ComponentModel.ISupportInitialize)(this.txtMacAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBootfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPoolIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMacAddress;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerAddress;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnUpdateNew;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cboBootfile;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit cboPoolIp;
        private DevExpress.XtraEditors.ComboBoxEdit txtIpAddress;
        private DevExpress.XtraEditors.ComboBoxEdit txtLocation;
    }
}