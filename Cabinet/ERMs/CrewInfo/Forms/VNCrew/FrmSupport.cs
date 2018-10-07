using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERMs.Data.Task;
using DevExpress.XtraGrid.Columns;
using ERMs.Data;
using Erms.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using ERMs.Data.Support;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSupport : ERMs.SharedBase.XtraFormMDIBase
    {
        int supportId;
        SupportDal db = new SupportDal();
        BindingSource bis = new BindingSource();
        SystemDAL dbSystem = new SystemDAL();
        public List<TiepVienLookUpModel> lstSysAccount;

        public FrmSupport():base()
        {
            InitializeComponent();
        }

        public FrmSupport(int id):this()
        {
            supportId = id;
        }
        private void FrmSupport_Load(object sender, EventArgs e)
        {
            this.Text = "Support";
            splitContainerControl1.Dock = DockStyle.Fill;
            cbxStatus.EditValue = "1";
            txtMessage.Focus();
            StyleFormatCondition styleComplete = new StyleFormatCondition();
            styleComplete.Condition = FormatConditionEnum.Expression;
            styleComplete.Expression = "[Status] = 2";            
            styleComplete.Appearance.Options.UseForeColor = true;
            styleComplete.Appearance.ForeColor = Color.Green;            
            styleComplete.Column = clTinhTrang;                       
            gvSupport.FormatConditions.Add(styleComplete);

            StyleFormatCondition styleHidden = new StyleFormatCondition();
            styleHidden.Condition = FormatConditionEnum.Expression;
            styleHidden.Expression = "[Status] = 5";
            styleHidden.Appearance.Options.UseForeColor = true;
            styleHidden.Appearance.ForeColor = Color.Gray;
            styleHidden.Column = clTinhTrang;
            gvSupport.FormatConditions.Add(styleHidden);

            StyleFormatCondition styleStick = new StyleFormatCondition(FormatConditionEnum.Equal, gvSupport.Columns["Status"], null, 3);
            styleStick.Condition = FormatConditionEnum.Expression;
            styleStick.Expression = "[Status] = 3";
            styleStick.Appearance.Options.UseForeColor = true;
            styleStick.Appearance.ForeColor = Color.Red;
            styleStick.Column = clTinhTrang;            
            gvSupport.FormatConditions.Add(styleStick);
            txtFromdate.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTodate.DateTime = DateTime.Now;
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            
            UpdateGridView();
            lstSysAccount = dbSystem.GetSysAccounts();
        }

        public void UpdateGridView()
        {
            DateTime fromdate, todate;
            DateTime now = DateTime.Now;
            fromdate = txtFromdate.DateTime == null ? DateTime.Today : txtFromdate.DateTime;
            todate = txtTodate.DateTime == null ? DateTime.Today.AddDays(7) : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);
            int? status = null;
            if (cbxStatus.EditValue != null)
            {
                status = Convert.ToInt32(cbxStatus.EditValue);
            }
            gridControl1.DataSource = db.GetTickets(fromdate, todate, ERMs.Sys.ConfigurationSetting.UserInfo.Code, "", 1, 10000000, status);
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
                MessageBox.Show("Vui lòng nhập text");
            else
            {
                ER_Support support = new ER_Support();
                support.ParentID = 0;
                support.Sender = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                support.Message = txtMessage.Text;                
                support.Created = DateTime.Now;
                support.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                support.Modified = DateTime.Now;
                support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                support.Status = 1;
                db.AddSupport(support);
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
                    int groupID = ApiUtils.UploadSupportFiles(lstFile, ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString(), ERMs.Sys.ConfigurationSetting.UserInfo.Token, "0");                    
                    if (groupID != -1)
                    {                        
                        //ER_Support support = new ER_Support();
                        //support.ParentID = 0;
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
                        //db.AddSupport(support);
                        txtMessage.Text = "";                        
                        UpdateGridView();
                    }                    
                }
            }
            catch { }
        }

        private void gvSupport_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //if (e.Column.FieldName == "ID")
            //{
            //    int id = (int)e.CellValue;
            //    FrmSupportDetail frmDetails = new FrmSupportDetail(id);                
            //    frmDetails.MdiParent = this.ParentForm;
            //    frmDetails.Show();
            //}
            if (e.Column.Name == "clComplete")
            {
                GridView view = sender as GridView;
                API_ER_USP_Get_Supports2_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Supports2_Result;
                support.Status = 2;
                db.UpdateSupportStatus(support);
                UpdateGridView();
            }
            else if (e.Column.Name == "clTick")
            {
                GridView view = sender as GridView;
                API_ER_USP_Get_Supports2_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Supports2_Result;
                support.Status = 3;
                support.Assignee = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                support.AssigneeName = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName.ToString();
                db.UpdateSupport(support);
                UpdateGridView();
            }
            //else
            //{
            //    GridView view = sender as GridView;
            //    API_ER_USP_Get_Supports2_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Supports2_Result;
            //    FrmSupportDetail frmDetails = new FrmSupportDetail(support.ID, this);
            //    frmDetails.MdiParent = this.ParentForm;
            //    frmDetails.Show();
            //}
        }

        private void gvSupport_RowClick(object sender, RowClickEventArgs e)
        {
            GridHitInfo hitInfo = gvSupport.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell == false && hitInfo.InRow == true)
            {
                GridView view = sender as GridView;
                API_ER_USP_Get_Supports2_Result support = view.GetRow(e.RowHandle) as API_ER_USP_Get_Supports2_Result;
                FrmSupportDetail frmDetails = new FrmSupportDetail(support.ID, this);
                frmDetails.MdiParent = this.ParentForm;
                frmDetails.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateGridView();
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
                    support.ParentID = 0;
                    support.Sender = ERMs.Sys.ConfigurationSetting.UserInfo.ShortName;
                    support.Message = txtMessage.Text;
                    support.Created = DateTime.Now;
                    support.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                    support.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    support.Modified = DateTime.Now;
                    support.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code.ToString();
                    support.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    support.Status = 1;
                    db.AddSupport(support);
                    txtMessage.Text = "";
                    UpdateGridView();
                }
            }
        }
    }
}
