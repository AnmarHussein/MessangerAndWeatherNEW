using Core.Service;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Core.DTO;
using System;
using System.IO;

namespace infra.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private EmailSMTP GetDataEmailSMTP()
        {
            EmailSMTP emailSMTP = new EmailSMTP();
            emailSMTP.Host = _configuration["Smtp:Host"];
            emailSMTP.Port = Int32.Parse(_configuration["Smtp:Port"]);
            emailSMTP.Username = _configuration["Smtp:Username"];
            emailSMTP.Password = _configuration["Smtp:Password"];
            return emailSMTP;
        }
        public bool SendBlockEmail(FRINEDEMAIL frinedEmail)
        {
            EmailSMTP emailSMTP = GetDataEmailSMTP();

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", emailSMTP.Username);
            MailboxAddress to = new MailboxAddress("user", frinedEmail.FROMEMAIL);

            builder.HtmlBody = File.ReadAllText(@"here .. \MessangerAndWeather\Core\Final_Task_DataBase\Block_Template.txt");
            builder.HtmlBody = builder.HtmlBody.Replace("{USERFROMBLOCK}", frinedEmail.FROMNAME);
            builder.HtmlBody = builder.HtmlBody.Replace("{USERTOBLOCK}", frinedEmail.TONAME);
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "Block User";

            using (var item = new SmtpClient())
            {
                item.Connect(emailSMTP.Host, emailSMTP.Port, false);
                item.Authenticate(emailSMTP.Username, emailSMTP.Password);
                item.Send(message);
                item.Disconnect(true);

            }
            return true;
        }
    }
}
