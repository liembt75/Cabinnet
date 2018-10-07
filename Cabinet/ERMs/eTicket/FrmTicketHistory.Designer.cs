namespace eTicket
{
    partial class FrmTicketHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketHistory));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLoadFlights = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.gcFormDetail = new DevExpress.XtraGrid.GridControl();
            this.gvFormDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "wait.png");
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.btnLoadFlights);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 32);
            this.panelNav.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(195, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "đến";
            // 
            // btnLoadFlights
            // 
            this.btnLoadFlights.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLoadFlights.Location = new System.Drawing.Point(360, 3);
            this.btnLoadFlights.Name = "btnLoadFlights";
            this.btnLoadFlights.Size = new System.Drawing.Size(54, 25);
            this.btnLoadFlights.TabIndex = 12;
            this.btnLoadFlights.Text = "&Search";
            this.btnLoadFlights.ToolTip = "Xem danh sách chuyến bay";
            this.btnLoadFlights.Click += new System.EventHandler(this.btnLoadFlights_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Từ ngày";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(55, 5);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtFromdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromdate.Properties.DisplayFormat.FormatString = "";
            this.txtFromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromdate.Properties.EditFormat.FormatString = "";
            this.txtFromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromdate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtFromdate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFromdate.Properties.NullValuePrompt = "dd/MM/yyyy";
            this.txtFromdate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtFromdate.Size = new System.Drawing.Size(131, 20);
            this.txtFromdate.TabIndex = 9;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(226, 5);
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTodate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTodate.Properties.DisplayFormat.FormatString = "";
            this.txtTodate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTodate.Properties.EditFormat.FormatString = "";
            this.txtTodate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTodate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTodate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTodate.Properties.NullValuePrompt = "dd/MM/yyyy";
            this.txtTodate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTodate.Size = new System.Drawing.Size(128, 20);
            this.txtTodate.TabIndex = 11;
            // 
            // gcFormDetail
            // 
            this.gcFormDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFormDetail.Location = new System.Drawing.Point(0, 32);
            this.gcFormDetail.MainView = this.gvFormDetail;
            this.gcFormDetail.Name = "gcFormDetail";
            this.gcFormDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox3,
            this.repositoryItemImageComboBox1,
            this.repositoryItemHyperLinkEdit1});
            this.gcFormDetail.Size = new System.Drawing.Size(716, 578);
            this.gcFormDetail.TabIndex = 13;
            this.gcFormDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFormDetail});
            // 
            // gvFormDetail
            // 
            this.gvFormDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4});
            this.gvFormDetail.GridControl = this.gcFormDetail;
            this.gvFormDetail.Name = "gvFormDetail";
            this.gvFormDetail.OptionsBehavior.Editable = false;
            this.gvFormDetail.OptionsView.ShowGroupPanel = false;
            this.gvFormDetail.OptionsView.ShowIndicator = false;
            this.gvFormDetail.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvFormDetail_RowCellClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 27;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Waiting", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Processing", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Waiting", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Reject", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Done", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Accept", 2, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 26;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Content";
            this.gridColumn5.FieldName = "Contents";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 461;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Created";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yy hh:mm:ss tt";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "Created";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Modified";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "Modified";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 100;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", 0)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            this.repositoryItemImageComboBox3.SmallImages = this.imageCollection1;
            // 
            // FrmTicketHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gcFormDetail);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmTicketHistory";
            this.Text = "Ticket History";
            this.Activated += new System.EventHandler(this.FrmTicketHistory_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFormDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFormDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraGrid.GridControl gcFormDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFormDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLoadFlights;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
    }
}