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
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.HealthCare
{
    public partial class FrmManagementHealthCare : ERMs.SharedBase.XtraFormMDIBase
    {
        HealthCareDal db = new HealthCareDal();
        SystemDAL dbSystem = new SystemDAL();
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;
        public FrmManagementHealthCare()
        {
            InitializeComponent();
            UpdateGridView();            
        }

        private void FrmManagementHealthCare_Load(object sender, EventArgs e)
        {
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.H.C.01", out create, out read, out update, out delete);
            btnAdd.Visible = create;
            clUpdate.Visible = update;
            clDel.Visible = delete;
        }

        public void UpdateGridView()
        {
            DateTime? fromdate = null, todate = null;
            if (!string.IsNullOrEmpty(txtFromdate.Text))
            {
                fromdate = txtFromdate.DateTime;                
                fromdate = new DateTime(fromdate.Value.Year, fromdate.Value.Month, fromdate.Value.Day, 0, 0, 0, 0);                
            }
            if (!string.IsNullOrEmpty(txtTodate.Text))
            {                
                todate = txtTodate.DateTime;                
                todate = new DateTime(todate.Value.Year, todate.Value.Month, todate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromExpiredDate = null, toExpiredDate = null;
            if (!string.IsNullOrEmpty(txtFromdateFlightDate.Text))
            {
                fromExpiredDate = txtFromdateFlightDate.DateTime;
                fromExpiredDate = new DateTime(fromExpiredDate.Value.Year, fromExpiredDate.Value.Month, fromExpiredDate.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtTodateFlightDate.Text))
            {
                toExpiredDate = txtTodateFlightDate.DateTime;
                toExpiredDate = new DateTime(toExpiredDate.Value.Year, toExpiredDate.Value.Month, toExpiredDate.Value.Day, 23, 59, 59, 59);
            }

            gridControl1.DataSource = db.GetHealthCare(fromdate, todate, fromExpiredDate, toExpiredDate);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<HealthCareModel> lstHealthCareModel = new List<HealthCareModel>();
            for (int i = 0; i < gridView1.GetSelectedRows().Length; i++)
            {
                int rowHandle = gridView1.GetSelectedRows()[i];
                HealthCareModel healthCareModel = (HealthCareModel)gridView1.GetRow(rowHandle);
                lstHealthCareModel.Add(healthCareModel);
            }
            if (lstHealthCareModel.Count <= 0)
            {
                HealthCareModel healthCare = gridView1.GetRow(gridView1.FocusedRowHandle) as HealthCareModel;
                lstHealthCareModel.Add(healthCare);
            }            
            FrmAddHealthCare frm = new FrmAddHealthCare(lstHealthCareModel, this);
            frm.Show();
        }

        private void gridView1_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            HealthCareModel health = (HealthCareModel)gridView1.GetRow(e.RowHandle);
            if (health == null) return;
            health.Items.Clear();
            health.Items.AddRange(db.GetHealthCareByCrewID(health.CrewID));
            gridView1.RefreshData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "DanhSachDotKham.xlsx";
            file.Title = "Save an Excel";
            file.ShowDialog();

            if (file.FileName.Trim() != "")
            {                
                gridView1.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clUpdate")
            {
                List<HealthCareModel> lstHealthCareModel = new List<HealthCareModel>();
                HealthCareModel health = (HealthCareModel)gridView1.GetRow(e.RowHandle);
                if (health.IDDotKham != null)
                {
                    lstHealthCareModel.Add(health);
                    FrmUpdateHealthCare frm = new FrmUpdateHealthCare(lstHealthCareModel, this);                    
                    frm.Show();    
                }
            }
            else if (e.Column.Name == "clDel")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa đợt khám này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    HealthCareModel health = (HealthCareModel)gridView1.GetRow(e.RowHandle);
                    health.Modified = DateTime.Now;
                    health.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    health.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    db.DeleteHeathCareByHealthID(health);
                    MessageBox.Show("Xóa đợt khám thành công!");
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    UpdateGridView();
                    SplashScreenManager.CloseForm(false);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if ((!string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text)) ||
            //    (string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text)) ||
            //    (!string.IsNullOrEmpty(txtFromdateFlightDate.Text) && string.IsNullOrEmpty(txtTodateFlightDate.Text)) ||
            //    (string.IsNullOrEmpty(txtFromdateFlightDate.Text) && !string.IsNullOrEmpty(txtTodateFlightDate.Text)))
            //{
            //    MessageBox.Show("Bạn phải chọn đầy đủ từ ngày tới ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtFromdate.Text) && string.IsNullOrEmpty(txtTodate.Text) &&
            //    string.IsNullOrEmpty(txtFromdateFlightDate.Text) && string.IsNullOrEmpty(txtTodateFlightDate.Text))
            //{
            //    MessageBox.Show("Bạn phải chọn ngày bay hoặc ngày báo cáo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            UpdateGridView();
            SplashScreenManager.CloseForm(false);
        }
    }
}