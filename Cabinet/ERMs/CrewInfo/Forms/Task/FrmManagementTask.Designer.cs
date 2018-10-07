namespace CrewInfo.Forms.Task
{
    partial class FrmManagementTask
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
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.cbxAllTask = new DevExpress.XtraEditors.CheckEdit();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAllTask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(46, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(415, 159);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.cbxAllTask);
            this.panelNav.Controls.Add(this.btnDetail);
            this.panelNav.Controls.Add(this.btnNew);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(986, 35);
            this.panelNav.TabIndex = 5;
            // 
            // cbxAllTask
            // 
            this.cbxAllTask.Location = new System.Drawing.Point(364, 8);
            this.cbxAllTask.Name = "cbxAllTask";
            this.cbxAllTask.Properties.Caption = "Tất cả task";
            this.cbxAllTask.Size = new System.Drawing.Size(75, 19);
            this.cbxAllTask.TabIndex = 7;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnDetail.Location = new System.Drawing.Point(881, 5);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(100, 25);
            this.btnDetail.TabIndex = 6;
            this.btnDetail.Text = "Xuất excel";
            this.btnDetail.ToolTip = "Xuất excel";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnNew
            // 
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNew.Location = new System.Drawing.Point(559, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Thêm &mới";
            this.btnNew.ToolTip = "Xem danh sách chuyến bay";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(199, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "đến";
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSearch.Location = new System.Drawing.Point(445, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Tim";
            this.btnSearch.ToolTip = "Xem danh sách chuyến bay";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(31, 103);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(506, 225);
            this.panelControl1.TabIndex = 6;
            // 
            // FrmManagementTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 681);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmManagementTask";
            this.Text = "FrmManagementTask";
            this.Load += new System.EventHandler(this.FrmManagementTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxAllTask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraEditors.CheckEdit cbxAllTask;
    }
}