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
using DevExpress.XtraEditors.Repository;
using ERMs.Data;
using DevExpress.XtraGrid;
using DevExpress.Export;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using System.Text.RegularExpressions;
using CrewInfo.ADONet;
using System.Reflection;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors.Controls;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmForm : ERMs.SharedBase.XtraFormMDIBase
    {        

        #region Properties
        FormDal db = new FormDal();
        List<HR_Form_Category> lstFormCategory = new List<HR_Form_Category>();
        List<HR_Form_Category> lstAccessFormCategory = new List<HR_Form_Category>();
        BindingSource bind = new BindingSource();
        Dictionary<int, string> messageStatus;
        #endregion

        #region Function
        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsPrint.PrintSelectedRowsOnly = true;
            //gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

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
            col.Caption = "FullName";
            col.FieldName = "FullNameVn";
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);            

            col = new GridColumn();
            col.Caption = "CD";
            col.FieldName = "type_tv";            
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "LĐ";
            col.FieldName = "Group";            
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Base";
            col.FieldName = "Base";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Term";
            col.FieldName = "Term";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            RepositoryItemLookUpEdit categoryLookUpEdit = new RepositoryItemLookUpEdit();
            categoryLookUpEdit.DataSource = lstFormCategory;
            categoryLookUpEdit.DisplayMember = "Name";
            categoryLookUpEdit.ValueMember = "ID";
            categoryLookUpEdit.Columns.Add(new LookUpColumnInfo("Name"));

            col = new GridColumn();
            col.Caption = "Loại";
            col.FieldName = "Category_ID";
            col.ColumnEdit = categoryLookUpEdit;
            col.OptionsColumn.ReadOnly = true;

            //Kiem tra co quyen sua category nguyen vong hay ko
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.FC.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                col.OptionsColumn.ReadOnly = false;
            }
            col.Visible = true;
            gv.Columns.Add(col);

            //StyleFormatCondition styleCategory = new StyleFormatCondition();
            //styleCategory.Column = col;
            //styleCategory.Condition = FormatConditionEnum.Expression;
            //styleCategory.Expression = "Not IsNullOrEmpty([Category_ID]) and ([Category_ID] = 2 or [Category_ID] = 4 or [Category_ID] = 5)";
            //styleCategory.Appearance.BackColor = Color.Red;
            //styleCategory.Appearance.BackColor2 = Color.White;
            //styleCategory.Appearance.Options.UseBackColor = true;
            ////styleCategory.ApplyToRow = true;
            //gv.FormatConditions.Add(styleCategory);

            col = new GridColumn();
            col.Caption = "Từ ngày";
            col.FieldName = "From_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tới ngày";
            col.FieldName = "To_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);



            col = new GridColumn();
            col.Caption = "Số hiệu CB";
            col.FieldName = "FlightNo";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Chặng bay";
            col.FieldName = "Route";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nội dung";
            col.FieldName = "Content";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Width = 200;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đính kèm";
            col.FieldName = "AttachmentText";
            col.ColumnEdit = new RepositoryItemHyperLinkEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày tạo";
            col.FieldName = "Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Người trả lời";
            col.FieldName = "Replier";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày trả lời";
            col.FieldName = "Replied";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nội dung trả lời";
            col.FieldName = "ReplyInfo";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = false;
            col.Width = 200;            
            col.Visible = true;
            gv.Columns.Add(col);

            RepositoryItemImageComboBox statusImageCbx = new RepositoryItemImageComboBox();
            statusImageCbx.SmallImages = imgStatus;
            statusImageCbx.AutoHeight = false;            
            for (int i = 1; i < messageStatus.Count; i++)
            {
                statusImageCbx.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(messageStatus[i], i, i - 1));
            }             

            col = new GridColumn();
            col.Caption = "Tình trạng XL";
            col.FieldName = "Status";
            col.ColumnEdit = statusImageCbx;
            col.OptionsColumn.ReadOnly = true;
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv.Columns.Add(col);



            col = new GridColumn();
            col.Caption = "MSNV";
            col.FieldName = "CID";
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "CName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            gv.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            gv.OptionsSelection.MultiSelect = true;
            gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            //gv.VisibleColumns[0].OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            //gv.OptionsPrint.AutoWidth = false;

            col = new GridColumn();
            col.Caption = "MSNV";
            col.FieldName = "CID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FullName";
            col.FieldName = "FullNameVn";
            col.Fixed = FixedStyle.Left;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tên";
            col.FieldName = "CName";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Base";
            col.FieldName = "Base";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "CD";
            col.FieldName = "type_tv";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "LĐ";
            col.FieldName = "Group";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày tạo";
            col.FieldName = "Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Từ ngày";
            col.FieldName = "From_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tới ngày";
            col.FieldName = "To_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Chặng bay";
            col.FieldName = "Route";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nội dung";
            col.FieldName = "Content";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Width = 200;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Đính kèm";
            col.FieldName = "AttachmentText";
            //col.ColumnEdit = new RepositoryItemHyperLinkEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Loại";
            col.FieldName = "Category_ID";
            col.ColumnEdit = categoryLookUpEdit;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);
            //gvBaoCao.FormatConditions.Add(styleCategory);

            col = new GridColumn();
            col.Caption = "Người trả lời";
            col.FieldName = "Replier";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày trả lời";
            col.FieldName = "Replied";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Nội dung trả lời";
            col.FieldName = "ReplyInfo";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = false;
            col.Width = 200;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Tình trạng XL";
            col.FieldName = "Status";
            col.ColumnEdit = statusImageCbx;
            col.OptionsColumn.ReadOnly = true;
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gvBaoCao.Columns.Add(col);

            gv.VisibleColumns[0].OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            gv.OptionsPrint.AutoWidth = false;
            gvBaoCao.OptionsPrint.AutoWidth = false;            


            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";            
            col.OptionsColumn.ReadOnly = true;            
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày tạo";
            col.FieldName = "Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "CID";
            col.FieldName = "CID";            
            col.Visible = true;
            col.OptionsColumn.ReadOnly = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FullName";
            col.FieldName = "FullNameVn";            
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);

            RepositoryItemLookUpEdit categoryCodeLookUpEdit = new RepositoryItemLookUpEdit();
            categoryCodeLookUpEdit.DataSource = lstFormCategory;
            categoryCodeLookUpEdit.DisplayMember = "Code";
            categoryCodeLookUpEdit.ValueMember = "ID";            

            col = new GridColumn();
            col.Caption = "Category";
            col.FieldName = "Category_ID";
            col.ColumnEdit = categoryCodeLookUpEdit;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = " ";
            col.FieldName = "Category_ID";
            col.ColumnEdit = categoryLookUpEdit;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FromDate";
            col.FieldName = "From_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ToDate";
            col.FieldName = "To_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gvExport.Columns.Add(col);



            

            col = new GridColumn();
            col.Caption = "Route";
            col.FieldName = "Route";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "FlightNo";
            col.FieldName = "FlightNo";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Content";
            col.FieldName = "Content";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Width = 200;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Remark";
            col.FieldName = "";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = false;
            col.Width = 200;
            col.Visible = true;
            gvExport.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Status";
            col.FieldName = "";            
            col.OptionsColumn.ReadOnly = true;            
            col.Visible = true;
            gvExport.Columns.Add(col);

            gvExport.OptionsPrint.AutoWidth = false;
            //gvExport.OptionsPrint.PrintSelectedRowsOnly = true;     
        }

        private void RefreshData()
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

            DateTime? fromFromDate = null, toFromDate = null;
            if (!string.IsNullOrEmpty(txtFromFromdate.Text))
            {
                fromFromDate = txtFromFromdate.DateTime;
                fromFromDate = new DateTime(fromFromDate.Value.Year, fromFromDate.Value.Month, fromFromDate.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtToFromdate.Text))
            {
                toFromDate = txtToFromdate.DateTime;
                toFromDate = new DateTime(toFromDate.Value.Year, toFromDate.Value.Month, toFromDate.Value.Day, 23, 59, 59, 59);
            }

            DateTime? fromToDate = null, toToDate = null;
            if (!string.IsNullOrEmpty(txtFromTodate.Text))
            {
                fromToDate = txtFromTodate.DateTime;
                fromToDate = new DateTime(fromToDate.Value.Year, fromToDate.Value.Month, fromToDate.Value.Day, 0, 0, 0, 0);
            }
            if (!string.IsNullOrEmpty(txtToTodate.Text))
            {
                toToDate = txtToTodate.DateTime;
                toToDate = new DateTime(toToDate.Value.Year, toToDate.Value.Month, toToDate.Value.Day, 23, 59, 59, 59);
            }

            string key = null;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                key = txtSearch.Text.Trim();

            int status = 0;
            if (lookUpEditStatus.EditValue != null)
            {
                try
                {
                    status = int.Parse(lookUpEditStatus.EditValue.ToString().Trim());
                } catch { }
            }
            //List<HR_Forms> lstForm = db.GetListForm(fromdate, todate, key, status);
            List<HRFormModel> lstForm = new List<HRFormModel>();
            foreach (var accessCategory in lstAccessFormCategory)
            {
                lstForm.AddRange(db.GetListForm(fromdate, todate, fromFromDate, toFromDate, fromToDate, toToDate, key, status, accessCategory.ID));
            }
            lstForm = lstForm.OrderByDescending(i => i.ID).ToList();
            //List<HRFormModel> lstForm = db.GetListForm(fromdate, todate, fromFromDate, toFromDate, fromToDate, toToDate, key, status);
            bind.DataSource = lstForm;
            gc.DataSource = bind;
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName == "Content" || column.FieldName == "ReplyInfo")
                    continue;
                column.BestFit();                
            }
            //gv.BestFitColumns();
        }
        #endregion

        #region Event
        public FrmForm()
        {
            InitializeComponent();
        }

        private void FrmForm_Load(object sender, EventArgs e)
        {
            messageStatus = new Dictionary<int, string>();
            messageStatus.Add(0, "Tất cả");
            messageStatus.Add(1, "Mới");
            messageStatus.Add(2, "Đang xử lý");
            messageStatus.Add(3, "Chấp nhận");
            messageStatus.Add(4, "Từ chối");

            btnNew.Text = messageStatus[1];
            btnProcessing.Text = messageStatus[2];
            btnApproved.Text = messageStatus[3];
            btnReject.Text = messageStatus[4];

            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTodate.DateTime = DateTime.Today;

            //cbxStatus
            lookUpEditStatus.Properties.DataSource = new BindingSource(messageStatus, null);
            lookUpEditStatus.Properties.DisplayMember = "Value";
            lookUpEditStatus.Properties.ValueMember = "Key";
            lookUpEditStatus.EditValue = 0;

            gv.OptionsBehavior.ReadOnly = true;
            groupControl1.Visible = false;
            groupControl2.Visible = false;
            //panelNav.Visible = false;
            //panel1.Visible = false;            

            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID("D.C.F.01");
            if (crud != null && crud.U.HasValue && crud.U.Value)
            {
                gv.OptionsBehavior.ReadOnly = false;
                groupControl1.Visible = true;
                groupControl2.Visible = true;                
                //panel1.Visible = true;
            }
            
            lstFormCategory = db.GetFormCategory();
            foreach (var category in lstFormCategory)
            {
                crud = UserInfoModel.GetCRUID(string.Format("D.C.F.{0}", category.Code));
                if (crud != null && crud.R.HasValue && crud.R.Value)
                    lstAccessFormCategory.Add(category);                
            }
            
            InitView();
            RefreshData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
            flyoutPanel1.HidePopup();
        }

        #endregion

        private void gv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //if (e.Column.FieldName == "Attachments")
                if (e.Column.FieldName == "AttachmentText")
                    
            {
                GridView view = sender as GridView;
                var item = view.GetRow(e.RowHandle) as HR_Forms;
                if (item.Attachments.HasValue)
                {
                    FrmFormAttachment frmFormAttachment = new FrmFormAttachment(item);
                    frmFormAttachment.MdiParent = this.ParentForm;
                    frmFormAttachment.Show();
                }
            }
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {            
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            HRFormModel item = (HRFormModel)e.Row;
            try
            {
                HRFormModel returnItem = db.UpdateForm(item);
                //item.ID = returnItem.ID;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            UpdateFormStatus(1);
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            UpdateFormStatus(2);
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            UpdateFormStatus(3);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateFormStatus(4);
        }

        private void UpdateFormStatus(int status)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            try
            {
                List<HRFormModel> lstForms = new List<HRFormModel>();
                for (int i = 0; i < gv.GetSelectedRows().Length; i++)
                {
                    int rowHandle = gv.GetSelectedRows()[i];
                    HRFormModel item = (HRFormModel)gv.GetRow(rowHandle);
                    item.Status = status;
                    lstForms.Add(item);
                }
                if (lstForms.Count > 0)
                {
                    db.UpdateStatusListForm(lstForms);
                    RefreshData();
                    alertControl1.Show(this.FindForm(), "Successful", "Thành công");
                }
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<HRFormModel> lstForm = new List<HRFormModel>();
            HRFormModel item = null;
            foreach (int rowHandle in gv.GetSelectedRows())
            {
                item = (HRFormModel)gv.GetRow(rowHandle);
                if (item.Status != 2)
                {
                    MessageBox.Show("Vui lòng chỉ chọn nguyện vọng đang xử lý!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lstForm.Add(item);
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "NguyenVongExport.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {                
                //Lay ds hrform khong co reject truoc khi export
                //List<HRFormModel> lstForm = (List<HRFormModel>)bind.DataSource;
                //gc.DataSource = lstForm.Where(i => i.Status == 1);                
                gc.DataSource = lstForm;
                gc.MainView = gvExport;
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gvExport.BestFitColumns();
                gvExport.ExportToXlsx(file.FileName);

                //Quay lai ds hrform ban dau
                gc.DataSource = bind.DataSource;
                gc.MainView = gv;
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void btnGetRoute_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            List<HRFormModel> lstForms = new List<HRFormModel>();
            bool isAdd = false;
            foreach (int rowIndex in gv.GetSelectedRows())
            {
                isAdd = false;
                HRFormModel hrFrom = (HRFormModel)gv.GetRow(rowIndex);
                if (hrFrom == null || !string.IsNullOrWhiteSpace(hrFrom.Route) || string.IsNullOrWhiteSpace(hrFrom.Content)) continue;
                string content = hrFrom.Content.ToUpper() + " ";
                var regexFlNoObj = new Regex(@"VN(\d+)");
                var matchFlNo = regexFlNoObj.Matches(content);
                if (matchFlNo.Count > 0 && matchFlNo[0].Groups.Count > 0)
                {
                    hrFrom.FlightNo = matchFlNo[0].Groups[0].Value.Trim();
                    isAdd = true;                    
                }

                var regexRouteObj = new Regex(@"\w\w\w(-\w\w\w)+");
                var matchRoute = regexRouteObj.Matches(content);
                if (matchRoute.Count > 0 && matchRoute[0].Groups.Count > 0)
                {
                    hrFrom.Route = matchRoute[0].Groups[0].Value.Trim();
                    isAdd = true;                    
                }
                if (isAdd)
                    lstForms.Add(hrFrom);
                //var regexObj = new Regex(@"@(\S*)\s");
                ////var regexFlightNoObj = new Regex(@"@(.*)");
                //var matchFrom = regexObj.Matches(content);
                ////var matchFlightNo = Regex.Match(hrFrom.Content, @"@(.*)", RegexOptions.RightToLeft);
                //if (matchFrom.Count >= 2)
                //{
                //    hrFrom.Route = matchFrom[0].Groups[1].Value.Trim();
                //    hrFrom.FlightNo = matchFrom[1].Groups[1].Value.Trim();
                //    lstForms.Add(hrFrom);
                //}
                //else if (matchFrom.Count == 1)
                //{
                //    hrFrom.Route = matchFrom[0].Groups[1].Value.Trim();
                //    //hrFrom.FlightNo = matchFrom[1].Groups[1].Value.Trim();
                //    lstForms.Add(hrFrom);
                //}
            }
            if (lstForms.Count > 0)
            {
                db.UpdateStatusListForm(lstForms);
                gc.RefreshDataSource();
                DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }            
            SplashScreenManager.CloseForm(false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmImportForm form = new FrmImportForm();
            //form.MdiParent = this.ParentForm;             
            if (form.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                RefreshData();
                SplashScreenManager.CloseForm(false);
            }
        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string formCategory = view.GetRowCellDisplayText(e.RowHandle, "Category_ID");
            var fromDateValue = view.GetRowCellValue(e.RowHandle, "From_Date");

            DateTime? fromDate = null;
            if (fromDateValue != null)
                fromDate = (DateTime)view.GetRowCellValue(e.RowHandle, "From_Date");

            if (e.Column.FieldName == "Category_ID" && !string.IsNullOrWhiteSpace(formCategory))
            {
                if (formCategory.Contains("ốm"))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.White;
                }
                    //e.Appearance.TextOptions.HAlignment = _mark ? HorzAlignment.Far : HorzAlignment.Near;
            }

            if (e.Column.FieldName == "From_Date" && fromDate != null)
            {
                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
                DateTime maxDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 59).AddDays(2);

                if (fromDate >= now && fromDate <= maxDay)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.BackColor2 = Color.White;
                }
                //e.Appearance.TextOptions.HAlignment = _mark ? HorzAlignment.Far : HorzAlignment.Near;
            }
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void bbiExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //List<HRFormModel> lstForm = new List<HRFormModel>();
            //HRFormModel item = null;
            //foreach (int rowHandle in gv.GetSelectedRows())
            //{
            //    item = (HRFormModel)gv.GetRow(rowHandle);
            //    lstForm.Add(item);
            //}

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "NguyenVong.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                //gc.DataSource = lstForm;
                //gc.MainView = gvBaoCao;
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                gv.ExportToXlsx(file.FileName);
                //gvBaoCao.BestFitColumns();
                //gvBaoCao.ExportToXlsx(file.FileName);

                //Quay lai ds hrform ban dau
                //gc.DataSource = bind.DataSource;
                //gc.MainView = gv;
                System.Diagnostics.Process.Start(file.FileName);

                ////foreach (GridColumn column in gv.Columns)
                ////{                    
                ////    column.Width = column.Width + 30;
                ////}
                //gc.MainView = gvBaoCao;
                //ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                //gvBaoCao.BestFitColumns();
                //gvBaoCao.ExportToXlsx(file.FileName);
                //gc.MainView = gv;
                ////foreach (GridColumn column in gv.Columns)
                ////{
                ////    if (column.FieldName == "Content" || column.FieldName == "ReplyInfo")
                ////        continue;
                ////    column.BestFit();
                ////}
                //System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void bbiReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gv.GetSelectedRows().Length > 0)
            {
                dsForm ds = new dsForm();
                int rowHandle = gv.GetSelectedRows()[0];
                HRFormModel model = (HRFormModel)gv.GetRow(rowHandle);
                Sys_Account account = null;
                Ticket_Employee te = null;
                if (!string.IsNullOrWhiteSpace(model.CID))
                {
                    account = db.getAccountByCID(model.CID);
                    te = db.getTicketEmployeeByCID(model.CID);
                }
                
                if (model != null)
                    addForm(ds, model);
                if (account != null)
                    addAccount(ds, account);
                if (te != null)
                {
                    addTicketEmployee(ds, te);
                }

                RpForm xrpt = new RpForm();
                xrpt.DataSource = ds;                
                using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }

        private void addForm(dsForm ds, HRFormModel form)
        {
            try
            {
                dsForm.HR_FormsRow returnValue = ds.HR_Forms.NewHR_FormsRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = form.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null || sourcePi.GetValue(form, null) == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(form, null), null);
                }
                ds.HR_Forms.AddHR_FormsRow(returnValue);
            }
            catch { }
        }

        private void addAccount(dsForm ds, Sys_Account account)
        {
            try
            {
                dsForm.Sys_AccountRow returnValue = ds.Sys_Account.NewSys_AccountRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = account.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null || sourcePi.GetValue(account, null) == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(account, null), null);
                }
                ds.Sys_Account.AddSys_AccountRow(returnValue);
            }
            catch { }
        }
        private void addTicketEmployee(dsForm ds, Ticket_Employee account)
        {
            try
            {
                dsForm.Ticket_EmployeeRow returnValue = ds.Ticket_Employee.NewTicket_EmployeeRow();
                PropertyInfo[] destProperties = returnValue.GetType().GetProperties();
                foreach (PropertyInfo destPi in destProperties)
                {
                    PropertyInfo sourcePi = account.GetType().GetProperty(destPi.Name);
                    if (sourcePi == null || sourcePi.GetValue(account, null) == null)
                        continue;
                    destPi.SetValue(returnValue, sourcePi.GetValue(account, null), null);
                }
                ds.Ticket_Employee.AddTicket_EmployeeRow(returnValue);
            }
            catch { }
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Down)
            {
                if (flyoutPanel1.IsPopupOpen)
                    flyoutPanel1.HidePopup();
                else
                    flyoutPanel1.ShowPopup();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            flyoutPanel1.HidePopup();
        }

        private void txtFromdate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DateEdit editor = (DateEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                editor.EditValue = null;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gv.GetSelectedRows().Length > 0)
            {
                dsForm ds = new dsForm();
                int rowHandle = gv.GetSelectedRows()[0];
                HRFormModel model = (HRFormModel)gv.GetRow(rowHandle);
                Sys_Account account = null;
                Ticket_Employee te = null;
                if (!string.IsNullOrWhiteSpace(model.CID))
                {
                    account = db.getAccountByCID(model.CID);
                    te = db.getTicketEmployeeByCID(model.CID);
                }

                if (model != null)
                    addForm(ds, model);
                if (account != null)
                {
                    account.name_tv = account.name_tv.Trim();                    
                    addAccount(ds, account);
                }
                if (te != null)
                {
                    addTicketEmployee(ds, te);
                }


                RPXemXetHDLD xrpt = new RPXemXetHDLD();
                xrpt.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(xrpt))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }
    }
}