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
using ERMs.Data.Task;
using ERMs.Data;
using Erms.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System.Net;
using System.IO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using ERMs.Data.Support;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSupportDetail : ERMs.SharedBase.XtraFormMDIBase
    {
        int supportId;
        SupportDal dbSupport = new SupportDal();
        SystemDAL dbSystem = new SystemDAL();
        FrmSupport frmSupport = null;
        public FrmSupportDetail()
        {
            InitializeComponent();
        }

        public FrmSupportDetail(int id, FrmSupport iFrmSupport) :this()
        {
            supportId = id;
            frmSupport = iFrmSupport;
        }

        private void FrmSupportDetail_Load(object sender, EventArgs e)
        {            
            this.Text += " - " + supportId;            
            txtMessage.Focus();
            UpdateGridView();
            StyleFormatCondition styleAccount;
            styleAccount = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["Sender"], null, ERMs.Sys.ConfigurationSetting.UserInfo.ShortName);
            styleAccount.Appearance.BackColor = Color.LightGreen;
            styleAccount.Appearance.ForeColor = Color.White;
            styleAccount.ApplyToRow = true;
            //gridView1.FormatConditions.Add(styleAccount);
            //List<TiepVienLookUpModel> lstSysAccount = dbSystem.GetSysAccounts();
            List<TiepVienLookUpModel> lstSysAccount = frmSupport.lstSysAccount;
            lookUpTV.Properties.DataSource = lstSysAccount;
            lookUpTV.Properties.DisplayMember = "FirstNameVn";
            lookUpTV.Properties.ValueMember = "Code_tv";

            lookUpNV.Properties.DataSource = lstSysAccount.ToList();
            lookUpNV.Properties.DisplayMember = "FirstNameVn";
            lookUpNV.Properties.ValueMember = "Code_tv";            
        }

        public void UpdateGridView()
        {
            gridControl1.DataSource = dbSupport.GetListSupportBySupportID(supportId);
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
                MessageBox.Show("Vui lòng nhập text");
            else
            {
                ER_Support support = new ER_Support();
                support.ParentID = supportId;
                support.Sender = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                support.Message = txtMessage.Text;
                support.Created = DateTime.Now;
                support.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                support.Modified = DateTime.Now;
                support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                support.Status = 1;
                dbSupport.AddSupport(support);
                txtMessage.Text = "";
                UpdateGridView();
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Images | *.png; *.bmp; *.jpg; *.jpeg";
                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    List<string> lstFile = new List<string>();
                    lstFile.Add(file.FileName);
                    int groupID = ApiUtils.UploadSupportFiles(lstFile, ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString(), ERMs.Sys.ConfigurationSetting.UserInfo.Token, supportId.ToString());
                    if (groupID != -1)
                    {
                        //ER_Support support = new ER_Support();
                        //support.ParentID = supportId;
                        //support.Sender = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                        //support.Message = txtMessage.Text;
                        //support.AttachmentId = groupID;
                        //support.Created = DateTime.Now;
                        //support.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                        //support.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //support.Modified = DateTime.Now;
                        //support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                        //support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        //support.Status = 1;
                        //dbSupport.AddSupport(support);
                        txtMessage.Text = "";
                        UpdateGridView();
                    }
                }
            }
            catch { }
        }

        private void gridView1_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            int dx = 5;
            // A rectangle for displaying text.            
            Rectangle r = e.Bounds;
            r.X += dx * 2;            
            r.Width -= dx * 3;

            Rectangle rImage = e.Bounds;
            rImage.X += dx * 2;
            rImage.Y += dx;
            rImage.Width -= dx * 3;
            
            API_ER_USP_Get_Support_BySupportID_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Support_BySupportID_Result;
            //if (support.Sender == ERMs.Sys.ConfigurationSetting.UserInfo.ShortName)
            //{
            //    e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            //}
            //else
            //{
            //    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            //}
            if (!string.IsNullOrEmpty(support.FilePath))
            {
                var webClient = new WebClient();
                //byte[] imageBytes = webClient.DownloadData(support.FilePath.Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn"));
                byte[] imageBytes = webClient.DownloadData(AttachmentUtils.GetAttachmentUrl(support.FilePath));
                Image image = DevExpress.XtraEditors.Controls.ByteImageConverter.FromByteArray(imageBytes);                
                var ratioX = (double)150 / image.Width;
                var ratioY = (double)150 / image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);


                e.Graphics.DrawImage(image, rImage.X, rImage.Y, newWidth, newHeight);
            }
            else
                e.Appearance.DrawString(e.Cache, view.GetRowPreviewDisplayText(e.RowHandle), r, Brushes.Black);
            // No default painting is required
            e.Handled = true;
        }

        private void gridView1_MeasurePreviewHeight(object sender, RowHeightEventArgs e)
        {
            GridView view = sender as GridView;            
            if (!string.IsNullOrEmpty(((API_ER_USP_Get_Support_BySupportID_Result)view.GetRow(e.RowHandle)).FilePath))
                e.RowHeight = 100;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell == false && hitInfo.InRow == true)
            {
                GridView view = sender as GridView;
                API_ER_USP_Get_Support_BySupportID_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Support_BySupportID_Result;
                if (!string.IsNullOrEmpty(support.FilePath))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(AttachmentUtils.GetAttachmentUrl(support.FilePath), Path.GetTempPath() + Path.GetFileName(support.FilePath));
                    System.Diagnostics.Process.Start(Path.GetTempPath() + Path.GetFileName(support.FilePath));
                }
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            try
            {
                GridView view = sender as GridView;
                API_ER_USP_Get_Support_BySupportID_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Support_BySupportID_Result;
                switch (e.Column.Name)
                {
                    case "clHide":
                        support.Status = 5;
                        dbSupport.UpdateSupportStatus(support);
                        UpdateGridView();
                        break;
                    case "clDelete":
                        support.Status = 4;
                        dbSupport.UpdateSupportStatus(support);
                        UpdateGridView();
                        break;
                }
            } 
            catch { }                           
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {            
            dbSupport.UpdateSupportStatusBySupportID(supportId, 2);
            frmSupport.UpdateGridView();
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            MemoEdit edit = sender as MemoEdit;
            Keys CtrlEnter = Keys.Shift | Keys.Enter;
            if (e.KeyData == CtrlEnter)
            {
                //string text = string.Empty;
                //if (edit.EditValue != null)
                //    text = edit.EditValue.ToString();
                ////edit.EditValue = string.Format("{0}{1}", text, Environment.NewLine);
                //edit.SelectionStart = edit.Text.Length;
                //e.Handled = true;
                //e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMessage.Text))
                    MessageBox.Show("Vui lòng nhập text");
                else
                {
                    ER_Support support = new ER_Support();
                    support.ParentID = supportId;
                    support.Sender = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                    support.Message = txtMessage.Text;
                    support.Created = DateTime.Now;
                    support.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                    support.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    support.Modified = DateTime.Now;
                    support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                    support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    support.Status = 1;
                    dbSupport.AddSupport(support);
                    txtMessage.Text = "";
                    UpdateGridView();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }            
            
        }

        private void btnAssignTV_Click(object sender, EventArgs e)
        {
            if (lookUpTV.EditValue == null)
                MessageBox.Show("Vui lòng chọn tiếp viên cần gán");
            else
            {
                TiepVienLookUpModel tiepvien = (TiepVienLookUpModel)lookUpTV.Properties.GetDataSourceRowByKeyValue(lookUpTV.EditValue);                
                ER_Support support = dbSupport.GetSupportBySupportID(supportId);
                support.Sender = tiepvien.FirstNameVn;
                support.Creatorid = tiepvien.Code_tv;
                support.Creator = tiepvien.name_tv;
                support.Modified = DateTime.Now;
                support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                dbSupport.UpdateSupport(support);
                UpdateGridView();
                MessageBox.Show("Đã gán thành công!");
                frmSupport.UpdateGridView();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpNV.EditValue == null)
                MessageBox.Show("Vui lòng chọn nhân viên cần tick");
            else
            {
                TiepVienLookUpModel tiepvien = (TiepVienLookUpModel)lookUpNV.Properties.GetDataSourceRowByKeyValue(lookUpNV.EditValue);
                ER_Support support = dbSupport.GetSupportBySupportID(supportId);
                support.Status = 3;
                support.Assignee = tiepvien.Code_tv;
                support.AssigneeName = tiepvien.FirstNameVn;
                support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                dbSupport.UpdateSupport(support);                
                MessageBox.Show("Đã tick thành công!");
                frmSupport.UpdateGridView();
            }
        }
    }
}