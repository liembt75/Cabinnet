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
using ERMs.Data.Flight;
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightInfoSpec : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        FlightDal db = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        List<FlightInfoModel> lstFlight = new List<FlightInfoModel>();
        public FrmFlightInfoSpec()
        {
            InitializeComponent();
        }

        private void FrmFlightInfoSpec_Load(object sender, EventArgs e)
        {
            gv.OptionsBehavior.ReadOnly = true;
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.T.05");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;                
            }
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            gv.Columns.Clear();
            GridColumn col = null;
            col = new GridColumn() { Caption = "Task", FieldName = "Task", Visible = true }; col.Fixed = FixedStyle.Left; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cbxTask = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            cbxTask.SmallImages = imgStatus;
            cbxTask.Items.Add(new ImageComboBoxItem("Coming", 0, 0));
            cbxTask.Items.Add(new ImageComboBoxItem("Done", 1, 2));
            cbxTask.Items.Add(new ImageComboBoxItem("Pending", 2, 1));
            col.ColumnEdit = cbxTask;

            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; col.Fixed = FixedStyle.Left; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Date", FieldName = "Date", Visible = true }; col.Fixed = FixedStyle.Left; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);

            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Aircraft", FieldName = "Aircraft", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Departed", FieldName = "Departed", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Arrived", FieldName = "Arrived", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "C", FieldName = "TotalPaxC", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Y", FieldName = "TotalPaxY", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "VIP", FieldName = "TotalVIP", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "SpecialInfo", FieldName = "SpecialInfo", Visible = true }; col.Width = 200; col.Fixed = FixedStyle.Right; gv.Columns.Add(col);

            StyleFormatCondition style = new StyleFormatCondition();
            //stylePhongBanChuaTraLoi.Column = gridColumn14;
            style.Condition = FormatConditionEnum.Expression;
            style.Expression = "Not IsNullOrEmpty([SpecialInfo])";
            style.Appearance.BackColor = Color.Red;
            style.Appearance.BackColor2 = Color.White;
            style.Appearance.Options.UseBackColor = true;
            style.ApplyToRow = true;
            gv.FormatConditions.Add(style);

            gv1.Columns.Clear();
            col = new GridColumn() { Caption = "MSNV", FieldName = "CrewID", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "LastName", FieldName = "LastNameVn", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "FirstName", FieldName = "FirstNameVn", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "Group", FieldName = "Group", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "KNB", FieldName = "Ability", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "KH", FieldName = "FO_Job", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
            col = new GridColumn() { Caption = "Task", FieldName = "Job", Visible = true }; col.OptionsColumn.ReadOnly = true; gv1.Columns.Add(col);
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

            lstFlight = db.GetFlights(fromdate, todate, "", crewID, isGetAll, false, false, 1, 1000000);
            bind.DataSource = lstFlight;
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

        private void gv_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView view = sender as GridView;
            FlightInfoModel item = (FlightInfoModel)view.GetRow(e.RowHandle);
            if (item == null) return;            
            item.Crews = db.GetFlightCrewByFlightIDAdmin(item.FlightID, false);            
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            FlightInfoModel item = (FlightInfoModel)e.Row;
            try
            {                
                db.UpdateFlightInfoNote(item);                
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
    }
}