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
using CrewInfo.ADONet;
using System.Reflection;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace CrewInfo.Forms.Meeting
{
    public partial class FrmMeeting : ERMs.SharedBase.XtraFormMDIBase
    {
        List<MonthlyMeetingModel> lstMeeting = new List<MonthlyMeetingModel>();
        List<Meeting_Detail> lstMeetingDetail = new List<Meeting_Detail>();
        List<Meeting_Section> lstMeetingSection = new List<Meeting_Section>();
        MeetingDal meetingDal = new MeetingDal();
        dsMetting ds = new dsMetting();
        BindingSource bind = new BindingSource();
        public FrmMeeting()
        {
            InitializeComponent();
        }

        private void FrmMeeting_Load(object sender, EventArgs e)
        {
            lstMeetingSection = meetingDal.GetListMeetingSection();
            
            bind.DataSource = lstMeetingDetail;
            gc.DataSource = bind;
            InitView();
            RefreshData();

            //gridControl1.DataSource = lstMeetingSection;
            //gridView1.BestFitColumns();
            addDataSet();
            rpMeeting xrpt = new rpMeeting();
            xrpt.DataSource = ds;
            xrpt.CreateDocument();
            documentViewer1.DocumentSource = xrpt;            
        }

        private void InitView()
        {
            gv.Columns.Clear();
            //gridView1.Columns.Clear();
            GridColumn col = null;

            RepositoryItemLookUpEdit categoryLookUpEdit = new RepositoryItemLookUpEdit();
            categoryLookUpEdit.DataSource = lstMeetingSection;
            categoryLookUpEdit.DisplayMember = "Title";
            categoryLookUpEdit.ValueMember = "ID";
            categoryLookUpEdit.Columns.Add(new LookUpColumnInfo("Title"));

            col = new GridColumn() { Caption = "Loại", FieldName = "MeetingSection", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col); col.ColumnEdit = categoryLookUpEdit;
            col = new GridColumn() { Caption = "Ngày", FieldName = "Date", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Giá trị", FieldName = "Value", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Giá trị KH", FieldName = "ScheduleValue", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ghi Chú", FieldName = "Note", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);

            //col = new GridColumn() { Caption = "Loại", FieldName = "Title", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gridView1.Columns.Add(col);
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Today.Year, 1, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            //todate = txtTodate.DateTime = txtTodate.EditValue == null ? new DateTime(DateTime.Today.Year, 6, 30) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            lstMeetingDetail.Clear();
            lstMeetingDetail.AddRange(meetingDal.GetMeetingDetail(fromdate, todate));            
            gc.RefreshDataSource();
            gv.BestFitColumns();
            documentViewer1.Refresh();
        }

        private void addDataSet()
        {
            ds.Clear();
            dsMetting.ReportRow reportRow = ds.Report.NewReportRow();
            reportRow.ReportKey = "1";
            ds.Report.AddReportRow(reportRow);

            DateTime todate = txtTodate.DateTime;
            //them so lieu thong thuong vao dataset
            foreach (var meeting in lstMeetingDetail)
            {
                addMeeting(meeting);
            }

            //them so lieu tinh toan vao dataset
            List<dsMetting.IMeetingRow> lstAddedMeetingRow = new List<dsMetting.IMeetingRow>();
            dsMetting.SpecialValueRow specialRow = ds.SpecialValue.NewSpecialValueRow();

            foreach (dsMetting.IMeetingRow row in ds.IMeeting.Rows)
            {
                try
                {
                    string keyTongKhach = "47" + row.Date;
                    switch (row.MeetingSection)
                    {
                        //Tỷ lệ thư phản ánh C/Khách: 122
                        case 44:
                            dsMetting.IMeetingRow rowTongKhach = (dsMetting.IMeetingRow)ds.IMeeting.Rows.Find(keyTongKhach);
                            if (rowTongKhach != null)
                            {

                                dsMetting.IMeetingRow returnValue = ds.IMeeting.NewIMeetingRow();
                                returnValue.Date = row.Date;
                                returnValue.Value = row.Value / rowTongKhach.Value;
                                returnValue.MeetingSection = 122;
                                returnValue.Key = "122" + returnValue.Date;
                                returnValue.ReportKey = "1";
                                lstAddedMeetingRow.Add(returnValue);
                            }
                            break;
                        //Tỷ lệ thư phản ánh Y/Khách: 123
                        case 46:
                            rowTongKhach = (dsMetting.IMeetingRow)ds.IMeeting.Rows.Find(keyTongKhach);
                            if (rowTongKhach != null)
                            {

                                dsMetting.IMeetingRow returnValue = ds.IMeeting.NewIMeetingRow();
                                returnValue.Date = row.Date;
                                returnValue.Value = row.Value / rowTongKhach.Value;
                                returnValue.MeetingSection = 123;
                                returnValue.Key = "123" + returnValue.Date;
                                returnValue.ReportKey = "1";
                                lstAddedMeetingRow.Add(returnValue);
                            }
                            break;
                        //Lấy số chuyến bay cuối cùng và số chuyến bay kế cuối
                        case 1:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.SoChuyenBayOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.SoChuyenBay = row.Value;
                            }
                            catch { }
                            break;                   
                        //Lấy số giờ bay cuối cùng và số giờ bay kế cuối
                        case 4:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.GioBayTVOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.GioBayTV = row.Value;
                            }
                            catch { }
                            break;
                        //Lấy số giờ bay trung bình tv cuối cùng, kế cuối
                        case 5:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.GioBayTBTVOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.GioBayTBTV = row.Value;
                            }
                            catch { }
                            break;
                        //Lấy tv co huu cuối cùng, kế cuối
                        case 10:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.TVCoHuuOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVCoHuu = row.Value;
                            }
                            catch { }
                            break;
                        //Lấy tv nước ngoài cuối cùng, kế cuối
                        case 11:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.TVNuocNgoaiOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVNuocNgoai = row.Value;
                            }
                            catch { }
                            break;
                        //Lấy tv als cuối cùng, kế cuối
                        case 12:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.TVAlsimexcoOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVAlsimexco = row.Value;
                            }
                            catch { }
                            break;
                        //Lấy tv kiêm nhiệm cuối cùng, kế cuối
                        case 13:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                    specialRow.TVVNKiemNhiemOld = row.Value;
                            }
                            catch { }
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVVNKiemNhiem = row.Value;
                            }
                            catch { }
                            break;
                        case 15:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb2NgayBay = row.Value;
                            }
                            catch { }                            
                            break;
                        case 20:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb2GioLamNV = row.Value;
                            }
                            catch { }
                            break;
                        case 27:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb2TongNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 32:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb2NgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 16:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb1NgayBay = row.Value;
                            }
                            catch { }
                            break;
                        case 21:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb1GioLamNV = row.Value;
                            }
                            catch { }
                            break;
                        case 28:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb1TongNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 33:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVTb1NgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 17:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVBNgayBay = row.Value;
                            }
                            catch { }
                            break;
                        case 22:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVBGioLamNV = row.Value;
                            }
                            catch { }
                            break;
                        case 29:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVBTongNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 34:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVBNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 18:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVYNgayBay = row.Value;
                            }
                            catch { }
                            break;
                        case 23:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVYGioLamNV = row.Value;
                            }
                            catch { }
                            break;
                        case 30:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVYTongNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 35:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                    specialRow.TVYNgayCong = row.Value;
                            }
                            catch { }
                            break;
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                        case 67:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                {
                                    dsMetting.BCCBRow bccbRow = (dsMetting.BCCBRow)ds.BCCB.Rows.Find(row.MeetingSection.ToString());
                                    if (bccbRow == null)
                                    {
                                        bccbRow = ds.BCCB.NewBCCBRow();
                                        bccbRow.Key = row.MeetingSection.ToString();
                                        bccbRow.Value = row.Value;
                                        bccbRow.Note = row.Note;
                                        bccbRow.ReportKey = "1";
                                        switch (row.MeetingSection)
                                        {
                                            case 61:
                                                bccbRow.Section = "Suất ăn";
                                                break;
                                            case 62:
                                                bccbRow.Section = "Đồ uống";
                                                break;
                                            case 63:
                                                bccbRow.Section = "Dụng cụ";
                                                break;
                                            case 64:
                                                bccbRow.Section = "Báo chí, giải trí";
                                                break;
                                            case 65:
                                                bccbRow.Section = "VTVP, vệ sinh";
                                                break;
                                            case 66:
                                                bccbRow.Section = "Phục vụ mặt đất";
                                                break;
                                            case 67:
                                                bccbRow.Section = "PKỹ thuật";
                                                break;
                                        }

                                        ds.BCCB.AddBCCBRow(bccbRow);
                                    }
                                    else
                                    {
                                        bccbRow.Value = row.Value;
                                        bccbRow.Note = row.Note;
                                    }
                                }
                            }
                            catch { }
                            break;                            
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86:
                        case 87:
                        case 88:
                        case 89:
                        case 90:
                            try
                            {
                                if (row.Date == todate.AddMonths(-1).ToString("MM/yy"))
                                {                                    
                                    dsMetting.NLTVRow nltvRow = (dsMetting.NLTVRow)ds.NLTV.Rows.Find(row.MeetingSection.ToString());
                                    if (nltvRow == null)
                                    {
                                        nltvRow = ds.NLTV.NewNLTVRow();
                                        nltvRow.Key = row.MeetingSection.ToString();
                                        nltvRow.ValueOld = row.Value;
                                        //nltvRow.Value = row.Value;
                                        nltvRow.Section = lstMeetingSection.Where(i => i.ID == row.MeetingSection).FirstOrDefault().Title;
                                        nltvRow.SectionValue = row.MeetingSection;
                                        nltvRow.ReportKey = "1";
                                        ds.NLTV.AddNLTVRow(nltvRow);
                                    }
                                    else
                                    {
                                        nltvRow.ValueOld = row.Value;
                                        //nltvRow.ValueOld = nltvRow.Value;
                                        //nltvRow.Value = row.Value;
                                        //nltvRow.Note = row.Note;
                                    }
                                }
                                if (row.Date == todate.ToString("MM/yy"))
                                {
                                    dsMetting.NLTVRow nltvRow = (dsMetting.NLTVRow)ds.NLTV.Rows.Find(row.MeetingSection.ToString());
                                    if (nltvRow == null)
                                    {
                                        nltvRow = ds.NLTV.NewNLTVRow();
                                        nltvRow.Key = row.MeetingSection.ToString();
                                        nltvRow.Value = row.Value;
                                        nltvRow.Section = lstMeetingSection.Where(i => i.ID == row.MeetingSection).FirstOrDefault().Title;
                                        nltvRow.SectionValue = row.MeetingSection;
                                        nltvRow.ReportKey = "1";
                                        ds.NLTV.AddNLTVRow(nltvRow);
                                    }
                                    else
                                    {                                        
                                        nltvRow.Value = row.Value;                                        
                                    }
                                }
                            }
                            catch { }
                            break;
                        case 91:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                {                                    
                                    dsMetting.KHDTLopRow khdtLopRow = (dsMetting.KHDTLopRow)ds.KHDTLop.Rows.Find(row.MeetingSection.ToString());
                                    if (khdtLopRow == null)
                                    {
                                        khdtLopRow = ds.KHDTLop.NewKHDTLopRow();
                                        khdtLopRow.Key = row.MeetingSection.ToString();
                                        khdtLopRow.ValueOld = row.Value;
                                        khdtLopRow.Value = row.Value;
                                        khdtLopRow.ValueSchedule = row.ValueSchedule;
                                        khdtLopRow.Section = row.MeetingSection.ToString();
                                        khdtLopRow.SectionValue = row.MeetingSection;
                                        khdtLopRow.Note = row.Note;
                                        khdtLopRow.ReportKey = "1";
                                        ds.KHDTLop.AddKHDTLopRow(khdtLopRow);
                                    }
                                    else
                                    {
                                        //nltvRow.ValueOld = nltvRow.Value;
                                        khdtLopRow.Value = row.Value;
                                        //nltvRow.Note = row.Note;
                                    }
                                }
                            }
                            catch { }
                            break;
                        case 92:
                            try
                            {
                                if (row.Date == todate.ToString("MM/yy"))
                                {
                                    dsMetting.KHDTTVRow khdttvRow = (dsMetting.KHDTTVRow)ds.KHDTTV.Rows.Find(row.MeetingSection.ToString());
                                    if (khdttvRow == null)
                                    {
                                        khdttvRow = ds.KHDTTV.NewKHDTTVRow();
                                        khdttvRow.Key = row.MeetingSection.ToString();
                                        khdttvRow.ValueOld = row.Value;
                                        khdttvRow.Value = row.Value;
                                        khdttvRow.ValueSchedule = row.ValueSchedule;
                                        khdttvRow.Section = row.MeetingSection.ToString();
                                        khdttvRow.SectionValue = row.MeetingSection;
                                        khdttvRow.Note = row.Note;
                                        khdttvRow.ReportKey = "1";
                                        ds.KHDTTV.AddKHDTTVRow(khdttvRow);
                                    }
                                    else
                                    {
                                        //nltvRow.ValueOld = nltvRow.Value;
                                        khdttvRow.Value = row.Value;
                                        //nltvRow.Note = row.Note;
                                    }
                                }
                            }
                            catch { }
                            
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
            }

            try
            {
                specialRow.SoChuyenBayOld = (specialRow.SoChuyenBay - specialRow.SoChuyenBayOld) / 100;
            }
            catch { }            
            try
            {
                specialRow.GioBayTVOld = (specialRow.GioBayTV - specialRow.GioBayTVOld) / 100;
            } catch { }
            try
            {
                specialRow.GioBayTBTVOld = (specialRow.GioBayTBTV - specialRow.GioBayTBTVOld) / 100;
            }
            catch { }
            try
            {
                specialRow.TVCoHuuOld = (specialRow.TVCoHuu - specialRow.TVCoHuuOld) / 100;
            }
            catch { }
            try
            {
                specialRow.TVNuocNgoaiOld = (specialRow.TVNuocNgoai - specialRow.TVNuocNgoaiOld) / 100;
            }
            catch { }
            try
            {
                specialRow.TVAlsimexcoOld = (specialRow.TVAlsimexco - specialRow.TVAlsimexcoOld) / 100;
            }
            catch { }
            try
            {
                specialRow.TVVNKiemNhiemOld = (specialRow.TVVNKiemNhiem - specialRow.TVVNKiemNhiemOld) / 100;
            }
            catch { }
            try
            {
                specialRow.NgayBayNSLDTB = (specialRow.TVTb1NgayBay + specialRow.TVTb2NgayBay + specialRow.TVBNgayBay + specialRow.TVYNgayBay) / 4;
            }
            catch { }
            try
            {
                specialRow.GioLamNVNSLDTB = (specialRow.TVTb1GioLamNV + specialRow.TVTb2GioLamNV + specialRow.TVBGioLamNV + specialRow.TVYGioLamNV) / 4;
            }
            catch { }
            try
            {
                specialRow.NgayCongNSLDTB = (specialRow.TVTb1NgayCong + specialRow.TVTb2NgayCong + specialRow.TVBNgayCong + specialRow.TVYNgayCong) / 4;
            }
            catch { }
            try
            {
                specialRow.TongNgayCongNSLDTB = (specialRow.TVTb1TongNgayCong + specialRow.TVTb2TongNgayCong + specialRow.TVBTongNgayCong + specialRow.TVYTongNgayCong) / 4;
            }
            catch { }

            foreach (var addedrow in lstAddedMeetingRow)
                ds.IMeeting.AddIMeetingRow(addedrow);
            ds.SpecialValue.AddSpecialValueRow(specialRow);
        }

        private void addMeeting(Meeting_Detail meeting)
        {
            try
            {
                dsMetting.IMeetingRow returnValue = (dsMetting.IMeetingRow)ds.IMeeting.Rows.Find(meeting.MeetingSection.ToString() + meeting.Date.Value.ToString("MM/yy"));
                if (returnValue == null)
                {
                    returnValue = ds.IMeeting.NewIMeetingRow();
                    returnValue.Date = meeting.Date.Value.ToString("MM/yy");
                    returnValue.MeetingSection = meeting.MeetingSection;
                    returnValue.Key = meeting.MeetingSection.ToString() + returnValue.Date;
                    returnValue.Note = meeting.Note;
                    returnValue.ReportKey = "1";
                    returnValue.Value = Convert.ToDecimal(meeting.Value);
                    try
                    {
                        returnValue.ValueSchedule = Convert.ToDecimal(meeting.ScheduleValue);
                    }
                    catch { }
                    ds.IMeeting.AddIMeetingRow(returnValue);
                }
                else
                {
                    returnValue.Value += Convert.ToDecimal(meeting.Value);
                    try
                    {
                        returnValue.ValueSchedule += Convert.ToDecimal(meeting.ScheduleValue);
                    }
                    catch { }
                }                             
                switch (meeting.MeetingSection)
                {
                    //Tinh tong thu khen
                    case 40:
                    case 41:
                    case 42:
                        addOrUpdateSum(meeting, 39);
                        break;
                    //Tinh tong thu phan anh
                    case 44:
                    case 45:
                    case 46:
                        addOrUpdateSum(meeting, 43);
                        break;
                    //Tinh tong khach
                    case 48:
                    case 49:
                    case 50:
                        addOrUpdateSum(meeting, 47);
                        break;
                    //Tinh tong TVVN
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                        addOrUpdateSum(meeting, 76);
                        break;
                    //Tinh tong TVNN
                    case 85:
                    case 86:
                    case 87:                    
                        addOrUpdateSum(meeting, 84);
                        break;
                    //Tinh tong TVALS
                    case 89:
                    case 90:                    
                        addOrUpdateSum(meeting, 88);
                        break;
                }
            }
            catch { }
        }

        private void addOrUpdateSum(Meeting_Detail meeting, int meetingSection)
        {
            string key = meetingSection.ToString() + meeting.Date.Value.ToString("MM/yy");
            dsMetting.IMeetingRow row = (dsMetting.IMeetingRow)ds.IMeeting.Rows.Find(key);
            if (row == null)
            {
                dsMetting.IMeetingRow returnValue = ds.IMeeting.NewIMeetingRow();
                returnValue.Date = meeting.Date.Value.ToString("MM/yy");
                returnValue.Value = Convert.ToDecimal(meeting.Value);
                returnValue.MeetingSection = meetingSection;
                returnValue.Key = key;
                returnValue.ReportKey = "1";
                ds.IMeeting.AddIMeetingRow(returnValue);
            }
            else
            {
                row.Value += Convert.ToDecimal(meeting.Value);
            }
        }

        //private void addSoCB(dsMetting ds, Meeting_Detail meeting)
        //{
        //    try
        //    {
        //        dsMetting.SoCBRow returnValue = ds.SoCB.NewSoCBRow();
        //        returnValue.Date = meeting.Date.Value.ToString("MM/yy");
        //        returnValue.Value = Convert.ToInt32(meeting.Value);                
        //        ds.SoCB.AddSoCBRow(returnValue);
        //    }
        //    catch { }
        //}

        //private void addGioBay(dsMetting ds, MonthlyMeetingModel model)
        //{
        //    try
        //    {
        //        dsMetting.GioBayTVRow returnValue = ds.GioBayTV.NewGioBayTVRow();
        //        returnValue.Date = model.Date.ToShortDateString();
        //        returnValue.Value = model.GiaTri;
        //        //PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
        //        //foreach (PropertyInfo destPi in destProperties)
        //        //{
        //        //    PropertyInfo sourcePi = model.GetType().GetProperty(destPi.Name);
        //        //    if (sourcePi == null || sourcePi.GetValue(model, null) == null)
        //        //        continue;
        //        //    destPi.SetValue(returnValue, sourcePi.GetValue(model, null), null);
        //        //}
        //        ds.GioBayTV.AddGioBayTVRow(returnValue);
        //    }
        //    catch { }
        //}

        //private void addSoCB(dsMetting ds, MonthlyMeetingModel model)
        //{
        //    try
        //    {
        //        dsMetting.SoCBRow returnValue = ds.SoCB.NewSoCBRow();
        //        returnValue.Date = model.Date.ToShortDateString();
        //        returnValue.Value = model.GiaTri;
        //        //PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
        //        //foreach (PropertyInfo destPi in destProperties)
        //        //{
        //        //    PropertyInfo sourcePi = model.GetType().GetProperty(destPi.Name);
        //        //    if (sourcePi == null || sourcePi.GetValue(model, null) == null)
        //        //        continue;
        //        //    destPi.SetValue(returnValue, sourcePi.GetValue(model, null), null);
        //        //}
        //        ds.SoCB.AddSoCBRow(returnValue);
        //    }
        //    catch { }
        //}

        //private void addGioBayTB(dsMetting ds, MonthlyMeetingModel model)
        //{
        //    try
        //    {
        //        dsMetting.GioBayTBRow returnValue = ds.GioBayTB.NewGioBayTBRow();
        //        returnValue.Date = model.Date.ToShortDateString();
        //        returnValue.Value = model.GiaTri;
        //        //PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
        //        //foreach (PropertyInfo destPi in destProperties)
        //        //{
        //        //    PropertyInfo sourcePi = model.GetType().GetProperty(destPi.Name);
        //        //    if (sourcePi == null || sourcePi.GetValue(model, null) == null)
        //        //        continue;
        //        //    destPi.SetValue(returnValue, sourcePi.GetValue(model, null), null);
        //        //}
        //        ds.GioBayTB.AddGioBayTBRow(returnValue);
        //    }
        //    catch { }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
            addDataSet();
            rpMeeting xrpt = new rpMeeting();
            xrpt.DataSource = ds;
            xrpt.CreateDocument();
            documentViewer1.DocumentSource = xrpt;            
            documentViewer1.Refresh();
        }

        public static IEnumerable<string> MonthsBetween(
            DateTime startDate,
            DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return iterator.Month.ToString() + iterator.Year.ToString();                
                iterator = iterator.AddMonths(1);
            }
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    dsMetting dsCustom = (dsMetting)ds.Copy();            
        //    rpCustomMeeting xrpt = new rpCustomMeeting();
        //    xrpt.DataSource = dsCustom;
        //    xrpt.Bands[BandKind.Detail].Controls.Clear();

        //    if (cbxOnechart.Checked)
        //    {
        //        XRChart xrChart1 = new DevExpress.XtraReports.UI.XRChart();

        //        xrChart1.Location = new System.Drawing.Point(0, 0);
        //        xrChart1.Name = "xrChart1";

        //        foreach (var rowIndex in gridView1.GetSelectedRows())
        //        {
        //            Meeting_Section row = (Meeting_Section)gridView1.GetRow(rowIndex);

        //            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series(row.Title, DevExpress.XtraCharts.ViewType.Line);
        //            series.ArgumentDataMember = "IMeeting.Date";
        //            DevExpress.XtraCharts.DataFilter dataFilter = new DevExpress.XtraCharts.DataFilter();
        //            dataFilter.Condition = DevExpress.XtraCharts.DataFilterCondition.Equal;
        //            dataFilter.ColumnName = "MeetingSection";
        //            dataFilter.DataType = 1.GetType();
        //            dataFilter.Value = row.ID;
        //            series.DataFilters.Add(dataFilter);
        //            series.ValueDataMembers[0] = "IMeeting.Value";
        //            xrChart1.Series.Add(series);
        //        }


        //        xrChart1.Size = new System.Drawing.Size(650, 360);
        //        xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //        xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;

        //        // Place the chart onto a report footer
        //        xrpt.Bands[BandKind.Detail].Controls.Add(xrChart1);
        //    }
        //    else
        //    {
        //        int i = 0;
        //        foreach (var rowIndex in gridView1.GetSelectedRows())
        //        {
        //            XRChart xrChart1 = new DevExpress.XtraReports.UI.XRChart();
        //            xrChart1.Location = new System.Drawing.Point(0, i * 360);
        //            //xrChart1.Name = "xrChart1";
        //            Meeting_Section row = (Meeting_Section)gridView1.GetRow(rowIndex);

        //            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series(row.Title, DevExpress.XtraCharts.ViewType.Line);
        //            series.ArgumentDataMember = "IMeeting.Date";
        //            DevExpress.XtraCharts.DataFilter dataFilter = new DevExpress.XtraCharts.DataFilter();
        //            dataFilter.Condition = DevExpress.XtraCharts.DataFilterCondition.Equal;
        //            dataFilter.ColumnName = "MeetingSection";
        //            dataFilter.DataType = 1.GetType();
        //            dataFilter.Value = row.ID;
        //            series.DataFilters.Add(dataFilter);
        //            series.ValueDataMembers[0] = "IMeeting.Value";
        //            xrChart1.Series.Add(series);



        //            xrChart1.Size = new System.Drawing.Size(650, 360);
        //            xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
        //            xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;

        //            // Place the chart onto a report footer
        //            xrpt.Bands[BandKind.Detail].Controls.Add(xrChart1);
        //            i++;
        //        }
        //    }

        //    xrpt.CreateDocument();
        //    documentViewer2.DocumentSource = xrpt;
        //    documentViewer2.Refresh();
        //    //documentViewerRibbonController2.DocumentViewer = documentViewer2
        //    //documentViewerRibbonController2.RibbonControl = ribbonControl2;
        //}

        private void btnCustomGraph_Click(object sender, EventArgs e)
        {
            FrmMeetingCustomChart frm = new FrmMeetingCustomChart();
            frm.lstMeetingSection = lstMeetingSection;
            frm.ds = ds;
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }
    }
}