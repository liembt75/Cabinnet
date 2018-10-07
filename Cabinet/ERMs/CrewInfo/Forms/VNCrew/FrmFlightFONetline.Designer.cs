namespace CrewInfo.Forms.VNCrew
{
    partial class FrmFlightFONetline
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
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gvFO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc2 = new DevExpress.XtraGrid.GridControl();
            this.gvOCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riSync = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cbxShowAll = new DevExpress.XtraEditors.CheckEdit();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.txtKeyword = new DevExpress.XtraEditors.TextEdit();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxShowAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 58);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gc1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gc2);
            this.splitContainerControl1.Panel2.Controls.Add(this.cbxShowAll);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1353, 878);
            this.splitContainerControl1.SplitterPosition = 500;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gc1
            // 
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gc1.Location = new System.Drawing.Point(0, 0);
            this.gc1.MainView = this.gvFO;
            this.gc1.Margin = new System.Windows.Forms.Padding(4);
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(500, 878);
            this.gc1.TabIndex = 2;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFO});
            // 
            // gvFO
            // 
            this.gvFO.GridControl = this.gc1;
            this.gvFO.Name = "gvFO";
            this.gvFO.OptionsView.ColumnAutoWidth = false;
            this.gvFO.OptionsView.ShowFooter = true;
            this.gvFO.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvFO_RowCellStyle);
            this.gvFO.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvFo_FocusedRowChanged);
            // 
            // gc2
            // 
            this.gc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gc2.Location = new System.Drawing.Point(0, 0);
            this.gc2.MainView = this.gvOCC;
            this.gc2.Margin = new System.Windows.Forms.Padding(4);
            this.gc2.Name = "gc2";
            this.gc2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riSync});
            this.gc2.Size = new System.Drawing.Size(845, 878);
            this.gc2.TabIndex = 2;
            this.gc2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOCC});
            // 
            // gvOCC
            // 
            this.gvOCC.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gvOCC.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvOCC.GridControl = this.gc2;
            this.gvOCC.Name = "gvOCC";
            this.gvOCC.OptionsView.ColumnAutoWidth = false;
            this.gvOCC.OptionsView.ShowFooter = true;
            this.gvOCC.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvOCC_RowStyle);
            // 
            // riSync
            // 
            this.riSync.Appearance.Options.UseTextOptions = true;
            this.riSync.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.riSync.AutoHeight = false;
            this.riSync.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riSync.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, 0)});
            this.riSync.Name = "riSync";
            // 
            // cbxShowAll
            // 
            this.cbxShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxShowAll.Location = new System.Drawing.Point(388, 4);
            this.cbxShowAll.Margin = new System.Windows.Forms.Padding(4);
            this.cbxShowAll.Name = "cbxShowAll";
            this.cbxShowAll.Properties.Caption = "Hiện ds chuyến bay chưa map";
            this.cbxShowAll.Size = new System.Drawing.Size(246, 23);
            this.cbxShowAll.TabIndex = 3;
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnExport);
            this.panelNav.Controls.Add(this.txtKeyword);
            this.panelNav.Controls.Add(this.btnEdit);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelNav.Margin = new System.Windows.Forms.Padding(4);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1362, 48);
            this.panelNav.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExport.Location = new System.Drawing.Point(1248, 6);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 37);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.EditValue = "";
            this.txtKeyword.Location = new System.Drawing.Point(546, 12);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(4);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Properties.NullValuePrompt = "Tìm kiếm theo flightno, route, msnv, tên";
            this.txtKeyword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKeyword.Size = new System.Drawing.Size(494, 26);
            this.txtKeyword.TabIndex = 5;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnEdit.Location = new System.Drawing.Point(1137, 6);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 37);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit mode";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(298, 18);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "đến";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSearch.Location = new System.Drawing.Point(1048, 7);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 37);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "&Search";
            this.btnSearch.ToolTip = "Xem danh sách chuyến bay";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 19);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(88, 13);
            this.txtFromdate.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtFromdate.Size = new System.Drawing.Size(196, 26);
            this.txtFromdate.TabIndex = 1;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(345, 13);
            this.txtTodate.Margin = new System.Windows.Forms.Padding(4);
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
            this.txtTodate.Size = new System.Drawing.Size(192, 26);
            this.txtTodate.TabIndex = 3;
            // 
            // FrmFlightFONetline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 968);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmFlightFONetline";
            this.Text = "FrmFlightFONetline";
            this.Load += new System.EventHandler(this.FrmFlightFONetline_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxShowAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFO;
        private DevExpress.XtraEditors.CheckEdit cbxShowAll;
        private DevExpress.XtraGrid.GridControl gc2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOCC;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riSync;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.TextEdit txtKeyword;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
        private DevExpress.XtraEditors.SimpleButton btnExport;
    }
}