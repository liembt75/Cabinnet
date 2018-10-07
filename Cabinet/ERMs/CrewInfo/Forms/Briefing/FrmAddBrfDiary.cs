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

namespace CrewInfo.Forms.Briefing
{
    public partial class FrmAddBrfDiary : DevExpress.XtraEditors.XtraForm
    {
        BriefingDal db = new BriefingDal();
        List<SysAccBrfDiaryModel> mLstSysAcc = null;
        BR_BriefingDiary mDiary = null;

        public FrmAddBrfDiary(List<SysAccBrfDiaryModel> lstSysAcc, BR_BriefingDiary diary)
        {
            InitializeComponent();
            mLstSysAcc = lstSysAcc;
            mDiary = diary;            
        }



        private void FrmAddBrfDiary_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> hinhThucDic = new Dictionary<int, string>();
            hinhThucDic.Add(0, "Nhắc nhở, yêu cầu khắc phục");
            hinhThucDic.Add(1, "Báo cáo vi phạm");
            hinhThucDic.Add(2, "Đình bay");
            hinhThucDic.Add(3, "Trễ briefing");
            cbxHinhThuc.DataSource = new BindingSource(hinhThucDic, null);
            cbxHinhThuc.DisplayMember = "Value";
            cbxHinhThuc.ValueMember = "Key";
            cbxHinhThuc.SelectedIndex = 0;

            Dictionary<string, string> baseDic = new Dictionary<string, string>();
            baseDic.Add("Nam", "Nam");
            baseDic.Add("Bắc", "Bắc");
            cbxBase.DataSource = new BindingSource(baseDic, null);
            cbxBase.DisplayMember = "Value";
            cbxBase.ValueMember = "Key";
            cbxBase.SelectedIndex = 0;

            lookUpEditEmployee.Properties.DataSource = mLstSysAcc;
            lookUpEditEmployee.Properties.DisplayMember = "FirstNameVn";
            lookUpEditEmployee.Properties.ValueMember = "FirstNameVn";

            if (mDiary != null)
            {
                this.Text = "Cập nhật nhật ký";
                button1.Text = "Cập nhật";
                dtpNgay.Value = mDiary.Ngay;
                tbxMaNV.Text = mDiary.manv;
                tbxHoTen.Text = mDiary.hoten;
                lookUpEditEmployee.EditValue = lookUpEditEmployee.Properties.GetKeyValueByDisplayText(mDiary.ten);
                tbxLienDoi.Text = mDiary.bophan;
                tbxChuyenBay.Text = mDiary.chuyenbay;
                tbxNoiDung.Text = mDiary.noidung;
                cbxHinhThuc.SelectedValue = mDiary.hinhthuc;
                cbxBase.SelectedValue = mDiary.Base == null ? "Nam" : mDiary.Base;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookUpEditEmployee_EditValueChanged(object sender, EventArgs e)
        {                       
            if (lookUpEditEmployee.EditValue != null)
            {            
                tbxMaNV.Text = lookUpEditEmployee.GetColumnValue("CrewID") == null ? "" : lookUpEditEmployee.GetColumnValue("CrewID").ToString();
                tbxLienDoi.Text = lookUpEditEmployee.GetColumnValue("Group") == null ? "" : lookUpEditEmployee.GetColumnValue("Group").ToString();
                tbxHoTen.Text = lookUpEditEmployee.GetColumnValue("name_tv") == null ? "" : lookUpEditEmployee.GetColumnValue("name_tv").ToString().Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbError = new StringBuilder();
            if (lookUpEditEmployee.EditValue == null)
            {
                sbError.Append("- Vui lòng nhập tên.\n");
            }
            if (string.IsNullOrWhiteSpace(tbxLienDoi.Text))
            {
                sbError.Append("- Vui lòng nhập liên đội.\n");
            }
            if (string.IsNullOrWhiteSpace(tbxChuyenBay.Text))
            {
                sbError.Append("- Vui lòng nhập chuyến bay.\n");
            }
            if (string.IsNullOrWhiteSpace(tbxNoiDung.Text))
            {
                sbError.Append("- Vui lòng nhập nội dung.\n");
            }
            if (sbError.Length != 0)
            {
                MessageBox.Show(sbError.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (mDiary == null)
                {
                    BR_BriefingDiary nhatky = new BR_BriefingDiary();
                    nhatky.Ngay = dtpNgay.Value;
                    nhatky.manv = tbxMaNV.Text;
                    nhatky.hoten = tbxHoTen.Text;
                    nhatky.ten = lookUpEditEmployee.EditValue.ToString().Trim();
                    nhatky.bophan = tbxLienDoi.Text.Trim();
                    nhatky.chuyenbay = tbxChuyenBay.Text.Trim();
                    nhatky.noidung = tbxNoiDung.Text.Trim();
                    int iHinhThuc = nhatky.hinhthuc = (int)cbxHinhThuc.SelectedValue;                    
                    switch (iHinhThuc)
                    {
                        case 0:
                            nhatky.hinhthuc1 = "X";
                            break;
                        case 1:
                            nhatky.hinhthuc2 = "X";
                            break;
                        case 2:
                            nhatky.hinhthuc3 = "X";
                            break;
                        case 3:
                            nhatky.hinhthuc4 = "X";
                            break;
                    }
                    nhatky.Base = cbxBase.SelectedValue.ToString();
                    nhatky.CreatedDate = DateTime.Now;
                    nhatky.UpdatedDate = DateTime.Now;
                    nhatky.UpdatedBy = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;
                    nhatky.Status = 0;
                    db.UpdateDiary(nhatky);
                    MessageBox.Show("Bạn đã nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    mDiary.Ngay = dtpNgay.Value;
                    mDiary.manv = tbxMaNV.Text;
                    mDiary.hoten = tbxHoTen.Text;
                    mDiary.ten = lookUpEditEmployee.EditValue.ToString().Trim();
                    mDiary.bophan = tbxLienDoi.Text.Trim();
                    mDiary.chuyenbay = tbxChuyenBay.Text.Trim();
                    mDiary.noidung = tbxNoiDung.Text.Trim();
                    int iHinhThuc = mDiary.hinhthuc = (int)cbxHinhThuc.SelectedValue;
                    switch (iHinhThuc)
                    {
                        case 0:
                            mDiary.hinhthuc1 = "X";
                            break;
                        case 1:
                            mDiary.hinhthuc2 = "X";
                            break;
                        case 2:
                            mDiary.hinhthuc3 = "X";
                            break;
                        case 3:
                            mDiary.hinhthuc4 = "X";
                            break;
                    }
                    mDiary.Base = cbxBase.SelectedValue.ToString();
                    mDiary.UpdatedDate = DateTime.Now;
                    mDiary.UpdatedBy = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;                    
                    db.UpdateDiary(mDiary);
                    this.Close();
                }
            }
        }
    }
}