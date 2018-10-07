using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using ERMs.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms
{
    public partial class FrmUser : ERMs.SharedBase.XtraFormMDIBase
    {
        SystemDAL db = new SystemDAL();
        public FrmUser()
        {
            InitializeComponent();

            LayoutInitial();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LoadGridData();
            tbKeyword.Focus();
        }

        void LayoutInitial()
        {
            this.Text = "Users";
            lblUser.AllowHtmlString = true;
            this.WindowState = FormWindowState.Maximized;

            splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.WorkingArea.Width / 2;

            gridControl2.Dock = DockStyle.Fill;
            gridControl3.Dock = DockStyle.Fill;
            gridControl4.Dock = DockStyle.Fill;

            //gridView2.OptionsBehavior.ReadOnly = true;
            //gridView3.OptionsBehavior.ReadOnly = true;
            //gridView4.OptionsBehavior.ReadOnly = true;

            GenerateUserGridView();
            GenerateUserActivityGridView();
            GenerateUserRoleGridView();
            GenerateDepartmentGridView();
        }

        void GenerateUserGridView()
        {
            GridColumn colUserId = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true };
            GridColumn colCodeTV = new GridColumn() { Caption = "Code", FieldName = "CrewID", Visible = true, Width = 100 };
            GridColumn colNameTV = new GridColumn() { Caption = "FirstName", FieldName = "FirstNameVn", Visible = true, Width = 100 };
            GridColumn colName = new GridColumn() { Caption = "LastNameVn", FieldName = "LastNameVn", Visible = true, Width = 300 };
            GridColumn colMainBase = new GridColumn() { Caption = "Base", FieldName = "main_base", Visible = true, Width = 100 };
            GridColumn colGroup = new GridColumn() { Caption = "Group", FieldName = "Group", Visible = true, Width = 100 };
            GridColumn colPhone = new GridColumn() { Caption = "Phone", FieldName = "Phone", Visible = true, Width = 100 };
            GridColumn colAccount = new GridColumn() { Caption = "Account", FieldName = "Account", Visible = true, Width = 100 };
            GridColumn colToken = new GridColumn() { Caption = "***", FieldName = "Token", Visible = true, Width = 100 };
            GridColumn colSelected = new GridColumn() { Caption = "Sel", FieldName = "ID", Visible = true };

            colName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colName.SummaryItem.DisplayFormat = "{0:#,#}";

            //Button
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riSelected = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            riSelected.AutoHeight = false;
            riSelected.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Right;
            riSelected.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            riSelected.ButtonClick += riSelected_ButtonClick;

            colSelected.Width = 40;
            colSelected.Fixed = FixedStyle.Right;
            colSelected.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            colSelected.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colSelected.OptionsColumn.AllowMove = false;
            colSelected.OptionsFilter.AllowFilter = false;
            colSelected.ColumnEdit = riSelected;

            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(new GridColumn[] { colUserId, colCodeTV, colNameTV, colName, colPhone, colMainBase, colGroup, colAccount, colSelected });
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = true;
            //gridView1.GroupSummary.Add(new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LastNameVn", colName, "{0:n0}")); 

        }

        void GenerateDepartmentGridView()
        {
            gridControl4.Dock = DockStyle.Fill;

            GridColumn colCheck = new GridColumn() { Caption = "#", FieldName = "Checkbox", Visible = true };
            colCheck.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();

            GridColumn colCode = new GridColumn() { Caption = "Code", FieldName = "Code", Visible = true, Width = 100 };
            GridColumn colName = new GridColumn() { Caption = "Name", FieldName = "DepartmentName", Visible = true, Width = 500 };
            GridColumn colDescription = new GridColumn() { Caption = "Description", FieldName = "Description", Visible = true, Width = 300 };
            GridColumn colModifier = new GridColumn() { Caption = "Modifier", FieldName = "Modifier", Visible = true, Width = 100 };
            GridColumn colId = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true };

            gridView4.Columns.Clear();
            gridView4.Columns.AddRange(new GridColumn[] { colCheck, colCode, colName, colDescription, colModifier, colId });

            //gridView4.OptionsSelection.MultiSelect = true;
            //gridView4.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            //gridView4.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            //gridView4.OptionsSelection.ShowCheckBoxSelectorInColumnHeader =DefaultBoolean.True;
            gridView4.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView4.OptionsView.ShowGroupPanel = false;

        }


        private void btSaveRA_Click(object sender, EventArgs e)
        {
            List<SYS_GetUserActivity_Result> lst = new List<SYS_GetUserActivity_Result>();
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {
                int ActivityID = (int)gridView2.GetRowCellValue(i, "ActivityId");
                int UserId = (int)gridView2.GetRowCellValue(i, "UserId");
                int? ItemId = (int?)gridView2.GetRowCellValue(i, "ItemId");
                bool C = (bool)gridView2.GetRowCellValue(i, "C");
                bool R = (bool)gridView2.GetRowCellValue(i, "R");
                bool U = (bool)gridView2.GetRowCellValue(i, "U");
                bool D = (bool)gridView2.GetRowCellValue(i, "D");

                lst.Add(new SYS_GetUserActivity_Result()
                {
                    ActivityId = ActivityID,
                    UserId = UserId,
                    ItemId = ItemId,
                    C = C,
                    R = R,
                    U = U,
                    D = D
                });
            }
            db.UpdateUserActivityList(lst);            
        }

        void GenerateUserActivityGridView()
        {
            //GridColumn colActivityId = new GridColumn() { Caption = "ActivityId", FieldName = "ActivityId", Visible = false };
            //GridColumn colRoleId = new GridColumn() { Caption = "RoleId", FieldName = "RoleId", Visible = false };
            //GridColumn colItemId = new GridColumn() { Caption = "ItemID", FieldName = "ItemID", Visible = false };
            GridColumn colActivityName = new GridColumn() { Caption = "Activity", FieldName = "ActivityName", Visible = true, Width = 100 };
            GridColumn colApplictionName = new GridColumn() { Caption = "Application", FieldName = "ApplicationName", Visible = true, Width = 100, GroupIndex = 0 };
            GridColumn colR = new GridColumn() { Caption = "Xem", FieldName = "R", Visible = true, Width = 100 };
            GridColumn colC = new GridColumn() { Caption = "Thêm", FieldName = "C", Visible = true, Width = 100 };
            GridColumn colU = new GridColumn() { Caption = "Cập nhật", FieldName = "U", Visible = true, Width = 100 };
            GridColumn colD = new GridColumn() { Caption = "Xóa", FieldName = "D", Visible = true, Width = 100 };

            gridView2.Columns.Clear();
            gridView2.Columns.AddRange(new GridColumn[] { colActivityName, colApplictionName, colR, colC, colU, colD });

            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView2.OptionsView.ShowGroupPanel = false;
        }
        void GenerateUserRoleGridView()
        {
            GridColumn colRoleId = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = false, Width = 100 };
            GridColumn colHasRole = new GridColumn() { Caption = " ", FieldName = "HasRole", Visible = true, Width = 40 };
            GridColumn colRoleName = new GridColumn() { Caption = "Role", FieldName = "RoleName", Visible = true, Width = 100 };
            GridColumn colDescription = new GridColumn() { Caption = "Description", FieldName = "Description", Visible = true, Width = 300 };
            GridColumn colNote = new GridColumn() { Caption = "Note", FieldName = "Note", Visible = true, Width = 500 };
            
            gridView3.Columns.Clear();  
            gridView3.Columns.AddRange(new GridColumn[] { colHasRole, colRoleId, colRoleName, colDescription, colNote });

            gridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView3.OptionsView.ShowGroupPanel = true;

        }
        void LoadGridData()
        {
            string SearchKey = tbKeyword.Text;
            gridControl1.DataSource = db.GetUserList(SearchKey);

        }

        private void riSelected_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BindingDetailList(gridView1.FocusedRowHandle);
            lblUser.Text = string.Format("THAY ĐỔI QUYÊN CHO <b>{0} {1}</b> #{2}", gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LastNameVn"), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FirstNameVn"), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CrewID"));

        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindingDetailList(e.FocusedRowHandle);
            lblUser.Text = string.Format("THAY ĐỔI QUYÊN CHO <b>{0} {1}</b> #{2}", gridView1.GetRowCellValue(e.FocusedRowHandle, "LastNameVn"), gridView1.GetRowCellValue(e.FocusedRowHandle, "FirstNameVn"), gridView1.GetRowCellValue(e.FocusedRowHandle, "CrewID"));
        }        

        void BindingDetailList(int index)
        {
            try
            {
                //panelNav.Hide();
                gridControl2.SuspendLayout();
                gridControl3.SuspendLayout();
                if (index >= 0)
                {
                    gridControl2.DataSource = db.GetUserActivityList((int)gridView1.GetRowCellValue(index, "ID"));
                    gridControl3.DataSource = db.GetUserRoleList((int)gridView1.GetRowCellValue(index, "ID"));
                    gridControl4.DataSource = db.GetDepartment((int)gridView1.GetRowCellValue(index, "ID"));

                }
                else
                {
                    gridControl2.DataSource = null;
                    gridControl3.DataSource = null;
                    gridControl4.DataSource = null;
                }

                gridControl2.RefreshDataSource();
                gridControl2.ResumeLayout();
                gridView2.ExpandAllGroups();

                gridControl3.RefreshDataSource();
                gridControl3.ResumeLayout();

                gridControl4.RefreshDataSource();
                gridControl4.ResumeLayout();
            }
            catch { }
            //panelNav.Show();
        }

        private void btSearchUser_Click(object sender, EventArgs e)
        {
            LoadGridData();
            BindingDetailList(0);
        }

        private void tbKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadGridData();
        }
        private void tbKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadGridData();
                BindingDetailList(0);
            }
        }

        private void btClearSearch_Click(object sender, EventArgs e)
        {
            tbKeyword.Text = string.Empty;
            LoadGridData();
            BindingDetailList(0);
        }      

        private void btSaveUserRole_Click(object sender, EventArgs e)
        {
            List<SYS_GetUserRole_Result> lst = new List<SYS_GetUserRole_Result>();
            for (int i = 0; i < gridView3.DataRowCount; i++)
            {
                bool HasRole = (bool)gridView3.GetRowCellValue(i, "HasRole");
                int UserId = (int)gridView3.GetRowCellValue(i, "UserId");
                int RoleID = (int)gridView3.GetRowCellValue(i, "ID");
                int? ItemId = (int?)gridView3.GetRowCellValue(i, "ItemId");
                lst.Add(new SYS_GetUserRole_Result()
                {
                    ID = RoleID,
                    UserId = UserId,
                    HasRole = HasRole,
                    ItemId = ItemId
                });
            }

            bool result = db.UpdateUserRoleList(lst);
            if (result)
            {
                alertControl1.Show(
               this.FindForm(),
               "Thông báo",
               "Cập nhật Nhóm quyền thành công"
               );
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gridView2.OptionsBehavior.ReadOnly = false;
            gridView3.OptionsBehavior.ReadOnly = false;
            gridView4.OptionsBehavior.ReadOnly = false;

            alertControl1.Show( this.FindForm(), "Thông báo", "Đã mở chức năng cập nhật");
        }
        //Department
        private void gridView4_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0 ) return;
            if (e.Column.FieldName != "Checkbox") return;

            int employeeid = (int) gridView1.GetFocusedRowCellValue("ID");

            try
            {
                db.UpdateDepartment((int)gridView4.GetRowCellValue(e.RowHandle, "DepartmentID"), employeeid, (bool)e.Value);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        
        //Roles
        private void gridView3_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName != "HasRole") return;

            //bool HasRole = (bool)gridView3.GetRowCellValue(e.RowHandle, "HasRole");
            int employeeid = (int)gridView3.GetRowCellValue(e.RowHandle, "UserId");
            int roleid = (int)gridView3.GetRowCellValue(e.RowHandle, "ID");

            try
            {
                db.UpdateUserRole(roleid, employeeid, (bool)e.Value);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} \n{1}", ex.Message, ex.InnerException.Message));

                gridView3.SetRowCellValue(e.RowHandle, "HasRole", !(bool)e.Value);
                gridView3.RefreshEditor(true);

            }

        }

        //Quyen db
        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (! "/C/R/U/D/".Contains ("/" + e.Column.FieldName + "/") ) return;

            SystemDAL.CRUD crud;
            switch (e.Column.FieldName)
            {
                case "C":
                    crud = SystemDAL.CRUD.C; break;
                case "R":
                    crud = SystemDAL.CRUD.R; break;
                case "U":
                    crud = SystemDAL.CRUD.U; break;
                case "D":
                    crud = SystemDAL.CRUD.D; break;

                default:
                    return;
            }

            int ActivityID = (int)gridView2.GetRowCellValue(e.RowHandle, "ActivityId");
            int employeeid = (int)gridView2.GetRowCellValue(e.RowHandle, "UserId");
            int? ItemId = (int?)gridView2.GetRowCellValue(e.RowHandle, "ItemId");
            bool C = (bool)gridView2.GetRowCellValue(e.RowHandle, "C");
            bool R = (bool)gridView2.GetRowCellValue(e.RowHandle, "R");
            bool U = (bool)gridView2.GetRowCellValue(e.RowHandle, "U");
            bool D = (bool)gridView2.GetRowCellValue(e.RowHandle, "D");

            try
            {
                db.UpdateUserActivity(ActivityID, employeeid, crud, (bool)e.Value);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} \n{1}",ex.Message,ex.InnerException.Message));
                
            }
        }

      
    }
}