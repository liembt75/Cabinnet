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
using System.Collections;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmTicket : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketFormModel _ticketForm = null;
        int _rowSelectedIndex = 0;
        public FrmTicket(TicketFormModel ticketFormModel)
        {
            _ticketForm = ticketFormModel;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            if (_ticketForm.employee != null)
            {
                lbInformation.Text = String.Format("Tên tôi là: {0}\r\nNgày tháng năm sinh:{1}\r\nChức danh: {2}\r\nNơi công tác: {3}\r\nSố vé ID90 còn lại: {4}\r\nSố vé ID75 còn lại: {5}\r\n",
                                                    _ticketForm.employee.Fullname,
                                                    _ticketForm.employee.Birthday == null ? "" : _ticketForm.employee.Birthday.Value.ToString("dd/MM/yyyy"),
                                                    _ticketForm.employee.JobTitle,
                                                    "Đoàn tiếp viên",
                                                    _ticketForm.ticketQuotaRemain.ID90,
                                                    _ticketForm.ticketQuotaRemain.ID75);

            }
            if (_ticketForm.LstFormDetail.Count > 0)
            {
                gcFormDetail.DataSource = _ticketForm.LstFormDetail;
            }                        
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            FrmComment frm = new FrmComment();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ticketForm.Reject(frm.comment);
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {            
            if (_ticketForm.Sove <= 0)
            {
                MessageBox.Show("Form don't have any tickets yet!", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                if (_ticketForm.OverQuota)
                {
                    if (MessageBox.Show("Your ticket is over quota. Do you want to continute?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                _ticketForm.Save();
                try
                {
                    List<TicketFormPrint> lstTicketForm = new List<TicketFormPrint>();
                    lstTicketForm.Add(new TicketFormPrint(_ticketForm));

                    List<TicketFormDetailPrint> lstTicketFormDetail = new List<TicketFormDetailPrint>();
                    for (int i = 0; i < _ticketForm.LstFormDetail.Count; i++)
                    {
                        var formDetail = _ticketForm.LstFormDetail[i];
                        if (!string.IsNullOrEmpty(formDetail.Route))
                            lstTicketFormDetail.Add(new TicketFormDetailPrint(i + 1, _ticketForm, formDetail));
                    }

                    DataSet ds = new DataSet();
                    DataTable dtFlightFinalReport = new DataTable("fr");
                    ListUtils.LoadRows(dtFlightFinalReport, lstTicketForm);
                    ds.Tables.Add(dtFlightFinalReport);


                    DataTable dtFlightCrew = new DataTable("df");
                    ListUtils.LoadRows(dtFlightCrew, lstTicketFormDetail);
                    ds.Tables.Add(dtFlightCrew);

                    List<DictionaryEntry> list = new List<DictionaryEntry>
                    {
                        new DictionaryEntry("fr", String.Empty),
                        new DictionaryEntry("df", "FormID = %fr.ID%")
                    };

                    DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\FOMVEGIAM.doc", "VeGiam.doc");
                    System.Diagnostics.Process.Start("VeGiam.doc");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}