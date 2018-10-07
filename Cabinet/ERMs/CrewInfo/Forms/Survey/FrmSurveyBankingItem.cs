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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.CHK
{
    public partial class FrmSurveyBankingItem : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        SurveyDal db = new SurveyDal();
        BindingSource bind = new BindingSource();
        GridColumn colCategoryID, colIndex, colInput, colFactor, colQuestion;
        List<CR_Survey_Category> lstSurveyCategory = new List<CR_Survey_Category>();

        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsView.EnableAppearanceEvenRow = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";            
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);

            RepositoryItemLookUpEdit categoryLookUpEdit = new RepositoryItemLookUpEdit();
            categoryLookUpEdit.DataSource = lstSurveyCategory;
            categoryLookUpEdit.DisplayMember = "Name";
            categoryLookUpEdit.ValueMember = "ID";
            categoryLookUpEdit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"));
            categoryLookUpEdit.NullText = "";

            //RepositoryItemImageComboBox categoryComboBox = new RepositoryItemImageComboBox();
            //foreach (var category in lstSurveyCategory)
            //{
            //    categoryComboBox.Items.Add(category.Name, category.ID, 0);
            //}

            colCategoryID = new GridColumn();
            colCategoryID.Caption = "Category";
            colCategoryID.FieldName = "CR_Survey_Category_ID";
            colCategoryID.ColumnEdit = categoryLookUpEdit;
            colCategoryID.Visible = true;
            gv.Columns.Add(colCategoryID);

            colIndex = new GridColumn();
            colIndex.Caption = "Index";
            colIndex.FieldName = "index";
            colIndex.Visible = true;            
            gv.Columns.Add(colIndex);

            colInput = new GridColumn();
            colInput.Caption = "Input";
            colInput.FieldName = "input";
            colInput.Visible = true;
            gv.Columns.Add(colInput);

            colQuestion = new GridColumn();
            colQuestion.Caption = "Question";
            colQuestion.FieldName = "Question";
            colQuestion.Visible = true;
            gv.Columns.Add(colQuestion);

            colFactor = new GridColumn();
            colFactor = new GridColumn();
            colFactor.Caption = "Factor";
            colFactor.FieldName = "Factor";
            colFactor.Visible = true;
            gv.Columns.Add(colFactor);

            col = new GridColumn();
            col.Caption = "Version";
            col.FieldName = "Version";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "IsDeleted";
            col.FieldName = "IsDeleted";
            col.Visible = true;
            gv.Columns.Add(col);
        }        

        private void RefreshData()
        {
            bind.DataSource = db.GetListSurveyBankingItem();
            gc.DataSource = bind;
            //foreach (GridColumn column in gv.Columns)
            //{
            //    if (column.FieldName == "Content")
            //        continue;
            //    column.BestFit();
            //}
            gv.BestFitColumns();
        }
        #endregion

        #region Event
        public FrmSurveyBankingItem()
        {
            InitializeComponent();
        }

        

        private void FrmCHKBankingItem_Load(object sender, EventArgs e)
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.CHK.BI.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
                gv.OptionsBehavior.Editable = true;
            panelNav.Visible = false;
            //lstSurveyCategory = db.GetListSurveyCategory();
            InitView();
            RefreshData();
        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gv.SetRowCellValue(e.RowHandle, "Factor", 1);
        }
        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            CR_Survey_Banking_Item item = (CR_Survey_Banking_Item)e.Row;

            if (item.CR_Survey_Category_ID == null)
            {
                e.Valid = false;
                view.SetColumnError(colCategoryID, "Category không được để trống.");
            }
            if (string.IsNullOrEmpty(item.Question))
            {
                e.Valid = false;
                view.SetColumnError(colQuestion, "Question không được để trống.");
            }
            if (item.Factor == null)
            {
                e.Valid = false;
                view.SetColumnError(colFactor, "Factor phải lớn hơn 1.");
            }
            else
            {                
                if (item.Factor < 1)
                {
                    e.Valid = false;
                    view.SetColumnError(colFactor, "Factor phải lớn hơn 1.");
                }                
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            //CR_Survey_Banking_Item item = (CR_Survey_Banking_Item)e.Row;
            //try
            //{
            //    CR_Survey_Banking_Item returnItem = db.UpdateSurveyBankingItem(item);
            //    item.ID = returnItem.ID;
            //    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            //    gv.BestFitColumns();
            //}
            //catch (Exception ex)
            //{
            //    alertControl1.Show(this.FindForm(), "Error", ex.Message);
            //}
        }
        #endregion


    }
}