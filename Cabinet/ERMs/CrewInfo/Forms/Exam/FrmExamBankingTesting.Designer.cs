namespace CrewInfo.Forms.Exam
{
    partial class FrmExamBankingTesting
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clTSQuestionBankType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.clTSAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTSNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEB = new DevExpress.XtraGrid.GridControl();
            this.gvEB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.clDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clScoreExpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFromdate = new DevExpress.XtraEditors.DateEdit();
            this.txtTodate = new DevExpress.XtraEditors.DateEdit();
            this.btnExamineeList = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTodate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBA
            // 
            this.gvBA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clTSQuestionBankType,
            this.clTSAmount,
            this.clTSNote});
            this.gvBA.GridControl = this.gcEB;
            this.gvBA.Name = "gvBA";
            this.gvBA.OptionsBehavior.Editable = false;
            this.gvBA.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvBA.OptionsView.ShowFooter = true;
            this.gvBA.OptionsView.ShowGroupPanel = false;
            this.gvBA.ViewCaption = "Câu hỏi";
            this.gvBA.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvBA_InvalidRowException);
            this.gvBA.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvBA_ValidateRow);
            this.gvBA.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvBA_RowUpdated);
            // 
            // clTSQuestionBankType
            // 
            this.clTSQuestionBankType.Caption = "QuestionType";
            this.clTSQuestionBankType.ColumnEdit = this.rlkeQuestionType;
            this.clTSQuestionBankType.FieldName = "QuestionBankType";
            this.clTSQuestionBankType.Name = "clTSQuestionBankType";
            this.clTSQuestionBankType.Visible = true;
            this.clTSQuestionBankType.VisibleIndex = 0;
            this.clTSQuestionBankType.Width = 150;
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
            // clTSAmount
            // 
            this.clTSAmount.Caption = "Amount";
            this.clTSAmount.FieldName = "Amount";
            this.clTSAmount.Name = "clTSAmount";
            this.clTSAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Tổng={0:0.##}")});
            this.clTSAmount.Visible = true;
            this.clTSAmount.VisibleIndex = 1;
            this.clTSAmount.Width = 150;
            // 
            // clTSNote
            // 
            this.clTSNote.Caption = "Note";
            this.clTSNote.FieldName = "Note";
            this.clTSNote.Name = "clTSNote";
            this.clTSNote.Visible = true;
            this.clTSNote.VisibleIndex = 2;
            this.clTSNote.Width = 598;
            // 
            // gcEB
            // 
            this.gcEB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEB.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.LevelTemplate = this.gvBA;
            gridLevelNode1.RelationName = "ExamBankingTestingSection";
            this.gcEB.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcEB.Location = new System.Drawing.Point(0, 51);
            this.gcEB.MainView = this.gvEB;
            this.gcEB.Margin = new System.Windows.Forms.Padding(4);
            this.gcEB.Name = "gcEB";
            this.gcEB.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.rlkeQuestionType,
            this.repositoryItemHyperLinkEdit1,
            this.repCategory,
            this.repositoryItemImageComboBox1});
            this.gcEB.Size = new System.Drawing.Size(1074, 841);
            this.gcEB.TabIndex = 9;
            this.gcEB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEB,
            this.gvBA});
            // 
            // gvEB
            // 
            this.gvEB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clID,
            this.clCategory,
            this.clCode,
            this.clTitle,
            this.clDescription,
            this.clStartTime,
            this.clDuration,
            this.clAmount,
            this.clScoreExpec,
            this.clNote,
            this.clCreator,
            this.clActive});
            this.gvEB.GridControl = this.gcEB;
            this.gvEB.Name = "gvEB";
            this.gvEB.OptionsBehavior.Editable = false;
            this.gvEB.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gvEB.OptionsView.ColumnAutoWidth = false;
            this.gvEB.OptionsView.EnableAppearanceEvenRow = true;
            this.gvEB.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvEB.OptionsView.ShowFooter = true;
            this.gvEB.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gvEB_MasterRowGetChildList);
            this.gvEB.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvEB_InitNewRow);
            this.gvEB.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvEB_InvalidRowException);
            this.gvEB.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEB_ValidateRow);
            this.gvEB.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvEB_RowUpdated);
            // 
            // clID
            // 
            this.clID.Caption = "ID";
            this.clID.FieldName = "ID";
            this.clID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.clID.Name = "clID";
            this.clID.OptionsColumn.ReadOnly = true;
            this.clID.Visible = true;
            this.clID.VisibleIndex = 0;
            this.clID.Width = 30;
            // 
            // clCategory
            // 
            this.clCategory.Caption = "Loại";
            this.clCategory.FieldName = "Category";
            this.clCategory.Name = "clCategory";
            this.clCategory.Visible = true;
            this.clCategory.VisibleIndex = 1;
            this.clCategory.Width = 54;
            // 
            // clCode
            // 
            this.clCode.Caption = "Mã";
            this.clCode.FieldName = "Code";
            this.clCode.Name = "clCode";
            this.clCode.OptionsColumn.ReadOnly = true;
            this.clCode.Visible = true;
            this.clCode.VisibleIndex = 2;
            this.clCode.Width = 36;
            // 
            // clTitle
            // 
            this.clTitle.Caption = "Tựa đề";
            this.clTitle.FieldName = "Title";
            this.clTitle.Name = "clTitle";
            this.clTitle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Title", "{0}")});
            this.clTitle.Visible = true;
            this.clTitle.VisibleIndex = 3;
            this.clTitle.Width = 106;
            // 
            // clDescription
            // 
            this.clDescription.Caption = "Mô tả";
            this.clDescription.FieldName = "Description";
            this.clDescription.Name = "clDescription";
            this.clDescription.Visible = true;
            this.clDescription.VisibleIndex = 4;
            this.clDescription.Width = 106;
            // 
            // clStartTime
            // 
            this.clStartTime.Caption = "Thời gian bắt đầu";
            this.clStartTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.clStartTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.clStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clStartTime.FieldName = "StartTime";
            this.clStartTime.Name = "clStartTime";
            this.clStartTime.ToolTip = "Thời gian bắt đầu thi";
            this.clStartTime.Visible = true;
            this.clStartTime.VisibleIndex = 5;
            this.clStartTime.Width = 72;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // clDuration
            // 
            this.clDuration.Caption = "Phút";
            this.clDuration.FieldName = "Duration";
            this.clDuration.Name = "clDuration";
            this.clDuration.ToolTip = "Thời gian làm bài (phút)";
            this.clDuration.Visible = true;
            this.clDuration.VisibleIndex = 6;
            this.clDuration.Width = 36;
            // 
            // clAmount
            // 
            this.clAmount.Caption = "Tổng số câu";
            this.clAmount.FieldName = "Amount";
            this.clAmount.Name = "clAmount";
            this.clAmount.OptionsColumn.ReadOnly = true;
            this.clAmount.Visible = true;
            this.clAmount.VisibleIndex = 7;
            this.clAmount.Width = 36;
            // 
            // clScoreExpec
            // 
            this.clScoreExpec.Caption = "Y/C";
            this.clScoreExpec.FieldName = "ScoreExpec";
            this.clScoreExpec.Name = "clScoreExpec";
            this.clScoreExpec.ToolTip = "Số câu đúng tối thiểu";
            this.clScoreExpec.Visible = true;
            this.clScoreExpec.VisibleIndex = 8;
            this.clScoreExpec.Width = 36;
            // 
            // clNote
            // 
            this.clNote.Caption = "Ghi chú";
            this.clNote.FieldName = "Note";
            this.clNote.Name = "clNote";
            this.clNote.ToolTip = "Ghi chú";
            this.clNote.Width = 50;
            // 
            // clCreator
            // 
            this.clCreator.Caption = "Người tạo";
            this.clCreator.FieldName = "Creator";
            this.clCreator.Name = "clCreator";
            this.clCreator.Visible = true;
            this.clCreator.VisibleIndex = 9;
            this.clCreator.Width = 57;
            // 
            // clActive
            // 
            this.clActive.Caption = "Active";
            this.clActive.FieldName = "Active";
            this.clActive.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.clActive.Name = "clActive";
            this.clActive.Visible = true;
            this.clActive.VisibleIndex = 10;
            this.clActive.Width = 32;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repCategory
            // 
            this.repCategory.AutoHeight = false;
            this.repCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCategory.Name = "repCategory";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("NA", 0, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdate.Location = new System.Drawing.Point(916, 7);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 37);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.ToolTip = "Xem danh sách chuyến bay";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.labelControl2);
            this.panelNav.Controls.Add(this.labelControl1);
            this.panelNav.Controls.Add(this.txtFromdate);
            this.panelNav.Controls.Add(this.txtTodate);
            this.panelNav.Controls.Add(this.btnExamineeList);
            this.panelNav.Controls.Add(this.btnUpdate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Margin = new System.Windows.Forms.Padding(4);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1074, 51);
            this.panelNav.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(530, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 34);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(292, 16);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 19);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 16);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 19);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Ngày thi";
            // 
            // txtFromdate
            // 
            this.txtFromdate.EditValue = null;
            this.txtFromdate.Location = new System.Drawing.Point(87, 12);
            this.txtFromdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromdate.Name = "txtFromdate";
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
            this.txtFromdate.TabIndex = 21;
            // 
            // txtTodate
            // 
            this.txtTodate.EditValue = null;
            this.txtTodate.Location = new System.Drawing.Point(328, 12);
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
            this.txtTodate.TabIndex = 23;
            // 
            // btnExamineeList
            // 
            this.btnExamineeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExamineeList.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExamineeList.Location = new System.Drawing.Point(758, 7);
            this.btnExamineeList.Margin = new System.Windows.Forms.Padding(4);
            this.btnExamineeList.Name = "btnExamineeList";
            this.btnExamineeList.Size = new System.Drawing.Size(150, 37);
            this.btnExamineeList.TabIndex = 7;
            this.btnExamineeList.Text = "Danh sách thí sinh";
            this.btnExamineeList.ToolTip = "Xem danh sách thí sinh";
            this.btnExamineeList.Click += new System.EventHandler(this.btnExamineeList_Click);
            // 
            // FrmExamBankingTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 892);
            this.Controls.Add(this.gcEB);
            this.Controls.Add(this.panelNav);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmExamBankingTesting";
            this.Text = "Quản lý đề thi";
            this.Load += new System.EventHandler(this.FrmExamBankingTesting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcEB;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEB;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraGrid.Columns.GridColumn clCode;
        private DevExpress.XtraGrid.Columns.GridColumn clTitle;
        private DevExpress.XtraGrid.Columns.GridColumn clDescription;
        private DevExpress.XtraGrid.Columns.GridColumn clStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn clDuration;
        private DevExpress.XtraGrid.Columns.GridColumn clAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clScoreExpec;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clTSQuestionBankType;
        private DevExpress.XtraGrid.Columns.GridColumn clTSAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clTSNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.SimpleButton btnExamineeList;
        private DevExpress.XtraGrid.Columns.GridColumn clCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn clID;
        private DevExpress.XtraGrid.Columns.GridColumn clCreator;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFromdate;
        private DevExpress.XtraEditors.DateEdit txtTodate;
    }
}