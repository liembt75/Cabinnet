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
using ERMs.Data.HealthCare;

namespace CrewInfo.Forms.HealthCare
{
    public partial class FrmUpdateHealthCare : ERMs.SharedBase.XtraFormMDIBase
    {
        List<HealthCareModel> lstHealthCare = null;
        HealthCareDal db = new HealthCareDal();
        FrmManagementHealthCare frmManagementHealthCare = null;
        public FrmUpdateHealthCare(List<HealthCareModel> ilstHealthCare, FrmManagementHealthCare iFrmManagementHealthCare)
        {
            InitializeComponent();
            lstHealthCare = ilstHealthCare;
            gridControl1.DataSource = lstHealthCare;
            frmManagementHealthCare = iFrmManagementHealthCare;
            txtDotKham.EditValue = lstHealthCare[0].Dotkham.Value;
            txtExpired.EditValue = lstHealthCare[0].Expired.Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDotKham.Text) ||
                string.IsNullOrEmpty(txtExpired.Text))
            {
                MessageBox.Show("Vui lòng nhập đợt khám và ngày hết hạn!");
            }
            else
            {
                HealthCareModel model = lstHealthCare[0];
                model.Dotkham = txtDotKham.DateTime;
                model.Expired = txtExpired.DateTime;
                model.Modified = DateTime.Now;
                model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                db.Update(model);
                frmManagementHealthCare.UpdateGridView();
                this.Close();
                //List<HR_HealthCare> lstHR_HealthCare = new List<HR_HealthCare>();
                //foreach (HealthCareModel model in lstHealthCare)
                //{
                //    HR_HealthCare health = new HR_HealthCare();
                //    health.CrewID = model.CrewID;
                //    health.Expired = txtExpired.DateTime;
                //    health.Dotkham = txtDotKham.DateTime;
                //    health.Isdeleted = false;
                //    lstHR_HealthCare.Add(health);
                //}
                //db.Add(lstHR_HealthCare);
                //MessageBox.Show("Nhập thành công");
                //this.Close();
            }
        }
    }
}