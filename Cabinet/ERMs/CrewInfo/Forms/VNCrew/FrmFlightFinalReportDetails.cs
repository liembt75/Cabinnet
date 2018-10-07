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
using DevExpress.XtraEditors.Controls;
using Erms.Utils;
using System.Collections;
using System.Net;
using System.IO;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFlightFinalReportDetails : ERMs.SharedBase.XtraFormMDIBase
    {
        const int PPHKID = 3;

        public int ID = -1;
        bool create = false;
        bool read = false;
        bool update = false;
        bool delete = false;
        SystemDAL dbSystem = new SystemDAL();
        FlightDal dbFlight = new FlightDal();
        List<int> lstDepartmentID = new List<int>();
        public FrmFlightFinalReportDetails()
        {
            InitializeComponent();
        }
        private void FrmFlightFinalReportDetails_Load(object sender, EventArgs e)
        {
                            
            dbSystem.GetCRUD(ERMs.Sys.ConfigurationSetting.UserInfo.Userid, "D.C.R.01", out create, out read, out update, out delete);
            //groupControl8.Visible = update;
            lstDepartmentID = dbFlight.GetDepartmentByEmployeeID(ERMs.Sys.ConfigurationSetting.UserInfo.Userid).Select(i => i.DepartmentID).ToList();
            btnLog.Visible = btnCapNhat.Visible = update ? true : false; ;
            
            CR_Flight_FinalReport flightFinalReport = dbFlight.GetFlightFinalReportByID(ID);
            this.Text += " - ID: " + ID.ToString();
            if (flightFinalReport != null)
            {
                //switch (flightFinalReport.ReportStatus)
                //{
                //    case 0:
                //        btnMoKhoa.Visible = false;
                //        break;
                //    case 2:
                //        btnKhoa.Visible = false;
                //        break;
                //    case 1:
                //        btnMoKhoa.Visible = false;
                //        btnKhoa.Visible = false;
                //        break;
                //    default:
                //        btnMoKhoa.Visible = false;
                //        break;
                //}
                List<API_CR_USP_GetFlightCrew2_Result> lstFlightCrew = new List<API_CR_USP_GetFlightCrew2_Result>();
                lstFlightCrew.AddRange(dbFlight.GetFlightCrew2ByFlightID(flightFinalReport.FlightID.Value));
                gcFlightCrews.DataSource = lstFlightCrew;
                if (update && flightFinalReport.ReportStatus != 1 && flightFinalReport.ReportStatus != 2)
                    dbFlight.UpdateFlightFinalReportStatus(ID, 2, ERMs.Sys.ConfigurationSetting.UserInfo.Userid, ERMs.Sys.ConfigurationSetting.UserInfo.FullName);
                CR_FlightInfo flightInfo = dbFlight.GetFlightInfoByFlightID(flightFinalReport.FlightID.Value);
                if (flightInfo != null)
                {
                    lbPhiCong.Text = flightFinalReport.MainPilot;
                    lbChiTiet.Text = flightInfo.FlightNo + "      " + flightInfo.Routing + "      " + flightInfo.Date.ToString("dd/MM/yyyy") + "      " + flightInfo.TotalVIP + "      " + flightInfo.TotalPaxY + "      " + flightInfo.TotalPax + "      " + flightInfo.TotalPaxC;
                    lbChiTiet2.Text = "Aircraft: " + flightInfo.Aircraft + "      " + "Special meal: " + flightInfo.TotalSM + "      " + "UM: " + flightInfo.TotalUM + "      " + "WCHC: " + flightInfo.TotalWchr + "      " + "BSCT: " + flightInfo.TotalBSCT + "      " + "UM: " + flightInfo.TotalUM + "      " + "Inf: " + flightInfo.TotalINF + "      " + "CIP: " + flightInfo.TotalCIP;
                    lbChitiet3.Text = flightFinalReport.Creator;
                    //rcMucDo.
                    if (flightFinalReport.Emergency != null)
                    {
                        rcMucDo.Rating = flightFinalReport.Emergency.Value + 1;
                    }
                    memoNoiDung.Text = flightFinalReport.Content;
                    memoRely.Text = flightFinalReport.ReplyInfo;
                    string[] flightFinalReportSubCategory = flightFinalReport.Category.Replace(" ", "").Split(',');


                    List<int> mainCategory = new List<int>();
                    List<API_CR_USP_Flight_FinalReport_Get_Category_Result> lstCategory = dbFlight.GetFlightFinalReportCategory();
                    CheckedListBoxItem item = null;
                    foreach (API_CR_USP_Flight_FinalReport_Get_Category_Result category in lstCategory)
                    {
                        if (mainCategory.IndexOf(category.CategoryID.Value) == -1)
                        {
                            item = new CheckedListBoxItem();
                            item.Description = category.Category;
                            //item.Value = category.CategoryID.Value;
                            item.CheckState = CheckState.Unchecked;
                            item.Enabled = false;
                            cbxDanhMuc.Properties.Items.Add(item);
                            mainCategory.Add(category.CategoryID.Value);
                        }
                        item = new CheckedListBoxItem();
                        item.Description = category.SubCategory;
                        item.Value = category.SubCategoryID;
                        if (Array.IndexOf(flightFinalReportSubCategory, category.SubCategoryID.ToString()) != -1)
                            item.CheckState = CheckState.Checked;
                        cbxDanhMuc.Properties.Items.Add(item);
                    }

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
                            pb.ImageLocation = attachment.FilePath.Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn");
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
                }
            }
        }

        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox test = (PictureBox)sender;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(((PictureBox)sender).ImageLocation, Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));
            System.Diagnostics.Process.Start(Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));
            //FrmAttachmentDetail frm = new FrmAttachmentDetail();
            //frm.ImageUrl = ((PictureBox)sender).ImageLocation;
            //frm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "JPG|*.jpg";
            file.Title = "Lưu hình";
            file.ShowDialog();

            if (file.FileName.Trim() != "")
            {
                var menuItem = sender as ToolStripMenuItem;
                var contextMenu = menuItem.Owner as ContextMenuStrip;
                var pictureBox = contextMenu.SourceControl as PictureBox;
                pictureBox.Image.Save(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        //private void btnKhoa_Click(object sender, EventArgs e)
        //{
        //    dbFlight.UpdateFlightFinalReportStatus(ID, 2, account.ID, account.name);
        //    MessageBox.Show("Đã khóa báo cáo!");
        //    btnMoKhoa.Visible = true;
        //    btnKhoa.Visible = false;
        //}

        //private void btnMoKhoa_Click(object sender, EventArgs e)
        //{
        //    dbFlight.UpdateFlightFinalReportStatus(ID, 0, account.ID, account.name);
        //    MessageBox.Show("Đã mỡ khóa báo cáo!");
        //    btnMoKhoa.Visible = false;
        //    btnKhoa.Visible = true;
        //}

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CR_Flight_FinalReport_Replied_Log log = new CR_Flight_FinalReport_Replied_Log();

            CR_Flight_FinalReport flightFinalReport = dbFlight.GetFlightFinalReportByID(ID);
            if (flightFinalReport != null)
            {
                log.FinalReportID = flightFinalReport.ID;
                if (flightFinalReport.Category != cbxDanhMuc.EditValue.ToString().Replace(" ", ""))
                    log.Category = cbxDanhMuc.EditValue.ToString().Replace(" ", "");
                if (flightFinalReport.Emergency != (int)(rcMucDo.Rating - 1))
                    log.Emergency = (int)(rcMucDo.Rating - 1);

                flightFinalReport.Emergency = (int)(rcMucDo.Rating - 1);
                flightFinalReport.Category = cbxDanhMuc.EditValue.ToString().Replace(" ", "");
                log.Replierid = flightFinalReport.Replierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                log.Replied = flightFinalReport.Replied = DateTime.Now;
                log.Replier = flightFinalReport.Replier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                log.ReplyInfo = flightFinalReport.ReplyInfo = memoRely.Text;
                if (!string.IsNullOrEmpty(memoRely.Text))
                {
                    flightFinalReport.ReportStatus = 1;
                }
                flightFinalReport.Modified = DateTime.Now;
                flightFinalReport.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                flightFinalReport.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid;
            }
            //JsonUtils.SerializeObject(flightFinalReport);
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
                    API_CR_USP_GetFlightFinalReportByID_Result flightFinalReport = dbFlight.GetFullFlightFinalReportByID(ID);

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

                    DocUtility.MergeFile(ds, list, "FlightFinalReport.doc", file.FileName);
                    System.Diagnostics.Process.Start(file.FileName);
                }
            }
            catch { }
        }

        private void btnChuyenBoPhan_Click(object sender, EventArgs e)
        {
            FrmFlightFinalReportDepartment frm = new FrmFlightFinalReportDepartment();
            frm.MdiParent = this.ParentForm;
            frm.ID = this.ID;            
            frm.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmFlightFinalReportRepliedLog frm = new FrmFlightFinalReportRepliedLog(this.ID);
            frm.ShowDialog();
        }
    }
}