using DevExpress.Export;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ERMs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFONetline : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bindNL = new BindingSource();
        BindingSource bindFO = new BindingSource();

        //Tui
        List<USP_GetFlights_NL_FO_byKeyword_Result> nlFlights = new List<USP_GetFlights_NL_FO_byKeyword_Result>();
        FlightNetLineDal db = new FlightNetLineDal();

        #region init
        public FrmFlightFONetline():base()
        {
            InitializeComponent();
            GenerateView();
        }
        public override void HideNav()
        {
            panelNav.Hide();
        }

        public override void ShowNav()
        {
            panelNav.Show();

        }
        #endregion

        GridColumn colFoid, colFoFlightNo, colFoDate, colFoRoute, colFoDepart, colFoArrive, colFoAircraft, colFoStatus, colFoCarry, colFoModifier, colFo_NLFLtNo, colFo_NLRoute, colFo_NLUTCDepart, colFoCancel;            

        private void btnEdit_Click(object sender, EventArgs e)
        {
            colFoCancel.Visible = true;
            colOCCid.Visible = true;
        }

        GridColumn colOCCid, colOCCFlightNo, colOCCDate, colOCCRoute, colOCCDepart, colOCCArrive, colOCCAircraft, colOCCStatus, colOCCCarry, colOCCFltNoNL, colOCC_NL_UTCDepart, colOCC_NLModifier;
       private void GenerateView()
        {
            this.Text = "FO ↔️ OCC";

            colFoid = new GridColumn() { Caption = "ID", FieldName = "FoFlightID", Visible = true, Width = 50, ToolTip = "" };
            colFoFlightNo = new GridColumn() { Caption = "FLT", FieldName = "FoFlightNo", Visible = true, Width = 60, ToolTip = "" };
            colFoDate = new GridColumn() { Caption = "Date", FieldName = "FoDate", Visible = true, Width = 70, ToolTip = "" };
            colFoRoute = new GridColumn() { Caption = "Route", FieldName = "FoRouting", Visible = true, Width = 70, ToolTip = "" };
            colFoDepart = new GridColumn() { Caption = "Depart", FieldName = "FoDepart", Visible = true, Width = 50, ToolTip = "" };
            colFoArrive = new GridColumn() { Caption = "Arrive", FieldName = "FoArrive", Visible = true, Width = 50, ToolTip = "" };
            colFoAircraft = new GridColumn() { Caption = "AC", FieldName = "FoAircraft", Visible = true, Width = 50, ToolTip = "" };
            colFoCarry = new GridColumn() { Caption = "C", FieldName = "FoCarry", Visible = true, Width = 50, ToolTip = "Carry" };
            colFoStatus = new GridColumn() { Caption = "CNL", FieldName = "FoStatus", Visible = true, Width = 40, ToolTip = "" };
            colFo_NLFLtNo = new GridColumn() { Caption = "OCC-FLT", FieldName = "NlFlightNo", Visible = true, Width = 50, ToolTip = "" };
            colFo_NLRoute = new GridColumn() { Caption = "Sector", FieldName = "NlRouting", Visible = true, Width = 70, ToolTip = "Actual route from Netline" };
            colFo_NLUTCDepart = new GridColumn() { Caption = "UTC depart", FieldName = "NlUTCDepart", Visible = true, Width = 100, ToolTip = "" };
            colFoCancel = new GridColumn() { Caption = "#", FieldName = "FoFlightID", Visible = true, Width = 30, ToolTip = "" };


            //Button
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riFLTCancel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            riFLTCancel.AutoHeight = false;
            riFLTCancel.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            riFLTCancel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            riFLTCancel.ButtonClick += riFLTCancel_ButtonClick;
            colFoCancel.ColumnEdit = riFLTCancel;

            ////Button
            //DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riSelected = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //riSelected.AutoHeight = false;
            //riSelected.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK;
            //riSelected.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            ////riSelected.ButtonClick += riSelected_ButtonClick;
            //colFOid.ColumnEdit = riSelected;

            colFoFlightNo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colFoFlightNo.SummaryItem.DisplayFormat = "{0:#,#}";
            gvFO.Columns.Clear();
            gvFO.Columns.AddRange(new GridColumn[] { colFoid, colFoFlightNo,  colFoRoute, colFoDate, colFoDepart, colFoArrive, colFoAircraft, colFoStatus, colFoCarry, colFo_NLFLtNo, colFo_NLRoute, colFo_NLUTCDepart, colFoCancel});
            gvFO.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gvFO.OptionsView.ShowGroupPanel = true;
            gvFO.OptionsView.ShowFooter = true;
            //gvFO.OptionsView.EnableAppearanceEvenRow = true;
            gvFO.OptionsBehavior.Editable = true;
            gvFO.OptionsBehavior.ReadOnly = true;
            gvFO.Appearance.FocusedRow.BackColor = Color.GreenYellow;
            gvFO.Appearance.FocusedRow.BackColor2 = Color.YellowGreen;
            //gridView1.GroupSummary.Add(new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LastNameVn", colName, "{0:n0}")); 

            colOCCid = new GridColumn() { Caption = "#", FieldName = "NlID", Visible = true, Width = 30, ToolTip = "" };
            colOCCFlightNo = new GridColumn() { Caption = "FLT", FieldName = "NlFlightNo", Visible = true, Width = 50, ToolTip = "" };
            colOCCDate = new GridColumn() { Caption = "UTC", FieldName = "NlUTCDate", Visible = true, Width = 50, ToolTip = "" };
            colOCCRoute = new GridColumn() { Caption = "Route", FieldName = "NlRouting", Visible = true, Width = 100, ToolTip = "" };
            colOCCDepart = new GridColumn() { Caption = "Depart", FieldName = "NlUTCDepart", Visible = true, Width = 100, ToolTip = "" };
            colOCCArrive = new GridColumn() { Caption = "Arrive", FieldName = "NlUTCArrive", Visible = true, Width = 100, ToolTip = "" };
            colOCCAircraft = new GridColumn() { Caption = "AC", FieldName = "NlAC", Visible = true, Width = 50, ToolTip = "" };
            colOCCStatus = new GridColumn() { Caption = "Status", FieldName = "NlStatus", Visible = true, Width = 50, ToolTip = "x đã huỷ" };
            colOCCCarry = new GridColumn() { Caption = "C", FieldName = "NlCarry", Visible = true, Width = 50, ToolTip = "Carry" };
            colOCCFltNoNL = new GridColumn() { Caption = "FO FLT", FieldName = "FoFlightNo", Visible = true, Width = 50, ToolTip = "" };
            colOCC_NL_UTCDepart = new GridColumn() { Caption = "L Time", FieldName = "FoDepart", Visible = true, Width = 100, ToolTip = "" };
            colOCC_NLModifier = new GridColumn() { Caption = "Modifier", FieldName = "NlModifier", Visible = true, Width = 60, ToolTip = "" };

            colOCCFlightNo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colOCCFlightNo.SummaryItem.DisplayFormat = "{0:#,#}";

            //Button
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riMatch = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            riMatch.AutoHeight = false;
            riMatch.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK;
            riMatch.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            riMatch.ButtonClick += riMatch_ButtonClick;
            colOCCid.ColumnEdit = riMatch;



            gvOCC.Columns.Clear();
            gvOCC.Columns.AddRange(new GridColumn[] { colOCCFlightNo,  colOCCRoute, colOCCDate, colOCCDepart, colOCCArrive, colOCCAircraft, colOCCStatus, colOCCCarry, colOCCFltNoNL, colOCC_NL_UTCDepart, colOCCid, colOCC_NLModifier });
            gvOCC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gvOCC.OptionsView.ShowGroupPanel = true;
            gvOCC.OptionsView.ShowFooter = true;
            //gvOCC.OptionsView.EnableAppearanceEvenRow = true;
            gvOCC.OptionsBehavior.Editable = true;
            gvOCC.OptionsBehavior.ReadOnly = true;

          
            //FORMAT
            colFoDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colFoDate.DisplayFormat.FormatString = "ddMMM";
            colFoDepart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colFoDepart.DisplayFormat.FormatString = "HH:mm";
            colFoArrive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colFoArrive.DisplayFormat.FormatString = "HH:mm";
            colFo_NLUTCDepart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colFo_NLUTCDepart.DisplayFormat.FormatString = "ddMMM HH:mm";

            colOCCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colOCCDate.DisplayFormat.FormatString = "ddMMM";
            colOCCDepart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colOCCDepart.DisplayFormat.FormatString = "HH:mm";
            colOCCArrive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colOCCArrive.DisplayFormat.FormatString = "HH:mm";

            colOCC_NL_UTCDepart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colOCC_NL_UTCDepart.DisplayFormat.FormatString = "ddMMM HH:mm";

            //VISIBLE for EDIT MODE
            colFoCancel.Visible = false;
            colOCCid.Visible = false;

            #region Style format
            colFoCancel.Fixed = FixedStyle.Right;
            colOCCid.Fixed = FixedStyle.Left;

            StyleFormatCondition styleFO_CNL;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleFO_CNL = new StyleFormatCondition(FormatConditionEnum.Equal, colFoStatus, null, true);
            //styleFO_CNL.Column = colFoFlightNo;
            styleFO_CNL.Appearance.BackColor = Color.Gray;
            styleFO_CNL.Appearance.BackColor2 = Color.Gray;
            styleFO_CNL.ApplyToRow = true; 
            gvFO.FormatConditions.Add(styleFO_CNL);

            StyleFormatCondition styleOCC_CNL;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleOCC_CNL = new StyleFormatCondition(FormatConditionEnum.Equal, colOCCStatus, null, "CNL");
            styleOCC_CNL.Appearance.BackColor = Color.Gray;
            //styleOCC_CNL.Appearance.BackColor2 = Color.Transparent;
            //styleOCC_CNL.ApplyToRow = true;
            gvOCC.FormatConditions.Add(styleOCC_CNL);

            //StyleFormatCondition styleNLCancel;
            //styleNLCancel = new StyleFormatCondition();// FormatConditionEnum.Equal, colFo_NLFLtNo, null, "CNL");
            //styleNLCancel.Column = colFo_NLFLtNo;
            //styleNLCancel.Condition = FormatConditionEnum.Expression;
            //styleNLCancel.Expression = @"[NlStatus] =""CNL""";
            //styleNLCancel.Appearance.BackColor = Color.Red;
            ////styleNLCancel.Appearance.BackColor2 = Color.GreenYellow;
            //gvFO.FormatConditions.Add(styleNLCancel);
            #endregion

            //BIND
            gc1.DataSource = bindFO ;
            gc2.DataSource = bindNL;

        }
        void LoadData(DateTime fromdate, DateTime todate, string keyword)
        {
            gc1.SuspendLayout();

           // bindFO.DataSource = null;
            bindFO.DataSource = db.GetFOFlights(fromdate, todate, keyword);
            //gc1.RefreshDataSource();
            gc1.ResumeLayout();
                     
        }
       
        private void FrmFlightFONetline_Load(object sender, EventArgs e)
        {
            txtFromdate.DateTime = DateTime.Today.AddDays(-7);
            txtTodate.DateTime = DateTime.Today.AddDays(1);
            LoadData(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text);
            splitContainerControl1.SplitterPosition = 2 * Screen.PrimaryScreen.WorkingArea.Width / 3;
            txtKeyword.Focus();

        }
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            //TODO: Xuất ra excel
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.Title = "Save an Excel";
            DialogResult dlg = file.ShowDialog();
            if (dlg != DialogResult.OK) return;

            ExportSettings.DefaultExportType = ExportType.WYSIWYG;
            gvFO.ExportToXlsx(file.FileName);
            try
            {
                System.Diagnostics.Process.Start(file.FileName);
            }
            catch
            {
            }
        }

        private void riFLTCancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if (gvFO.FocusedRowHandle < 0) return;
            //TODO: isdeleted = 1; islock = 1
            int id = (int)gvFO.GetFocusedRowCellValue(colFoid);
            try
            {
                db.FoCancel(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gvFO.SetFocusedRowCellValue(colFoStatus, true);

        }
        private void riMatch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Ref id; auto = false
            int flightid = (int) gvFO.GetFocusedRowCellValue(colFoid);
            string foFlightNo = gvFO.GetFocusedRowCellValue(colFoFlightNo).ToString();
            DateTime? foDate = (DateTime?) gvFO.GetFocusedRowCellValue(colFoDepart);
            USP_GetFlights_NL_FO_byFLT_Result item = (USP_GetFlights_NL_FO_byFLT_Result)gvOCC.GetRow(gvOCC.FocusedRowHandle);

            try
            {
                db.Match(flightid, item);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Refresh
            gvOCC.SetFocusedRowCellValue("FoFlightID", flightid );
            gvOCC.SetFocusedRowCellValue(colOCCFltNoNL,foFlightNo );
            gvOCC.SetFocusedRowCellValue(colOCC_NL_UTCDepart,foDate );
            gvOCC.SetFocusedRowCellValue(colOCC_NLModifier, ERMs.Sys.ConfigurationSetting.UserInfo.FullName);

            //Refresh
            gvFO.SetFocusedRowCellValue(colFo_NLFLtNo, item.NlFlightNo);
            gvFO.SetFocusedRowCellValue(colFo_NLRoute, item.NlRouting);
            gvFO.SetFocusedRowCellValue(colFo_NLUTCDepart, item.NlUTCDepart);

            List<USP_GetFlights_NL_FO_byFLT_Result> rows = (List <USP_GetFlights_NL_FO_byFLT_Result> ) bindNL.DataSource;
            foreach (var ro in rows)
                ro.FoFlightID = 0;

            item.FoFlightID = flightid;
            gvOCC.RefreshData();

        }
        private void gvFo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            GridView view = sender as GridView;
            USP_GetFlights_NL_FO_byKeyword_Result row = (USP_GetFlights_NL_FO_byKeyword_Result)view.GetRow(e.FocusedRowHandle);

            DateTime dat = row.FoDate;
            string fltNo = row.FoFlightNo;
            string route = row.FoRouting;

            bindNL.DataSource = db.GetFlights_byFLT(dat, fltNo, route);
            gvOCC.RefreshData();

        }
        private void gvFO_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (!e.Column.Equals(colFo_NLFLtNo) && !e.Column.Equals(colFoFlightNo)) return;

            GridView view = sender as GridView;
            USP_GetFlights_NL_FO_byKeyword_Result item = (USP_GetFlights_NL_FO_byKeyword_Result)view.GetRow(e.RowHandle);

            if (e.Column.Equals(colFo_NLFLtNo) && item.NlStatus == "CNL")
            {
                e.Appearance.BackColor = Color.Coral;
                //e.Appearance.BackColor2 = Color.Coral;
            }
            else if (e.Column.Equals(colFoFlightNo) && !item.LBid.HasValue ) // !item.FoStatus.HasValue)
            {
                e.Appearance.BackColor = Color.Coral;
                //e.Appearance.BackColor2 = Color.Coral;
            }
            else if (e.Column.Equals(colFoFlightNo) && item.LBid.HasValue && item.FoStatus == true)
            {
                e.Appearance.BackColor = Color.Aquamarine;
                e.Appearance.BackColor2 = Color.Aqua;
            }
        }

        //Lấy matching
        private void gvOCC_RowStyle(object sender, RowStyleEventArgs e)
        {
            const int HOURS = 22;
            if (gvFO.FocusedRowHandle < 0 || e.RowHandle < 0) return;
            USP_GetFlights_NL_FO_byKeyword_Result fo = (USP_GetFlights_NL_FO_byKeyword_Result)gvFO.GetRow(gvFO.FocusedRowHandle);
            
            GridView view = sender as GridView;
            USP_GetFlights_NL_FO_byFLT_Result item = (USP_GetFlights_NL_FO_byFLT_Result)view.GetRow(e.RowHandle);
            if (fo == null || item == null) return;

            if (fo.FoFlightID == item.FoFlightID)
            {
                e.Appearance.BackColor = Color.GreenYellow;
                e.Appearance.BackColor2 = Color.YellowGreen;
            }
            else if (fo.FoDepart >= item.NlUTCDepart && fo.FoDepart <= item.NlUTCDepart.Value.AddHours(HOURS) && item.NlStatus != "CNL") // && fo.FoFlightNo.Replace("Z","").Replace("D","").Trim() == item.NlFlightNo.Replace("Z", "").Replace("D", "").Trim())
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.BackColor2 = Color.Yellow;

            }
           
        }

    }
}
