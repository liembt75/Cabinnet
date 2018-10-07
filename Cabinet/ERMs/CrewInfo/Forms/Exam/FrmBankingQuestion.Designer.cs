namespace CrewInfo.Forms.Exam
{
    partial class FrmBankingQuestion
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBQ = new DevExpress.XtraGrid.GridControl();
            this.gvBQ = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clQuestionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clQuestion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCrewType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAircraft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.txtQuestionFilter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkeQuestionType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuestionFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeQuestionType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBA
            // 
            this.gvBA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clAnswer,
            this.clisCorrect,
            this.clANote,
            this.clAActive});
            this.gvBA.GridControl = this.gcBQ;
            this.gvBA.Name = "gvBA";
            this.gvBA.OptionsBehavior.Editable = false;
            this.gvBA.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvBA.OptionsView.ShowGroupPanel = false;
            this.gvBA.ViewCaption = "Câu hỏi";
            this.gvBA.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvBA_InitNewRow);
            this.gvBA.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvBA_InvalidRowException);
            this.gvBA.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvBA_ValidateRow);
            this.gvBA.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvBA_RowUpdated);
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
            // gcBQ
            // 
            this.gcBQ.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = this.gvBA;
            gridLevelNode2.RelationName = "ExamBankingAnswer";
            this.gcBQ.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gcBQ.Location = new System.Drawing.Point(0, 35);
            this.gcBQ.MainView = this.gvBQ;
            this.gcBQ.Name = "gcBQ";
            this.gcBQ.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType});
            this.gcBQ.Size = new System.Drawing.Size(716, 575);
            this.gcBQ.TabIndex = 8;
            this.gcBQ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBQ,
            this.gvBA});
            // 
            // gvBQ
            // 
            this.gvBQ.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clQuestionType,
            this.clQuestion,
            this.clCrewType,
            this.clAircraft,
            this.clNote,
            this.clActive});
            this.gvBQ.GridControl = this.gcBQ;
            this.gvBQ.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gvBQ.Name = "gvBQ";
            this.gvBQ.OptionsBehavior.Editable = false;
            this.gvBQ.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvBQ.OptionsView.ColumnAutoWidth = false;
            this.gvBQ.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvBQ.OptionsView.ShowFooter = true;
            this.gvBQ.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gvBQ_MasterRowGetChildList);
            this.gvBQ.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvBQ_InitNewRow);
            this.gvBQ.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvBQ_InvalidRowException);
            this.gvBQ.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvBQ_ValidateRow);
            this.gvBQ.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvBQ_RowUpdated);
            // 
            // clQuestionType
            // 
            this.clQuestionType.Caption = "Type";
            this.clQuestionType.ColumnEdit = this.rlkeQuestionType;
            this.clQuestionType.FieldName = "QuestionType";
            this.clQuestionType.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clQuestionType.Name = "clQuestionType";
            this.clQuestionType.Visible = true;
            this.clQuestionType.VisibleIndex = 0;
            this.clQuestionType.Width = 53;
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
            // clQuestion
            // 
            this.clQuestion.Caption = "Question";
            this.clQuestion.FieldName = "Question";
            this.clQuestion.Name = "clQuestion";
            this.clQuestion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Question", "{0}")});
            this.clQuestion.Visible = true;
            this.clQuestion.VisibleIndex = 1;
            this.clQuestion.Width = 600;
            // 
            // clCrewType
            // 
            this.clCrewType.Caption = "CrewType";
            this.clCrewType.FieldName = "CrewType";
            this.clCrewType.Name = "clCrewType";
            this.clCrewType.Width = 40;
            // 
            // clAircraft
            // 
            this.clAircraft.Caption = "Aircraft";
            this.clAircraft.FieldName = "Aircraft";
            this.clAircraft.Name = "clAircraft";
            this.clAircraft.Visible = true;
            this.clAircraft.VisibleIndex = 2;
            this.clAircraft.Width = 40;
            // 
            // clNote
            // 
            this.clNote.Caption = "Note";
            this.clNote.FieldName = "Note";
            this.clNote.Name = "clNote";
            this.clNote.Visible = true;
            this.clNote.VisibleIndex = 3;
            this.clNote.Width = 95;
            // 
            // clActive
            // 
            this.clActive.Caption = "Active";
            this.clActive.FieldName = "Active";
            this.clActive.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.clActive.Name = "clActive";
            this.clActive.Visible = true;
            this.clActive.VisibleIndex = 4;
            this.clActive.Width = 41;
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.txtQuestionFilter);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.lkeQuestionType);
            this.panelNav.Controls.Add(this.btnUpdate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(716, 35);
            this.panelNav.TabIndex = 7;
            // 
            // txtQuestionFilter
            // 
            this.txtQuestionFilter.Location = new System.Drawing.Point(237, 8);
            this.txtQuestionFilter.Name = "txtQuestionFilter";
            this.txtQuestionFilter.Size = new System.Drawing.Size(140, 20);
            this.txtQuestionFilter.TabIndex = 6;
            this.txtQuestionFilter.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(188, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Question";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Type";
            // 
            // lkeQuestionType
            // 
            this.lkeQuestionType.Location = new System.Drawing.Point(42, 8);
            this.lkeQuestionType.Name = "lkeQuestionType";
            this.lkeQuestionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeQuestionType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Title", "Title")});
            this.lkeQuestionType.Properties.NullText = "";
            this.lkeQuestionType.Size = new System.Drawing.Size(140, 20);
            this.lkeQuestionType.TabIndex = 3;
            this.lkeQuestionType.EditValueChanged += new System.EventHandler(this.lkeQuestionType_EditValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdate.Location = new System.Drawing.Point(611, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.ToolTip = "Xem danh sách chuyến bay";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FrmBankingQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.gcBQ);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmBankingQuestion";
            this.Text = "Quản lý ngân hàng câu hỏi";
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuestionFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeQuestionType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.GridControl gcBQ;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBQ;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeQuestionType;
        private DevExpress.XtraEditors.TextEdit txtQuestionFilter;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn clQuestionType;
        private DevExpress.XtraGrid.Columns.GridColumn clQuestion;
        private DevExpress.XtraGrid.Columns.GridColumn clCrewType;
        private DevExpress.XtraGrid.Columns.GridColumn clAircraft;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn clisCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn clANote;
        private DevExpress.XtraGrid.Columns.GridColumn clAActive;
    }
}