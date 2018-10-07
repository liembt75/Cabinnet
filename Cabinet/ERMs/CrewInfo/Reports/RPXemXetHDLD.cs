using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Reports
{
    public partial class RPXemXetHDLD : DevExpress.XtraReports.UI.XtraReport
    {
        public RPXemXetHDLD()
        {
            InitializeComponent();
        }

        private void xrLabel16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime begin = new DateTime(now.Year, 1, 1, 0, 0, 0, 0);
            xrLabel16.Text = string.Format(xrLabel16.Text, begin.ToString("dd/MM/yyyy"), now.ToString("dd/MM/yyyy"), now.Year.ToString());
        }
    }
}
