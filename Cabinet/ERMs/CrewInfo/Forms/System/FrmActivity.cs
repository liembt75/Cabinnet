using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ERMs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewInfo.Forms
{
    public partial class FrmActivity : ERMs.SharedBase.XtraFormMDIBase
    {

        SystemDAL db = new SystemDAL();
        BindingSource bind = new BindingSource();
        public FrmActivity():base()
        {
            InitializeComponent();
            LayoutInitial();
        }

        private void FrmActivity_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Text = "Activities";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.ReadOnly = false;
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            alertControl1.Show(this.FindForm(), "Thông báo", "Mở");

        }

        void LayoutInitial()
        {
            this.Text = "Roles";
            this.WindowState = FormWindowState.Maximized;
            panelControl1.Dock = DockStyle.Fill;

            gridView1.OptionsBehavior.ReadOnly = true;
            GenerateActivityGridView();
        }

        GridColumn colID, colApp, colCode, colActivityName, colDescription, colIsdeleted, colModified;
        GridColumn col;

        private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView gridvew = sender as GridView;
            GridView detailView = gridvew.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detailView.BestFitColumns();
        }

        private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            GridView gridvew = sender as GridView;
            SysActivityModel item = (SysActivityModel)gridvew.GetRow(e.RowHandle);
            if (item == null) return;
            item.Items = db.GetCRUDByActivityID(item.ID);
        }

        void GenerateActivityGridView()
        {
             colID = new GridColumn() { Caption = "#", FieldName = "ID", Visible = true  };

             colApp = new GridColumn() { Caption = "App", FieldName = "ApplicationName", Visible = true, Width = 100 };
             colCode = new GridColumn() { Caption = "Code", FieldName = "Code", Visible = true, Width = 100 };
             colActivityName = new GridColumn() { Caption = "Activity", FieldName = "ActivityName", Visible = true, Width = 100 };
             colDescription = new GridColumn() { Caption = "Description", FieldName = "Description", Visible = true, Width = 100 };
             colIsdeleted = new GridColumn() { Caption = "Deactive", FieldName = "Isdeleted", Visible = true, Width = 70 };
             colModified = new GridColumn() { Caption = "Modified", FieldName = "Modified", Visible = true, Width = 100 };
            
            //GridColumn colApplictionName = new GridColumn() { Caption = "Application", FieldName = "ApplicationName", Visible = true, Width = 100, GroupIndex = 0 };
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(new GridColumn[] { colApp, colCode, colActivityName, colDescription, colIsdeleted, colModified, colID });

            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsDetail.AllowExpandEmptyDetails = true;

            gridView2.Columns.Clear();
            col = new GridColumn() { Caption = "CrewID", FieldName = "CrewID", Visible = true }; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "FirstNameVn", FieldName = "FirstNameVn", Visible = true }; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Xem", FieldName = "R", Visible = true }; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Thêm", FieldName = "C", Visible = true }; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Cập nhật", FieldName = "U", Visible = true }; gridView2.Columns.Add(col);
            col = new GridColumn() { Caption = "Xóa", FieldName = "D", Visible = true }; gridView2.Columns.Add(col);
            gridView2.OptionsView.ShowGroupPanel = false;
        }


        void LoadData()
        {
            bind.DataSource = db.GetActivities();
            gridControl1.DataSource = bind;
        }
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle,colModified, DateTime.Now);
            gridView1.SetRowCellValue(e.RowHandle, colIsdeleted, false);

        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            SysActivityModel item = (SysActivityModel)e.Row;

            if (string.IsNullOrWhiteSpace(item.ApplicationName))
            {
                e.Valid = false;
                view.SetColumnError(colApp, "This is not empty.");
            }

            if (string.IsNullOrWhiteSpace(item.Code) || item.Code.Length > 10)
            {
                e.Valid = false;
                view.SetColumnError(colCode, "This is not empty or less than 10 characters.");
            }

            if (string.IsNullOrWhiteSpace(item.ActivityName))
            {
                e.Valid = false;
                view.SetColumnError(colActivityName, "This is not empty.");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();

            SysActivityModel item = (SysActivityModel)e.Row;
            try
            {
                item = db.UpdateActivity(item);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

       
    }
}
