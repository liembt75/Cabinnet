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
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Export;
using DevExpress.XtraEditors.Repository;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmDutyFree : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        FlightDal db = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        //List<FlightInfoModel> lstFlight = new List<FlightInfoModel>();
        List<FlightDutyModel> lstFlightDutyFree = new List<FlightDutyModel>();

        public FrmDutyFree()
        {
            InitializeComponent();
        }

        private void FrmDutyFree_Load(object sender, EventArgs e)
        {
            gv.OptionsBehavior.ReadOnly = true;
            gv1.OptionsBehavior.ReadOnly = true;
            btnExcelDanhThu.Visible = false;
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.T.06");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv1.OptionsBehavior.ReadOnly = false;
                btnExcelDanhThu.Visible = true;
            }
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            gv.Columns.Clear();
            GridColumn col = null;
            //col = new GridColumn() { Caption = "Task", FieldName = "Task", Visible = true }; col.Fixed = FixedStyle.Left; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            //DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbxTask = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            //cbxTask.SmallImages = imgStatus;
            //cbxTask.Items.Add(new ImageComboBoxItem("Coming", 0, 0));
            //cbxTask.Items.Add(new ImageComboBoxItem("Done", 1, 2));
            //cbxTask.Items.Add(new ImageComboBoxItem("Pending", 2, 1));
            //col.ColumnEdit = cbxTask;

            col = new GridColumn() { Caption = "ID", FieldName = "FlightID", Visible = true }; col.Fixed = FixedStyle.Left; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Chuyến bay", FieldName = "FlightNo", Visible = true }; col.Fixed = FixedStyle.Left; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ngày", FieldName = "Date", Visible = true }; col.Fixed = FixedStyle.Left; col.DisplayFormat.FormatString = "dd MMM"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);

            col = new GridColumn() { Caption = "Chặng", FieldName = "Routing", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Máy bay", FieldName = "Aircraft", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Khởi hành", FieldName = "Departed", Visible = true }; col.DisplayFormat.FormatString = "HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Thời gian đến", FieldName = "Arrived", Visible = true }; col.DisplayFormat.FormatString = "HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "C", FieldName = "TotalPaxC", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Y", FieldName = "TotalPaxY", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            //col = new GridColumn() { Caption = "VIP", FieldName = "TotalVIP", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Khả năng", ToolTip="Số TV có khả năng bán hàng miễn thuế", FieldName = "Qly", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Thực tế", ToolTip ="Số TV được phân công nhiệm vụ bán hàng miễn thuế trên chuyến bay", FieldName = "RealQly", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Tiền", FieldName = "Total", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ghi chú", FieldName = "Remark", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);

            StyleFormatCondition styleRealQly = new StyleFormatCondition();
            styleRealQly = new StyleFormatCondition(FormatConditionEnum.GreaterOrEqual, gv.Columns["RealQly"], null, 1);
            //style.Condition = FormatConditionEnum.Expression;
            //style.Expression = "Not IsNullOrEmpty([RealQly]) and [RealQly] > 0";
            styleRealQly.Appearance.BackColor = Color.LightYellow;
            styleRealQly.Appearance.BackColor2 = Color.YellowGreen;
            styleRealQly.ApplyToRow = false;
            gv.FormatConditions.Add(styleRealQly);

            StyleFormatCondition styleQly = new StyleFormatCondition();
            styleQly = new StyleFormatCondition(FormatConditionEnum.Equal, gv.Columns["Qly"], null, 0,null);
            styleQly.Appearance.BackColor = Color.White;
            styleQly.Appearance.BackColor2 = Color.Tomato;
            styleQly.ApplyToRow = false;
            gv.FormatConditions.Add(styleQly);

            StyleFormatCondition styleDuty = new StyleFormatCondition();
            styleDuty = new StyleFormatCondition(FormatConditionEnum.NotEqual, gv.Columns["Total"], null, null, null);
            styleDuty.Appearance.BackColor = Color.LightYellow;
            styleDuty.Appearance.BackColor2 = Color.LightYellow;
            styleDuty.ApplyToRow = true;
            gv.FormatConditions.Add(styleDuty);

            gv1.Columns.Clear();
            col = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "MSNV", FieldName = "CrewID", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "LastName", FieldName = "LastNameVn", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "FirstName", FieldName = "FirstNameVn", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "Group", FieldName = "Group", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "KNB", FieldName = "Ability", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "KH", FieldName = "FO_Job", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "Task", FieldName = "Job", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "DutyFree", FieldName = "DutyFree", Visible = true }; col.OptionsColumn.ReadOnly = false; gv1.Columns.Add(col);            
            RepositoryItemLookUpEdit rpiDutyFree = new RepositoryItemLookUpEdit();
            List<string> lstDutyFree = new List<string>() { "", "D", "S", "DS"};
            rpiDutyFree.DataSource = lstDutyFree;
            col.ColumnEdit = rpiDutyFree;
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-2) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today.AddDays(1) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string crewID = "";
            bool isGetAll = true;
            if (!string.IsNullOrEmpty(txtCrewID.Text))
            {
                isGetAll = false;
                try
                {
                    int iCrewID = int.Parse(txtCrewID.Text);
                    crewID = txtCrewID.Text;
                }
                catch
                {
                    Sys_Account acc = dbSystem.GetSysAccountByName(txtCrewID.Text);
                    if (acc != null)
                        crewID = acc.CrewID;
                }
            }

            //lstFlight = db.GetFlights(fromdate, todate, "", crewID, isGetAll, false, false, 1, 1000000);
            lstFlightDutyFree = db.GetFlightDutyFree(fromdate, todate, null);
            bind.DataSource = lstFlightDutyFree;
            gc.DataSource = bind;
            gv.BestFitColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
        }

        private void gv_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        private void gv_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView view = sender as GridView;
            FlightDutyModel item = (FlightDutyModel)view.GetRow(e.RowHandle);
            if (item == null) return;
            item.Crews = db.GetFlightCrewByFlightIDAdmin(item.FlightID, false);
        }

        private void txtCrewID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "DutyFree.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gv.ExportToXlsx(file.FileName);                
                System.Diagnostics.Process.Start(file.FileName);                
            }
        }

        private void gv1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            API_CR_USP_GetFlightCrewAdmin_Result item = (API_CR_USP_GetFlightCrewAdmin_Result)e.Row;
            try
            {
                API_CR_USP_GetFlightCrewAdmin_Result returnItem = db.UpdateDutyFree(item);                
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");                
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromdate, todate;
                fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-2) : txtFromdate.DateTime;
                todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today.AddDays(1) : txtTodate.DateTime;
                fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
                todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                db.ReloadFlightDutyfree(fromdate, todate);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcelDanhThu_Click(object sender, EventArgs e)
        {
            FrmDutyFreeImport form = new FrmDutyFreeImport();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }
    }
}