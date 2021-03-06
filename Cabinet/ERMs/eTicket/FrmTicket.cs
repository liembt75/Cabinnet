﻿using System;
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
using ERMs.Data.Ticket;
using Erms.Utils;
using System.Collections;

namespace eTicket
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
            if (!_ticketForm.canEdit)
            {
                gvFormDetail.OptionsBehavior.Editable = false;
                btnPrint.Visible = false;
                clAdd.Visible = false;
                clRoute.Visible = false;
            }
            switch (_ticketForm.TicketStatus)
            {
                case TicketFormModel.TicketFormStatus.Accept:
                case TicketFormModel.TicketFormStatus.Reject:                
                case TicketFormModel.TicketFormStatus.Processing:
                case TicketFormModel.TicketFormStatus.Done:                
                    gvFormDetail.OptionsBehavior.Editable = false;
                    btnPrint.Visible = false;
                    clAdd.Visible = false;
                    clRoute.Visible = false;                    
                    break;
            }
        }

        private void gvFormDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clAdd")
            {
                var ticketFormDetail = gvFormDetail.GetRow(e.RowHandle) as Ticket_FormDetail;
                var newTicketFormDetail = new Ticket_FormDetail();
                newTicketFormDetail.FamilyID = ticketFormDetail.FamilyID;
                newTicketFormDetail.Fullname = ticketFormDetail.Fullname;
                newTicketFormDetail.Relationship = ticketFormDetail.Relationship;
                newTicketFormDetail.Birthday = ticketFormDetail.Birthday;
                newTicketFormDetail.PID = ticketFormDetail.PID;                
                _ticketForm.LstFormDetail.Insert(e.RowHandle + 1, newTicketFormDetail);
                gcFormDetail.RefreshDataSource();
            }
            if (e.Column.Name == "clRoute")
            {
                var ticketFormDetail = gvFormDetail.GetRow(e.RowHandle) as Ticket_FormDetail;
                _rowSelectedIndex = e.RowHandle;
                var frmRoute = new FrmRoute(_ticketForm, ticketFormDetail);
                if (frmRoute.ShowDialog() == DialogResult.OK)
                {                    
                    ticketFormDetail.Route = frmRoute._routeModel.routeString;
                    ticketFormDetail.TicketCount = frmRoute._routeModel.soVe;
                    ticketFormDetail.Type = frmRoute._routeModel.ticketType.ToString();
                    ticketFormDetail.Base = frmRoute._routeModel.Base;
                }                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {    
            if (_ticketForm.ID == 0 && _ticketForm.HaveWaitingTicket())
            {
                MessageBox.Show("You are having a wating ticket to submit. So you can't create another ticket!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_ticketForm.Sove <= 0)
            {
                MessageBox.Show("Form don't have any tickets yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }            
            else
            {
                if (_ticketForm.OverQuota)
                {
                    MessageBox.Show("Your tickets are over quota.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    //if (MessageBox.Show("Your ticket is over quota. Do you want to continute?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //    return;                    
                }
                StringBuilder fromStatus = new StringBuilder();                
                if (_ticketForm.LstFormDetail.Count > 0)
                {
                    Ticket_FormDetail formDetail = _ticketForm.LstFormDetail[0];
                    fromStatus.Append(formDetail.Fullname);
                    fromStatus.Append(": ");
                    fromStatus.Append(formDetail.Route);
                }
                _ticketForm.Contents = fromStatus.ToString();
                _ticketForm.Save();
                try
                {                   
                    List<TicketFormPrint> lstTicketForm = new List<TicketFormPrint>();
                    lstTicketForm.Add(new TicketFormPrint(_ticketForm));

                    List<TicketFormDetailPrint> lstTicketFormDetail = new List<TicketFormDetailPrint>();
                    int j = 1;
                    for (int i = 0; i < _ticketForm.LstFormDetail.Count; i++)
                    {
                        var formDetail = _ticketForm.LstFormDetail[i];
                        if (!string.IsNullOrEmpty(formDetail.Route))
                        {
                            lstTicketFormDetail.Add(new TicketFormDetailPrint(j, _ticketForm, formDetail));
                            j++;
                        }
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

                    System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "FormVe");
                    string path = string.Format("{0}\\{1}\\{2}_{3}.doc", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FormVe", _ticketForm.employee == null ? "VeGiam" : _ticketForm.employee.CID, DateTime.Now.ToString("ddMMyyhhmmss"));                                        

                    DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\FOMVEGIAM.doc", path);
                    System.Diagnostics.Process.Start(path);                            
                }
                catch { }
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {            
            TicketDal db = new TicketDal();
            db.UpdateEmployeeFromVietnamRedant(ERMs.Sys.ConfigurationSetting.UserInfo.Code);
            _ticketForm = new TicketFormModel();
            InitData();
            MessageBox.Show("Đã cập nhật thông tin nhân viên!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
    }
}