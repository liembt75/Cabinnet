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
using ERMs.Data;
using DevExpress.XtraEditors.Controls;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportAddDepartment : ERMs.SharedBase.XtraFormMDIBase
    {
        public int ID = -1;
        public FrmFlightFinalReportDetail frmFD = null;

        FlightDal db = new FlightDal();
        public FrmFlightFinalReportAddDepartment()
        {
            InitializeComponent();
        }

        private void FrmFlightFinalReportAddDepartment_Load(object sender, EventArgs e)
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

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoEditNote.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung vào ô đề nghị!");
                return;
            }
            CR_Flight_FinalReport_Department fd = new CR_Flight_FinalReport_Department();
            fd.FinalReportID = ID;
            fd.DepartmentID = (int)lookUpEditDepartment.EditValue;
            fd.CategoryID = (int)lookUpEditCategory.EditValue;
            fd.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
            fd.Created = DateTime.Now;
            fd.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
            fd.Note = memoEditNote.Text;
            db.AddFlightFinalReportDepartment(fd);
            frmFD.UpdateDepartment();                        
            MessageBox.Show("Thêm phòng ban thành công!");
            //this.Close();
        }
    }
}