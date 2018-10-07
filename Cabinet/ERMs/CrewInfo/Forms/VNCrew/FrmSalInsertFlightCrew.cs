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

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSalInsertFlightCrew : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        public CR_FlightInfo flightInfo;
        public List<API_CR_USP_GetFlightCrewAdmin_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrewAdmin_Result>();

        public FrmSalInsertFlightCrew()
        {
            InitializeComponent();
        }

        private void FrmSalInsertFlightCrew_Load(object sender, EventArgs e)
        {
            lbCR_FlightInfo.Text = String.Format("FlightNo: {0}, Date: {1}, Routing: {2}", flightInfo.FlightNo, flightInfo.Date.ToString("dd/MM/yyyy"), flightInfo.Routing);
            List<API_CR_USP_GetBKFlightCrew_Result> lstBkFlightCrew = db.GetBKFlightCrew(flightInfo.FlightNo, flightInfo.Routing, flightInfo.Date);
            for (int i = lstBkFlightCrew.Count - 1; i >= 0; i--)
            {
                API_CR_USP_GetBKFlightCrew_Result bkFlightCrew = lstBkFlightCrew[i];
                API_CR_USP_GetFlightCrewAdmin_Result flightCrew = lstFlightCrew.Where(f => f.CrewID == bkFlightCrew.CrewID).FirstOrDefault();
                if (flightCrew != null)
                {
                    lstBkFlightCrew.RemoveAt(i);
                }
            }
            gcFlightCrew.DataSource = lstBkFlightCrew;
        }

        private void btnAddFligthCrew_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thật sự muốn thêm tiếp viên này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    API_CR_USP_GetBKFlightCrew_Result bkFlightCrew = (API_CR_USP_GetBKFlightCrew_Result)gvFlightCrew.GetFocusedRow();
                    bkFlightCrew.FlightID = flightInfo.FlightID;
                    if (string.IsNullOrEmpty(bkFlightCrew.CodeFly))
                    {
                        CR_Trip trip = db.GetTripByCodeFly(bkFlightCrew.CodeFly);
                        if (trip != null)
                            bkFlightCrew.TripID = trip.TripID;
                    }
                    db.InsertFlightCrewFromBkFlightCrew(bkFlightCrew);
                    this.Close();
                }
            }
            catch { }
        }
    }
}