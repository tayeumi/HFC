namespace HFC
{
    partial class frmintro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmintro));
            this.IntroTime = new System.Windows.Forms.Timer(this.components);
            this.Checkfile = new System.Windows.Forms.Timer(this.components);
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblfile = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PicLoad = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSLFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // IntroTime
            // 
            this.IntroTime.Interval = 1000;
            this.IntroTime.Tick += new System.EventHandler(this.IntroTime_Tick);
            // 
            // Checkfile
            // 
            this.Checkfile.Tick += new System.EventHandler(this.Checkfile_Tick);
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.BackColor = System.Drawing.Color.Transparent;
            this.lblCheck.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCheck.Location = new System.Drawing.Point(28, 199);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(243, 16);
            this.lblCheck.TabIndex = 0;
            this.lblCheck.Text = " Checking ...                                       ";
            // 
            // lblfile
            // 
            this.lblfile.AutoSize = true;
            this.lblfile.BackColor = System.Drawing.Color.Transparent;
            this.lblfile.Location = new System.Drawing.Point(90, 201);
            this.lblfile.Name = "lblfile";
            this.lblfile.Size = new System.Drawing.Size(0, 13);
            this.lblfile.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 220);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(217, 24);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // PicLoad
            // 
            this.PicLoad.Image = ((System.Drawing.Image)(resources.GetObject("PicLoad.Image")));
            this.PicLoad.Location = new System.Drawing.Point(9, 198);
            this.PicLoad.Name = "PicLoad";
            this.PicLoad.Size = new System.Drawing.Size(18, 18);
            this.PicLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLoad.TabIndex = 5;
            this.PicLoad.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(503, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSLFile
            // 
            this.lblSLFile.AutoSize = true;
            this.lblSLFile.BackColor = System.Drawing.Color.Transparent;
            this.lblSLFile.ForeColor = System.Drawing.Color.Green;
            this.lblSLFile.Location = new System.Drawing.Point(233, 225);
            this.lblSLFile.Name = "lblSLFile";
            this.lblSLFile.Size = new System.Drawing.Size(0, 13);
            this.lblSLFile.TabIndex = 7;
            // 
            // frmintro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HFC.Properties.Resources.b_g1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(389, 251);
            this.Controls.Add(this.lblSLFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.PicLoad);
            this.Controls.Add(this.lblfile);
            this.Controls.Add(this.lblCheck);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmintro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmintro_FormClosed);
            this.Load += new System.EventHandler(this.frmintro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer IntroTime;
        private System.Windows.Forms.Timer Checkfile;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblfile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox PicLoad;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSLFile;
    }
}

