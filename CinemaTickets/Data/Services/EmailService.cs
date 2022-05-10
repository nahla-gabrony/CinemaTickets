using CinemaTickets.Data.ViewModels.Email;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"Data/EmailTemplate/{0}.html";
        private readonly STMPConfigViewModel _smtpConfig;

        public EmailService(IOptions<STMPConfigViewModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        public async Task SendEmailforConfirmationEmail(UserEmailOptionsViewModel model)
        {
            model.Subject = "Cinema Tickets";
            model.Body = UpdatePlaceholder(GetEmailBody("ConfirmationEmail"), model.Placeholders);
            await SendEmail(model);
        }
        public async Task SendEmailforForgotPassword(UserEmailOptionsViewModel model)
        {
            model.Subject = "Cinema Tickets";
            model.Body = UpdatePlaceholder(GetEmailBody("ForgotPassword"), model.Placeholders);
            await SendEmail(model);
        }
        private async Task SendEmail(UserEmailOptionsViewModel model)
        {
            MailMessage mail = new MailMessage
            {
                Subject = model.Subject,
                Body = model.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML
            };

            foreach (var Email in model.ToEmails)
            {
                mail.To.Add(Email);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

        private string UpdatePlaceholder(string text, List<KeyValuePair<string, string>> placeholders)
        {
            if(!string.IsNullOrEmpty(text) && placeholders != null)
            {
                foreach (var palceholder in placeholders)
                {
                    if (text.Contains(palceholder.Key))
                    {
                        text = text.Replace(palceholder.Key, palceholder.Value);
                    }
                }
            }
            return text;
        }
    }
}
