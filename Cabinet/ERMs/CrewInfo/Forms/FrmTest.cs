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

namespace CrewInfo.Forms
{
    public partial class FrmTest : ERMs.SharedBase.XtraFormMDIBase
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel);
            MessageBox.Show(ERMs.Sys.ConfigurationSetting.ActiveDirInfo.LDAP);
        }
    }
}