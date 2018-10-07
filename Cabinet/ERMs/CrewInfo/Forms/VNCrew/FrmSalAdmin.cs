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
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using ERMs.Data;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSalAdmin : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        BindingSource dataSource = new BindingSource();
        string userName = "";
        int selectedFlightID = -1;
        List<API_CR_USP_GetFlightCrewAdmin_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrewAdmin_Result>();

        public FrmSalAdmin()
        {
            InitializeComponent();
            LayoutInitial();
        }

        private void LayoutInitial()
        {
            this.Text = "Báo cáo vị trí - Admin";
            this.WindowState = FormWindowState.Maximized;

            StyleFormatCondition styleFlightCrewIsDelete;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleFlightCrewIsDelete = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightCrew.Columns["IsDeleted"], null, "true");
            styleFlightCrewIsDelete.Appearance.BackColor = Color.Gray;
            styleFlightCrewIsDelete.Appearance.BackColor2 = Color.Gray;
            styleFlightCrewIsDelete.ApplyToRow = true;
            gvFlightCrew.FormatConditions.Add(styleFlightCrewIsDelete);

            StyleFormatCondition styleFlightInfoIsDelete;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleFlightInfoIsDelete = new StyleFormatCondition(FormatConditionEnum.Equal, gvFlightInfo.Columns["IsDeleteds"], null, "true");
            styleFlightInfoIsDelete.Appearance.BackColor = Color.Gray;
            styleFlightInfoIsDelete.Appearance.BackColor2 = Color.Gray;
            styleFlightInfoIsDelete.ApplyToRow = true;
            gvFlightInfo.FormatConditions.Add(styleFlightInfoIsDelete);

            StyleFormatCondition styleDeh;
            //styleVIP.Appe arance.ForeColor = Color.Orange;
            styleDeh = new StyleFormatCondition(FormatConditionEnum.NotEqual, gvFlightCrew.Columns["FO_Cfg"], null, "");
            styleDeh.Appearance.BackColor = Color.GreenYellow;
            styleDeh.Appearance.BackColor2 = Color.GreenYellow;
            styleDeh.ApplyToRow = true;
            gvFlightCrew.FormatConditions.Add(styleDeh);
        }

        private void FrmSalAdmin_Load(object sender, EventArgs e)
        {
            userName = ((FrmMain)this.ParentForm).mUserName;
            txtFromdate.DateTime = DateTime.Today.AddDays(-14); // new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            txtTodate.DateTime = DateTime.Today;
            btnLoadFlights_Click(null, null);
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Height * 2 / 3;
        }

        public override void HideNav()
        {
            panelNav.Hide();
        }

        public override void ShowNav()
        {
            panelNav.Show();

        }

        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;

            dataSource.DataSource = db.GetFlightsAdmin(fromdate, todate);
            gridControl1.DataSource = dataSource;
            BindingDetailList(0);
            SplashScreenManager.CloseForm(false);
        }

        void BindingDetailList(int index)
        {
            if (index < 0)
                return;
            try
            {
                selectedFlightID = (int)gvFlightInfo.GetRowCellValue(index, "FlightID");
                gcFlightCrew.DataSource = lstFlightCrew = db.GetFlightCrewByFlightIDAdmin(selectedFlightID, true);
            }
            catch { }
        }

        private void gvFlightInfo_ColumnFilterChanged(object sender, EventArgs e)
        {
            BindingDetailList(0);
        }

        private void gvFlightInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindingDetailList(e.FocusedRowHandle);
        }

        private void gvFlightInfo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {
                bool isUpdate = false;
                int flightID = (int)gvFlightInfo.GetRowCellValue(e.RowHandle, "FlightID");

                CR_FlightInfo flightInfo = db.GetFlightInfoByFlightID(flightID);
                switch (e.Column.Name)
                {
                    case "clIsDeleteds":
                        isUpdate = true;                        
                        break;
                }
                if (isUpdate)
                {
                    flightInfo.Modifier = userName;
                    db.UpdateFlightInfo(flightInfo);
                }
            }
            catch
            { }
        }

        private void gvFlightInfo_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu này?", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Value = gvFlightInfo.ActiveEditor.OldEditValue;
            }
        }

        private void gvFlightCrew_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {
                bool isUpdate = false;
                int id = (int)gvFlightCrew.GetRowCellValue(e.RowHandle, "ID");

                CR_Flight_Crew cr_Flight_Crew = db.GetFlightCrewByFlightCrewID(id);
                switch (e.Column.Name)
                {
                    case "clIsDeleted":
                        if (cr_Flight_Crew.IsDeleted != (bool)e.Value)
                        {
                            cr_Flight_Crew.IsDeleted = (bool)e.Value;
                            isUpdate = true;
                        }
                        break;
                    case "clCFG":
                        if (cr_Flight_Crew.FO_Cfg != e.Value.ToString())
                        {
                            cr_Flight_Crew.FO_Cfg = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clKH":
                        if (cr_Flight_Crew.FO_Job != e.Value.ToString())
                        {
                            cr_Flight_Crew.FO_Job = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clTask":
                        if (cr_Flight_Crew.Job != e.Value.ToString())
                        {
                            cr_Flight_Crew.Job = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clCA":
                        if (cr_Flight_Crew.CA != e.Value.ToString())
                        {
                            cr_Flight_Crew.CA = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                    case "clOJT":
                        if (cr_Flight_Crew.Training != e.Value.ToString())
                        {
                            cr_Flight_Crew.Training = e.Value.ToString();
                            isUpdate = true;
                        }
                        break;
                }
                if (isUpdate)
                {
                    cr_Flight_Crew.Modifier = userName;
                    db.UpdateFlightCrew(cr_Flight_Crew);
                }
            }
            catch
            { }
        }

        private void gvFlightCrew_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu này?", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Value = gvFlightCrew.ActiveEditor.OldEditValue;
            }
        }

        private void btnInsertFlightCrew_Click(object sender, EventArgs e)
        {
            if (selectedFlightID == -1)
            {
                MessageBox.Show("Vui lòng chọn chuyến bay!");
            }
            else
            {
                CR_FlightInfo flightInfo = db.GetFlightInfoByFlightID(selectedFlightID);
                if (flightInfo != null)
                {
                    FrmSalInsertFlightCrew frm = new FrmSalInsertFlightCrew();
                    frm.flightInfo = flightInfo;
                    frm.lstFlightCrew = lstFlightCrew;
                    frm.ShowDialog();
                    BindingDetailList(gvFlightInfo.FocusedRowHandle);
                }
            }
        }
    }
}