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
using ERMs.Data.Flight;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Net;
using System.IO;
using Erms.Utils;
using System.Collections;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportDetail : ERMs.SharedBase.XtraFormMDIBase
    {
        int _ID = -1;
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;
        SystemDAL dbSystem = new SystemDAL();
        FlightDal dbFlight = new FlightDal();
        List<int> lstDepartmentID = new List<int>();
        List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstSeletedCategory = new List<API_CR_USP_Flight_FinalReport_Get_Category_Result>();
        public FrmFlightFinalReportDetail(int ID)
        {
            InitializeComponent();
            _ID = ID;
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.C.R.01", out create, out read, out update, out delete);
            lstDepartmentID = dbFlight.GetDepartmentByEmployeeID(ERMs.Sys.ConfigurationSetting.UserInfo.Userid).Select(i => i.DepartmentID).ToList();
            btnLog.Visible = btnCapNhat.Visible = btnAddDepartment.Visible = update ? true : false;
            CR_Flight_FinalReport flightFinalReport = dbFlight.GetFlightFinalReportByID(_ID);
            this.Text += " - ID: " + _ID.ToString();
            if (flightFinalReport != null)
            {                
                List<API_CR_USP_GetFlightCrew2_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrew2_Result>();
                lstFlightCrew.AddRange(dbFlight.GetFlightCrew2ByFlightID(flightFinalReport.FlightID.Value));
                gcFlightCrews.DataSource = lstFlightCrew;
                //status:
                //1 da tra loi tiep vien
                //2 dang xu ly (nguoi xu ly da xem bao cao)
                //if (update && flightFinalReport.ReportStatus != 1 && flightFinalReport.ReportStatus != 2)
                    //dbFlight.UpdateFlightFinalReportStatus(_ID, 2, ERMs.Sys.ConfigurationSetting.UserInfo.Userid, ERMs.Sys.ConfigurationSetting.UserInfo.UserName);
                CR_FlightInfo flightInfo = dbFlight.GetFlightInfoByFlightID(flightFinalReport.FlightID.Value);
                if (flightInfo != null)
                {
                    StringBuilder flightInfoSB = new StringBuilder();
                    flightInfoSB.Append(string.Format("- Người báo cáo: {0}\r\n\r\n- FlightNo: {1}      Routing: {2}      Departed: {3}      Arrived: {4}      VIP: {5}      Pax: {6}      PaxC: {7}      PaxY: {8}      \r\n\r\n- Aircraft: {9}      RegisterNo: {10}      Special meal: {11}      UM: {12}      WCHC: {13}      BSCT: {14}      UM: {15}      Inf: {16}      CIP: {17}"
                                        , string.Format("{0} {1}", flightFinalReport.Creator, flightFinalReport.Created.Value.ToString("dd/MM/yyyy hh:mm:ss tt"))
                                        , flightInfo.FlightNo
                                        , flightInfo.Routing
                                        , flightInfo.Departed == null ? "" : flightInfo.Departed.Value.ToString("dd/MM/yyyy hh:mm:ss tt")
                                        , flightInfo.Arrived == null ? "" : flightInfo.Arrived.Value.ToString("dd/MM/yyyy hh:mm:ss tt")
                                        , flightInfo.TotalVIP
                                        , flightInfo.TotalPax
                                        , flightInfo.TotalPaxC
                                        , flightInfo.TotalPaxY
                                        , flightInfo.Aircraft
                                        , flightInfo.RegisterNo
                                        , flightInfo.TotalSM
                                        , flightInfo.TotalUM
                                        , flightInfo.TotalWchr
                                        , flightInfo.TotalBSCT
                                        , flightInfo.TotalUM
                                        , flightInfo.TotalINF
                                        , flightInfo.TotalCIP));
                    //flightInfoSB.Append(flightFinalReport.Creator);
                    //flightInfoSB.Append("\r\n");
                    memoFlightInfo.Text = flightInfoSB.ToString();
                    //lbPhiCong.Text = flightFinalReport.MainPilot;
                    //lbChiTiet.Text = flightInfo.FlightNo + "      " + flightInfo.Routing + "      " + flightInfo.Date.ToString("dd/MM/yyyy") + "      " + flightInfo.TotalVIP + "      " + flightInfo.TotalPaxY + "      " + flightInfo.TotalPax + "      " + flightInfo.TotalPaxC;
                    //lbChiTiet2.Text = "Aircraft: " + flightInfo.Aircraft + "      " + "Special meal: " + flightInfo.TotalSM + "      " + "UM: " + flightInfo.TotalUM + "      " + "WCHC: " + flightInfo.TotalWchr + "      " + "BSCT: " + flightInfo.TotalBSCT + "      " + "UM: " + flightInfo.TotalUM + "      " + "Inf: " + flightInfo.TotalINF + "      " + "CIP: " + flightInfo.TotalCIP;
                    //lbChitiet3.Text = flightFinalReport.Creator;
                    //rcMucDo.
                    if (flightFinalReport.Emergency != null)
                    {
                        rcMucDo.Rating = flightFinalReport.Emergency.Value + 1;
                    }
                    //string test = System.Text.RegularExpressions.Regex.Replace(flightFinalReport.Content, "(?<!\r)\n", "\r\n");
                    memoNoiDung.Text = System.Text.RegularExpressions.Regex.Replace(flightFinalReport.Content, "(?<!\r)\n", "\r\n");
                    memoRely.Text = flightFinalReport.ReplyInfo;
                    string[] flightFinalReportSubCategory = flightFinalReport.Category.Replace(" ", "").Split(',');

                    
                    List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = dbFlight.GetFlightFinalReportCategory();
                    API_CR_USP_Flight_FinalReport_Get_Category_Result autoCategory = new API_CR_USP_Flight_FinalReport_Get_Category_Result();
                    autoCategory.SubCategoryID = -1;
                    autoCategory.Category = "Tự động";
                    autoCategory.SubCategory = "Tự động";
                    lstCategory.Insert(0, autoCategory);
                    foreach (API_CR_USP_Flight_FinalReport_Get_Category_Result category in lstCategory)
                    {
                        if (Array.IndexOf(flightFinalReportSubCategory, category.SubCategoryID.ToString()) != -1)
                            lstSeletedCategory.Add(category);
                    }
                    gcCategory.DataSource = lstCategory;
                    gridControl1.DataSource = lstSeletedCategory;

                    if (flightFinalReport.Attachments != null)
                    {
                        List<EX_Attachment> lstAttachment = dbFlight.GetFlightFinalReportAttachmentByGroupID(flightFinalReport.Attachments.Value);
                        //ImageListBoxItem attachmentItem = null;
                        int xIndex = 1;
                        foreach (EX_Attachment attachment in lstAttachment)
                        {
                            if (pcAttachment.Controls.Count > 0)
                            {
                                xIndex = pcAttachment.Controls[pcAttachment.Controls.Count - 1].Location.X + pcAttachment.Controls[pcAttachment.Controls.Count - 1].Width + 10;
                            }
                            PictureBox pb = new PictureBox();
                            //pb.ImageLocation = AttachmentUtils.GetAttachmentUrl(attachment.FilePath).Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn").Replace(@"D:/Sites/CrewAPI", @"https://api.crew.vn");
                            pb.ImageLocation = AttachmentUtils.GetAttachmentUrl(attachment.FilePath);
                            pb.Height = pcAttachment.Height - 1;
                            pb.Width = pcAttachment.Height - 1;
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Location = new Point(xIndex, 1);
                            pb.Cursor = Cursors.Hand;
                            pb.MouseClick += Pb_MouseClick;
                            pb.ContextMenuStrip = contextMenuStripAttachment;

                            pcAttachment.Controls.Add(pb);
                        }
                    }
                    
                    gridControl2.DataSource = dbFlight.GetFlightFinalReportDeparmentByFinalReportID(_ID);
                    UpdateSize();

                    //PopupContainerControl popupControl = new PopupContainerControl();
                    //popupControl.Controls.Add(gcCategory);
                    popupContainerControl1.Width = gridControl2.Width;
                    popupContainerControl1.Height = 250;
                    popupContainerEdit1.Properties.PopupControl = popupContainerControl1;
                }
            }
            xtraScrollableControl1.Focus();
        }

        private void UpdateSize()
        {
            //Update size danh sach tiep vien
            GridViewInfo viewInfo = (GridViewInfo)gvFlightCrew.GetViewInfo();
            FieldInfo fi = typeof(GridView).GetField("scrollInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            ScrollInfo scrollInfo = (ScrollInfo)fi.GetValue(gvFlightCrew);
            int height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;            
            height = Math.Min(ClientSize.Height - gcFlightCrews.Location.Y, height) + 20;            
            groupControl9.Size = new Size(groupControl9.Width, height);
            groupControl2.Size = new Size(groupControl2.Width, height);
            splitContainerControl1.Size = new Size(splitContainerControl1.Width, height + 65);

            viewInfo = (GridViewInfo)gridView2.GetViewInfo();
            fi = typeof(GridView).GetField("scrollInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            scrollInfo = (ScrollInfo)fi.GetValue(gridView2);
            height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;
            height = Math.Min(ClientSize.Height - gridControl2.Location.Y, height);
            groupControl3.Size = new Size(groupControl3.Width, height + 40);
            //Update size category
            //viewInfo = (GridViewInfo)gridView2.GetViewInfo();
            //scrollInfo = (ScrollInfo)fi.GetValue(gridView2);
            //height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            //if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;
            //height = Math.Min(ClientSize.Height - gridControl2.Location.Y, height);
            //groupControl3.Size = new Size(groupControl3.Width, height + 50);

            //Update y kien phan hoi grid size
            viewInfo = (GridViewInfo)gvYKPH.GetViewInfo();            
            scrollInfo = (ScrollInfo)fi.GetValue(gvYKPH);                    
            height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;                        
            height = Math.Min(ClientSize.Height - gridControl2.Location.Y, height);            
            groupControl5.Size = new Size(groupControl5.Width, height + 20);

            memoNoiDung.Properties.ScrollBars = ScrollBars.None;
            MemoEditViewInfo vi = memoNoiDung.GetViewInfo() as MemoEditViewInfo;
            GraphicsCache cache = new GraphicsCache(memoNoiDung.CreateGraphics());
            int h = (vi as DevExpress.XtraEditors.ViewInfo.IHeightAdaptable).CalcHeight(cache, vi.MaskBoxRect.Width);
            ObjectInfoArgs args = new ObjectInfoArgs();
            args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, h);
            Rectangle rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
            cache.Dispose();
            groupControl6.Size = new Size(groupControl6.Width, rect.Height + 20);

            //Size s = vi.CalcBestFit(memoNoiDung.CreateGraphics());
            //ObjectInfoArgs args = new ObjectInfoArgs();
            //args.Bounds = new Rectangle(0, 0, vi.ClientRect.Width, s.Height);
            //Rectangle rect = vi.BorderPainter.CalcBoundsByClientRectangle(args);
            ////memoNoiDung.Height = rect.Height;
            //groupControl6.Size = new Size(groupControl6.Width, rect.Height + 40);
        }

        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox test = (PictureBox)sender;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(((PictureBox)sender).ImageLocation, Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));
            System.Diagnostics.Process.Start(Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CR_Flight_FinalReport_Replied_Log log = new CR_Flight_FinalReport_Replied_Log();

            CR_Flight_FinalReport flightFinalReport = dbFlight.GetFlightFinalReportByID(_ID);
            if (flightFinalReport != null)
            {
                log.FinalReportID = flightFinalReport.ID;
                StringBuilder sbCategory = new StringBuilder();
                foreach (API_CR_USP_Flight_FinalReport_Get_Category_Result category in lstSeletedCategory)
                {
                    if (sbCategory.Length > 0)
                        sbCategory.Append(",");
                    sbCategory.Append(category.SubCategoryID);
                }
                if (flightFinalReport.Category != sbCategory.ToString())
                    log.Category = sbCategory.ToString();
                //if (flightFinalReport.Category != cbxDanhMuc.EditValue.ToString().Replace(" ", ""))
                //log.Category = cbxDanhMuc.EditValue.ToString().Replace(" ", "");
                if (flightFinalReport.Emergency != (int)(rcMucDo.Rating - 1))
                    log.Emergency = (int)(rcMucDo.Rating - 1);

                flightFinalReport.Emergency = (int)(rcMucDo.Rating - 1);
                //flightFinalReport.Category = cbxDanhMuc.EditValue.ToString().Replace(" ", "");
                flightFinalReport.Category = sbCategory.ToString();
                log.Replierid = flightFinalReport.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                log.Replied = flightFinalReport.Replied = DateTime.Now;
                log.Replier = flightFinalReport.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.UserName;
                log.ReplyInfo = flightFinalReport.ReplyInfo = memoRely.Text;
                if (!string.IsNullOrEmpty(memoRely.Text))
                {
                    flightFinalReport.ReportStatus = 1;
                }
                flightFinalReport.Modified = DateTime.Now;
                flightFinalReport.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                flightFinalReport.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
            }            
            dbFlight.UpdateFlightFinalReport(flightFinalReport);
            dbFlight.AddFinalReportRepliedLog(log);
            MessageBox.Show("Đã cập nhật báo cáo!");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Microsoft Word|*.doc";
                file.Title = "Save an Doc";
                file.FileName = "BaoCaoChuyenBay.doc";
                file.ShowDialog();

                if (file.FileName.Trim() != "")
                {
                    API_CR_USP_GetFlightFinalReportByID_Result flightFinalReport = dbFlight.GetFullFlightFinalReportByID(_ID);

                    List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = dbFlight.GetFlightFinalReportCategory();
                    List<FlightFinalReportModel> lstFlightFinalReport = new List<FlightFinalReportModel>();
                    lstFlightFinalReport.Add(new FlightFinalReportModel().ToModel(flightFinalReport, lstCategory));

                    List<API_CR_USP_GetFlightCrew2_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrew2_Result>();
                    foreach (FlightFinalReportModel reportModel in lstFlightFinalReport)
                    {
                        lstFlightCrew.AddRange(dbFlight.GetFlightCrew2ByFlightID(flightFinalReport.FlightID.Value));
                    }

                    DataSet ds = new DataSet();
                    DataTable dtFlightFinalReport = new DataTable("fr");
                    ListUtils.LoadRows(dtFlightFinalReport, lstFlightFinalReport);
                    ds.Tables.Add(dtFlightFinalReport);


                    DataTable dtFlightCrew = new DataTable("cr");
                    ListUtils.LoadRows(dtFlightCrew, lstFlightCrew);
                    ds.Tables.Add(dtFlightCrew);

                    List<DictionaryEntry> list = new List<DictionaryEntry>
                    {
                        new DictionaryEntry("fr", String.Empty),
                        new DictionaryEntry("cr", "FlightID = %fr.FlightID%")
                    };
                    //list = new List<DictionaryEntry>();

                    DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\FlightFinalReport.doc", file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmFlightFinalReportRepliedLog frm = new FrmFlightFinalReportRepliedLog(_ID);
            frm.ShowDialog();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            FrmFlightFinalReportAddDepartment frm = new FrmFlightFinalReportAddDepartment();
            frm.ID = _ID;
            frm.frmFD = this;
            frm.Show();
        }

        public void UpdateDepartment()
        {
            gridControl2.DataSource = dbFlight.GetFlightFinalReportDeparmentByFinalReportID(_ID);
            //Update y kien phan hoi grid size
            GridViewInfo viewInfo = (GridViewInfo)gvFlightCrew.GetViewInfo();
            FieldInfo fi = typeof(GridView).GetField("scrollInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            ScrollInfo scrollInfo = (ScrollInfo)fi.GetValue(gvFlightCrew);
            viewInfo = (GridViewInfo)gvYKPH.GetViewInfo();
            scrollInfo = (ScrollInfo)fi.GetValue(gvYKPH);
            int height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;
            height = Math.Min(ClientSize.Height - gridControl2.Location.Y, height);
            groupControl5.Size = new Size(groupControl5.Width, height + 20);
        }

        private void gvYKPH_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clRely)
            {
                API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(e.RowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;
                if (flightFinalReportDepartment.Replied != null || lstDepartmentID.IndexOf(flightFinalReportDepartment.DepartmentID) < 0)
                {
                    e.Appearance.FillRectangle(new DevExpress.Utils.Drawing.GraphicsCache(e.Graphics), e.Bounds);
                    e.Handled = true;
                }
            }
        }

        private void gvYKPH_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn == clRely)
            {
                API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(view.FocusedRowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;
                if (flightFinalReportDepartment.Replied != null || lstDepartmentID.IndexOf(flightFinalReportDepartment.DepartmentID) < 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void repositoryTraLoi_Click(object sender, EventArgs e)
        {
            API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result flightFinalReportDepartment = gvYKPH.GetRow(gvYKPH.FocusedRowHandle) as API_CR_USP_GetFlightFinalReportDeparmentByFinalReportID_Result;
            FrmFlightFinalReportDepartmentRely frm = new FrmFlightFinalReportDepartmentRely();
            frm.flightFinalReportDepartment = flightFinalReportDepartment;
            frm.frmFD = this;
            frm.Show();
        }

        private void popupContainerEdit1_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            int[] selectedRows = gridView1.GetSelectedRows();
            if (selectedRows.Length > 0)
                lstSeletedCategory.Clear();
            //StringBuilder sb = new StringBuilder();
            foreach (int selectionRow in selectedRows)
            {
                if (selectionRow < 0)
                    continue;
                API_CR_USP_Flight_FinalReport_Get_Category_Result f = gridView1.GetRow(selectionRow) as API_CR_USP_Flight_FinalReport_Get_Category_Result;
                lstSeletedCategory.Add(f);
                //if (sb.ToString().Length > 0) { sb.Append(", "); }
                //sb.Append(string.Format("[{0}] {1}", f.Category, f.SubCategory));
            }
            //e.Value = sb.ToString();
            gridView1.ClearSelection();
            gridView1.CollapseAllGroups();        
            gridControl1.RefreshDataSource();            
        }

        private void btnSelectCategory_Click(object sender, EventArgs e)
        {
            Control button = sender as Control;
            //Close the dropdown accepting the user's choice 
            popupContainerEdit1.ClosePopup();
        }

        private void popupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            //gridView1.ClearSelection();
            //object val = popupContainerEdit1.EditValue;
            //if (val == null)
            //    gridView1.ClearSelection();
            //else
            //{
            //    string[] texts = val.ToString().Split(',');
            //    foreach (string text in texts)
            //    {
            //        int rowHandle = gridView1.LocateByValue("FruitName", text.Trim());
            //        gridView1.SelectRow(rowHandle);
            //    }

            //}
        }

        private void gridView2_RowCountChanged(object sender, EventArgs e)
        {                       
            GridViewInfo viewInfo = (GridViewInfo)gridView2.GetViewInfo();
            FieldInfo fi = typeof(GridView).GetField("scrollInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            ScrollInfo scrollInfo = (ScrollInfo)fi.GetValue(gridView2);
            int height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            if (scrollInfo.HScrollVisible) height += scrollInfo.HScrollSize;
            height = Math.Min(ClientSize.Height - gridControl2.Location.Y, height);
            groupControl3.Size = new Size(groupControl3.Width, height + 40);
        }
    }
}