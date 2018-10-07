using DevExpress.Export;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using ERMs.Data;
using ERMs.SharedBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmTicketBooking : ERMs.SharedBase.XtraFormMDIBase
    {
        SystemDAL dbSystem = new SystemDAL();
        BindingSource dataSource = new BindingSource();
        GridColumn colID, colResCode, colIssued, colDate, colTicketNo, colPassenger, colSabreStatus, colSabResponse, colSitaAddress, colSabRouting, colLoaded;
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;

        public GridColumn ColID
        {
            get
            {
                return colID;
            }

            set
            {
                colID = value;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "TicketBooking.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.WYSIWYG;                
                gridView1.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }

        public FrmTicketBooking():base()
        {
            InitializeComponent();
            LayoutInitial();
            //LoadData();
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.L.B.01", out create, out read, out update, out delete);
            if (update == false)
                btnCapNhat.Visible = false;
        }

       

        private void FrmTicketBooking_Load(object sender, EventArgs e)
        {
            //LoadData();
            txtKeyword.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                List<USP_Ticket_Booking_Result> lstBookingPending = new List<USP_Ticket_Booking_Result>();
                USP_Ticket_Booking_Result booking = null;
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    booking = (USP_Ticket_Booking_Result)gridView1.GetRow(rowIndex);
                    if (booking == null) return;
                    booking.Pending = true;
                    lstBookingPending.Add(booking);                    
                }
                TicketDal db = new TicketDal();
                db.UpdateTicketBookPending(lstBookingPending);
                SplashScreenManager.CloseForm(false);

                MessageBox.Show("Thao tác cập nhật tình trạng vé sẽ mất vài giờ. \nAnh/Chị vui lòng chờ đợi, xin cám ơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Internal
        private void LayoutInitial()
        {
            this.Text = "Booking";
            txtKeyword.Properties.ShowNullValuePromptWhenFocused = true;
            txtKeyword.Properties.NullValuePromptShowForEmptyValue = true;
            txtKeyword.Properties.NullValuePrompt = "trave -> lấy các vé đề nghị hoàn (OK, USED, RFND, EXCH là Chưa sử dụng, đã dùng, đã hoàn, đổi)";
            gridControl1.Dock = DockStyle.Fill;
            #region Main View

            RepositoryItemDateEdit repoDate = new RepositoryItemDateEdit();
            repoDate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repoDate.Mask.EditMask = "dd MMM";
            repoDate.Mask.UseMaskAsDisplayFormat = true;
            repoDate.CharacterCasing = CharacterCasing.Upper;

            gridView1.OptionsPrint.AutoWidth = false;
            ColID = new GridColumn();
            ColID.Caption = "#";
            ColID.FieldName = "ID";
            ColID.Width = 40;
            ColID.Visible = true;
            ColID.Fixed = FixedStyle.Right;

            colResCode = new GridColumn();
            colResCode.Caption = "Code";
            colResCode.FieldName = "ResCode";
            colResCode.Width = 50;
            colResCode.Visible = true;

            colIssued = new GridColumn();
            colIssued.Caption = "Issue";
            colIssued.FieldName = "IssueDate";
            colIssued.Width = 70;
            colIssued.Visible = true;
            colIssued.ColumnEdit = repoDate;


            colDate = new GridColumn();
            colDate.Caption = "Departed";
            colDate.FieldName = "SabDepartdate";
            colDate.Width = 70;
            colDate.Visible = true;
            colDate.Fixed = FixedStyle.Right;
            colDate.ColumnEdit = repoDate;

            colTicketNo = new GridColumn();
            colTicketNo.Caption = "Ticket";
            colTicketNo.FieldName = "TicketNo";
            colTicketNo.Width = 100;
            colTicketNo.Visible = true;
            colTicketNo.Fixed = FixedStyle.Left;
            colTicketNo.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            colTicketNo.SummaryItem.DisplayFormat = "{0:n0}";

            colPassenger = new GridColumn();
            colPassenger.Caption = "Passenger";
            colPassenger.FieldName = "Passenger";
            colPassenger.Width = 150;
            colPassenger.Visible = true;

            colSabreStatus = new GridColumn();
            colSabreStatus.Caption = "Stat";
            colSabreStatus.FieldName = "SabreStatus";
            colSabreStatus.Width = 150;
            colSabreStatus.Visible = true;

         
            //RepositoryItemMemoEdit riTitle = new RepositoryItemMemoEdit();
            //colTitle.ColumnEdit = riTitle;
            //colTitle.AppearanceCell.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold | FontStyle.Underline);
            //colTitle.AppearanceCell.ForeColor = Color.Blue;
            //colTitle.AppearanceCell.Options.UseFont = true;
            //colTitle.AppearanceCell.Options.UseForeColor = true;

            colSabResponse = new GridColumn();
            colSabResponse.Caption = "Sab";
            colSabResponse.FieldName = "SabResponse";
            colSabResponse.Width = 200;
            colSabResponse.Visible = false;
            colSabResponse.ColumnEdit = new RepositoryItemMemoEdit();

            colSitaAddress = new GridColumn();
            colSitaAddress.Caption = "Sita";
            colSitaAddress.FieldName = "SitaAddress";
            colSitaAddress.Width = 50;
            colSitaAddress.Visible = true;

            colSabRouting = new GridColumn();
            colSabRouting.Caption = "Routing";
            colSabRouting.FieldName = "SabRouting";
            colSabRouting.Width = 50;
            colSabRouting.Visible = true;

            colLoaded = new GridColumn();
            colLoaded.Caption = "Loaded";
            colLoaded.FieldName = "SabDate";
            colLoaded.Width = 50;
            colLoaded.Visible = true;

            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(new GridColumn[] { ColID, colResCode, colIssued, colDate, colTicketNo, colPassenger, colSabreStatus, colSabResponse, colSitaAddress, colSabRouting, colLoaded });
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

            //Show checkbox
            //gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader =DevExpress.Utils.DefaultBoolean.True;
            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;


            // Create and setup the first summary item.
            GridGroupSummaryItem groupItem = new GridGroupSummaryItem();
            groupItem.FieldName = "Passenger";
            groupItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            //gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            groupItem.DisplayFormat = "({0:n0} items)";
            gridView1.GroupSummary.Add(groupItem);

            #endregion


            #region Style format

            StyleFormatCondition styleVIP, styleCIP, styleSM, styleINF;
            ////styleVIP.Appe arance.ForeColor = Color.Orange;
            //styleVIP = new StyleFormatCondition(FormatConditionEnum.Greater, colVip, null, 0);
            //styleVIP.Appearance.BackColor = Color.Yellow;
            //styleVIP.Appearance.BackColor2 = Color.GreenYellow;
            //styleVIP.ApplyToRow = true;
            //gvFlightInfo.FormatConditions.Add(styleVIP);

            //StyleFormatCondition styleDeh;
            ////styleVIP.Appe arance.ForeColor = Color.Orange;
            //styleDeh = new StyleFormatCondition(FormatConditionEnum.NotEqual, gvFlightCrew.Columns["FO_Cfg"], null, "");
            //styleDeh.Appearance.BackColor = Color.Gray;
            //styleDeh.Appearance.BackColor2 = Color.GreenYellow;
            //styleDeh.ApplyToRow = true;
            //gvFlightCrew.FormatConditions.Add(styleDeh);
            #endregion
        }
        public void LoadData()
        {

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(ERMs.SharedBase.WaitFormDefault), true, true, false);

            if (txtFromdate.EditValue == null) txtFromdate.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            if (txtTodate.EditValue == null) txtTodate.DateTime = DateTime.Today;

            TicketDal db = new TicketDal();
            dataSource.DataSource = db.GetBooking(txtFromdate.DateTime, txtTodate.DateTime, txtKeyword.Text.Trim());
            gridControl1.DataSource = dataSource;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
        #endregion
    }
}
