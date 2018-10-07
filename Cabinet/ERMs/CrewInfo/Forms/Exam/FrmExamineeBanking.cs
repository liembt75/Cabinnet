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

namespace CrewInfo.Forms.Exam
{
    public partial class FrmExamineeBanking : ERMs.SharedBase.XtraFormMDIBase
    {
        ExamDal db = new ExamDal();
        ExamBankingTestingModel _ExamBankingTestingModel = null;
        List<ExamineeModel> lstInitExaminee = new List<ExamineeModel>();
        List<ExamineeModel> lstExaminee = new List<ExamineeModel>();
        //Chứa các examinee sẽ bị xóa khỏi đề thi
        List<ExamineeModel> lstDelExaminee = new List<ExamineeModel>();
        public FrmExamineeBanking(ExamBankingTestingModel item)
        {
            InitializeComponent();
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width * 5 / 10;
            splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl2.SplitterPosition = splitContainerControl2.Width * 1 / 8;
            _ExamBankingTestingModel = item;
            labelControl2.Text += item.Title;
            labelControl1.Text += item.Description;
            lstInitExaminee = db.GetAddedExaminee(_ExamBankingTestingModel.ID);
            gridControl1.DataSource = lstExaminee = lstInitExaminee.ToList();
            UpdateGridView();            
        }

        private void UpdateGridView()
        {
            List<string> lstMSNV = new List<string>();
            lstMSNV = txtMSNV.Text.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lstTen = new List<string>();
            lstTen = txtTen.Text.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            gridControl2.DataSource = db.GetExaminee(lstMSNV, lstTen);                        
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGridView();            
        }

        private void txtTen_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnFoward_Click(object sender, EventArgs e)
        {
            foreach(int rowHandle in gridView2.GetSelectedRows())
            {
                ExamineeModel examineeModel = (ExamineeModel)gridView2.GetRow(rowHandle);
                if (lstExaminee.Where(i => i.CrewID == examineeModel.CrewID).FirstOrDefault() == null)
                {
                    examineeModel.BankTestID = _ExamBankingTestingModel.ID;
                    //Nếu add lại thí sinh đã bị xóa trong danh sách xóa thì xóa thí sinh đó trong danh sách xóa
                    ExamineeModel removeExaminee = lstDelExaminee.Where(i => i.CrewID == examineeModel.CrewID).FirstOrDefault();
                    if (removeExaminee != null)
                        lstDelExaminee.Remove(removeExaminee);                    
                    lstExaminee.Add(examineeModel);
                }
            }
            gridControl1.RefreshDataSource();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            List<ExamineeModel> lstRemoveAccount = new List<ExamineeModel>();
            foreach (int rowHandle in gridView1.GetSelectedRows())
            {
                ExamineeModel examineeModel = (ExamineeModel)gridView1.GetRow(rowHandle);
                gridView1.UnselectRow(rowHandle);
                lstRemoveAccount.Add(examineeModel);
            }
            foreach (ExamineeModel acc in lstRemoveAccount)
            {
                //nếu xóa thí sinh trong danh sách đề, add thí sinh đó vào danh sách cần xóa
                if (lstInitExaminee.Where(i => i.CrewID == acc.CrewID).FirstOrDefault() != null)
                    lstDelExaminee.Add(acc);
                lstExaminee.Remove(acc);
            }
            gridControl1.RefreshDataSource();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();            
            try
            {
                db.UpdateExamineeBanking(lstExaminee, lstDelExaminee);                
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                lstInitExaminee = db.GetAddedExaminee(_ExamBankingTestingModel.ID);
                gridControl1.DataSource = lstExaminee = lstInitExaminee.ToList();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
    }
}