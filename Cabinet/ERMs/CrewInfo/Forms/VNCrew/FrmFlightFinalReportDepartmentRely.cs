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
using DevExpress.XtraEditors.Controls;
using ERMs.Data.Flight;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportDepartmentRely : ERMs.SharedBase.XtraFormMDIBase
    {
        public API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = null;
        FlightDal db = new FlightDal();
        public FrmFlightFinalReportDetail frmFD = null;
        public FrmFlightFinalReportDepartmentRely()
        {
            InitializeComponent();
        }

        private void FrmFlightFinalReportDepartmentRely_Load(object sender, EventArgs e)
        {
            List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = db.GetFlightFinalReportCategory();
            lookUpEditCategory.Properties.DataSource = lstCategory;
            lookUpEditCategory.Properties.ValueMember = "SubCategoryID";
            lookUpEditCategory.Properties.DisplayMember = "SubCategory";
            lookUpEditCategory.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            lookUpEditDepartment.Properties.DataSource = db.GetDepartment();
            lookUpEditDepartment.Properties.ValueMember = "ID";
            lookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
            lookUpEditDepartment.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            lookUpEditDepartment.EditValue = flightFinalReportDepartment.DepartmentID;
            lookUpEditCategory.EditValue = flightFinalReportDepartment.CategoryID;
            memoEditNote.Text = flightFinalReportDepartment.Note;
        }

        private void btnRely_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoRelyEdit.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung vào ô trả lời!");
                return;
            }
            flightFinalReportDepartment.ReplyInfo = memoRelyEdit.Text;
            flightFinalReportDepartment.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
            flightFinalReportDepartment.Replied = DateTime.Now;            
            flightFinalReportDepartment.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
            db.UpdateFlightFinalReportDepartment(flightFinalReportDepartment);
            frmFD.UpdateDepartment();
            MessageBox.Show("Đã trả lời thành công!");
            this.Close();
        }
    }
}