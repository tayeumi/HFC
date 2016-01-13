namespace HFC.Forms
{
    partial class frmDHCPService_Restart
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
            this.webcontrol = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webcontrol
            // 
            this.webcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webcontrol.Location = new System.Drawing.Point(0, 0);
            this.webcontrol.MinimumSize = new System.Drawing.Size(20, 20);
            this.webcontrol.Name = "webcontrol";
            this.webcontrol.ScrollBarsEnabled = false;
            this.webcontrol.Size = new System.Drawing.Size(607, 355);
            this.webcontrol.TabIndex = 0;
            // 
            // frmDHCPService_Restart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 355);
            this.Controls.Add(this.webcontrol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDHCPService_Restart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DHCPService_Restart";
            this.Load += new System.EventHandler(this.frmDHCPService_Restart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webcontrol;
    }
}