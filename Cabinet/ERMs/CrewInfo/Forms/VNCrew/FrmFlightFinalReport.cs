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
using ERMs.Data.Flight;
using ERMs.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using System.Collections;
using Erms.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReport : ERMs.SharedBase.XtraFormMDIBase
    {
        const int PPHKID = 3;
        FlightDal db = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        List<int> lstDepartmentID = new List<int>();
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;

        public FrmFlightFinalReport()
        {
            InitializeComponent();            
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTodate.DateTime = DateTime.Today;
            List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = db.GetFlightFinalReportCategory();
            List<int> mainCategory = new List<int>();
            CheckedListBoxItem item = null;
            CheckedListBoxItem itemDanhMuc = null;
            foreach (API_CR_USP_Flight_FinalReport_Get_Category_Result category in lstCategory)
            {
                if (mainCategory.IndexOf(category.CategoryID.Value) == -1)
                {
                    item = new CheckedListBoxItem();
                    item.Description = category.Category;
                    //item.Value = category.CategoryID.Value;
                    item.CheckState = CheckState.Unchecked;
                    item.Enabled = false;
                    cbxDanhMuc.Properties.Items.Add(item);
                    mainCategory.Add(category.CategoryID.Value);
                }
                item = new CheckedListBoxItem();
                item.Description = string.Format("[{0}] {1}", category.Category, category.SubCategory);
                item.Value = category.SubCategoryID;

                itemDanhMuc = new CheckedListBoxItem();
                itemDanhMuc.Description = category.SubCategory;
                itemDanhMuc.Value = category.SubCategoryID;
                repositoryItemCheckedComboBoxEdit1.Items.Add(item);
                cbxDanhMuc.Properties.Items.Add(itemDanhMuc);
            }

            StyleFormatCondition styleDaXuLy, styleKhoa;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleKhoa = new StyleFormatCondition(FormatConditionEnum.Equal, clReportStatus, null, 2);
            styleKhoa.Appearance.BackColor = Color.Yellow;
            styleKhoa.Appearance.BackColor2 = Color.Yellow;
            styleKhoa.ApplyToRow = true;
            gvFlightFinalReport.FormatConditions.Add(styleKhoa);

            styleDaXuLy = new StyleFormatCondition(FormatConditionEnum.Equal, clReportStatus, null, 1);
            styleDaXuLy.Appearance.BackColor = Color.LightBlue;
            styleDaXuLy.Appearance.BackColor2 = Color.LightBlue;
            styleDaXuLy.ApplyToRow = true;
            gvFlightFinalReport.FormatConditions.Add(styleDaXuLy);

            StyleFormatCondition styleChuaTraLoi = new StyleFormatCondition(FormatConditionEnum.Equal, clBPTraLoi, null, null);
            styleChuaTraLoi.Appearance.BackColor = Color.Red;
            styleChuaTraLoi.Appearance.BackColor2 = Color.White;
            styleChuaTraLoi.ApplyToRow = true;
            gvFinalReportDepartment.FormatConditions.Add(styleChuaTraLoi);

            lstDepartmentID = db.GetDepartmentByEmployeeID(ERMs.Sys.ConfigurationSetting.UserInfo.Userid).Select(i => i.DepartmentID).ToList();
            //dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.C.R.01", out create, out read, out update, out delete);
            //cbxView.EditValue = update ? "0" : "1";            
            cbxView.EditValue = "0";
            UpdateGridView();
        }

        private void FrmFlightFinalReport_Load(object sender, EventArgs e)
        {
                    
        }

        public void UpdateGridView()
        {              
            DateTime? fromdate = null, todate = null;
            if (!string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                fromdate = txtFromdate.DateTime;
                todate = txtTodate.DateTime;
                fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);
                todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromFlightdate = null, toFlightdate = null;
            if (!string.IsNullOrEmpty(txtFromdateFlightDate.Text) && !string.IsNullOrEmpty(txtTodateFlightDate.Text))
            {
                fromFlightdate = txtFromdateFlightDate.DateTime;
                toFlightdate = txtTodateFlightDate.DateTime;
                fromFlightdate = new DateTime(fromFlightdate.Value.Year, fromFlightdate.Value.Month, fromFlightdate.Value.Day, 0, 0, 0, 0);
                toFlightdate = new DateTime(toFlightdate.Value.Year, toFlightdate.Value.Month, toFlightdate.Value.Day, 23, 59, 59, 59);
            }


            //gcFlightFinalReport.DataSource = db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate);

            //foreach (string danhmuc in cbxDanhMuc.SelectedText)
            
            switch (cbxView.EditValue.ToString())
            {
                case "0":
                    gcFlightFinalReport.DataSource = null;
                    gcFlightFinalReport.MainView = gvFlightFinalReport;
                    List<API_CR_USP_GetFlightFinalReport2_Result> lstFlightFinalReport = new List<API_CR_USP_GetFlightFinalReport2_Result>();
                    if (string.IsNullOrEmpty(cbxDanhMuc.EditValue.ToString()))
                    {
                        lstFlightFinalReport = db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, false, true, "");
                    }
                    else
                    {
                        foreach (string category in cbxDanhMuc.EditValue.ToString().Split(','))
                        {
                            lstFlightFinalReport.AddRange(db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, false, false, category));
                        }
                    }
                    gcFlightFinalReport.DataSource = lstFlightFinalReport;
                    break;
                case "1":
                    gcFlightFinalReport.DataSource = null;
                    gcFlightFinalReport.MainView = gvFinalReportDepartment;                    
                    List<API_CR_USP_GetFlightFinalReportDepartment_Result> lstFinalReportDepartment = new List<API_CR_USP_GetFlightFinalReportDepartment_Result>();
                    if (lstDepartmentID.IndexOf(PPHKID) >= 0)   //Neu la phong pphk thi lay tat ca phong ban
                    {
                        if (string.IsNullOrEmpty(cbxDanhMuc.EditValue.ToString()))
                        {
                            lstFinalReportDepartment.AddRange(db.GetFlightFinalReportDeparment(fromdate, todate, fromFlightdate, toFlightdate, false, true, 0, true, 0));
                        }
                        else
                        {
                            foreach (string category in cbxDanhMuc.EditValue.ToString().Split(','))
                            {
                                lstFinalReportDepartment.AddRange(db.GetFlightFinalReportDeparment(fromdate, todate, fromFlightdate, toFlightdate, false, false, Convert.ToInt32(category), true, 0));
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(cbxDanhMuc.EditValue.ToString()))
                        {
                            foreach (int departmentID in lstDepartmentID)
                            {
                                lstFinalReportDepartment.AddRange(db.GetFlightFinalReportDeparment(fromdate, todate, fromFlightdate, toFlightdate, false, true, 0, false, departmentID));
                            }
                        }
                        else
                        {
                            foreach (int departmentID in lstDepartmentID)
                            {
                                foreach (string category in cbxDanhMuc.EditValue.ToString().Split(','))
                                {
                                    lstFinalReportDepartment.AddRange(db.GetFlightFinalReportDeparment(fromdate, todate, fromFlightdate, toFlightdate, false, false, Convert.ToInt32(category), false, departmentID));
                                }
                            }
                        }
                    }
                    gcFlightFinalReport.DataSource = lstFinalReportDepartment;
                    break;
            }                       
        }

        private void btnSearchFlightFinalReport_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text)) ||
                (string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text)) ||
                (!string.IsNullOrEmpty(txtFromdateFlightDate.Text) && string.IsNullOrEmpty(txtTodateFlightDate.Text)) ||
                (string.IsNullOrEmpty(txtFromdateFlightDate.Text) && !string.IsNullOrEmpty(txtTodateFlightDate.Text)))
            {
                MessageBox.Show("Bạn phải chọn đầy đủ từ ngày tới ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text) &&
                string.IsNullOrEmpty(txtFromdateFlightDate.Text) && string.IsNullOrEmpty(txtTodateFlightDate.Text))
            {
                MessageBox.Show("Bạn phải chọn ngày bay hoặc ngày báo cáo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void btnClearReportDate_Click(object sender, EventArgs e)
        {
            txtFromdate.Text = txtTodate.Text = "";
        }

        private void btnClearFlightDate_Click(object sender, EventArgs e)
        {
            txtFromdateFlightDate.Text = txtTodateFlightDate.Text = "";
        }

        private void btnExportFlightFinalReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Word|*.doc";
                file.Title = "Save an Doc";
                file.FileName = "BaoCaoChuyenBay.doc";                

                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = db.GetFlightFinalReportCategory();
                    List<FlightFinalReportModel> lstFlightFinalReport = new List<FlightFinalReportModel>();
                    foreach (int rowIndex in gvFlightFinalReport.GetSelectedRows())
                    {                        
                        API_CR_USP_GetFlightFinalReport2_Result flightFinalReport = (API_CR_USP_GetFlightFinalReport2_Result)gvFlightFinalReport.GetRow(rowIndex);
                        if (flightFinalReport == null) return;
                        lstFlightFinalReport.Add(new FlightFinalReportModel().ToModel(flightFinalReport, lstCategory));
                    }

                    List<API_CR_USP_GetFlightCrew2_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrew2_Result>();
                    foreach (FlightFinalReportModel reportModel in lstFlightFinalReport)
                    {
                        lstFlightCrew.AddRange(db.GetFlightCrew2ByFlightID(reportModel.FlightID.Value));
                    }

                    DataSet ds = new DataSet();
                    DataTable dtFlightFinalReport = new DataTable("fr");
                    ListUtils.LoadRows(dtFlightFinalReport, lstFlightFinalReport);
                    ds.Tables.Add(dtFlightFinalReport);


                    DataTable dtFlightCrew = new DataTable("cr");
                    ListUtils.LoadRows(dtFlightCrew, lstFlightCrew);
                    ds.Tables.Add(dtFlightCrew);                    

                    List<DictionaryEntry> list = new List<DictionaryEntry>
                    {
                        new DictionaryEntry("fr", String.Empty),
                        new DictionaryEntry("cr", "FlightID = %fr.FlightID%")
                    };
                    //list = new List<DictionaryEntry>();

                    DocUtility.MergeFile(ds, list, "FlightFinalReport.doc", file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.Title = "Save an Excel";
                file.FileName = "BaoCaoChuyenBay.xlsx";                

                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    //ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                    //gvFlightFinalReport.BestFitColumns();
                    switch (cbxView.EditValue.ToString())
                    {
                        case "0":
                            gvFlightFinalReport.ExportToXlsx(file.FileName);
                            break;
                        case "1":
                            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;                            
                            gvFinalReportDepartment.ExportToXlsx(file.FileName);
                            break;
                    }
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void gvFlightFinalReport_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gvFlightFinalReport.CalcHitInfo(e.Location);

            if (hitInfo.InRowCell == true && hitInfo.Column == gvFlightFinalReport.Columns["ID"])
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }

        private void gvFlightFinalReport_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clID")
            {
                int id = (int)e.CellValue;
                //FrmFlightFinalReportDetails frmDetails = new FrmFlightFinalReportDetails();
                //frmDetails.ID = id;
                //frmDetails.MdiParent = this.ParentForm;
                //frmDetails.Show();
                FrmFlightFinalReportDetail frmDetails = new FrmFlightFinalReportDetail(id);                
                frmDetails.MdiParent = this.ParentForm;
                frmDetails.Show();
            }
        }

        private void cbxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxView.EditValue.ToString())
            {
                case "0":
                    btnExportFlightFinalReport.Visible = true;
                    break;
                case "1":
                    btnExportFlightFinalReport.Visible = false;
                    break;
            }

            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void cbxDanhMuc_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {            
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                cbxDanhMuc.SetEditValue("");
            }            
        }

        private void gvFinalReportDepartment_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                int id = (int)e.CellValue;
                FrmFlightFinalReportDetail frmDetails = new FrmFlightFinalReportDetail(id);
                frmDetails.MdiParent = this.ParentForm;
                frmDetails.Show();
            }
        }
    }
}