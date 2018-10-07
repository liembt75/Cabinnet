using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Reports
{
    public partial class RpOJT : DevExpress.XtraReports.UI.XtraReport
    {
        public RpOJT()
        {
            InitializeComponent();
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel4.Text = xrLabel4.Text.ToUpper();
        }
    }
}
