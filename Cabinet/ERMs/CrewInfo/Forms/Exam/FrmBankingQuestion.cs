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

namespace CrewInfo.Forms.Exam
{
    public partial class FrmBankingQuestion : ERMs.SharedBase.XtraFormMDIBase
    {
        ExamDal db = new ExamDal();
        SystemDAL dbSystem = new SystemDAL();
        BindingSource bind = new BindingSource();
        List<Exam_QuestionType> lstQuestionType = null;
        public FrmBankingQuestion()
        {
            InitializeComponent();
            bool create, read, update, delete;
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.E.M.03", out create, out read, out update, out delete);
            if (!update)
            {
                btnUpdate.Visible = false;                
            }

            lstQuestionType = db.GetQuestionType(true);
            rlkeQuestionType.DataSource = lstQuestionType.ToList();
            rlkeQuestionType.DisplayMember = "Title";
            rlkeQuestionType.ValueMember = "ID";

            Exam_QuestionType exam_QuestionType = new Exam_QuestionType();
            exam_QuestionType.ID = -1;
            exam_QuestionType.Title = "";
            lstQuestionType.Insert(0, exam_QuestionType);

            lkeQuestionType.Properties.DataSource = lstQuestionType.ToList();
            lkeQuestionType.Properties.ValueMember = "ID";
            lkeQuestionType.Properties.DisplayMember = "Title";
            lkeQuestionType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lkeQuestionType.EditValue = "-1";
            
            UpdateGridView();
        }

        private void UpdateGridView()
        {            
            int questionType = Convert.ToInt32(lkeQuestionType.EditValue);
            string question = txtQuestionFilter.Text;
            bind.DataSource = db.GetBankingQuestion(questionType, question, lstQuestionType);
            gcBQ.DataSource = bind;
            clQuestionType.BestFit();
            clAircraft.BestFit();
            clNote.BestFit();
            clAActive.BestFit();
            //gvBQ.BestFitColumns();
        }

        private void lkeQuestionType_EditValueChanged(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);            
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gvBQ.OptionsBehavior.Editable = !gvBQ.OptionsBehavior.Editable;
            gvBA.OptionsBehavior.Editable = !gvBA.OptionsBehavior.Editable;
        }

        private void gvBQ_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvBQ.SetRowCellValue(e.RowHandle, "CrewType", "");
            gvBQ.SetRowCellValue(e.RowHandle, "Aircraft", "All");
            gvBQ.SetRowCellValue(e.RowHandle, "Active", true);
            gvBQ.SetRowCellValue(e.RowHandle, "Created", DateTime.Now);
            gvBQ.SetRowCellValue(e.RowHandle, "Creator", ERMs.Sys.ConfigurationSetting.UserInfo.FullName);
            gvBQ.SetRowCellValue(e.RowHandle, "Creatorid", ERMs.Sys.ConfigurationSetting.UserInfo.Userid);
        }

        private void gvBQ_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ExamBankingQuestionModel item = (ExamBankingQuestionModel)e.Row;
            if (item.QuestionType == 0)
            {
                e.Valid = false;
                gvBQ.SetColumnError(clQuestionType, "Loại câu hỏi không để trống.");
            }
            if (string.IsNullOrEmpty(item.Question))
            {
                e.Valid = false;
                gvBQ.SetColumnError(clQuestion, "Câu hỏi không để trống.");
            }
        }

        private void gvBQ_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvBQ_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            ExamBankingQuestionModel item = (ExamBankingQuestionModel)e.Row;
            try
            {
                Exam_Banking_Question returnItem = db.UpdateExamBankingQuestion(item.ToReverseModel());
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gvBQ_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            ExamBankingQuestionModel item = (ExamBankingQuestionModel)gvBQ.GetRow(e.RowHandle);
            if (item == null) return;
            item.ExamBankingAnswer = new BindingList<Exam_Banking_Answer>();
            //bindAnswear.DataSource = db.GetExamBankingAnswer(item.ID);
            foreach (Exam_Banking_Answer ex in db.GetExamBankingAnswer(item.ID))
                item.ExamBankingAnswer.Add(ex);
        }

        private void gvBA_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            ExamBankingQuestionModel item = (ExamBankingQuestionModel)gvBQ.GetRow(detailView.SourceRowHandle);            
            detailView.SetRowCellValue(e.RowHandle, "QuestionID", item.ID);
            detailView.SetRowCellValue(e.RowHandle, "isCorrect", false);
            detailView.SetRowCellValue(e.RowHandle, "Created", DateTime.Now);
            detailView.SetRowCellValue(e.RowHandle, "Creator", ERMs.Sys.ConfigurationSetting.UserInfo.FullName);
            detailView.SetRowCellValue(e.RowHandle, "Creatorid", ERMs.Sys.ConfigurationSetting.UserInfo.Userid);
        }

        private void gvBA_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Exam_Banking_Answer item = (Exam_Banking_Answer)e.Row;            
            if (string.IsNullOrEmpty(item.Answer))
            {
                e.Valid = false;
                gvBQ.SetColumnError(clQuestion, "Câu trả lời không để trống.");
            }
        }

        private void gvBA_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvBA_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Exam_Banking_Answer item = (Exam_Banking_Answer)e.Row;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                ExamBankingQuestionModel question = (ExamBankingQuestionModel)gvBQ.GetRow(detailView.SourceRowHandle);
                item.QuestionID = question.ID;
                Exam_Banking_Answer returnItem = db.UpdateExamBankingAnswer(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
    }
}