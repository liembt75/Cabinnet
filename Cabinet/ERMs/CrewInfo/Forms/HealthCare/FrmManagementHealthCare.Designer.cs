namespace CrewInfo.Forms.HealthCare
{
    partial class FrmManagementHealthCare
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.clDel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdateFlightDate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodateFlightDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdateFlightDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdateFlightDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodateFlightDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodateFlightDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.ViewCaption = "DS Đợt khám";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Đợt khám";
            this.gridColumn8.FieldName = "Dotkham";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ngày hết hạn";
            this.gridColumn9.FieldName = "Expired";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Items";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2});
            this.gridControl1.Size = new System.Drawing.Size(780, 546);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn6,
            this.gridColumn12,
            this.gridColumn13,
            this.clUpdate,
            this.clDel});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridView1_MasterRowExpanded);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MSNV";
            this.gridColumn1.FieldName = "Code_tv";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Code_tv", "{0} TV")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Họ";
            this.gridColumn7.FieldName = "LastNameVn";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "FirstNameVn";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 177;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Đơn vị";
            this.gridColumn3.FieldName = "Group";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Đợt khám";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "Dotkham";
            this.gridColumn4.GroupFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn4.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngày hết hạn";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "Expired";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Ngày sinh";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "dob";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Quốc tịch";
            this.gridColumn11.FieldName = "quoctich";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Giới tính";
            this.gridColumn6.FieldName = "mantext";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            this.gridColumn6.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Base";
            this.gridColumn12.FieldName = "main_base";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // clUpdate
            // 
            this.clUpdate.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.clUpdate.Name = "clUpdate";
            this.clUpdate.Visible = true;
            this.clUpdate.VisibleIndex = 12;
            this.clUpdate.Width = 40;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Cập nhật";
            // 
            // clDel
            // 
            this.clDel.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.clDel.Name = "clDel";
            this.clDel.Visible = true;
            this.clDel.VisibleIndex = 13;
            this.clDel.Width = 40;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.NullText = "Xóa";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nữ", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nam", true, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(784, 550);
            this.panelControl1.TabIndex = 8;
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.labelControl3);
            this.panelNav.Controls.Add(this.labelControl4);
            this.panelNav.Controls.Add(this.txtFromdateFlightDate);
            this.panelNav.Controls.Add(this.txtTodateFlightDate);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Controls.Add(this.simpleButton1);
            this.panelNav.Controls.Add(this.btnAdd);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(784, 60);
            this.panelNav.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(389, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(224, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(18, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "đến";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Ngày hết hạn";
            // 
            // txtFromdateFlightDate
            // 
            this.txtFromdateFlightDate.EditValue = null;
            this.txtFromdateFlightDate.Location = new System.Drawing.Point(84, 35);
            this.txtFromdateFlightDate.Name = "txtFromdateFlightDate";
            this.txtFromdateFlightDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromdateFlightDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromdateFlightDate.Properties.DisplayFormat.FormatString = "";
            this.txtFromdateFlightDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromdateFlightDate.Properties.EditFormat.FormatString = "";
            this.txtFromdateFlightDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromdateFlightDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtFromdateFlightDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtFromdateFlightDate.Properties.NullValuePrompt = "dd/MM/yyyy";
            this.txtFromdateFlightDate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtFromdateFlightDate.Size = new System.Drawing.Size(131, 20);
            this.txtFromdateFlightDate.TabIndex = 16;
            // 
            // txtTodateFlightDate
            // 
            this.txtTodateFlightDate.EditValue = null;
            this.txtTodateFlightDate.Location = new System.Drawing.Point(255, 35);
            this.txtTodateFlightDate.Name = "txtTodateFlightDate";
            this.txtTodateFlightDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTodateFlightDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTodateFlightDate.Properties.DisplayFormat.FormatString = "";
            this.txtTodateFlightDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTodateFlightDate.Properties.EditFormat.FormatString = "";
            this.txtTodateFlightDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTodateFlightDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtTodateFlightDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTodateFlightDate.Properties.NullValuePrompt = "dd/MM/yyyy";
            this.txtTodateFlightDate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTodateFlightDate.Size = new System.Drawing.Size(128, 20);
            this.txtTodateFlightDate.TabIndex = 18;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(224, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Đợt khám";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(84, 7);
            this.txtFromdate.Name = "txtFromdate";
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
            this.txtFromdate.TabIndex = 12;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(255, 7);
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
            this.txtTodate.TabIndex = 14;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(693, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Xuất excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(601, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm đợt khám";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Course";
            this.gridColumn13.CustomizationCaption = "Course";
            this.gridColumn13.FieldName = "course";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // FrmManagementHealthCare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 610);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmManagementHealthCare";
            this.Text = "QLSK";
            this.Load += new System.EventHandler(this.FrmManagementHealthCare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdateFlightDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdateFlightDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodateFlightDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodateFlightDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn clUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit txtFromdateFlightDate;
        private DevExpress.XtraEditors.DateEdit txtTodateFlightDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}