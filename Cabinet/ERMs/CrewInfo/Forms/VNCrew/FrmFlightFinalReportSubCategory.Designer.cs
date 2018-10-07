namespace CrewInfo.Forms.VNCrew
{
    partial class FrmFlightFinalReportSubCategory
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
            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.txtSubCategory = new DevExpress.XtraEditors.TextEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.clSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.txtCategory = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemHyperLinkEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 67);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.gridControl1.Size = new System.Drawing.Size(716, 543);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clSubCategory,
            this.clDel});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.txtCategory);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.txtSubCategory);
            this.panelNav.Controls.Add(this.btnNew);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 67);
            this.panelNav.TabIndex = 9;
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Location = new System.Drawing.Point(89, 36);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(302, 20);
            this.txtSubCategory.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNew.Location = new System.Drawing.Point(397, 33);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Thêm &mới";
            this.btnNew.ToolTip = "Xem danh sách chuyến bay";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh mục";
            // 
            // clSubCategory
            // 
            this.clSubCategory.Caption = "Danh mục";
            this.clSubCategory.FieldName = "SubCategory";
            this.clSubCategory.Name = "clSubCategory";
            this.clSubCategory.Visible = true;
            this.clSubCategory.VisibleIndex = 0;
            this.clSubCategory.Width = 219;
            // 
            // clDel
            // 
            repositoryItemHyperLinkEdit3.AutoHeight = false;
            repositoryItemHyperLinkEdit3.Name = "repositoryItemHyperLinkEdit2";
            repositoryItemHyperLinkEdit3.NullText = "Xóa";
            this.clDel.ColumnEdit = repositoryItemHyperLinkEdit3;
            this.clDel.Name = "clDel";
            this.clDel.OptionsColumn.AllowEdit = false;
            this.clDel.Visible = true;
            this.clDel.VisibleIndex = 1;
            this.clDel.Width = 40;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Danh mục con";
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.NullText = "Xóa";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(89, 9);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Properties.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(302, 20);
            this.txtCategory.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Danh mục cha";
            // 
            // FrmFlightFinalReportSubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmFlightFinalReportSubCategory";
            this.Text = "Danh mục con báo cáo chuyến bay";
            this.Load += new System.EventHandler(this.FrmFlightFinalReportSubCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemHyperLinkEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clSubCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.TextEdit txtSubCategory;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCategory;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}