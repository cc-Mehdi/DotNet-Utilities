using Mail_Service_Training.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Mail_Service_Training.Configuration;

namespace Mail_Service_Training.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toAddress, string subject, string body, bool isBodyHtml = true)
        {
            using (var smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.User, _emailSettings.Password);

                var mailMessage = new MailMessage(_emailSettings.FromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml
                };

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
