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

namespace ERMs.SharedBase
{
    public partial class XtraDialogBase : DevExpress.XtraEditors.XtraForm
    {
        public XtraDialogBase()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void XtraDialogBase_Load(object sender, EventArgs e)
        {

        }
    }
}