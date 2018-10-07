using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERMs.Data.Flight;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.Export;
using ERMs.Data;
using CrewInfo.Forms.VNCrew;
using ERMs.Data.Log;
using CrewInfo.ADONet;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Forms
{
    public partial class FrmFlightForSalary : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        LogDal dbLog = new LogDal();
        BindingSource dataSource = new BindingSource();
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;
        List<ExamineeModel> lstCrew = new List<ExamineeModel>();
        public FrmFlightForSalary()
        {
            InitializeComponent();
            LayoutInitial();
        }

        GridColumn colFlightid, colFlightNo, colRouting, colFlightDate, colDepart, colAircraft, colPaxTotal, colPaxC, colPaxY, colCarry, colVip, colCip, colSM, colINF, colChecklist, colPurserName, colPurserID, colLock, colIsDeleted, colMarked;


        private void LayoutInitial()
        {
            this.Text = "Báo cáo vị trí";
            this.WindowState = FormWindowState.Maximized;            
            gridControl1.Dock = DockStyle.Fill;            
            #region Main View
            colChecklist = new GridColumn();
            colChecklist.Caption = "Task";
            colChecklist.FieldName = "Task";
            colChecklist.Width = 40;
            colChecklist.Visible = true;
            colChecklist.ColumnEdit = repositoryItemImageComboBox1;
            colChecklist.Fixed = FixedStyle.Left;
            colChecklist.OptionsColumn.AllowEdit = false;

            colFlightid = new GridColumn();
            colFlightid.Caption = "#";
            colFlightid.FieldName = "FlightID";
            colFlightid.Width = 50;
            colFlightid.Visible = true;
            colFlightid.OptionsColumn.ReadOnly = true;

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
            colFlightDate.Width = 60;
            colFlightDate.Visible = true;
            colFlightDate.Fixed = FixedStyle.Left;
            colFlightDate.OptionsColumn.AllowEdit = false;

            RepositoryItemDateEdit recolFlightDate = new RepositoryItemDateEdit();
            recolFlightDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            recolFlightDate.Mask.EditMask = "dd/MM/yyyy";
            recolFlightDate.Mask.UseMaskAsDisplayFormat = true;
            recolFlightDate.CharacterCasing = CharacterCasing.Upper;
            colFlightDate.ColumnEdit = recolFlightDate;

            colRouting = new GridColumn();
            colRouting.FieldName = "Routing";
            colRouting.Width = 50;
            colRouting.Visible = true;
            colRouting.OptionsColumn.AllowEdit = false;

            colAircraft = new GridColumn();
            colAircraft.FieldName = "Aircraft";
            colAircraft.Width = 50;
            colAircraft.Visible = true;
            colAircraft.OptionsColumn.AllowEdit = false;

            colDepart = new GridColumn();
            colDepart.FieldName = "Departed";
            colDepart.Width = 50;
            colDepart.Visible = true;
            RepositoryItemDateEdit recolFlightDeparted = new RepositoryItemDateEdit();
            recolFlightDeparted.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            recolFlightDeparted.Mask.EditMask = "HH:mm";
            recolFlightDeparted.Mask.UseMaskAsDisplayFormat = true;
            colDepart.ColumnEdit = recolFlightDeparted;
            colDepart.OptionsColumn.AllowEdit = false;

            //total pax
            colPaxTotal = new GridColumn();
            colPaxTotal.Caption = "EQUIP";
            colPaxTotal.FieldName = "Classify";
            colPaxTotal.Width = 60;
            colPaxTotal.Visible = true;
            //colPaxTotal.AppearanceCell.Options.UseTextOptions = true;
            //colPaxTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            colPaxTotal.OptionsColumn.ReadOnly= true;

            colPaxC = new GridColumn();
            colPaxC.Caption = "C";
            colPaxC.FieldName = "TotalPaxC";
            colPaxC.Width = 30;
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
            colCarry.Width = 30;
            colCarry.Visible = true;
            colCarry.OptionsColumn.AllowEdit = false;

            RepositoryItemSpinEdit recolSpinNumber = new RepositoryItemSpinEdit();
            recolSpinNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            recolSpinNumber.Mask.EditMask = "####";
            recolSpinNumber.Mask.UseMaskAsDisplayFormat = true;

            colVip = new GridColumn();
            colVip.Caption = "VIP";
            colVip.FieldName = "TotalVIP";
            colVip.Width = 30;
            colVip.Visible = true;
            colVip.ColumnEdit = recolSpinNumber;
            colVip.OptionsColumn.AllowEdit = false;

            colCip = new GridColumn();
            colCip.Caption = "CIP";
            colCip.FieldName = "TotalCIP";
            colCip.Width = 30;
            colCip.Visible = true;
            colCip.ColumnEdit = recolSpinNumber;
            colCip.OptionsColumn.AllowEdit = false;

            colSM = new GridColumn();
            colSM.Caption= "SM";
            colSM.ToolTip= "Special meal";
            colSM.FieldName = "TotalSM";
            colSM.Width = 30;
            colSM.Visible = true;
            colSM.OptionsColumn.AllowEdit = false;

            colINF = new GridColumn();
            colINF.Caption = "Infant";
            colINF.FieldName = "TotalINF";
            colINF.Width = 30;
            colINF.Visible = true;
            colINF.OptionsColumn.AllowEdit = false;

            colPurserName = new GridColumn();
            colPurserName.Caption = "Purser";
            colPurserName.FieldName = "PurserName";
            colPurserName.Width = 30;
            colPurserName.Visible = true;
            colPurserName.OptionsColumn.AllowEdit = false;

            colPurserID = new GridColumn();
            colPurserID.Caption = "CID";
            colPurserID.FieldName = "Purserid";
            colPurserID.Width = 30;
            colPurserID.Visible = true;
            colPurserID.OptionsColumn.AllowEdit = false;

            GridColumn colIsDeleted = new GridColumn();
            colIsDeleted.Name = "clIsDeleted";
            colIsDeleted.Caption = "Inactive";
            colIsDeleted.FieldName = "IsDeleted";
            colIsDeleted.Width = 30;
            colIsDeleted.Visible = true;

            GridColumn colLock = new GridColumn();
            colLock.Caption = "Lock";
            colLock.Name = "isLocked";
            colLock.FieldName = "isLocked";
            colLock.Width = 30;
            colLock.Visible = true;

            gvFlightInfo.Columns.Clear();
            gvFlightInfo.Columns.AddRange(new GridColumn[] { colChecklist, colFlightNo, colFlightDate, colDepart, colRouting, colAircraft, colPaxTotal, colPaxC, colPaxY, colCarry,
                                                            colVip, colCip, colSM, colINF, colPurserName, colPurserID,  colFlightid, colIsDeleted,colLock});
            gvFlightInfo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gvFlightInfo.OptionsView.ShowGroupPanel = true;
            gvFlightInfo.OptionsView.EnableAppearanceEvenRow = true;
            //gvFlightInfo.OptionsBehavior.ReadOnly = true;

            gvFlightInfo.GroupPanelText = "Danh sách chuyến bay";
            gvFlightInfo.OptionsView.ShowFooter = true;
            //Show checkbox
            gvFlightInfo.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            gvFlightInfo.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            

            // Create and setup the first summary item.
            GridGroupSummaryItem groupItem = new GridGroupSummaryItem();
            groupItem.FieldName = "Task";
            groupItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            //gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            groupItem.DisplayFormat = "({0:n0} items)";
            gvFlightInfo.GroupSummary.Add(groupItem);

            //gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;//.VisibleIfExpanded;


            #endregion            

            #region Style format

            StyleFormatCondition styleVIP, styleCIP, styleSM, styleINF;
            styleVIP = new StyleFormatCondition();            
            styleVIP.Condition = FormatConditionEnum.Expression;
            styleVIP.Expression = "([Carry] = \'O\' OR [Carry] = \'E\') AND [TotalVIP] > 0";            
            styleVIP.Appearance.BackColor = Color.Yellow;
            styleVIP.Appearance.BackColor2 = Color.GreenYellow;
            styleVIP.Appearance.Options.UseBackColor = true;            
            styleVIP.ApplyToRow = true;
            gvFlightInfo.FormatConditions.Add(styleVIP);  

            StyleFormatCondition styleDeh;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleDeh = new StyleFormatCondition(FormatConditionEnum.NotEqual, gvFlightCrew.Columns["FO_Cfg"], null, "");
            styleDeh.Appearance.BackColor = Color.LightBlue;
            styleDeh.ApplyToRow = true;
            gvFlightCrew.FormatConditions.Add(styleDeh);

            StyleFormatCondition styleDelete;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleDelete = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightInfo.Columns["IsDeleted"], null, "true");
            styleDelete.Appearance.BackColor = Color.Gray;
            styleDelete.Appearance.BackColor2 = Color.Gray;
            //styleDelete.Appearance.ForeColor2 = Color.Gray;
            styleDelete.ApplyToRow = true;
            gvFlightInfo.FormatConditions.Add(styleDelete);

            

            StyleFormatCondition styleCrewExclamation = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightCrew.Columns["Job"], null, "!");
            styleCrewExclamation.Appearance.BackColor = Color.Red;
            styleCrewExclamation.Appearance.BackColor2 = Color.Transparent;
            //styleDelete.Appearance.ForeColor2 = Color.Gray;
            styleCrewExclamation.ApplyToRow = true;
            gvFlightCrew.FormatConditions.Add(styleCrewExclamation);

            //StyleFormatCondition styleMarket = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightCrew.Columns["Marked"], null, 1);
            //styleMarket.Appearance.BackColor = Color.Red;
            //styleMarket.Appearance.BackColor2 = Color.Transparent;
            ////styleDelete.Appearance.ForeColor2 = Color.Gray;
            //styleMarket.ApplyToRow = true;
            //gvFlightInfo.FormatConditions.Add(styleMarket);

            StyleFormatCondition style = new StyleFormatCondition();
            //stylePhongBanChuaTraLoi.Column = gridColumn14;
            style.Condition = FormatConditionEnum.Expression;
            style.Expression = "[Marked] == 1 and [IsDeleted] != true";
            style.Appearance.BackColor = (Color)new ColorConverter().ConvertFromString("#FFDFD991"); ;
            //style.Appearance.BackColor2 = Color.White;
            style.Appearance.Options.UseBackColor = true;
            style.ApplyToRow = true;
            gvFlightInfo.FormatConditions.Add(style);

            StyleFormatCondition styleCrewDelete;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleCrewDelete = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightCrew.Columns["IsDeleted"], null, "true");
            styleCrewDelete.Appearance.BackColor = Color.Gray;
            styleCrewDelete.Appearance.BackColor2 = Color.Gray;
            //styleDelete.Appearance.ForeColor2 = Color.Gray;
            styleCrewDelete.ApplyToRow = true;
            gvFlightCrew.FormatConditions.Add(styleCrewDelete);
            #endregion            
        }

        #region Event
        private void FrmFlightForSalary_Load(object sender, EventArgs e)
        {            
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.C.T.01", out create, out read, out update, out delete);
            gvFlightCrew.Columns["FO_Cfg"].OptionsColumn.AllowEdit = update;
            gvFlightCrew.Columns["FO_Job"].OptionsColumn.AllowEdit = update;
            gvFlightCrew.Columns["Job"].OptionsColumn.AllowEdit = update;
            gvFlightCrew.Columns["CA"].OptionsColumn.AllowEdit = update;
            gvFlightCrew.Columns["Training"].OptionsColumn.AllowEdit = update;
            gvFlightCrew.Columns["IsDeleted"].Visible = delete;
            gvFlightCrew.Columns["IsDeleted"].OptionsColumn.AllowEdit = delete;
            //btnInsertFlightCrew.Visible = create;
            gvFlightInfo.Columns["IsDeleted"].Visible = delete;

            List<Sys_Crew_Task_Category> lstCTCategory = db.GetCrewTaskCategory(1);
            List<string> lststrCTCategory = lstCTCategory.Select(c => c.Name).ToList();
            lststrCTCategory.Insert(0, "");
            lststrCTCategory.Add("I");
            repositoryItemLookUpEdit1.DataSource = lststrCTCategory.ToArray();

            //Lay tat ca tiep vien de them vao chuyen bay
            lstCrew = db.GetExaminee();

            //panelNav.Hide();
            txtFromdate.DateTime = DateTime.Today.AddDays(-2); // new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            txtTodate.DateTime = DateTime.Today.AddDays(1);
            btnLoadFlights_Click(null, null);
        }
        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                DateTime fromdate, todate;
                DateTime now = DateTime.Now;
                fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
                todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
                fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
                todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

                string crewID = "";
                bool isGetAll = true;
                bool isExclamation = cbxIsExclamation.Checked;
                if (!string.IsNullOrEmpty(txtCrewID.Text))
                {
                    isGetAll = false;
                    try
                    {
                        int iCrewID = int.Parse(txtCrewID.Text);
                        crewID = "@" + txtCrewID.Text;
                    }
                    catch
                    {
                        Sys_Account acc = dbSystem.GetSysAccountByName(txtCrewID.Text);
                        if (acc != null)
                            crewID = "@" + acc.CrewID;
                        else
                            crewID = txtCrewID.Text.ToUpper();
                    }
                }

                bool IsGetLBMB = cbxGetLBMB.Checked;

                dataSource.DataSource = db.GetFlights(fromdate, todate, "", crewID, isGetAll, isExclamation, delete, IsGetLBMB, 1, 1000000);

                gridControl1.DataSource = dataSource;
                gvFlightInfo.BestFitColumns();
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DsFlightCrews ds = new DsFlightCrews();
            if (gvFlightInfo.GetSelectedRows().Length <= 0)
            {
                FlightInfoModel flightInfo = (FlightInfoModel)gvFlightInfo.GetFocusedRow();

                //add flight info
                DsFlightCrews.CR_FlightInfoRow row = ds.CR_FlightInfo.NewCR_FlightInfoRow();
                row.FlightID = flightInfo.FlightID;
                row.FlightNo = flightInfo.FlightNo;
                row.Routing = flightInfo.Routing;
                row.Departed = flightInfo.Departed.Value;
                row.Date = flightInfo.Date;
                ds.CR_FlightInfo.Rows.Add(row);
                //add crews
                if (flightInfo.Crews.Count <= 0)
                {
                    flightInfo.Crews.AddRange(db.GetFlightCrewByFlightIDAdmin(flightInfo.FlightID, delete));
                }
                foreach (var item in flightInfo.Crews)
                {
                    if (item.IsDeleted.HasValue && item.IsDeleted.Value) continue;

                    DsFlightCrews.CR_Flight_CrewRow cr = ds.CR_Flight_Crew.NewCR_Flight_CrewRow();
                    cr.FlightID = flightInfo.FlightID;
                    cr.CrewName = string.Format("{0} {1}", item.LastNameVn, item.FirstNameVn);
                    cr.CrewID = item.CrewID;
                    cr.FO_Job = item.FO_Job;
                    cr.FO_Cfg = item.FO_Cfg;
                    cr.Job = item.Job;
                    cr.CA = item.CA;
                    cr.Training = item.Training;
                    ds.CR_Flight_Crew.AddCR_Flight_CrewRow(cr);
                }
            }
            else
            {
                for (int i = 0; i < gvFlightInfo.GetSelectedRows().Length; i++)
                {
                    int rowHandle = gvFlightInfo.GetSelectedRows()[i];
                    FlightInfoModel flightInfo = (FlightInfoModel)gvFlightInfo.GetRow(rowHandle);

                    //add flight info
                    DsFlightCrews.CR_FlightInfoRow row = ds.CR_FlightInfo.NewCR_FlightInfoRow();
                    row.FlightID = flightInfo.FlightID;
                    row.FlightNo = flightInfo.FlightNo;
                    row.Routing = flightInfo.Routing;
                    row.Departed = flightInfo.Departed.Value;
                    row.Date = flightInfo.Date;
                    ds.CR_FlightInfo.Rows.Add(row);
                    //add crews
                    if (flightInfo.Crews.Count <= 0)
                    {
                        flightInfo.Crews.AddRange(db.GetFlightCrewByFlightIDAdmin(flightInfo.FlightID, delete));
                    }
                    foreach (var item in flightInfo.Crews)
                    {
                        if (item.IsDeleted.HasValue && item.IsDeleted.Value) continue;

                        DsFlightCrews.CR_Flight_CrewRow cr = ds.CR_Flight_Crew.NewCR_Flight_CrewRow();
                        cr.FlightID = flightInfo.FlightID;
                        cr.CrewName = string.Format("{0} {1}", item.LastNameVn, item.FirstNameVn);
                        cr.CrewID = item.CrewID;
                        cr.FO_Job = item.FO_Job;
                        cr.FO_Cfg = item.FO_Cfg;
                        cr.Job = item.Job;
                        cr.CA = item.CA;
                        cr.Training = item.Training;
                        cr.Ability = item.Ability;
                        ds.CR_Flight_Crew.AddCR_Flight_CrewRow(cr);
                    }

                }
            }

            RptFlightCrews xrpt = new RptFlightCrews();
            xrpt.DataSource = ds;

            using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
            {
                printTool.ShowRibbonPreviewDialog();
                // Invoke the Print dialog.
                //printTool.PrintDialog();
                // Send the report to the default printer.
                //printTool.Print();

                // Send the report to the specified printer.
                //printTool.Print("myPrinter");
            }
               
            }
        #endregion

        #region Navi
        public override void HideNav()
        {
            panelNav.Hide();
        }

        public override void ShowNav()
        {
            panelNav.Show();

        }
        #endregion

        private void btnGetFlightCrew_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            foreach (int rowIndex in gvFlightInfo.GetSelectedRows())
            {
                FlightInfoModel flight = (FlightInfoModel)gvFlightInfo.GetRow(rowIndex);
                if (flight == null) continue;
                flight.Crews.Clear();
                flight.Crews.AddRange(db.GetFlightCrewByFlightIDAdmin(flight.FlightID, delete));
                gvFlightInfo.SetMasterRowExpanded(rowIndex, true);
            }
            gridControl1.RefreshDataSource();
            SplashScreenManager.CloseForm(false);
        }

        private void txtCrewID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoadFlights_Click(null, null);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "DanhSachChuyenBay.xlsx";
            file.Title = "Save an Excel";
            file.ShowDialog();

            if (file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gvFlightCrew.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void btnExportExcelFlightCrews_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "DanhSachChuyenBay.xlsx";
            file.Title = "Save an Excel";
            file.ShowDialog();
            if (file.FileName.Trim() != "")
            {
                List<FlightInfoFlightCrewModel> lstFlightInfoFlightCrewModel = new List<FlightInfoFlightCrewModel>();
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                for (int i = 0; i < gvFlightInfo.GetSelectedRows().Length; i++)
                {
                    int rowHandle = gvFlightInfo.GetSelectedRows()[i];
                    FlightInfoModel flightInfo = (FlightInfoModel)gvFlightInfo.GetRow(rowHandle);
                    lstFlightInfoFlightCrewModel.AddRange(FlightInfoFlightCrewModel.ToModel(flightInfo, i + 1));
                }
                SplashScreenManager.CloseForm(false);
                gcFlightCrewEX.DataSource = lstFlightInfoFlightCrewModel;                
                gcFlightCrewEX.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void gvFlightInfo_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            FlightInfoModel flight = (FlightInfoModel)gvFlightInfo.GetRow(e.RowHandle);
            if (flight == null) return;
            flight.Crews.Clear();
            flight.Crews.AddRange(db.GetFlightCrewByFlightIDAdmin(flight.FlightID, delete));
            gridControl1.RefreshDataSource();
            gvFlightCrew.UpdateGroupSummary();
        }

        private void gvFlightCrew_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {
                bool isUpdate = false;
                GridView gridview = (GridView)sender;
                int id = (int)gridview.GetRowCellValue(e.RowHandle, "ID");

                CR_Flight_Crew cr_Flight_Crew = db.GetFlightCrewByFlightCrewID(id);
                CrewTaskLogModel log = new CrewTaskLogModel();
                switch (e.Column.Name)
                {
                    case "clIsDeletedDT":
                        if (cr_Flight_Crew.IsDeleted != (bool)e.Value)
                        {
                            log.OldValue = cr_Flight_Crew.IsDeleted == null ? "" : cr_Flight_Crew.IsDeleted.ToString();                            
                            cr_Flight_Crew.IsDeleted = (bool)e.Value;
                            isUpdate = true;
                        }
                        break;
                    case "clCFGDT":
                        if (cr_Flight_Crew.FO_Cfg != e.Value.ToString() && update)
                        {
                            log.OldValue = cr_Flight_Crew.FO_Cfg == null ? "" : cr_Flight_Crew.FO_Cfg.ToString();
                            cr_Flight_Crew.FO_Cfg = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clKHDT":
                        if (cr_Flight_Crew.FO_Job != e.Value.ToString() && update)
                        {
                            log.OldValue = cr_Flight_Crew.FO_Job == null ? "" : cr_Flight_Crew.FO_Job.ToString();
                            cr_Flight_Crew.FO_Job = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clTaskDT":
                        if (cr_Flight_Crew.Job != e.Value.ToString() && update)
                        {
                            log.OldValue = cr_Flight_Crew.Job == null ? "" : cr_Flight_Crew.Job.ToString();
                            cr_Flight_Crew.Job = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clCADT":
                        if (cr_Flight_Crew.CA != e.Value.ToString() && update)
                        {
                            log.OldValue = cr_Flight_Crew.CA == null ? "" : cr_Flight_Crew.CA.ToString();
                            cr_Flight_Crew.CA = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clOJTDT":
                        if (cr_Flight_Crew.Training != e.Value.ToString() && update)
                        {
                            log.OldValue = cr_Flight_Crew.Training == null ? "" : cr_Flight_Crew.Training.ToString();
                            cr_Flight_Crew.Training = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                }
                if (isUpdate)
                {
                    log.NewValue = e.Value.ToString();

                    cr_Flight_Crew.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    cr_Flight_Crew.Modified = DateTime.Now;
                    cr_Flight_Crew.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    db.UpdateFlightCrew(cr_Flight_Crew);
                    
                    log.UserName = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    log.Created = DateTime.Now;                    
                    log.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;                    
                    log.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();                    
                    log.FlightID = cr_Flight_Crew.FlightID;
                    log.Table = "CR_Flight_Crew";
                    log.Key = cr_Flight_Crew.ID.ToString();
                    log.Column = e.Column.FieldName;
                    log.Action = "Update";                    
                    dbLog.Add(log.ToModel());

                    bool finish = true;
                    for (int i = 0; i < gridview.RowCount; i++)
                    {
                        API_CR_USP_GetFlightCrewAdmin_Result flightCrew = gridview.GetRow(i) as API_CR_USP_GetFlightCrewAdmin_Result;
                        if (flightCrew.IsDeleted == false && (string.IsNullOrEmpty(flightCrew.Job) || string.IsNullOrEmpty(flightCrew.CA)))
                            finish = false;
                    }
                    if (finish == true)
                    {                        
                        db.UpdateFlightInfoCrewTaskStatusByFlighID(cr_Flight_Crew.FlightID, 1);
                        DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                        alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                    }
                }
            }
            catch
            { }
        }

        private void gvFlightCrew_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu này?", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //{
            //    e.Value = ((GridView)sender).ActiveEditor.OldEditValue;
            //}
        }

        private void btnInsertFlightCrew_Click(object sender, EventArgs e)
        {
            FlightInfoModel flighInfoModel = gvFlightInfo.GetFocusedRow() as FlightInfoModel;
            int selectedFlightID = flighInfoModel.FlightID;
            if (selectedFlightID == -1)
            {
                MessageBox.Show("Vui lòng chọn chuyến bay!");
            }
            else
            {
                CR_FlightInfo flightInfo = db.GetFlightInfoByFlightID(selectedFlightID);
                if (flightInfo != null)
                {
                    FrmSalInsertFlightCrew2 frm = new FrmSalInsertFlightCrew2(flightInfo, lstCrew);
                    frm.MdiParent = this.ParentForm;
                    //frm.flightInfo = flightInfo;
                    //frm.lstFlightCrew = db.GetFlightCrewByFlightIDAdmin(selectedFlightID, delete);
                    frm.Show();
                    frm.FormClosed += Frm_FormClosed;                  
                }
            }
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FlightInfoModel flight = gvFlightInfo.GetFocusedRow() as FlightInfoModel;            
            if (flight == null) return;
            flight.Crews.Clear();
            flight.Crews.AddRange(db.GetFlightCrewByFlightIDAdmin(flight.FlightID, delete));
            gridControl1.RefreshDataSource();
            gvFlightCrew.UpdateGroupSummary();
        }

        private void gvFlightInfo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {
                bool isUpdate = false;
                FlightInfoModel flighInfoModel = gvFlightInfo.GetFocusedRow() as FlightInfoModel;                
                CR_FlightInfo flightInfo = db.GetFlightInfoByFlightID(flighInfoModel.FlightID);
                CrewTaskLogModel log = new CrewTaskLogModel();
                switch (e.Column.FieldName.ToLower())
                {
                    case "isdeleted":
                        if (flightInfo.IsDeleted != (bool)e.Value && delete)
                        {
                            log.OldValue = flightInfo.IsDeleted.ToString();
                            flightInfo.IsDeleted = (bool)e.Value;
                            isUpdate = true;
                        }                        
                        break;
                    case "islocked":
                        if (flightInfo.isLocked.HasValue)
                        {
                            log.OldValue = flightInfo.isLocked.ToString();                            
                        }
                        flightInfo.isLocked = Convert.ToBoolean(e.Value);
                        isUpdate = true;
                        break;

                }

                if (isUpdate)
                {
                    log.NewValue = e.Value.ToString();

                    flightInfo.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    flightInfo.Modified = DateTime.Now;
                    flightInfo.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    db.UpdateFlightInfo(flightInfo);

                    log.UserName = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    log.Created = DateTime.Now;
                    log.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    log.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    log.FlightID = flightInfo.FlightID;
                    log.Table = "CR_FlightInfo";
                    log.Key = flightInfo.FlightID.ToString();
                    log.Column = e.Column.FieldName;
                    log.Action = "Update";                    
                    dbLog.Add(log.ToModel());
                    DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                }
            }
            catch
            { }
        }

        private void gvFlightInfo_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu này?", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //{
            //    e.Value = ((GridView)sender).ActiveEditor.OldEditValue;
            //}
        }
    }
}
