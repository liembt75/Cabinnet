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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace CrewInfo.Forms.CHK
{
    public partial class FrmSurveyCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        SurveyDal db = new SurveyDal();
        BindingSource bind = new BindingSource();
        BindingSource bindItem = new BindingSource();
        Dictionary<int, string> surVeyType;
        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv1.OptionsView.EnableAppearanceEvenRow = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);

            RepositoryItemImageComboBox typeImageCbx = new RepositoryItemImageComboBox();
            //statusImageCbx.SmallImages = imgStatus;
            //statusImageCbx.AutoHeight = false;
            for (int i = 0; i < surVeyType.Count; i++)
            {
                DevExpress.XtraEditors.Controls.ImageComboBoxItem item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                item.Description = surVeyType[i];
                item.Value = i;
                typeImageCbx.Items.Add(item);
            }

            col = new GridColumn();
            col.Caption = "Loại";
            col.FieldName = "Type";            
            col.ColumnEdit = typeImageCbx;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "Name";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Mô tả";
            col.FieldName = "Description";            
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ghi chú";
            col.FieldName = "Note";            
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ký tên";
            col.FieldName = "Signature";                        
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Hiệu lực";
            col.FieldName = "Active";
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv.Columns.Add(col);

            gv1.Columns.Clear();
            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv1.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "Thứ tự";
            //col.FieldName = "index";
            //col.Visible = true;
            //gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Thứ tự";
            col.FieldName = "SN";
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ô nhập";
            col.FieldName = "input";
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tiêu chí";
            col.FieldName = "Question";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col = new GridColumn();
            col.Caption = "Trọng số";
            col.FieldName = "Factor";
            col.Visible = true;
            gv1.Columns.Add(col);

            RepositoryItemColorEdit colorEdit = new RepositoryItemColorEdit();
            colorEdit.CustomDisplayText += ColorEdit_CustomDisplayText;
                        
            col = new GridColumn();
            col.Caption = "Màu";
            col.FieldName = "TextColorValue";
            col.ColumnEdit = colorEdit;            
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col = new GridColumn();
            col.Caption = "Loại điểm";
            col.FieldName = "ScoreType";            
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Hiệu lực";
            col.FieldName = "Active";
            col.Visible = true;
            gv1.Columns.Add(col);
        }

        private void ColorEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {            
            Color colorToCheck = (Color)e.Value;
            string name = colorToCheck.ToString();

            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                if (colorToCheck.ToArgb() == known.ToArgb())
                {
                    name = known.Name;
                }
            }
            e.DisplayText = name;                   
        }

        private void RefreshData()
        {
            bind.DataSource = db.GetListSurveyCategory();
            gc.DataSource = bind;
            //foreach (GridColumn column in gv.Columns)
            //{
            //    if (column.FieldName == "Content")
            //        continue;
            //    column.BestFit();
            //}
            gv.BestFitColumns();
            gv1.BestFitColumns();
        }
        #endregion

        #region Event
        public FrmSurveyCategory()
        {
            InitializeComponent();
        }

        

        private void FrmCHKCategory_Load(object sender, EventArgs e)
        {
            surVeyType = new Dictionary<int, string>();
            //surVeyType.Add(-1, "Tất cả");
            surVeyType.Add(0, "An toàn");
            surVeyType.Add(1, "Dịch vụ");
            surVeyType.Add(2, "Nội bộ");            

            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.SV.C.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.Editable = true;
                gv1.OptionsBehavior.Editable = true;
            }
            panelNav.Visible = false;
            InitView();
            RefreshData();
        }
        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            SurveyCategoryModel item = (SurveyCategoryModel)e.Row;

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Name"], "Name không được để trống.");
            }
            else
            {
                List<SurveyCategoryModel> lstCategory = bind.DataSource as List<SurveyCategoryModel>;
                if (lstCategory.Where(x => x.Name == item.Name).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["Name"], "Name không được giống nhau.");
                }
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }        

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            SurveyCategoryModel item = (SurveyCategoryModel)e.Row;
            try
            {
                SurveyCategoryModel returnItem = db.UpdateSurveyCategory(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gv_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridvew = sender as GridView;            
            SurveyCategoryModel item = (SurveyCategoryModel)gridvew.GetRow(e.RowHandle);
            if (item == null) return;
            item.Items = new BindingList<SurveyBankingItemModel>();
            foreach (var bankingItem in db.GetListSurveyBankingItemBySurveyCategoryID(item.ID))
                item.Items.Add(bankingItem);
            bindItem.DataSource = item;
        }

        private void gv_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        private void gv1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            SurveyBankingItemModel item = (SurveyBankingItemModel)e.Row;            
            if (string.IsNullOrEmpty(item.Question))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Question"], "Question không được để trống.");
            }
            if (item.Factor == null)
            {
                e.Valid = false;                
                view.SetColumnError(view.Columns["Factor"], "Factor phải lớn hơn 1.");
            }
            else
            {
                if (item.Factor < 1)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["Factor"], "Factor phải lớn hơn 1.");
                }
            }
        }

        private void gv1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gv1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            SurveyBankingItemModel item = (SurveyBankingItemModel)e.Row;
            try
            {
                GridView detailView = sender as GridView;
                SurveyCategoryModel category = (SurveyCategoryModel)detailView.SourceRow;
                item.CR_Survey_Category_ID = category.ID;

                CR_Survey_Banking_Item returnItem = db.UpdateSurveyBankingItem(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                detailView.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
        #endregion

        private void gv1_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
        }

        private void gv1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["SN"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["input"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["Factor"], 1);
            view.SetRowCellValue(e.RowHandle, view.Columns["Active"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["TextColorValue"], Color.Black);
        }
    }
}