namespace CrewInfo.Forms.VNCrew
{
    partial class FrmImportFormCategory
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
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvBaoCao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvExport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 34);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType});
            this.gc.Size = new System.Drawing.Size(588, 414);
            this.gc.TabIndex = 18;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gvBA,
            this.gvBaoCao,
            this.gvExport});
            // 
            // gv
            // 
            this.gv.Appearance.Row.Options.UseTextOptions = true;
            this.gv.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gv.GridControl = this.gc;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gv.Name = "gv";
            this.gv.OptionsPrint.AutoWidth = false;
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.RowAutoHeight = true;
            this.gv.OptionsView.ShowFooter = true;
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
            // gvBaoCao
            // 
            this.gvBaoCao.Appearance.Row.Options.UseTextOptions = true;
            this.gvBaoCao.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gvBaoCao.GridControl = this.gc;
            this.gvBaoCao.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gvBaoCao.Name = "gvBaoCao";
            this.gvBaoCao.OptionsBehavior.Editable = false;
            this.gvBaoCao.OptionsPrint.AutoWidth = false;
            this.gvBaoCao.OptionsView.ColumnAutoWidth = false;
            this.gvBaoCao.OptionsView.RowAutoHeight = true;
            this.gvBaoCao.OptionsView.ShowFooter = true;
            // 
            // gvExport
            // 
            this.gvExport.Appearance.Row.Options.UseTextOptions = true;
            this.gvExport.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gvExport.GridControl = this.gc;
            this.gvExport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gvExport.Name = "gvExport";
            this.gvExport.OptionsBehavior.Editable = false;
            this.gvExport.OptionsPrint.AutoWidth = false;
            this.gvExport.OptionsView.ColumnAutoWidth = false;
            this.gvExport.OptionsView.RowAutoHeight = true;
            this.gvExport.OptionsView.ShowFooter = true;
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnLuu);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(588, 34);
            this.panelNav.TabIndex = 17;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(501, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmImportFormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 448);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmImportFormCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập loại nguyện vọng";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn clisCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn clANote;
        private DevExpress.XtraGrid.Columns.GridColumn clAActive;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBaoCao;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExport;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
    }
}