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
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.Exam
{
    public partial class FrmQuestionType : ERMs.SharedBase.XtraFormMDIBase
    {
        ExamDal db = new ExamDal();
        SystemDAL dbSystem = new SystemDAL();       
        BindingSource bind = new BindingSource();
        public FrmQuestionType()
        {
            InitializeComponent();
            bool create, read, update, delete;
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.E.M.02", out create, out read, out update, out delete);
            if (!update)
            {
                btnUpdate.Visible = false;
                btnImport.Visible = false;
            }
            UpdateGridView();
        }

        private void UpdateGridView()
        {                      
            bind.DataSource = db.GetQuestionType(null);
            gcQSType.DataSource = bind;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gvQSType.OptionsBehavior.Editable = !gvQSType.OptionsBehavior.Editable;
        }

        private void gvQSType_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvQSType.SetRowCellValue(e.RowHandle, "Active", true);
        }

        private void gvQSType_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Exam_QuestionType item = (Exam_QuestionType)e.Row;

            if (string.IsNullOrWhiteSpace(item.Title))
            {
                e.Valid = false;
                view.SetColumnError(clTitle, "Title không được để trống.");
            }
            else
            {
                List<Exam_QuestionType> lstEx = bind.DataSource as List<Exam_QuestionType>;
                if (lstEx.Where(x => x.Title == item.Title).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(clTitle, "Title không được giống nhau.");
                }
            }
        }

        private void gvQSType_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvQSType_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Exam_QuestionType item = (Exam_QuestionType)e.Row;
            try
            {
                Exam_QuestionType returnItem = db.UpdateQuestionType(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);                
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (gvQSType.GetSelectedRows().Length > 0)
            {
                int rowIndex = gvQSType.GetSelectedRows()[0];
                Exam_QuestionType questionType = (Exam_QuestionType)gvQSType.GetRow(rowIndex);
                FrmImportQuestionBanking frm = new FrmImportQuestionBanking(questionType);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }
    }
}