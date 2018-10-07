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
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using CrewInfo.ADONet;
using System.Reflection;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Forms.Ojt
{
    public partial class FrmOJT : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        OJTDal db = new OJTDal();
        //BindingSource bind = new BindingSource();
        //BindingSource bindLesson = new BindingSource();
        //BindingSource bindLessonItem = new BindingSource();
        //GridColumn colName, colNameLesson, colCodeLesson, colOder, colQuestionLessonItem;
        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsBehavior.ReadOnly = true;
            gv1.OptionsBehavior.ReadOnly = true;
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv1.OptionsView.EnableAppearanceEvenRow = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV HD";            
            col.FieldName = "ExaminerID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên HD";            
            col.FieldName = "ExaminerName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MSNV HV";
            col.FieldName = "ExamineeID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên HV";
            col.FieldName = "ExamineeName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày";
            col.FieldName = "Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Bài";
            col.FieldName = "CR_OJT_Lesson";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Loại";
            col.FieldName = "CR_OJT_Category";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tổng điểm";
            col.FieldName = "TotalScore";
            col.OptionsColumn.ReadOnly = true;
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nhận xét";
            col.FieldName = "Comment";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 200;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đề nghị";
            col.FieldName = "Suggestion";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 200;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Thời gian ký";
            col.OptionsColumn.ReadOnly = true;
            col.FieldName = "Signed";
            col.Visible = true;
            gv.Columns.Add(col);



            col = new GridColumn();
            col.Caption = "Thông tin CB";
            col.FieldName = "FltInfo";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 200;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";            
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tiêu chí";
            col.FieldName = "Question";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Trọng lượng";
            col.FieldName = "Factor";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Điểm";
            col.FieldName = "Score";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Giá trị quy đổi";
            col.FieldName = "ScoreValue";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nhận xét";
            col.FieldName = "Remark";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đề nghị";
            col.FieldName = "Comment";
            col.OptionsColumn.ReadOnly = true;
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 300;
            col.Visible = true;
            gv1.Columns.Add(col);
        }
        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-7) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string key = null;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                key = txtSearch.Text.Trim();
            //bind.DataSource = db.GetListOJTCategory();
            gc.DataSource = db.GetListOJT(fromdate, todate, key);
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName == "FltInfo" ||
                    column.FieldName == "Comment" ||
                    column.FieldName == "Suggestion")
                    continue;
                column.BestFit();
            }
            //gv.BestFitColumns();
        }
        #endregion
        public FrmOJT()
        {
            InitializeComponent();
        }

        private void FrmOJT_Load(object sender, EventArgs e)
        {
            //USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.O.C.01");
            //if (crud != null && crud.U.HasValue && crud.U.Value)
            //{
            //    gv.OptionsBehavior.Editable = true;
            //    gv1.OptionsBehavior.Editable = true;
            //    gv2.OptionsBehavior.Editable = true;
            //}
            //panelNav.Visible = false;
            InitView();
            RefreshData();
        }

        private void gv_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridvew = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            OJTModel item = (OJTModel)gridvew.GetRow(e.RowHandle);
            if (item == null) return;
            item.Items = db.GetOJTItemByOJTID(item.ID);
            
        }

        private void gv_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            foreach (GridColumn column in detailView.Columns)
            {
                if (column.FieldName == "Comment")
                    continue;
                column.BestFit();
            }
            //detailView.BestFitColumns();
        }

        private void gv1_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gv.GetSelectedRows().Length > 0)
            {
                dsOJT ds = new dsOJT();
                int rowHandle = gv.GetSelectedRows()[0];
                OJTModel ojtModel = (OJTModel)gv.GetRow(rowHandle);
                ojtModel.Items = db.GetOJTItemByOJTID(ojtModel.ID);

                CR_FlightInfo flightInfo = null;
                CR_Flight_Crew examnerCrew = null;
                CR_Flight_Crew examneeCrew = null;
                if (ojtModel.FlightID != null)
                {
                    flightInfo = db.getFlightInfoByFlightID(ojtModel.FlightID);
                    examnerCrew = db.GetCrew(ojtModel.ExaminerID, ojtModel.FlightID);
                    examneeCrew = db.GetCrew(ojtModel.ExamineeID, ojtModel.FlightID);
                }
                if (flightInfo != null)
                    addFlightInfo(ds, flightInfo);
                if (examnerCrew != null)
                    addExamnerCrew(ds, examnerCrew);
                if (examneeCrew != null)
                    addExamneeCrew(ds, examneeCrew);
                addOJT(ds, ojtModel);
                addOJTItem(ds, ojtModel.Items);

                Sys_Account examner = db.GetExamner(ojtModel.ExaminerID);
                Sys_Account examnee = db.GetExamnee(ojtModel.ExamineeID);                
                addExamner(ds, examner);
                addExamnee(ds, examnee);
                


                RpOJT xrpt = new RpOJT();
                xrpt.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }            
        }

        private void addFlightInfo(dsOJT ds, CR_FlightInfo flightInfo)
        {
            try
            {
                dsOJT.CR_FlightInfoRow returnValue = ds.CR_FlightInfo.NewCR_FlightInfoRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = flightInfo.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(flightInfo, null), null);
                }
                ds.CR_FlightInfo.AddCR_FlightInfoRow(returnValue);
            }
            catch { }
        }

        private void addExamnerCrew(dsOJT ds, CR_Flight_Crew examnerCrew)
        {
            try
            {
                dsOJT.CR_Flight_CrewRow returnValue = ds.CR_Flight_Crew.NewCR_Flight_CrewRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = examnerCrew.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(examnerCrew, null), null);
                }
                ds.CR_Flight_Crew.AddCR_Flight_CrewRow(returnValue);
            }
            catch { }
        }

        private void addExamneeCrew(dsOJT ds, CR_Flight_Crew examneeCrew)
        {
            try
            {
                dsOJT.CR_Flight_Crew1Row returnValue = ds.CR_Flight_Crew1.NewCR_Flight_Crew1Row();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = examneeCrew.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(examneeCrew, null), null);
                }
                ds.CR_Flight_Crew1.AddCR_Flight_Crew1Row(returnValue);
            }
            catch { }
        }

        private void addOJT(dsOJT ds, OJTModel surveyModel)
        {
            dsOJT.CR_OJTRow returnValue = ds.CR_OJT.NewCR_OJTRow();            
            PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo destPi in destProperties)
            {
                PropertyInfo sourcePi = surveyModel.GetType().GetProperty(destPi.Name);
                if (sourcePi == null)
                    continue;
                destPi.SetValue(returnValue, sourcePi.GetValue(surveyModel, null), null);
            }
            ds.CR_OJT.AddCR_OJTRow(returnValue);
        }

        private void addOJTItem(dsOJT ds, List<CR_OJT_Item> lstItem)
        {
            foreach (var item in lstItem)
            {
                dsOJT.CR_OJT_ItemRow returnValue = ds.CR_OJT_Item.NewCR_OJT_ItemRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = item.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(item, null), null);
                }
                ds.CR_OJT_Item.AddCR_OJT_ItemRow(returnValue);
            }
        }

        private void addExamner(dsOJT ds, Sys_Account flightInfo)
        {
            try
            {
                dsOJT.Sys_AccountRow returnValue = ds.Sys_Account.NewSys_AccountRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = flightInfo.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(flightInfo, null), null);
                }
                ds.Sys_Account.AddSys_AccountRow(returnValue);
            }
            catch { }
        }

        private void addExamnee(dsOJT ds, Sys_Account flightInfo)
        {
            try
            {
                dsOJT.Sys_Account1Row returnValue = ds.Sys_Account1.NewSys_Account1Row();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = flightInfo.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(flightInfo, null), null);
                }
                ds.Sys_Account1.AddSys_Account1Row(returnValue);
            }
            catch { }
        }
    }
}