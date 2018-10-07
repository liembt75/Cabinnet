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
using DevExpress.Export;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;

namespace CrewInfo.Forms.Exam
{
    public partial class FrmExam : ERMs.SharedBase.XtraFormMDIBase
    {
        ExamDal examDal = new ExamDal();
        BindingSource bind = new BindingSource();
        SystemDAL dbSystem = new SystemDAL();
        List<int> categories = new List<int>();
        public FrmExam()
        {
            InitializeComponent();
            txtFromdate.DateTime = DateTime.Now;
            txtTodate.DateTime = DateTime.Now;

            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0401.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0401);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0404.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0404);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0408.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0408);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0416.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0416);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0421.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0421);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0422.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0422);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0423.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0423);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0424.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0424);

            crud = UserInfoModel.GetCRUID(FrmExamBankingTesting.Categories.D_E_M_0425.ToString());
            if (crud != null && crud.R.HasValue && crud.R.Value) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0425);

            crud = UserInfoModel.GetCRUID("D.E.M.01".ToString());
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                btnExBaiThi.Visible = true;
            }
            //Permissions -> Visible for admin
            //bool create, read, update, delete;
            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0401.ToString(), out create, out read, out update, out delete);            
            //categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0401);

            ////--------------------------------------------------

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0404.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0404);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0408.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0408);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0416.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0416);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0421.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0421);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0422.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0422);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0423.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0423);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0424.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0424);

            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, FrmExamBankingTesting.Categories.D_E_M_0425.ToString(), out create, out read, out update, out delete);
            //if (read) categories.Add((int)FrmExamBankingTesting.Categories.D_E_M_0425);

            StyleFormatCondition stylePhongBanChuaTraLoi = new StyleFormatCondition();
            stylePhongBanChuaTraLoi.Column = gridColumn14;
            stylePhongBanChuaTraLoi.Condition = FormatConditionEnum.Expression;
            stylePhongBanChuaTraLoi.Expression = "Not IsNullOrEmpty([ScoreResult]) and [ScoreResult] < [ScoreExpec]";
            stylePhongBanChuaTraLoi.Appearance.BackColor = Color.Red;
            stylePhongBanChuaTraLoi.Appearance.BackColor2 = Color.White;
            stylePhongBanChuaTraLoi.Appearance.Options.UseBackColor = true;
            //stylePhongBanChuaTraLoi.ApplyToRow = true;
            gvExam.FormatConditions.Add(stylePhongBanChuaTraLoi);

            StyleFormatCondition styleHetGio = new StyleFormatCondition();
            styleHetGio.Column = gridColumn12;
            styleHetGio.Condition = FormatConditionEnum.Expression;
            styleHetGio.Expression = "Not IsNullOrEmpty([StartTime]) and DateDiffMinute(Now(), [StartTime]) > [Duration]";
            styleHetGio.Appearance.BackColor = Color.Yellow;
            styleHetGio.Appearance.BackColor2 = Color.White;
            styleHetGio.Appearance.Options.UseBackColor = true;
            //stylePhongBanChuaTraLoi.ApplyToRow = true;
            gvExam.FormatConditions.Add(styleHetGio);

            StyleFormatCondition styleCauSai = new StyleFormatCondition();
            styleCauSai.Column = clisCorrect;
            styleCauSai.Condition = FormatConditionEnum.Expression;
            styleCauSai.Expression = "[isCorrect] != true";
            styleCauSai.Appearance.BackColor = Color.Black;
            styleCauSai.Appearance.BackColor2 = Color.White;
            styleCauSai.Appearance.Options.UseBackColor = true;

            repositoryItemImageComboBox1.Items.Clear();
            foreach (var item in categories)
            {
                ImageComboBoxItem cbi = new ImageComboBoxItem();
                switch (item)
                {
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0401:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Admin", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0404:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Hệ thống", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0408:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Briefing", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0416:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Practice", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0421:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("HV mới", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0422:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Nâng bậc-Nam", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0423:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("Nâng bậc-Bắc", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0424:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("KTNL-Nam", (object)item));
                        break;
                    case (int)FrmExamBankingTesting.Categories.D_E_M_0425:
                        repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem("KTNL-Bắc", (object)item));
                        break;
                    default:
                        break;
                }
            }
            clCategory.ColumnEdit = repositoryItemImageComboBox1;
            //styleCauSai.ApplyToRow = true;
            gvQuestion.FormatConditions.Add(styleCauSai);
            UpdateGridView();
        }

        public void UpdateGridView()
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
            bind.DataSource = examDal.GetExamTester(fromdate, todate, categories);
            gcExam.DataSource = bind;
            gvExam.BestFitColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "Exam.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                //ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                //gvExam.BestFitColumns();
                gvExam.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (int rowHandle in gvExam.GetSelectedRows())
            {
                ExamTesterModel item = (ExamTesterModel)gvExam.GetRow(rowHandle);
                examDal.DelelteFinishDate(item.ID);
                DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                UpdateGridView();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void gvExam_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.E.M.01".ToString());
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                ExamTesterModel item = (ExamTesterModel)gvExam.GetRow(e.RowHandle);
                if (item == null) return;
                item.ExamQuestion = examDal.GetExamQuestionByExamTesterID(item.ID);
                //item.ExamQuestion = new BindingList<ExamQuestionModel>();
                //bindAnswear.DataSource = db.GetExamBankingAnswer(item.ID);
                //foreach (Exam_Banking_Answer ex in db.GetExamBankingAnswer(item.ID))
                //    item.ExamBankingAnswer.Add(ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa bài thi này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (int rowHandle in gvExam.GetSelectedRows())
                {
                    ExamTesterModel item = (ExamTesterModel)gvExam.GetRow(rowHandle);
                    examDal.DeleteExam(item.ID);
                    DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    UpdateGridView();
                    SplashScreenManager.CloseForm(false);
                }
            }
        }

        private void btnExBaiThi_Click(object sender, EventArgs e)
        {
            foreach (int rowHandle in gvExam.GetSelectedRows())
            {
                ExamTesterModel item = (ExamTesterModel)gvExam.GetRow(rowHandle);
                if (item == null) return;
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.FileName = item.FirstNameVn.Replace(" ", "") + "_Exam.xlsx";
                file.Title = "Save an Excel";
                DialogResult result = file.ShowDialog();

                if (result == DialogResult.OK && file.FileName.Trim() != "")
                {
                    ExportSettings.DefaultExportType = ExportType.WYSIWYG;                                        
                    gridControl1.DataSource = examDal.GetExamQuestionByExamTesterID(item.ID);
                    gridView1.ExportToXlsx(file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
                           
            }
        }
    }
}