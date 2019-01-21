using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBackend.Helpers
{
    public class MailHelper
    {
        private const string smtpUser = @"iotest830@outlook.com";
        private const string smtpPassword = @"lubieio123";
        private bool UseSsl = true;
        private const int smtpPortTLS = 587;
        private const int smtpPortSSL = 465;
        private string ServerName = @"smtp-mail.outlook.com";
        private const string defaultFooter = "<p class=\"mail-footer\"><span>Niniejsza wiadomość została wygenerowana automatycznie z aplikacji</span></p>";





        public void SendMail(string reciever, string filepath)
        {
            using (SmtpClient cl = new SmtpClient(ServerName))
            {
                using (MailMessage msg = new MailMessage())
                {
                    if (reciever == null || reciever.Length == 0)
                        return;
                    cl.EnableSsl = UseSsl;
                    cl.DeliveryMethod = SmtpDeliveryMethod.Network;
                    cl.Port = smtpPortTLS;
                    cl.UseDefaultCredentials = false;
                    cl.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    //cl.Timeout = 30 * 1000;
                    cl.ServicePoint.MaxIdleTime = 1;

                    msg.From = new MailAddress(smtpUser);
                    msg.To.Add(reciever);

                    msg.IsBodyHtml = true;
                    //msg.Body = MailBodyString(message);
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.Subject = "Rachunek";
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    string message = $"<html><head><style=\"font-family:Arimo,Roboto,Helvetica Neue;\"></head><p>Dziękujemy za wybór Naszej pizzeri.W załączniku przesyłam rachunek.</a></html>";
                    msg.Body = message;
                    msg.Attachments.Add(new Attachment(filepath));
                    cl.Send(msg);
                }
            }
        }
    }
}
