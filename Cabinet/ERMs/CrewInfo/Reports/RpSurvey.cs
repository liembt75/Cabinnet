using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Reports
{
    public partial class RpSurvey : DevExpress.XtraReports.UI.XtraReport
    {
        public RpSurvey()
        {
            InitializeComponent();
        }

        private void xrLabelCategory_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabelCategory.Text = xrLabelCategory.Text.ToUpper();
        }
    }
}
