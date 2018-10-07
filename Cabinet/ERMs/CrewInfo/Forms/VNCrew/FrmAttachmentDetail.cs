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

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmAttachmentDetail : DevExpress.XtraEditors.XtraForm
    {
        public string ImageUrl = "";
        public FrmAttachmentDetail()
        {
            InitializeComponent();
        }

        private void FrmAttachmentDetail_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.ImageLocation = ImageUrl;            
            pb.LoadCompleted += Pb_LoadCompleted;
            this.Controls.Add(pb);
        }

        private void Pb_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            PictureBox pb = ((PictureBox)sender);
            this.Height = pb.Height = pb.Image.Size.Height;
            this.Width = pb.Width = pb.Image.Size.Width;
        }
    }
}