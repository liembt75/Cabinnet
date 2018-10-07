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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraScheduler;
using System.IO;
using System.Net;

namespace CrewInfo.Forms.ExternalUnit
{
    public partial class FrmFlight : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        BindingSource bindCrew = new BindingSource();
        BindingSource bindCrewFlight = new BindingSource();
        FlightDal db = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        List<FlightInfoExModel> lstFlight = new List<FlightInfoExModel>();
        List<API_CR_USP_GetFlightCrewAdminExternalUnit_Result> lstCrew = new List<API_CR_USP_GetFlightCrewAdminExternalUnit_Result>();
        List<FlightInfoModel> lstCrewFlight = new List<FlightInfoModel>();
        PictureBox pic = new PictureBox();
        const string IMAGE_PATH = "https://api.crew.vn/profiles/{0}.jpg";        
        bool itemClick = false;
        public FrmFlight()
        {
            InitializeComponent();
        }

        private void FrmFlight_Load(object sender, EventArgs e)
        {            
            schedulerControl1.PopupMenuShowing += SchedulerControl1_PopupMenuShowing;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width * 1 / 2;

            splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl2.SplitterPosition = splitContainerControl1.Height * 1 / 2 - 20;

            gv.OptionsBehavior.ReadOnly = true;
            bind.DataSource = lstFlight;
            gc.DataSource = bind;

            bindCrew.DataSource = lstCrew;
            gcCrew.DataSource = bindCrew;

            bindCrewFlight.DataSource = lstCrewFlight;
            gcCrewHistory.DataSource = bindCrewFlight;

            InitView();
            RefreshData();
        }        

        private void InitView()
        {
            gv.Columns.Clear();
            GridColumn col = null;

            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            //col = new GridColumn() { Caption = "Departed", FieldName = "Departed", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            //col = new GridColumn() { Caption = "Arrived", FieldName = "Arrived", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Date", FieldName = "Date", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Departed", FieldName = "strDeparted", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Arrived", FieldName = "strArrived", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Aircraft", FieldName = "Aircraft", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "EQUIP", FieldName = "Classify", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "C", FieldName = "CkinC", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Y", FieldName = "CkinY", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "VIP", FieldName = "TotalVIP", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);

            gvCrewHistory.Columns.Clear();
            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "Departed", FieldName = "Departed", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "Arrived", FieldName = "Arrived", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy HH:mm"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "Aircraft", FieldName = "Aircraft", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "EQUIP", FieldName = "Classify", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "C", FieldName = "CkinC", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "Y", FieldName = "CkinY", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
            col = new GridColumn() { Caption = "VIP", FieldName = "TotalVIP", Visible = true }; col.OptionsColumn.ReadOnly = true; gvCrewHistory.Columns.Add(col);
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-2) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today.AddDays(1) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);            

            lstFlight.Clear();
            lstFlight.AddRange(db.GetFlightsExternalUnit(fromdate, todate, txtKeyword.Text));
            gc.RefreshDataSource();
            gv.BestFitColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
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

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);            
            GridView view = sender as GridView;
            FlightInfoExModel item = (FlightInfoExModel)view.GetRow(e.FocusedRowHandle);
            lstCrew.Clear();
            lstCrew.AddRange(db.GetFlightCrewByFlightIDAdminExternalUnit(item.FlightID, false));            
            //itemClick = false;            
            gcCrew.RefreshDataSource();
            gvCrew.BestFitColumns();

            //Them lich tiep vien dau tien
            schedulerControl1.Storage.Appointments.Clear();
            try
            {
                API_CR_USP_GetFlightCrewAdminExternalUnit_Result itemCrew = (API_CR_USP_GetFlightCrewAdminExternalUnit_Result)lstCrew[0];
                lstCrewFlight.Clear();
                DateTime fromdate, todate;
                //fromdate = FirstDayOfWeek(DateTime.Today).AddDays(1);
                //todate = fromdate.AddDays(6);
                //fromdate = DateTime.Today.AddDays(-3);
                //todate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                fromdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
                todate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), 23, 59, 59, 59);

                lstCrewFlight.AddRange(db.GetFlightCrewHistory(itemCrew.CrewID, fromdate, todate));
                schedulerControl1.Storage.Appointments.Clear();
                schedulerControl1.Start = FirstDayOfWeek(DateTime.Today).AddDays(1);
                schedulerControl1.LimitInterval.Start = fromdate;
                schedulerControl1.LimitInterval.End = todate;
                foreach (var crewFlight in lstCrewFlight)
                {
                    try
                    {
                        Appointment apt = schedulerControl1.Storage.CreateAppointment(AppointmentType.Normal);
                    apt.Start = crewFlight.Departed.Value;
                    apt.End = crewFlight.Arrived.Value;
                    apt.Subject = crewFlight.FlightNo + " " + crewFlight.Routing;                    
                    schedulerControl1.Storage.Appointments.Add(apt);
                    }
                    catch { }
                }
            }
            catch { }
            SplashScreenManager.CloseForm(false);
        }

        private void tileView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            TileView view = sender as TileView;

            try
            {
                API_CR_USP_GetFlightCrewAdminExternalUnit_Result item = (API_CR_USP_GetFlightCrewAdminExternalUnit_Result)view.GetRow(e.FocusedRowHandle);
                lstCrewFlight.Clear();
                DateTime fromdate, todate;
                //fromdate = FirstDayOfWeek(DateTime.Today).AddDays(1);
                //todate = fromdate.AddDays(6);
                //fromdate = DateTime.Today.AddDays(-3);
                //todate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                fromdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
                todate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), 23, 59, 59, 59);

                lstCrewFlight.AddRange(db.GetFlightCrewHistory(item.CrewID, fromdate, todate));
                schedulerControl1.Storage.Appointments.Clear();
                schedulerControl1.Start = FirstDayOfWeek(DateTime.Today).AddDays(1);
                schedulerControl1.LimitInterval.Start = fromdate;
                schedulerControl1.LimitInterval.End = todate;
                List<Appointment> lstApp = new List<Appointment>();
                foreach (var crewFlight in lstCrewFlight)
                {
                    try
                    {
                        Appointment apt = schedulerControl1.Storage.CreateAppointment(AppointmentType.Normal);
                        apt.Start = crewFlight.Departed.Value;
                        apt.End = crewFlight.Arrived.Value;
                        apt.Subject = crewFlight.FlightNo + " " + crewFlight.Routing;
                        lstApp.Add(apt);
                        //apt.Description = crewFlight.Routing;                                            
                    } catch { }
                }
                schedulerControl1.Storage.Appointments.AddRange(lstApp.ToArray());

                //gcCrewHistory.RefreshDataSource();
                //gvCrewHistory.BestFitColumns();

            }
            catch { }
            SplashScreenManager.CloseForm(false);            
        }

        private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            //if (itemClick == false)
            //{
            //    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //    TileView view = sender as TileView;
            //    itemClick = true;
            //    try
            //    {
            //        API_CR_USP_GetFlightCrewAdminExternalUnit_Result item = (API_CR_USP_GetFlightCrewAdminExternalUnit_Result)view.GetRow(e.Item.RowHandle);
            //        lstCrewFlight.Clear();
            //        DateTime fromdate, todate;
            //        fromdate = FirstDayOfWeek(DateTime.Today).AddDays(1);
            //        todate = fromdate.AddDays(6);
            //        //fromdate = DateTime.Today.AddDays(-3);
            //        //todate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            //        fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            //        todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            //        lstCrewFlight.AddRange(db.GetFlightCrewHistory(item.CrewID, fromdate, todate));
            //        schedulerControl1.Storage.Appointments.Clear();
            //        schedulerControl1.Start = fromdate;
            //        schedulerControl1.LimitInterval.Start = fromdate;
            //        schedulerControl1.LimitInterval.End = todate;
            //        foreach (var crewFlight in lstCrewFlight)
            //        {
            //            Appointment apt = schedulerControl1.Storage.CreateAppointment(AppointmentType.Normal);
            //            apt.Start = crewFlight.Departed.Value;
            //            apt.End = crewFlight.Arrived.Value;
            //            apt.Subject = crewFlight.FlightNo + " " + crewFlight.Routing;
            //            //apt.Description = crewFlight.Routing;                    
            //            schedulerControl1.Storage.Appointments.Add(apt);
            //        }


            //        //gcCrewHistory.RefreshDataSource();
            //        //gvCrewHistory.BestFitColumns();

            //    }
            //    catch { }
            //    SplashScreenManager.CloseForm(false);
            //}
        }

        private void SchedulerControl1_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            //e.Menu.Items.Clear();
        }

        public DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        public DateTime LastDayOfWeek(DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(6);
        }

        private void tileView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Image" && e.IsGetData)
                {
                    GridView view = sender as GridView;
                    API_CR_USP_GetFlightCrewAdminExternalUnit_Result item = (API_CR_USP_GetFlightCrewAdminExternalUnit_Result)e.Row;
                    string pathImage = string.Format(IMAGE_PATH, item.CrewID);
                    //pic.Load(pathImage);                
                    //e.Value = pic.Image;
                    e.Value = getImageFromURL(pathImage);
                }
            } catch { }
        }

        private byte[] getImageFromURL(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(url);
                return data;
                //using (MemoryStream mem = new MemoryStream(data))
                //{
                //    using (var yourImage = Image.FromStream(mem))
                //    {
                //        return yourImage;
                //    }
                //}
            }
        }
    }
}