using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERMs.Data.Task;
using ERMs.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Export;

namespace CrewInfo.Forms.Task
{
    public partial class FrmManagementTask : ERMs.SharedBase.XtraFormMDIBase
    {
       TaskDal  db = new TaskDal();
        SystemDAL dbSystem = new SystemDAL();
        BindingSource dataSource = new BindingSource();
        List<TokenEditToken> lstTokenAccount = new List<TokenEditToken>();
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;

        public FrmManagementTask()
        {
            InitializeComponent();
            LayoutInitial();
            InitListContact();
        }

        private void InitListContact()
        {            
            foreach (VHR_Employee_Department employee in dbSystem.GetEmployeeDepartment())
            {                
                lstTokenAccount.Add(new TokenEditToken(employee.FullNameWithDept, employee.ID.ToString()));
            }
        }

        GridColumn colID, colDate, colTitle, colDescription, colTaskMaster, colDeadline, colCompleted, colProgress, colReason, colDuedate, colCreated, colCreator;

        

        private void FrmManagementTask_Load(object sender, EventArgs e)
        {
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTodate.DateTime = DateTime.Now;
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            dataSource.DataSource = db.GetTasks(fromdate, todate, "", 0, 1000000, cbxAllTask.Checked, false, false, false, "", ERMs.Sys.ConfigurationSetting.UserInfo.Userid);

            gridControl1.DataSource = dataSource;
            gridView1.BestFitColumns();
            //btnSearch_Click(null, null);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks < 2) return;

            TaskModel selRow = (TaskModel)(((GridView)gridControl1.MainView).GetRow(e.RowHandle));
            //MessageBox.Show(selRow.Title);

            FrmTaskEdit frm = new FrmTaskEdit(selRow.ID, lstTokenAccount, this);
            frm.MdiParent = this.ParentForm;
            frm.Show();            

        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "Title")
            {
                TaskModel taskModel = gridView1.GetRow(e.RowHandle) as TaskModel;
                //int id = (int)e.CellValue;
                FrmTaskEdit frm = new FrmTaskEdit(taskModel.ID, lstTokenAccount, this);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "KLGB.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;                                
                gridView1.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {            
            FrmTaskEdit frm = new FrmTaskEdit(0, lstTokenAccount, this);            
            frm.MdiParent = this.ParentForm;
            frm.Show();

        }

        private void LayoutInitial()
        {
            this.Text = "KLGB";
            this.WindowState = FormWindowState.Maximized;
            panelControl1.Dock = DockStyle.Fill;
            gridControl1.Dock = DockStyle.Fill;

            #region Main View

            RepositoryItemDateEdit repoDate = new RepositoryItemDateEdit();
            repoDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repoDate.Mask.EditMask = "dd/MM/yyyy";
            repoDate.Mask.UseMaskAsDisplayFormat = true;
            repoDate.CharacterCasing = CharacterCasing.Upper;

            gridView1.OptionsPrint.AutoWidth = false;
            colID = new GridColumn();
            colID.Caption = "#";
            colID.FieldName = "ID";
            colID.Width = 40;
            colID.Visible = true;
            colID.Fixed = FixedStyle.Left;
            //colID.AppearanceCell.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold);
            //colID.AppearanceCell.Options.UseFont = true;
            //RepositoryItemHyperLinkEdit riHyperLink = new RepositoryItemHyperLinkEdit();
            //colID.ColumnEdit = riHyperLink;
            //colID.AppearanceCell.Options.UseTextOptions = true;
            //colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            colDate = new GridColumn();
            colDate.Caption = "Ngay";
            colDate.FieldName = "Date";
            colDate.Width = 70;
            colDate.Visible = true;
            colDate.Fixed = FixedStyle.Left;
            colDate.ColumnEdit = repoDate;
            colDate.AppearanceCell.Options.UseTextOptions = true;
            colDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            colTitle = new GridColumn();
            colTitle.Caption = "TieuDe";
            colTitle.FieldName = "Title";
            colTitle.Width = 200;
            colTitle.Visible = true;
            colTitle.Fixed = FixedStyle.Left;
            colTitle.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colTitle.SummaryItem.DisplayFormat = "{0:n0}";
            RepositoryItemMemoEdit riTitle = new RepositoryItemMemoEdit();
            colTitle.ColumnEdit = riTitle;
            colTitle.AppearanceCell.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold|FontStyle.Underline);
            colTitle.AppearanceCell.ForeColor = Color.Blue;
            colTitle.AppearanceCell.Options.UseFont = true;
            colTitle.AppearanceCell.Options.UseForeColor = true;

            colDescription = new GridColumn();
            colDescription.Caption = "NoiDung";
            colDescription.FieldName = "Description";
            colDescription.Width = 200;
            colDescription.Visible = true;
            RepositoryItemMemoEdit riDescription = new RepositoryItemMemoEdit();
            colDescription.ColumnEdit = riDescription;


            colTaskMaster = new GridColumn();
            colTaskMaster.Caption = "NguoiGiao";
            colTaskMaster.FieldName = "FullNameWithDept";
            colTaskMaster.Width = 70;
            colTaskMaster.Visible = true;
            colTaskMaster.AppearanceCell.Options.UseTextOptions = true;
            colTaskMaster.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            colDeadline = new GridColumn();
            colDeadline.FieldName = "Deadline";
            colDeadline.Width = 70;
            colDeadline.Visible = true;
            colDeadline.ColumnEdit = repoDate;
            colDeadline.AppearanceCell.Options.UseTextOptions = true;
            colDeadline.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            //total pax
            colCompleted = new GridColumn();
            colCompleted.Caption = "NgayHoanThanh";
            colCompleted.FieldName = "Completed";
            colCompleted.Width = 70;
            colCompleted.Visible = true;
            colCompleted.ColumnEdit = repoDate;
            colCompleted.AppearanceCell.Options.UseTextOptions = true;
            colCompleted.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            GridColumn colAssignees1 = new GridColumn();
            colAssignees1.Caption = "DonVi";
            colAssignees1.FieldName = "Assignees1";
            colAssignees1.Width = 70;
            colAssignees1.Visible = true;
            colAssignees1.AppearanceCell.Options.UseTextOptions = true;
            colAssignees1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            GridColumn colAssignees2 = new GridColumn();
            colAssignees2.Caption = "DVPhoiHop";
            colAssignees2.FieldName = "Assignees2";
            colAssignees2.Width = 70;
            colAssignees2.Visible = true;
            colAssignees2.AppearanceCell.Options.UseTextOptions = true;
            colAssignees2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            GridColumn colNote = new GridColumn();
            colNote.Caption = "DonVi";
            colNote.FieldName = "ArrayNote";
            colNote.Width = 200;
            colNote.Visible = true;
            RepositoryItemMemoEdit riNote = new RepositoryItemMemoEdit();
            colNote.ColumnEdit = riNote;

            colProgress = new GridColumn();
            colProgress.Caption = "TienDo";
            colProgress.FieldName = "Progress";
            colProgress.Width = 15;
            colProgress.Visible = true;
            colProgress.AppearanceCell.Options.UseTextOptions = true;
            colProgress.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            RepositoryItemProgressBar recolProgressBar = new RepositoryItemProgressBar();
            recolProgressBar.Minimum = 0;
            recolProgressBar.Maximum = 100; 
            recolProgressBar.ShowTitle = true;            
            colProgress.ColumnEdit = recolProgressBar;

            //RepositoryItemSpinEdit recolSpinNumber = new RepositoryItemSpinEdit();
            //recolSpinNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //recolSpinNumber.Mask.EditMask = "##";
            //recolSpinNumber.Mask.UseMaskAsDisplayFormat = true;
            //colProgress.ColumnEdit = recolSpinNumber;

            colReason = new GridColumn();
            colReason.FieldName = "Reason";
            colReason.Width = 30;
            colReason.Visible = true;
            //colReason.ColumnEdit = recolSpinNumber;

            colDuedate = new GridColumn();
            colDuedate.FieldName = "DueDate";
            colDuedate.Width = 30;
            colDuedate.Visible = true;
            colDuedate.ColumnEdit = repoDate;

            gridView1.Columns.Clear();
            //gridView1.Columns.AddRange(new GridColumn[] { colID, colDate, colTitle, colDescription, colTaskMaster, colDeadline, colCompleted, colProgress, colReason, colDuedate });
            //gridView1.Columns.AddRange(new GridColumn[] { colDate, colTitle, colDescription, colTaskMaster, colDeadline, colCompleted, colAssignees1, colAssignees2, colNote, colProgress });
            gridView1.Columns.AddRange(new GridColumn[] { colDate, colTitle, colDescription, colTaskMaster, colDeadline, colCompleted, colNote, colAssignees2, colProgress });
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsDetail.EnableMasterViewMode = false;

            gridView1.GroupPanelText = "Danh sách công việc";
            gridView1.OptionsView.ShowFooter = true;
            //Show checkbox
            //gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader =DevExpress.Utils.DefaultBoolean.True;
            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            // Create and setup the first summary item.
            GridGroupSummaryItem groupItem = new GridGroupSummaryItem();
            groupItem.FieldName = "Task";
            groupItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            //gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            groupItem.DisplayFormat = "({0:n0} items)";
            gridView1.GroupSummary.Add(groupItem);

            #endregion

            #region Detail

            //GridColumn colContent = new GridColumn();
            //colContent.FieldName = "Content";
            //colContent.Visible = true;
            //colContent.ColumnEdit = new RepositoryItemMemoEdit();

            //gridView2.Columns.Clear();
            //gridView2.Columns.AddRange(new GridColumn[] { colContent });
            //gridView2.OptionsView.ColumnAutoWidth = true;
            //gridView2.OptionsView.RowAutoHeight = true;

            //gridView2.OptionsView.ShowColumnHeaders = false;
            //gridView2.OptionsView.ShowGroupPanel = false;
            //gridView2.OptionsView.ShowViewCaption = false;
            #endregion

            #region Style format

            StyleFormatCondition styleVIP, styleCIP, styleSM, styleINF;
            ////styleVIP.Appe arance.ForeColor = Color.Orange;
            //styleVIP = new StyleFormatCondition(FormatConditionEnum.Greater, colVip, null, 0);
            //styleVIP.Appearance.BackColor = Color.Yellow;
            //styleVIP.Appearance.BackColor2 = Color.GreenYellow;
            //styleVIP.ApplyToRow = true;
            //gvFlightInfo.FormatConditions.Add(styleVIP);

            //StyleFormatCondition styleDeh;
            ////styleVIP.Appe arance.ForeColor = Color.Orange;
            //styleDeh = new StyleFormatCondition(FormatConditionEnum.NotEqual, gvFlightCrew.Columns["FO_Cfg"], null, "");
            //styleDeh.Appearance.BackColor = Color.Gray;
            //styleDeh.Appearance.BackColor2 = Color.GreenYellow;
            //styleDeh.ApplyToRow = true;
            //gvFlightCrew.FormatConditions.Add(styleDeh);
            #endregion

            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.T.T.01", out create, out read, out update, out delete);
            if (create == false)
                btnNew.Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);

            UpdateGrid();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

        }

        public void UpdateGrid()
        {
            DateTime fromdate, todate;
            DateTime now = DateTime.Now;
            fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            dataSource.DataSource = db.GetTasks(fromdate, todate, "", 0, 1000000, cbxAllTask.Checked, false, false, false, "", ERMs.Sys.ConfigurationSetting.UserInfo.Userid);

            gridControl1.DataSource = dataSource;
            //gridView1.BestFitColumns();
        }
    }
}
