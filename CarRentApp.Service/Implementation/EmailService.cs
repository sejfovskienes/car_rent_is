using CarRentApp.Domain.Email;
using CarRentApp.Domain.Models;
using CarRentApp.Service.Interface;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailMessage allMails)
        {
            var emailMessage = new MimeMessage
            {
                Sender = new MailboxAddress("Car Rent", "rentc753@gmail.com"),
                Subject = allMails.Subject
            };

            emailMessage.From.Add(new MailboxAddress("Car Rent", "rentc753@gmail.com"));

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = allMails.Content };

            emailMessage.To.Add(new MailboxAddress(allMails.MailTo, allMails.MailTo));

            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOptions = SecureSocketOptions.Auto;

                    await smtp.ConnectAsync(_mailSettings.SmtpServer, 587, socketOptions);

                    if (!string.IsNullOrEmpty(_mailSettings.SmtpUserName))
                    {
                        await smtp.AuthenticateAsync(_mailSettings.SmtpUserName, _mailSettings.SmtpPassword);
                    }
                    await smtp.SendAsync(emailMessage);


                    await smtp.DisconnectAsync(true);
                }
            }
            catch (SmtpException ex)
            {
                throw ex;
            }

        }
    }
}
