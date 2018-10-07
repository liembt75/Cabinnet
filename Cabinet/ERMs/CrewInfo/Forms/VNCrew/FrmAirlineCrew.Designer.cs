namespace CrewInfo.Forms.VNCrew
{
    partial class FrmAirlineCrew
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
            this.gcAC = new DevExpress.XtraGrid.GridControl();
            this.gvAC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPrior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAircraft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clRouting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.clP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clExpired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelNav = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).BeginInit();
            this.panelNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcAC
            // 
            this.gcAC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAC.Location = new System.Drawing.Point(0, 35);
            this.gcAC.MainView = this.gvAC;
            this.gcAC.Name = "gcAC";
            this.gcAC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType,
            this.repositoryItemMemoEdit1});
            this.gcAC.Size = new System.Drawing.Size(662, 343);
            this.gcAC.TabIndex = 10;
            this.gcAC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAC,
            this.gvBA});
            // 
            // gvAC
            // 
            this.gvAC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.clPrior,
            this.clAircraft,
            this.clRouting,
            this.clP,
            this.clX,
            this.clB,
            this.clY,
            this.clNote,
            this.clExpired});
            this.gvAC.GridControl = this.gcAC;
            this.gvAC.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "QuestionType", null, "(Type: Count={0})")});
            this.gvAC.Name = "gvAC";
            this.gvAC.OptionsBehavior.Editable = false;
            this.gvAC.OptionsFind.AlwaysVisible = true;
            this.gvAC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvAC.OptionsView.RowAutoHeight = true;
            this.gvAC.OptionsView.ShowFooter = true;
            this.gvAC.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvAC_InitNewRow);
            this.gvAC.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvAC_InvalidRowException);
            this.gvAC.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvAC_ValidateRow);
            this.gvAC.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvAC_RowUpdated);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // clPrior
            // 
            this.clPrior.Caption = "Prior";
            this.clPrior.FieldName = "Prior";
            this.clPrior.Name = "clPrior";
            this.clPrior.ToolTip = "Giá trị càng nhỏ mức độ ưu tiên càng cao";
            this.clPrior.Visible = true;
            this.clPrior.VisibleIndex = 1;
            // 
            // clAircraft
            // 
            this.clAircraft.Caption = "Aircraft";
            this.clAircraft.FieldName = "Aircraft";
            this.clAircraft.Name = "clAircraft";
            this.clAircraft.ToolTip = "Các aircraft cách nhau bằng dấu chấm phẩy \";\". Ví dụ: VN931;VN930;....";
            this.clAircraft.Visible = true;
            this.clAircraft.VisibleIndex = 2;
            // 
            // clRouting
            // 
            this.clRouting.Caption = "Routing";
            this.clRouting.ColumnEdit = this.repositoryItemMemoEdit1;
            this.clRouting.FieldName = "Routing";
            this.clRouting.Name = "clRouting";
            this.clRouting.Visible = true;
            this.clRouting.VisibleIndex = 3;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // clP
            // 
            this.clP.Caption = "P";
            this.clP.FieldName = "P";
            this.clP.Name = "clP";
            this.clP.Visible = true;
            this.clP.VisibleIndex = 4;
            // 
            // clX
            // 
            this.clX.Caption = "X";
            this.clX.FieldName = "X";
            this.clX.Name = "clX";
            this.clX.Visible = true;
            this.clX.VisibleIndex = 5;
            // 
            // clB
            // 
            this.clB.Caption = "B";
            this.clB.FieldName = "B";
            this.clB.Name = "clB";
            this.clB.Visible = true;
            this.clB.VisibleIndex = 6;
            // 
            // clY
            // 
            this.clY.Caption = "Y";
            this.clY.FieldName = "Y";
            this.clY.Name = "clY";
            this.clY.Visible = true;
            this.clY.VisibleIndex = 7;
            // 
            // clNote
            // 
            this.clNote.Caption = "Note";
            this.clNote.FieldName = "Note";
            this.clNote.Name = "clNote";
            this.clNote.Visible = true;
            this.clNote.VisibleIndex = 8;
            // 
            // clExpired
            // 
            this.clExpired.Caption = "Expired";
            this.clExpired.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clExpired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clExpired.FieldName = "Expired";
            this.clExpired.Name = "clExpired";
            this.clExpired.Visible = true;
            this.clExpired.VisibleIndex = 9;
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
            this.gvBA.GridControl = this.gcAC;
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
            this.panelNav.Controls.Add(this.btnUpdate);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(662, 35);
            this.panelNav.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdate.Location = new System.Drawing.Point(557, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Chỉnh sửa";
            this.btnUpdate.ToolTip = "Xem danh sách chuyến bay";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FrmAirlineCrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 378);
            this.Controls.Add(this.gcAC);
            this.Controls.Add(this.panelNav);
            this.Name = "FrmAirlineCrew";
            this.Text = "Cơ cấu máy bay";
            ((System.ComponentModel.ISupportInitialize)(this.gcAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNav)).EndInit();
            this.panelNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAC;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn clPrior;
        private DevExpress.XtraGrid.Columns.GridColumn clAircraft;
        private DevExpress.XtraGrid.Columns.GridColumn clRouting;
        private DevExpress.XtraGrid.Columns.GridColumn clP;
        private DevExpress.XtraGrid.Columns.GridColumn clX;
        private DevExpress.XtraGrid.Columns.GridColumn clB;
        private DevExpress.XtraGrid.Columns.GridColumn clY;
        private DevExpress.XtraGrid.Columns.GridColumn clNote;
        private DevExpress.XtraGrid.Columns.GridColumn clExpired;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn clisCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn clANote;
        private DevExpress.XtraGrid.Columns.GridColumn clAActive;
        private DevExpress.XtraEditors.PanelControl panelNav;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}