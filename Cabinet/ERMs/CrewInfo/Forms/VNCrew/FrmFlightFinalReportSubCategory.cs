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
using ERMs.Data.Flight;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.VNCrew
{
    //tét
    public partial class FrmFlightFinalReportSubCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        CR_Flight_FinalReport_Category category = null;
        FlightDal dbFlight = new FlightDal();
        public FrmFlightFinalReportSubCategory(CR_Flight_FinalReport_Category iCategory)
        {
            InitializeComponent();
            category = iCategory;
        }

        private void FrmFlightFinalReportSubCategory_Load(object sender, EventArgs e)
        {
            txtCategory.Text = category.Category;
            gridControl1.DataSource = dbFlight.GetFinalReportSubCategoryByCateogryID(category.ID);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubCategory.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục");
            }
            else
            {
                CR_Flight_FinalReport_SubCategory subcategory = new CR_Flight_FinalReport_SubCategory();
                subcategory.CategoryID = category.ID;
                subcategory.SubCategory = txtSubCategory.Text;
                subcategory.IsDeleted = false;
                subcategory.Created = DateTime.Now;
                subcategory.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                subcategory.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                subcategory.Modified = DateTime.Now;
                subcategory.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                subcategory.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                dbFlight.AddSubCategory(subcategory);
                MessageBox.Show("Nhập danh mục thành công");
                gridControl1.DataSource = dbFlight.GetFinalReportSubCategoryByCateogryID(category.ID);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clDel")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa danh mục này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CR_Flight_FinalReport_SubCategory subcategory = (CR_Flight_FinalReport_SubCategory)gridView1.GetRow(e.RowHandle);
                    subcategory.Modified = DateTime.Now;
                    subcategory.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    subcategory.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                    subcategory.IsDeleted = true;
                    dbFlight.UpdateSubCategory(subcategory);
                    MessageBox.Show("Xóa danh mục thành công");
                    gridControl1.DataSource = dbFlight.GetFinalReportSubCategoryByCateogryID(category.ID);
                }
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
                CR_Flight_FinalReport_SubCategory subcategory = (CR_Flight_FinalReport_SubCategory)gridView1.GetRow(e.RowHandle);
                switch (e.Column.Name)
                {
                    case "clSubCategory":
                        subcategory.SubCategory = e.Value.ToString();
                        subcategory.Modified = DateTime.Now;
                        subcategory.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        subcategory.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
                        dbFlight.UpdateSubCategory(subcategory);                        
                        break;
                }
            }
            catch
            { }
        }
    }
}