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
using ERMs.Data;
using System.Net;
using System.IO;
using Erms.Utils;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmFormAttachment : ERMs.SharedBase.XtraFormMDIBase
    {
        const string apiLocalPath = @"D:/Sites/CrewAPI";
        const string apiServerPath = @"https://api.crew.vn";

        //const string apiLocalPath = @"D:/Sites/APIservices_forDev";
        //const string apiServerPath = @"http://118.69.198.212:8090";

        FormDal db = new FormDal();
        private HR_Forms mForm;
        public FrmFormAttachment()
        {
            InitializeComponent();
        }

        public FrmFormAttachment(HR_Forms form)
        {
            InitializeComponent();
            mForm = form;
        }

        private void FrmFormAttachment_Load(object sender, EventArgs e)
        {
            if (mForm.Attachments == null)
                return;
            List<EX_Attachment> lstAttachment = db.GetAttachmentByAttachmentID(mForm.Attachments.Value);
            panelImage.Controls.Clear();
            //ImageListBoxItem attachmentItem = null;
            int xIndex = 1;
            foreach (EX_Attachment attachment in lstAttachment)
            {                
                PictureBox pb = new PictureBox();
                //pb.ImageLocation = attachment.FilePath.Replace(@"\", @"/").Replace(apiLocalPath, apiServerPath);
                pb.ImageLocation = AttachmentUtils.GetAttachmentUrl(attachment.FilePath);
                pb.Height = 150;
                pb.Width = 150;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Location = new Point(xIndex, 1);
                pb.Cursor = Cursors.Hand;
                pb.MouseClick += Pb_MouseClick;
                //pb.ContextMenuStrip = contextMenuStripAttachment;

                panelImage.Controls.Add(pb);
            }
        }

        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox test = (PictureBox)sender;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(((PictureBox)sender).ImageLocation, Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));
            System.Diagnostics.Process.Start(Path.GetTempPath() + Path.GetFileName(((PictureBox)sender).ImageLocation));
        }
    }
}