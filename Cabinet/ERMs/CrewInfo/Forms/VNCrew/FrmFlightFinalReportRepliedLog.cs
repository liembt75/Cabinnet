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

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportRepliedLog : ERMs.SharedBase.XtraFormMDIBase
    {
        int FinalReportID = -1;
        FlightDal dbFlight = new FlightDal();
        public FrmFlightFinalReportRepliedLog(int iFinalReportID)
        {
            InitializeComponent();
            FinalReportID = iFinalReportID;
            gridControl1.DataSource = dbFlight.GetFinalReportRepliedLogByFinalReportID(FinalReportID);
        }
    }
}