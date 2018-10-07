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
using Erms.Utils;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.Export;
using DevExpress.XtraGrid.Columns;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReport2 : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstSeletedCategory = new List<API_CR_USP_Flight_FinalReport_Get_Category_Result>();
        public FrmFlightFinalReport2()
        {
            InitializeComponent();
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTodate.DateTime = DateTime.Today;
            List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = db.GetFlightFinalReportCategory();
            API_CR_USP_Flight_FinalReport_Get_Category_Result autoCategory = new API_CR_USP_Flight_FinalReport_Get_Category_Result();
            autoCategory.SubCategoryID = -1;
            autoCategory.Category = "Tự động";
            autoCategory.SubCategory = "Tự động";
            lstCategory.Insert(0, autoCategory);
            CheckedListBoxItem item = null;            
            foreach (API_CR_USP_Flight_FinalReport_Get_Category_Result category in lstCategory)
            {                
                item = new CheckedListBoxItem();
                item.Description = string.Format("({0}) {1}", category.Category, category.SubCategory);
                item.Value = category.SubCategoryID;                
                repositoryItemCheckedComboBoxEdit1.Items.Add(item);                
            }            

            List<HR_Department> lstDepartment = db.GetDepartment();
            HR_Department deparment = new HR_Department();
            deparment.ID = -1;
            deparment.DepartmentName = "All";
            lstDepartment.Insert(0, deparment);
            deparment = new HR_Department();
            deparment.ID = -2;
            deparment.DepartmentName = "";
            lstDepartment.Insert(1, deparment);
            deparment = new HR_Department();
            deparment.ID = -3;
            deparment.DepartmentName = "Bất kỳ phòng ban";
            lstDepartment.Insert(2, deparment);
            lookUpEditDepartment.Properties.DataSource = lstDepartment;
            lookUpEditDepartment.Properties.ValueMember = "ID";
            lookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
            lookUpEditDepartment.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lookUpEditDepartment.EditValue = "-1";
            comboBoxEditEmergency.SelectedIndex = 0;

            gcCategory.DataSource = db.GetFlightFinalReportCategory();
            //gcCategory.DataSource = lstCategory.ToList();
            popupContainerControl1.Width = 350;
            popupContainerControl1.Height = 250;
            popupContainerEdit1.Properties.PopupControl = popupContainerControl1;

            StyleFormatCondition styleDaXuLy = new StyleFormatCondition();
            //styleDaXuLy.Column = gridColumn18;
            styleDaXuLy.Condition = FormatConditionEnum.Expression;
            styleDaXuLy.Expression = "Not IsNullOrEmpty([ReplyInfo])";
            styleDaXuLy.Appearance.BackColor = Color.LightBlue;
            styleDaXuLy.Appearance.BackColor2 = Color.LightBlue;
            styleDaXuLy.Appearance.Options.UseBackColor = true;
            styleDaXuLy.ApplyToRow = true;
            gvFlightFinalReport.FormatConditions.Add(styleDaXuLy);

            StyleFormatCondition stylePhongBanChuaTraLoi = new StyleFormatCondition();
            //styleDaXuLy.Column = gridColumn18;
            stylePhongBanChuaTraLoi.Condition = FormatConditionEnum.Expression;
            stylePhongBanChuaTraLoi.Expression = "Not IsNullOrEmpty([Code]) and IsNullOrEmpty([DepartmentReply])";
            stylePhongBanChuaTraLoi.Appearance.BackColor = Color.LightYellow;
            stylePhongBanChuaTraLoi.Appearance.BackColor2 = Color.LightYellow;
            stylePhongBanChuaTraLoi.Appearance.Options.UseBackColor = true;
            stylePhongBanChuaTraLoi.ApplyToRow = true;
            gvFlightFinalReport.FormatConditions.Add(stylePhongBanChuaTraLoi);

            StyleFormatCondition stylePhongBanDaTraLoi = new StyleFormatCondition();
            //styleDaXuLy.Column = gridColumn18;
            stylePhongBanDaTraLoi.Condition = FormatConditionEnum.Expression;
            stylePhongBanDaTraLoi.Expression = "Not IsNullOrEmpty([Code]) and Not IsNullOrEmpty([DepartmentReply])";
            stylePhongBanDaTraLoi.Appearance.BackColor = Color.LightGray;
            stylePhongBanDaTraLoi.Appearance.BackColor2 = Color.LightGray;
            stylePhongBanDaTraLoi.Appearance.Options.UseBackColor = true;
            stylePhongBanDaTraLoi.ApplyToRow = true;
            gvFlightFinalReport.FormatConditions.Add(stylePhongBanDaTraLoi);

            UpdateGridView();
        }

        public void UpdateGridView()
        {
            DateTime? fromdate = null, todate = null;
            if (!string.IsNullOrEmpty(txtFromdate.Text))
            {
                fromdate = txtFromdate.DateTime;
                fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);
            }

            if (!string.IsNullOrEmpty(txtTodate.Text))
            {
                todate = txtTodate.DateTime;
                todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromFlightdate = null, toFlightdate = null;
            if (!string.IsNullOrEmpty(txtFromdateFlightDate.Text))
            {
                fromFlightdate = txtFromdateFlightDate.DateTime;
                fromFlightdate = new DateTime(fromFlightdate.Value.Year, fromFlightdate.Value.Month, fromFlightdate.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtTodateFlightDate.Text))
            {
                toFlightdate = txtTodateFlightDate.DateTime;
                toFlightdate = new DateTime(toFlightdate.Value.Year, toFlightdate.Value.Month, toFlightdate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromDateDeparmetSent = null, toDateDeparmetSent = null;
            if (!string.IsNullOrEmpty(txtFromDateDeparmetSent.Text))
            {
                fromDateDeparmetSent = txtFromDateDeparmetSent.DateTime;
                fromDateDeparmetSent = new DateTime(fromDateDeparmetSent.Value.Year, fromDateDeparmetSent.Value.Month, fromDateDeparmetSent.Value.Day, 0, 0, 0, 0);
            }

            if (!string.IsNullOrEmpty(txtToDateDeparmetSent.Text))
            {
                toDateDeparmetSent = txtToDateDeparmetSent.DateTime;
                toDateDeparmetSent = new DateTime(toDateDeparmetSent.Value.Year, toDateDeparmetSent.Value.Month, toDateDeparmetSent.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromDateDeparmetRelied = null, toDateDeparmetRelied = null;
            if (!string.IsNullOrEmpty(txtFromDateDeparmetRelied.Text))
            {
                fromDateDeparmetRelied = txtFromDateDeparmetRelied.DateTime;
                fromDateDeparmetRelied = new DateTime(fromDateDeparmetRelied.Value.Year, fromDateDeparmetRelied.Value.Month, fromDateDeparmetRelied.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtToDateDeparmetRelied.Text))
            {
                toDateDeparmetRelied = txtToDateDeparmetRelied.DateTime;
                toDateDeparmetRelied = new DateTime(toDateDeparmetRelied.Value.Year, toDateDeparmetRelied.Value.Month, toDateDeparmetRelied.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromDateRelied = null, toDateRelied = null;
            if (!string.IsNullOrEmpty(txtFromDateRelied.Text))
            {
                fromDateRelied = txtFromDateRelied.DateTime;
                fromDateRelied = new DateTime(fromDateRelied.Value.Year, fromDateRelied.Value.Month, fromDateRelied.Value.Day, 0, 0, 0, 0);
            }

            if (!string.IsNullOrEmpty(txtToDateRelied.Text))
            {
                toDateRelied = txtToDateRelied.DateTime;
                toDateRelied = new DateTime(toDateRelied.Value.Year, toDateRelied.Value.Month, toDateRelied.Value.Day, 23, 59, 59, 59);
            }

            int? deparmentID = null;
            if (lookUpEditDepartment.EditValue.ToString() != "-2")
            {
                deparmentID = Convert.ToInt32(lookUpEditDepartment.EditValue);
            }

            int? emergency = null;
            switch (comboBoxEditEmergency.SelectedIndex)
            {
                case 1:
                    emergency = 0;
                    break;
                case 2:
                    emergency = 1;
                    break;
                case 3:
                    emergency = 2;
                    break;
            }
            string replier = null;
            if (!string.IsNullOrEmpty(txtReplier.Text))
            {
                replier = txtReplier.Text;
            }

            int? reportStatus = null;
            switch (comboBoxEditReportStatus.SelectedIndex)
            {
                case 1: //chua xu ly
                    reportStatus = -1;
                    break;
                case 2: //chua tra loi tv: truong status la null, hoac bang 0 hoac bang 2 (dang khoa)
                    reportStatus = 0;
                    break;
                case 3: //da tra loi tv: truong status = 1
                    reportStatus = 1;
                    break;
                case 4: //bp chua tra loi
                    reportStatus = -2;
                    break;
            }
            if (lstSeletedCategory.Count <= 0)
                gcFlightFinalReport.DataSource = db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, fromDateDeparmetSent, toDateDeparmetSent, fromDateDeparmetRelied, toDateDeparmetRelied, fromDateRelied, toDateRelied, emergency, reportStatus, null, deparmentID, replier);
            else
            {
                List<API_CR_USP_GetFlightFinalReport5_Result> lstFlightFinalReport = new List<API_CR_USP_GetFlightFinalReport5_Result>();
                foreach (var category in lstSeletedCategory)
                {
                    lstFlightFinalReport.AddRange(db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, fromDateDeparmetSent, toDateDeparmetSent, fromDateDeparmetRelied, toDateDeparmetRelied, fromDateRelied, toDateRelied, emergency, reportStatus, category.SubCategoryID.ToString(), deparmentID, replier));
                }
                gcFlightFinalReport.DataSource = lstFlightFinalReport;
            }
            foreach (GridColumn column in gvFlightFinalReport.Columns)
            {
                if (column.FieldName == "Category" ||
                    column.FieldName == "ReplyInfo" ||
                    column.FieldName == "Replier" ||
                    column.FieldName == "DepartmentReply" ||
                    column.FieldName == "Content" ||
                    column.FieldName == "FullName")
                    continue;
                column.BestFit();
            }
            //gvFlightFinalReport.BestFitColumns();              
        }

        private void btnSearchFlightFinalReport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void txtFromdate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtFromdate.EditValue = null;
            }
        }

        private void txtTodate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtTodate.EditValue = null;
            }
        }

        private void txtFromdateFlightDate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtFromdateFlightDate.EditValue = null;
            }
        }

        private void txtTodateFlightDate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtTodateFlightDate.EditValue = null;
            }
        }

        private void dateEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtFromDateDeparmetSent.EditValue = null;
            }
        }

        private void dateEdit2_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtToDateDeparmetSent.EditValue = null;
            }
        }

        private void dateEdit3_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtFromDateDeparmetRelied.EditValue = null;
            }
        }

        private void dateEdit4_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtToDateDeparmetRelied.EditValue = null;
            }
        }

        private void popupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            int[] selectedRows = gridView1.GetSelectedRows();
            lstSeletedCategory.Clear();            
            StringBuilder sb = new StringBuilder();
            foreach (int selectionRow in selectedRows)
            {
                if (selectionRow < 0)
                    continue;
                API_CR_USP_Flight_FinalReport_Get_Category_Result f = gridView1.GetRow(selectionRow) as API_CR_USP_Flight_FinalReport_Get_Category_Result;
                lstSeletedCategory.Add(f);
                if (sb.ToString().Length > 0) { sb.Append(", "); }
                sb.Append(string.Format("({0}) {1}", f.Category, f.SubCategory));
            }
            e.Value = sb.ToString();
            gridView1.ClearSelection();
            gridView1.CollapseAllGroups();            
        }

        private void btnSelectCategory_Click(object sender, EventArgs e)
        {
            Control button = sender as Control;
            //Close the dropdown accepting the user's choice 
            popupContainerEdit1.ClosePopup();
        }

        private void popupContainerEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                lstSeletedCategory.Clear();
                popupContainerEdit1.EditValue = "";
            }
        }

        private void gvFlightFinalReport_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "FlightNo")
            {
                var flightReport = gvFlightFinalReport.GetRow(e.RowHandle) as API_CR_USP_GetFlightFinalReport5_Result;                
                FrmFlightFinalReportDetail frmDetails = new FrmFlightFinalReportDetail(flightReport.ID);
                frmDetails.MdiParent = this.ParentForm;
                frmDetails.Show();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.Title = "Save an Excel";
                file.FileName = "BaoCaoChuyenBay.xlsx";
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    if (cbxAuto.Checked)
                    {
                        gvFlightFinalReport.ExportToXlsx(file.FileName);                        
                    }                    
                    else
                    {
                        List<API_CR_USP_GetFlightFinalReport5_Result> lstFlightFinalReport = (List<API_CR_USP_GetFlightFinalReport5_Result>)gvFlightFinalReport.DataSource;
                        List<API_CR_USP_GetFlightFinalReport5_Result> lstFlightFinalReportTemp = new List<API_CR_USP_GetFlightFinalReport5_Result>();
                        foreach (var flightFinalReport in lstFlightFinalReport)
                        {
                            if (flightFinalReport.Category == "-1")
                                continue;
                            lstFlightFinalReportTemp.Add(flightFinalReport);
                        }
                        gcFlightFinalReport.DataSource = lstFlightFinalReportTemp;
                        gvFlightFinalReport.ExportToXlsx(file.FileName);
                        gcFlightFinalReport.DataSource = lstFlightFinalReport;                        
                    }
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
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
                        API_CR_USP_GetFlightFinalReport5_Result temp = (API_CR_USP_GetFlightFinalReport5_Result)gvFlightFinalReport.GetRow(rowIndex);
                        API_CR_USP_GetFlightFinalReportByID_Result flightFinalReport = db.GetFullFlightFinalReportByID(temp.ID);
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

                    DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\FlightFinalReport.doc", file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void dateEdit1_Properties_ButtonClick_1(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtFromDateRelied.EditValue = null;
            }
        }

        private void dateEdit2_Properties_ButtonClick_1(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtToDateRelied.EditValue = null;
            }
        }

        private void btnLstBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Word|*.doc";
                file.Title = "Save an Doc";
                file.FileName = "BaoCaoTinhHinhKhaiThacBay.doc";

                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);                                        
                    DateTime? fromdate = null, todate = null;
                    if (!string.IsNullOrEmpty(txtFromdate.Text))
                    {
                        fromdate = txtFromdate.DateTime;
                        fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);
                    }

                    if (!string.IsNullOrEmpty(txtTodate.Text))
                    {
                        todate = txtTodate.DateTime;
                        todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
                    }

                    DateTime? fromFlightdate = null, toFlightdate = null;
                    if (!string.IsNullOrEmpty(txtFromdateFlightDate.Text))
                    {
                        fromFlightdate = txtFromdateFlightDate.DateTime;
                        fromFlightdate = new DateTime(fromFlightdate.Value.Year, fromFlightdate.Value.Month, fromFlightdate.Value.Day, 0, 0, 0, 0);
                    }
                    if (!string.IsNullOrEmpty(txtTodateFlightDate.Text))
                    {
                        toFlightdate = txtTodateFlightDate.DateTime;
                        toFlightdate = new DateTime(toFlightdate.Value.Year, toFlightdate.Value.Month, toFlightdate.Value.Day, 23, 59, 59, 59);
                    }

                    List<API_CR_USP_GetFlightFinalReport2_Result> lstFlightReport = new List<API_CR_USP_GetFlightFinalReport2_Result>();
                    if (lstSeletedCategory.Count <= 0)
                        lstFlightReport = db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, false, true, "");
                    else
                    {                        
                        foreach (var category in lstSeletedCategory)
                        {
                            lstFlightReport.AddRange(db.GetFlightFinalReport(fromdate, todate, fromFlightdate, toFlightdate, false, false, category.SubCategoryID.ToString()));
                        }                        
                    }

                    List<FlightReportTemplate> lstFR = new List<FlightReportTemplate>();
                    FlightReportTemplate fr = new FlightReportTemplate();
                    fr.IDTemPlate = 1;
                    fr.FromDate = fromdate.Value.ToString("dd/MM/yyyy");
                    fr.ToDate = todate.Value.ToString("dd/MM/yyyy");
                    lstFR.Add(fr);

                    List<FlightReportDetailTemplate> lstDetailFR = new List<FlightReportDetailTemplate>();
                    FlightReportDetailTemplate dt = null;
                    for (int i =0; i< lstFlightReport.Count; i++)                    
                    {
                        API_CR_USP_GetFlightFinalReport2_Result temp = lstFlightReport[i];
                        dt = new FlightReportDetailTemplate().ToModel(temp);
                        dt.IDTemPlate = 1;
                        dt.FRIndex = (i + 1).ToString();
                        lstDetailFR.Add(dt);
                    }


                    //List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = db.GetFlightFinalReportCategory();
                    //List<FlightFinalReportModel> lstFlightFinalReport = new List<FlightFinalReportModel>();
                    //foreach (int rowIndex in gvFlightFinalReport.GetSelectedRows())
                    //{
                    //    API_CR_USP_GetFlightFinalReport5_Result temp = (API_CR_USP_GetFlightFinalReport5_Result)gvFlightFinalReport.GetRow(rowIndex);
                    //    API_CR_USP_GetFlightFinalReportByID_Result flightFinalReport = db.GetFullFlightFinalReportByID(temp.ID);
                    //    if (flightFinalReport == null) return;
                    //    lstFlightFinalReport.Add(new FlightFinalReportModel().ToModel(flightFinalReport, lstCategory));
                    //}

                    //List<API_CR_USP_GetFlightCrew2_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrew2_Result>();
                    //foreach (FlightFinalReportModel reportModel in lstFlightFinalReport)
                    //{
                    //    lstFlightCrew.AddRange(db.GetFlightCrew2ByFlightID(reportModel.FlightID.Value));
                    //}

                    DataSet ds = new DataSet();
                    DataTable dtFlightFinalReport = new DataTable("fr");
                    ListUtils.LoadRows(dtFlightFinalReport, lstFR);
                    ds.Tables.Add(dtFlightFinalReport);


                    DataTable dtFlightCrew = new DataTable("cr");
                    ListUtils.LoadRows(dtFlightCrew, lstDetailFR);
                    ds.Tables.Add(dtFlightCrew);

                    List<DictionaryEntry> list = new List<DictionaryEntry>()
                    {
                        new DictionaryEntry("fr", String.Empty),
                        new DictionaryEntry("cr", "IDTemPlate = %fr.IDTemPlate%")
                    };
                    //List<DictionaryEntry>  list = new List<DictionaryEntry>();

                    DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\BaoCaoTinhHinhKhaiThacBay.doc", file.FileName);
                    SplashScreenManager.CloseForm(false);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void btnExcelNoAuto_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.Title = "Save an Excel";
                file.FileName = "BaoCaoChuyenBay.xlsx";

                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {                    
                    List<API_CR_USP_GetFlightFinalReport5_Result> lstFlightFinalReport = (List<API_CR_USP_GetFlightFinalReport5_Result>)gvFlightFinalReport.DataSource;
                    List<API_CR_USP_GetFlightFinalReport5_Result> lstFlightFinalReportTemp = new List<API_CR_USP_GetFlightFinalReport5_Result>();
                    foreach (var flightFinalReport in lstFlightFinalReport)
                    {
                        if (flightFinalReport.Category == "-1")
                            continue;
                        lstFlightFinalReportTemp.Add(flightFinalReport);
                    }
                    gcFlightFinalReport.DataSource = lstFlightFinalReportTemp;                    
                    gvFlightFinalReport.ExportToXlsx(file.FileName);

                    gcFlightFinalReport.DataSource = lstFlightFinalReport;                    
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }
    }
}