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
using ERMs.Data.Flight;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportDepartment : ERMs.SharedBase.XtraFormMDIBase
    {
        const int PPHKID = 3;

        public int ID = -1;
        FlightDal dbFlight = new FlightDal();
        SystemDAL dbSystem = new SystemDAL();
        List<int> lstDepartmentID = new List<int>();
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;        

        public FrmFlightFinalReportDepartment()
        {
            InitializeComponent();
        }

        private void FrmFlightFinalReportDepartment_Load(object sender, EventArgs e)
        {
            UpdateData();            
            lstDepartmentID = dbFlight.GetDepartmentByEmployeeID(ERMs.Sys.ConfigurationSetting.UserInfo.Userid).Select(i => i.DepartmentID).ToList();
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.C.R.01", out create, out read, out update, out delete);
            btnAddDepartment.Visible = update ? true : false;
        }

        public void UpdateData()
        {
            List<API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result> lstFlightFinalReportDepartment = dbFlight.GetFlightFinalReportDeparmentByFinalReportID(ID);
            gridControl1.DataSource = lstFlightFinalReportDepartment;
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            FrmFlightFinalReportAddDepartment frm = new FrmFlightFinalReportAddDepartment();
            frm.ID = this.ID;            
            //frm.frmFD = this;
            frm.ShowDialog();
        }

        private void repositoryTraLoi_Click(object sender, EventArgs e)
        {
            API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(gvYKPH.FocusedRowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;
            FrmFlightFinalReportDepartmentRely frm = new FrmFlightFinalReportDepartmentRely();
            frm.flightFinalReportDepartment = flightFinalReportDepartment;            
            //frm.frmFD = this;
            frm.ShowDialog();                 
        }

        private void gvYKPH_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clRely)
            {
                API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(e.RowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;                
                if (flightFinalReportDepartment.Replied != null || lstDepartmentID.IndexOf(flightFinalReportDepartment.DepartmentID) < 0)
                {
                    e.Appearance.FillRectangle(new DevExpress.Utils.Drawing.GraphicsCache(e.Graphics), e.Bounds);
                    e.Handled = true;
                    //ButtonEditViewInfo buttonEditViewInfo = ((GridCellInfo)e.Cell).ViewInfo as ButtonEditViewInfo;
                    //if (buttonEditViewInfo != null)
                    //{                        
                    //    buttonEditViewInfo.Item.Buttons[0].Image = null;
                    //    buttonEditViewInfo.Editable = false;
                    //}
                }
            }
        }

        private void gvYKPH_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn == clRely)
            {
                API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(view.FocusedRowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;
                if (flightFinalReportDepartment.Replied != null || lstDepartmentID.IndexOf(flightFinalReportDepartment.DepartmentID) < 0)
                {
                    e.Cancel = true;
                }
            }                
        }
    }
}