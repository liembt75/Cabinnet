namespace CrewInfo.Forms.Briefing
{
    partial class FrmBriefingDiary
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
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnExcel);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Controls.Add(this.btnUpdate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 41);
            this.panelNav.TabIndex = 11;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExcel.Location = new System.Drawing.Point(363, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(100, 25);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(198, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Từ ngày";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(58, 7);
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
            this.txtFromdate.TabIndex = 7;
            this.txtFromdate.EditValueChanged += new System.EventHandler(this.txtFromdate_EditValueChanged);
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(229, 7);
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
            this.txtTodate.TabIndex = 9;
            this.txtTodate.EditValueChanged += new System.EventHandler(this.txtTodate_EditValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdate.Location = new System.Drawing.Point(611, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Thêm";
            this.btnUpdate.ToolTip = "Xem danh sách chuyến bay";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 41);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType});
            this.gc.Size = new System.Drawing.Size(716, 569);
            this.gc.TabIndex = 12;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gvBA});
            // 
            // gv
            // 
            this.gv.Appearance.Row.Options.UseTextOptions = true;
            this.gv.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gv.GridControl = this.gc;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsFind.AlwaysVisible = true;
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.RowAutoHeight = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gv_RowCellClick);
            // 
            // rlkeQuestionType
            // 
            this.rlkeQuestionType.AutoHeight = false;
            this.rlkeQuestionType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkeQuestionType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Title", "Title")});
            this.rlkeQuestionType.Name = "rlkeQuestionType";
            this.rlkeQuestionType.NullText = "";
            // 
            // gvBA
            // 
            this.gvBA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clAnswer,
            this.clisCorrect,
            this.clANote,
            this.clAActive});
            this.gvBA.GridControl = this.gc;
            this.gvBA.Name = "gvBA";
            this.gvBA.OptionsBehavior.Editable = false;
            this.gvBA.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvBA.OptionsView.ShowGroupPanel = false;
            this.gvBA.ViewCaption = "Câu hỏi";
            // 
            // clAnswer
            // 
            this.clAnswer.Caption = "Answer";
            this.clAnswer.FieldName = "Answer";
            this.clAnswer.Name = "clAnswer";
            this.clAnswer.Visible = true;
            this.clAnswer.VisibleIndex = 0;
            this.clAnswer.Width = 500;
            // 
            // clisCorrect
            // 
            this.clisCorrect.Caption = "isCorrect";
            this.clisCorrect.FieldName = "isCorrect";
            this.clisCorrect.Name = "clisCorrect";
            this.clisCorrect.Visible = true;
            this.clisCorrect.VisibleIndex = 1;
            this.clisCorrect.Width = 40;
            // 
            // clANote
            // 
            this.clANote.Caption = "Note";
            this.clANote.FieldName = "Note";
            this.clANote.Name = "clANote";
            this.clANote.Visible = true;
            this.clANote.VisibleIndex = 2;
            this.clANote.Width = 132;
            // 
            // clAActive
            // 
            this.clAActive.Caption = "Active";
            this.clAActive.FieldName = "Active";
            this.clAActive.Name = "clAActive";
            this.clAActive.Visible = true;
            this.clAActive.VisibleIndex = 3;
            this.clAActive.Width = 40;
            // 
            // FrmBriefingDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmBriefingDiary";
            this.Text = "Nhật ký trực briefing";
            this.Load += new System.EventHandler(this.FrmBriefingDiary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn clisCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn clANote;
        private DevExpress.XtraGrid.Columns.GridColumn clAActive;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}