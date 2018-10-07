namespace CrewInfo.Forms.VNCrew
{
    partial class FrmSalAdmin
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvFlightInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clCrewTaskStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFlightNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clRouting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTotalPax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPurserid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPurserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIsDeleteds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFlightID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAircraft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcFlightCrew = new DevExpress.XtraGrid.GridControl();
            this.gvFlightCrew = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clFlightCrew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCFG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAnn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDuTyFree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clVIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOJT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKNB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnInsertFlightCrew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLoadFlights = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFlightCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 35);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcFlightCrew);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(716, 575);
            this.splitContainerControl1.SplitterPosition = 293;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(716, 293);
            this.panelControl1.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gvFlightInfo;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(712, 289);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFlightInfo});
            // 
            // gvFlightInfo
            // 
            this.gvFlightInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clCrewTaskStatus,
            this.clFlightNo,
            this.clDate,
            this.clRouting,
            this.clTotalPax,
            this.clPurserid,
            this.clPurserName,
            this.clIsDeleteds,
            this.clFlightID,
            this.clAircraft});
            this.gvFlightInfo.GridControl = this.gridControl1;
            this.gvFlightInfo.Name = "gvFlightInfo";
            this.gvFlightInfo.OptionsView.ShowFooter = true;
            this.gvFlightInfo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFlightInfo_FocusedRowChanged);
            this.gvFlightInfo.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvFlightInfo_CellValueChanged);
            this.gvFlightInfo.ColumnFilterChanged += new System.EventHandler(this.gvFlightInfo_ColumnFilterChanged);
            this.gvFlightInfo.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvFlightInfo_ValidatingEditor);
            // 
            // clCrewTaskStatus
            // 
            this.clCrewTaskStatus.Caption = "CrewTaskStatus";
            this.clCrewTaskStatus.FieldName = "CrewTaskStatus";
            this.clCrewTaskStatus.Name = "clCrewTaskStatus";
            this.clCrewTaskStatus.OptionsColumn.AllowEdit = false;
            this.clCrewTaskStatus.Visible = true;
            this.clCrewTaskStatus.VisibleIndex = 0;
            // 
            // clFlightNo
            // 
            this.clFlightNo.Caption = "FlightNo";
            this.clFlightNo.FieldName = "FlightNo";
            this.clFlightNo.Name = "clFlightNo";
            this.clFlightNo.OptionsColumn.AllowEdit = false;
            this.clFlightNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "FlightNo", "{0}")});
            this.clFlightNo.Visible = true;
            this.clFlightNo.VisibleIndex = 1;
            // 
            // clDate
            // 
            this.clDate.Caption = "Date";
            this.clDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clDate.FieldName = "Date";
            this.clDate.Name = "clDate";
            this.clDate.OptionsColumn.AllowEdit = false;
            this.clDate.Visible = true;
            this.clDate.VisibleIndex = 2;
            // 
            // clRouting
            // 
            this.clRouting.Caption = "Routing";
            this.clRouting.FieldName = "Routing";
            this.clRouting.Name = "clRouting";
            this.clRouting.OptionsColumn.AllowEdit = false;
            this.clRouting.Visible = true;
            this.clRouting.VisibleIndex = 3;
            // 
            // clTotalPax
            // 
            this.clTotalPax.Caption = "TotalPax";
            this.clTotalPax.FieldName = "TotalPax";
            this.clTotalPax.Name = "clTotalPax";
            this.clTotalPax.OptionsColumn.AllowEdit = false;
            this.clTotalPax.Visible = true;
            this.clTotalPax.VisibleIndex = 4;
            // 
            // clPurserid
            // 
            this.clPurserid.Caption = "Purserid";
            this.clPurserid.FieldName = "Purserid";
            this.clPurserid.Name = "clPurserid";
            this.clPurserid.OptionsColumn.AllowEdit = false;
            this.clPurserid.Visible = true;
            this.clPurserid.VisibleIndex = 6;
            // 
            // clPurserName
            // 
            this.clPurserName.Caption = "PurserName";
            this.clPurserName.FieldName = "PurserName";
            this.clPurserName.Name = "clPurserName";
            this.clPurserName.OptionsColumn.AllowEdit = false;
            this.clPurserName.Visible = true;
            this.clPurserName.VisibleIndex = 7;
            // 
            // clIsDeleteds
            // 
            this.clIsDeleteds.Caption = "IsDeleted";
            this.clIsDeleteds.FieldName = "IsDeleted";
            this.clIsDeleteds.Name = "clIsDeleteds";
            this.clIsDeleteds.Visible = true;
            this.clIsDeleteds.VisibleIndex = 8;
            // 
            // clFlightID
            // 
            this.clFlightID.Caption = "FlightID";
            this.clFlightID.FieldName = "FlightID";
            this.clFlightID.Name = "clFlightID";
            this.clFlightID.Visible = true;
            this.clFlightID.VisibleIndex = 9;
            // 
            // clAircraft
            // 
            this.clAircraft.Caption = "Aircraft";
            this.clAircraft.FieldName = "Aircraft";
            this.clAircraft.Name = "clAircraft";
            this.clAircraft.OptionsColumn.AllowEdit = false;
            this.clAircraft.Visible = true;
            this.clAircraft.VisibleIndex = 5;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Coming", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Done", 1, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending", 2, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gcFlightCrew
            // 
            this.gcFlightCrew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFlightCrew.Location = new System.Drawing.Point(0, 0);
            this.gcFlightCrew.MainView = this.gvFlightCrew;
            this.gcFlightCrew.Name = "gcFlightCrew";
            this.gcFlightCrew.Size = new System.Drawing.Size(716, 277);
            this.gcFlightCrew.TabIndex = 0;
            this.gcFlightCrew.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFlightCrew});
            // 
            // gvFlightCrew
            // 
            this.gvFlightCrew.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clFlightCrew,
            this.clKH,
            this.clCFG,
            this.clTask,
            this.clCA,
            this.clAnn,
            this.clDuTyFree,
            this.clVIP,
            this.clOJT,
            this.clKNB,
            this.clIsDeleted});
            this.gvFlightCrew.GridControl = this.gcFlightCrew;
            this.gvFlightCrew.Name = "gvFlightCrew";
            this.gvFlightCrew.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvFlightCrew_CellValueChanged);
            this.gvFlightCrew.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvFlightCrew_ValidatingEditor);
            // 
            // clFlightCrew
            // 
            this.clFlightCrew.Caption = "Crews of flight";
            this.clFlightCrew.FieldName = "FirstNameVn";
            this.clFlightCrew.Name = "clFlightCrew";
            this.clFlightCrew.OptionsColumn.AllowEdit = false;
            this.clFlightCrew.Visible = true;
            this.clFlightCrew.VisibleIndex = 0;
            // 
            // clKH
            // 
            this.clKH.Caption = "KH";
            this.clKH.FieldName = "FO_Job";
            this.clKH.Name = "clKH";
            this.clKH.Visible = true;
            this.clKH.VisibleIndex = 3;
            // 
            // clCFG
            // 
            this.clCFG.Caption = "CFG";
            this.clCFG.FieldName = "FO_Cfg";
            this.clCFG.Name = "clCFG";
            this.clCFG.Visible = true;
            this.clCFG.VisibleIndex = 2;
            // 
            // clTask
            // 
            this.clTask.AppearanceCell.BackColor = System.Drawing.Color.Gold;
            this.clTask.AppearanceCell.Options.UseBackColor = true;
            this.clTask.Caption = "Task";
            this.clTask.FieldName = "Job";
            this.clTask.Name = "clTask";
            this.clTask.Visible = true;
            this.clTask.VisibleIndex = 4;
            // 
            // clCA
            // 
            this.clCA.Caption = "CA";
            this.clCA.FieldName = "CA";
            this.clCA.Name = "clCA";
            this.clCA.Visible = true;
            this.clCA.VisibleIndex = 5;
            // 
            // clAnn
            // 
            this.clAnn.Caption = "ANN";
            this.clAnn.FieldName = "ANN";
            this.clAnn.Name = "clAnn";
            this.clAnn.OptionsColumn.AllowEdit = false;
            this.clAnn.Visible = true;
            this.clAnn.VisibleIndex = 6;
            // 
            // clDuTyFree
            // 
            this.clDuTyFree.Caption = "Duty Free";
            this.clDuTyFree.FieldName = "DutyFree";
            this.clDuTyFree.Name = "clDuTyFree";
            this.clDuTyFree.OptionsColumn.AllowEdit = false;
            this.clDuTyFree.Visible = true;
            this.clDuTyFree.VisibleIndex = 7;
            // 
            // clVIP
            // 
            this.clVIP.Caption = "VIP";
            this.clVIP.FieldName = "VIP";
            this.clVIP.Name = "clVIP";
            this.clVIP.OptionsColumn.AllowEdit = false;
            this.clVIP.Visible = true;
            this.clVIP.VisibleIndex = 8;
            // 
            // clOJT
            // 
            this.clOJT.Caption = "OJT";
            this.clOJT.FieldName = "Training";
            this.clOJT.Name = "clOJT";
            this.clOJT.Visible = true;
            this.clOJT.VisibleIndex = 9;
            // 
            // clKNB
            // 
            this.clKNB.Caption = "KNB";
            this.clKNB.FieldName = "Ability";
            this.clKNB.Name = "clKNB";
            this.clKNB.OptionsColumn.AllowEdit = false;
            this.clKNB.Visible = true;
            this.clKNB.VisibleIndex = 1;
            // 
            // clIsDeleted
            // 
            this.clIsDeleted.Caption = "IsDeleted";
            this.clIsDeleted.FieldName = "IsDeleted";
            this.clIsDeleted.Name = "clIsDeleted";
            this.clIsDeleted.Visible = true;
            this.clIsDeleted.VisibleIndex = 10;
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnInsertFlightCrew);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.btnLoadFlights);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 35);
            this.panelNav.TabIndex = 9;
            // 
            // btnInsertFlightCrew
            // 
            this.btnInsertFlightCrew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnInsertFlightCrew.Location = new System.Drawing.Point(478, 6);
            this.btnInsertFlightCrew.Name = "btnInsertFlightCrew";
            this.btnInsertFlightCrew.Size = new System.Drawing.Size(100, 25);
            this.btnInsertFlightCrew.TabIndex = 5;
            this.btnInsertFlightCrew.Text = "Thêm TV";
            this.btnInsertFlightCrew.ToolTip = "Xem danh sách chuyến bay";
            this.btnInsertFlightCrew.Click += new System.EventHandler(this.btnInsertFlightCrew_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(199, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "đến";
            // 
            // btnLoadFlights
            // 
            this.btnLoadFlights.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLoadFlights.Location = new System.Drawing.Point(372, 6);
            this.btnLoadFlights.Name = "btnLoadFlights";
            this.btnLoadFlights.Size = new System.Drawing.Size(100, 25);
            this.btnLoadFlights.TabIndex = 2;
            this.btnLoadFlights.Text = "&Search";
            this.btnLoadFlights.ToolTip = "Xem danh sách chuyến bay";
            this.btnLoadFlights.Click += new System.EventHandler(this.btnLoadFlights_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(59, 9);
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
            this.txtFromdate.TabIndex = 1;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(230, 9);
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
            this.txtTodate.TabIndex = 4;
            // 
            // FrmSalAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmSalAdmin";
            this.Text = "FrmSalAdmin";
            this.Load += new System.EventHandler(this.FrmSalAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFlightCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFlightInfo;
        private DevExpress.XtraGrid.Columns.GridColumn clCrewTaskStatus;
        private DevExpress.XtraGrid.Columns.GridColumn clFlightNo;
        private DevExpress.XtraGrid.Columns.GridColumn clDate;
        private DevExpress.XtraGrid.Columns.GridColumn clRouting;
        private DevExpress.XtraGrid.Columns.GridColumn clTotalPax;
        private DevExpress.XtraGrid.Columns.GridColumn clPurserid;
        private DevExpress.XtraGrid.Columns.GridColumn clPurserName;
        private DevExpress.XtraGrid.Columns.GridColumn clIsDeleteds;
        private DevExpress.XtraGrid.Columns.GridColumn clFlightID;
        private DevExpress.XtraGrid.Columns.GridColumn clAircraft;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.GridControl gcFlightCrew;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFlightCrew;
        private DevExpress.XtraGrid.Columns.GridColumn clFlightCrew;
        private DevExpress.XtraGrid.Columns.GridColumn clKH;
        private DevExpress.XtraGrid.Columns.GridColumn clCFG;
        private DevExpress.XtraGrid.Columns.GridColumn clTask;
        private DevExpress.XtraGrid.Columns.GridColumn clCA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnn;
        private DevExpress.XtraGrid.Columns.GridColumn clDuTyFree;
        private DevExpress.XtraGrid.Columns.GridColumn clVIP;
        private DevExpress.XtraGrid.Columns.GridColumn clOJT;
        private DevExpress.XtraGrid.Columns.GridColumn clKNB;
        private DevExpress.XtraGrid.Columns.GridColumn clIsDeleted;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnInsertFlightCrew;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLoadFlights;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
    }
}