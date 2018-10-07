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
using DevExpress.XtraGrid.Views.BandedGrid;
using ERMs.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightNetLine : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        BindingSource bindNetLine = new BindingSource();
        BindingSource bindDTV = new BindingSource();
        List<USP_GetFlight_NetLine_Result> lstFlight = new List<USP_GetFlight_NetLine_Result>();        
        List<USP_GetFlight_NetLine_Result> lstNetLineFlightRefNull = new List<USP_GetFlight_NetLine_Result>();
        List<USP_GetFlight_NetLine_Result> lstDTVFlightRefNull = new List<USP_GetFlight_NetLine_Result>();
        FlightNetLineDal db = new FlightNetLineDal();
        bool firstLoad = true;
        public FrmFlightNetLine()
        {
            InitializeComponent();
        }

        private void FrmFlightNetLine_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width * 1 / 2;
            bind.DataSource = lstFlight;
            gc.DataSource = bind;            
            bindNetLine.DataSource = lstNetLineFlightRefNull;
            gc2.DataSource = bindNetLine;
            bindDTV.DataSource = lstDTVFlightRefNull;
            gc1.DataSource = bindDTV;

            InitView();
            RefreshData();
        }

        private void InitView()
        {
            bgv.Bands.Clear();
            bgv.Columns.Clear();
            GridBand gridband = null;
            BandedGridColumn bandedCol = null;

            gridband = new GridBand() { Caption = "DTV Flights", VisibleIndex = 0 }; bgv.Bands.Add(gridband);
            bandedCol = new BandedGridColumn() { Caption = "FlightID", FieldName = "FlightID", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bandedCol.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; bandedCol.SummaryItem.DisplayFormat = "{0:n0}"; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "Date", FieldName = "Date", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "dd/MM/yy"; bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "Departed", FieldName = "Departed", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "HH:mm"; bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "Arrived", FieldName = "Arrived", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "HH:mm"; bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);


            gridband = new GridBand() { Caption = "NetLine Flights", VisibleIndex = 1 }; bgv.Bands.Add(gridband);
            bandedCol = new BandedGridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "UTCDate", FieldName = "UTCDate", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "dd/MM/yy"; 
            bandedCol = new BandedGridColumn() { Caption = "FLT_NO", FieldName = "FLT_NO", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "FNRouting", FieldName = "FNRouting", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "UTCDepart", FieldName = "UTCDepart", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "HH:mm"; 
            bandedCol = new BandedGridColumn() { Caption = "UTCArrive", FieldName = "UTCArrive", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol); bandedCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; bandedCol.DisplayFormat.FormatString = "HH:mm"; 
            bandedCol = new BandedGridColumn() { Caption = "Status", FieldName = "STATUS", Visible = true }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);
            bandedCol = new BandedGridColumn() { Caption = "Auto", FieldName = "Auto", Visible = false }; gridband.Columns.Add(bandedCol); bandedCol.OptionsColumn.ReadOnly = true; bgv.Columns.Add(bandedCol);

            StyleFormatCondition styleManual = new StyleFormatCondition();
            styleManual = new StyleFormatCondition(FormatConditionEnum.Equal, gv2.Columns["Auto"], null, false, null);
            styleManual.Appearance.BackColor = Color.LightYellow;
            styleManual.Appearance.BackColor2 = Color.LightYellow;
            styleManual.ApplyToRow = true;
            bgv.FormatConditions.Add(styleManual);

            GridColumn col = null;
            gv1.Columns.Clear();
            col = new GridColumn() { Caption = "FlightID", FieldName = "FlightID", Visible = true }; gv1.Columns.Add(col); col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; 
            col = new GridColumn() { Caption = "Date", FieldName = "Date", Visible = true }; gv1.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "dd/MM/yy"; col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "FlightNo", FieldName = "FlightNo", Visible = true }; gv1.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "Routing", FieldName = "Routing", Visible = true }; gv1.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "Departed", FieldName = "Departed", Visible = true }; gv1.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "HH:mm"; col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "Arrived", FieldName = "Arrived", Visible = true }; gv1.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "HH:mm"; col.OptionsColumn.ReadOnly = true;

            gv2.Columns.Clear();
            col = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; 
            col = new GridColumn() { Caption = "UTCDate", FieldName = "UTCDate", Visible = true }; gv2.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "dd/MM/yy"; col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "FLT_NO", FieldName = "FLT_NO", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "FNRouting", FieldName = "FNRouting", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "UTCDepart", FieldName = "UTCDepart", Visible = true }; gv2.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "HH:mm"; col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "UTCArrive", FieldName = "UTCArrive", Visible = true }; gv2.Columns.Add(col); col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.DisplayFormat.FormatString = "HH:mm"; col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "Status", FieldName = "STATUS", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "FlightID", FieldName = "FlightID", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            col = new GridColumn() { Caption = "Sync", Visible = true }; gv2.Columns.Add(col); col.OptionsColumn.ReadOnly = true;
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.T.07");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                col.ColumnEdit = riSync;
            }            

            StyleFormatCondition styleQly = new StyleFormatCondition();
            styleQly = new StyleFormatCondition(FormatConditionEnum.Equal, gv2.Columns["STATUS"], null, FlightNetLineStatus.CANCEL, null);
            styleQly.Appearance.BackColor = Color.LightGray;
            styleQly.Appearance.BackColor2 = Color.LightGray;
            styleQly.ApplyToRow = true;
            gv2.FormatConditions.Add(styleQly);

            StyleFormatCondition styleDaSync = new StyleFormatCondition();
            styleDaSync = new StyleFormatCondition(FormatConditionEnum.NotEqual, gv2.Columns["FlightID"], null, null, null);
            styleDaSync.Appearance.BackColor = Color.LightYellow;
            styleDaSync.Appearance.BackColor2 = Color.LightYellow;
            styleDaSync.ApplyToRow = true;
            gv2.FormatConditions.Add(styleDaSync);

            //StyleFormatCondition styleCancelFlight = new StyleFormatCondition();
            ////styleCancelFlight.Column = clisCorrect;
            //styleCancelFlight.Condition = FormatConditionEnum.Expression;
            //styleCancelFlight.Expression = "[STATUS] != " + FlightNetLineStatus.CANCEL;
            //styleCancelFlight.Appearance.BackColor = Color.Black;
            //styleCancelFlight.Appearance.BackColor2 = Color.White;
            //styleCancelFlight.Appearance.Options.UseBackColor = true;
            //styleCancelFlight.ApplyToRow = true;
            //gv2.FormatConditions.Add(styleCancelFlight);
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            lstFlight.Clear();
            lstFlight.AddRange(db.GetFlightNetLine(fromdate, todate, ""));
            gc.RefreshDataSource();
            bgv.BestFitColumns();

            //lstNetLineFlight.Clear();
            //lstNetLineFlight.AddRange(db.GetNetLineFlight(fromdate, todate, ""));

            lstNetLineFlightRefNull.Clear();
            //lstNetLineFlightRefNull.AddRange(lstFlight.Where(i => i.FlightID == null && i.ID != null && i.STATUS != FlightNetLineStatus.CANCEL).ToList());
            lstNetLineFlightRefNull.AddRange(lstFlight.Where(i => i.FlightID == null && i.ID != null).OrderBy(i => i.STATUS == FlightNetLineStatus.CANCEL ? 1 : 0).ToList());
            gc2.RefreshDataSource();
            gv2.BestFitColumns();
            //var lstNetLineFlightRef = lstNetLineFlight.Where(i => i.Refflightid != null).ToList();

            lstDTVFlightRefNull.Clear();
            lstDTVFlightRefNull.AddRange(lstFlight.Where(i => i.FlightID != null && i.ID == null).ToList());
            gc1.RefreshDataSource();
            gv1.BestFitColumns();
        }

        private void gv2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "Sync")
            {
                DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
        }

        private void riSync_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            alertControl1.Show(this.FindForm(), "Successful", "Thành công2");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
            //DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            //alertControl1.Show(this.FindForm(), "Successful", "Thành công2");
        }

        private void gv2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            alertControl1.Show(this.FindForm(), "Successful", "Thành công4");
        }

        private void riSync_Click(object sender, EventArgs e)
        {
            USP_GetFlight_NetLine_Result rowFlightInfo = null;
            USP_GetFlight_NetLine_Result rowFlightInfoNetLine = null;
            try
            {
                rowFlightInfo = gv1.GetFocusedRow() as USP_GetFlight_NetLine_Result;
                rowFlightInfoNetLine = gv2.GetFocusedRow() as USP_GetFlight_NetLine_Result;
            }
            catch { }
            if (rowFlightInfo != null && rowFlightInfoNetLine != null)
            {
                bool result = db.SetFlightReference(rowFlightInfo, rowFlightInfoNetLine);
                //bool result = true;
                if (result)
                {
                    DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                    lstDTVFlightRefNull.Remove(rowFlightInfo);
                    lstNetLineFlightRefNull.Remove(rowFlightInfoNetLine);
                    gc1.RefreshDataSource();
                    gc2.RefreshDataSource();

                    lstFlight.Remove(lstFlight.Where(i => i.FlightID == rowFlightInfo.FlightID).FirstOrDefault());
                    lstFlight.Remove(lstFlight.Where(i => i.ID == rowFlightInfoNetLine.ID).FirstOrDefault());

                    USP_GetFlight_NetLine_Result newSyncFlight = new USP_GetFlight_NetLine_Result();
                    newSyncFlight.FlightID = rowFlightInfo.FlightID;
                    newSyncFlight.Date = rowFlightInfo.Date;
                    newSyncFlight.Routing = rowFlightInfo.Routing;
                    newSyncFlight.FlightNo = rowFlightInfo.FlightNo;
                    newSyncFlight.Departed = rowFlightInfo.Departed;
                    newSyncFlight.Arrived = rowFlightInfo.Arrived;
                    newSyncFlight.ID = rowFlightInfoNetLine.ID;
                    newSyncFlight.UTCDate = rowFlightInfoNetLine.UTCDate;
                    newSyncFlight.FNRouting = rowFlightInfoNetLine.FNRouting;
                    newSyncFlight.FLT_NO = rowFlightInfoNetLine.FLT_NO;
                    newSyncFlight.UTCDepart = rowFlightInfoNetLine.UTCDepart;
                    newSyncFlight.UTCArrive = rowFlightInfoNetLine.UTCArrive;
                    newSyncFlight.STATUS = rowFlightInfoNetLine.STATUS;
                    newSyncFlight.Auto = false;
                    lstFlight.Insert(0, newSyncFlight);
                    gc.RefreshDataSource();
                }
            }
        }

        private void gv1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (firstLoad)
            //    firstLoad = false;
            //else
            //{

            //}
            if (!cbxShowAll.Checked)
            {
                GridView view = sender as GridView;
                USP_GetFlight_NetLine_Result dtv = (USP_GetFlight_NetLine_Result)view.GetRow(e.FocusedRowHandle);
                try
                {
                    lstNetLineFlightRefNull.Clear();
                    lstNetLineFlightRefNull.AddRange(lstFlight.Where(nl =>  nl.ID != null &&
                                                                            nl.FNRouting == dtv.Routing &&
                                                                            dtv.FlightNo.Contains(nl.FLT_NO) &&
                                                                            dtv.Date.Value.Date >= nl.UTCDepart.Value.AddDays(-2).Date &&
                                                                            dtv.Date.Value.Date <= nl.UTCDepart.Value.AddDays(2).Date).OrderBy(i => i.FlightID).ToList());
                    gc2.RefreshDataSource();
                }
                catch { }
            }
        }

        private void cbxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowAll.Checked)
            {
                lstNetLineFlightRefNull.Clear();
                //lstNetLineFlightRefNull.AddRange(lstFlight.Where(i => i.FlightID == null && i.ID != null && i.STATUS != FlightNetLineStatus.CANCEL).ToList());
                lstNetLineFlightRefNull.AddRange(lstFlight.Where(i => i.FlightID == null && i.ID != null).OrderBy(i => i.STATUS == FlightNetLineStatus.CANCEL ? 1 : 0).ToList());
                gc2.RefreshDataSource();
                gv2.BestFitColumns();
            }
            else
            {
                USP_GetFlight_NetLine_Result dtv = (USP_GetFlight_NetLine_Result)gv1.GetFocusedRow();
                try
                {
                    lstNetLineFlightRefNull.Clear();
                    lstNetLineFlightRefNull.AddRange(lstFlight.Where(nl => 
                                                                            nl.ID != null &&
                                                                            nl.FNRouting == dtv.Routing &&
                                                                            dtv.FlightNo.Contains(nl.FLT_NO) &&
                                                                            dtv.Date.Value.Date >= nl.UTCDepart.Value.AddDays(-2).Date &&
                                                                            dtv.Date.Value.Date <= nl.UTCDepart.Value.AddDays(2).Date).OrderBy(i => i.FlightID).ToList());
                    gc2.RefreshDataSource();
                }
                catch { }
            }
        }
    }

    public class FlightNetLineStatus
    {
        public const string CANCEL = "CNL";
    }
}