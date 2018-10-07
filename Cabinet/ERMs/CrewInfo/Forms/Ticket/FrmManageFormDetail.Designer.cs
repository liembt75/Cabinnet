namespace CrewInfo.Forms.Ticket
{
    partial class FrmManageFormDetail
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
            this.cbxEmployeeType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.printReport = new DevExpress.XtraEditors.SimpleButton();
            this.yearTo = new DevExpress.XtraEditors.TextEdit();
            this.yearFrom = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditTicketType = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEmployeeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTicketType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.cbxEmployeeType);
            this.panelNav.Controls.Add(this.label4);
            this.panelNav.Controls.Add(this.comboBoxBase);
            this.panelNav.Controls.Add(this.label3);
            this.panelNav.Controls.Add(this.printReport);
            this.panelNav.Controls.Add(this.yearTo);
            this.panelNav.Controls.Add(this.yearFrom);
            this.panelNav.Controls.Add(this.label2);
            this.panelNav.Controls.Add(this.lookUpEditTicketType);
            this.panelNav.Controls.Add(this.label1);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 64);
            this.panelNav.TabIndex = 10;
            // 
            // cbxEmployeeType
            // 
            this.cbxEmployeeType.Location = new System.Drawing.Point(428, 6);
            this.cbxEmployeeType.Name = "cbxEmployeeType";
            this.cbxEmployeeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxEmployeeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxEmployeeType.Size = new System.Drawing.Size(100, 20);
            this.cbxEmployeeType.TabIndex = 14;
            this.cbxEmployeeType.SelectedIndexChanged += new System.EventHandler(this.cbxEmployeeType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nhân viên: ";
            // 
            // comboBoxBase
            // 
            this.comboBoxBase.Location = new System.Drawing.Point(256, 6);
            this.comboBoxBase.Name = "comboBoxBase";
            this.comboBoxBase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxBase.Properties.Items.AddRange(new object[] {
            "SGN",
            "HAN"});
            this.comboBoxBase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxBase.Size = new System.Drawing.Size(100, 20);
            this.comboBoxBase.TabIndex = 12;
            this.comboBoxBase.SelectedIndexChanged += new System.EventHandler(this.comboBoxBase_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nơi xuất vé";
            // 
            // printReport
            // 
            this.printReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printReport.Location = new System.Drawing.Point(623, 4);
            this.printReport.Name = "printReport";
            this.printReport.Size = new System.Drawing.Size(88, 23);
            this.printReport.TabIndex = 10;
            this.printReport.Text = "Luu && In BC";
            this.printReport.Click += new System.EventHandler(this.printReport_Click);
            // 
            // yearTo
            // 
            this.yearTo.Location = new System.Drawing.Point(256, 32);
            this.yearTo.Name = "yearTo";
            this.yearTo.Size = new System.Drawing.Size(100, 20);
            this.yearTo.TabIndex = 9;
            this.yearTo.EditValueChanged += new System.EventHandler(this.yearTo_EditValueChanged);
            // 
            // yearFrom
            // 
            this.yearFrom.Location = new System.Drawing.Point(78, 32);
            this.yearFrom.Name = "yearFrom";
            this.yearFrom.Size = new System.Drawing.Size(100, 20);
            this.yearFrom.TabIndex = 8;
            this.yearFrom.EditValueChanged += new System.EventHandler(this.yearFrom_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thâm niên";
            // 
            // lookUpEditTicketType
            // 
            this.lookUpEditTicketType.Location = new System.Drawing.Point(78, 6);
            this.lookUpEditTicketType.Name = "lookUpEditTicketType";
            this.lookUpEditTicketType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTicketType.Properties.NullText = "";
            this.lookUpEditTicketType.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditTicketType.TabIndex = 6;
            this.lookUpEditTicketType.EditValueChanged += new System.EventHandler(this.lookUpEditTicketType_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ticket type";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(716, 546);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "#";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 23;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "NguoiMua";
            this.gridColumn2.FieldName = "FullNameOffer";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 115;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ThamNien";
            this.gridColumn3.FieldName = "YearOffer";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 30;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "HoTen";
            this.gridColumn4.FieldName = "Fullname";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "NgaySinh";
            this.gridColumn5.FieldName = "Birthday";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID";
            this.gridColumn6.FieldName = "PID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "QuanHe";
            this.gridColumn7.FieldName = "Relationship";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ChangBay";
            this.gridColumn8.FieldName = "Route";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "NoiXuatVe";
            this.gridColumn9.FieldName = "Base";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "LoaiVe";
            this.gridColumn10.FieldName = "Type";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "SLVe";
            this.gridColumn11.FieldName = "TicketCount";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            this.gridColumn11.Width = 50;
            // 
            // FrmManageFormDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmManageFormDetail";
            this.Text = "Quản lý form detail";
            this.Activated += new System.EventHandler(this.FrmManageFormDetail_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEmployeeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTicketType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTicketType;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.TextEdit yearTo;
        private DevExpress.XtraEditors.TextEdit yearFrom;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton printReport;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxBase;
        private DevExpress.XtraEditors.ComboBoxEdit cbxEmployeeType;
        private System.Windows.Forms.Label label4;
    }
}