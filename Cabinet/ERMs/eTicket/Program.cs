using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using ERMs.SharedBase;
using System.Threading.Tasks;
using Squirrel;

namespace eTicket
{
    static class Program
    {
        private const string SIGNIN = "#4";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

#if (DEBUG)

            string code = SIGNIN + Guid.NewGuid().ToString();
            FrmQRCode frm = new FrmQRCode(code);

            //FrmSignIn frm;
            //frm = new FrmSignIn("phongth", "0987654321");
#else
            Task.Run(async () => {
                try
                {
                    using (var mgr = new UpdateManager(@"\\10.105.2.243\Publish\Ticket"))
                    {
                        await mgr.UpdateApp();
                    }
                }
                catch
                { }
            });
            //FrmSignIn frm;
            //frm = new FrmSignIn();
            string code = SIGNIN + Guid.NewGuid().ToString();
            FrmQRCode frm = new FrmQRCode(code);
#endif
            if (frm.ShowDialog() != DialogResult.OK)
                Application.Exit();
            else
            {

                //FrmMain frmMain = new FrmMain();
                Application.Run(new FrmMain());
            }

            //Application.Run(new Form1());
        }
    }
}
