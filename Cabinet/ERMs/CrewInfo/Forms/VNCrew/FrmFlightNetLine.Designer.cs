namespace CrewInfo.Forms.VNCrew
{
    partial class FrmFlightNetLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFlightNetLine));
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gc1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbxShowAll = new DevExpress.XtraEditors.CheckEdit();
            this.gc2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riSync = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.bgv = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxShowAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 41);
            this.panelNav.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSearch.Location = new System.Drawing.Point(356, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(191, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Từ ngày";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(51, 12);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.txtFromdate.TabIndex = 19;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(222, 12);
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.txtTodate.TabIndex = 21;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 41);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(716, 569);
            this.xtraTabControl1.TabIndex = 26;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(710, 541);
            this.xtraTabPage2.Text = "Fo->Netline";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gc1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.cbxShowAll);
            this.splitContainerControl1.Panel2.Controls.Add(this.gc2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(710, 541);
            this.splitContainerControl1.SplitterPosition = 315;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gc1
            // 
            this.gc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc1.Location = new System.Drawing.Point(0, 0);
            this.gc1.MainView = this.gv1;
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(315, 541);
            this.gc1.TabIndex = 2;
            this.gc1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
            // 
            // gv1
            // 
            this.gv1.GridControl = this.gc1;
            this.gv1.Name = "gv1";
            this.gv1.OptionsView.ColumnAutoWidth = false;
            this.gv1.OptionsView.ShowFooter = true;
            this.gv1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv1_FocusedRowChanged);
            // 
            // cbxShowAll
            // 
            this.cbxShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxShowAll.Location = new System.Drawing.Point(219, 3);
            this.cbxShowAll.Name = "cbxShowAll";
            this.cbxShowAll.Properties.Caption = "Hiện ds chuyến bay chưa map";
            this.cbxShowAll.Size = new System.Drawing.Size(164, 19);
            this.cbxShowAll.TabIndex = 3;
            this.cbxShowAll.CheckedChanged += new System.EventHandler(this.cbxShowAll_CheckedChanged);
            // 
            // gc2
            // 
            this.gc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc2.Location = new System.Drawing.Point(0, 0);
            this.gc2.MainView = this.gv2;
            this.gc2.Name = "gc2";
            this.gc2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riSync});
            this.gc2.Size = new System.Drawing.Size(390, 541);
            this.gc2.TabIndex = 2;
            this.gc2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv2});
            // 
            // gv2
            // 
            this.gv2.GridControl = this.gc2;
            this.gv2.Name = "gv2";
            this.gv2.OptionsView.ColumnAutoWidth = false;
            this.gv2.OptionsView.ShowFooter = true;
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
            this.riSync.SmallImages = this.imageCollection1;
            this.riSync.Click += new System.EventHandler(this.riSync_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("reset2_16x16.png", "images/actions/reset2_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/reset2_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "reset2_16x16.png");
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gc);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(710, 541);
            this.xtraTabPage1.Text = "DS chuyến bay";
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.MainView = this.bgv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(710, 541);
            this.gc.TabIndex = 2;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgv});
            // 
            // bgv
            // 
            this.bgv.GridControl = this.gc;
            this.bgv.Name = "bgv";
            this.bgv.OptionsSelection.MultiSelect = true;
            this.bgv.OptionsView.ColumnAutoWidth = false;
            this.bgv.OptionsView.ShowFooter = true;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(710, 541);
            this.xtraTabPage3.Text = "Netline -> FO";
            // 
            // FrmFlightNetLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmFlightNetLine";
            this.Text = "NetLine filghts";
            this.Load += new System.EventHandler(this.FrmFlightNetLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxShowAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgv;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gc1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.GridControl gc2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riSync;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.CheckEdit cbxShowAll;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
    }
}