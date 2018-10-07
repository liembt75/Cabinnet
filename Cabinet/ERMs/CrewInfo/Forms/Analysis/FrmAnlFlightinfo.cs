using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ERMs.Data.Analysis;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace CrewInfo.Forms.Analysis
{
    public partial class FrmAnlFlightinfo : ERMs.SharedBase.XtraFormMDIBase
    {

        AnlFlightDal db = new AnlFlightDal();
        BindingSource bis = new BindingSource();

        public FrmAnlFlightinfo():base()
        {
            InitializeComponent();
            InitialLayout();
            this.Text = "Flights";
        }

        private void FrmAnlFlightinfo_Load(object sender, EventArgs e)
        {
            //txtFromdate.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtFromdate.DateTime = DateTime.Today;
            txtTodate.DateTime = txtFromdate.DateTime.AddMonths(1).AddDays(-1);
            gridControl1.DataSource = bis;

            //LoadData(txtFromdate.DateTime, txtTodate.DateTime, "");
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (object.Equals(e.Column,colCrewB))
            {

                int valid = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, colPaxC)) + 10 - (Convert.ToInt32(e.CellValue) * 10);

                if (valid < 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.BackColor2 = Color.LemonChiffon;
                }
            }

            else if (object.Equals(e.Column, colCrewTotal))
            {
                //e.Appearance.BackColor = Color.DeepSkyBlue;
                e.Appearance.BackColor2 = Color.DeepSkyBlue;
            }


        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text.Trim());
        }
        #region Initial

        GridColumn colFlightNo, colRouting, colFlightDate, colDepart, colAircraft, colPaxTotal, colPaxC, colPaxY, colCarry, colVip, 
                colCrewP, colCrewX, colCrewS, colCrewB, colCrewY, colCrewT, colCrewO, colCrewTotal, colCOF, colDeactive, colFlightid;

        private void InitialLayout()
        {
            //panelControl1.Dock = DockStyle.Fill;
            gridControl1.Dock = DockStyle.Fill;
         
            colFlightid = new GridColumn();
            colFlightid.Caption = "#";
            colFlightid.FieldName = "FlightID";
            colFlightid.Width = 40;
            colFlightid.Visible = true;
            colFlightid.OptionsColumn.AllowEdit = false;

            colFlightNo = new GridColumn();
            colFlightNo.FieldName = "FlightNo";
            colFlightNo.Width = 50;
            colFlightNo.Visible = true;
            colFlightNo.Fixed = FixedStyle.Left;
            colFlightNo.OptionsColumn.AllowEdit = false;

            colFlightNo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colFlightNo.SummaryItem.DisplayFormat = "{0:n0}";

            colFlightDate = new GridColumn();
            colFlightDate.FieldName = "Date";
            colFlightDate.Width = 40;
            colFlightDate.Visible = true;
            colFlightDate.OptionsColumn.AllowEdit = false;

            RepositoryItemDateEdit recolFlightDate = new RepositoryItemDateEdit();
            recolFlightDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            recolFlightDate.Mask.EditMask = "dd/MM";
            recolFlightDate.Mask.UseMaskAsDisplayFormat = true;
            recolFlightDate.CharacterCasing = CharacterCasing.Upper;
            colFlightDate.ColumnEdit = recolFlightDate;

            colRouting = new GridColumn();
            colRouting.FieldName = "Routing";
            colRouting.Width = 40;
            colRouting.Visible = true;
            colRouting.OptionsColumn.AllowEdit = false;

            colAircraft = new GridColumn();
            colAircraft.FieldName = "Aircraft";
            colAircraft.Width = 40;
            colAircraft.Visible = true;
            colAircraft.OptionsColumn.AllowEdit = false;

            colDepart = new GridColumn();
            colDepart.FieldName = "Departed";
            colDepart.Width = 40;
            colDepart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDepart.DisplayFormat.FormatString = "HH:mm";
            colDepart.Visible = true;

            //total pax
            colPaxTotal = new GridColumn();
            colPaxTotal.Caption = "Pax";
            colPaxTotal.FieldName = "TotalPax";
            colPaxTotal.Width = 30;
            colPaxTotal.Visible = false;
            colPaxTotal.AppearanceCell.Options.UseTextOptions = true;
            colPaxTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            colPaxTotal.OptionsColumn.AllowEdit = false;

            colPaxC = new GridColumn();
            colPaxC.Caption = "C";
            colPaxC.FieldName = "TotalPaxC";
            colPaxC.Width = 20;
            colPaxC.Visible = true;
            colPaxC.OptionsColumn.AllowEdit = false;

            colPaxY = new GridColumn();
            colPaxY.Caption = "Y";
            colPaxY.FieldName = "TotalPaxY";
            colPaxY.Width = 30;
            colPaxY.Visible = true;
            colPaxY.OptionsColumn.AllowEdit = false;

            colCarry = new GridColumn();
            colCarry.Caption = "Carry";
            colCarry.FieldName = "Carry";
            colCarry.Width = 20;
            colCarry.Visible = true;
            colCarry.OptionsColumn.AllowEdit = false;

            RepositoryItemSpinEdit recolSpinNumber = new RepositoryItemSpinEdit();
            recolSpinNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            recolSpinNumber.Mask.EditMask = "####";
            recolSpinNumber.Mask.UseMaskAsDisplayFormat = true;

            colVip = new GridColumn();
            colVip.Caption = "VIP";
            colVip.FieldName = "TotalVIP";
            colVip.Width = 20;
            colVip.Visible = true;
            colVip.ColumnEdit = recolSpinNumber;
            colVip.OptionsColumn.AllowEdit = false;

            colCrewP = new GridColumn();
            colCrewP.FieldName = "P";
            colCrewP.Visible = true;
            colCrewP.Width = 20;
            colCrewP.ColumnEdit = recolSpinNumber;
            colCrewP.OptionsColumn.AllowEdit = false;

            colCrewX = new GridColumn();
            colCrewX.FieldName = "X";
            colCrewX.Width = 20;
            colCrewX.Visible = true;
            colCrewX.ColumnEdit = recolSpinNumber;
            colCrewX.OptionsColumn.AllowEdit = false;

            colCrewS = new GridColumn();
            colCrewS.FieldName = "S";
            colCrewS.Width = 20;
            colCrewS.Visible = true;
            colCrewS.ColumnEdit = recolSpinNumber;
            colCrewS.OptionsColumn.AllowEdit = false;

            colCrewB = new GridColumn();
            colCrewB.FieldName = "B";
            colCrewB.Width = 20;
            colCrewB.Visible = true;
            colCrewB.ColumnEdit = recolSpinNumber;
            colCrewB.OptionsColumn.AllowEdit = false;

            colCrewY = new GridColumn();
            colCrewY.FieldName = "Y";
            colCrewY.Width = 20;
            colCrewY.Visible = true;
            colCrewY.ColumnEdit = recolSpinNumber;
            colCrewY.OptionsColumn.AllowEdit = false;

            colCrewT = new GridColumn();
            colCrewT.FieldName = "T";
            colCrewT.Width = 20;
            colCrewT.Visible = true;
            colCrewT.ColumnEdit = recolSpinNumber;
            colCrewT.OptionsColumn.AllowEdit = false;

            colCrewO = new GridColumn();
            colCrewO.FieldName = "O";
            colCrewO.Width = 20;
            colCrewO.Visible = true;
            colCrewO.ColumnEdit = recolSpinNumber;
            colCrewO.OptionsColumn.AllowEdit = false;

            colCrewTotal = new GridColumn();
            colCrewTotal.Caption = "Total";
            colCrewTotal.FieldName = "CrewTotal";
            colCrewTotal.Width = 20;
            colCrewTotal.Visible = true;
            colCrewTotal.ColumnEdit = recolSpinNumber;
            colCrewTotal.OptionsColumn.AllowEdit = false;

            colCOF = new GridColumn();
            colCOF.FieldName = "COF";
            colCOF.Width = 250;
            colCOF.Visible = true;
            colCOF.OptionsColumn.AllowEdit = false;


            colDeactive = new GridColumn();
            colDeactive.Caption = "Deactive";
            colDeactive.FieldName = "IsDeleted";
            colDeactive.Width = 30;
            colDeactive.Visible = true;

            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(new GridColumn[] { colFlightNo, colRouting, colFlightDate, colDepart, colAircraft, colPaxTotal, colPaxC, colPaxY,
                colVip, colCarry, colCrewP, colCrewX, colCrewS, colCrewB, colCrewY, colCrewT,  colCrewTotal, colCrewO, colCOF, colDeactive, colFlightid });
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

            gridView1.GroupPanelText = "Danh sách chuyến bay";
            gridView1.OptionsView.ShowFooter = true;
            //Show checkbox
            gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;

            // Create and setup the first summary item.
            GridGroupSummaryItem groupItem = new GridGroupSummaryItem();
            groupItem.FieldName = "FlightNo";
            groupItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            //gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            groupItem.DisplayFormat = "({0:n0} items)";
            gridView1.GroupSummary.Add(groupItem);
            //gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;//.VisibleIfExpanded;

            /// Style format
            //StyleFormatCondition styleVIP;
            //styleVIP = new StyleFormatCondition();
            //styleVIP.Condition = FormatConditionEnum.Expression;
            //styleVIP.Expression = "([Carry] = \'O\' OR [Carry] = \'E\') AND [TotalVIP] > 0";
            //styleVIP.Appearance.BackColor = Color.Yellow;
            //styleVIP.Appearance.BackColor2 = Color.GreenYellow;
            //styleVIP.Appearance.Options.UseBackColor = true;
            //styleVIP.ApplyToRow = true;
            //gridView1.FormatConditions.Add(styleVIP);

        }

        private void LoadData(DateTime from, DateTime to, string keyword)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(ERMs.SharedBase.WaitFormDefault), true, true, false);
                bis.DataSource = db.GetFlights(from, to, keyword);
                gridControl1.RefreshDataSource();
                SplashScreenManager.CloseForm(false);


            }
            catch 
            {

            }

        }

        #endregion
    }
}
