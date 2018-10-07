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
using ERMs.Data.HealthCare;

namespace CrewInfo.Forms.HealthCare
{
    public partial class FrmAddHealthCare : ERMs.SharedBase.XtraFormMDIBase
    {
        List<HealthCareModel> lstHealthCare = null;
        HealthCareDal db = new HealthCareDal();
        FrmManagementHealthCare frmManagementHealthCare = null;
        public FrmAddHealthCare()
        {
            InitializeComponent();            
        }

        public FrmAddHealthCare(List<HealthCareModel> ilstHealthCare, FrmManagementHealthCare iFrmManagementHealthCare)
        {
            InitializeComponent();
            lstHealthCare = ilstHealthCare;
            frmManagementHealthCare = iFrmManagementHealthCare;
        }

        private void FrmAddHealthCare_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = lstHealthCare;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDotKham.Text) ||
                string.IsNullOrEmpty(txtExpired.Text))
            {
                MessageBox.Show("Vui lòng nhập đợt khám và ngày hết hạn!");
            }
            else
            {
                List<HR_HealthCare> lstHR_HealthCare = new List<HR_HealthCare>();
                foreach (HealthCareModel model in lstHealthCare)
                {
                    HR_HealthCare health = new HR_HealthCare();
                    health.CrewID = model.CrewID;
                    health.Expired = txtExpired.DateTime;
                    health.Dotkham = txtDotKham.DateTime;
                    health.Isdeleted = false;
                    health.Created = DateTime.Now;
                    health.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    health.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    lstHR_HealthCare.Add(health);
                }
                db.Add(lstHR_HealthCare);
                MessageBox.Show("Nhập thành công");
                frmManagementHealthCare.UpdateGridView();
                this.Close();
            }
        }
    }
}