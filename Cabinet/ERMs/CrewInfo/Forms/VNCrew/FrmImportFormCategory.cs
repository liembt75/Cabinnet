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
using DevExpress.XtraGrid.Columns;
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmImportFormCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        List<HR_Form_Category> lstFormCategory = new List<HR_Form_Category>();
        FormDal db = new FormDal();
        public FrmImportFormCategory(List<HR_Form_Category> iLstFormCategory)
        {
            InitializeComponent();
            lstFormCategory = iLstFormCategory;
            InitView();
            gc.DataSource = lstFormCategory;
            gv.BestFitColumns();
            gv.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            gv.OptionsSelection.MultiSelect = true;
            gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
        }

        private void InitView()
        {
            gv.Columns.Clear();
            //gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsPrint.AutoWidth = false;

            GridColumn col = new GridColumn();
            col.Caption = "Code";
            col.FieldName = "Code";
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Name";
            col.FieldName = "Name";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Description";
            col.FieldName = "Description";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gv.Columns.Add(col);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            List<HR_Form_Category> lstAddedFormCategory = new List<HR_Form_Category>();
            foreach (int rowHandle in gv.GetSelectedRows())            
            {
                HR_Form_Category formCategory = (HR_Form_Category)gv.GetRow(rowHandle);
                formCategory.Code = formCategory.Code.ToUpper();
                lstAddedFormCategory.Add(formCategory);                
            }
            db.addListFormCategory(lstAddedFormCategory);
            MessageBox.Show("Bạn đã nhập loại nguyện vọng thành công!", "Nhập nguyện vọng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SplashScreenManager.CloseForm(false);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}