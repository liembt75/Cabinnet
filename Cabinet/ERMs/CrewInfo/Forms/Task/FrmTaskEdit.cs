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
using DevExpress.XtraEditors;
using ERMs.Data;
using System.IO;
using System.Net;
using Erms.Utils;
using ERMs.SharedBase;
using DevExpress.XtraEditors.Controls;

namespace CrewInfo.Forms.Task
{    
    public partial class FrmTaskEdit : ERMs.SharedBase.XtraDialogBase
    {        
        int taskId;
        TaskDal db = new TaskDal();
        SystemDAL dbSys = new SystemDAL();
        TaskModel item;
        List<TokenEditToken> lstTokenAccount = new List<TokenEditToken>();
        FrmManagementTask parentForm = null;
        public FrmTaskEdit(int taskId, List<TokenEditToken> iLstTokenAccount, FrmManagementTask iParentForm) : base()
        {
            InitializeComponent();
            this.taskId = taskId;
            this.lstTokenAccount = iLstTokenAccount;
            parentForm = iParentForm;
        }

        private void FrmTaskEdit_Load(object sender, EventArgs e)
        {            
            InititalData();            
        }

        private void InititalData()
        {
            txtCreated.DateTime = DateTime.Now;
            txtDeadline.DateTime = DateTime.Now;
            tkeTaskEmployee.Properties.Tokens.AddRange(lstTokenAccount);
            tkeTaskManagement2.Properties.Tokens.AddRange(lstTokenAccount);
            tkeTaskMaster.Properties.Tokens.AddRange(lstTokenAccount);
            if (taskId <= 0) //Tao moi
            {
                item = new TaskModel();
                this.Text = "Tạo mới";
                txtTitle.Focus();
                groupBox2.Visible = false;
                groupBox1.Dock = DockStyle.Fill;
                txtCreated.DateTime = DateTime.Now;
                txtDeadline.DateTime = DateTime.Now;
            }
            else
            {
                txtTitle.ReadOnly = true;
                tkeTaskEmployee.ReadOnly = true;
                txtDescription.ReadOnly = true;
                tkeTaskManagement2.ReadOnly = true;
                tkeTaskMaster.ReadOnly = true;
                txtDeadline.ReadOnly = true;
                txtCreated.ReadOnly = true;
                //tokenEditAttach.ReadOnly = true;
                btnAttach.Enabled = false;
                this.Text = string.Format("Task #{0}", taskId);
                tbxProgress.Focus();

                item = db.GetTaskByID(taskId);
                if (item == null) return;
                txtTitle.EditValue = item.Title;
                txtDescription.EditValue = item.Description;
                txtDeadline.EditValue = item.Deadline;
                txtCreated.EditValue = item.Date;                
                gcTaskManagement.DataSource = item.lstHR_Task_Management;
                tkeTaskMaster.EditValue = item.TaskMaster.ToString();

                if (item.AttachmentGroupId != null)
                {
                    List<EX_Attachment> lstAttachment = db.GetTaskAttachmentByGroupID(item.AttachmentGroupId.Value);
                    foreach (EX_Attachment attach in lstAttachment)
                    {
                        string filePath = attach.FilePath.Replace(@"\", @"/").Replace(@"D:/Sites/APIServices", @"http://api.doantiepvien.com.vn");
                        tokenEditAttach.Properties.Tokens.Add(new TokenEditToken(attach.FileNameReal, filePath));
                        if (tokenEditAttach.Properties.Tokens.Count > 0)
                        {
                            tokenEditAttach.EditValue += ",";
                        }
                        tokenEditAttach.EditValue += filePath;
                    }
                }

                decimal proccessMain = 0;
                StringBuilder sb = new StringBuilder();
                foreach (var taskManagement in item.lstHR_Task_Management)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(taskManagement.AssigneeID);
                    proccessMain += Convert.ToDecimal(taskManagement.Progress);
                }
                if (item.lstHR_Task_Management.Count > 0)
                    spinMainProcess.Value = (proccessMain / item.lstHR_Task_Management.Count);
                tkeTaskEmployee.EditValue = sb.ToString();
                sb.Clear();
                foreach (var taskManagement in item.lstHR_Task_Management2)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(taskManagement.AssigneeID);
                }
                tkeTaskManagement2.EditValue = sb.ToString();

                var employee = item.lstHR_Task_Management.Where(i => i.AccountID == ERMs.Sys.ConfigurationSetting.UserInfo.Userid).FirstOrDefault();
                if (employee != null && item.Completed == null)   //La nguoi xu ly
                {                    
                    if (employee.Progress != null)
                        tbxProgress.Value = employee.Progress.Value;
                    txtReason.Text = employee.Reason;
                    tbxNote.Text = employee.Note;
                    tbxProgress.Focus();
                }
                else //La nguoi su dung
                {
                    panelButton.Visible = false;
                    panelControl2.Visible = false;
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskId <= 0)
                {
                    bool isError = false;
                    //Validate
                    if (string.IsNullOrEmpty(txtTitle.Text))
                    {
                        isError = true;
                        lbTitle.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbTitle.ForeColor = Color.Black;
                    }
                    if (tkeTaskEmployee.EditValue == null)
                    {
                        isError = true;
                        lbTaskEmployee.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbTaskEmployee.ForeColor = Color.Black;
                    }
                    if (string.IsNullOrEmpty(txtDescription.Text))
                    {
                        isError = true;
                        lbDescription.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbDescription.ForeColor = Color.Black;
                    }
                    if (tkeTaskMaster.EditValue == null)
                    {
                        isError = true;
                        lbTaskMaster.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbTaskMaster.ForeColor = Color.Black;
                    }
                    //if (txtDeadline.EditValue == null)
                    //{
                    //    isError = true;
                    //    lbDeadLine.ForeColor = Color.Red;
                    //}
                    //else
                    //{
                    //    lbDeadLine.ForeColor = Color.Black;
                    //}
                    if (txtCreated.EditValue == null)
                    {
                        isError = true;
                        lbCreated.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbCreated.ForeColor = Color.Black;
                    }
                    if (isError)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string userName = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    HR_Task task = new HR_Task();
                    task.Date = txtCreated.DateTime;
                    task.Title = txtTitle.Text;
                    task.Description = txtDescription.Text;
                    task.TaskMaster = Convert.ToInt32(tkeTaskMaster.EditValue);
                    if (!string.IsNullOrEmpty(txtDeadline.Text))
                        task.Deadline = txtDeadline.DateTime;
                    task.Created = DateTime.Now;                    
                    task.Creator = userName;
                    task.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();
                    

                    List<HR_Task_Management> lstTaskManageMent = new List<HR_Task_Management>();
                    List<HR_Task_Management2> lstTaskManageMent2 = new List<HR_Task_Management2>();
                    HR_Task_Management taskManagement = null;
                    HR_Task_Management2 taskManagement2 = null;
                    foreach (TokenEditToken token in tkeTaskEmployee.SelectedItems)
                    {
                        taskManagement = new HR_Task_Management();
                        taskManagement.TaskID = task.ID;
                        taskManagement.AssigneeID = Convert.ToInt32(token.Value);
                        taskManagement.Progress = 0;
                        taskManagement.Created = DateTime.Now;                        
                        taskManagement.Creator = userName;
                        taskManagement.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();                        
                        lstTaskManageMent.Add(taskManagement);
                    }
                    foreach (TokenEditToken token in tkeTaskManagement2.SelectedItems)
                    {
                        taskManagement2 = new HR_Task_Management2();
                        taskManagement2.TaskID = task.ID;
                        taskManagement2.AssigneeID = Convert.ToInt32(token.Value);
                        taskManagement2.Progress = 0;
                        taskManagement2.Created = DateTime.Now;                        
                        taskManagement2.Creator = userName;
                        taskManagement2.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString();                        
                        lstTaskManageMent2.Add(taskManagement2);
                    }
                    if (tokenEditAttach.EditValue != null)
                    {
                        List<string> lstFile = tokenEditAttach.EditValue.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        int groupID = ApiUtils.UploadFiles(lstFile, ERMs.Sys.ConfigurationSetting.UserInfo.Userid.ToString(), ERMs.Sys.ConfigurationSetting.UserInfo.Token);
                        if (groupID != -1)
                        {
                            task.AttachmentGroupId = groupID;
                        }
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    }
                    db.Save(task, lstTaskManageMent, lstTaskManageMent2);
                    parentForm.UpdateGrid();
                    MessageBox.Show("Thành công!");
                    this.Close();
                }
                else
                {
                    var employee = item.lstHR_Task_Management.Where(i => i.AccountID == ERMs.Sys.ConfigurationSetting.UserInfo.Userid).FirstOrDefault();
                    if (employee != null)
                    {
                        employee.Progress = Convert.ToInt32(tbxProgress.Value);
                        employee.Note = tbxNote.Text;
                        employee.Reason = txtReason.Text;
                        db.UpdateTaskManagement(employee);
                    }
                    parentForm.UpdateGrid();
                    MessageBox.Show("Thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tkeTaskEmployee_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            Image image = Properties.Resources.account;
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
        }

        private void tkeTaskManagement2_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            Image image = Properties.Resources.account;
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
        }

        private void tkeTaskMaster_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            Image image = Properties.Resources.account;
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
        }

        private void tokenEditAttach_CustomDrawTokenGlyph(object sender, TokenEditCustomDrawTokenGlyphEventArgs e)
        {
            Image image = Properties.Resources.image;
            if (image != null) e.Cache.Paint.DrawImage(e.Graphics, image, e.GlyphBounds, new Rectangle(Point.Empty, image.Size), true);
            e.Handled = true;
        }

        private void tkeTaskMaster_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string newValue = (string)e.NewValue;
            string[] separators = new string[tkeTaskMaster.Properties.Separators.Count];
            for (int i = 0; i < tkeTaskMaster.Properties.Separators.Count; i++)
            {
                separators[i] = tkeTaskMaster.Properties.Separators[i];
            }
            string[] tokenCount = newValue.Split(separators, StringSplitOptions.None);
            e.Cancel = tokenCount.Count() > 1;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Images | *.png; *.bmp; *.jpg";                
                if (file.ShowDialog() == DialogResult.OK && file.FileName.Trim() != "")
                {
                    tokenEditAttach.Properties.Tokens.Add(new TokenEditToken(file.SafeFileName, file.FileName));
                    if (tokenEditAttach.Properties.Tokens.Count > 0)
                    {
                        tokenEditAttach.EditValue += ",";                        
                    }
                    tokenEditAttach.EditValue += file.FileName;
                }                
            }
            catch { }
        }

        private void tokenEdit1_Properties_TokenDoubleClick(object sender, TokenEditTokenClickEventArgs e)
        {
            TokenEdit token = sender as TokenEdit;
            if (token.CheckedItem.Value.ToString().Contains("api.doantiepvien.com.vn"))
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(token.CheckedItem.Value.ToString(), Path.GetTempPath() + token.CheckedItem.Description);
                System.Diagnostics.Process.Start(Path.GetTempPath() + token.CheckedItem.Description);
            }
            else
            {
                System.Diagnostics.Process.Start(token.CheckedItem.Value.ToString());
            }
        }

        private void txtDeadline_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton Button = e.Button;
            if (Button.Kind == ButtonPredefines.Delete)
            {
                txtDeadline.EditValue = "";
            }
        }
    }
}
