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
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Export;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmEmMessage : ERMs.SharedBase.XtraFormMDIBase
    {
        #region Properties
        EMMessageDal db = new EMMessageDal();
        Dictionary<int, string> messageStatus;
        #endregion

        private void InitView()
        {
            gv.Columns.Clear();
            gv.OptionsView.EnableAppearanceEvenRow = true;
            gv.OptionsBehavior.ReadOnly = true;
            gv1.OptionsView.EnableAppearanceEvenRow = true;
            gv1.OptionsBehavior.ReadOnly = true;

            GridColumn col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID Người gửi";
            col.FieldName = "SenderID";            
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Người gửi";
            col.FieldName = "Sender";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID Người nhận";
            col.FieldName = "ReceiverID";
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Người nhận";
            col.FieldName = "Receiver";            
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Số ĐT";
            col.FieldName = "PhoneNo";
            col.Visible = true;
            gv.Columns.Add(col);
            
            col = new GridColumn();
            col.Caption = "Tin nhắn";
            col.FieldName = "Message";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 400;
            col.Visible = true;
            gv.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "Attachments";
            //col.FieldName = "Attachments";
            //col.Visible = true;
            //gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ghi chú";
            col.FieldName = "Note";
            col.Visible = true;
            gv.Columns.Add(col);
            
            RepositoryItemImageComboBox statusImageCbx = new RepositoryItemImageComboBox();            
            statusImageCbx.SmallImages = imageListStatus;
            statusImageCbx.AutoHeight = false;
            List<KeyValuePair<int, string>> lstImage = messageStatus.ToList();
            foreach (var message in messageStatus)
            {
                DevExpress.XtraEditors.Controls.ImageComboBoxItem item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                item.Description = message.Value;
                item.Value = message.Key;
                item.ImageIndex = lstImage.IndexOf(message);
                statusImageCbx.Items.Add(item);                
            }

            col = new GridColumn();
            col.Caption = "Tình trạng XL";
            col.FieldName = "Status";
            col.ColumnEdit = statusImageCbx;
            col.Visible = true;
            gv.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày đọc";
            col.FieldName = "Readtime";
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.Visible = true;
            gv.Columns.Add(col);


            gv1.Columns.Clear();
            col = new GridColumn();
            col.Caption = "ID";
            col.FieldName = "ID";
            col.Fixed = FixedStyle.Left;
            col.Visible = true;
            col.OptionsColumn.AllowEdit = false;
            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            col.SummaryItem.DisplayFormat = "{0:n0}";
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "ID người gửi";
            col.FieldName = "SenderID";
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Người gửi";
            col.FieldName = "Sender";
            col.Visible = true;
            gv1.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "ReceiverID";
            //col.FieldName = "ReceiverID";
            //col.Visible = true;
            //gv1.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "Receiver";
            //col.FieldName = "Receiver";
            //col.Visible = true;
            //gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Số ĐT";
            col.FieldName = "PhoneNo";
            col.Visible = true;
            gv1.Columns.Add(col);
            
            col = new GridColumn();
            col.Caption = "Tin nhắn";
            col.FieldName = "Message";
            col.ColumnEdit = new RepositoryItemMemoEdit();
            col.Width = 400;
            col.Visible = true;
            gv1.Columns.Add(col);

            //col = new GridColumn();
            //col.Caption = "Attachments";
            //col.FieldName = "Attachments";
            //col.Visible = true;
            //gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ghi chú";
            col.FieldName = "Note";
            col.Visible = true;
            gv1.Columns.Add(col);
            

            col = new GridColumn();
            col.Caption = "Tình trạng XL";
            col.FieldName = "Status";
            col.ColumnEdit = statusImageCbx;
            col.Visible = true;
            gv1.Columns.Add(col);

            col = new GridColumn();
            col.Caption = "Ngày đọc";
            col.FieldName = "Readtime";
            col.Visible = true;
            gv1.Columns.Add(col);
        }
        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? DateTime.Today.AddDays(-1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            string searchString = txtSearch.Text.Trim();
            gc.DataSource = db.GetListParentMessage(fromdate, todate, searchString);
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName == "Message")
                    continue;
                column.BestFit();
            }
            //gv.BestFitColumns();         
        }
        public FrmEmMessage()
        {
            InitializeComponent();
        }

        private void FrmEmMessage_Load(object sender, EventArgs e)
        {
            messageStatus = new Dictionary<int, string>();
            messageStatus.Add(0, "Chưa gửi");
            messageStatus.Add(1, "Đã gửi");
            messageStatus.Add(2, "Đã nhận");
            messageStatus.Add(4, "Chưa dọc");
            messageStatus.Add(8, "Đã đọc");
            messageStatus.Add(16, "Đã trả lời");
            messageStatus.Add(32, "Đồng ý");
            messageStatus.Add(64, "Từ chối");
            messageStatus.Add(128, "Trả lời");
            InitView();
            RefreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            RefreshData();
            SplashScreenManager.CloseForm(false);
        }

        private void gv_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            GridView view = sender as GridView;
            EMMessageModel item = (EMMessageModel)view.GetRow(e.RowHandle);
            if (item == null) return;
            item.Items = db.GetListChildMessageByParentMessageID(item.ID);
        }

        private void gv_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            //if (view.IsZoomedView)
            //    view.OptionsView.ShowFooter = true;
            //else
            //    view.OptionsView.ShowFooter = false;
            GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            //if (view.IsZoomedView)
            //    view.OptionsView.ShowFooter = true;
            //else
            //    view.OptionsView.ShowFooter = false;
            detailView.BestFitColumns();
        }

        private void gv1_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsZoomedView)
                view.OptionsView.ShowFooter = true;
            else
                view.OptionsView.ShowFooter = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "Message.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                //gvExam.BestFitColumns();
                gv.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshData();
            }
        }
    }
}