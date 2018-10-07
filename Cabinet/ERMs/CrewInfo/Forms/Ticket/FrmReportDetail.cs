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
using Erms.Utils;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmReportDetail : ERMs.SharedBase.XtraFormMDIBase
    {
        private TicketDal db = new TicketDal();
        private Ticket_VNAReport _ticketVNAReport;
        private BindingSource bind = new BindingSource();
        private List<USP_GetFromDetailByReportID_Result> lstFormDetail = new List<USP_GetFromDetailByReportID_Result>();
        public FrmReportDetail(Ticket_VNAReport iTicket_VNAReport)
        {
            _ticketVNAReport = iTicket_VNAReport;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            lbInformation.Text = string.Format("Mã report: {0}\r\nNgày tạo: {1}\r\nNgười tạo: {2}", _ticketVNAReport.FormCode, _ticketVNAReport.FormDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt"), _ticketVNAReport.Creator);
            lstFormDetail = db.GetTicketFormDetailByReportID(_ticketVNAReport.ID);
            bind.DataSource = lstFormDetail;
            gridControl1.DataSource = bind;
            switch (_ticketVNAReport.Status)
            {
                case (int)ReportModel.ReportStatus.Accept:
                case (int)ReportModel.ReportStatus.Done:
                    btnPrint.Visible = false;
                    clDeny.Visible = false;
                    break;
                case (int)ReportModel.ReportStatus.Waiting:
                    clDone.Visible = false;
                    btnDeny.Visible = true;
                    break;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clDeny")
            {
                var ticketFormDetail = gridView1.GetRow(e.RowHandle) as USP_GetFromDetailByReportID_Result;
                if (ticketFormDetail.Status == (int)TicketModel.TicketStatus.Processing)
                {
                    FrmComment frm = new FrmComment();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ticketFormDetail.Status = (int)TicketModel.TicketStatus.Reject;
                        ticketFormDetail.Remark = frm.comment;
                    }
                }
            }
            if (e.Column.Name == "clDone")
            {
                var ticketFormDetail = gridView1.GetRow(e.RowHandle) as USP_GetFromDetailByReportID_Result;
                if (ticketFormDetail.Status == (int)TicketModel.TicketStatus.Accept)
                {
                    ticketFormDetail.Status = (int)TicketModel.TicketStatus.Done;
                    db.UpdateReportWhenDone(ticketFormDetail);
                    gridControl1.RefreshDataSource();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //List<MailUtils.MailType> lstMail = new List<MailUtils.MailType>();
            MailUtils.MailType mailType = new MailUtils.MailType();
            mailType.subject = "Form ve ID";
            mailType.body = "KÍNH MỜI ANH/CHỊ ĐẾN PHÒNG KHHC NHẬN FOM VÉ ID. FOM VÉ ID CÓ GIÁ TRỊ TRONG VÒNG 20 NGÀY KỂ TỪ NGÀY CẤP VÀ KHÔNG ĐƯỢC GIA HẠN, ĐỔI TÊN, ĐỔI HÀNH TRÌNH.";
            foreach (var detail in lstFormDetail)
            {
                if (!string.IsNullOrEmpty(detail.Email) && detail.Status != (int)TicketModel.TicketStatus.Reject)
                {
                    mailType.mailTo.Add(detail.Email);
                }                                              

                if (detail.Status == (int)TicketModel.TicketStatus.Processing)
                    detail.Status = (int)TicketModel.TicketStatus.Accept;
            }
            db.AcceptReport(_ticketVNAReport, lstFormDetail);
            
            MessageBox.Show("Quá trình đã thực hiện hành công!");
            gridControl1.RefreshDataSource();
            btnPrint.Visible = false;
            btnDeny.Visible = false;
            try
            {
                MailUtils.sendMail(mailType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {            
            db.DenyReport(_ticketVNAReport, lstFormDetail);
            MessageBox.Show("Report đã bị hủy!");
            gridControl1.RefreshDataSource();
            this.Close();
        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            FrmSoCongVan frmCongVan = new FrmSoCongVan();
            if (frmCongVan.ShowDialog() == DialogResult.OK)
            {
                _ticketVNAReport.FormCode = frmCongVan.soCV;
                db.UpdateReportFormCode(_ticketVNAReport);
            }                                 
        }
    }
}