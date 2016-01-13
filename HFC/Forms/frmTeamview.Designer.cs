namespace HFC.Forms
{
    partial class frmTeamview
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
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItem
            // 
            this.gridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.gridItemDetail;
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(567, 385);
            this.gridItem.TabIndex = 0;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetail});
            // 
            // gridItemDetail
            // 
            this.gridItemDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPass,
            this.colUser,
            this.colPC,
            this.colDateTime,
            this.colLocation});
            this.gridItemDetail.GridControl = this.gridItem;
            this.gridItemDetail.Name = "gridItemDetail";
            this.gridItemDetail.OptionsView.ShowGroupPanel = false;
            this.gridItemDetail.DoubleClick += new System.EventHandler(this.gridItemDetail_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colPass
            // 
            this.colPass.Caption = "Pass";
            this.colPass.FieldName = "Pass";
            this.colPass.Name = "colPass";
            this.colPass.Visible = true;
            this.colPass.VisibleIndex = 1;
            // 
            // colUser
            // 
            this.colUser.Caption = "User";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 2;
            // 
            // colPC
            // 
            this.colPC.Caption = "PC";
            this.colPC.FieldName = "PC";
            this.colPC.Name = "colPC";
            this.colPC.Visible = true;
            this.colPC.VisibleIndex = 3;
            // 
            // colDateTime
            // 
            this.colDateTime.Caption = "DateTime";
            this.colDateTime.FieldName = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Visible = true;
            this.colDateTime.VisibleIndex = 4;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 5;
            // 
            // frmTeamview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 385);
            this.Controls.Add(this.gridItem);
            this.Name = "frmTeamview";
            this.ShowIcon = false;
            this.Text = "Teamview";
            this.Load += new System.EventHandler(this.frmTeamview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPass;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colPC;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
    }
}