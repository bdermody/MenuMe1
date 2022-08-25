using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MenuMe1
{
    public class EmailSender
    {
        public void SendEmail()
        {
            string fromMail = "bdermody9816@gmail.com";
            string fromPassword = "vouucviyyifuycaj";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Bienvenido a Menu Me!";
            message.To.Add(new MailAddress("bdermodycas@gmail.com"));
            message.Body = "<html><body> Succes </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
