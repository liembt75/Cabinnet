namespace CrewInfo.Forms.VNCrew
{
    partial class FrmSalInsertFlightCrew2
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
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtMSNV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbCR_FlightInfo = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cl1CrewID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl1LastNameVn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFirstNameVn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFoward = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cl2CrewID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl2LastNameVn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl2FirstNameVn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cl2FO_Job = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnInsert);
            this.panelNav.Controls.Add(this.txtTen);
            this.panelNav.Controls.Add(this.labelControl6);
            this.panelNav.Controls.Add(this.txtMSNV);
            this.panelNav.Controls.Add(this.labelControl3);
            this.panelNav.Controls.Add(this.lbCR_FlightInfo);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(663, 89);
            this.panelNav.TabIndex = 1;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(589, 5);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(62, 23);
            this.btnInsert.TabIndex = 19;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(47, 57);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(604, 20);
            this.txtTen.TabIndex = 18;
            this.txtTen.EditValueChanged += new System.EventHandler(this.txtTen_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 60);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(18, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Tên";
            // 
            // txtMSNV
            // 
            this.txtMSNV.Location = new System.Drawing.Point(47, 31);
            this.txtMSNV.Name = "txtMSNV";
            this.txtMSNV.Size = new System.Drawing.Size(604, 20);
            this.txtMSNV.TabIndex = 16;
            this.txtMSNV.EditValueChanged += new System.EventHandler(this.txtMSNV_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "MSNV";
            // 
            // lbCR_FlightInfo
            // 
            this.lbCR_FlightInfo.Location = new System.Drawing.Point(12, 12);
            this.lbCR_FlightInfo.Name = "lbCR_FlightInfo";
            this.lbCR_FlightInfo.Size = new System.Drawing.Size(104, 13);
            this.lbCR_FlightInfo.TabIndex = 1;
            this.lbCR_FlightInfo.Text = "Thông tin chuyến bay";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 89);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(663, 294);
            this.splitContainerControl1.SplitterPosition = 334;
            this.splitContainerControl1.TabIndex = 11;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(334, 294);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cl1CrewID,
            this.cl1LastNameVn,
            this.clFirstNameVn});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // cl1CrewID
            // 
            this.cl1CrewID.Caption = "CrewID";
            this.cl1CrewID.FieldName = "CrewID";
            this.cl1CrewID.Name = "cl1CrewID";
            this.cl1CrewID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CrewID", "{0}")});
            this.cl1CrewID.Visible = true;
            this.cl1CrewID.VisibleIndex = 1;
            this.cl1CrewID.Width = 30;
            // 
            // cl1LastNameVn
            // 
            this.cl1LastNameVn.Caption = "LastNameVn";
            this.cl1LastNameVn.FieldName = "LastNameVn";
            this.cl1LastNameVn.Name = "cl1LastNameVn";
            this.cl1LastNameVn.Visible = true;
            this.cl1LastNameVn.VisibleIndex = 2;
            // 
            // clFirstNameVn
            // 
            this.clFirstNameVn.Caption = "FirstNameVn";
            this.clFirstNameVn.FieldName = "FirstNameVn";
            this.clFirstNameVn.Name = "clFirstNameVn";
            this.clFirstNameVn.Visible = true;
            this.clFirstNameVn.VisibleIndex = 3;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.btnPrevious);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnFoward);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(324, 294);
            this.splitContainerControl2.SplitterPosition = 75;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(20, 249);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(37, 23);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFoward
            // 
            this.btnFoward.Location = new System.Drawing.Point(20, 211);
            this.btnFoward.Name = "btnFoward";
            this.btnFoward.Size = new System.Drawing.Size(37, 23);
            this.btnFoward.TabIndex = 1;
            this.btnFoward.Text = ">";
            this.btnFoward.Click += new System.EventHandler(this.btnFoward_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(244, 294);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cl2CrewID,
            this.cl2LastNameVn,
            this.cl2FirstNameVn,
            this.cl2FO_Job});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // cl2CrewID
            // 
            this.cl2CrewID.Caption = "CrewID";
            this.cl2CrewID.FieldName = "CrewID";
            this.cl2CrewID.Name = "cl2CrewID";
            this.cl2CrewID.OptionsColumn.AllowEdit = false;
            this.cl2CrewID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CrewID", "{0}")});
            this.cl2CrewID.Visible = true;
            this.cl2CrewID.VisibleIndex = 1;
            // 
            // cl2LastNameVn
            // 
            this.cl2LastNameVn.Caption = "LastNameVn";
            this.cl2LastNameVn.FieldName = "LastNameVn";
            this.cl2LastNameVn.Name = "cl2LastNameVn";
            this.cl2LastNameVn.OptionsColumn.AllowEdit = false;
            this.cl2LastNameVn.Visible = true;
            this.cl2LastNameVn.VisibleIndex = 2;
            // 
            // cl2FirstNameVn
            // 
            this.cl2FirstNameVn.Caption = "FirstNameVn";
            this.cl2FirstNameVn.FieldName = "FirstNameVn";
            this.cl2FirstNameVn.Name = "cl2FirstNameVn";
            this.cl2FirstNameVn.OptionsColumn.AllowEdit = false;
            this.cl2FirstNameVn.Visible = true;
            this.cl2FirstNameVn.VisibleIndex = 3;
            // 
            // cl2FO_Job
            // 
            this.cl2FO_Job.Caption = "FoJob";
            this.cl2FO_Job.FieldName = "FO_Job";
            this.cl2FO_Job.Name = "cl2FO_Job";
            this.cl2FO_Job.Visible = true;
            this.cl2FO_Job.VisibleIndex = 4;
            // 
            // FrmSalInsertFlightCrew2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 383);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmSalInsertFlightCrew2";
            this.Text = "Thêm tiếp viên";
            this.Load += new System.EventHandler(this.FrmSalInsertFlightCrew2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.LabelControl lbCR_FlightInfo;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtMSNV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cl1CrewID;
        private DevExpress.XtraGrid.Columns.GridColumn cl1LastNameVn;
        private DevExpress.XtraGrid.Columns.GridColumn clFirstNameVn;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFoward;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cl2CrewID;
        private DevExpress.XtraGrid.Columns.GridColumn cl2LastNameVn;
        private DevExpress.XtraGrid.Columns.GridColumn cl2FirstNameVn;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private DevExpress.XtraGrid.Columns.GridColumn cl2FO_Job;
    }
}