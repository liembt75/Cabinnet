using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();


            //1. Fill data table ve vao dataset
            DataSet ds = new DataSet();

            //2. Report
            report.DataSource = ds;
            
            //show
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowRibbonPreviewDialog();
        }
    }
}
