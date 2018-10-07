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

namespace CrewInfo.Forms.Ojt
{
    public partial class FrmOjtCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        OJTDal db = new OJTDal();
        BindingSource bind = new BindingSource();
        BindingSource bindLesson = new BindingSource();
        BindingSource bindLessonItem = new BindingSource();
        GridColumn colName, colNameLesson, colCodeLesson, colOder, colQuestionLessonItem;
        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv1.OptionsView.EnableAppearanceEvenRow = true;
            gv2.OptionsView.EnableAppearanceEvenRow = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);

            colName = new GridColumn();
            colName.Caption = "Tên";
            colName.FieldName = "Name";
            colName.Fixed = FixedStyle.Left;
            colName.Visible = true;
            gv.Columns.Add(colName);

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

            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv1.Columns.Add(col);

            colCodeLesson = new GridColumn();
            colCodeLesson.Caption = "Mã";
            colCodeLesson.FieldName = "Code";
            colCodeLesson.Fixed = FixedStyle.Left;
            colCodeLesson.Visible = true;
            gv1.Columns.Add(colCodeLesson);

            colNameLesson = new GridColumn();
            colNameLesson.Caption = "Tên";
            colNameLesson.FieldName = "Name";
            colNameLesson.Fixed = FixedStyle.Left;
            colNameLesson.Visible = true;
            gv1.Columns.Add(colNameLesson);

            col = new GridColumn();
            col.Caption = "Mô tả";
            col.FieldName = "Description";
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ghi chú";
            col.FieldName = "Note";
            col.Visible = true;
            gv1.Columns.Add(col);

            colOder = new GridColumn();
            colOder = new GridColumn();
            colOder.Caption = "Thứ tự";
            colOder.FieldName = "Order";
            colOder.Visible = true;
            gv1.Columns.Add(colOder);

            col = new GridColumn();
            col.Caption = "Ký tên";
            col.FieldName = "Signature";
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Hiệu lực";
            col.FieldName = "Active";
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv2.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "Thứ tự";
            //col.FieldName = "index";
            //col.Visible = true;
            //gv2.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Thứ tự";
            col.FieldName = "SN";
            col.Visible = true;
            gv2.Columns.Add(col);

            colQuestionLessonItem = new GridColumn();
            colQuestionLessonItem.Caption = "Tiêu chí";
            colQuestionLessonItem.FieldName = "Question";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            //colQuestionLessonItem.Fixed = FixedStyle.Left;
            colQuestionLessonItem.Visible = true;
            gv2.Columns.Add(colQuestionLessonItem);                        

            col = new GridColumn();
            col.Caption = "Ô nhập";
            col.FieldName = "input";
            col.Visible = true;
            gv2.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Trọng số";
            col.FieldName = "Factor";
            col.Visible = true;
            gv2.Columns.Add(col);

            RepositoryItemColorEdit colorEdit = new RepositoryItemColorEdit();
            colorEdit.CustomDisplayText += ColorEdit_CustomDisplayText;

            col = new GridColumn();
            col.Caption = "Màu";
            col.FieldName = "TextColorValue";
            col.ColumnEdit = colorEdit;
            col.Visible = true;
            gv2.Columns.Add(col);

            col = new GridColumn();
            col = new GridColumn();
            col.Caption = "Loại điểm";
            col.FieldName = "ScoreType";
            col.Visible = true;
            gv2.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Hiệu lực";
            col.FieldName = "Active";
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv2.Columns.Add(col);
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
            bind.DataSource = db.GetListOJTCategory();
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

        public FrmOjtCategory()
        {
            InitializeComponent();
        }

        private void FrmOjtCategory_Load(object sender, EventArgs e)
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.O.C.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.Editable = true;
                gv1.OptionsBehavior.Editable = true;
                gv2.OptionsBehavior.Editable = true;
            }
            panelNav.Visible = false;
            InitView();
            RefreshData();
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            OJTCategoryModel item = (OJTCategoryModel)e.Row;

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                e.Valid = false;
                view.SetColumnError(colName, "Name không được để trống.");
            }
            else
            {
                List<OJTCategoryModel> lstCategory = bind.DataSource as List<OJTCategoryModel>;
                if (lstCategory.Where(x => x.Name == item.Name).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(colName, "Name không được giống nhau.");
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
            OJTCategoryModel item = (OJTCategoryModel)e.Row;
            try
            {
                OJTCategoryModel returnItem = db.UpdateOJTCategory(item);
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
            DevExpress.XtraGrid.Views.Grid.GridView gridvew = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            OJTCategoryModel item = (OJTCategoryModel)gridvew.GetRow(e.RowHandle);
            if (item == null) return;
            item.OJTLesson = new BindingList<OJTLessonModel>();            
            foreach (var lesson in db.GetOJTLessonByOJTCategoryID(item.ID))
                item.OJTLesson.Add(lesson);
            bindLesson.DataSource = item.OJTLesson;
        }

        private void gv_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        private void gv1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridvew = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            OJTLessonModel item = (OJTLessonModel)gridvew.GetRow(e.RowHandle);
            if (item == null) return;
            item.OJTLessonItem = new BindingList<OJTLessonItemModel>();
            foreach (var lesson in db.GetOJTLessonItemByOJTLessonID(item.ID))
                item.OJTLessonItem.Add(lesson);
            bindLessonItem.DataSource = item.OJTLessonItem;
        }

        private void gv1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        private void gv1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            OJTLessonModel item = (OJTLessonModel)e.Row;

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Name"], "Name không được để trống.");
            }
            else
            {
                BindingList<OJTLessonModel> lstCategory = bindLesson.DataSource as BindingList<OJTLessonModel>;
                if (lstCategory.Where(x => x.Name == item.Name).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["Name"], "Name không được giống nhau.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Code))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Code"], "Code không được để trống.");
            }
            else
            {
                BindingList<OJTLessonModel> lstCategory = bindLesson.DataSource as BindingList<OJTLessonModel>;
                if (lstCategory.Where(x => x.Code == item.Code).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["Code"], "Code không được giống nhau.");
                }
            }
        }

        private void gv1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gv1_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
        }

        private void gv2_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
        }

        private void gv2_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["SN"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["input"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["Factor"], 1);
            view.SetRowCellValue(e.RowHandle, view.Columns["Active"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["TextColorValue"], Color.Black);
        }

        private void gv1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            OJTLessonModel item = (OJTLessonModel)e.Row;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                OJTCategoryModel category = (OJTCategoryModel)gv.GetRow(detailView.SourceRowHandle);
                item.CR_OJT_Category_ID = category.ID;
                 
                OJTLessonModel returnItem = db.UpdateOJTLesson(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gv1.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gv2_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gv2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            OJTLessonItemModel item = (OJTLessonItemModel)e.Row;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView detailView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                OJTLessonModel lesson = (OJTLessonModel)detailView.SourceRow;
                item.CR_OJT_Lesson_ID = lesson.ID;

                OJTLessonItemModel returnItem = db.UpdateOJTLessonItem(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                detailView.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gv2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            OJTLessonItemModel item = (OJTLessonItemModel)e.Row;
            
            if (string.IsNullOrWhiteSpace(item.Question))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Question"], "Question không được để trống.");
            }
            else
            {
                BindingList<OJTLessonItemModel> lstCategory = bindLessonItem.DataSource as BindingList<OJTLessonItemModel>;
                if (lstCategory.Where(x => x.Question == item.Question).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["Question"], "Question không được giống nhau.");
                }
            }
        }
    }
}