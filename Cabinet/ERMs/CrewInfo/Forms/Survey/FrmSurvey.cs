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
using CrewInfo.ADONet;
using System.Reflection;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.Export;
using DevExpress.XtraSpreadsheet;
using DevExpress.Spreadsheet;
using System.IO;

namespace CrewInfo.Forms.Survey
{
    public partial class FrmSurvey : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        const string SO_GHE = "0. Hạng ghế";
        SurveyDal db = new SurveyDal();
        BindingSource bind = new BindingSource();
        List<SurveyCategoryModel> lstSurveyCategory = new List<SurveyCategoryModel>();
        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();           
            

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;            
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);            

            col = new GridColumn();
            col.Caption = "Thông tin CB";
            col.FieldName = "FltInfo";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV";
            col.FieldName = "CID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "SurveyBy";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên Survey";
            col.FieldName = "FullName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày";
            col.FieldName = "Date";
            col.OptionsColumn.ReadOnly = true;
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);


            col = new GridColumn();
            col.Caption = "Số ghế";
            col.FieldName = "SeatNo";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV TVT";
            col.FieldName = "PurserID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên TVT";
            col.FieldName = "PurserName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV TVPTY";
            col.FieldName = "LeaderID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên TVPTY";
            col.FieldName = "LeaderName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Bài ĐG";
            col.FieldName = "CR_Survey_Category";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tổng điểm";
            col.FieldName = "TotalScore";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nhận xét";
            col.FieldName = "Comment";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đề nghị";
            col.FieldName = "Suggestion";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Thời gian ký";
            col.FieldName = "Signed";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            col.Visible = true;            
            col.OptionsColumn.ReadOnly = true;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tiêu chí";
            col.FieldName = "Question";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Visible = true;
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Trọng lượng";
            col.FieldName = "Factor";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Điểm";
            col.FieldName = "Score";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Giá trị quy đổi";
            col.FieldName = "ScoreValue";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nhận xét";
            col.FieldName = "Remark";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvChild.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đề nghị";
            col.FieldName = "Comment";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvChild.Columns.Add(col);

            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsPrint.AutoWidth = false;
            gvChild.OptionsBehavior.ReadOnly = true;
            gvChild.OptionsPrint.AutoWidth = false;            

            //gv.OptionsPrint.PrintDetails = true;
            gv.OptionsPrint.PrintSelectedRowsOnly = true;

            col = new GridColumn();
            col.Caption = "Thông tin CB";
            col.FieldName = "CR_Survey.FltInfo";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV";
            col.FieldName = "CR_Survey.CID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "CR_Survey.SurveyBy";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên Survey";
            col.FieldName = "CR_Survey.FullName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày";
            col.FieldName = "CR_Survey.Date";
            col.OptionsColumn.ReadOnly = true;
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tiêu chí";
            col.FieldName = "Question";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Trọng lượng";
            col.FieldName = "Factor";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Điểm";
            col.FieldName = "Score";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Giá trị quy đổi";
            col.FieldName = "ScoreValue";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nhận xét";
            col.FieldName = "Remark";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đề nghị";
            col.FieldName = "Comment";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gridView1.Columns.Add(col);

            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsPrint.AutoWidth = false;
            gvChild.OptionsBehavior.ReadOnly = true;
            gvChild.OptionsPrint.AutoWidth = false;

            gridView1.OptionsPrint.AutoWidth = false;
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-2) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string key = null;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                key = txtSearch.Text.Trim();
            bind.DataSource = db.GetListSurvey(fromdate, todate, key);
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
        public FrmSurvey()
        {
            InitializeComponent();
        }
        private void FrmSurvey_Load(object sender, EventArgs e)
        {
            //USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.CHK.BI.01");
            //if (crud != null && crud.U.HasValue && crud.U.Value)
            //gv.OptionsBehavior.Editable = true;
            //panelNav.Visible = false;
            lstSurveyCategory = db.GetListSurveyCategory();
            InitView();
            RefreshData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);            
        }
        private void gv_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            SurveyModel item = (SurveyModel)gv.GetRow(e.RowHandle);
            if (item == null) return;
            item.Items = db.GetSurveyItemBySurveyID(item.ID);
        }

        private void gv_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        #endregion

        private void gvChild_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dsSurvey ds = new dsSurvey();
            foreach (int rowHandle in gv.GetSelectedRows())
            //if (gv.GetSelectedRows().Length > 0)
            {
                //int rowHandle = gv.GetSelectedRows()[0];
                SurveyModel surveyModel = (SurveyModel)gv.GetRow(rowHandle);
                //surveyModel.Comment = surveyModel.Comment + "\r\n" + surveyModel.Suggestion;
                surveyModel.Items = db.GetSurveyItemBySurveyID(surveyModel.ID);
                if (surveyModel.Items.Count > 0)
                {
                    var item = surveyModel.Items[0];
                    if (item.Question.Contains(SO_GHE))
                        surveyModel.Items.RemoveAt(0);                    
                }
                CR_FlightInfo flightInfo = db.getFlightInfoByFlightID(surveyModel.FlightID);

                if (flightInfo != null)
                    addFlightInfo(ds, flightInfo);
                addSurvey(ds, surveyModel);                                
                addSurveyItem(ds, surveyModel.Items);                

            }
            RpSurvey xrpt = new RpSurvey();
            xrpt.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
            {
                printTool.ShowRibbonPreviewDialog();                
            }
        }

        private void addFlightInfo(dsSurvey ds, CR_FlightInfo flightInfo)
        {
            try
            {
                dsSurvey.CR_FlightInfoRow returnValue = ds.CR_FlightInfo.NewCR_FlightInfoRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = flightInfo.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(flightInfo, null), null);
                }
                ds.CR_FlightInfo.AddCR_FlightInfoRow(returnValue);
            } catch { }
        }

        private void addSurvey(dsSurvey ds, SurveyModel surveyModel)
        {
            dsSurvey.CR_SurveyRow returnValue = ds.CR_Survey.NewCR_SurveyRow();
            PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo destPi in destProperties)
            {
                PropertyInfo sourcePi = surveyModel.GetType().GetProperty(destPi.Name);
                if (sourcePi == null)
                    continue;
                destPi.SetValue(returnValue, sourcePi.GetValue(surveyModel, null), null);
            }
            ds.CR_Survey.AddCR_SurveyRow(returnValue);            
        }

        private void addSurveyItem(dsSurvey ds, List<CR_Survey_Item> lstItem)
        {            
            foreach (var item in lstItem)
            {
                dsSurvey.CR_Survey_ItemRow returnValue = ds.CR_Survey_Item.NewCR_Survey_ItemRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = item.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(item, null), null);
                }
                ds.CR_Survey_Item.AddCR_Survey_ItemRow(returnValue);
            }            
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void bbiReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dsSurvey ds = new dsSurvey();
            foreach (int rowHandle in gv.GetSelectedRows())
            //if (gv.GetSelectedRows().Length > 0)
            {
                //int rowHandle = gv.GetSelectedRows()[0];
                SurveyModel surveyModel = (SurveyModel)gv.GetRow(rowHandle);
                //surveyModel.Comment = surveyModel.Comment + "\r\n" + surveyModel.Suggestion;
                surveyModel.Items = db.GetSurveyItemBySurveyID(surveyModel.ID);
                if (surveyModel.Items.Count > 0)
                {
                    var item = surveyModel.Items[0];
                    if (item.Question.Contains(SO_GHE))
                        surveyModel.Items.RemoveAt(0);
                }
                CR_FlightInfo flightInfo = db.getFlightInfoByFlightID(surveyModel.FlightID);

                if (flightInfo != null)
                    addFlightInfo(ds, flightInfo);
                addSurvey(ds, surveyModel);
                addSurveyItem(ds, surveyModel.Items);

            }
            RpSurvey xrpt = new RpSurvey();
            xrpt.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void bbiExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "NguyenVong.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                List<CR_Survey_Item> lstSurveyItem = new List<CR_Survey_Item>();
                foreach (int rowHandle in gv.GetSelectedRows())
                {
                    SurveyModel item = (SurveyModel)gv.GetRow(rowHandle);
                    if (item == null) return;
                    //item.Items = db.GetSurveyItemBySurveyID(item.ID);
                    //gv.SetMasterRowExpanded(rowHandle, true);
                    lstSurveyItem.AddRange(db.GetSurveyItemBySurvey(item.ToData()));
                }
                gridControl1.DataSource = lstSurveyItem;
                gridView1.BestFitColumns();

                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gv.VisibleColumns[0].OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
                gv.ExportToXlsx("Parent.xlsx");                
                gridView1.ExportToXlsx("Child.xlsx");

                string[] files = new string[] { "Parent.xlsx", "Child.xlsx" };
                MergeXlsxFilesDevExpress(file.FileName, files);
                if (File.Exists("Parent.xlsx"))
                    File.Delete("Parent.xlsx");
                if (File.Exists("Child.xlsx"))
                    File.Delete("Child.xlsx");
                System.Diagnostics.Process.Start(file.FileName);
            }          
        }

        public void MergeXlsxFilesDevExpress(string destXlsxFileName, params string[] sourceXlsxFileNames)
        {
            SpreadsheetControl spreadsheetControl1 = new SpreadsheetControl();
            SpreadsheetControl spreadsheetControl2 = null;            
            spreadsheetControl1.CreateNewDocument();
            IWorkbook destWorkBook = spreadsheetControl1.Document;
            //destWorkBook.CreateNewDocument();

            foreach (var sourceXlsxFile in sourceXlsxFileNames)
            {
                spreadsheetControl2 = new SpreadsheetControl();
                spreadsheetControl2.LoadDocument(sourceXlsxFile);
                IWorkbook sourceWorkBook = spreadsheetControl2.Document;
                //sourceWorkBook.LoadDocument(sourceXlsxFile);
                foreach (DevExpress.Spreadsheet.Worksheet sheet in sourceWorkBook.Worksheets)
                {
                    DevExpress.Spreadsheet.Worksheet temp = destWorkBook.Worksheets.Add();
                    temp.CopyFrom(sheet);
                    //temp.Name = sheet.Name;
                }
                sourceWorkBook.Dispose();
            }

            destWorkBook.Worksheets.RemoveAt(0);
            destWorkBook.SaveDocument(destXlsxFileName);
            destWorkBook.Dispose();
        }

        private void bbiAnToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gv.GetSelectedRows().Length <= 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một survey an toàn trước khi tạo báo cáo", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            List<CR_FlightInfo> lstFlightInfo = new List<CR_FlightInfo>();
            List<SurveyItemModel> lstSurveyItem = new List<SurveyItemModel>();

            foreach (int rowHandle in gv.GetSelectedRows())            
            {                
                SurveyModel surveyModel = (SurveyModel)gv.GetRow(rowHandle); 
                CR_FlightInfo flightInfo = db.getFlightInfoByFlightID(surveyModel.FlightID);
                foreach (var surveyItem in db.GetSurveyItemBySurvey(surveyModel.ToData()))
                {
                    SurveyItemModel surveyItemModel = new SurveyItemModel();
                    surveyItemModel.ToCustomModel(surveyItem);
                    surveyItemModel.Routing = flightInfo.Routing;
                    lstSurveyItem.Add(surveyItemModel);
                }                
                if (flightInfo != null)
                    lstFlightInfo.Add(flightInfo);
            }

            int tongSoCB = lstFlightInfo.Count;
            int b787 = lstFlightInfo.Where(i => i.Aircraft == "787").Count();
            int a350 = lstFlightInfo.Where(i => i.Aircraft == "350").Count();
            int a330 = lstFlightInfo.Where(i => i.Aircraft == "330").Count();
            int a321 = lstFlightInfo.Where(i => i.Aircraft == "321").Count();
            int atr72 = lstFlightInfo.Where(i => i.Aircraft == "AT7").Count();

            int tongSoLanQS = lstSurveyItem.Count;
            //int soLanQSHopTC = lstSurveyItem.Where(i => i.Score == "Yes").Count();
            //int soLanQSKoHopTC = lstSurveyItem.Where(i => i.Score == "No").Count();
            int soLanQSKoAD = lstSurveyItem.Where(i => i.Score == "N/A").Count();

            var lstNoRoute = lstSurveyItem.Where(i => i.Input == true && i.Score == "No").OrderBy(i => i.ID).ThenBy(i => i.SN).GroupBy(i => new { i.Question, i.Routing })
            .Select(i => new
            {
                Question = i.Key.Question,
                Routing = i.Key.Routing,
                Count = i.Distinct().Count()
            }).ToList();

            var lstYesRoute = lstSurveyItem.Where(i => i.Input == true && i.Score == "Yes").OrderBy(i => i.ID).ThenBy(i => i.SN).GroupBy(i => new { i.Question, i.Routing })
            .Select(i => new
            {
                Question = i.Key.Question,
                Routing = i.Key.Routing,
                Count = i.Distinct().Count()
            }).ToList();

            var lstNo = lstNoRoute.GroupBy(i => i.Question)
            .Select(i => new
            {
                Question = i.Key,
                Count = i.Distinct().Count()
            }).ToList();
            int soLanQSKoHopTC = lstNo.Sum(i => i.Count);

            var lstYes = lstYesRoute.GroupBy(i => i.Question)
            .Select(i => new
            {
                Question = i.Key,
                Count = i.Distinct().Count()
            }).ToList();
            int soLanQSHopTC = lstYes.Sum(i => i.Count);

            dsSurveyAT ds = new dsSurveyAT();
            dsSurveyAT.HoatDongAnToanRow hoatDongAnToan = ds.HoatDongAnToan.NewHoatDongAnToanRow();
            hoatDongAnToan.ID = "1";
            hoatDongAnToan.TongSoCB = tongSoCB;            
            hoatDongAnToan.A321 = a321;
            hoatDongAnToan.A330 = a330;
            hoatDongAnToan.A350 = a350;
            hoatDongAnToan.B787 = b787;
            hoatDongAnToan.ATR72 = atr72;
            hoatDongAnToan.SoLanQuanSat = tongSoLanQS;
            hoatDongAnToan.LanQuanSatPhuHop = soLanQSHopTC;
            hoatDongAnToan.LanQuanSatKoPhuHop = soLanQSKoHopTC;
            hoatDongAnToan.LanQuanSatKoApDung = soLanQSKoAD;
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-2) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            hoatDongAnToan.FromDate = fromdate;
            hoatDongAnToan.ToDate = todate;
            ds.HoatDongAnToan.AddHoatDongAnToanRow(hoatDongAnToan);

            foreach (var noItem in lstNo)
            {
                dsSurveyAT.TieuChiQuanSatKoPhuHopRow tieuChiQuanSatKoPhuHop = ds.TieuChiQuanSatKoPhuHop.NewTieuChiQuanSatKoPhuHopRow();
                tieuChiQuanSatKoPhuHop.ID = "1";
                tieuChiQuanSatKoPhuHop.SoLuong = noItem.Count;
                tieuChiQuanSatKoPhuHop.TieuChi = noItem.Question;
                ds.TieuChiQuanSatKoPhuHop.AddTieuChiQuanSatKoPhuHopRow(tieuChiQuanSatKoPhuHop);
            }

            foreach (var yesItem in lstYes)
            {
                dsSurveyAT.TieuChiQuanSatPhuHopRow tieuChiQuanSatPhuHop = ds.TieuChiQuanSatPhuHop.NewTieuChiQuanSatPhuHopRow();
                tieuChiQuanSatPhuHop.ID = "1";
                tieuChiQuanSatPhuHop.SoLuong = yesItem.Count;
                tieuChiQuanSatPhuHop.TieuChi = yesItem.Question;
                ds.TieuChiQuanSatPhuHop.AddTieuChiQuanSatPhuHopRow(tieuChiQuanSatPhuHop);
            }

            foreach (var noRouteItem in lstNoRoute)
            {
                dsSurveyAT.TieuChiQuanSatKoPhuHopTheoChangRow tieuChiQuanSatKoPhuHop = ds.TieuChiQuanSatKoPhuHopTheoChang.NewTieuChiQuanSatKoPhuHopTheoChangRow();
                tieuChiQuanSatKoPhuHop.ID = "1";
                tieuChiQuanSatKoPhuHop.SoLuong = noRouteItem.Count;
                tieuChiQuanSatKoPhuHop.TieuChi = noRouteItem.Question;
                tieuChiQuanSatKoPhuHop.Route = noRouteItem.Routing;
                ds.TieuChiQuanSatKoPhuHopTheoChang.AddTieuChiQuanSatKoPhuHopTheoChangRow(tieuChiQuanSatKoPhuHop);
            }

            foreach (var yesRouteItem in lstYesRoute)
            {
                dsSurveyAT.TieuChiQuanSatPhuHopTheoChangRow tieuChiQuanSatPhuHop = ds.TieuChiQuanSatPhuHopTheoChang.NewTieuChiQuanSatPhuHopTheoChangRow();
                tieuChiQuanSatPhuHop.ID = "1";
                tieuChiQuanSatPhuHop.SoLuong = yesRouteItem.Count;
                tieuChiQuanSatPhuHop.TieuChi = yesRouteItem.Question;
                tieuChiQuanSatPhuHop.Route = yesRouteItem.Routing;
                ds.TieuChiQuanSatPhuHopTheoChang.AddTieuChiQuanSatPhuHopTheoChangRow(tieuChiQuanSatPhuHop);
            }

            //var lstNo = lstSurveyItem.Where(i => i.Input == true && i.Score == "No").OrderBy(i => i.SN).GroupBy(i => i.Question)
            //.Select(i => new
            //{
            //    Question = i.Key,
            //    Count = i.Distinct().Count()
            //}).ToList();
            //int soLanQSKoHopTC = lstKoPhuHop.Sum(i => i.Count);            


            //var lstPhuHop = lstSurveyItem.Where(i => i.Input == true && i.Score == "Yes").OrderBy(i => i.SN).GroupBy(i => i.Question)
            //.Select(i => new
            //{
            //    Question = i.Key,
            //    Count = i.Distinct().Count()
            //}).ToList();
            //int soLanQSHopTC = lstPhuHop.Sum(i => i.Count);

            SplashScreenManager.CloseForm(false);
            rpSurveyAT xrpt = new rpSurveyAT();
            xrpt.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }            
        }
    }
}