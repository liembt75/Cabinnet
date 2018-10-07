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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.Meeting
{
    public partial class FrmMeetingData : ERMs.SharedBase.XtraFormMDIBase
    {
        List<MonthlyMeetingModel> lstMeeting = new List<MonthlyMeetingModel>();
        List<Meeting_Detail> lstMeetingDetail = new List<Meeting_Detail>();
        List<Meeting_Section> lstMeetingSection = new List<Meeting_Section>();
        List<Meeting_Section> lstMeetingSectionAuthority = new List<Meeting_Section>();
        MeetingDal meetingDal = new MeetingDal();        
        BindingSource bind = new BindingSource();
        public FrmMeetingData()
        {
            InitializeComponent();
        }

        private void FrmMeetingData_Load(object sender, EventArgs e)
        {
            lstMeetingSection = meetingDal.GetListMeetingSection();            
            foreach (var meetingSection in lstMeetingSection)
            {
                if (!string.IsNullOrWhiteSpace(meetingSection.Activity))
                {
                    string[] arrActivity = meetingSection.Activity.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var activity in arrActivity)
                    {
                        USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID(activity);
                        if (crud != null && crud.R.HasValue && crud.R.Value)
                        {
                            lstMeetingSectionAuthority.Add(meetingSection);
                            break;
                        }
                    }
                }
            }
            bind.DataSource = lstMeetingDetail;
            gc.DataSource = bind;
            InitView();
            RefreshData();
        }

        private void InitView()
        {            
            gv.Columns.Clear();
            GridColumn col = null;

            RepositoryItemLookUpEdit categoryLookUpEdit = new RepositoryItemLookUpEdit();
            categoryLookUpEdit.DataSource = lstMeetingSection;
            categoryLookUpEdit.DisplayMember = "Title";
            categoryLookUpEdit.ValueMember = "ID";
            categoryLookUpEdit.Columns.Add(new LookUpColumnInfo("Title"));

            col = new GridColumn() { Caption = "Loại", FieldName = "MeetingSection", Visible = true }; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col); col.ColumnEdit = categoryLookUpEdit;
            col = new GridColumn() { Caption = "Ngày", FieldName = "Date", Visible = true }; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Giá trị", FieldName = "Value", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Giá trị KH", FieldName = "ScheduleValue", Visible = true }; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Ghi Chú", FieldName = "Note", Visible = true, Width = 200 }; gv.Columns.Add(col);
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            lstMeetingDetail.Clear();
            foreach (var meetingSection in lstMeetingSectionAuthority)
            {
                lstMeetingDetail.AddRange(meetingDal.GetMeetingDetail(fromdate, todate, meetingSection.ID));
            }
            lstMeetingDetail = lstMeetingDetail.OrderByDescending(i => i.ID).ToList();
            gc.RefreshDataSource();
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName != "Note")
                    column.BestFit();
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void gv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //gv.SetRowCellValue(e.RowHandle, "Active", true);
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Meeting_Detail item = (Meeting_Detail)e.Row;
            if (item.MeetingSection == 0)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["MeetingSection"], "Loại không được để trống.");
            }
            if (item.Date == null)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Date"], "Ngày không được để trống.");
            }
            if (item.Value == null)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["Date"], "Giá trị không được để trống.");
            }
            if (e.Valid)
            {
                DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();                
                try
                {
                    Meeting_Detail returnItem = meetingDal.UpdateMeetingDetail(item);
                    item.ID = returnItem.ID;
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }            
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
}