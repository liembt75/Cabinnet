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
using DevExpress.Spreadsheet;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using ERMs.Data;
using ERMs.Data.Flight;

namespace CrewInfo.Forms.VNCrew
{    
    public partial class FrmDutyFreeImport : DevExpress.XtraEditors.XtraForm
    {
        Worksheet _worksheet = null;
        FlightDal db = new FlightDal();
        public FrmDutyFreeImport()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "CSV file|*.csv";
            file.ShowDialog();

            if (file.FileName.Trim() != "")
            {
                spreadsheetControl1.LoadDocument(file.FileName);
                IWorkbook workbook = spreadsheetControl1.Document;
                WorksheetCollection worksheets = workbook.Worksheets;
                _worksheet = workbook.Worksheets[0];
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            Range usedRange = _worksheet.GetUsedRange();
            int colCount = usedRange.ColumnCount;
            int rowCount = usedRange.RowCount;
            try
            {
                if (colCount != 14)
                {
                    throw new Exception();
                }

                //List<TourRegister2018> lstTour = new List<TourRegister2018>();
                //List<TourRegister2018> lstExistTour = new List<TourRegister2018>();
                //List<TourRegister2018> lstUserNotPermitTour = new List<TourRegister2018>();
                List<CR_Flight_Dutyfree> lstUpdatedDutyFree = new List<CR_Flight_Dutyfree>();
                CR_Flight_Dutyfree dutyFree = null;
                CR_FlightInfo flightInfo = null;
                for (int i = 1; i < rowCount; i++)
                {
                    dutyFree = null;
                    flightInfo = null;
                    string flightNo = _worksheet[i, 7].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 7].Value.ToString()) ? "" : "VN" + _worksheet[i, 7].Value.ToString();
                    string routeFrom = _worksheet[i, 8].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 8].Value.ToString()) ? "" : _worksheet[i, 8].Value.ToString();
                    string routeTo = _worksheet[i, 9].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 9].Value.ToString()) ? "" : _worksheet[i, 9].Value.ToString();
                    DateTime? date = null;
                    if (_worksheet[i, 10].Value != null && _worksheet[i, 10].Value.IsDateTime)
                      date = _worksheet[i, 10].Value.DateTimeValue;                    
                    string msnv = _worksheet[i, 11].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 11].Value.ToString()) ? "" : _worksheet[i, 11].Value.ToString();
                    string tennv = _worksheet[i, 12].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 12].Value.ToString()) ? "" : _worksheet[i, 12].Value.ToString();
                    double sale = 0;
                    if (_worksheet[i, 13].Value != null && _worksheet[i, 13].Value.IsNumeric)
                        sale = _worksheet[i, 13].Value.NumericValue;                    
                    if (!string.IsNullOrWhiteSpace(flightNo) && !string.IsNullOrEmpty(routeFrom) && !(string.IsNullOrEmpty(routeTo) && date != null)) {
                        flightInfo = db.GetFlightByCondition(flightNo, routeFrom + "-" + routeTo, date.Value);
                    }                    
                    if (flightInfo != null)
                    {
                        dutyFree = db.GetDutyFreeByFlightID(flightInfo.FlightID);
                    }
                    if (dutyFree != null)
                    {
                        CR_Flight_Dutyfree dutyFreeExit = lstUpdatedDutyFree.Where(j => j.FlightID == dutyFree.FlightID).FirstOrDefault();
                        if (dutyFreeExit == null)
                        {
                            dutyFree.Total = sale;                            
                            dutyFree.Remark = tennv;
                            dutyFree.Modified = DateTime.Now;
                            dutyFree.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            dutyFree.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            lstUpdatedDutyFree.Add(dutyFree);
                        }
                        else
                        {
                            dutyFreeExit.Total += sale;
                            if (!string.IsNullOrWhiteSpace(dutyFreeExit.Remark) && !string.IsNullOrWhiteSpace(tennv))
                                dutyFreeExit.Remark += ";";
                            dutyFreeExit.Remark += tennv;
                        }
                    }                    
                }
                db.UpdateListDutyFree(lstUpdatedDutyFree);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Bạn đã nhập doanh thu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
                //if (lstUserNotPermitTour.Count > 0 || lstExistTour.Count > 0)
                //{
                //    string loi = "";
                //    foreach (var userNotPermit in lstUserNotPermitTour)
                //    {
                //        loi += string.Format("- MSNV: {0}, Họ và tên: {1}, Quan hệ: {2} . Nhân viên có msnv này không đủ tiêu chuẩn để nghỉ mát \r\n", userNotPermit.MSNV, userNotPermit.HoTen, userNotPermit.QuanHe);
                //    }
                //    foreach (var tourExist in lstExistTour)
                //    {
                //        loi += string.Format("- MSNV: {0}, Họ và tên: {1}, Quan hệ: {2} đã tồn tại \r\n", tourExist.MSNV, tourExist.HoTen, tourExist.QuanHe);
                //    }
                //    SplashScreenManager.CloseForm(false);
                //    MessageBox.Show(loi);
                //}
                //else
                //{
                //    tourDal.AddListTourRegister(lstTour);
                //    SplashScreenManager.CloseForm(false);
                //    MessageBox.Show("Bạn đã nhập nguyện vọng thành công!", "Nhập nguyện vọng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
            }
            catch
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("File không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}