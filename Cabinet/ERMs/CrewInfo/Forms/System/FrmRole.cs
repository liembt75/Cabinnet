﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using ERMs.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms
{
    public partial class FrmRole : ERMs.SharedBase.XtraFormMDIBase
    {
        SystemDAL db = new SystemDAL();
        List<SYS_GetRoleUser_Result> lstRoleUser = new List<SYS_GetRoleUser_Result>();

        public FrmRole()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard
            LayoutInitial();

        }

        void LayoutInitial()
        {
            this.Text = "Roles";
            this.WindowState = FormWindowState.Maximized;

            splitContainerControl1.SplitterPosition = Screen.PrimaryScreen.WorkingArea.Width / 2;

            gridView1.OptionsBehavior.ReadOnly = true;
            gridView2.OptionsBehavior.ReadOnly = true;

            GenerateRoleGridView();
            GenerateRoleActivityGridView();
        }

        GridColumn colRoleId, colRoleName, colDescription, colNote, colRoleActive;
        void GenerateRoleGridView()
        {
            colRoleId = new GridColumn() { Caption = "ID", FieldName = "ID", Visible = true, Width = 100 };
            colRoleName = new GridColumn() { Caption = "Role", FieldName = "RoleName", Visible = true, Width = 100 };
            colDescription = new GridColumn() { Caption = "Description", FieldName = "Description", Visible = true, Width = 300 };
            colNote = new GridColumn() { Caption = "Note", FieldName = "Note", Visible = true, Width = 500 };
            colRoleActive = new GridColumn() { Caption = "Deactive", FieldName = "Isdeleted", Visible = true, Width = 100 };

            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(new GridColumn[] { colRoleName, colDescription, colNote, colRoleActive, colRoleId });

            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView1.OptionsView.ShowGroupPanel = true;
            
        }

        private void FrmRole_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void btSaveRA_Click(object sender, EventArgs e)
        {
            List<SYS_GetRoleActivity_Result> lst = new List<SYS_GetRoleActivity_Result>();
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {
                int ActivityID = (int)gridView2.GetRowCellValue(i, "ActivityId");
                int RoleId = (int)gridView2.GetRowCellValue(i, "RoleId");
                int? ItemId = (int?)gridView2.GetRowCellValue(i, "ItemId");
                bool C = (bool)gridView2.GetRowCellValue(i, "C");
                bool R = (bool)gridView2.GetRowCellValue(i, "R");
                bool U = (bool)gridView2.GetRowCellValue(i, "U");
                bool D = (bool)gridView2.GetRowCellValue(i, "D");

                lst.Add(new SYS_GetRoleActivity_Result()
                {
                    ActivityId = ActivityID,
                    RoleId = RoleId,
                    ItemId = ItemId,
                    C = C,
                    R = R,
                    U = U,
                    D = D
                });
            }
            db.UpdateRoleActivityList(lst);
        }

        void GenerateRoleActivityGridView()
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

        void LoadGridData()
        {
            BindingSource bind = new BindingSource();
            bind.DataSource = db.GetRoleList();
            gridControl1.DataSource = bind;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView2.OptionsBehavior.ReadOnly = false;

        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            panelNav.Hide();
            gridControl2.SuspendLayout();
            if (e.FocusedRowHandle >= 0)
            {
                gridControl2.DataSource = db.GetRoleActivityList((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "ID"));
                lstRoleUser = db.GetRoleUser((int)gridView1.GetRowCellValue(e.FocusedRowHandle, "ID"));
                gridControl3.DataSource = lstRoleUser;
            }
            else
            {
                gridControl2.DataSource = null;
                gridControl3.DataSource = null;
            }

            gridControl2.RefreshDataSource();
            gridControl2.ResumeLayout();
            gridControl3.RefreshDataSource();
            gridControl3.ResumeLayout();
            gridView2.ExpandAllGroups();
            panelNav.Show();
        }

     
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, colRoleId, 0);
            gridView1.SetRowCellValue(e.RowHandle, colRoleActive, false);

        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Xóa người dùng khỏi nhóm?", "Lưu ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GridView view = sender as GridView;
                    db.DeleteRoleUser((int)gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID"));
                    lstRoleUser = db.GetRoleUser((int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                    gridControl3.DataSource = lstRoleUser;
                    gridControl3.RefreshDataSource();
                    gridControl3.ResumeLayout();
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Sys_Role item = (Sys_Role) e.Row;

            if (string.IsNullOrWhiteSpace(item.RoleName) || item.RoleName.Length > 20)
            {
                e.Valid = false;
                view.SetColumnError(colRoleName, "This is not empty or less than 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(item.Description))
            {
                e.Valid = false;
                view.SetColumnError(colDescription, "This is not empty.");
            }
        }

        private void txtAddUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddUser_Click(null, null);
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();

            Sys_Role item = (Sys_Role)e.Row;
            try
            {
                db.UpdateRole(item);
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (!"/C/R/U/D/".Contains("/" + e.Column.FieldName + "/")) return;

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

            int activityId = (int)gridView2.GetRowCellValue(e.RowHandle, "ActivityId");
            int roleId = (int)gridView2.GetRowCellValue(e.RowHandle, "RoleId");
            bool C = (bool)gridView2.GetRowCellValue(e.RowHandle, "C");
            bool R = (bool)gridView2.GetRowCellValue(e.RowHandle, "R");
            bool U = (bool)gridView2.GetRowCellValue(e.RowHandle, "U");
            bool D = (bool)gridView2.GetRowCellValue(e.RowHandle, "D");

            try
            {
                db.UpdateRoleActivity(activityId, roleId, crud, (bool)e.Value);
                //alertControl1.Show(this.FindForm(), "Successful", "Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} \n{1}", ex.Message, ex.InnerException.Message));

            }
        }



        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddUser.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Sys_Account account = null;
                try
                {
                    int crewID = int.Parse(txtAddUser.Text);
                    account = db.GetSysAccountByCrewID(txtAddUser.Text);                                     
                }
                catch
                {
                    account = db.GetUserByUserName(txtAddUser.Text);
                }
                if (account != null)
                {
                    var userInRole = lstRoleUser.Where(i => i.CrewID == account.CrewID).FirstOrDefault();
                    if (userInRole != null)
                    {
                        MessageBox.Show("Người dùng đã có trong nhóm!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var focusRow = gridView1.GetFocusedRow() as Sys_Role;
                        if (focusRow != null)
                        {
                            int roleID = focusRow.ID;
                            Sys_User_Role userRole = new Sys_User_Role();
                            userRole.Roleid = roleID;
                            userRole.Userid = account.ID;
                            db.AddUserRole(userRole);
                            lstRoleUser = db.GetRoleUser(roleID);
                            gridControl3.DataSource = lstRoleUser;
                            gridControl3.RefreshDataSource();
                            gridControl3.ResumeLayout();
                            txtAddUser.Text = "";
                        }                        
                    }
                }  
                else
                {
                    MessageBox.Show("Người dùng không tồn tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }              
            }
        }
    }
}