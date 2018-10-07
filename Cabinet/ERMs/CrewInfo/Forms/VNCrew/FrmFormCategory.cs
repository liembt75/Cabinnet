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
using DevExpress.XtraGrid.Columns;
using ERMs.Data;
using System.Data.OleDb;
using System.IO;
using Erms.Utils;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFormCategory : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        FormDal db = new FormDal();
        public FrmFormCategory()
        {
            InitializeComponent();
        }

        private void FrmFormCategory_Load(object sender, EventArgs e)
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.F.02");
            gv.OptionsBehavior.ReadOnly = true;
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;
                panelNav.Visible = true;
            }
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            gv.Columns.Clear();
            //gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsPrint.AutoWidth = false;
            gv.OptionsView.EnableAppearanceEvenRow = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Code";
            col.FieldName = "Code";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Name";
            col.FieldName = "Name";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = false;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Description";
            col.FieldName = "Description";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = false;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Active";
            col.FieldName = "Active";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = false;
            gv.Columns.Add(col);            
        }

        private void RefreshData()
        {            
            List<HR_Form_Category> lstFormCategory = db.GetListFormCategory();
            bind.DataSource = lstFormCategory;
            gc.DataSource = bind;
            //foreach (GridColumn column in gv.Columns)
            //{
            //    if (column.FieldName == "Content" || column.FieldName == "ReplyInfo")
            //        continue;
            //    column.BestFit();
            //}
            gv.BestFitColumns();
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            HR_Form_Category item = (HR_Form_Category)e.Row;
            try
            {
                db.UpdateFormCategory(item);                
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                foreach (GridColumn column in gv.Columns)
                {
                    if (column.FieldName == "Content" || column.FieldName == "ReplyInfo")
                        continue;
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Foxpro file|*.dbf";
            file.ShowDialog();
            
            if (file.FileName.Trim() != "")
            {
                DataTable dt = new DataTable();
                string path = Path.GetDirectoryName(file.FileName);
                string fileName = Path.GetFileName(file.FileName);                
                OleDbConnection yourConnectionHandler = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + path);
                yourConnectionHandler.Open();

                if (yourConnectionHandler.State == ConnectionState.Open)
                {
                    //string mySQL = "select * from qlns.DBF where manv='0004'";  // dbf table name
                    string mySQL = string.Format("select * from {0} where Nhomtk = 'NGHI'", fileName);  // dbf table name

                    OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
                    OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);

                    DA.Fill(dt);

                    yourConnectionHandler.Close();
                }

                List<HR_Form_Category> lstFormCategory = new List<HR_Form_Category>();
                HR_Form_Category formCategory = null;
                List<HR_Form_Category> lstFormRemainCategory = (List<HR_Form_Category>)bind.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    formCategory = new HR_Form_Category();
                    formCategory.Code = row[0] == DBNull.Value ? "" : row[0].ToString();
                    formCategory.Name = formCategory.Description = row[1] == DBNull.Value ? "" : TCVNUtils.TCVN3ToUnicode(row[1].ToString().Trim());
                    formCategory.Active = true;
                    if (lstFormRemainCategory.Where(i => i.Code == formCategory.Code).FirstOrDefault() == null)
                        lstFormCategory.Add(formCategory);
                }
                if (lstFormCategory.Count > 0)
                {
                    FrmImportFormCategory form = new FrmImportFormCategory(lstFormCategory);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        RefreshData();
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }

            
            //return YourResultSet;
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;            
            HR_Form_Category item = (HR_Form_Category)e.Row;
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                e.Valid = false;
                gv.SetColumnError(view.Columns["Name"], "Name không được để trống!");
            }
            else if (item.Name.Length <= 20)
            {
                e.Valid = false;
                gv.SetColumnError(view.Columns["Name"], "Name phải ít hơn 20 kí tự!");
            }
        }
    }
}