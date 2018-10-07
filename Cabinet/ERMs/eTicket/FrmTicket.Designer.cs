namespace eTicket
{
    partial class FrmTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicket));
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdateEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.lbInformation = new System.Windows.Forms.Label();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.gcFormDetail = new DevExpress.XtraGrid.GridControl();
            this.gvFormDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.clRoute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnUpdateEmployee);
            this.panelNav.Controls.Add(this.btnPrint);
            this.panelNav.Controls.Add(this.lbInformation);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 91);
            this.panelNav.TabIndex = 9;
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateEmployee.Location = new System.Drawing.Point(504, 5);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(119, 23);
            this.btnUpdateEmployee.TabIndex = 9;
            this.btnUpdateEmployee.Text = "Cập nhật từ nhân sự";
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(629, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Save && Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Location = new System.Drawing.Point(12, 9);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(71, 13);
            this.lbInformation.TabIndex = 0;
            this.lbInformation.Text = "lbInformation";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "plus.png");
            this.imageCollection1.Images.SetKeyName(1, "route.png");
            // 
            // gcFormDetail
            // 
            this.gcFormDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFormDetail.Location = new System.Drawing.Point(0, 91);
            this.gcFormDetail.MainView = this.gvFormDetail;
            this.gcFormDetail.Name = "gcFormDetail";
            this.gcFormDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.gcFormDetail.Size = new System.Drawing.Size(716, 519);
            this.gcFormDetail.TabIndex = 13;
            this.gcFormDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFormDetail});
            // 
            // gvFormDetail
            // 
            this.gvFormDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clAdd,
            this.clRoute,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn2});
            this.gvFormDetail.GridControl = this.gcFormDetail;
            this.gvFormDetail.Name = "gvFormDetail";
            this.gvFormDetail.OptionsBehavior.Editable = false;
            this.gvFormDetail.OptionsView.ShowGroupPanel = false;
            this.gvFormDetail.OptionsView.ShowIndicator = false;
            this.gvFormDetail.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvFormDetail_RowCellClick);
            // 
            // clAdd
            // 
            this.clAdd.ColumnEdit = this.repositoryItemImageComboBox1;
            this.clAdd.Name = "clAdd";
            this.clAdd.OptionsColumn.AllowEdit = false;
            this.clAdd.Visible = true;
            this.clAdd.VisibleIndex = 0;
            this.clAdd.Width = 20;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageCollection1;
            // 
            // clRoute
            // 
            this.clRoute.ColumnEdit = this.repositoryItemImageComboBox2;
            this.clRoute.Name = "clRoute";
            this.clRoute.OptionsColumn.AllowEdit = false;
            this.clRoute.Visible = true;
            this.clRoute.VisibleIndex = 1;
            this.clRoute.Width = 20;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, 1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.imageCollection1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fullname";
            this.gridColumn3.FieldName = "Fullname";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Birthday";
            this.gridColumn4.FieldName = "Birthday";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ID";
            this.gridColumn5.FieldName = "PID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 95;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Relationship";
            this.gridColumn6.FieldName = "Relationship";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 95;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Route";
            this.gridColumn7.FieldName = "Route";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 95;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Count";
            this.gridColumn8.FieldName = "TicketCount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 95;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Type";
            this.gridColumn9.FieldName = "Type";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 104;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Base";
            this.gridColumn1.FieldName = "Base";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Status";
            this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox3;
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Waiting", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Proccessing", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Accept", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Reject", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Done", 10, -1)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // FrmTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gcFormDetail);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmTicket";
            this.Text = "Ticket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private System.Windows.Forms.Label lbInformation;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl gcFormDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFormDetail;
        private DevExpress.XtraGrid.Columns.GridColumn clAdd;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn clRoute;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.SimpleButton btnUpdateEmployee;
    }
}