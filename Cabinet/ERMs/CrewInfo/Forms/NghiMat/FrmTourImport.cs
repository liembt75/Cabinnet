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

namespace CrewInfo.Forms.NghiMat
{
    public partial class FrmTourImport : ERMs.SharedBase.XtraFormMDIBase
    {
        Worksheet _worksheet = null;
        TourDal tourDal = new TourDal();
        public FrmTourImport()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Microsoft Excel|*.xlsx;*.xls";
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
                if (colCount != 7)
                {
                    throw new Exception();
                }

                List<TourRegister2018> lstTour = new List<TourRegister2018>();
                List<TourRegister2018> lstExistTour = new List<TourRegister2018>();
                List<TourRegister2018> lstUserNotPermitTour = new List<TourRegister2018>();
                for (int i = 1; i < rowCount; i++)
                {
                    TourRegister2018 tour = new TourRegister2018();
                    tour.IDTour = int.Parse(_worksheet[i, 0].Value.ToString());
                    tour.MSNV = _worksheet[i, 1].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 1].Value.ToString()) ? "" : _worksheet[i, 1].Value.ToString();                    
                    string ho = _worksheet[i, 2].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 2].Value.ToString()) ? "" : _worksheet[i, 2].Value.ToString();
                    string ten = _worksheet[i, 3].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 3].Value.ToString()) ? "" : _worksheet[i, 3].Value.ToString();
                    tour.Mail = tour.MSNV;
                    tour.HoTen = ho + " " + ten;
                    tour.QuanHe = _worksheet[i, 4].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 4].Value.ToString()) ? "" : _worksheet[i, 4].Value.ToString();
                    tour.CMND = _worksheet[i, 5].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 5].Value.ToString()) ? "" : _worksheet[i, 5].Value.ToString();
                    tour.NgaySinh = _worksheet[i, 6].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 6].Value.ToString()) ? "" : _worksheet[i, 6].Value.ToString();
                    tour.AnThongTin = false;
                    tour.IsDelete = false;
                    tour.TinhTrang = 0;
                    tour.NgayCapNhat = DateTime.Now;
                    tour.NguoiCapNhat = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;

                    if (tourDal.UserPermit(tour))
                    {
                        lstTour.Add(tour);
                    }
                    else
                    {
                        lstUserNotPermitTour.Add(tour);
                    }

                    if (!tourDal.TourExist(tour))
                        lstTour.Add(tour);
                    else
                        lstExistTour.Add(tour);
                }
                if (lstUserNotPermitTour.Count > 0 || lstExistTour.Count > 0)
                {
                    string loi = "";
                    foreach (var userNotPermit in lstUserNotPermitTour)
                    {
                        loi += string.Format("- MSNV: {0}, Họ và tên: {1}, Quan hệ: {2} . Nhân viên có msnv này không đủ tiêu chuẩn để nghỉ mát \r\n", userNotPermit.MSNV, userNotPermit.HoTen, userNotPermit.QuanHe);
                    }
                    foreach (var tourExist in lstExistTour)
                    {
                        loi += string.Format("- MSNV: {0}, Họ và tên: {1}, Quan hệ: {2} đã tồn tại \r\n", tourExist.MSNV, tourExist.HoTen, tourExist.QuanHe);
                    }
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show(loi);
                }                
                else
                {
                    tourDal.AddListTourRegister(lstTour);
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Bạn đã nhập nguyện vọng thành công!", "Nhập nguyện vọng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("File không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}