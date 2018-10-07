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
using DevExpress.Export;

namespace CrewInfo.Forms.Briefing
{
    public partial class FrmBriefingDiary : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        BriefingDal db = new BriefingDal();
        List<SysAccBrfDiaryModel> lstSysAcc = null;
        #endregion

        public FrmBriefingDiary()
        {
            InitializeComponent();            
        }

        private void FrmBriefingDiary_Load(object sender, EventArgs e)
        {
            InitView();
        }

        #region Function
        private void InitView()
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.B.D.01".ToString());
            if (crud != null && crud.U.HasValue && crud.U.Value) btnUpdate.Visible = true;

            lstSysAcc = db.GetSysAcc();
            gv.Columns.Clear();
            GridColumn col = new GridColumn();
            col.Caption = "Ngay";
            col.FieldName = "Ngay";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.ColumnEdit = new RepositoryItemHyperLinkEdit();
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Hoten";
            col.FieldName = "hoten";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Bophan";
            col.FieldName = "bophan";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Chuyenbay";
            col.FieldName = "chuyenbay";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Noidung";
            col.FieldName = "noidung";
            col.Width = 200;
            col.Visible = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NhanNho,Y/CKhacPhuc";
            col.FieldName = "hinhthuc1";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "BCViPham";
            col.FieldName = "hinhthuc2";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "DinhBay";
            col.FieldName = "hinhthuc3";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "TreBriefing";
            col.FieldName = "hinhthuc4";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Base";
            col.FieldName = "Base";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NgayCapNhat";
            col.FieldName = "UpdatedDate";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NguoiCapNhat";
            col.FieldName = "UpdatedBy";
            col.Visible = true;
            gv.Columns.Add(col);

            RefreshData();
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-7) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            List<BR_BriefingDiary> lstBriefingDiary = db.GetBriefingDiary(fromdate, todate);
            gc.DataSource = lstBriefingDiary;
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName == "noidung")
                    continue;
                column.BestFit();
            }
            //gv.BestFitColumns();
        }
        #endregion

        #region Event
        private void txtFromdate_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtTodate_EditValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmAddBrfDiary frm = new FrmAddBrfDiary(lstSysAcc, null);
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();                     
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshData();
        }

        private void gv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Ngay":
                    USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.B.D.01".ToString());
                    if (crud != null && crud.U.HasValue && crud.U.Value)
                    {
                        BR_BriefingDiary diary = (BR_BriefingDiary)gv.GetRow(e.RowHandle);
                        FrmAddBrfDiary frm = new FrmAddBrfDiary(lstSysAcc, diary);
                        frm.FormClosed += Frm_FormClosed;
                        frm.ShowDialog();
                    }
                    break;                    
            }
        }
        #endregion

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "NhatKyBriefing.xlsx";
            file.Title = "Save an Excel";
            file.ShowDialog();
            if (file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gc.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        
    }
}