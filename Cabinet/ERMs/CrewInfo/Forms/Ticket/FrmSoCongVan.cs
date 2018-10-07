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

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmSoCongVan : ERMs.SharedBase.XtraDialogBase
    {
        public string soCV;
        public FrmSoCongVan()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            soCV = txtSoCV.Text;
        }
    }
}