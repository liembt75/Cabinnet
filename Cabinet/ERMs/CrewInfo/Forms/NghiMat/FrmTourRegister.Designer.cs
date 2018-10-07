namespace CrewInfo.Forms.NghiMat
{
    partial class FrmTourRegister
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMSNV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportEx = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcelImport = new DevExpress.XtraEditors.SimpleButton();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rlkeQuestionType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvBA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAnswer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clisCorrect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clANote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.newBtn = new DevExpress.XtraBars.BarButtonItem();
            this.huyBtn = new DevExpress.XtraBars.BarButtonItem();
            this.boTourbtn = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoTour = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtMSNV);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnExportEx);
            this.panelControl1.Controls.Add(this.btnExcelImport);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(686, 66);
            this.panelControl1.TabIndex = 24;
            // 
            // txtMSNV
            // 
            this.txtMSNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMSNV.Location = new System.Drawing.Point(56, 9);
            this.txtMSNV.Name = "txtMSNV";
            this.txtMSNV.Properties.NullValuePrompt = "Các msnv cách nhau bằng dấu \",\" ví dụ: 1234,5678";
            this.txtMSNV.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtMSNV.Size = new System.Drawing.Size(618, 20);
            this.txtMSNV.TabIndex = 12;
            this.txtMSNV.EditValueChanged += new System.EventHandler(this.txtMSNV_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "MSNV";
            // 
            // btnExportEx
            // 
            this.btnExportEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportEx.Location = new System.Drawing.Point(599, 37);
            this.btnExportEx.Name = "btnExportEx";
            this.btnExportEx.Size = new System.Drawing.Size(75, 23);
            this.btnExportEx.TabIndex = 1;
            this.btnExportEx.Text = "Xuất excel";
            this.btnExportEx.Click += new System.EventHandler(this.btnExportEx_Click);
            // 
            // btnExcelImport
            // 
            this.btnExcelImport.Location = new System.Drawing.Point(5, 37);
            this.btnExcelImport.Name = "btnExcelImport";
            this.btnExcelImport.Size = new System.Drawing.Size(75, 23);
            this.btnExcelImport.TabIndex = 0;
            this.btnExcelImport.Text = "Nhập từ excel";
            this.btnExcelImport.Click += new System.EventHandler(this.btnExcelImport_Click);
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 66);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkeQuestionType});
            this.gc.Size = new System.Drawing.Size(686, 356);
            this.gc.TabIndex = 25;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gv1,
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
            this.gv.OptionsPrint.AutoWidth = false;
            this.gv.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gv.OptionsSelection.MultiSelect = true;
            this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gv_ShowingEditor);
            this.gv.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gv_InvalidRowException);
            this.gv.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gv_ValidateRow);
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
            // gv1
            // 
            this.gv1.GridControl = this.gc;
            this.gv1.Name = "gv1";
            this.gv1.OptionsView.ColumnAutoWidth = false;
            this.gv1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gv1.OptionsView.RowAutoHeight = true;
            this.gv1.OptionsView.ShowGroupPanel = false;
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
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.newBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.huyBtn),
            new DevExpress.XtraBars.LinkPersistInfo(this.boTourbtn)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // newBtn
            // 
            this.newBtn.Caption = "Mới đăng ký";
            this.newBtn.Id = 3;
            this.newBtn.Name = "newBtn";
            this.newBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newBtn_ItemClick);
            // 
            // huyBtn
            // 
            this.huyBtn.Caption = "Hủy";
            this.huyBtn.Id = 4;
            this.huyBtn.Name = "huyBtn";
            this.huyBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.huyBtn_ItemClick);
            // 
            // boTourbtn
            // 
            this.boTourbtn.Caption = "Bỏ tour";
            this.boTourbtn.Id = 5;
            this.boTourbtn.Name = "boTourbtn";
            this.boTourbtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.boTourbtn_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiExcel,
            this.bbiReport,
            this.barButtonItem1,
            this.newBtn,
            this.huyBtn,
            this.boTourbtn});
            this.barManager1.MaxItemId = 6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(686, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 422);
            this.barDockControlBottom.Size = new System.Drawing.Size(686, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 422);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(686, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 422);
            // 
            // bbiExcel
            // 
            this.bbiExcel.Caption = "Excel";
            this.bbiExcel.Id = 0;
            this.bbiExcel.ImageUri.Uri = "ExportToXLS";
            this.bbiExcel.Name = "bbiExcel";
            // 
            // bbiReport
            // 
            this.bbiReport.Caption = "In đơn nguyện vọng";
            this.bbiReport.Id = 1;
            this.bbiReport.ImageUri.Uri = "Today";
            this.bbiReport.Name = "bbiReport";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "In đơn xem xét HĐLĐ";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageUri.Uri = "Paste";
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnBoTour
            // 
            this.btnBoTour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoTour.Location = new System.Drawing.Point(552, 399);
            this.btnBoTour.Name = "btnBoTour";
            this.btnBoTour.Size = new System.Drawing.Size(75, 23);
            this.btnBoTour.TabIndex = 31;
            this.btnBoTour.Text = "Bỏ tour";
            this.btnBoTour.Click += new System.EventHandler(this.btnBoTour_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(471, 399);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 32;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FrmTourRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 422);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnBoTour);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTourRegister";
            this.Text = "DS Đăng ký";
            this.Load += new System.EventHandler(this.FrmTourRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkeQuestionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcelImport;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkeQuestionType;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBA;
        private DevExpress.XtraGrid.Columns.GridColumn clAnswer;
        private DevExpress.XtraGrid.Columns.GridColumn clisCorrect;
        private DevExpress.XtraGrid.Columns.GridColumn clANote;
        private DevExpress.XtraGrid.Columns.GridColumn clAActive;
        private DevExpress.XtraEditors.SimpleButton btnExportEx;
        private DevExpress.XtraEditors.TextEdit txtMSNV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem bbiExcel;
        private DevExpress.XtraBars.BarButtonItem bbiReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem newBtn;
        private DevExpress.XtraBars.BarButtonItem huyBtn;
        private DevExpress.XtraBars.BarButtonItem boTourbtn;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnBoTour;
    }
}