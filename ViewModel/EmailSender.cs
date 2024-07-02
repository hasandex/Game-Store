using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace GameZone.ViewModel
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "dexter2003w@outlook.com";
            var fpassword = "leo@@em00";
            var Msg = new MailMessage();
            Msg.From = new MailAddress(fmail);
            Msg.Subject = subject;
            Msg.To.Add(email);
            Msg.Body = $"<html><body>{htmlMessage}</body></html>";
            Msg.IsBodyHtml = false;
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
         
                EnableSsl = true,
                Credentials = new NetworkCredential(fmail,fpassword),
                Port = 587,
            };
            smtpClient.Send(Msg);
        }
    }
}
