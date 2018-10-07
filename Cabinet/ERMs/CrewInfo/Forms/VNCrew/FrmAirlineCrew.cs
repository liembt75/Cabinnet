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

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmAirlineCrew : ERMs.SharedBase.XtraFormMDIBase
    {
        #region properties
        BindingSource bind = new BindingSource();
        FlightDal db = new FlightDal();
        #endregion

        public FrmAirlineCrew()
        {
            InitializeComponent();
            InitData();
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.T.03");
            if (crud != null && crud.U.HasValue && crud.U.Value)
                btnUpdate.Visible = true;
        }

        #region custom function
        private void InitData()
        {
            bind.DataSource = db.GetAirplaneCrew();
            gcAC.DataSource = bind;
            gvAC.BestFitColumns();
        }
        #endregion


        #region event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gvAC.OptionsBehavior.Editable = !gvAC.OptionsBehavior.Editable;
        }


        private void gvAC_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvAC.SetRowCellValue(e.RowHandle, "CrewType", "");
            gvAC.SetRowCellValue(e.RowHandle, "Prior", "0");
            gvAC.SetRowCellValue(e.RowHandle, "Aircraft", null);
            gvAC.SetRowCellValue(e.RowHandle, "Routing", null);
            gvAC.SetRowCellValue(e.RowHandle, "P", null);
            gvAC.SetRowCellValue(e.RowHandle, "X", null);
            gvAC.SetRowCellValue(e.RowHandle, "B", null);
            gvAC.SetRowCellValue(e.RowHandle, "Y", null);
            gvAC.SetRowCellValue(e.RowHandle, "Note", null);
            gvAC.SetRowCellValue(e.RowHandle, "Expired", null);
        }

        private void gvAC_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            CR_Airplane_Crew item = (CR_Airplane_Crew)e.Row;
            if (item.Prior < 0)
            {
                e.Valid = false;
                gvAC.SetColumnError(clPrior, "Prior phải lớn hơn hoặc bằng 0.");
            }
            if (string.IsNullOrEmpty(item.Aircraft))
            {
                e.Valid = false;
                gvAC.SetColumnError(clAircraft, "Aircraft không được để trống.");
            }
            else
            {
                List<CR_Airplane_Crew> lstAC = bind.DataSource as List<CR_Airplane_Crew>;
                if (lstAC.Where(x => x.Aircraft == item.Aircraft && x.Routing == item.Routing).Count() > 1)
                {
                    e.Valid = false;
                    gvAC.SetColumnError(clRouting, "Routing không được giống nhau.");
                }
            }
        }

        private void gvAC_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvAC_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            CR_Airplane_Crew item = (CR_Airplane_Crew)e.Row;
            try
            {
                CR_Airplane_Crew returnItem = db.UpdateAirplaneCrew(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gvAC.BestFitColumns();
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
        #endregion

    }
}