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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.Export;

namespace CrewInfo.Forms.NghiMat
{
    public partial class FrmTourRegister : ERMs.SharedBase.XtraFormMDIBase
    {
        class TinhTrangDangKy
        {
            public int Status { get; set; }
            public string StatusText { get; set; }
        }
        TourDal tourDal = new TourDal();
        BindingSource bind = new BindingSource();
        List<GetRegister2018_Result> lstRegister = new List<GetRegister2018_Result>();
        public FrmTourRegister()
        {
            InitializeComponent();
        }

        private void FrmTourRegister_Load(object sender, EventArgs e)
        {
            bind.DataSource = lstRegister;
            gc.DataSource = bind;
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            btnExcelImport.Visible = false;
            //dropDownButton1.Visible = false;
            btnBoTour.Visible = false;
            btnHuy.Visible = false;
            gv.OptionsBehavior.ReadOnly = true;
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.N.R.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;                
                btnExcelImport.Visible = true;
                btnHuy.Visible = true;
                btnBoTour.Visible = true;
            }

            USP_GetAllCRUDByUserID_Result crudBoTour = UserInfoModel.GetCRUID("D.N.R.02");
            if (crudBoTour != null && crudBoTour.U.HasValue && crudBoTour.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;
                btnExcelImport.Visible = true;
                btnHuy.Visible = true;
                btnBoTour.Visible = true;                
            }

            gv.Columns.Clear();
            GridColumn col = null;

            col = new GridColumn() { Caption = "MSNV", FieldName = "MSNV", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            //col = new GridColumn() { Caption = "Mail", FieldName = "Mail", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Họ và tên", FieldName = "HoTen", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Quan hệ", FieldName = "QuanHe", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "CMND", FieldName = "CMND", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ngày sinh", FieldName = "NgaySinh", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Base", FieldName = "Base", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Đơn vị", FieldName = "DonVi", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);            
            col = new GridColumn() { Caption = "Nội dung", FieldName = "NoiDung", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Từ ngày", FieldName = "FromDate", Visible = true }; col.OptionsColumn.ReadOnly = true; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Tới ngày", FieldName = "ToDate", Visible = true }; col.OptionsColumn.ReadOnly = true; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            RepositoryItemLookUpEdit statusLookUpEdit = new RepositoryItemLookUpEdit();            
            List<TinhTrangDangKy> lstTinhTrang = new List<TinhTrangDangKy>();
            lstTinhTrang.Add(new TinhTrangDangKy() { Status = 0, StatusText = "Đăng ký" });
            lstTinhTrang.Add(new TinhTrangDangKy() { Status = 1, StatusText = "Hủy" });
            lstTinhTrang.Add(new TinhTrangDangKy() { Status = 2, StatusText = "Bỏ tour" });
            
            statusLookUpEdit.DataSource = lstTinhTrang;
            statusLookUpEdit.DisplayMember = "StatusText";
            statusLookUpEdit.ValueMember = "Status";
            statusLookUpEdit.Columns.Add(new LookUpColumnInfo("StatusText", ""));
            col = new GridColumn() { Caption = "Tình trạng", FieldName = "TinhTrang", Visible = true }; gv.Columns.Add(col); col.ColumnEdit = statusLookUpEdit;
            //if (crud != null && crud.U.HasValue && crud.U.Value)
            //{
            //    col.OptionsColumn.ReadOnly = false;
            //}
            col = new GridColumn() { Caption = "Người nhập", FieldName = "NguoiCapNhat", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ngày nhập", FieldName = "NgayCapNhat", Visible = true }; col.OptionsColumn.ReadOnly = true; col.DisplayFormat.FormatString = "dd/MM/yy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            gv.VisibleColumns[0].OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
        }

        private void RefreshData()
        {
            List<string> lstMSNV = new List<string>();
            lstMSNV = txtMSNV.Text.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //gridControl2.DataSource = db.GetExaminee(lstMSNV, lstTen);

            lstRegister.Clear();
            lstRegister.AddRange(tourDal.GetRegister(lstMSNV));
            gc.RefreshDataSource();
            gv.BestFitColumns();
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GetRegister2018_Result item = (GetRegister2018_Result)e.Row;
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            try
            {
                GetRegister2018_Result returnItem = tourDal.UpdateRegister(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                RefreshData();
                //switch (item.TinhTrang)
                //{
                //    case 0:
                //    case 1:
                //        if (item.NguoiCapNhat == ERMs.Sys.ConfigurationSetting.UserInfo.UserName)
                //        {
                //            GetRegister2018_Result returnItem = tourDal.UpdateRegister(item);
                //            item.ID = returnItem.ID;
                //            alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                //            RefreshData();
                //        }
                //        else
                //        {
                //            e.Valid = false;                            
                //            MessageBox.Show("Chỉ có người đã nhập tour này mới được thay đổi tình trạng tour!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //        break;
                //    case 2:
                //        USP_GetAllCRUDByUserID_Result crudBoTour = UserInfoModel.GetCRUID("D.N.R.02");
                //        if (crudBoTour != null && crudBoTour.U.HasValue && crudBoTour.U.Value)
                //        {
                //            GetRegister2018_Result returnItem = tourDal.UpdateRegister(item);
                //            item.ID = returnItem.ID;
                //            alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                //            RefreshData();
                //        }
                //        else
                //        {
                //            e.Valid = false;                            
                //            MessageBox.Show("Chỉ có người được cấp quyền mới được bỏ tour!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //        break;
                //}

                //Neu nguoi dung co quyen bo tour
                //Chi cho phep cap nhat tinh trang bo tour
                //USP_GetAllCRUDByUserID_Result crudBoTour = UserInfoModel.GetCRUID("D.N.R.02");
                //if (crudBoTour != null && crudBoTour.U.HasValue && crudBoTour.U.Value && item.TinhTrang == 2)
                //{
                //    GetRegister2018_Result returnItem = tourDal.UpdateRegister(item);
                //    item.ID = returnItem.ID;
                //    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                //    RefreshData();
                //}
                //else
                //{
                //    //neu khong co quyen bo tour ma bo tour
                //    if (item.TinhTrang == 2)
                //    {
                //        MessageBox.Show("Lỗi", "Chỉ có người được cấp quyền mới được bỏ tour!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    else
                //    {
                //        //neu co quyen thay doi nhung khong phai thong tin cua nguoi do
                //        if (item.NguoiCapNhat == ERMs.Sys.ConfigurationSetting.UserInfo.UserName)
                //        {
                //            GetRegister2018_Result returnItem = tourDal.UpdateRegister(item);
                //            item.ID = returnItem.ID;
                //            alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                //            RefreshData();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Lỗi", "Chỉ có người nhập tour này mới thay đổi tình trạng tour đã nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            FrmTourImport form = new FrmTourImport();                      
            if (form.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnExportEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "DangKyTour.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {               
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gv.BestFitColumns();
                gv.ExportToXlsx(file.FileName);                
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void newBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateTourStatus(0);
        }

        private void huyBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateTourStatus(1);
        }

        private void boTourbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateTourStatus(2);            
        }

        private void UpdateTourStatus(int status)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            try
            {
                List<GetRegister2018_Result> lstRegister = new List<GetRegister2018_Result>();
                for (int i = 0; i < gv.GetSelectedRows().Length; i++)
                {
                    int rowHandle = gv.GetSelectedRows()[i];
                    GetRegister2018_Result item = (GetRegister2018_Result)gv.GetRow(rowHandle);

                    USP_GetAllCRUDByUserID_Result crudBoTour = UserInfoModel.GetCRUID("D.N.R.02");
                    if (crudBoTour != null && crudBoTour.U.HasValue && crudBoTour.U.Value)
                    {
                        item.TinhTrang = status;
                        lstRegister.Add(item);
                    }
                    else
                    {
                        if (item.NguoiCapNhat == ERMs.Sys.ConfigurationSetting.UserInfo.UserName)
                        {
                            item.TinhTrang = status;
                            lstRegister.Add(item);
                        }
                    }                                 
                }
                if (lstRegister.Count > 0)
                {
                    tourDal.UpdateStatusListRegister(lstRegister);
                    RefreshData();
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                }
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }

        }

        private void txtMSNV_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        
        private void gv_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            GetRegister2018_Result item = (GetRegister2018_Result)view.GetRow(view.FocusedRowHandle);            
            USP_GetAllCRUDByUserID_Result crudBoTour = UserInfoModel.GetCRUID("D.N.R.02");
            if (crudBoTour != null && crudBoTour.U.HasValue && crudBoTour.U.Value)
            {                
            }
            else
            {
                if (item.NguoiCapNhat != ERMs.Sys.ConfigurationSetting.UserInfo.UserName)
                {
                    e.Cancel = true;                    
                }
            }            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            UpdateTourStatus(1);
        }

        private void btnBoTour_Click(object sender, EventArgs e)
        {
            UpdateTourStatus(2);
        }
    }
}