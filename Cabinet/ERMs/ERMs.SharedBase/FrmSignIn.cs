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
using ERMs.Sys;

namespace ERMs.SharedBase
{
    public partial class FrmSignIn : DevExpress.XtraEditors.XtraForm
    {
        public string mUserName;
        public FrmSignIn()
        {
            InitializeComponent();
        }

        public FrmSignIn(string _UserName, string _Password):this()
        {
            txtUser.EditValue = _UserName;
            txtPassword.EditValue = _Password;
        }
        private void FrmSignIn_Load(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            //lblVersion.Text= string.Format("Version: {0}.{1}", version.Major, version.Minor);
            lblVersion.Text = string.Format("Version {0}.{1}.{2}", version.Major, version.Minor, version.Build);

            txtUser.SelectAll();
            txtUser.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ERMs.Sys.UserInfo o = new ERMs.Sys.UserInfo();
                o.Signin(txtUser.Text.Trim(), txtPassword.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

           this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAccept_Click(null, null);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAccept_Click(null, null);
        }
    }
}