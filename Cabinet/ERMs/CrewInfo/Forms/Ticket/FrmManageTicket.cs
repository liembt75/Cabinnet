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
    public partial class FrmManageTicket : ERMs.SharedBase.XtraFormMDIBase
    {
        List<Ticket_Form> _lstTicketForm = new List<Ticket_Form>();
        TicketDal db = new TicketDal();
        public FrmManageTicket()
        {
            InitializeComponent();
            StyleFormatCondition styleOverQuota = new StyleFormatCondition();            
            styleOverQuota.Condition = FormatConditionEnum.Expression;
            styleOverQuota.Expression = "[Status] = 4";
            styleOverQuota.Appearance.BackColor = Color.LightYellow;
            styleOverQuota.Appearance.BackColor2 = Color.LightYellow;
            styleOverQuota.Appearance.Options.UseBackColor = true;
            styleOverQuota.ApplyToRow = true;
            gridView1.FormatConditions.Add(styleOverQuota);
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            txtTodate.DateTime = DateTime.Now;
            //InitData();
        }

        private void InitData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? new DateTime(DateTime.Now.Year, 1, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Now : txtTodate.DateTime;
            _lstTicketForm = db.GetTicketFormByStatus(TicketFormModel.TicketFormStatus.Waiting, fromdate, todate);
            _lstTicketForm.AddRange(db.GetTicketFormByStatus(TicketFormModel.TicketFormStatus.OverQuota, fromdate, todate));
            gridControl1.DataSource = _lstTicketForm;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "ID")
            {
                var ticketForm = gridView1.GetRow(e.RowHandle) as Ticket_Form;

                TicketFormModel ticketFormModel = new TicketFormModel(ticketForm);
                //ticketFormModel.canEdit = true;                
                var frm = new FrmTicket(ticketFormModel);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }

        private void btnThemForm_Click(object sender, EventArgs e)
        {
            var frm = new FrmAddTicket();
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void FrmManageTicket_Activated(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}