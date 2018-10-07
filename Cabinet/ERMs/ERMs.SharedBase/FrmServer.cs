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
using System.Data.SqlClient;
using ERMs.Data;

namespace ERMs.SharedBase
{
    public partial class FrmServer : DevExpress.XtraEditors.XtraForm
    {
        public string server, database, user, pass;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = string.Format(@"metadata = res://*/ERMSModel.csdl|res://*/ERMSModel.ssdl|res://*/ERMSModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""", 
                    txtServer.Text.Trim(), 
                    txtDatabase.Text.Trim(), 
                    txtUser.Text.Trim(),
                    txtPassword.Text.Trim());

                using (ERMSEntities context = new ERMSEntities(connectionString))
                {
                    context.Sys_Account.FirstOrDefault();
                    server = txtServer.Text.Trim();
                    database = txtDatabase.Text.Trim();
                    user = txtUser.Text.Trim();
                    pass = txtPassword.Text.Trim();                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông tin server không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        public bool Login()
        {
            try
            {                
                if (server == null ||
                    database == null ||
                    user == null ||
                    pass == null)
                    return false;
                else
                {
                    string connectionString = string.Format(@"metadata = res://*/ERMSModel.csdl|res://*/ERMSModel.ssdl|res://*/ERMSModel.msl;provider=System.Data.SqlClient;provider connection string= ""data source={0};initial catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True;application name=EntityFramework&quot;""",
                        server,
                        database,
                        user,
                        pass);

                    using (ERMSEntities context = new ERMSEntities(connectionString))
                    {
                        context.Sys_Account.FirstOrDefault();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}