namespace CrewInfo.Forms.Exam
{
    partial class FrmQuestionType
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
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.gcQSType = new DevExpress.XtraGrid.GridControl();
            this.gvQSType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcQSType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQSType)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnImport);
            this.panelNav.Controls.Add(this.btnUpdate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 35);
            this.panelNav.TabIndex = 6;
            // 
            // btnImport
            // 
            this.btnImport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnImport.Location = new System.Drawing.Point(5, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(122, 25);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Nhập câu hỏi từ excel";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdate.Location = new System.Drawing.Point(611, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.ToolTip = "Xem danh sách chuyến bay";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gcQSType
            // 
            this.gcQSType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcQSType.Location = new System.Drawing.Point(0, 35);
            this.gcQSType.MainView = this.gvQSType;
            this.gcQSType.Name = "gcQSType";
            this.gcQSType.Size = new System.Drawing.Size(716, 575);
            this.gcQSType.TabIndex = 7;
            this.gcQSType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQSType});
            // 
            // gvQSType
            // 
            this.gvQSType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.clTitle,
            this.clDescription,
            this.clActive});
            this.gvQSType.GridControl = this.gcQSType;
            this.gvQSType.Name = "gvQSType";
            this.gvQSType.OptionsBehavior.Editable = false;
            this.gvQSType.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvQSType.OptionsView.ShowGroupPanel = false;
            this.gvQSType.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvQSType_InitNewRow);
            this.gvQSType.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvQSType_InvalidRowException);
            this.gvQSType.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvQSType_ValidateRow);
            this.gvQSType.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvQSType_RowUpdated);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 30;
            // 
            // clTitle
            // 
            this.clTitle.Caption = "Title";
            this.clTitle.FieldName = "Title";
            this.clTitle.Name = "clTitle";
            this.clTitle.Visible = true;
            this.clTitle.VisibleIndex = 1;
            this.clTitle.Width = 221;
            // 
            // clDescription
            // 
            this.clDescription.Caption = "Description";
            this.clDescription.FieldName = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.Visible = true;
            this.clDescription.VisibleIndex = 2;
            this.clDescription.Width = 221;
            // 
            // clActive
            // 
            this.clActive.Caption = "Active";
            this.clActive.FieldName = "Active";
            this.clActive.Name = "clActive";
            this.clActive.Visible = true;
            this.clActive.VisibleIndex = 3;
            this.clActive.Width = 226;
            // 
            // FrmQuestionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gcQSType);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmQuestionType";
            this.Text = "Quản lý loại câu hỏi";
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcQSType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQSType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.GridControl gcQSType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQSType;
        private DevExpress.XtraGrid.Columns.GridColumn clTitle;
        private DevExpress.XtraGrid.Columns.GridColumn clDescription;
        private DevExpress.XtraGrid.Columns.GridColumn clActive;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}