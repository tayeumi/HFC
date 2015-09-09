namespace HFC.Forms
{
    partial class frmDeviceToNode
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
            this.gridItemNode = new DevExpress.XtraGrid.GridControl();
            this.gridItemDetailNode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNodeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNodeGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PicNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetailNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // gridItemNode
            // 
            this.gridItemNode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItemNode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridItemNode.Location = new System.Drawing.Point(3, 8);
            this.gridItemNode.MainView = this.gridItemDetailNode;
            this.gridItemNode.Name = "gridItemNode";
            this.gridItemNode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PicNhanVien});
            this.gridItemNode.Size = new System.Drawing.Size(357, 361);
            this.gridItemNode.TabIndex = 2;
            this.gridItemNode.UseEmbeddedNavigator = true;
            this.gridItemNode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemDetailNode});
            // 
            // gridItemDetailNode
            // 
            this.gridItemDetailNode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNodeCode,
            this.colNodeName,
            this.colNodeGroup,
            this.colDescription});
            this.gridItemDetailNode.GridControl = this.gridItemNode;
            this.gridItemDetailNode.GroupCount = 1;
            this.gridItemDetailNode.Name = "gridItemDetailNode";
            this.gridItemDetailNode.OptionsBehavior.Editable = false;
            this.gridItemDetailNode.OptionsCustomization.AllowRowSizing = true;
            this.gridItemDetailNode.OptionsView.RowAutoHeight = true;
            this.gridItemDetailNode.OptionsView.ShowAutoFilterRow = true;
            this.gridItemDetailNode.OptionsView.ShowGroupPanel = false;
            this.gridItemDetailNode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gridItemDetailNode.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNodeGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colNodeCode
            // 
            this.colNodeCode.Caption = "Mã Node";
            this.colNodeCode.FieldName = "NodeCode";
            this.colNodeCode.Name = "colNodeCode";
            this.colNodeCode.Visible = true;
            this.colNodeCode.VisibleIndex = 0;
            this.colNodeCode.Width = 93;
            // 
            // colNodeName
            // 
            this.colNodeName.Caption = "Tên Node";
            this.colNodeName.FieldName = "NodeName";
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.Visible = true;
            this.colNodeName.VisibleIndex = 1;
            this.colNodeName.Width = 162;
            // 
            // colNodeGroup
            // 
            this.colNodeGroup.Caption = "Node";
            this.colNodeGroup.FieldName = "NodeGroup";
            this.colNodeGroup.Name = "colNodeGroup";
            this.colNodeGroup.Visible = true;
            this.colNodeGroup.VisibleIndex = 2;
            this.colNodeGroup.Width = 173;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Tọa độ";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 77;
            // 
            // PicNhanVien
            // 
            this.PicNhanVien.CustomHeight = 105;
            this.PicNhanVien.Name = "PicNhanVien";
            this.PicNhanVien.NullText = "[Chưa có hình]";
            this.PicNhanVien.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(280, 375);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmDeviceToNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 407);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridItemNode);
            this.Name = "frmDeviceToNode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Device vào Node";
            ((System.ComponentModel.ISupportInitialize)(this.gridItemNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemDetailNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridItemNode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemDetailNode;
        private DevExpress.XtraGrid.Columns.GridColumn colNodeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNodeGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PicNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}