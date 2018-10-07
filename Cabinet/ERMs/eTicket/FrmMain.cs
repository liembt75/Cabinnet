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

namespace eTicket
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
            TicketFormModel ticketFormModel = new TicketFormModel();            
            var frm = new FrmTicket(ticketFormModel);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TicketFormModel ticketFormModel = new TicketFormModel();
            var frm = new FrmTicket(ticketFormModel);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmTicketHistory();
            frm.MdiParent = this;
            frm.Show();            
        }

        private void btnFormHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmFormHistory();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}