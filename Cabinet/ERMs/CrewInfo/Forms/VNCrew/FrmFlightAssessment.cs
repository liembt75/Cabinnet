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
using ERMs.Data.Flight;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using ERMs.Data;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightAssessment : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        public FrmFlightAssessment()
        {
            InitializeComponent();
        }

        private void FrmFlightAssessment_Load(object sender, EventArgs e)
        {
            try
            {                
                txtFromdate.DateTime = new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
                txtTodate.DateTime = DateTime.Now;
                cbxView.EditValue = "0";
                //UpdateListFlightAssessment();                
            }
            catch
            { }
        }
        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text)) ||
                (string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text)) ||
                (!string.IsNullOrEmpty(tbxFromAssDate.Text) && string.IsNullOrEmpty(tbxToAssDate.Text)) ||
                (string.IsNullOrEmpty(tbxFromAssDate.Text) && !string.IsNullOrEmpty(tbxToAssDate.Text)))
                {
                    MessageBox.Show("Bạn phải chọn đầy đủ từ ngày tới ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text) &&
                    string.IsNullOrEmpty(tbxFromAssDate.Text) && string.IsNullOrEmpty(tbxToAssDate.Text))
                {
                    MessageBox.Show("Bạn phải chọn ngày bay hoặc ngày đánh giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                UpdateListFlightAssessment();
                SplashScreenManager.CloseForm(false);
            }
            catch { }
        }
        private void UpdateListFlightAssessment()
        {            
            DateTime? fromdate = null, todate = null;
            if (!string.IsNullOrEmpty(tbxFromAssDate.Text) && !string.IsNullOrEmpty(tbxToAssDate.Text))
            {
                fromdate = tbxFromAssDate.DateTime;
                todate = tbxToAssDate.DateTime;
                fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);
                todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromFlightdate = null, toFlightdate = null;
            if (!string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                fromFlightdate = txtFromdate.DateTime;
                toFlightdate = txtTodate.DateTime;
                fromFlightdate = new DateTime(fromFlightdate.Value.Year, fromFlightdate.Value.Month, fromFlightdate.Value.Day, 0, 0, 0, 0);
                toFlightdate = new DateTime(toFlightdate.Value.Year, toFlightdate.Value.Month, toFlightdate.Value.Day, 23, 59, 59, 59);
            }
            switch (cbxView.EditValue.ToString())
            {
                case "0":
                    gcFlightAssessment.DataSource = db.GetListFlightAssessment(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
                case "1":
                    gcFlightAssessment.DataSource = db.GetFlightAssessmentAvgScore(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
                case "2":                    
                    gcFlightAssessment.DataSource = db.GetFlightAssessmentToTal(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
                case "3":
                    gcFlightAssessment.DataSource = db.GetAssessmentAvgScoreByQuestion(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
                case "4":
                    gcFlightAssessment.DataSource = db.GetAssAvgScoreGroupRouting(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
                case "5":                    
                    gcFlightAssessment.DataSource = db.GetAssAvgScoreTypeTVRouting(fromdate, todate, fromFlightdate, toFlightdate);
                    break;
            }
        }

        private void btnExcelDetails_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.FileName = "DanhGiaChatLuongCongViecChiTiet.xlsx";
                file.Title = "Save an Excel";
                file.ShowDialog();

                if (file.FileName.Trim() != "")
                {
                    List<FlightAssessmentFlightAssessmentItemModel> lstFlightAssessmentFlightAssessmentItemModel = new List<FlightAssessmentFlightAssessmentItemModel>();
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    for (int i = 0; i < gvFlightAssessment.GetSelectedRows().Length; i++)
                    {
                        int rowHandle = gvFlightAssessment.GetSelectedRows()[i];
                        API_CR_USP_GetAssessmentList2_Result fligthAssessment = (API_CR_USP_GetAssessmentList2_Result)gvFlightAssessment.GetRow(rowHandle);
                        lstFlightAssessmentFlightAssessmentItemModel.AddRange(FlightAssessmentFlightAssessmentItemModel.ToModel(fligthAssessment, i + 1));
                    }
                    SplashScreenManager.CloseForm(false);                    
                    gcFlightAssessmentDetail.DataSource = lstFlightAssessmentFlightAssessmentItemModel;                    
                    gvFlightAssessmentDetail.ExportToXlsx(file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void btnAvgScore_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.FileName = "DGCLCBTB.xlsx";
                file.Title = "Save an Excel";                

                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    DateTime fromdate, todate;
                    DateTime now = DateTime.Now;
                    fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
                    todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
                    fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
                    todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
                    //gcFlightAssessmentAvgScore.DataSource = db.GetFlightAssessmentAvgScore(fromdate, todate);
                    gvFlightAssessmentAvgScore.BestFitColumns();
                    SplashScreenManager.CloseForm(false);

                    gvFlightAssessmentAvgScore.ExportToXlsx(file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void gvFlightAssessment_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            FlightAssessmentModel flightAssessmentModel = (FlightAssessmentModel)gvFlightAssessment.GetRow(e.RowHandle);
            if (flightAssessmentModel == null) return;
            flightAssessmentModel.Items.Clear();
            flightAssessmentModel.Items.AddRange(db.GetFlightInfoByFlightAssessmentID(flightAssessmentModel.ID));            
            gvFlightAssessment.RefreshData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
                file.Title = "Save an Excel";
                switch (cbxView.EditValue.ToString())
                {
                    case "0":                                                
                        file.FileName = "DanhGiaChatLuongCongViec.xlsx";                        
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvFlightAssessment.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                    case "1":
                        file.FileName = "DanhGiaChatLuongCongViecTrungBinh.xlsx";
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvFAAvgScore.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                    case "2":
                        file.FileName = "DanhGiaChatLuongCongViecSoLuon.xlsx";
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvFATotal.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                    case "3":
                        file.FileName = "DanhGiaChatLuongCongViecTBTheoTieuChi.xlsx";
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvAvgScoreByQuestion.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                    case "4":
                        file.FileName = "DanhGiaChatLuongCongViecTBTheoLDTuyenBay.xlsx";
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvAvgScoreByGroupQuestion.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                    case "5":
                        file.FileName = "DanhGiaChatLuongCongViecTBTheoLoaiTVTuyenBay.xlsx";
                        file.ShowDialog();

                        if (file.FileName.Trim() != "")
                        {
                            gvAvgScoreTypeTVRouting.ExportToXlsx(file.FileName);
                            System.Diagnostics.Process.Start(file.FileName);
                        }
                        break;
                }
                
            }
            catch { }
        }

        private void cbxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcelDetails.Visible = false;
            btnDeleteAssessment.Visible = false;
            gcFlightAssessment.DataSource = null;
            switch (cbxView.EditValue.ToString())
            {
                case "0":
                    btnExcelDetails.Visible = true;
                    USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.A.01");
                    if (crud != null && crud.U.HasValue && crud.U.Value) btnDeleteAssessment.Visible = true;
                    gcFlightAssessment.MainView = gvFlightAssessment;
                    break;
                case "1":                    
                    gcFlightAssessment.MainView = gvFAAvgScore;
                    break;
                case "2":                    
                    gcFlightAssessment.MainView = gvFATotal;
                    break;
                case "3":
                    gcFlightAssessment.MainView = gvAvgScoreByQuestion;
                    break;
                case "4":
                    gcFlightAssessment.MainView = gvAvgScoreByGroupQuestion;
                    break;
                case "5":
                    gcFlightAssessment.MainView = gvAvgScoreTypeTVRouting;
                    break;                    
            }

            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateListFlightAssessment();
            SplashScreenManager.CloseForm(false);
        }

        private void btnDeleteAssessment_Click(object sender, EventArgs e)
        {
            switch (cbxView.EditValue.ToString())
            {
                case "0":
                    if (DialogResult.Yes == MessageBox.Show("Bạn có thực sự muốn xóa các báo cáo chuyến bay này!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        List<FlightAssessmentModel> lstFlightAssessment = new List<FlightAssessmentModel>();
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        for (int i = 0; i < gvFlightAssessment.GetSelectedRows().Length; i++)
                        {
                            int rowHandle = gvFlightAssessment.GetSelectedRows()[i];
                            FlightAssessmentModel fligthAssessment = (FlightAssessmentModel)gvFlightAssessment.GetRow(rowHandle);
                            lstFlightAssessment.Add(fligthAssessment);
                        }
                        if (lstFlightAssessment.Count > 0)
                        {
                            db.deleteFlightAssessment(lstFlightAssessment);
                        }
                        SplashScreenManager.CloseForm(false);
                        MessageBox.Show("Bạn đã xóa thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateListFlightAssessment();
                    }
                    break;
            }
        }
    }
}