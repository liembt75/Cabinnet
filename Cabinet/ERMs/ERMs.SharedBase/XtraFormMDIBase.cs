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

    public partial class XtraFormMDIBase : DevExpress.XtraEditors.XtraForm
    {
        private int id;
        public int ID { get { return id; } }
        public XtraFormMDIBase() : base()
        {
            InitializeComponent();
        }

        public XtraFormMDIBase(int _id) : this()
        {
            id = _id;
        }

        public virtual void HideNav()
        {
        }

        public virtual void ShowNav()
        {
        }

        public void XtraFormMDIBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }            
        }
    }
}