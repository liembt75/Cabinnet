using DevExpress.XtraSplashScreen;
using ERMs.Data;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMs.SharedBase
{
    public partial class FrmQRCode : XtraFormBase
    {
        //private const string SIGNIN = "#4";
        //const int AID = 4;
        string code;
        LoggedInDal db = new LoggedInDal();

        public FrmQRCode(string _QRcode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.HelpButton = true;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            code = _QRcode;
            this.Text = "Login";
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            lbVersion.Text = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
            label4.Text = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

        private void FrmQRCode_Load(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;

            //pictureEdit1.Image = qrCodeImage;
            //pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                ERMs.Sys.UserInfo o = new ERMs.Sys.UserInfo();
                o.InitDatabase();

#if (DEBUG)
                o.InitUser("2460");


#else
                if (code.Length > 2)
                {
                    int codeID = int.Parse(code[1].ToString());
                    string codeText = code.Substring(2);
                    Sys_LoggedIn loggedIn = db.getLoggedInByQRCode(codeID, codeText);
                    if (loggedIn == null)
                    {
                        MessageBox.Show("Please use vncrew on smartphone or table to scan qr code", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SplashScreenManager.CloseForm(false);
                        return;
                    }
                    try
                    {
                        loggedIn.Logged = DateTime.Now;
                        loggedIn.MAC = GetMacAddress();
                        List<string> lstIP = GetIP();
                        if (lstIP.Count > 0)
                            loggedIn.IPv4 = lstIP[0];
                        if (lstIP.Count > 1)
                            loggedIn.IPv6 = lstIP[1];
                        loggedIn.LocalUser = System.Environment.UserName;
                        loggedIn.DeviceName = System.Environment.MachineName;
                        loggedIn.DeviceOS = System.Environment.OSVersion.ToString();
                        db.UpdateLoggedIn(loggedIn);
                    }
                    catch { }
                    o.InitUser(loggedIn.CID);
                }         
#endif
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GetMacAddress()
        {
            return 
                    (
                        from nic in NetworkInterface.GetAllNetworkInterfaces()
                        where nic.OperationalStatus == OperationalStatus.Up
                        select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();
        }

        private List<string> GetIP()
        {
            List<string> lstIP = new List<string>();
            string strHostName = System.Net.Dns.GetHostName(); ;
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            if (addr.Length > 0)
                lstIP.Add(addr[addr.Length - 1].ToString());
            if (addr[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                lstIP.Add(addr[0].ToString()); //ipv6
            }
            return lstIP;
        }

        private void FrmQRCode_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Process.Start("https://crew.vn/vi/tin-tuc/Guide/2/337");
        }

        private void lbLoginOld_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                panelQRCode.Visible = true;
                AcceptButton = btnSubmit;
            }
            else
            {
                panel1.Visible = true;
                panelQRCode.Visible = false;
                AcceptButton = btnAccept;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;                
                panelQRCode.Visible = true;
                AcceptButton = btnSubmit;
            }
            else
            {
                panel1.Visible = true;
                panelQRCode.Visible = false;
                AcceptButton = btnAccept;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                ERMs.Sys.UserInfo o = new ERMs.Sys.UserInfo();
                o.Signin(txtUser.Text.Trim(), txtPassword.Text.Trim());
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
