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
using Erms.Utils;
using ERMs.Data;
using Newtonsoft.Json;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSalesForce : ERMs.SharedBase.XtraFormMDIBase
    {
        string key = null;
        public FrmSalesForce()
        {
            InitializeComponent();
        }

        private void FrmSalesForce_Load(object sender, EventArgs e)
        {            
            //System.Threading.Tasks.Task.Run(async () => {                
            //    key = await SalesForceUtils.Authentication();
            //});
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(async () => {
                if (key == null)
                    key = await SalesForceUtils.Authentication();                
                string content = await SalesForceUtils.RetrieveCaseByID(key, "5000l000002R8ylAAC");
                richEditControl1.Text = content;             
            });
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(async () => {
                if (key == null)
                    key = await SalesForceUtils.Authentication();                
                bool content = await SalesForceUtils.DeleteCaseByID(key, "5000l000002PrPCAA0");
                richEditControl1.Text = content.ToString();
            });
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SalesforceModel model = new SalesforceModel();
            //model.ID = "5000l000002PrPMAA0";
            model.Subject = "BCCB test 3";
            model.Description = "Cập nhật bccb test 3";
            model.Priority = "Low";
            model.Web_Aircraft__c = "A350";
            model.Type = "Complaint";
            string jsonOutput = JsonConvert.SerializeObject(model);
            System.Threading.Tasks.Task.Run(async () => {
                if (key == null)
                    key = await SalesForceUtils.Authentication();
                bool content = await SalesForceUtils.UpdateCaseByID(key, "5000l000002PrPMAA0", jsonOutput);
                richEditControl1.Text = content.ToString();
            });            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SalesforceModel model = new SalesforceModel();            
            model.Subject = "Thất lạc hành lý";
            model.Description = "Tổ tv  kiểm tra khoang khách sau chuyến bay , đã tìm thấy 1 túi xách màu đen ( pax 2A)va 1 tui nylon gấu bông trên hộc đựng hành lý 22DEG.Đã giao lại quầy hành lý thất lạc.";
            model.Priority = "Low";
            model.Web_Aircraft__c = "321";
            model.Type = "Feedback";
            model.Origin = "VNCrew";
            model.VNCrew_Ref_Id__c = "31504";
            model.Web_Departure_Date__c = "2018-06-22T09:00:00Z";
            model.Category__c = "On boarding/During Flight";
            model.Sub_category__c = "Others";
            model.SuppliedName = "Đoàn tiếp viên";
            model.SuppliedEmail = "doantiepvien.crew@vietnamairlines.com";
            model.SuppliedPhone = "0123456789";
            model.Web_Flight_Number__c = "VN1263";
            model.Seat_Number__c = "1A";
            model.VNCrew_Name__c = "Bùi Thị Thanh Huyền 5";
            model.VNCrew_Code__c = "0527";            
            string jsonOutput = JsonConvert.SerializeObject(model);
            System.Threading.Tasks.Task.Run(async () => {
                if (key == null)
                    key = await SalesForceUtils.Authentication();
                string id = await SalesForceUtils.InsertCase(key, jsonOutput);
                //richEditControl1.Text = content.ToString();
            });
        }
    }
}