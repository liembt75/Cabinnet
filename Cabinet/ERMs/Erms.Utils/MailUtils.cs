using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class MailUtils
    {
        public struct MailType
        {
            public List<string> mailTo;
            public string subject;
            public string body;
        }

        const string mailFrom = "doantiepvien.crew@vietnamairlines.com";
        const string userName = "doantiepvien.crew";
        const string passwordMail = "Str@ng1009";
        const string hostMail = "183.90.160.200";
        const int portMail = 25;

        public static void sendMail(string mailTo, string subject, string body)
        {
            try
            {
                SmtpClient smtpclientTCT = new SmtpClient(hostMail, portMail);
                smtpclientTCT.Credentials = new NetworkCredential(userName, passwordMail);

                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress(mailFrom);
                mailmsg.To.Add(new MailAddress(mailTo));
                mailmsg.Subject = subject;
                mailmsg.Body = body;
                mailmsg.IsBodyHtml = true;
                smtpclientTCT.Send(mailmsg);
            }
            catch
            {
                throw;
            }
        }

        public static void sendMail(MailType mailType)
        {
            try
            {
                SmtpClient smtpclientTCT = new SmtpClient(hostMail, portMail);
                smtpclientTCT.Credentials = new NetworkCredential(userName, passwordMail);

                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress(mailFrom);
                foreach (var item in mailType.mailTo)
                {
                    mailmsg.To.Add(new MailAddress(item));
                }
                mailmsg.Subject = mailType.subject;
                mailmsg.Body = mailType.body;
                mailmsg.IsBodyHtml = true;
                if (mailmsg.To.Count > 0)
                    smtpclientTCT.Send(mailmsg);
            }
            catch
            {
                throw;
            }
        }
    }
}
