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
using System.IO;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmImportForm : ERMs.SharedBase.XtraFormMDIBase
    {
        Worksheet _worksheet = null;
        FormDal db = new FormDal();
        public FrmImportForm()
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
                //if (Path.GetExtension(file.FileName).ToLower() == ".xls")
                //{
                //    //using (FileStream stream = new FileStream(file.FileName, FileMode.Open))
                //    //{
                //    //    spreadsheetControl1.LoadDocument(stream, DocumentFormat.Xls);
                //    //}
                //    spreadsheetControl1.LoadDocument(file.FileName, DocumentFormat.Xls);
                //}
                //else
                //{
                //    spreadsheetControl1.LoadDocument(file.FileName);
                //}
                IWorkbook workbook = spreadsheetControl1.Document;

                // Access a collection of worksheets.
                WorksheetCollection worksheets = workbook.Worksheets;

                // Access a worksheet by its index.
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
                if (colCount != 5)
                {
                    throw new Exception();
                }
                List<HR_Forms> lstForm = new List<HR_Forms>();
                for (int i = 1; i < rowCount; i++)
                {
                    int id = int.Parse(_worksheet[i, 0].Value.ToString());
                    string status = _worksheet[i, 1].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 1].Value.ToString()) ? "" : _worksheet[i, 1].Value.ToString();
                    string remark = _worksheet[i, 2].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 2].Value.ToString()) ? "" : _worksheet[i, 2].Value.ToString();
                    string timexuly = _worksheet[i, 3].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 3].Value.ToString()) ? "" : _worksheet[i, 3].Value.ToString();
                    string username = _worksheet[i, 4].Value == null || string.IsNullOrWhiteSpace(_worksheet[i, 4].Value.ToString()) ? "" : _worksheet[i, 4].Value.ToString();                    
                    
                    if (status == "" || (status != "OK" && status != "NO"))
                        continue;
                    else
                    {
                        int bStatus = status == "OK" ? 3 : 4;
                        HR_Forms form = db.getFormByFormID(id);
                        if (form != null)
                        {
                            form.Status = bStatus;
                            form.ReplyInfo = string.Format("{0}, Date: {1}, User: {2}", remark, timexuly, username);                            
                            lstForm.Add(form);
                        }
                    }                    
                }
                db.UpdateListForm(lstForm);
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Bạn đã nhập nguyện vọng thành công!", "Nhập nguyện vọng", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.DialogResult = DialogResult.OK;
                this.Close();      
            }
            catch
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("File không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            
        }
    }
}