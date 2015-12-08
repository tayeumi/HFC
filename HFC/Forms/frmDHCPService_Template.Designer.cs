namespace HFC.Forms
{
    partial class frmDHCPService_Template
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
            this.txtDHCP = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDHCP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDHCP
            // 
            this.txtDHCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDHCP.Location = new System.Drawing.Point(0, 0);
            this.txtDHCP.Name = "txtDHCP";
            this.txtDHCP.Size = new System.Drawing.Size(634, 416);
            this.txtDHCP.TabIndex = 0;
            // 
            // frmDHCPService_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 416);
            this.Controls.Add(this.txtDHCP);
            this.Name = "frmDHCPService_Template";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmDHCPService_Template";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDHCPService_Template_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtDHCP.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDHCP;
    }
}