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
using DevExpress.XtraGrid.Columns;
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.Export;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmFormDetailHistory : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketDal db = new TicketDal();
        List<Ticket_FormDetail> lstTicketFormDetail = new List<Ticket_FormDetail>();
        BindingSource bind = new BindingSource();

        public FrmFormDetailHistory()
        {
            InitializeComponent();
        }

        private void FrmFormDetailHistory_Load(object sender, EventArgs e)
        {
            bind.DataSource = lstTicketFormDetail;
            gc.DataSource = bind;
            InitView();
            RefreshData();            
        }

        private void InitView()
        {
            gv.Columns.Clear();            

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            col.Visible = true;
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);            

            col = new GridColumn();
            col.Caption = "MSNVNgườiTạo";
            col.FieldName = "Creatorid";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            col.Fixed = FixedStyle.Left;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NgườiTạo";
            col.FieldName = "Creator";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            col.Fixed = FixedStyle.Left;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "Fullname";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            col.Fixed = FixedStyle.Left;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "QuanHệ";
            col.FieldName = "Relationship";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            col.Fixed = FixedStyle.Left;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NgàySinh";
            col.FieldName = "Birthday";
            col.OptionsColumn.ReadOnly = true;
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);


            col = new GridColumn();
            col.Caption = "Chặng";
            col.FieldName = "Route";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Base";
            col.FieldName = "Base";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Số vé";
            col.FieldName = "TicketCount";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Loại vé";
            col.FieldName = "Type";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "NgàyTạo";
            col.FieldName = "Created";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "IDFormVé";
            col.FieldName = "FormID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID report";
            col.FieldName = "VNAReportID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ghi chú";
            col.FieldName = "Remark";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            col.Fixed = FixedStyle.Right;
            gv.Columns.Add(col);

            gv.OptionsView.EnableAppearanceEvenRow = true;
            //gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsPrint.AutoWidth = false;
            //gv.OptionsPrint.PrintSelectedRowsOnly = true;
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string key = null;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                key = txtSearch.Text.Trim();
            lstTicketFormDetail.Clear();
            lstTicketFormDetail.AddRange(db.GetTicketFormDetail(fromdate, todate, key));
            gc.RefreshDataSource();
            gv.BestFitColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "ChiTietVe.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {                
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;                
                gv.ExportToXlsx(file.FileName);                
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {            
            if (gv.GetFocusedRow() != null)
            {
                if (MessageBox.Show("Bạn có thật sự muốn hũy vé này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Ticket_FormDetail ticketFormDetail = (Ticket_FormDetail)gv.GetFocusedRow();
                    ticketFormDetail.Status = (int)TicketModel.TicketStatus.Reject;
                    db.UpdateTicketFormDetail(ticketFormDetail);
                }                
            }            
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Ticket_FormDetail item = (Ticket_FormDetail)e.Row;
            try
            {
                db.UpdateTicketFormDetail(item);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gv.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}