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
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.NghiMat
{
    public partial class FrmTour : ERMs.SharedBase.XtraFormMDIBase
    {
        TourDal tourDal = new TourDal();
        BindingSource bind = new BindingSource();
        List<Tours2018> lstTour = new List<Tours2018>();
        public FrmTour()
        {
            InitializeComponent();
        }

        private void FrmTour_Load(object sender, EventArgs e)
        {            
            bind.DataSource = lstTour;
            gc.DataSource = bind;
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.N.T.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;
                gv.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;                
            }
            gv.Columns.Clear();
            GridColumn col = null;

            col = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Base", FieldName = "Base", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Đơn vị", FieldName = "DonVi", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Nội dung", FieldName = "NoiDung", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Từ ngày", FieldName = "FromDate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Tới ngày", FieldName = "ToDate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Xóa", FieldName = "IsDelete", Visible = true }; gv.Columns.Add(col);
        }

        private void RefreshData()
        {
            lstTour.Clear();
            lstTour.AddRange(tourDal.GetTours());            
            gc.RefreshDataSource();
            gv.BestFitColumns();    
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Tours2018 item = (Tours2018)e.Row;
            if (string.IsNullOrWhiteSpace(item.NoiDung))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["NoiDung"], "Nội dung không được để trống.");
            }            
            if (e.Valid)
            {
                DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                try
                {
                    Tours2018 returnItem = tourDal.UpdateTour(item);
                    item.ID = returnItem.ID;
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
}