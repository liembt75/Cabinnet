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
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmManageReport : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketDal db = new TicketDal();
        public FrmManageReport()
        {
            InitializeComponent();
            StyleFormatCondition styleDone = new StyleFormatCondition();
            styleDone.Condition = FormatConditionEnum.Expression;
            styleDone.Expression = "[Status] = 3";
            styleDone.Appearance.BackColor = Color.LightYellow;
            styleDone.Appearance.BackColor2 = Color.LightYellow;
            styleDone.Appearance.Options.UseBackColor = true;
            styleDone.ApplyToRow = true;
            gridView1.FormatConditions.Add(styleDone);
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            txtTodate.DateTime = DateTime.Now;
            //InitData();
        }

        private void InitData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? new DateTime(DateTime.Now.Year, 1, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Now : txtTodate.DateTime;
            gridControl1.DataSource = db.GetVNAReport(fromdate, todate);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                var ticketVNAReport = gridView1.GetRow(e.RowHandle) as Ticket_VNAReport;                
                //Lay cap nhat moi nhat tu csdl chu ko phai tren list
                Ticket_VNAReport ticketVNAReportNew = db.GetTicketVNAReportByID(ticketVNAReport.ID);
                if (ticketVNAReportNew == null || ticketVNAReportNew.IsDeleted == true)
                {
                    return;
                }
                FrmReportDetail frm = new FrmReportDetail(ticketVNAReportNew);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }

        private void FrmManageReport_Activated(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}