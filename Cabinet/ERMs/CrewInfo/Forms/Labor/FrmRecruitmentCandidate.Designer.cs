namespace CrewInfo.Forms.Labor
{
    partial class FrmRecruitmentCandidate
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
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 35);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType,
            this.repositoryItemImageComboBox1});
            this.gc.Size = new System.Drawing.Size(793, 343);
            this.gc.TabIndex = 12;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gvBA});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn17,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn25,
            this.gridColumn26});
            this.gv.GridControl = this.gc;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsFind.AlwaysVisible = true;
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.ShowFooter = true;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Id";
            this.gridColumn27.FieldName = "Id";
            this.gridColumn27.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", "{0}")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "FullName";
            this.gridColumn7.FieldName = "FullName";
            this.gridColumn7.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Gender";
            this.gridColumn8.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn8.FieldName = "Gender";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nam", false, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Nữ", true, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "DateOfBirth";
            this.gridColumn9.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn9.FieldName = "DateOfBirth";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "PlaceOfOrigin";
            this.gridColumn10.FieldName = "PlaceOfOrigin";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdentityOrPassportNo";
            this.gridColumn11.FieldName = "IdentityOrPassportNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IssueDate";
            this.gridColumn12.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "IssueDate";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "IssuePlace";
            this.gridColumn13.FieldName = "IssuePlace";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Address";
            this.gridColumn14.FieldName = "Address";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Phone1";
            this.gridColumn15.FieldName = "Phone1";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Phone2";
            this.gridColumn16.FieldName = "Phone2";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "EducationLevel";
            this.gridColumn18.FieldName = "EducationLevelText";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 11;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "ForeignLanguageLevel";
            this.gridColumn19.FieldName = "ForeignLanguageLevelText";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 12;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "ForeignLanguageTestedDate";
            this.gridColumn20.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn20.FieldName = "ForeignLanguageTestedDate";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 13;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "ForeignLanguageTestedPoint";
            this.gridColumn21.FieldName = "ForeignLanguageTestedPoint";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 14;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "ForeignLanguageOther";
            this.gridColumn22.FieldName = "ForeignLanguageOther";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 15;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Gifted";
            this.gridColumn23.FieldName = "Gifted";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 16;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "PastCompany";
            this.gridColumn24.FieldName = "PastCompany";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 17;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Email";
            this.gridColumn17.FieldName = "Email";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 18;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CandidateType";
            this.gridColumn1.FieldName = "CandidateTypeText";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 19;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KnowledgeInfoBy";
            this.gridColumn2.FieldName = "KnowledgeInfoByText";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 20;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "TestPlace";
            this.gridColumn3.FieldName = "TestPlaceText";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 21;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TestLanguage";
            this.gridColumn4.FieldName = "TestLanguageText";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 22;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TestedPlace";
            this.gridColumn5.FieldName = "TestedPlaceText";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 23;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TestedDate";
            this.gridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "TestedDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 24;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Modified";
            this.gridColumn25.FieldName = "Modified";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 25;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "AttachmentID";
            this.gridColumn26.FieldName = "AttachmentID";
            this.gridColumn26.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 26;
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
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnExcel);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(793, 35);
            this.panelNav.TabIndex = 11;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(702, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(86, 23);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmRecruitmentCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 378);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmRecruitmentCandidate";
            this.Text = "Ứng viên";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}