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
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;
using ERMs.Data;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightSync : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        BindingSource bind = new BindingSource();
        List<Sys_Flight_Sync> lstFlightSync = new List<Sys_Flight_Sync>();
        public FrmFlightSync()
        {
            InitializeComponent();
        }

        private void FrmFlightSync_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width * 2 / 5;
            InitView();
            RefreshDataFlight();
            RefreshDataPending();
            RefreshDataHistory();
            tabPane1.SelectedPageIndex = 0;
        }

        private void InitView()
        {
            gv.Columns.Clear();
            GridColumn col = null;
            col = new GridColumn() { Caption = "ID", FieldName = "FlightID", Visible = true }; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Aircraft", FieldName = "Aircraft", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Fromdate", FieldName = "Date", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);

            gridView2.Columns.Clear();
            col = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; gridView2.Columns.Add(col);
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit editor = (DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)gc.RepositoryItems.Add("TextEdit");
            editor.CharacterCasing = CharacterCasing.Upper;
            col.ColumnEdit = editor;

            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; gridView2.Columns.Add(col);
            editor = (DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)gc.RepositoryItems.Add("TextEdit");
            editor.CharacterCasing = CharacterCasing.Upper;
            col.ColumnEdit = editor;

            col = new GridColumn() { Caption = "Fromdate", FieldName = "Fromdate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Todate", FieldName = "Todate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Creator", FieldName = "Creator", Visible = true, }; col.OptionsColumn.ReadOnly = true; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Created", FieldName = "Created", Visible = true }; col.OptionsColumn.ReadOnly = true; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView2.Columns.Add(col);

            gridView5.Columns.Clear();
            col = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Fromdate", FieldName = "Fromdate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Todate", FieldName = "Todate", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yyyy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Creator", FieldName = "Creator", Visible = true, }; col.OptionsColumn.ReadOnly = true; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Created", FieldName = "Created", Visible = true }; col.OptionsColumn.ReadOnly = true; col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "StartTime", FieldName = "StartTime", Visible = true, }; col.DisplayFormat.FormatString = "HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gridView5.Columns.Add(col);
            col = new GridColumn() { Caption = "Finish", FieldName = "LoadTime", Visible = true, }; col.DisplayFormat.FormatString = "HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gridView5.Columns.Add(col);            
        }

        private void RefreshDataFlight()
        {            
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string key = null;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                key = txtSearch.Text.Trim();
            
            gc.DataSource = db.GetFlights(fromdate, todate, key);
            gv.BestFitColumns();            
        }

        private void RefreshDataPending()
        {            
            lstFlightSync = db.GetFlightSync(null, null, false);
            //if (lstFlightSync != null && lstFlightSync.Count > 0)
            //{
            //    lstFlightSync = lstFlightSync.OrderByDescending(i => i.Created).ToList();
            //}
            bind.DataSource = lstFlightSync;
            gridControl1.DataSource = bind;
            gridView2.BestFitColumns();
        }

        private void RefreshDataHistory()
        {
            DateTime fromdate, todate;
            fromdate = txtFromDateHistory.DateTime = txtFromDateHistory.EditValue == null ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) : txtFromDateHistory.DateTime;
            todate = txtToDateHistory.DateTime = txtToDateHistory.EditValue == null ? DateTime.Today : txtToDateHistory.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            
            gridControl2.DataSource = db.GetFlightSync(fromdate, todate, true);
            gridView5.BestFitColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshDataFlight();
            SplashScreenManager.CloseForm(false);
        }

        private void btnFoward_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            List<Sys_Flight_Sync> lstAddedFlightSync = new List<Sys_Flight_Sync>();
            
            foreach (int rowHandle in gv.GetSelectedRows())
            {
                CR_FlightInfo flightInfo = (CR_FlightInfo)gv.GetRow(rowHandle);
                if (lstFlightSync.Where(i => i.FlightNo == flightInfo.FlightNo &&
                                             i.Routing == flightInfo.Routing &&
                                             i.Fromdate == flightInfo.Date).FirstOrDefault() == null)
                {
                    Sys_Flight_Sync flightSync = new Sys_Flight_Sync();
                    flightSync.FlightNo = flightInfo.FlightNo;
                    flightSync.Routing = flightInfo.Routing;
                    flightSync.Fromdate = flightInfo.Date;
                    flightSync.Todate = flightInfo.Date;
                    flightSync.Created = DateTime.Now;
                    flightSync.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    flightSync.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    lstAddedFlightSync.Add(flightSync);
                }
            }
            db.AddFlightSync(lstAddedFlightSync);
            lstFlightSync.Clear();
            lstFlightSync.AddRange(db.GetFlightSync(null, null, false));
            gridControl1.RefreshDataSource();
            SplashScreenManager.CloseForm(false);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            List<Sys_Flight_Sync> lstRemovedFlightSync = new List<Sys_Flight_Sync>();

            foreach (int rowHandle in gridView2.GetSelectedRows())
            {                
                lstRemovedFlightSync.Add((Sys_Flight_Sync)gridView2.GetRow(rowHandle));                
            }
            db.RemoveFlightSync(lstRemovedFlightSync);
            lstFlightSync.Clear();
            lstFlightSync.AddRange(db.GetFlightSync(null, null, false));
            gridControl1.RefreshDataSource();
            SplashScreenManager.CloseForm(false);
        }

        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (!gridView2.IsNewItemRow(gridView2.FocusedRowHandle))
                e.Cancel = true;
        }

        private void gridView2_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Sys_Flight_Sync item = (Sys_Flight_Sync)e.Row;
            try
            {
                item.Created = DateTime.Now;
                item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                db.AddFlightSync(item);                                
                lstFlightSync.Clear();
                lstFlightSync.AddRange(db.GetFlightSync(null, null, false));
                gridControl1.RefreshDataSource();
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Sys_Flight_Sync item = (Sys_Flight_Sync)e.Row;

            if (item.Fromdate == null)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Fromdate"], "Fromdate không được để trống.");
            }
            if (item.Todate == null)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Todate"], "Todate không được để trống.");
            }
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshDataHistory();
            SplashScreenManager.CloseForm(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshDataPending();
            SplashScreenManager.CloseForm(false);
        }
    }
}