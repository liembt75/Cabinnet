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
using DevExpress.XtraEditors.Repository;
using CrewInfo.ADONet;
using CrewInfo.Reports;
using System.Reflection;
using DevExpress.XtraReports.UI;

namespace eTicket
{
    public partial class FrmFormHistory : ERMs.SharedBase.XtraFormMDIBase
    {
        FormDal db = new FormDal();
        Dictionary<int, string> messageStatus;
        List<HR_Form_Category> lstFormCategory = new List<HR_Form_Category>();

        public FrmFormHistory()
        {
            InitializeComponent();
        }

        private void FrmFormHistory_Load(object sender, EventArgs e)
        {
            //panelNav.Visible = false;
            gv.OptionsBehavior.ReadOnly = true;

            messageStatus = new Dictionary<int, string>();
            messageStatus.Add(-1, "All");
            messageStatus.Add(1, "New");
            messageStatus.Add(2, "Processing");
            messageStatus.Add(3, "Accept");
            messageStatus.Add(4, "Deny");

            lstFormCategory = db.GetFormCategory();
            InitView();
            RefreshData();
        }

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

            RepositoryItemLookUpEdit categoryLookUpEdit = new RepositoryItemLookUpEdit();
            categoryLookUpEdit.DataSource = lstFormCategory;
            categoryLookUpEdit.DisplayMember = "Name";
            categoryLookUpEdit.ValueMember = "ID";

            col = new GridColumn();
            col.Caption = "Category";
            col.FieldName = "Category_ID";
            col.ColumnEdit = categoryLookUpEdit;
            col.OptionsColumn.ReadOnly = true;
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
            col.Caption = "FromDate";
            col.FieldName = "From_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ToDate";
            col.FieldName = "To_Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);



            col = new GridColumn();
            col.Caption = "FlightNo";
            col.FieldName = "FlightNo";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Route";
            col.FieldName = "Route";
            col.OptionsColumn.ReadOnly = false;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Content";
            col.FieldName = "Content";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Width = 200;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Attachment";
            col.FieldName = "AttachmentText";
            col.ColumnEdit = new RepositoryItemHyperLinkEdit();
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Date";
            col.FieldName = "Date";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Replier";
            col.FieldName = "Replier";
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Replied";
            col.FieldName = "Replied";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.OptionsColumn.ReadOnly = true;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ReplyInfo";
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
            col.Caption = "Status";
            col.FieldName = "Status";
            col.ColumnEdit = statusImageCbx;
            col.OptionsColumn.ReadOnly = true;
            col.Fixed = FixedStyle.Right;
            col.Visible = true;
            gv.Columns.Add(col);

            //gv.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            //gv.OptionsSelection.MultiSelect = true;
            //gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            //gv.VisibleColumns[0].OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            //gv.OptionsPrint.AutoWidth = false;  
        }

        private void RefreshData()
        {
            string userID = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
            List<HRFormModel> lstForm = db.GetListFormByUser(userID);            
            gc.DataSource = lstForm;
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName == "Content" || column.FieldName == "ReplyInfo")
                    continue;
                column.BestFit();
            }
            //gv.BestFitColumns();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gv.GetSelectedRows().Length > 0)
            {
                dsForm ds = new dsForm();
                int rowHandle = gv.GetSelectedRows()[0];
                HRFormModel model = (HRFormModel)gv.GetRow(rowHandle);
                Sys_Account account = null;
                if (!string.IsNullOrWhiteSpace(model.CID))
                {
                    account = db.getAccountByCID(model.CID);
                }

                if (model != null)
                    addForm(ds, model);
                if (account != null)
                    addAccount(ds, account);


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

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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