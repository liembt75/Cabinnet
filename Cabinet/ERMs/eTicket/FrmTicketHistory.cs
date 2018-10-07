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

namespace eTicket
{
    public partial class FrmTicketHistory : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketDal db = new TicketDal();
        public FrmTicketHistory()
        {
            InitializeComponent();
            StyleFormatCondition styleOverQuota = new StyleFormatCondition();
            styleOverQuota.Condition = FormatConditionEnum.Expression;
            styleOverQuota.Expression = "[Status] = 4";
            styleOverQuota.Appearance.BackColor = Color.LightYellow;
            styleOverQuota.Appearance.BackColor2 = Color.LightYellow;
            styleOverQuota.Appearance.Options.UseBackColor = true;
            styleOverQuota.ApplyToRow = true;
            gvFormDetail.FormatConditions.Add(styleOverQuota);

            StyleFormatCondition styleReject = new StyleFormatCondition();
            styleReject.Condition = FormatConditionEnum.Expression;
            styleReject.Expression = "[Status] = 3";
            styleReject.Appearance.BackColor = Color.Black;
            //styleReject.Appearance.BackColor2 = Color.LightGray;
            styleReject.Appearance.ForeColor = Color.White;
            styleReject.Appearance.Options.UseBackColor = true;
            styleReject.Appearance.Options.UseForeColor = true;
            styleReject.ApplyToRow = true;
            gvFormDetail.FormatConditions.Add(styleReject);
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            txtTodate.DateTime = DateTime.Now;
            //InitData();
            //DateTime fromdate, todate;            
            //fromdate = txtFromdate.DateTime == null ? DateTime.Now : txtFromdate.DateTime;
            //todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
            //fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            //todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
        }

        private void InitData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? new DateTime(DateTime.Now.Year, 1, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Now : txtTodate.DateTime;
            var lstTicketForm = db.GetTicketFormByUserID(fromdate, todate);
            gcFormDetail.DataSource = lstTicketForm;
        }

        private void gvFormDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                var ticketForm = gvFormDetail.GetRow(e.RowHandle) as Ticket_Form;
                                    
                TicketFormModel ticketFormModel = new TicketFormModel(ticketForm);
                if (e.RowHandle == 0)
                    ticketFormModel.canEdit = true;
                else
                    ticketFormModel.canEdit = false;
                var frm = new FrmTicket(ticketFormModel);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }

        private void FrmTicketHistory_Activated(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}