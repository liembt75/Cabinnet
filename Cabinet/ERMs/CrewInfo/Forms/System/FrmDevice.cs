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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmDevice : ERMs.SharedBase.XtraFormMDIBase
    {
        #region properties
        BindingSource bind = new BindingSource();
        SystemDAL db = new SystemDAL();
        List<SysDeviceModel> lstSysDevice = new List<SysDeviceModel>();
        #endregion
        public FrmDevice()
        {
            InitializeComponent();
            InitView();
            InitData();            
        }

        #region Custom function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsBehavior.ReadOnly = true;
            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            col.Visible = true;
            gv.Columns.Add(col);


            col = new GridColumn();
            col.Caption = "AID";
            col.FieldName = "AID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "CID";
            col.FieldName = "CID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FullName";
            col.FieldName = "FullNameVn";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "PhoneNo";
            col.FieldName = "PhoneNo";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "DeviceName";
            col.FieldName = "DeviceName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "DeviceType";
            col.FieldName = "DeviceType";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "DeviceOS";
            col.FieldName = "DeviceOS";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Manufacture";
            col.FieldName = "Manufacture";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "OSType";
            col.FieldName = "OSType";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "IsNotify";
            col.FieldName = "IsNotify";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "MainDevice";
            col.FieldName = "MainDevice";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "LastLogin";
            col.FieldName = "LastLogin";
            col.OptionsColumn.ReadOnly = true;
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "OTPCode";
            col.FieldName = "OTPCode";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "OTPDate";
            col.FieldName = "OTPDate";
            col.OptionsColumn.ReadOnly = true;
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "OTPCount";
            col.FieldName = "OTPCount";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "OTPFailures";
            col.FieldName = "OTPFailures";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "AuthUDID";
            col.FieldName = "AuthUDID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FullNameAuth";
            col.FieldName = "FullNameAuthVn";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "UDID";
            col.FieldName = "UDID";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Keycode";
            col.FieldName = "Keycode";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "PushToken";
            col.FieldName = "PushToken";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Description";
            col.FieldName = "Description";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Note";
            col.FieldName = "Note";
            col.Fixed = FixedStyle.Right;
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Activate";
            col.FieldName = "Activate";
            col.Fixed = FixedStyle.Right;
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            gv.OptionsBehavior.ReadOnly = true;
        }
        private void InitData()
        {
            lstSysDevice = db.GetSysDevice();
            bind.DataSource = lstSysDevice;
            gc.DataSource = bind;
            gv.BestFitColumns();
        }
        #endregion

        #region Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gv.OptionsBehavior.ReadOnly = !gv.OptionsBehavior.Editable;
            //gv.OptionsBehavior.Editable = !gv.OptionsBehavior.Editable;
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            SysDeviceModel item = (SysDeviceModel)e.Row;
            try
            {   
                if (item.Activate.HasValue && item.Activate.Value && string.IsNullOrWhiteSpace(item.CID))
                {
                    item.CID = item.CrewID;
                }
                SysDeviceModel returnItem = db.UpdateSysDevice(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                gv.BestFitColumns();                
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            lstSysDevice.Clear();
            lstSysDevice.AddRange(db.GetSysDevice());
            gc.RefreshDataSource();
            //gc.DataSource = null;
            //bind.DataSource = db.GetSysDevice();
            //gc.DataSource = bind;
            gv.BestFitColumns();
            SplashScreenManager.CloseForm(false);

        }
    }
}