using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.Exam
{
    public partial class FrmExamBankingTesting : ERMs.SharedBase.XtraFormMDIBase
    {

        //const string CODE = "D.E.M.04";
        public enum Categories
        {
            D_E_M_0401 = 1, //Admin
            D_E_M_0404 = 4, //hệ thông
            D_E_M_0408 = 8, //Briefing - for flight
            D_E_M_0416 = 16, //Practice
            D_E_M_0421 = 21, //Học viên mới
            D_E_M_0422 = 22, //Đề thi cho khu vực Phía Nam
            D_E_M_0423 = 23, //Đề thi cho khu vực Phía Bắc
            D_E_M_0424 = 24, //Kiểm tra năng lực Phía Nam
            D_E_M_0425 = 25 //Kiểm tra năng lực Phía Bắc

        }

        List<int> categories = new List<int>();
        SystemDAL dbSystem = new SystemDAL();
       
        ExamDal db = new ExamDal();
        BindingSource bind = new BindingSource();
        public FrmExamBankingTesting()
        {
            InitializeComponent();
            clCategory.ColumnEdit = repositoryItemImageComboBox1;
            txtFromdate.DateTime = DateTime.Now.AddDays(-7);
            txtTodate.DateTime = DateTime.Now;
            StyleFormatCondition styleDeThiKhongCauHoi = new StyleFormatCondition();
            //styleDeThiKhongCauHoi.Column = gridColumn14;
            styleDeThiKhongCauHoi.Condition = FormatConditionEnum.Expression;
            styleDeThiKhongCauHoi.Expression = "IsNullOrEmpty([Amount]) or [Amount] <= 0";
            styleDeThiKhongCauHoi.Appearance.BackColor = Color.Yellow;
            styleDeThiKhongCauHoi.Appearance.BackColor2 = Color.Yellow;
            styleDeThiKhongCauHoi.Appearance.Options.UseBackColor = true;
            styleDeThiKhongCauHoi.ApplyToRow = true;
            gvEB.FormatConditions.Add(styleDeThiKhongCauHoi);
        }

        private void FrmExamBankingTesting_Load(object sender, EventArgs e)
        {
            InitialData();
        }

        private void InitialData()
        {
            List<Exam_QuestionType> lstEx = db.GetQuestionType(true);
            rlkeQuestionType.DataSource = lstEx.ToList();
            rlkeQuestionType.DisplayMember = "Title";
            rlkeQuestionType.ValueMember = "ID";

            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID(Categories.D_E_M_0401.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value)
                categories.Add((int)Categories.D_E_M_0401);
            else
                clDescription.Visible = false;

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0404.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0404);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0408.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0408);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0416.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0416);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0421.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0421);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0422.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0422);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0423.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0423);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0424.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0424);

            crud = UserInfoModel.GetCRUID(Categories.D_E_M_0425.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)Categories.D_E_M_0425);

            //Permissions -> Visible for admin
            //bool create, read, update, delete;
            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.E.M.04", out create, out read, out update, out delete);
            //if (!update)
            //{
            //    btnUpdate.Visible = false;
            //    btnExamineeList.Visible = false;
            //}

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0401.ToString(), out create, out read, out update, out delete);
            //if (!read) //hide != Admin
            //{
            //    clCode.Visible = false;
            //    clDescription.Visible = false;
            //}
            //else
            //    categories.Add((int)Categories.D_E_M_0401);

            ////--------------------------------------------------

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0404.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0404);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0408.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0408);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0416.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0416);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0421.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0421);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0422.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0422);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0423.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0423);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0424.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0424);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, Categories.D_E_M_0425.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)Categories.D_E_M_0425);


            //Combobox Category
            repositoryItemImageComboBox1.Items.Clear();
            foreach (var item in categories)
            {
                ImageComboBoxItem cbi = new ImageComboBoxItem();
                switch (item)
                {
                    case (int) Categories.D_E_M_0401:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Admin", (object) item));
                        break;
                    case (int)Categories.D_E_M_0404:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Hệ thống", (object)item));
                        break;
                    case (int) Categories.D_E_M_0408:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Briefing", (object) item));
                        break;
                    case (int) Categories.D_E_M_0416:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Practice", (object) item));
                        break;
                    case (int) Categories.D_E_M_0421:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("HV mới", (object)item));
                        break;
                    case (int) Categories.D_E_M_0422:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Nâng bậc-Nam", (object)item));
                        break;
                    case (int) Categories.D_E_M_0423:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Nâng bậc-Bắc", (object)item));
                        break;
                    case (int) Categories.D_E_M_0424:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("KTNL-Nam", (object)item));
                        break;
                    case (int) Categories.D_E_M_0425:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("KTNL-Bắc", (object)item));
                        break;
                    default:
                        break;
                }
            }

            UpdateGridView();
                                        
        }

        private void UpdateGridView()
        {
            DateTime? fromdate = null, todate = null;
            if (!string.IsNullOrEmpty(txtFromdate.Text))
            {
                fromdate = txtFromdate.DateTime;
                fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtTodate.Text))
            {
                todate = txtTodate.DateTime;
                todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
            }

            bind.DataSource = db.GetExamBankingTesting(categories, fromdate, todate);
            gcEB.DataSource = bind;
            gvEB.BestFitColumns();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gvEB.OptionsBehavior.Editable = !gvEB.OptionsBehavior.Editable;
            gvBA.OptionsBehavior.Editable = !gvBA.OptionsBehavior.Editable;
        }

        private void gvEB_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvEB.SetRowCellValue(e.RowHandle, clCode,"");
            gvEB.SetRowCellValue(e.RowHandle, clDescription, DateTime.Now.Ticks.ToString());
            gvEB.SetRowCellValue(e.RowHandle, "Active", true);
            gvEB.SetRowCellValue(e.RowHandle, "Created", DateTime.Now);
            gvEB.SetRowCellValue(e.RowHandle, "Creator", ERMs.Sys.ConfigurationSetting.UserInfo.FullName);
            gvEB.SetRowCellValue(e.RowHandle, "Creatorid", ERMs.Sys.ConfigurationSetting.UserInfo.Userid);
        }

        private void gvEB_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvEB_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ExamBankingTestingModel item = (ExamBankingTestingModel)e.Row;           
            //if (string.IsNullOrEmpty(item.Code))
            //{
            //    e.Valid = false;
            //    gvEB.SetColumnError(clCode, "Code không để trống.");
            //}
            //else
            //{
            //    List<ExamBankingTestingModel> lstEx = bind.DataSource as List<ExamBankingTestingModel>;
            //    if (lstEx.Where(x => x.Code == item.Code).Count() > 1)
            //    {
            //        e.Valid = false;
            //        gvEB.SetColumnError(clCode, "Code không được giống nhau.");
            //    }
            //}

            if (string.IsNullOrEmpty(item.Title))
            {
                e.Valid = false;
                gvEB.SetColumnError(clTitle, "Title không để trống.");
            }
            if (string.IsNullOrEmpty(item.Description))
            {
                e.Valid = false;
                gvEB.SetColumnError(clDescription, "Description không để trống.");
            }
            if (item.Duration == null)
            {
                e.Valid = false;
                gvEB.SetColumnError(clDuration, "Duration không để trống.");
            }
            //if (item.Amount == null)
            //{
            //    e.Valid = false;
            //    gvEB.SetColumnError(clAmount, "Amount không để trống.");
            //}
            if (item.ScoreExpec == null)
            {
                e.Valid = false;
                gvEB.SetColumnError(clScoreExpec, "ScoreExpec không để trống.");
            }
        }

        private void gvEB_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            ExamBankingTestingModel item = (ExamBankingTestingModel)e.Row;
            try
            {
                Exam_Banking_Testing returnItem = db.UpdateExamBankingTesting(item.ToReverseModel());
                item.ID = returnItem.ID;
                item.Code = returnItem.Code;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEB_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            ExamBankingTestingModel item = (ExamBankingTestingModel)gvEB.GetRow(e.RowHandle);
            if (item == null) return;
            item.ExamBankingTestingSection = new BindingList<Exam_Banking_Testing_Section>();            
            foreach (Exam_Banking_Testing_Section ex in db.GetExamBankingTestingSection(item.ID))
                item.ExamBankingTestingSection.Add(ex);
            gvBA.BestFitColumns();            
        }


        private void gvBA_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Exam_Banking_Testing_Section item = (Exam_Banking_Testing_Section)e.Row;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                ExamBankingTestingModel exam = (ExamBankingTestingModel)gvEB.GetRow(detailView.SourceRowHandle);
                item.BankTest_ID = exam.ID;
                Exam_Banking_Testing_Section returnItem = db.UpdateExamBankingTestingSection(item);
                item.ID = returnItem.ID;

                Exam_Banking_Testing examUpdate = new ExamDal().GetExamBankingTestingByID(exam.ID);
                exam.Amount = examUpdate.Amount;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gvBA_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            Exam_Banking_Testing_Section item = (Exam_Banking_Testing_Section)e.Row;
            if (item.QuestionBankType == 0)
            {
                e.Valid = false;
                detailView.SetColumnError(detailView.Columns["QuestionBankType"], "Question type không để trống.");
            }
            else
            {                
                ExamBankingTestingModel exam = (ExamBankingTestingModel)gvEB.GetRow(detailView.SourceRowHandle);
                if (exam.ExamBankingTestingSection.Where(x => x.QuestionBankType == item.QuestionBankType).Count() > 1)
                {
                    e.Valid = false;
                    detailView.SetColumnError(detailView.Columns["QuestionBankType"], "Question type không được giống nhau.");
                }
            }
            if (item.Amount == null || item.Amount < 0)
            {
                e.Valid = false;
                detailView.SetColumnError(detailView.Columns["Amount"], "Amount phải lớn hơn hoặc bằng 0.");
            }
        }
        private void gvBA_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvEB_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void btnExamineeList_Click(object sender, EventArgs e)
        {
            foreach (int rowHandle in gvEB.GetSelectedRows())
            {
                ExamBankingTestingModel item = (ExamBankingTestingModel)gvEB.GetRow(rowHandle);
                FrmExamineeBanking frmExamineeBanking = new FrmExamineeBanking(item);
                frmExamineeBanking.MdiParent = this.ParentForm;
                frmExamineeBanking.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGridView();
        }
    }
}