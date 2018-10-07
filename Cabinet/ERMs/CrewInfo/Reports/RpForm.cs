using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CrewInfo.Reports
{
    public partial class RpForm : DevExpress.XtraReports.UI.XtraReport
    {
        public RpForm()
        {
            InitializeComponent();
            //xrBarCode1.Text = "";
        }

        private void xrBarCode1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrBarCode1.Text = xrBarCode1.Text.ToString() + DateTime.Now.ToString("dd/MM/yyyy");
            //xrBarCode1.Text = DateTime.Now.ToString("yyMMddHHmm");
        }
    }
}
