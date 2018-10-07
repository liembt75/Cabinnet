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
using DevExpress.Spreadsheet;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.Exam
{
    public partial class FrmImportQuestionBanking : ERMs.SharedBase.XtraFormMDIBase
    {
        Exam_QuestionType _questionType = null;
        Worksheet _worksheet = null;
        ExamDal db = new ExamDal();
        public FrmImportQuestionBanking(Exam_QuestionType iquestionType)
        {
            InitializeComponent();
            _questionType = iquestionType;
            lbInformation.Text = string.Format("Loại câu hỏi: {0}", _questionType.Title);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.ShowDialog();

            if (file.FileName.Trim() != "")
            {
                spreadsheetControl1.LoadDocument(file.FileName);
                IWorkbook workbook = spreadsheetControl1.Document;

                // Access a collection of worksheets.
                WorksheetCollection worksheets = workbook.Worksheets;

                // Access a worksheet by its index.
                _worksheet = workbook.Worksheets[0];                
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Range usedRange = _worksheet.GetUsedRange();
            int colCount = usedRange.ColumnCount;
            int rowCount = usedRange.RowCount;
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                if (colCount < 4)
                {
                    throw new Exception();
                }
                List<ExamBankingQuestionModel> lstquestion = new List<ExamBankingQuestionModel>();
                for (int i = 1; i < rowCount; i++)
                {
                    ExamBankingQuestionModel question = new ExamBankingQuestionModel();
                    question.QuestionType = _questionType.ID;
                    question.Active = true;
                    question.Aircraft = "ALL";
                    string strquestion = _worksheet[i, 1].Value == null ? null : _worksheet[i, 1].Value.ToString();
                    if (string.IsNullOrEmpty(strquestion))
                    {
                        continue;
                    }
                    question.Question = strquestion;
                    question.ExamBankingAnswer = new BindingList<Exam_Banking_Answer>();
                    lstquestion.Add(question);
                    int dapandung = Convert.ToInt32(_worksheet[i, 2].Value.ToString());
                    for (int j = 3; j < colCount; j++)
                    {
                        string dapAn = _worksheet[i, j].Value == null ? null : _worksheet[i, j].Value.ToString();
                        if (string.IsNullOrEmpty(dapAn))
                        {
                            break;
                        }
                        else
                        {
                            Exam_Banking_Answer answear = new Exam_Banking_Answer();
                            answear.Answer = dapAn;
                            answear.isCorrect = false;
                            if (dapandung + 2 == j)
                                answear.isCorrect = true;
                            question.ExamBankingAnswer.Add(answear);
                        }
                    }
                }
                db.SaveQuestion(lstquestion);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Bạn đã nhập câu hỏi thành công!", "Nhập câu hỏi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
            catch
            {
                MessageBox.Show("File không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SplashScreenManager.CloseForm(false);
            }
        }
    }
}