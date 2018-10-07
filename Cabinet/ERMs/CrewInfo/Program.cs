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
using System.Drawing;
using Erms.Utils;

namespace CrewInfo
{
    static class Program
    {
        private const string SIGNIN = "#3";
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

            //string server, database, user, pass;
            //RegistryUtils.GetServerValue(out server, out database, out user, out pass);

            //string secretKey = Environment.MachineName;
            //FrmServer frmServer = new FrmServer();
            //if (server != null) frmServer.server = Crypto.DecryptStringAES(server, secretKey);
            //if (database != null) frmServer.database = Crypto.DecryptStringAES(database, secretKey);
            //if (user != null) frmServer.user = Crypto.DecryptStringAES(user, secretKey);
            //if (pass != null) frmServer.pass = Crypto.DecryptStringAES(pass, secretKey);

            //if (frmServer.Login() == false)
            //{
            //    if (frmServer.ShowDialog() != DialogResult.OK)
            //        Environment.Exit(1);
            //    else
            //    {
            //        RegistryUtils.AddServerValue("server", Crypto.EncryptStringAES(frmServer.server, secretKey), Microsoft.Win32.RegistryValueKind.String);
            //        RegistryUtils.AddServerValue("database", Crypto.EncryptStringAES(frmServer.database, secretKey), Microsoft.Win32.RegistryValueKind.String);
            //        RegistryUtils.AddServerValue("user", Crypto.EncryptStringAES(frmServer.user, secretKey), Microsoft.Win32.RegistryValueKind.String);
            //        RegistryUtils.AddServerValue("pass", Crypto.EncryptStringAES(frmServer.pass, secretKey), Microsoft.Win32.RegistryValueKind.String);
            //    }
            //}                        

            string code = SIGNIN + Guid.NewGuid().ToString();
            FrmQRCode frm = new FrmQRCode(code);

            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Tahoma", 12);

            //#if (DEBUG)            
            //            //FrmSignIn frm;
            //            //frm = new FrmSignIn("phongth", "0987654321");
            //            string code = SIGNIN + Guid.NewGuid().ToString();            
            //            FrmQRCode frm = new FrmQRCode(code);
            //#else
            //            Task.Run(async () => {
            //                try
            //                {
            //                    using (var mgr = new UpdateManager(@"\\10.105.2.243\Publish\ERMs"))
            //                    {
            //                        await mgr.UpdateApp();
            //                    }
            //                }
            //                catch
            //                { }
            //            });
            //            //FrmSignIn frm;
            //            //frm = new FrmSignIn();
            //            string code = SIGNIN + Guid.NewGuid().ToString();
            //            FrmQRCode frm = new FrmQRCode(code);
            //#endif

            if (frm.ShowDialog() != DialogResult.OK)
                Application.Exit();
            else
            {

                FrmMain frmMain = new FrmMain();
//#if (DEBUG)
//                frmMain.mUserName = "haibt";
//#else
//            frmMain.mUserName = frm.mUserName;
//#endif
                Application.Run(frmMain);
            }
        }
    }
}
