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
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal dbFlight = new FlightDal();
        public FrmFlightFinalReportCategory()
        {
            InitializeComponent();
            gridControl1.DataSource = dbFlight.GetFinalReportCategory();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục");
            }
            else
            {
                CR_Flight_FinalReport_Category category = new CR_Flight_FinalReport_Category();
                category.Category = txtCategory.Text;
                category.IsDeleted = false;
                category.Created = DateTime.Now;
                category.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                category.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                category.Modified = DateTime.Now;
                category.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                category.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                dbFlight.AddCategory(category);
                MessageBox.Show("Nhập danh mục thành công");
                gridControl1.DataSource = dbFlight.GetFinalReportCategory();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clDel")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa danh mục này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CR_Flight_FinalReport_Category category = (CR_Flight_FinalReport_Category)gridView1.GetRow(e.RowHandle);
                    category.Modified = DateTime.Now;
                    category.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    category.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                    category.IsDeleted = true;
                    dbFlight.UpdateCategory(category);
                    MessageBox.Show("Xóa danh mục thành công");
                    gridControl1.DataSource = dbFlight.GetFinalReportCategory();
                }
            }
            if (e.Column.Name == "clSubCategory")
            {
                CR_Flight_FinalReport_Category category = (CR_Flight_FinalReport_Category)gridView1.GetRow(e.RowHandle);
                FrmFlightFinalReportSubCategory frm = new FrmFlightFinalReportSubCategory(category);
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn cập nhật dữ liệu này?", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Value = ((GridView)sender).ActiveEditor.OldEditValue;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {                
                CR_Flight_FinalReport_Category category = (CR_Flight_FinalReport_Category)gridView1.GetRow(e.RowHandle);                                                
                switch (e.Column.Name)
                {
                    case "clCategory":
                        category.Category = e.Value.ToString();
                        category.Modified = DateTime.Now;
                        category.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        category.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                        dbFlight.UpdateCategory(category);
                        break;
                }
            }
            catch
            { }
        }
    }
}