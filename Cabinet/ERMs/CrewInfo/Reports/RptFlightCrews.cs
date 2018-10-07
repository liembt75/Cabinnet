using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace CrewInfo.Reports
{
    public partial class RptFlightCrews : DevExpress.XtraReports.UI.XtraReport
    {
        public RptFlightCrews()
        {
            InitializeComponent();

            xcode.Text = DateTime.Now.ToString("yyMMddHHmm");
        }

    }
}
