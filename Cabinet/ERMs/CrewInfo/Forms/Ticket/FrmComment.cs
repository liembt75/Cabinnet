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
    public partial class FrmComment : ERMs.SharedBase.XtraDialogBase
    {
        public string comment;
        public FrmComment()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(memoEdit1.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            comment = memoEdit1.Text;
        }
    }
}